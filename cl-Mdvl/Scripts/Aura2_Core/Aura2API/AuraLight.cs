using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Light))]
	[AddComponentMenu("Aura 2/Aura Light", 1)]
	[ExecuteInEditMode]
	public class AuraLight : CullableObject
	{
		public float strength = 1f;

		public BooleanChoice useScattering;

		public bool overrideScattering;

		[Range(0f, 1f)]
		public float overridingScattering = 0.5f;

		public float scatteringBias;

		public bool useColorTemperatureTint;

		public bool overrideColor;

		[ColorCircularPicker(false)]
		public Color overridingColor = Color.white;

		public bool useShadow = true;

		[NonSerialized]
		public RenderTexture shadowMapRenderTexture;

		public bool useCookie = true;

		public RenderTexture cookieMapRenderTexture;

		public bool enableOutOfPhaseColor;

		public float outOfPhaseColorStrength = 0.1f;

		[ColorCircularPicker(false)]
		public Color outOfPhaseColor = Color.cyan;

		[NonSerialized]
		public RenderTexture shadowDataRenderTexture;

		public float customDistanceFalloffThreshold = 0.5f;

		public float customDistanceFalloffPower = 2f;

		public float customCookieDistanceFalloffStartThreshold = 0.1f;

		public float customCookieDistanceFalloffEndThreshold = 0.25f;

		public float customCookieDistanceFalloffPower = 2f;

		public float customAngularFalloffThreshold = 0.8f;

		public float customAngularFalloffPower = 2f;

		private Shader _storeDirectionalShadowDataShader;

		private Shader _storeDirectionalSpotCookieMapShader;

		private Shader _storePointLightShadowMapShader;

		private Mesh _storePointLightShadowMapMesh;

		private Shader _storePointLightCookieMapShader;

		private bool _isInitialized;

		private Light _lightComponent;

		private LightType _previousLightType;

		private bool _previousUseShadow;

		private int _shadowMapIndex;

		private CommandBuffer _copyShadowmapCommandBuffer;

		private bool _previousUseCookie;

		private int _cookieMapIndex;

		private Texture2D _previousCookieTexture;

		private Material _storeShadowDataMaterial;

		private CommandBuffer _storeShadowDataCommandBuffer;

		private Material _storePointLightShadowMapMaterial;

		private Material _storeCookieMapMaterial;

		private DirectionalLightParameters _directionalLightParameters;

		private SpotLightParameters _spotLightParameters;

		private PointLightParameters _pointLightParameters;

		public Light LightComponent
		{
			get
			{
				if (_isInitialized)
				{
					return _lightComponent;
				}
				return GetComponent<Light>();
			}
		}

		public LightType Type => LightComponent.type;

		public bool CastsShadows
		{
			get
			{
				if (QualitySettings.shadows != ShadowQuality.Disable && LightComponent.shadows != LightShadows.None)
				{
					return useShadow;
				}
				return false;
			}
		}

		public bool CastsCookie
		{
			get
			{
				if (LightComponent.cookie != null)
				{
					return useCookie;
				}
				return false;
			}
		}

		public bool IsActive { get; private set; }

		public event Action<AuraLight, LightType> OnUninitialize;

		private void Reset()
		{
			if (GetComponent<Light>().type == LightType.Directional)
			{
				strength *= 0.25f;
			}
		}

		private void OnEnable()
		{
			if (!Aura.IsCompatible)
			{
				base.enabled = false;
			}
			else
			{
				Initialize();
			}
		}

		private void OnDisable()
		{
			Uninitialize();
		}

		private void Update()
		{
			if (_previousUseShadow != CastsShadows || _previousUseCookie != CastsCookie || _previousLightType != Type)
			{
				Reinitialize();
			}
		}

		private void Initialize()
		{
			AuraCamera.OnRegisteredAuraCamerasListChanged += AuraCamera_OnRegistredAuraCamerasListChanged;
			IsActive = AuraCamera.HasRegisteredAuraCameras;
			if (!IsActive)
			{
				return;
			}
			InitializeResources();
			_lightComponent = GetComponent<Light>();
			_previousLightType = Type;
			if (CastsShadows)
			{
				Vector2Int vector2Int = new Vector2Int(0, 0);
				switch (Type)
				{
				case LightType.Directional:
					vector2Int = DirectionalLightsManager.ShadowMapSize;
					break;
				case LightType.Spot:
					vector2Int = SpotLightsManager.shadowMapSize;
					break;
				case LightType.Point:
					vector2Int = PointLightsManager.shadowMapSize;
					break;
				}
				shadowMapRenderTexture = new RenderTexture(vector2Int.x, vector2Int.y, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
				shadowMapRenderTexture.name = base.gameObject.name + " : Shadow Map Render Texture";
				shadowMapRenderTexture.Create();
				RenderTargetIdentifier renderTargetIdentifier = BuiltinRenderTextureType.CurrentActive;
				_copyShadowmapCommandBuffer = new CommandBuffer();
				_copyShadowmapCommandBuffer.name = "Aura 2 : Store shadowmap";
				_copyShadowmapCommandBuffer.SetShadowSamplingMode(renderTargetIdentifier, ShadowSamplingMode.RawDepth);
				_copyShadowmapCommandBuffer.Blit(renderTargetIdentifier, new RenderTargetIdentifier(shadowMapRenderTexture));
				LightComponent.AddCommandBuffer(LightEvent.AfterShadowMap, _copyShadowmapCommandBuffer);
				switch (Type)
				{
				case LightType.Point:
					_storePointLightShadowMapMaterial = new Material(_storePointLightShadowMapShader);
					break;
				case LightType.Directional:
					if (shadowDataRenderTexture == null)
					{
						shadowDataRenderTexture = new RenderTexture(32, 1, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
						shadowDataRenderTexture.name = base.gameObject.name + " : Shadow Data Render Texture";
					}
					_storeShadowDataCommandBuffer = new CommandBuffer();
					_storeShadowDataCommandBuffer.name = "Aura 2 : Store directional shadow data";
					_storeShadowDataMaterial = new Material(_storeDirectionalShadowDataShader);
					LightComponent.AddCommandBuffer(LightEvent.BeforeScreenspaceMask, _storeShadowDataCommandBuffer);
					_storeShadowDataCommandBuffer.Blit(null, new RenderTargetIdentifier(shadowDataRenderTexture), _storeShadowDataMaterial);
					AuraCamera.CommonDataManager.LightsCommonDataManager.OnShadowsSettingsChanged += LightsCommonDataManager_OnShadowsSettingsChanged;
					break;
				}
			}
			_previousUseShadow = CastsShadows;
			if (CastsCookie)
			{
				Vector2Int vector2Int2 = Vector2Int.zero;
				switch (Type)
				{
				case LightType.Directional:
					vector2Int2 = DirectionalLightsManager.cookieMapSize;
					break;
				case LightType.Spot:
					vector2Int2 = SpotLightsManager.cookieMapSize;
					break;
				case LightType.Point:
					vector2Int2 = PointLightsManager.cookieMapSize;
					break;
				}
				cookieMapRenderTexture = new RenderTexture(vector2Int2.x, vector2Int2.y, 0, RenderTextureFormat.R8);
				cookieMapRenderTexture.name = base.gameObject.name + " : Cookie Map Render Texture";
				if (Type == LightType.Point)
				{
					_storeCookieMapMaterial = new Material(_storePointLightCookieMapShader);
				}
				else
				{
					_storeCookieMapMaterial = new Material(_storeDirectionalSpotCookieMapShader);
				}
			}
			_previousUseCookie = CastsCookie;
			AuraCamera.CommonDataManager.LightsCommonDataManager.RegisterLight(this);
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(Camera_onPreCull));
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
			_isInitialized = true;
		}

		private void Uninitialize()
		{
			AuraCamera.OnRegisteredAuraCamerasListChanged -= AuraCamera_OnRegistredAuraCamerasListChanged;
			if (!_isInitialized)
			{
				return;
			}
			if (this.OnUninitialize != null)
			{
				this.OnUninitialize(this, _previousLightType);
			}
			if (_previousUseShadow)
			{
				LightComponent.RemoveCommandBuffer(LightEvent.AfterShadowMap, _copyShadowmapCommandBuffer);
				_copyShadowmapCommandBuffer.Clear();
				_copyShadowmapCommandBuffer.Release();
				_copyShadowmapCommandBuffer = null;
				shadowMapRenderTexture.Release();
				shadowMapRenderTexture.Destroy();
				shadowMapRenderTexture = null;
				switch (_previousLightType)
				{
				case LightType.Point:
					_storePointLightShadowMapMaterial.Destroy();
					_storePointLightShadowMapMaterial = null;
					break;
				case LightType.Directional:
					LightComponent.RemoveCommandBuffer(LightEvent.BeforeScreenspaceMask, _storeShadowDataCommandBuffer);
					_storeShadowDataCommandBuffer.Clear();
					_storeShadowDataCommandBuffer.Release();
					_storeShadowDataCommandBuffer = null;
					_storeShadowDataMaterial.Destroy();
					_storeShadowDataMaterial = null;
					shadowDataRenderTexture.Release();
					shadowDataRenderTexture.Destroy();
					shadowDataRenderTexture = null;
					AuraCamera.CommonDataManager.LightsCommonDataManager.OnShadowsSettingsChanged -= LightsCommonDataManager_OnShadowsSettingsChanged;
					break;
				}
			}
			if (_previousUseCookie)
			{
				_storeCookieMapMaterial.Destroy();
				_storeCookieMapMaterial = null;
				cookieMapRenderTexture.Release();
				cookieMapRenderTexture.Destroy();
				cookieMapRenderTexture = null;
			}
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(Camera_onPreCull));
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
			_isInitialized = false;
		}

		private void Reinitialize()
		{
			Uninitialize();
			Initialize();
		}

		private void AuraCamera_OnRegistredAuraCamerasListChanged()
		{
			if ((!IsActive && AuraCamera.HasRegisteredAuraCameras) || (IsActive && !AuraCamera.HasRegisteredAuraCameras))
			{
				Reinitialize();
			}
		}

		private void Camera_onPreCull(Camera camera)
		{
			if (!IsActive || !AuraCamera.IsFirstRegisteredCamera(camera))
			{
				return;
			}
			if (this == null)
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(Camera_onPreCull));
				return;
			}
			if (CastsShadows && Type == LightType.Point)
			{
				_copyShadowmapCommandBuffer.Clear();
			}
			UpdateBoundingSphere();
		}

		private void Camera_onPreRender(Camera camera)
		{
			if (!IsActive || (!AuraCamera.IsFirstRegisteredCamera(camera) && Type != LightType.Directional))
			{
				return;
			}
			if (this == null)
			{
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
				return;
			}
			if (CastsCookie)
			{
				CopyCookieMap();
			}
			PackParameters(camera);
		}

		private void LightsCommonDataManager_OnShadowsSettingsChanged()
		{
			if (CastsShadows)
			{
				Reinitialize();
			}
		}

		private void InitializeResources()
		{
			_storeDirectionalShadowDataShader = Aura.ResourcesCollection.storeDirectionalShadowDataShader;
			_storeDirectionalSpotCookieMapShader = Aura.ResourcesCollection.storeDirectionalSpotCookieMapShader;
			_storePointLightShadowMapShader = Aura.ResourcesCollection.storePointShadowMapShader;
			_storePointLightShadowMapMesh = Aura.ResourcesCollection.storePointShadowMapMesh;
			_storePointLightCookieMapShader = Aura.ResourcesCollection.storePointCookieMapShader;
		}

		private void PackParameters(Camera camera)
		{
			Vector4 vector = ((LightHelpers.IsColorTemperatureAvailable && useColorTemperatureTint) ? ((Vector4)Mathf.CorrelatedColorTemperatureToRGB(LightComponent.colorTemperature)) : Vector4.one);
			Vector4 vector2 = (overrideColor ? overridingColor : (LightComponent.color * vector)) * LightComponent.intensity * strength;
			int useDefaultScattering = ((useScattering == BooleanChoice.Default) ? 1 : 0);
			float scatteringOverride = ((useScattering == BooleanChoice.False) ? (-2f) : (overrideScattering ? (1f - overridingScattering) : (-1f)));
			switch (Type)
			{
			case LightType.Directional:
			{
				_directionalLightParameters.color = vector2;
				_directionalLightParameters.useDefaultScattering = useDefaultScattering;
				_directionalLightParameters.scatteringOverride = scatteringOverride;
				_directionalLightParameters.lightPosition = LightComponent.transform.position;
				_directionalLightParameters.lightDirection = LightComponent.transform.forward;
				Matrix4x4 matrix2 = Matrix4x4.TRS(LightComponent.transform.position, LightComponent.transform.rotation, Vector3.one);
				_directionalLightParameters.worldToLightMatrix = MatrixFloats.ToMatrixFloats(matrix2.inverse);
				_directionalLightParameters.lightToWorldMatrix = MatrixFloats.ToMatrixFloats(matrix2);
				_directionalLightParameters.shadowMapIndex = (CastsShadows ? _shadowMapIndex : (-1));
				_directionalLightParameters.cookieMapIndex = -1;
				if (CastsCookie)
				{
					_directionalLightParameters.cookieMapIndex = _cookieMapIndex;
					_directionalLightParameters.cookieParameters.x = LightComponent.cookieSize;
					_directionalLightParameters.cookieParameters.y = ((LightComponent.cookie.wrapMode != TextureWrapMode.Repeat) ? 1 : 0);
				}
				_directionalLightParameters.enableOutOfPhaseColor = (enableOutOfPhaseColor ? 1 : 0);
				_directionalLightParameters.outOfPhaseColor = (Vector4)outOfPhaseColor * outOfPhaseColorStrength;
				break;
			}
			case LightType.Spot:
				_spotLightParameters.color = vector2;
				_spotLightParameters.useDefaultScattering = useDefaultScattering;
				_spotLightParameters.scatteringOverride = scatteringOverride;
				_spotLightParameters.lightPosition = LightComponent.transform.position;
				_spotLightParameters.lightDirection = LightComponent.transform.forward;
				_spotLightParameters.lightRange = LightComponent.range;
				_spotLightParameters.lightCosHalfAngle = Mathf.Cos(LightComponent.spotAngle * 0.5f * (MathF.PI / 180f));
				_spotLightParameters.angularFalloffParameters = new Vector2(customAngularFalloffThreshold, customAngularFalloffPower);
				_spotLightParameters.distanceFalloffParameters = new Vector2(Mathf.Min(customDistanceFalloffThreshold, 0.999999f), customDistanceFalloffPower);
				_spotLightParameters.shadowMapIndex = -1;
				if (CastsShadows)
				{
					Matrix4x4 inverse2 = Matrix4x4.TRS(LightComponent.transform.position, LightComponent.transform.rotation, Vector3.one).inverse;
					Matrix4x4 matrix4x2 = Matrix4x4.Perspective(LightComponent.spotAngle, 1f, LightComponent.shadowNearPlane, LightComponent.range);
					Matrix4x4 matrix4x3 = Matrix4x4.TRS(Vector3.one * 0.5f, Quaternion.identity, Vector3.one * 0.5f) * matrix4x2;
					matrix4x3[0, 2] *= -1f;
					matrix4x3[1, 2] *= -1f;
					matrix4x3[2, 2] *= -1f;
					matrix4x3[3, 2] *= -1f;
					Matrix4x4 matrix = matrix4x3 * inverse2;
					_spotLightParameters.worldToShadowMatrix = MatrixFloats.ToMatrixFloats(matrix);
					_spotLightParameters.shadowMapIndex = _shadowMapIndex;
					_spotLightParameters.shadowStrength = 1f - LightComponent.shadowStrength;
				}
				_spotLightParameters.cookieMapIndex = -1;
				if (CastsCookie)
				{
					_spotLightParameters.cookieMapIndex = _cookieMapIndex;
					_spotLightParameters.cookieParameters.x = customCookieDistanceFalloffStartThreshold;
					_spotLightParameters.cookieParameters.y = customCookieDistanceFalloffEndThreshold;
					_spotLightParameters.cookieParameters.z = customCookieDistanceFalloffPower;
				}
				break;
			case LightType.Point:
				_pointLightParameters.color = vector2;
				_pointLightParameters.useDefaultScattering = useDefaultScattering;
				_pointLightParameters.scatteringOverride = scatteringOverride;
				_pointLightParameters.lightPosition = LightComponent.transform.position;
				_pointLightParameters.lightRange = LightComponent.range;
				_pointLightParameters.distanceFalloffParameters = new Vector2(Mathf.Min(customDistanceFalloffThreshold, 0.999999f), customDistanceFalloffPower);
				_pointLightParameters.shadowMapIndex = -1;
				if (CastsShadows)
				{
					Matrix4x4 matrix4x = Matrix4x4.TRS(camera.transform.position, base.transform.rotation, Vector3.one * camera.nearClipPlane * 2f);
					_storePointLightShadowMapMaterial.SetMatrix("_WorldViewProj", GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true) * camera.worldToCameraMatrix * matrix4x);
					_copyShadowmapCommandBuffer.SetGlobalTexture("_ShadowMapTexture", BuiltinRenderTextureType.CurrentActive);
					_copyShadowmapCommandBuffer.SetRenderTarget(shadowMapRenderTexture);
					_copyShadowmapCommandBuffer.DrawMesh(_storePointLightShadowMapMesh, matrix4x, _storePointLightShadowMapMaterial, 0);
					Matrix4x4 inverse = Matrix4x4.TRS(LightComponent.transform.position, LightComponent.transform.rotation, Vector3.one * LightComponent.range).inverse;
					_pointLightParameters.worldToShadowMatrix = MatrixFloats.ToMatrixFloats(inverse);
					_pointLightParameters.lightProjectionParameters = new Vector2(LightComponent.range / (LightComponent.shadowNearPlane - LightComponent.range), LightComponent.shadowNearPlane * LightComponent.range / (LightComponent.shadowNearPlane - LightComponent.range));
					_pointLightParameters.shadowMapIndex = _shadowMapIndex;
					_pointLightParameters.shadowStrength = 1f - LightComponent.shadowStrength;
				}
				_pointLightParameters.cookieMapIndex = -1;
				if (CastsCookie)
				{
					_pointLightParameters.cookieMapIndex = _cookieMapIndex;
					_pointLightParameters.cookieParameters.x = customCookieDistanceFalloffStartThreshold;
					_pointLightParameters.cookieParameters.y = customCookieDistanceFalloffEndThreshold;
					_pointLightParameters.cookieParameters.z = customCookieDistanceFalloffPower;
				}
				break;
			}
		}

		public DirectionalLightParameters GetDirectionnalParameters()
		{
			return _directionalLightParameters;
		}

		public SpotLightParameters GetSpotParameters()
		{
			return _spotLightParameters;
		}

		public PointLightParameters GetPointParameters()
		{
			return _pointLightParameters;
		}

		public void SetShadowMapIndex(int index)
		{
			_shadowMapIndex = index;
		}

		public void SetCookieMapIndex(int index)
		{
			_cookieMapIndex = index;
		}

		private void UpdateBoundingSphere()
		{
			float radius = float.MaxValue;
			switch (Type)
			{
			case LightType.Point:
				radius = LightComponent.range;
				break;
			case LightType.Spot:
				radius = LightComponent.range;
				break;
			}
			UpdateBoundingSphere(base.transform.position, radius);
		}

		private void CopyCookieMap()
		{
			if (Type == LightType.Point)
			{
				_storeCookieMapMaterial.SetMatrix("_InverseWorldMatrix", LightComponent.transform.localToWorldMatrix);
			}
			Graphics.Blit(LightComponent.cookie, cookieMapRenderTexture, _storeCookieMapMaterial);
		}

		public static GameObject CreateGameObject(string name, LightType type)
		{
			GameObject obj = new GameObject(name);
			obj.AddComponent<Light>();
			obj.GetComponent<Light>().type = type;
			obj.GetComponent<Light>().shadows = LightShadows.Soft;
			obj.AddComponent<AuraLight>();
			return obj;
		}
	}
}
