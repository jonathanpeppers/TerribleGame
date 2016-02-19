#r @"packages/FAKE.4.20.0/tools/FakeLib.dll"
open Fake
open System

let Exec command args =
    let result = Shell.Exec(command, args)
    if result <> 0 then failwithf "%s exited with error %d" command result

Target "android" (fun () ->
  Exec "/Applications/Unity/Unity.app/Contents/MacOS/Unity" "-quit -batchmode -logFile -executeMethod BuildScript.Android"
)

RunTarget()