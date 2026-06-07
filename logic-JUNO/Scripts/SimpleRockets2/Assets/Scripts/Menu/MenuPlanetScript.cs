using System;
using Assets.Scripts.State;
using Assets.Scripts.Terrain.Rendering;
using ModApi.Common;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class MenuPlanetScript : MonoBehaviour, IObjectViewerScale
	{
		private int _cubemapDownsampleCount;

		private EnumSetting<TerrainQualitySettings.PlanetCubemapQuality> _cubemapQuality;

		private int _cubemapSize;

		private PlanetShaderDynamicData _dynamicShaderData;

		private float _eclipse;

		[SerializeField]
		private Light _light;

		private Material _material;

		private IPlanetData _planetData;

		private PlanetRenderingData _planetRenderingData;

		private PlanetShaderStaticData _staticShaderData;

		public Camera Camera { get; private set; }

		public float Eclipse
		{
			get
			{
				return _eclipse;
			}
			set
			{
				_eclipse = Mathf.Clamp01(value);
				_material.SetFloat("_Eclipse", 1f - _eclipse);
			}
		}

		public bool IsInitialized { get; private set; }

		public Light Light
		{
			get
			{
				return _light;
			}
			private set
			{
				_light = value;
			}
		}

		public float RotationSpeed { get; set; } = -1f;

		public void Initialize(Light light, Camera camera)
		{
			IsInitialized = true;
			Camera = camera;
			Light = light;
		}

		void IObjectViewerScale.ScaleObject(float scale)
		{
			UpdateScale(scale);
		}

		public void SetPlanetData(IPlanetData planetData)
		{
			if (planetData == null)
			{
				base.gameObject.SetActive(value: false);
			}
			else
			{
				if (!(_planetData?.Name != planetData.Name))
				{
					return;
				}
				base.gameObject.SetActive(value: true);
				_planetData = planetData;
				if (!PlanetCubemapUtility.Exists(_planetData, PlanetCubemapType.Color, _cubemapSize))
				{
					try
					{
						ApplicationState.PushTask("Generating Cubemap: " + planetData.Name);
						PlanetCubemapUtility.CreateCubemaps(_planetData, null, _cubemapSize, _cubemapDownsampleCount, normalMaps: true, ModApi.Common.Game.Instance.Settings.Quality.Terrain.CubemapSettings.NormalCliffColorEnabled);
					}
					finally
					{
						ApplicationState.PopTask("Generating Cubemap: " + planetData.Name);
					}
				}
				UpdateCubemaps();
				UpdateScale();
			}
		}

		protected virtual void Awake()
		{
			_material = GetComponent<MeshRenderer>().material;
			Eclipse = 1f;
			TerrainQualitySettings terrain = ModApi.Common.Game.Instance.QualitySettings.Terrain;
			_cubemapQuality = terrain.Cubemaps;
			_cubemapQuality.Changed += CubemapQualityChanged;
			_cubemapSize = terrain.CubemapSettings.MenuSize;
			_cubemapDownsampleCount = terrain.CubemapSettings.MenuGenerationDownsampleCount;
			base.gameObject.SetActive(value: false);
		}

		protected virtual void OnDestroy()
		{
			_cubemapQuality.Changed -= CubemapQualityChanged;
			DestroyCubemaps();
			UnityEngine.Object.Destroy(_material);
		}

		protected virtual void Update()
		{
			base.transform.Rotate(new Vector3(0f, RotationSpeed * Time.deltaTime, 0f));
			if (_dynamicShaderData != null)
			{
				_dynamicShaderData.RadiusScale = (double)base.transform.lossyScale.x / _planetData.RadiusScaledSpace;
				ScaledSpaceRenderer.UpdateShaderKeywords(_material, ScaledSpaceRenderer.GetAtmosphereQuality(_planetRenderingData));
				_staticShaderData.Update();
				_dynamicShaderData.Update(currentPlanet: true);
				if (_material != null)
				{
					_staticShaderData.SetShaderProperties(_material);
					_dynamicShaderData.SetShaderProperties(_material);
				}
			}
		}

		private void CubemapQualityChanged(object sender, SettingChangedEventArgs<TerrainQualitySettings.PlanetCubemapQuality> e)
		{
			UpdateCubemaps();
		}

		private void DestroyCubemaps()
		{
			if (_material != null)
			{
				Texture texture = _material.GetTexture("_Cube");
				if (texture != null)
				{
					UnityEngine.Object.Destroy(texture);
				}
				Texture texture2 = _material.GetTexture("_BumpCube");
				if (texture2 != null)
				{
					UnityEngine.Object.Destroy(texture2);
				}
			}
		}

		private void UpdateCubemaps()
		{
			DestroyCubemaps();
			_planetRenderingData = new PlanetRenderingData(_planetData, base.transform, Camera.transform, Light.transform);
			_staticShaderData = new PlanetShaderStaticData(_planetRenderingData, base.transform, skyShader: false, scaledSpaceShader: true, fadeSkyboxDuringDay: false);
			_dynamicShaderData = new PlanetShaderDynamicData(_staticShaderData);
			try
			{
				ApplicationState.PushTask("Loading Cubemaps");
				Cubemap value = PlanetCubemapUtility.LoadCubemap(_planetData, PlanetCubemapType.Color, _cubemapSize, create: true);
				Cubemap cubemap = PlanetCubemapUtility.LoadCubemap(_planetData, PlanetCubemapType.Normal, _cubemapSize, create: true);
				PlanetCubemapData cubemapData = PlanetCubemapUtility.GetCubemapData(_planetData, create: false);
				_material.SetTexture("_Cube", value);
				_material.SetVector("_MaxColors", cubemapData.MaxColor);
				if (cubemap != null)
				{
					_material.SetTexture("_BumpCube", cubemap);
					if (ModApi.Common.Game.Instance.QualitySettings.Terrain.ScaledSpaceVertexDisplacement.Value)
					{
						double radius = _planetData.Radius;
						_material.SetFloat("_MinASL", 1f);
						_material.SetFloat("_MaxASL", (float)(1.0 / Mathd.InverseLerp(0.0, radius + (double)cubemapData.MaxHeight, radius + (double)cubemapData.MinHeight)));
						_material.DisableKeyword("NORMALMAP");
						_material.EnableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
					}
					else
					{
						_material.EnableKeyword("NORMALMAP");
						_material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
					}
				}
				else
				{
					_material.DisableKeyword("NORMALMAP");
					_material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred trying to load the planet cubemap for the launch location.");
				Debug.LogException(exception);
			}
			finally
			{
				ApplicationState.PopTask("Loading Cubemaps");
			}
		}

		private void UpdateScale(float baseScale = 0.1f)
		{
			PlanetCubemapData cubemapData = PlanetCubemapUtility.GetCubemapData(_planetData, create: false);
			double num = 1.0;
			if (cubemapData != null)
			{
				num = (_planetData.Radius + (double)cubemapData.MinHeight) / (_planetData.Radius + (double)cubemapData.MaxHeight);
			}
			base.transform.localScale = Vector3.one * (float)((double)baseScale * num);
		}
	}
}
