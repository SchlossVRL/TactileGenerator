using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using System.IO;

namespace Parabox.Stl.Editor
{
	sealed class MultiSTLExport : UnityEditor.Editor
	{
		[MenuItem("Assets/Export Models/STL (Binary)", false, 30)]
		static void MenuExportMultiBinary()
		{
            string path = EditorUtility.SaveFilePanel("Save Meshes to STL", "", Selection.gameObjects.FirstOrDefault().name, "stl");
            foreach(GameObject g in Selection.gameObjects)
            {
			    //ExportWithFileDialog(Selection.gameObjects, FileType.Binary);
                //Debug.Log(path);
                string p = Path.GetDirectoryName(path);
                string s = p + "/" + g.name + ".stl";
                Debug.Log(s);
                Exporter.Export(s, new GameObject[] { g }, FileType.Binary);
            }
		}
	}
}
