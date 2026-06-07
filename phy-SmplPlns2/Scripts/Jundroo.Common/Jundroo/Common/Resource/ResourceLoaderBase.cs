using System.Xml.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Jundroo.Common.Resource
{
	public abstract class ResourceLoaderBase : IResourceLoaderBase
	{
		public virtual Material InstantiateMaterial(string path, bool logErrors = true)
		{
			Material material = Resources.Load<Material>(path);
			if (material == null && logErrors)
			{
				Debug.LogError("The material asset at path '" + path + "' could not be found.");
			}
			return Object.Instantiate(material);
		}

		public virtual GameObject InstantiatePrefab(string path, Transform parent = null, bool logErrors = true)
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null)
			{
				if (logErrors)
				{
					Debug.LogError("The prefab at path '" + path + "' could not be found.");
				}
				return null;
			}
			return Object.Instantiate(gameObject, parent);
		}

		public virtual T InstantiatePrefab<T>(string path, Transform parent = null, bool logErrors = true) where T : MonoBehaviour
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null)
			{
				if (logErrors)
				{
					Debug.LogError("The prefab at path '" + path + "' could not be found.");
				}
				return null;
			}
			if (!Object.Instantiate(gameObject, parent).TryGetComponent<T>(out var component))
			{
				if (logErrors)
				{
					Debug.LogError("The prefab at path '" + path + "' was instantiated but a component of type " + typeof(T).FullName + " could not be found.");
				}
				return null;
			}
			return component;
		}

		public async UniTask<GameObject> InstantiatePrefabAsync(string path, Transform parent = null, bool logErrors = true)
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null)
			{
				if (logErrors)
				{
					Debug.LogError("The prefab at path '" + path + "' could not be found.");
				}
				return null;
			}
			AsyncInstantiateOperation<GameObject> asyncOperation = Object.InstantiateAsync(gameObject, parent);
			await asyncOperation;
			return asyncOperation.Result[0];
		}

		public async UniTask<T> InstantiatePrefabAsync<T>(string path, Transform parent = null, bool logErrors = true) where T : MonoBehaviour
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null)
			{
				if (logErrors)
				{
					Debug.LogError("The prefab at path '" + path + "' could not be found.");
				}
				return null;
			}
			AsyncInstantiateOperation<GameObject> asyncOperation = Object.InstantiateAsync(gameObject, parent);
			await asyncOperation;
			if (!asyncOperation.Result[0].TryGetComponent<T>(out var component))
			{
				if (logErrors)
				{
					Debug.LogError("The prefab at path '" + path + "' was instantiated but a component of type " + typeof(T).FullName + " could not be found.");
				}
				return null;
			}
			return component;
		}

		public virtual T Load<T>(string path, bool logErrors = true) where T : Object
		{
			T val = Resources.Load<T>(path);
			if (val == null && logErrors)
			{
				Debug.LogError("The asset at path '" + path + "' could not be found.");
			}
			return val;
		}

		public virtual T[] LoadAll<T>(string path, bool logErrors = true) where T : Object
		{
			T[] array = Resources.LoadAll<T>(path);
			if (array == null && logErrors)
			{
				Debug.LogError("Unable to load resources at path '" + path + "'.");
			}
			return array;
		}

		public virtual ResourceRequestWrapper<T> LoadAsync<T>(string path, bool logErrors = true) where T : Object
		{
			return new ResourceRequestWrapper<T>(Resources.LoadAsync<T>(path), path, logErrors);
		}

		public virtual AudioClip LoadAudio(string path, bool logErrors = true)
		{
			AudioClip audioClip = Resources.Load<AudioClip>(path);
			if (audioClip == null && logErrors)
			{
				Debug.LogError("The audio clip asset at path '" + path + "' could not be found.");
			}
			return audioClip;
		}

		public virtual Material LoadMaterial(string path, bool logErrors = true)
		{
			Material material = Resources.Load<Material>(path);
			if (material == null && logErrors)
			{
				Debug.LogError("The material asset at path '" + path + "' could not be found.");
			}
			return material;
		}

		public virtual GameObject LoadPrefab(string path, bool logErrors = true)
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null && logErrors)
			{
				Debug.LogError("The prefab at path '" + path + "' could not be found.");
			}
			return gameObject;
		}

		public virtual T LoadScriptableObject<T>(string path, bool logErrors = true) where T : class
		{
			ScriptableObject scriptableObject = Resources.Load<ScriptableObject>(path);
			if (scriptableObject == null)
			{
				if (logErrors)
				{
					Debug.LogError("The scriptable object at path '" + path + "' could not be found.");
				}
				return null;
			}
			if (!(scriptableObject is T result))
			{
				Debug.LogError("The scriptable object at path '" + path + "' was found but it was not the expected type of '" + typeof(T).FullName + "'");
				return null;
			}
			return result;
		}

		public virtual string LoadText(string path, bool logErrors = true)
		{
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			if (textAsset == null)
			{
				if (logErrors)
				{
					Debug.LogError("The text asset at path '" + path + "' could not be found.");
				}
				return null;
			}
			string text = textAsset.text;
			Resources.UnloadAsset(textAsset);
			return text;
		}

		public virtual Texture2D LoadTexture(string path, bool logErrors = true)
		{
			Texture2D texture2D = Resources.Load<Texture2D>(path);
			if (texture2D == null && logErrors)
			{
				Debug.LogError("The texture asset at path '" + path + "' could not be found.");
			}
			return texture2D;
		}

		public XDocument LoadXml(string path, bool logErrors = true)
		{
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			if (textAsset == null)
			{
				if (logErrors)
				{
					Debug.LogError("The text asset at path '" + path + "' could not be found.");
				}
				return null;
			}
			XDocument result = XDocument.Parse(textAsset.text);
			Resources.UnloadAsset(textAsset);
			return result;
		}
	}
}
