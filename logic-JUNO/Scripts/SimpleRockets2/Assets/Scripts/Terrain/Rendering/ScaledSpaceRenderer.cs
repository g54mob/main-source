using System;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.Terrain.Rendering.Events;
using ModApi;
using ModApi.Common;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public class ScaledSpaceRenderer : MonoBehaviour, IScaledSpaceRenderer
	{
		private static class ShaderPropertyIds
		{
			public static readonly int VertexDisplacementLod = Shader.PropertyToID("_VertexDisplacementLod");
		}

		[Serializable]
		private class ScaledSpacePlanetSphere
		{
			public PlanetShaderDynamicData DynamicData { get; private set; }

			public Material Material { get; private set; }

			public MeshFilter MeshFilter { get; private set; }

			public MeshRenderer Renderer { get; private set; }

			public PlanetShaderStaticData StaticData { get; private set; }

			public Transform Transform { get; private set; }

			public ScaledSpacePlanetSphere(MeshRenderer renderer, PlanetShaderStaticData staticData, PlanetShaderDynamicData dynamicData)
			{
				Renderer = renderer;
				MeshFilter = renderer.GetComponent<MeshFilter>();
				Material = renderer.material;
				Transform = renderer.transform;
				StaticData = staticData;
				DynamicData = dynamicData;
			}

			public void Destroy()
			{
				if (Material != null)
				{
					UnityEngine.Object.Destroy(Material);
				}
			}

			public void RefreshDynamicShaderData(bool currentPlanet)
			{
				DynamicData.Update(currentPlanet);
				DynamicData.SetShaderProperties(Material);
			}

			public void RefreshStaticShaderData()
			{
				StaticData.Update();
				StaticData.SetShaderProperties(Material);
			}

			public void SetEnabled(bool enabled)
			{
				Renderer.enabled = enabled;
			}
		}

		private ScaledSpacePlanetSphere _atmosphere;

		[SerializeField]
		private VisualEffectsQualitySettings.AtmosphereQuality _atmosphereQuality;

		private Cubemap _cubemapColors;

		private int _cubemapHighDetailSize;

		private int _cubemapLowDetailSize;

		private Cubemap _cubemapNormals;

		private EnumSetting<TerrainQualitySettings.PlanetCubemapQuality> _cubemapQuality;

		private PlanetCubemapsRequest _cubemapRequest;

		private bool _isCurrentPlanet;

		private float _pixelSizeMinDistance;

		[SerializeField]
		private PlanetRenderingData _planetData;

		private PlanetMeshes.PlanetMeshQuality _planetMeshQuality;

		private float _radiusSquared;

		private bool _refreshAtmosphereQuality;

		private bool _refreshStaticData;

		private bool _shaderUsesVertexDisplacement;

		private ScaledSpacePlanetSphere _terrain;

		private int _terrainRenderQueue = 2000;

		private Transform _transform;

		public float PixelSize { get; private set; }

		public ScaledSpacePlanetScript Planet { get; private set; }

		public PlanetRenderingData PlanetData => _planetData;

		protected int TerrainRenderQueue
		{
			get
			{
				return _terrainRenderQueue;
			}
			set
			{
				if (_terrainRenderQueue != value)
				{
					_terrainRenderQueue = value;
					_terrain.Material.renderQueue = value;
				}
			}
		}

		public event EventHandler<PlanetCubemapsChangedEventArgs> CubemapsChanged;

		public static ScaledSpaceRenderer Create(ScaledSpacePlanetScript planet)
		{
			ScaledSpaceRenderer scaledSpaceRenderer = planet.gameObject.AddComponent<ScaledSpaceRenderer>();
			scaledSpaceRenderer.Initialize(planet);
			return scaledSpaceRenderer;
		}

		public static VisualEffectsQualitySettings.AtmosphereQuality GetAtmosphereQuality(PlanetRenderingData renderingData)
		{
			if (!renderingData.HasAtmosphere)
			{
				return VisualEffectsQualitySettings.AtmosphereQuality.Off;
			}
			return ModApi.Common.Game.Instance.QualitySettings.VisualEffects.Atmosphere.Value;
		}

		public static void UpdateShaderKeywords(Material material, VisualEffectsQualitySettings.AtmosphereQuality quality)
		{
			material.DisableKeyword("QUAD_SKY");
			if (quality == VisualEffectsQualitySettings.AtmosphereQuality.Off)
			{
				material.DisableKeyword("ATMOSPHERE");
			}
			else
			{
				material.EnableKeyword("ATMOSPHERE");
			}
		}

		public Material CreateMaterialDuplicate()
		{
			return UnityEngine.Object.Instantiate(_terrain.Material);
		}

		public void GetTextures(out Texture cubeTex, out Texture bumpTex)
		{
			cubeTex = _cubemapColors;
			bumpTex = _cubemapNormals;
		}

		public void RefreshDataAndUpdateRenderer(bool currentPlanet)
		{
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
			UpdateShaderData(currentPlanet);
			UpdateRendererScales();
		}

		[ContextMenu("Reset To Defaults")]
		public void ResetToDefaults()
		{
			_planetData.ResetToDefaults();
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
		}

		public void UpdateRenderer(Camera camera, Vector3d scaledSpaceCameraPosition, bool currentPlanet)
		{
			if (_isCurrentPlanet != currentPlanet)
			{
				_isCurrentPlanet = currentPlanet;
				if (_isCurrentPlanet)
				{
					camera.nearClipPlane = Mathf.Clamp(_radiusSquared, 0.01f, 1f);
				}
				TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings;
				int requestedSize = (currentPlanet ? cubemapSettings.ScaledSpaceHighDetailSize : cubemapSettings.ScaledSpaceLowDetailSize);
				_cubemapRequest.UpdateRequestedSize(requestedSize);
			}
			IPlanetNode planetNode = Planet.PlanetNode;
			Vector3d solarPosition = planetNode.SolarPosition;
			Vector3d vector3d = (solarPosition - scaledSpaceCameraPosition) * 0.0001;
			_transform.SetLocalPositionAndRotation(vector3d.ToVector3(), planetNode.Rotation.ToQuaternion());
			UpdatePixelSize(camera);
			UpdateCubemapRequestedSize();
			UpdateLod();
			double sqrMagnitude = (solarPosition - scaledSpaceCameraPosition).sqrMagnitude;
			TerrainRenderQueue = ((sqrMagnitude > 1E+20) ? 2505 : 2000);
			UpdateShaderData(currentPlanet);
		}

		protected virtual void Initialize(ScaledSpacePlanetScript planet)
		{
			Planet = planet;
			_transform = planet.transform;
			ScaledSpaceScript instance = ScaledSpaceScript.Instance;
			_planetData = new PlanetRenderingData(planet, instance.Camera.transform, instance.Sun.transform);
			_radiusSquared = _planetData.RadiusScaledSpace * _planetData.RadiusScaledSpace;
			_pixelSizeMinDistance = _planetData.RadiusScaledSpace + 0.01f;
			PlanetMeshes.Initialize();
			_terrain = CreateSphere("Planets/ScaledSpaceTerrain", isAtmosphere: false);
			if (_planetData.HasAtmosphere)
			{
				_atmosphere = CreateSphere("Planets/SkyFromSpace", isAtmosphere: true);
			}
			UpdateRendererScales();
			_cubemapQuality = ModApi.Common.Game.Instance.QualitySettings.Terrain.Cubemaps;
			_cubemapQuality.Changed += CubemapQualityChanged;
			InitializePlanetCubemaps(planet.PlanetNode);
			IGameQualitySettings qualitySettings = ModApi.Common.Game.Instance.QualitySettings;
			qualitySettings.VisualEffects.Atmosphere.Changed += OnAtmosphereQualityChanged;
			qualitySettings.Terrain.ScaledSpaceVertexDisplacement.Changed += OnScaledSpaceVertexDisplacementSettingChanged;
			_refreshStaticData = true;
			_refreshAtmosphereQuality = true;
		}

		protected virtual void OnDestroy()
		{
			_cubemapQuality.Changed -= CubemapQualityChanged;
			_terrain?.Destroy();
			_atmosphere?.Destroy();
			IGameQualitySettings qualitySettings = ModApi.Common.Game.Instance.QualitySettings;
			qualitySettings.VisualEffects.Atmosphere.Changed -= OnAtmosphereQualityChanged;
			qualitySettings.Terrain.ScaledSpaceVertexDisplacement.Changed -= OnScaledSpaceVertexDisplacementSettingChanged;
		}

		private ScaledSpacePlanetSphere CreateSphere(string prefabPath, bool isAtmosphere)
		{
			MeshRenderer meshRenderer = ModApi.Common.Game.Instance.ResourceLoader.InstantiatePrefab<MeshRenderer>(prefabPath);
			Transform transform = PlanetData.Transform;
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(meshRenderer.gameObject, transform.gameObject.layer);
			Transform transform2 = meshRenderer.transform;
			transform2.SetParent(transform, worldPositionStays: false);
			transform2.localPosition = Vector3.zero;
			PlanetShaderStaticData staticData = new PlanetShaderStaticData(_planetData, transform2, isAtmosphere, scaledSpaceShader: true, fadeSkyboxDuringDay: false);
			PlanetShaderDynamicData dynamicData = new PlanetShaderDynamicData(staticData);
			ScaledSpacePlanetSphere scaledSpacePlanetSphere = new ScaledSpacePlanetSphere(meshRenderer, staticData, dynamicData);
			if (isAtmosphere)
			{
				scaledSpacePlanetSphere.MeshFilter.mesh = (((VisualEffectsQualitySettings.AtmosphereQuality)ModApi.Common.Game.Instance.QualitySettings.VisualEffects.Atmosphere == VisualEffectsQualitySettings.AtmosphereQuality.Ultra) ? PlanetMeshes.MeshQualityUltra : PlanetMeshes.MeshQualityHigh);
			}
			else
			{
				_planetMeshQuality = PlanetMeshes.PlanetMeshQuality.High;
				scaledSpacePlanetSphere.MeshFilter.mesh = PlanetMeshes.MeshQualityHigh;
			}
			return scaledSpacePlanetSphere;
		}

		private void CubemapQualityChanged(object sender, SettingChangedEventArgs<TerrainQualitySettings.PlanetCubemapQuality> e)
		{
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings;
			_cubemapHighDetailSize = cubemapSettings.ScaledSpaceHighDetailSize;
			_cubemapLowDetailSize = cubemapSettings.ScaledSpaceLowDetailSize;
			_cubemapRequest.UpdateRequestedSize(_isCurrentPlanet ? _cubemapHighDetailSize : _cubemapLowDetailSize);
		}

		private void InitializeAtmosphereQuality()
		{
			_atmosphereQuality = (_planetData.HasAtmosphere ? ((VisualEffectsQualitySettings.AtmosphereQuality)ModApi.Common.Game.Instance.QualitySettings.VisualEffects.Atmosphere) : VisualEffectsQualitySettings.AtmosphereQuality.Off);
			_atmosphere?.SetEnabled(_atmosphereQuality != VisualEffectsQualitySettings.AtmosphereQuality.Off);
		}

		private void InitializePlanetCubemaps(IPlanetNode node)
		{
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings;
			_cubemapHighDetailSize = cubemapSettings.ScaledSpaceHighDetailSize;
			_cubemapLowDetailSize = cubemapSettings.ScaledSpaceLowDetailSize;
			_cubemapRequest = node.PlanetData.RequestCubemaps("Scaled Space", _cubemapLowDetailSize, OnCubemapsUpdated);
		}

		private void OnAtmosphereQualityChanged(object sender, SettingChangedEventArgs<VisualEffectsQualitySettings.AtmosphereQuality> e)
		{
			_refreshAtmosphereQuality = true;
		}

		private void OnCubemapsUpdated(PlanetCubemapsRequest request)
		{
			_cubemapColors = request.CubemapColor;
			_cubemapNormals = request.CubemapNormals;
			UpdateCubemapShaderData();
			this.CubemapsChanged?.Invoke(this, new PlanetCubemapsChangedEventArgs(_cubemapColors, _cubemapNormals));
		}

		private void OnScaledSpaceVertexDisplacementSettingChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateRendererScales();
			UpdateCubemapShaderData();
		}

		private void OnValidate()
		{
			if (_planetData != null)
			{
				if (_planetData.SyncShaderData)
				{
					_planetData.ShaderDataSky.CopyFrom(_planetData.ShaderDataTerrain);
				}
				if (_planetData.HasAtmosphere && _atmosphere == null)
				{
					_atmosphere = CreateSphere("Planets/SkyFromSpace", isAtmosphere: true);
					_refreshAtmosphereQuality = true;
				}
				_refreshStaticData = true;
			}
		}

		private void UpdateCubemapRequestedSize()
		{
			if (_isCurrentPlanet)
			{
				return;
			}
			float pixelSize = PixelSize;
			int requestedSize = _cubemapRequest.RequestedSize;
			float num = (float)requestedSize * 1.5f;
			if (requestedSize == _cubemapLowDetailSize && pixelSize < num)
			{
				return;
			}
			float num2 = (float)requestedSize * 0.5f;
			if (pixelSize >= num && requestedSize < _cubemapHighDetailSize)
			{
				int num3 = requestedSize * 2;
				num = (float)num3 * 1.5f;
				while (pixelSize >= num && num3 < _cubemapHighDetailSize)
				{
					num3 *= 2;
					num = (float)num3 * 1.5f;
				}
				Debug.Log($"Scaled Space '{base.name}' requesting cubemap size change: {requestedSize} --> {num3}");
				_cubemapRequest.UpdateRequestedSize(num3);
			}
			else if (pixelSize <= num2 && requestedSize > _cubemapLowDetailSize)
			{
				int num4 = requestedSize / 2;
				num2 = (float)num4 * 0.5f;
				while (pixelSize <= num2 && num4 > _cubemapLowDetailSize)
				{
					num4 /= 2;
					num2 = (float)num4 * 1.5f;
				}
				Debug.Log($"Scaled Space '{base.name}' requesting cubemap size change: {requestedSize} --> {num4}");
				_cubemapRequest.UpdateRequestedSize(num4);
			}
		}

		private void UpdateCubemapShaderData()
		{
			IPlanetData planetData = Planet.PlanetNode.PlanetData;
			PlanetCubemapData cubemapData = PlanetCubemapUtility.GetCubemapData(planetData, create: false);
			Material material = _terrain.Material;
			material.SetTexture("_Cube", _cubemapColors);
			material.SetVector("_MaxColors", cubemapData.MaxColor);
			_shaderUsesVertexDisplacement = false;
			if (_cubemapNormals != null)
			{
				material.SetTexture("_BumpCube", _cubemapNormals);
				if (ModApi.Common.Game.Instance.QualitySettings.Terrain.ScaledSpaceVertexDisplacement.Value)
				{
					double radius = planetData.Radius;
					material.SetFloat("_MinASL", (float)((radius + (double)cubemapData.MinHeight) / radius));
					material.SetFloat("_MaxASL", (float)((radius + (double)cubemapData.MaxHeight) / radius));
					material.DisableKeyword("NORMALMAP");
					material.EnableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
					_shaderUsesVertexDisplacement = true;
				}
				else
				{
					material.EnableKeyword("NORMALMAP");
					material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
				}
			}
			else
			{
				material.DisableKeyword("NORMALMAP");
				material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
			}
		}

		private void UpdateLod()
		{
			float pixelSize = PixelSize;
			if (_shaderUsesVertexDisplacement && _cubemapNormals != null)
			{
				int num = _cubemapNormals.width;
				int num2 = -1;
				while (pixelSize >= 8f)
				{
					num2++;
					num /= 2;
					if (pixelSize > (float)num)
					{
						break;
					}
				}
				if (num2 == -1)
				{
					Material material = _terrain.Material;
					if (material.IsKeywordEnabled("NORMALMAP_WITH_VERTEX_DISPLACEMENT"))
					{
						material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
						material.EnableKeyword("NORMALMAP");
					}
				}
				else
				{
					Material material2 = _terrain.Material;
					material2.SetFloat(ShaderPropertyIds.VertexDisplacementLod, num2);
					if (!material2.IsKeywordEnabled("NORMALMAP_WITH_VERTEX_DISPLACEMENT"))
					{
						material2.DisableKeyword("NORMALMAP");
						material2.EnableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
					}
				}
			}
			if (pixelSize >= 32f)
			{
				UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality.High);
			}
			else if (pixelSize >= 8f)
			{
				UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality.Medium);
			}
			else
			{
				UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality.Low);
			}
		}

		private void UpdatePixelSize(Camera camera)
		{
			Transform transform = camera.transform;
			Vector3 position = _transform.position;
			Vector3 position2 = transform.position;
			float num = (position - position2).magnitude;
			if (_isCurrentPlanet)
			{
				num = Mathf.Max(num, _pixelSizeMinDistance);
				float num2 = Mathf.Sqrt(num * num - _radiusSquared);
				float num3 = Mathf.Acos(num2 / num) * 57.29578f;
				if (num3 <= float.Epsilon)
				{
					PixelSize = 0f;
					return;
				}
				Vector3 position3 = position2 + transform.forward * num;
				Vector3 position4 = position2 + transform.localRotation * Quaternion.Euler(0f, num3, 0f) * Vector3.forward * num2;
				Vector3 vector = camera.WorldToScreenPoint(position3);
				PixelSize = (camera.WorldToScreenPoint(position4).x - vector.x) * 2f;
			}
			else
			{
				Vector3 vector2 = position2 + transform.forward * num;
				Vector3 position5 = vector2 + transform.right * PlanetData.RadiusScaledSpace;
				Vector3 vector3 = camera.WorldToScreenPoint(vector2);
				PixelSize = (camera.WorldToScreenPoint(position5).x - vector3.x) * 2f;
			}
			if (_atmosphere != null)
			{
				bool flag = _planetData.Radius / num > 250f;
				if (_atmosphere.Renderer.enabled != flag)
				{
					_atmosphere.Renderer.enabled = flag;
				}
			}
		}

		private void UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality quality)
		{
			if (_planetMeshQuality != quality)
			{
				_planetMeshQuality = quality;
				_terrain.MeshFilter.mesh = PlanetMeshes.GetMesh(quality);
				if (_atmosphere != null)
				{
					quality = (PlanetMeshes.PlanetMeshQuality)((_atmosphereQuality != VisualEffectsQualitySettings.AtmosphereQuality.Ultra) ? Math.Min(2, (int)(quality + 1)) : Math.Min(3, (int)(quality + 1)));
					_atmosphere.MeshFilter.mesh = PlanetMeshes.GetMesh(quality);
				}
			}
		}

		private void UpdateRendererScales()
		{
			float num = (ModApi.Common.Game.Instance.QualitySettings.Terrain.ScaledSpaceVertexDisplacement.Value ? (_planetData.Radius * 0.0001f) : _planetData.RadiusScaledSpace);
			_terrain.Renderer.transform.localScale = new Vector3(num, num, num);
			if (_atmosphere != null)
			{
				float num2 = num * _atmosphere.StaticData.AtmosRenderingSizeScale;
				_atmosphere.Renderer.transform.localScale = new Vector3(num2, num2, num2);
			}
		}

		private void UpdateShaderData(bool currentPlanet)
		{
			if (_refreshStaticData)
			{
				UpdateStaticData(_refreshAtmosphereQuality);
			}
			_terrain.RefreshDynamicShaderData(currentPlanet);
			if (_planetData.HasAtmosphere && _atmosphere != null)
			{
				_atmosphere.RefreshDynamicShaderData(currentPlanet);
			}
		}

		private void UpdateShaderKeywords(Material material)
		{
			UpdateShaderKeywords(material, GetAtmosphereQuality(_planetData));
		}

		private void UpdateStaticData(bool updateAtmosphereQuality)
		{
			bool num = _planetData.HasAtmosphere && _atmosphere != null;
			_terrain.RefreshStaticShaderData();
			if (num)
			{
				_atmosphere.RefreshStaticShaderData();
			}
			if (updateAtmosphereQuality)
			{
				InitializeAtmosphereQuality();
			}
			UpdateShaderKeywords(_terrain.Material);
			if (num)
			{
				UpdateShaderKeywords(_atmosphere.Material);
			}
			_refreshStaticData = false;
			_refreshAtmosphereQuality = false;
		}
	}
}
