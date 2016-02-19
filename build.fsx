#r @"packages/FAKE.4.20.0/tools/FakeLib.dll"
open Fake
open System

let provisioningId = "8d6a320d-2ac8-438e-a47c-dcc5b51ad491"
let provisioningName = "GenericInHouse"

let Exec command args =
    let result = Shell.Exec(command, args)
    if result <> 0 then failwithf "%s exited with error %d" command result
    
let UnityPath =
    if isUnix then "/Applications/Unity/Unity.app/Contents/MacOS/Unity" else @"C:\Program Files\Unity\Editor\Unity.exe"

Target "clean" (fun () ->
    DeleteDir "build"
    DeleteDir "scratch"
)

Target "android" (fun () ->
    Exec UnityPath "-quit -batchmode -logFile -executeMethod BuildScript.Android"
)

Target "ios-player" (fun () ->
    Exec UnityPath "-quit -batchmode -logFile -executeMethod BuildScript.iOS"
)

Target "ios" (fun () ->
    DeleteFile "build/TerribleGame.ipa"
    DeleteDir "scratch/TerribleGame.xarchive/"
    Exec "xcodebuild" ("-project scratch/Unity-iPhone.xcodeproj -scheme Unity-iPhone archive -archivePath scratch/TerribleGame PROVISIONING_PROFILE=" + provisioningId)
    Exec "xcodebuild" ("-exportArchive -archivePath scratch/TerribleGame.xcarchive -exportPath build/TerribleGame.ipa -exportProvisioningProfile " + provisioningName)
)

"clean" ==> "android"
"clean" ==> "ios-player"

RunTarget()