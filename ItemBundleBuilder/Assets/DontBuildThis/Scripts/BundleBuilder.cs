using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

#if UNITY_EDITOR

public class BundleBuilder : MonoBehaviour
{
    public string bundleName;
    public string exportFolder;
    
    public void BuildIt()
    {
        var builds = new List<AssetBundleBuild>();
        var asssetBundleFiles = new List<string>();
        
        foreach (var assPath in AssetDatabase.GetAllAssetPaths())
        {
            //the / in Assets/ is crucial
            if (!assPath.StartsWith("Assets/") || assPath.StartsWith("Assets/DontBuildThis"))
            {
                continue;
            }

            asssetBundleFiles.Add(assPath);
            Debug.Log(assPath);
        }
        
        builds.Add(new AssetBundleBuild {
            assetBundleName = bundleName,
            assetNames = asssetBundleFiles.ToArray()
        });
        
        var success = BuildPipeline.BuildAssetBundles(
            exportFolder,
            builds.ToArray(),
            BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows64
        );
        
        Debug.Log($"success: {success}");
    }
}

#endif
