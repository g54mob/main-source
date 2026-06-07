using ModApi.Common.Extensions;
using ModApi.Scenes.Events;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace ModApi.Scenes
{
	public static class SceneSkybox
	{
		private static class ShaderPropertyIds
		{
			public static readonly int Exposure = Shader.PropertyToID("_Exposure");
		}

		private static float? _defaultExposure;

		private static Material _defaultMaterial;

		private static Shader _defaultShader;

		private static bool _initialized;

		private static bool _isCustom;

		private static bool _isSubscribed;

		private static Material _materialInstance;

		public static float DefaultExposure
		{
			get
			{
				if (!_defaultExposure.HasValue)
				{
					GetMaterialInstance();
				}
				return _defaultExposure.Value;
			}
		}

		public static float Exposure
		{
			get
			{
				return GetMaterialInstance().GetFloat(ShaderPropertyIds.Exposure);
			}
			set
			{
				GetMaterialInstance().SetFloat(ShaderPropertyIds.Exposure, value);
			}
		}

		public static void Initialize(ISceneManager sceneManager)
		{
			if (!_initialized)
			{
				_initialized = true;
				_defaultShader = Shader.Find("Skybox/6 Sided");
				sceneManager.SceneUnloaded += OnSceneUnloaded;
				sceneManager.SceneLoaded += OnSceneLoaded;
			}
		}

		public static void ReplaceSkybox(Material material, bool isCustom = false)
		{
			UnloadSkybox();
			_defaultMaterial = RenderSettings.skybox;
			RenderSettings.skybox = material;
			_isCustom = isCustom;
			_materialInstance = material;
			_defaultExposure = material.GetFloat(ShaderPropertyIds.Exposure);
		}

		public static void UnloadSkybox()
		{
			if ((object)_defaultMaterial != null)
			{
				RenderSettings.skybox = _defaultMaterial;
				_defaultMaterial = null;
			}
			if ((object)_materialInstance != null)
			{
				Object.Destroy(_materialInstance);
				_materialInstance = null;
			}
			_defaultExposure = null;
		}

		private static Material GetDefaultMaterial()
		{
			if ((object)_defaultMaterial == null)
			{
				_defaultMaterial = RenderSettings.skybox;
			}
			return _defaultMaterial;
		}

		private static Material GetMaterialInstance()
		{
			if ((object)_materialInstance == null)
			{
				Material defaultMaterial = GetDefaultMaterial();
				if (defaultMaterial == null)
				{
					_materialInstance = new Material(_defaultShader);
					_materialInstance.name = "Dummy Skybox Material";
					_defaultExposure = _materialInstance.GetFloat(ShaderPropertyIds.Exposure);
				}
				else
				{
					_materialInstance = Object.Instantiate(defaultMaterial);
					_materialInstance.name = "Skybox Material Instance";
					_defaultExposure = _materialInstance.GetFloat(ShaderPropertyIds.Exposure);
					RenderSettings.skybox = _materialInstance;
				}
			}
			return _materialInstance;
		}

		private static void OnSceneLoaded(object sender, SceneEventArgs e)
		{
			Debug.Log($"Loaded Scene on Flight-{Game.InFlightScene} Subscribed-{_isSubscribed} and Quality-{Game.Instance.QualitySettings.VisualEffects.Skybox.Value.DisplayName()}");
			if (Game.InFlightScene || Game.InPlanetStudioScene)
			{
				if (!_isSubscribed)
				{
					_isSubscribed = true;
					Game.Instance.QualitySettings.VisualEffects.Skybox.Changed += OnSkyboxQualityChanged;
				}
				ApplySkyboxSetting(Game.Instance.QualitySettings.VisualEffects.Skybox.Value);
			}
		}

		private static void OnSceneUnloaded(object sender, SceneEventArgs e)
		{
			UnloadSkybox();
		}

		private static void OnSkyboxQualityChanged(object sender, SettingChangedEventArgs<VisualEffectsQualitySettings.SkyboxQuality> e)
		{
			ApplySkyboxSetting(e.Setting.Value);
		}

		private static void ApplySkyboxSetting(VisualEffectsQualitySettings.SkyboxQuality quality)
		{
			if (!_isCustom)
			{
				string text = quality switch
				{
					VisualEffectsQualitySettings.SkyboxQuality.High => "2k", 
					VisualEffectsQualitySettings.SkyboxQuality.Ultra => "4k", 
					_ => string.Empty, 
				};
				ReplaceSkybox(Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Planets/Materials/SkyboxMaterials/StarSkybox" + text)));
			}
		}
	}
}
