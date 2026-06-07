using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

namespace Jundroo.Juicy
{
	public class ResourceLoader : IResourceLoader
	{
		private Dictionary<string, UnityEngine.Object> _cache = new Dictionary<string, UnityEngine.Object>();

		private string _resourceRootPath;

		private Assembly _scriptAssembly;

		private Dictionary<string, Sprite[]> _spriteSheetCache = new Dictionary<string, Sprite[]>();

		private string _widgetRootPath;

		private Dictionary<string, GameObject> _widgets = new Dictionary<string, GameObject>();

		public ResourceLoader(string widgetRootPath, string resourceRootPath, Assembly scriptAssembly)
		{
			_widgetRootPath = widgetRootPath;
			_resourceRootPath = resourceRootPath;
			_scriptAssembly = scriptAssembly;
		}

		public Type GetScriptType(string scriptTypeName)
		{
			return _scriptAssembly.GetType(scriptTypeName);
		}

		public AudioClip LoadAudioClip(string path)
		{
			return GetResourceObject<AudioClip>(path);
		}

		public TMP_FontAsset LoadFont(string path)
		{
			return GetResourceObject<TMP_FontAsset>(path);
		}

		public Material LoadMaterial(string path)
		{
			return GetResourceObject<Material>(path);
		}

		public Sprite LoadSprite(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			if (path.Contains('#'))
			{
				string[] array = path.Split('#');
				if (array.Length != 2)
				{
					throw new Exception("Invalid sprite sheet path format: '" + path + "'. Expected 'path/to/sheet#SpriteName'.");
				}
				string text = array[0];
				string spriteName = array[1];
				if (!_spriteSheetCache.ContainsKey(text))
				{
					string text2 = _resourceRootPath + "/" + text;
					Sprite[] array2 = Resources.LoadAll<Sprite>(text2);
					if (array2 == null || array2.Length == 0)
					{
						throw new Exception("Could not load sprite sheet from path '" + text2 + "'. Make sure the texture is imported as 'Sprite (2D and UI)' with Sprite Mode set to 'Multiple'.");
					}
					_spriteSheetCache[text] = array2;
				}
				Sprite sprite = _spriteSheetCache[text].FirstOrDefault((Sprite s) => s.name == spriteName);
				if (sprite == null)
				{
					throw new Exception("Could not find sprite '" + spriteName + "' in sprite sheet '" + text + "'.");
				}
				return sprite;
			}
			return GetResourceObject<Sprite>(path);
		}

		public Texture LoadTexture(string path)
		{
			return GetResourceObject<Texture>(path);
		}

		public GameObject LoadWidgetGameObject(string name)
		{
			if (!_widgets.ContainsKey(name))
			{
				GameObject gameObject = Resources.Load(_widgetRootPath + "/" + name) as GameObject;
				_widgets[name] = gameObject;
				if (gameObject == null)
				{
					throw new Exception("Could not find widget prefab '" + name + "'");
				}
			}
			return UnityEngine.Object.Instantiate(_widgets[name]);
		}

		public XElement LoadXml(string path)
		{
			try
			{
				return XDocument.Parse(GetResourceObject<TextAsset>(path).text).Root;
			}
			catch (Exception innerException)
			{
				throw new Exception("Could not load XML file from the resource path '" + path + "'", innerException);
			}
		}

		private T GetResourceObject<T>(string path) where T : UnityEngine.Object
		{
			if (!_cache.ContainsKey(path))
			{
				T val = Resources.Load<T>(_resourceRootPath + "/" + path);
				if (!(val != null))
				{
					throw new Exception($"Could not load '{typeof(T)}' resource from path '{path}'");
				}
				_cache[path] = val;
			}
			return _cache[path] as T;
		}
	}
}
