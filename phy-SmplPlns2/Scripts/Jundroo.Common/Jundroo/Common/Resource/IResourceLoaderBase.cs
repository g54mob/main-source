using System.Xml.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Jundroo.Common.Resource
{
	public interface IResourceLoaderBase
	{
		Material InstantiateMaterial(string path, bool logErrors = true);

		GameObject InstantiatePrefab(string path, Transform parent = null, bool logErrors = true);

		T InstantiatePrefab<T>(string path, Transform parent = null, bool logErrors = true) where T : MonoBehaviour;

		UniTask<GameObject> InstantiatePrefabAsync(string path, Transform parent = null, bool logErrors = true);

		UniTask<T> InstantiatePrefabAsync<T>(string path, Transform parent = null, bool logErrors = true) where T : MonoBehaviour;

		T Load<T>(string path, bool logErrors = true) where T : Object;

		T[] LoadAll<T>(string path, bool logErrors = true) where T : Object;

		ResourceRequestWrapper<T> LoadAsync<T>(string path, bool logErrors = true) where T : Object;

		AudioClip LoadAudio(string path, bool logErrors = true);

		Material LoadMaterial(string path, bool logErrors = true);

		GameObject LoadPrefab(string path, bool logErrors = true);

		T LoadScriptableObject<T>(string path, bool logErrors = true) where T : class;

		string LoadText(string path, bool logErrors = true);

		Texture2D LoadTexture(string path, bool logErrors = true);

		XDocument LoadXml(string path, bool logErrors = true);
	}
}
