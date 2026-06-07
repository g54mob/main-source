using System;
using UnityEngine;

namespace TrueClouds
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public abstract class CloudCamera : MonoBehaviour
	{
		public LayerMask CloudsMask;

		public LayerMask LightMask;

		public LayerMask WorldBlockingMask;

		public int ResolutionDivider = 3;

		public int WorldDepthResolutionDivider = 2;

		public DepthPrecision DepthPrecision = DepthPrecision.Medium;

		public bool LateCut = true;

		public float BlurRadius = 10f;

		public BlurQuality BlurQuality = BlurQuality.High;

		public float LateCutThreshohld;

		public float LateCutPower = 1.5f;

		public bool UseDepthFiltering;

		public float DepthFilteringPower;

		public bool UseNoise;

		public Texture2D Noise;

		public Vector3 Wind = new Vector3(2f, 1f, 3f);

		public float NoiseScale = 1f;

		public float DepthNoiseScale = 1f;

		public float NormalNoisePower = 1f;

		public float DepthNoisePower = 1f;

		public float DisplacementNoisePower = 1f;

		public float NoiseSinTimeScale = 0.2f;

		public float DistanceToClouds = 10f;

		public Transform Light;

		public bool UseRamp;

		public Texture Ramp;

		public Color LightColor = Color.white;

		public Color ShadowColor = new Color(0.6f, 0.72f, 0.84f);

		public float LightEnd = 0.75f;

		public float HaloPower = 3f;

		public float HaloDistance = 0.5f;

		public float FallbackDistance = 1f;

		public Shader blurFastShader;

		public Shader blurShader;

		public Shader blurHQShader;

		public Shader depthBlurShader;

		public Shader depthShader;

		public Shader cloudShader;

		public Shader clearColorShader;

		private RenderTexture _worldDepth;

		private RenderTexture _cloudDepth;

		private RenderTexture _fromRT;

		private RenderTexture _toRT;

		private RenderTexture _cloudMain;

		private RenderTexture _worldBlit;

		private Material _renderMaterial;

		private Material _blurMaterial;

		private Material _depthBlurMaterial;

		private Material _clearColorMaterial;

		private Camera _camera;

		private Camera _tempCamera;

		private Vector3 _windTime;

		private static int LIGHT_DIR_ID;

		private static int LIGHT_POS_ID;

		private static int MAIN_COLOR_ID;

		private static int SHADOW_COLOR_ID;

		private static int LIGHT_END_ID;

		private static int WORLD_DEPTH_ID;

		private static int CAMERA_DEPTH_ID;

		private static int NORMALS_ID;

		private static int RAMP_ID;

		private static int NOISE_ID;

		private static int NORMAL_NOISE_POWER_ID;

		private static int DEPTH_NOISE_POWER_ID;

		private static int DISPLACEMENT_NOISE_POWER_ID;

		private static int NOISE_SIN_TIME_ID;

		private static int NOISE_PARAMS_ID;

		private static int FALLBACK_DIST_ID;

		private static int CAMERA_ROTATION_ID;

		private static int NEAR_PLANE_ID;

		private static int FAR_PLANE_ID;

		private static int CAMERA_DIR_LD;

		private static int CAMERA_DIR_RD;

		private static int CAMERA_DIR_LU;

		private static int CAMERA_DIR_RU;

		private static int HALO_POWER_ID;

		private static int HALO_DISTANCE_ID;

		private static int BLUR_SIZE_ID;

		private static int LATE_CUT_THRESHOLD;

		private static int LATE_CUT_POWER;

		private static int DEPTH_FILTERING_POWER;

		private int _lastBlurQuality = -1;

		private int _lastResolutionDivider = -1;

		private int _lastWorldResolutionDivider = -1;

		private Rect _lastScreenRect = Rect.zero;

		protected virtual void Awake()
		{
			_camera = GetComponent<Camera>();
			GameObject gameObject = new GameObject("cloud camera");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			_tempCamera = gameObject.AddComponent<Camera>();
			_tempCamera.CopyFrom(_camera);
			_tempCamera.enabled = false;
		}

		private void OnEnable()
		{
			CleanupRenderTextures();
			SetupShaderIDs();
		}

		private void OnDisable()
		{
			CleanupRenderTextures();
		}

		private void SetupShaderIDs()
		{
			LIGHT_DIR_ID = Shader.PropertyToID("_LightDir");
			LIGHT_POS_ID = Shader.PropertyToID("_LightPos");
			MAIN_COLOR_ID = Shader.PropertyToID("_MainColor");
			SHADOW_COLOR_ID = Shader.PropertyToID("_ShadowColor");
			LIGHT_END_ID = Shader.PropertyToID("_LightEnd");
			WORLD_DEPTH_ID = Shader.PropertyToID("_WorldDepth");
			CAMERA_DEPTH_ID = Shader.PropertyToID("_CameraDepth");
			NORMALS_ID = Shader.PropertyToID("_NormalTex");
			RAMP_ID = Shader.PropertyToID("_Ramp");
			NOISE_ID = Shader.PropertyToID("_Noise");
			NOISE_PARAMS_ID = Shader.PropertyToID("_NoiseParams");
			NORMAL_NOISE_POWER_ID = Shader.PropertyToID("_NormalNoisePower");
			NOISE_SIN_TIME_ID = Shader.PropertyToID("_NoiseSinTime");
			DEPTH_NOISE_POWER_ID = Shader.PropertyToID("_DepthNoisePower");
			DISPLACEMENT_NOISE_POWER_ID = Shader.PropertyToID("_DisplacementNoisePower");
			FALLBACK_DIST_ID = Shader.PropertyToID("_FallbackDist");
			CAMERA_ROTATION_ID = Shader.PropertyToID("_CameraRotation");
			NEAR_PLANE_ID = Shader.PropertyToID("_NearPlane");
			FAR_PLANE_ID = Shader.PropertyToID("_FarPlane");
			CAMERA_DIR_LD = Shader.PropertyToID("_CameraDirLD");
			CAMERA_DIR_RD = Shader.PropertyToID("_CameraDirRD");
			CAMERA_DIR_LU = Shader.PropertyToID("_CameraDirLU");
			CAMERA_DIR_RU = Shader.PropertyToID("_CameraDirRU");
			HALO_POWER_ID = Shader.PropertyToID("_HaloPower");
			HALO_DISTANCE_ID = Shader.PropertyToID("_HaloDistance");
			BLUR_SIZE_ID = Shader.PropertyToID("_BlurSize");
			LATE_CUT_THRESHOLD = Shader.PropertyToID("_LateCutThreshohld");
			LATE_CUT_POWER = Shader.PropertyToID("_LateCutPower");
			DEPTH_FILTERING_POWER = Shader.PropertyToID("_DepthFilteringPower");
		}

		private void SetupRenderTextures()
		{
			_cloudMain = GetTemporaryTexture(ResolutionDivider, FilterMode.Bilinear, "TrueClouds.RT_cloudMain");
			_worldDepth = GetTemporaryTexture(WorldDepthResolutionDivider, FilterMode.Bilinear, "TrueClouds.RT_worldDepth");
			if (WorldDepthResolutionDivider != 1)
			{
				_worldBlit = GetTemporaryTexture(WorldDepthResolutionDivider, FilterMode.Bilinear, "TrueClouds.RT_worldBlit");
			}
			_cloudDepth = GetTemporaryTexture(ResolutionDivider, FilterMode.Bilinear, "TrueClouds.RT_cloudDepth");
			_fromRT = GetTemporaryTexture(ResolutionDivider, FilterMode.Bilinear, "TrueClouds.RT_fromRT");
			_toRT = GetTemporaryTexture(ResolutionDivider, FilterMode.Bilinear, "TrueClouds.RT_toRT");
			_lastScreenRect = _camera.rect;
		}

		private void CleanupRenderTextures()
		{
			ReleaseTemporaryTexture(ref _cloudMain);
			ReleaseTemporaryTexture(ref _worldDepth);
			ReleaseTemporaryTexture(ref _worldBlit);
			ReleaseTemporaryTexture(ref _cloudDepth);
			ReleaseTemporaryTexture(ref _fromRT);
			ReleaseTemporaryTexture(ref _toRT);
			_lastScreenRect = Rect.zero;
		}

		private void Start()
		{
			_camera.cullingMask &= ~(int)CloudsMask;
			_camera.cullingMask &= ~(int)LightMask;
			_renderMaterial = new Material(cloudShader);
			UpdateBlurMaterial();
			_depthBlurMaterial = new Material(depthBlurShader);
			_clearColorMaterial = new Material(clearColorShader);
		}

		private void UpdateBlurMaterial()
		{
			switch (BlurQuality)
			{
			case BlurQuality.Low:
				_blurMaterial = new Material(blurFastShader);
				break;
			case BlurQuality.Medium:
				_blurMaterial = new Material(blurShader);
				break;
			case BlurQuality.High:
				_blurMaterial = new Material(blurHQShader);
				break;
			}
			_lastBlurQuality = (int)BlurQuality;
		}

		private RenderTexture GetTemporaryTexture(int divider, FilterMode mode, string name)
		{
			RenderTexture temporary = RenderTexture.GetTemporary((int)_camera.pixelRect.size.x / divider, (int)_camera.pixelRect.size.y / divider, 16, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			temporary.name = name;
			return temporary;
		}

		private void ReleaseTemporaryTexture(ref RenderTexture texture)
		{
			if (texture != null)
			{
				RenderTexture.ReleaseTemporary(texture);
				texture = null;
			}
		}

		protected void RenderClouds(RenderTexture source, RenderTexture destination)
		{
			UpdateChangedSettings();
			_tempCamera.CopyFrom(_camera);
			_tempCamera.allowMSAA = false;
			_tempCamera.allowHDR = false;
			_tempCamera.renderingPath = RenderingPath.Forward;
			_tempCamera.depthTextureMode = DepthTextureMode.Depth;
			_tempCamera.enabled = false;
			ApplyBlits(source, destination);
		}

		private void ApplyBlits(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination);
			_tempCamera.clearFlags = CameraClearFlags.Color;
			_tempCamera.backgroundColor = Color.white;
			_tempCamera.rect = new Rect(Vector2.zero, Vector2.one);
			_worldDepth.DiscardContents();
			_tempCamera.targetTexture = _worldDepth;
			_tempCamera.cullingMask = WorldBlockingMask;
			_tempCamera.RenderWithShader(depthShader, string.Empty);
			_cloudDepth.DiscardContents();
			_tempCamera.targetTexture = _cloudDepth;
			_tempCamera.cullingMask = CloudsMask;
			_tempCamera.RenderWithShader(depthShader, "RenderType");
			_tempCamera.clearFlags = CameraClearFlags.Color;
			_tempCamera.backgroundColor = new Color(0.5f, 0.5f, 0.5f, 0f);
			_tempCamera.cullingMask = CloudsMask;
			_cloudMain.DiscardContents();
			_tempCamera.targetTexture = _cloudMain;
			_tempCamera.Render();
			_tempCamera.enabled = false;
			UpdateShaderValues();
			if (LateCut)
			{
				SwapTextures(ref _toRT, ref _cloudMain);
			}
			else
			{
				SwapTextures();
				Graphics.Blit(_cloudMain, _toRT, _renderMaterial, 0);
			}
			if (LateCut || UseNoise)
			{
				_depthBlurMaterial.SetTexture(NORMALS_ID, _toRT);
				SwapTextures(ref _fromRT, ref _cloudDepth);
				Graphics.Blit(_fromRT, _cloudDepth, _depthBlurMaterial, 1);
				SwapTextures(ref _fromRT, ref _cloudDepth);
				Graphics.Blit(_fromRT, _cloudDepth, _depthBlurMaterial, 2);
				_renderMaterial.SetTexture(CAMERA_DEPTH_ID, _cloudDepth);
				_blurMaterial.SetTexture(CAMERA_DEPTH_ID, _cloudDepth);
			}
			SwapTextures();
			Graphics.Blit(_fromRT, _toRT, _blurMaterial, 0);
			SwapTextures();
			Graphics.Blit(_fromRT, _toRT, _blurMaterial, 1);
			if ((LateCut || UseNoise) && UseNoise)
			{
				SwapTextures(ref _fromRT, ref _cloudDepth);
				Graphics.Blit(_fromRT, _cloudDepth, _depthBlurMaterial, 0);
				_renderMaterial.SetTexture(CAMERA_DEPTH_ID, _cloudDepth);
			}
			SwapTextures();
			Graphics.Blit(_fromRT, _toRT, _renderMaterial, 1);
			Shader.SetGlobalTexture(CAMERA_DEPTH_ID, _cloudDepth);
			Shader.SetGlobalTexture(NORMALS_ID, _fromRT);
			_tempCamera.clearFlags = CameraClearFlags.Depth;
			_tempCamera.targetTexture = _toRT;
			_tempCamera.cullingMask = LightMask;
			_tempCamera.Render();
			if (!LateCut)
			{
				SwapTextures();
				Graphics.Blit(_fromRT, destination, _renderMaterial, 4);
			}
			else if (WorldDepthResolutionDivider != 1)
			{
				_worldBlit.DiscardContents();
				SwapTextures();
				Graphics.Blit(_fromRT, _worldBlit, _renderMaterial, 3);
				Graphics.Blit(_worldBlit, destination, _renderMaterial, 4);
			}
			else
			{
				SwapTextures();
				Graphics.Blit(_fromRT, destination, _renderMaterial, 2);
			}
		}

		private void DrawGreyBorder(RenderTexture texture)
		{
			Graphics.SetRenderTarget(texture);
			_clearColorMaterial.SetPass(0);
			GL.LoadPixelMatrix();
			GL.Color(Color.black);
			GL.Begin(2);
			GL.Vertex(new Vector3(1f, 1f));
			GL.Vertex(new Vector3(1f, Screen.height));
			GL.Vertex(new Vector3(Screen.width, Screen.height));
			GL.Vertex(new Vector3(Screen.width, 1f));
			GL.Vertex(new Vector3(1f, 1f));
			GL.End();
		}

		private void SwapTextures()
		{
			SwapTextures(ref _fromRT, ref _toRT);
		}

		private void SwapTextures(ref RenderTexture a, ref RenderTexture b)
		{
			a.DiscardContents();
			RenderTexture renderTexture = a;
			a = b;
			b = renderTexture;
		}

		private void SetFeature(string on, string off, bool enable)
		{
			if (enable)
			{
				Shader.DisableKeyword(off);
				Shader.EnableKeyword(on);
			}
			else
			{
				Shader.DisableKeyword(on);
				Shader.EnableKeyword(off);
			}
		}

		private void UpdateShaderValues()
		{
			if (Light != null)
			{
				Vector4 value = -Light.transform.forward;
				value.w = Mathf.Max(0f, Vector3.Dot(base.transform.forward, -Light.transform.forward));
				_renderMaterial.SetVector(LIGHT_DIR_ID, value);
				Vector3 point = -(base.transform.worldToLocalMatrix * Light.transform.forward);
				point.z = 0f - point.z;
				Vector2 vector = _camera.projectionMatrix.MultiplyPoint(point);
				vector = vector * 0.5f + new Vector2(0.5f, 0.5f);
				_renderMaterial.SetVector(LIGHT_POS_ID, vector);
			}
			bool enable = DepthPrecision == DepthPrecision.High;
			SetFeature("HIGH_RES_DEPTH", "MEDIUM_RES_DEPTH", enable);
			bool enable2 = HaloDistance > 0.01f && HaloPower > 0.01f;
			SetFeature("HALO_ON", "HALO_OFF", enable2);
			SetFeature("LATE_CUT", "EARLY_CUT", LateCut);
			SetFeature("DEPTH_FILTERING_ON", "DEPTH_FILTERING_OFF", UseDepthFiltering);
			SetFeature("NOISE_ON", "NOISE_OFF", UseNoise);
			SetFeature("RAMP_ON", "RAMP_OFF", UseRamp);
			_renderMaterial.SetColor(MAIN_COLOR_ID, LightColor);
			if (UseRamp)
			{
				_renderMaterial.SetTexture(RAMP_ID, Ramp);
			}
			else
			{
				_renderMaterial.SetColor(SHADOW_COLOR_ID, ShadowColor);
				_renderMaterial.SetFloat(LIGHT_END_ID, LightEnd);
			}
			_renderMaterial.SetTexture(WORLD_DEPTH_ID, _worldDepth);
			_renderMaterial.SetTexture(CAMERA_DEPTH_ID, _cloudDepth);
			if (UseNoise)
			{
				_renderMaterial.SetTexture(NOISE_ID, Noise);
				_depthBlurMaterial.SetTexture(NOISE_ID, Noise);
				_windTime += Wind * Time.deltaTime;
				Vector4 value2 = new Vector4(0f - _windTime.x, 0f - _windTime.y, 0f - _windTime.z, 1f / (NoiseScale * DistanceToClouds));
				Vector4 value3 = new Vector4(0f - _windTime.x, 0f - _windTime.y, 0f - _windTime.z, 1f / (DepthNoiseScale * DistanceToClouds));
				_renderMaterial.SetVector(NOISE_PARAMS_ID, value2);
				_depthBlurMaterial.SetVector(NOISE_PARAMS_ID, value3);
				_renderMaterial.SetFloat(NORMAL_NOISE_POWER_ID, NormalNoisePower * 0.3f);
				_renderMaterial.SetFloat(DISPLACEMENT_NOISE_POWER_ID, DisplacementNoisePower * 0.07f * DistanceToClouds);
				_depthBlurMaterial.SetFloat(DEPTH_NOISE_POWER_ID, DepthNoisePower * DistanceToClouds);
				Vector3 vector2 = new Vector3(Mathf.Sin(Time.time * NoiseSinTimeScale * 2f * MathF.PI), Mathf.Sin((Time.time * NoiseSinTimeScale + 0.3333f) * 2f * MathF.PI), Mathf.Sin((Time.time * NoiseSinTimeScale + 0.6666f) * 2f * MathF.PI));
				_depthBlurMaterial.SetVector(NOISE_SIN_TIME_ID, vector2);
			}
			_renderMaterial.SetFloat(FALLBACK_DIST_ID, FallbackDistance);
			_depthBlurMaterial.SetFloat(FALLBACK_DIST_ID, FallbackDistance);
			_renderMaterial.SetMatrix(CAMERA_ROTATION_ID, base.transform.localToWorldMatrix);
			_depthBlurMaterial.SetMatrix(CAMERA_ROTATION_ID, base.transform.localToWorldMatrix);
			_renderMaterial.SetFloat(NEAR_PLANE_ID, _camera.nearClipPlane);
			_depthBlurMaterial.SetFloat(NEAR_PLANE_ID, _camera.nearClipPlane);
			_renderMaterial.SetFloat(FAR_PLANE_ID, _camera.farClipPlane);
			_blurMaterial.SetFloat(FAR_PLANE_ID, _camera.farClipPlane);
			_depthBlurMaterial.SetFloat(FAR_PLANE_ID, _camera.farClipPlane);
			_blurMaterial.SetFloat(LATE_CUT_THRESHOLD, LateCutThreshohld);
			_blurMaterial.SetFloat(LATE_CUT_POWER, LateCutPower);
			float num = BlurRadius;
			if (UseDepthFiltering)
			{
				num *= Mathf.Pow(DistanceToClouds / _camera.farClipPlane, DepthFilteringPower);
				_blurMaterial.SetFloat(DEPTH_FILTERING_POWER, DepthFilteringPower);
				_depthBlurMaterial.SetFloat(DEPTH_FILTERING_POWER, DepthFilteringPower);
			}
			_depthBlurMaterial.SetFloat(BLUR_SIZE_ID, num);
			_blurMaterial.SetFloat(BLUR_SIZE_ID, num);
			Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
			Vector4 value4 = worldToLocalMatrix * Point(_camera.ScreenToWorldPoint(new Vector3(0f, 0f, 1f)));
			Vector4 value5 = worldToLocalMatrix * Point(_camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0f, 1f)));
			Vector4 value6 = worldToLocalMatrix * Point(_camera.ScreenToWorldPoint(new Vector3(0f, _camera.pixelHeight, 1f)));
			Vector4 value7 = worldToLocalMatrix * Point(_camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight, 1f)));
			_renderMaterial.SetVector(CAMERA_DIR_LD, value4);
			_depthBlurMaterial.SetVector(CAMERA_DIR_LD, value4);
			_renderMaterial.SetVector(CAMERA_DIR_RD, value5);
			_depthBlurMaterial.SetVector(CAMERA_DIR_RD, value5);
			_renderMaterial.SetVector(CAMERA_DIR_LU, value6);
			_depthBlurMaterial.SetVector(CAMERA_DIR_LU, value6);
			_renderMaterial.SetVector(CAMERA_DIR_RU, value7);
			_depthBlurMaterial.SetVector(CAMERA_DIR_RU, value7);
			_renderMaterial.SetFloat(HALO_POWER_ID, HaloPower);
			_renderMaterial.SetFloat(HALO_DISTANCE_ID, HaloDistance / 2f);
		}

		private static Vector4 Point(Vector3 v)
		{
			return new Vector4(v.x, v.y, v.z, 1f);
		}

		private void UpdateChangedSettings()
		{
			if (_lastBlurQuality != (int)BlurQuality)
			{
				UpdateBlurMaterial();
			}
			if (_lastResolutionDivider != ResolutionDivider || _lastWorldResolutionDivider != WorldDepthResolutionDivider || _lastScreenRect != _camera.rect)
			{
				CleanupRenderTextures();
				_lastResolutionDivider = ResolutionDivider;
				_lastWorldResolutionDivider = WorldDepthResolutionDivider;
				SetupRenderTextures();
			}
		}
	}
}
