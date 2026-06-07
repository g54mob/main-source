using System.IO;
using System.Linq;
using UnityEngine;

namespace TriLib.Samples
{
	public class PersistentDataPathLoadSample : MonoBehaviour
	{
		private string[] _files;

		private GameObject _loadedGameObject;

		private void Start()
		{
			string filter = AssetLoaderBase.GetSupportedFileExtensions();
			_files = (from x in Directory.GetFiles(Application.persistentDataPath, "*.*")
				where filter.Contains("*" + FileUtils.GetFileExtension(x) + ";")
				select x).ToArray();
		}

		private void OnGUI()
		{
			GUILayout.Label("Listing assets located at:");
			GUILayout.TextField(Application.persistentDataPath);
			string[] files = _files;
			foreach (string filename in files)
			{
				if (!GUILayout.Button(FileUtils.GetShortFilename(filename), GUILayout.Width((float)Screen.width * 0.25f)))
				{
					continue;
				}
				using (AssetLoader assetLoader = new AssetLoader())
				{
					if (_loadedGameObject != null)
					{
						Object.Destroy(_loadedGameObject);
					}
					_loadedGameObject = assetLoader.LoadFromFile(filename, null, base.gameObject);
					if (_loadedGameObject != null)
					{
						Camera.main.FitToBounds(_loadedGameObject.transform, 3f);
					}
				}
			}
		}
	}
}
