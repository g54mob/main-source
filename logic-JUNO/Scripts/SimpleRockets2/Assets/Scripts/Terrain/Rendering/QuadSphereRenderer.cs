using System;
using ModApi;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public class QuadSphereRenderer : MonoBehaviour
	{
		[Serializable]
		private class QuadsphereAtmosphere
		{
			public PlanetShaderDynamicData DynamicData { get; private set; }

			public Material Material { get; private set; }

			public MeshRenderer Renderer { get; private set; }

			public PlanetShaderStaticData StaticData { get; private set; }

			public Transform Transform { get; private set; }

			public QuadsphereAtmosphere(MeshRenderer renderer, PlanetShaderStaticData staticData, PlanetShaderDynamicData dynamicData)
			{
				Renderer = renderer;
				Material = renderer.material;
				Transform = renderer.transform;
				StaticData = staticData;
				DynamicData = dynamicData;
			}

			public void RefreshDynamicShaderData()
			{
				DynamicData.Update(currentPlanet: true);
				DynamicData.SetShaderProperties(Material);
			}

			public void RefreshStaticShaderData()
			{
				StaticData.Update();
				StaticData.SetShaderProperties(Material);
			}

			public void SetEnabled(bool enabled)
			{
				if (enabled != Renderer.enabled)
				{
					Renderer.enabled = enabled;
				}
			}
		}

		private QuadsphereAtmosphere _atmosphereFromInside;

		private QuadsphereAtmosphere _atmosphereFromOutside;

		[SerializeField]
		private VisualEffectsQualitySettings.AtmosphereQuality _atmosphereQuality;

		[SerializeField]
		private VisualEffectsQualitySettings.AtmosphereQuality _atmosphereQualityForObjects;

		[SerializeField]
		private VisualEffectsQualitySettings.AtmosphereQuality _atmosphereQualityForTerrain;

		private float _atmosphereRadius;

		[SerializeField]
		private PlanetShaderDynamicData _dynamicDataGlobal;

		[SerializeField]
		private PlanetRenderingData _planetData;

		private bool _refreshAtmosphereQuality;

		private bool _refreshStaticData;

		[SerializeField]
		private PlanetShaderStaticData _staticDataGlobal;

		public PlanetRenderingData PlanetData => _planetData;

		public QuadSphereScript QuadSphereScript { get; private set; }

		public static QuadSphereRenderer Create(QuadSphereScript quadSphere)
		{
			GameObject obj = new GameObject("QuadSphereRenderer");
			obj.transform.SetParent(quadSphere.transform, worldPositionStays: false);
			obj.transform.SetAsFirstSibling();
			QuadSphereRenderer quadSphereRenderer = obj.AddComponent<QuadSphereRenderer>();
			PlanetRenderingData data = new PlanetRenderingData(quadSphere);
			quadSphereRenderer.QuadSphereScript = quadSphere;
			quadSphereRenderer.Initialize(data, initializeWithoutQuadSphere: false);
			return quadSphereRenderer;
		}

		public static QuadSphereRenderer CreateWithoutQuadsphere(GameObject obj, Vector3 focusPosition, Transform camera, Transform light)
		{
			QuadSphereRenderer quadSphereRenderer = obj.AddComponent<QuadSphereRenderer>();
			PlanetRenderingData data = new PlanetRenderingData(focusPosition, camera, light);
			quadSphereRenderer.Initialize(data, initializeWithoutQuadSphere: true);
			return quadSphereRenderer;
		}

		public void RefreshDataAndUpdateRenderer()
		{
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
			UpdateRenderer();
		}

		[ContextMenu("Reset To Defaults")]
		public void ResetToDefaults()
		{
			_planetData.ResetToDefaults();
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
		}

		public void UpdateRenderer()
		{
			if (_refreshStaticData)
			{
				UpdateStaticData(_refreshAtmosphereQuality);
			}
			_dynamicDataGlobal.Update(currentPlanet: true);
			_dynamicDataGlobal.SetShaderProperties();
			if (_planetData.HasAtmosphere && _atmosphereQuality != VisualEffectsQualitySettings.AtmosphereQuality.Off)
			{
				bool flag = _dynamicDataGlobal.UnscaledCameraHeight < _atmosphereRadius;
				QuadsphereAtmosphere quadsphereAtmosphere = (flag ? _atmosphereFromInside : _atmosphereFromOutside);
				if (quadsphereAtmosphere != null)
				{
					_atmosphereFromInside.SetEnabled(flag);
					_atmosphereFromOutside.SetEnabled(!flag);
					quadsphereAtmosphere.RefreshDynamicShaderData();
				}
			}
		}

		protected virtual void Initialize(PlanetRenderingData data, bool initializeWithoutQuadSphere)
		{
			_planetData = data;
			_staticDataGlobal = new PlanetShaderStaticData(_planetData, _planetData.Transform, skyShader: false, scaledSpaceShader: false, !initializeWithoutQuadSphere && QuadSphereScript.PlanetData.SkyboxFadeDuringDaytime);
			_dynamicDataGlobal = new PlanetShaderDynamicData(_staticDataGlobal);
			if (_planetData.HasAtmosphere)
			{
				CreateAtmospheres();
			}
			Game.Instance.QualitySettings.VisualEffects.Atmosphere.Changed += OnAtmosphereQualityChanged;
			Game.Instance.Settings.Game.Flight.AmbientLightAttenuation.Changed += OnStaticDataSettingsChanged;
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.VisualEffects.Atmosphere.Changed -= OnAtmosphereQualityChanged;
			Game.Instance.Settings.Game.Flight.AmbientLightAttenuation.Changed -= OnStaticDataSettingsChanged;
			if (_atmosphereFromInside != null && _atmosphereFromInside.Material != null)
			{
				UnityEngine.Object.Destroy(_atmosphereFromInside.Material);
			}
			if (_atmosphereFromOutside != null && _atmosphereFromOutside.Material != null)
			{
				UnityEngine.Object.Destroy(_atmosphereFromOutside.Material);
			}
		}

		private QuadsphereAtmosphere CreateAtmosphere(string prefabPath)
		{
			MeshRenderer meshRenderer = Game.Instance.ResourceLoader.InstantiatePrefab<MeshRenderer>(prefabPath);
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(meshRenderer.gameObject, _planetData.Transform.gameObject.layer);
			Transform transform = meshRenderer.transform;
			transform.SetParent(_planetData.Transform, worldPositionStays: false);
			transform.SetSiblingIndex(1);
			transform.localPosition = Vector3.zero;
			PlanetShaderStaticData staticData = new PlanetShaderStaticData(_planetData, transform, skyShader: true, scaledSpaceShader: false, fadeSkyboxDuringDay: false);
			PlanetShaderDynamicData dynamicData = new PlanetShaderDynamicData(staticData);
			return new QuadsphereAtmosphere(meshRenderer, staticData, dynamicData);
		}

		private void CreateAtmospheres()
		{
			InitializeAtmosphereQuality();
			if (_atmosphereQuality == VisualEffectsQualitySettings.AtmosphereQuality.Ultra)
			{
				_atmosphereFromOutside = CreateAtmosphere("Planets/SkyFromSpaceUltra");
				_atmosphereFromInside = CreateAtmosphere("Planets/SkyFromAtmosphereUltra");
			}
			else
			{
				_atmosphereFromOutside = CreateAtmosphere("Planets/SkyFromSpace");
				_atmosphereFromInside = CreateAtmosphere("Planets/SkyFromAtmosphere");
			}
			UpdateAtmosphereRadius();
		}

		private void InitializeAtmosphereQuality()
		{
			if (_planetData.HasAtmosphere)
			{
				EnumSetting<VisualEffectsQualitySettings.AtmosphereQuality> atmosphere = Game.Instance.QualitySettings.VisualEffects.Atmosphere;
				_atmosphereQualityForTerrain = atmosphere;
				_atmosphereQualityForObjects = atmosphere;
			}
			else
			{
				_atmosphereQualityForTerrain = VisualEffectsQualitySettings.AtmosphereQuality.Off;
				_atmosphereQualityForObjects = VisualEffectsQualitySettings.AtmosphereQuality.Off;
			}
			_atmosphereQuality = _atmosphereQualityForTerrain;
			if (_atmosphereQuality == VisualEffectsQualitySettings.AtmosphereQuality.Off)
			{
				_atmosphereFromInside?.SetEnabled(enabled: false);
				_atmosphereFromOutside?.SetEnabled(enabled: false);
			}
		}

		private void OnAtmosphereQualityChanged(object sender, SettingChangedEventArgs<VisualEffectsQualitySettings.AtmosphereQuality> e)
		{
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
		}

		private void OnStaticDataSettingsChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			_refreshStaticData = true;
		}

		private void OnValidate()
		{
			if (_planetData != null)
			{
				if (_planetData.SyncShaderData)
				{
					_planetData.ShaderDataSky.CopyFrom(_planetData.ShaderDataTerrain);
				}
				if (_planetData.HasAtmosphere && _atmosphereFromInside == null && _atmosphereFromOutside == null)
				{
					CreateAtmospheres();
					_refreshAtmosphereQuality = true;
				}
				_refreshStaticData = true;
			}
		}

		private void UpdateAtmosphereRadius()
		{
			_atmosphereRadius = _planetData.Radius * _atmosphereFromInside.StaticData.AtmosRenderingSizeScale;
			Vector3 localScale = new Vector3(_atmosphereRadius, _atmosphereRadius, _atmosphereRadius);
			_atmosphereFromOutside.Renderer.transform.localScale = localScale;
			_atmosphereFromInside.Renderer.transform.localScale = localScale;
		}

		private void UpdateGlobalShaderKeywords()
		{
			if (_planetData.HasAtmosphere && _atmosphereQualityForTerrain != VisualEffectsQualitySettings.AtmosphereQuality.Off)
			{
				Shader.EnableKeyword("TERRAIN_ATMOSPHERE");
			}
			else
			{
				Shader.DisableKeyword("TERRAIN_ATMOSPHERE");
			}
			if (_planetData.HasAtmosphere && (_atmosphereQualityForObjects == VisualEffectsQualitySettings.AtmosphereQuality.High || _atmosphereQualityForObjects == VisualEffectsQualitySettings.AtmosphereQuality.Ultra))
			{
				Shader.EnableKeyword("OBJECT_ATMOSPHERE");
			}
			else
			{
				Shader.DisableKeyword("OBJECT_ATMOSPHERE");
			}
		}

		private void UpdateShaderKeywords(Material material)
		{
			material.EnableKeyword("QUAD_SKY");
		}

		private void UpdateStaticData(bool updateAtmosphereQuality)
		{
			bool num = _planetData.HasAtmosphere && _atmosphereFromInside != null && _atmosphereFromOutside != null;
			_staticDataGlobal.Update();
			_staticDataGlobal.SetShaderProperties();
			if (num)
			{
				UpdateAtmosphereRadius();
				_atmosphereFromInside.RefreshStaticShaderData();
				_atmosphereFromOutside.RefreshStaticShaderData();
			}
			if (updateAtmosphereQuality)
			{
				InitializeAtmosphereQuality();
			}
			UpdateGlobalShaderKeywords();
			if (num)
			{
				UpdateShaderKeywords(_atmosphereFromInside.Material);
				UpdateShaderKeywords(_atmosphereFromOutside.Material);
			}
			_refreshStaticData = false;
			_refreshAtmosphereQuality = false;
		}
	}
}
