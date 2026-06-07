using System;
using System.Collections.Generic;
using ModApi;
using ModApi.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityFS;

namespace Assets.Scripts
{
	public class ResourceLoader : IResourceLoader
	{
		private Dictionary<string, Aerofoil> _airfoils = new Dictionary<string, Aerofoil>();

		public ResourceLoader()
		{
			if (Application.isPlaying)
			{
				SceneManager.activeSceneChanged += OnActiveSceneChanged;
			}
		}

		public GameObject InstantiatePrefab(string path, bool logErrors = true)
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null)
			{
				if (logErrors)
				{
					Debug.LogErrorFormat("The prefab at path '{0}' could not be found.", path);
				}
				return null;
			}
			return UnityEngine.Object.Instantiate(gameObject);
		}

		public T InstantiatePrefab<T>(string path, bool logErrors = true)
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null)
			{
				if (logErrors)
				{
					Debug.LogErrorFormat("The prefab at path '{0}' could not be found.", path);
				}
				return default(T);
			}
			return UnityEngine.Object.Instantiate(gameObject).GetComponent<T>();
		}

		public T Load<T>(string path, bool logErrors = true) where T : UnityEngine.Object
		{
			T val = Resources.Load<T>(path);
			if (val == null && logErrors)
			{
				Debug.LogErrorFormat("The asset at path '{0}' could not be found.", path);
			}
			return val;
		}

		public Aerofoil LoadAirfoil(string airfoilName)
		{
			Aerofoil aerofoil = null;
			if (_airfoils.ContainsKey(airfoilName))
			{
				aerofoil = _airfoils[airfoilName];
			}
			else
			{
				UnityEngine.Object obj = Resources.Load("Craft/Parts/Wing/Airfoils/" + airfoilName);
				if (obj == null)
				{
					throw new ArgumentException($"Requested airfoil ({airfoilName}) could not be found", "airfoilName");
				}
				aerofoil = (UnityEngine.Object.Instantiate(obj) as GameObject).GetComponent<Aerofoil>();
				_airfoils.Add(airfoilName, aerofoil);
			}
			return aerofoil;
		}

		public T[] LoadAll<T>(string path, bool logErrors = true) where T : UnityEngine.Object
		{
			T[] array = Resources.LoadAll<T>(path);
			if (array == null && logErrors)
			{
				Debug.LogErrorFormat("Unable to load resources at path '{0}'.", path);
			}
			return array;
		}

		public ResourceRequestWrapper<T> LoadAsync<T>(string path, bool logErrors = true) where T : UnityEngine.Object
		{
			return new ResourceRequestWrapper<T>(Resources.LoadAsync<T>(path), path, logErrors);
		}

		public AudioClip LoadAudio(string path, bool logErrors = true)
		{
			AudioClip audioClip = Resources.Load<AudioClip>(path);
			if (audioClip == null && logErrors)
			{
				Debug.LogErrorFormat("The audio clip asset at path '{0}' could not be found.", path);
			}
			return audioClip;
		}

		public Material LoadMaterial(string path, bool logErrors = true)
		{
			Material material = Resources.Load<Material>(path);
			if (material == null && logErrors)
			{
				Debug.LogErrorFormat("The material asset at path '{0}' could not be found.", path);
			}
			return material;
		}

		public GameObject LoadPrefab(string path, bool logErrors = true)
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			if (gameObject == null && logErrors)
			{
				Debug.LogErrorFormat("The prefab at path '{0}' could not be found.", path);
			}
			return gameObject;
		}

		public T LoadScriptableObject<T>(string path, bool logErrors = true) where T : class
		{
			ScriptableObject scriptableObject = Resources.Load<ScriptableObject>(path);
			if (scriptableObject == null)
			{
				if (logErrors)
				{
					Debug.LogErrorFormat("The scriptable object at path '{0}' could not be found.", path);
				}
				return null;
			}
			if (!(scriptableObject is T result))
			{
				Debug.LogErrorFormat("The scriptable object at path '{0}' was found but it was not the expected type of '{1}'", path, typeof(T).FullName);
				return null;
			}
			return result;
		}

		public string LoadText(string path, bool logErrors = true)
		{
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			if (textAsset == null)
			{
				if (logErrors)
				{
					Debug.LogErrorFormat("The text asset at path '{0}' could not be found.", path);
				}
				return null;
			}
			string text = textAsset.text;
			Resources.UnloadAsset(textAsset);
			return text;
		}

		public Texture2D LoadTexture(string path, bool logErrors = true)
		{
			Texture2D texture2D = Resources.Load<Texture2D>(path);
			if (texture2D == null && logErrors)
			{
				Debug.LogErrorFormat("The texture asset at path '{0}' could not be found.", path);
				try
				{
					Debug.LogError(Environment.StackTrace);
				}
				catch
				{
				}
			}
			return texture2D;
		}

		private void OnActiveSceneChanged(Scene prevScene, Scene newScene)
		{
			_airfoils.Clear();
		}
	}
}
