using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Dev.Scripts
{
	public class ExportMeshesScript : MonoBehaviour
	{
		[SerializeField]
		private string _gameObjectFilter = "Street";

		[SerializeField]
		private string _targetPath = "C:\\temp\\mesh_export.stl";

		[SerializeField]
		private bool _obj;

		[ContextMenu("Export Meshes")]
		public void ExportMeshes()
		{
			GameObject gameObject = base.gameObject;
			Vector3 position = gameObject.transform.position;
			Quaternion rotation = gameObject.transform.rotation;
			gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			if (_obj)
			{
				OBJExporter.ExportObj(_targetPath + ".obj", gameObject, generateMaterials: true, exportTextures: true, splitObjects: true, applyScale: true, applyRotation: true, applyPosition: true);
				Debug.Log("OBJ exported to " + _targetPath + ".obj");
			}
			else
			{
				List<MeshFilter> list = new List<MeshFilter>();
				GetGameObjectsFromHierarchy(gameObject, list);
				bool flag = STL.Export(list.ToArray(), _targetPath + ".stl");
				string[] value = list.Select((MeshFilter x) => x.gameObject.name).ToArray();
				Debug.Log(string.Format("Success Result: {0}\nExported {1} game objects to a single mesh: {2}\nGame Objects exported:{3}", flag, list.Count, _targetPath, string.Join("\n", value)));
			}
			gameObject.transform.SetPositionAndRotation(position, rotation);
		}

		private void GetGameObjectsFromHierarchy(GameObject g, List<MeshFilter> list)
		{
			if (g.name.StartsWith(_gameObjectFilter) && g.TryGetComponent<MeshFilter>(out var component))
			{
				list.Add(component);
			}
			if (!(g != null))
			{
				return;
			}
			foreach (Transform item in g.transform)
			{
				GetGameObjectsFromHierarchy(item.gameObject, list);
			}
		}
	}
}
