using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections;

public class BuildScript 
{
    static void Android()
    {
		PlayerSettings.Android.keyaliasName = "StickmanEPIC";
		PlayerSettings.Android.keyaliasPass =
			PlayerSettings.Android.keystorePass = "hcents3@";
		PlayerSettings.Android.keystoreName = Path.GetFullPath("Android.keystore").Replace('\\', '/');

		if (!Directory.Exists ("build")) {
			Directory.CreateDirectory ("build");
		}

		BuildPipeline.BuildPlayer(GetScenes(), "build/TerribleGame.apk", BuildTarget.Android, BuildOptions.None);
    }

    static string[] GetScenes()
    {
        return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
    }
}
