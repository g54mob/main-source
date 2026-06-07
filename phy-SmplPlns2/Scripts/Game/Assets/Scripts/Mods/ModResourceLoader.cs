using System;
using System.Collections.Generic;
using Assets.Scripts.Mods.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Resource;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public class ModResourceLoader : IModResourceLoader
	{
		private AssetBundle _assetBundle;

		private Dictionary<string, string> _materialShaderMap;

		private Dictionary<string, Shader> _materialShaderReplacements;

		public ModInfo ModInfo { get; private set; }

		public static event EventHandler<PostProcessGameObjectEventArgs> PostProcessGameObject;

		public static event EventHandler<PostProcessMaterialEventArgs> PostProcessMaterial;

		public static event EventHandler<PostProcessMissingShaderMaterialEventArgs> PostProcessMissingShaderMaterial;

		public event EventHandler<GameObjectLoadedEventArgs> GameObjectLoaded;

		public ModResourceLoader(ModInfo mod, ModManifest modManifest, AssetBundle assetBundle)
		{
			if (assetBundle == null)
			{
				throw new ArgumentNullException("assetBundle");
			}
			ModInfo = mod;
			_assetBundle = assetBundle;
			_materialShaderMap = modManifest.MaterialShaderMap;
			_materialShaderReplacements = new Dictionary<string, Shader>();
		}

		public T LoadAsset<T>(string path) where T : UnityEngine.Object
		{
			T val = _assetBundle.LoadAsset<T>(path);
			if (val is GameObject obj)
			{
				return PostProcessLoadedGameObject(obj) as T;
			}
			if (val is Material material)
			{
				PostProcessLoadedMaterial(material, null, null);
			}
			return val;
		}

		public UnityEngine.Object LoadAsset(string path, Type type)
		{
			UnityEngine.Object obj = _assetBundle.LoadAsset(path, type);
			if (obj is GameObject obj2)
			{
				return PostProcessLoadedGameObject(obj2);
			}
			if (obj is Material material)
			{
				PostProcessLoadedMaterial(material, null, null);
			}
			return obj;
		}

		public async UniTask<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object
		{
			UnityEngine.Object obj = await _assetBundle.LoadAssetAsync<T>(path).ToUniTask();
			if (obj is GameObject obj2)
			{
				return PostProcessLoadedGameObject(obj2) as T;
			}
			if (obj is Material material)
			{
				PostProcessLoadedMaterial(material, null, null);
			}
			return (T)obj;
		}

		public AsyncAssetRequest<UnityEngine.Object> LoadAssetAsyncRequest(string path, Type type)
		{
			return new AsyncModAssetRequest<UnityEngine.Object>(_assetBundle.LoadAssetAsync(path), this);
		}

		public AsyncAssetRequest<T> LoadAssetAsyncRequest<T>(string path) where T : UnityEngine.Object
		{
			return new AsyncModAssetRequest<T>(_assetBundle.LoadAssetAsync<T>(path), this);
		}

		internal GameObject PostProcessLoadedGameObject(GameObject obj)
		{
			if (obj == null)
			{
				return obj;
			}
			EventHandler<PostProcessGameObjectEventArgs> postProcessGameObject = ModResourceLoader.PostProcessGameObject;
			if (postProcessGameObject != null)
			{
				PostProcessGameObjectEventArgs e = new PostProcessGameObjectEventArgs(ModInfo, this, obj);
				postProcessGameObject(this, e);
				obj = e.GameObject;
			}
			this.GameObjectLoaded?.Invoke(this, new GameObjectLoadedEventArgs(obj));
			return obj;
		}

		internal void PostProcessLoadedMaterial(Material material, Component associatedComponent, GameObject associatedGameObject)
		{
			if (!(material == null))
			{
				PostProcessLoadedMaterial(material, material.shader, associatedComponent, associatedGameObject);
				EventHandler<PostProcessMaterialEventArgs> postProcessMaterial = ModResourceLoader.PostProcessMaterial;
				if (postProcessMaterial != null)
				{
					PostProcessMaterialEventArgs e = new PostProcessMaterialEventArgs(ModInfo, this, material, associatedGameObject, associatedComponent);
					postProcessMaterial(this, e);
				}
			}
		}

		private void PostProcessLoadedMaterial(Material material, Shader shader, Component associatedComponent, GameObject associatedGameObject)
		{
			if (shader.isSupported)
			{
				return;
			}
			if (_materialShaderReplacements.TryGetValue(material.name, out shader))
			{
				if (shader != null)
				{
					material.shader = shader;
				}
				return;
			}
			shader = material.shader;
			if (string.IsNullOrEmpty(shader.name))
			{
				EventHandler<PostProcessMissingShaderMaterialEventArgs> postProcessMissingShaderMaterial = ModResourceLoader.PostProcessMissingShaderMaterial;
				if (postProcessMissingShaderMaterial != null)
				{
					PostProcessMissingShaderMaterialEventArgs e = new PostProcessMissingShaderMaterialEventArgs(ModInfo, this, material, associatedGameObject, associatedComponent);
					postProcessMissingShaderMaterial(this, e);
					if (shader != material.shader)
					{
						return;
					}
				}
				if (!_materialShaderMap.TryGetValue(material.name, out var value))
				{
					value = "Standard";
				}
				TryShaderReplacement(value, material);
			}
			else
			{
				TryShaderReplacement(shader.name, material);
			}
		}

		private void TryShaderReplacement(string shaderName, Material material)
		{
			Shader shader = Shader.Find(shaderName);
			if (shader != null && shader.isSupported)
			{
				Debug.LogFormat("Material '{0}' is using an unsupported shader '{1}'. The shader will be replaced with shader '{2}'", material.name, (material.shader != null) ? material.shader.name : "(null)", shader.name);
				material.shader = shader;
				_materialShaderReplacements.Add(material.name, shader);
			}
			else
			{
				Debug.LogFormat("Material '{0}' is using an unsupported shader '{1}'. A suitable replacement shader could not be found.", material.name, (material.shader != null) ? material.shader.name : "(null)");
				_materialShaderReplacements.Add(material.name, null);
			}
		}
	}
}
