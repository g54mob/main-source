using System;
using System.Xml.Linq;
using ModApi.Cameras;
using ModApi.Common.Extensions;
using ModApi.Flight.GameView;
using ModApi.Flight.GameView.Events;
using ModApi.Flight.Sim;
using ModApi.PlanetStudio;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace ModApi.Planet.Modifiers.Material
{
	public class WaterMaterialModifier : PlanetModifier, ISerializationCallbackReceiver
	{
		[SerializeField]
		private bool _debugUpdateShaderDataEveryFrame;

		private ISceneCamera _farCamera;

		private IGameCamera _gameCamera;

		private IGameTime _gameTime;

		private IGameView _gameView;

		[SerializeField]
		[Range(0f, 1f)]
		private float _lightingFresnelBias;

		[SerializeField]
		[Tooltip("The normal map approach used for the water. Blended is the highest quality. BlendedFast is the same as Blended but faster due to more work done in the vertex shader, however it results in some visual artifacts.")]
		private WaterQualitySettings.NormalMapQuality _normalMapType;

		private IQuadSphere _quadSphere;

		private IReferenceFrame _referenceFrame;

		[SerializeField]
		[Tooltip("A value indicating whether water reflections are enabled.")]
		private bool _reflectionsEnabled;

		[SerializeField]
		[Tooltip("A value indicating whether water refraction is enabled.")]
		private bool _refractionEnabled;

		private bool _shaderDistanceBlendDataInitialized;

		[SerializeField]
		private UnityEngine.Material _sharedMaterial;

		[SerializeField]
		private DistanceBlendedTexturesConfiguration _tilingConfiguration;

		private PlanetWaterConfig _waterConfig;

		[SerializeField]
		[Tooltip("A value indicating whether waves are enabled.")]
		private bool _wavesEnabled;

		public DistanceBlendedTexturesConfiguration TilingConfiguration => _tilingConfiguration;

		protected UnityEngine.Material SharedMaterial
		{
			get
			{
				return _sharedMaterial;
			}
			set
			{
				_sharedMaterial = value;
			}
		}

		public WaterMaterialModifier()
			: base(PlanetModifierType.WaterMaterial)
		{
		}

		public static bool AreWavesEnabled()
		{
			bool value = Game.Instance.QualitySettings.Water.Waves.Value;
			bool flag = false;
			if (Game.InFlightScene)
			{
				flag = Game.Instance.FlightScene.ViewManager.GameView.Planet.PlanetData.TerrainData.WaterConfigDefault.WaveAmplitude != 0f;
			}
			else if (Game.InPlanetStudioScene)
			{
				flag = PlanetStudioBase.Instance.CelestialBodyDesigner.GameView.Planet.PlanetData.TerrainData.WaterConfigDefault.WaveAmplitude != 0f;
			}
			return value && flag;
		}

		public virtual UnityEngine.Material GetMaterial(IQuadSphereQuad quad)
		{
			return _sharedMaterial;
		}

		public override QuadMeshDataFlags GetRequiredWaterMeshData()
		{
			return QuadMeshDataFlags.Color | QuadMeshDataFlags.UV | QuadMeshDataFlags.UV2 | QuadMeshDataFlags.UV3;
		}

		public float GetSpecularity(float distance)
		{
			_tilingConfiguration.GetData(distance, out var outputStrengths, out var outputData);
			return outputData.z * outputStrengths.z + outputData.w * outputStrengths.w;
		}

		public virtual void InitializeQuadSphere(IQuadSphere quadSphere)
		{
			_quadSphere = quadSphere;
			_sharedMaterial = UnityEngine.Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Planets/Materials/PlanetQuadWaterMaterial"));
			_waterConfig = _quadSphere.PlanetData.TerrainData.WaterConfigDefault;
			if (Game.InFlightScene)
			{
				_gameView = Game.Instance.FlightScene.ViewManager.GameView;
				_gameCamera = _gameView.GameCamera;
				_farCamera = _gameCamera.FarCamera.GetComponent<ISceneCamera>();
			}
			else if (Game.InPlanetStudioScene)
			{
				_gameView = PlanetStudioBase.Instance.CelestialBodyDesigner.GameView;
				_gameCamera = _gameView.GameCamera;
				_farCamera = PlanetStudioBase.Instance.CelestialBodyDesigner.CelestialBodyViewer.FarCamera.GetComponent<ISceneCamera>();
			}
			else
			{
				Debug.LogError("Unsupported game mode for WaterMaterialModifier");
			}
			_gameView.ReferenceFrameRecentered -= OnReferenceFrameRecentered;
			_gameView.ReferenceFrameRecentered += OnReferenceFrameRecentered;
			_referenceFrame = _gameView.ReferenceFrame;
			if (_gameCamera != null)
			{
				_gameCamera.CameraUnderWaterStateChanged += OnUnderWaterStateChanged;
			}
			if (_farCamera != null)
			{
				_farCamera.PreRender += OnFarCameraPreRender;
				_farCamera.PostRender += OnFarCameraPostRender;
			}
			UpdateWaterWaveOffset();
			WaterQualitySettings water = Game.Instance.QualitySettings.Water;
			water.Changed += OnWaterQualityChanged;
			_quadSphere.MaxSubDivisionDistChanged += OnMaxSubDivisionDistChanged;
			if (_lightingFresnelBias != 0f)
			{
				SharedMaterial.SetFloat("_lightingFresnelBias", _lightingFresnelBias);
			}
			ApplyQualitySettings(water);
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_tilingConfiguration != null)
			{
				_tilingConfiguration.OnAfterDeserialize();
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			if (_lightingFresnelBias != 0f)
			{
				xml.SetAttributeValue("fresnelBias", _lightingFresnelBias);
			}
			xml.Add(_tilingConfiguration.SaveXml(new XElement("TilingConfig")));
		}

		public void UpdateTilingConfiguration(DistanceBlendedTexturesConfiguration tilingConfiguration)
		{
			_tilingConfiguration.CopyFrom(tilingConfiguration);
			UpdateShaderDistanceBlendData();
		}

		protected virtual void ApplyQualitySettings(WaterQualitySettings quality)
		{
			_normalMapType = quality.NormalMaps;
			_reflectionsEnabled = (WaterQualitySettings.ReflectionQuality)quality.Reflections != WaterQualitySettings.ReflectionQuality.None;
			_refractionEnabled = quality.Transparency;
			_wavesEnabled = AreWavesEnabled();
			UpdateShaderData();
			UpdateShaderDistanceBlendData();
		}

		protected override void Awake()
		{
			if (_tilingConfiguration == null)
			{
				_tilingConfiguration = new DistanceBlendedTexturesConfiguration();
			}
			_tilingConfiguration.InitializeLevels();
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (focus && _shaderDistanceBlendDataInitialized)
			{
				UpdateShaderDistanceBlendData();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (_sharedMaterial != null)
			{
				UnityEngine.Object.Destroy(_sharedMaterial);
			}
			Game.Instance.QualitySettings.Water.Changed -= OnWaterQualityChanged;
			if (_quadSphere != null)
			{
				_quadSphere.MaxSubDivisionDistChanged -= OnMaxSubDivisionDistChanged;
			}
			if (_gameView != null)
			{
				_gameView.ReferenceFrameRecentered -= OnReferenceFrameRecentered;
			}
			if (_gameCamera != null)
			{
				_gameCamera.CameraUnderWaterStateChanged -= OnUnderWaterStateChanged;
			}
			if (_farCamera != null)
			{
				_farCamera.PreRender -= OnFarCameraPreRender;
				_farCamera.PostRender -= OnFarCameraPostRender;
			}
		}

		protected virtual void OnValidate()
		{
			if (_shaderDistanceBlendDataInitialized)
			{
				UpdateShaderData();
				UpdateShaderDistanceBlendData();
				Game.Instance.QualitySettings.Water.RaiseSettingsChangedEvent();
			}
		}

		protected virtual void Reset()
		{
			if (_tilingConfiguration == null)
			{
				_tilingConfiguration = new DistanceBlendedTexturesConfiguration();
			}
			_tilingConfiguration.InitializeLevels();
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_lightingFresnelBias = xml.GetFloatAttribute("fresnelBias");
			_tilingConfiguration = new DistanceBlendedTexturesConfiguration();
			_tilingConfiguration.RestoreXml(xml.Element("TilingConfig"));
		}

		protected virtual void Start()
		{
			UpdateWaterWaveFadeOutDist();
			_gameTime = Game.Instance.FlightScene?.IocContainer.Resolve<IGameTime>();
		}

		protected virtual void Update()
		{
			UnityEngine.Material sharedMaterial = SharedMaterial;
			if ((object)sharedMaterial != null)
			{
				if (_gameTime != null)
				{
					sharedMaterial.SetFloat("_WaveTime", (float)_gameTime.WaveTime);
				}
				else if (_quadSphere != null)
				{
					sharedMaterial.SetFloat("_WaveTime", (float)_quadSphere.PlanetData.GetWaveTime(Time.timeSinceLevelLoad));
				}
				if (_debugUpdateShaderDataEveryFrame)
				{
					UpdateShaderData();
				}
			}
		}

		[ContextMenu("Create Renderer")]
		private void CreateRenderer()
		{
			base.gameObject.AddComponent<MeshRenderer>().sharedMaterial = _sharedMaterial;
		}

		private void OnFarCameraPostRender(object sender, EventArgs e)
		{
			SetShaderLod(isFarCameraRendering: false);
		}

		private void OnFarCameraPreRender(object sender, EventArgs e)
		{
			SetShaderLod(isFarCameraRendering: true);
		}

		private void OnMaxSubDivisionDistChanged(IQuadSphere sphere)
		{
			UpdateWaterWaveFadeOutDist();
		}

		private void OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			UpdateWaterWaveOffset();
		}

		private void OnUnderWaterStateChanged(object sender, CameraUnderwaterStateChangedEventArgs e)
		{
		}

		private void OnWaterQualityChanged(object sender, SettingsChangedEventArgs<WaterQualitySettings> e)
		{
			ApplyQualitySettings(e.Category);
		}

		private void SetShaderLod(bool isFarCameraRendering)
		{
			UnityEngine.Material sharedMaterial = _sharedMaterial;
			bool flag = _refractionEnabled && !isFarCameraRendering;
			bool flag2 = _wavesEnabled && !isFarCameraRendering;
			if (flag && _reflectionsEnabled)
			{
				sharedMaterial.shader.maximumLOD = (flag2 ? 540 : 400);
			}
			else if (flag)
			{
				sharedMaterial.shader.maximumLOD = (flag2 ? 530 : 300);
			}
			else if (_reflectionsEnabled)
			{
				sharedMaterial.shader.maximumLOD = (flag2 ? 520 : 200);
			}
			else
			{
				sharedMaterial.shader.maximumLOD = (flag2 ? 510 : 100);
			}
		}

		private void UpdateShaderData()
		{
			UnityEngine.Material sharedMaterial = _sharedMaterial;
			if ((object)sharedMaterial == null)
			{
				return;
			}
			SetShaderLod(isFarCameraRendering: false);
			if (_normalMapType == WaterQualitySettings.NormalMapQuality.Blended)
			{
				sharedMaterial.DisableKeyword("WATER_NORMAL_MAPS_BLENDED_FAST");
				sharedMaterial.EnableKeyword("WATER_NORMAL_MAPS_BLENDED");
			}
			else if (_normalMapType == WaterQualitySettings.NormalMapQuality.BlendedFast)
			{
				sharedMaterial.DisableKeyword("WATER_NORMAL_MAPS_BLENDED");
				sharedMaterial.EnableKeyword("WATER_NORMAL_MAPS_BLENDED_FAST");
			}
			else
			{
				sharedMaterial.DisableKeyword("WATER_NORMAL_MAPS_BLENDED_FAST");
				sharedMaterial.DisableKeyword("WATER_NORMAL_MAPS_BLENDED");
			}
			if (_waterConfig != null)
			{
				sharedMaterial.SetFloat("_MaxTransparencyDepth", _waterConfig.TransparencyDepth);
				sharedMaterial.SetFloat("_FresnelBias", _waterConfig.FresnelBias);
				sharedMaterial.SetFloat("_FoamDepthInverse", 1f / _waterConfig.FoamDepth);
				sharedMaterial.SetColor("_FoamColor", _waterConfig.FoamColor);
				sharedMaterial.SetFloat("_RefractionDistortionStrength", _waterConfig.RefractionDistortion);
				sharedMaterial.SetFloat("_ReflectionDistortionStrength", _waterConfig.ReflectionDistortion);
				if (_wavesEnabled)
				{
					sharedMaterial.SetFloat("_WaveAmplitude", _waterConfig.WaveAmplitude);
					sharedMaterial.SetFloat("_WaveLength", _waterConfig.WaveLength);
					sharedMaterial.SetFloat("_WaveSpeed", _waterConfig.WaveSpeed);
				}
			}
		}

		private void UpdateShaderDistanceBlendData()
		{
			SharedMaterial?.SetVectorArray("_distanceBlendLookup", _tilingConfiguration.GetShaderData(base.PlanetScale));
			_shaderDistanceBlendDataInitialized = true;
		}

		private void UpdateWaterWaveFadeOutDist()
		{
			_sharedMaterial?.SetFloat("_MaxDisplacementDist", (float)_quadSphere.MaxSubDivisionDist / 2f);
		}

		private void UpdateWaterWaveOffset()
		{
			_sharedMaterial?.SetVector("_WaveOffset", (Vector3)_referenceFrame.WaterWaveOffset);
		}
	}
}
