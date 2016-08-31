using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.Collections;

public static class PostProcessBuild {

	[PostProcessBuild(999)]
	public static void OnPostProcessBuild( BuildTarget buildTarget, string path)
	{
		if(buildTarget == BuildTarget.iOS)
		{
			string projectPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject pbxProject = new PBXProject();
			pbxProject.ReadFromFile(projectPath);

			string target = pbxProject.TargetGuidByName("Unity-iPhone");
			
			// ▽▽▽▽
			            
			pbxProject.SetBuildProperty(target, "ENABLE_BITCODE", "NO");
			
			//pbxProject.AddFrameworkToProject (target, "AssetsLibrary.framework", true);
			//CopyAndReplaceDirectory("Assets/Lib/mylib.framework", Path.Combine(path, "Frameworks/mylib.framework"));
            //proj.AddFileToBuild(target, proj.AddFile("Frameworks/mylib.framework", "Frameworks/mylib.framework", PBXSourceTree.Source));
            //ファイルを追加
           	//var fileName = "my_file.xml";
            //var filePath = Path.Combine("Assets/Lib", fileName);
            //File.Copy(filePath, Path.Combine(path, fileName));
            //proj.AddFileToBuild(target, proj.AddFile(fileName, fileName, PBXSourceTree.Source));

			// △△△△△

			pbxProject.WriteToFile (projectPath);
		}
	}
}
