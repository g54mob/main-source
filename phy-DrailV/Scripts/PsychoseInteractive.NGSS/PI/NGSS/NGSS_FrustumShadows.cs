using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

namespace PI.NGSS
{
	[ExecuteInEditMode]
	public class NGSS_FrustumShadows : MonoBehaviour
	{
		public static NGSS_FrustumShadows instance;

		[Header("REFERENCES")]
		public Light mainShadowsLight;

		public Shader frustumShadowsShader;

		public Shader shadowApplyShader;

		[Header("SHADOWS SETTINGS")]
		[Tooltip("Poisson Noise. Randomize samples to remove repeated patterns.")]
		public bool m_dithering;

		[Tooltip("If enabled a faster separable blur will be used.\nIf disabled a slower depth aware blur will be used.")]
		public bool m_fastBlur = true;

		[Tooltip("If enabled, backfaced lit fragments will be skipped increasing performance. Requires GBuffer normals.")]
		public bool m_deferredBackfaceOptimization;

		[Range(0f, 1f)]
		[Tooltip("Set how backfaced lit fragments are shaded. Requires DeferredBackfaceOptimization to be enabled.")]
		public float m_deferredBackfaceTranslucency;

		[Tooltip("Tweak this value to remove soft-shadows leaking around edges.")]
		[Range(0.01f, 1f)]
		public float m_shadowsEdgeBlur = 0.25f;

		[Tooltip("Overall softness of the shadows.")]
		[Range(0.01f, 1f)]
		public float m_shadowsBlur = 0.5f;

		[Tooltip("Overall softness of the shadows. Higher values than 1 wont work well if FastBlur is enabled.")]
		[Range(1f, 4f)]
		public int m_shadowsBlurIterations = 1;

		[Tooltip("Rising this value will make shadows more blurry but also lower in resolution.")]
		[Range(1f, 4f)]
		public int m_shadowsDownGrade = 1;

		[Tooltip("Tweak this value if your objects display backface shadows.")]
		[Range(0f, 1f)]
		public float m_shadowsBias = 0.05f;

		[Tooltip("The distance in metters from camera where shadows start to shown.")]
		public float m_shadowsDistanceStart;

		[Header("RAY SETTINGS")]
		[Tooltip("If enabled the ray length will be scaled at screen space instead of world space. Keep it enabled for an infinite view shadows coverage. Disable it for a ContactShadows like effect. Adjust the Ray Scale property accordingly.")]
		public bool m_rayScreenScale = true;

		[Tooltip("Number of samplers between each step. The higher values produces less gaps between shadows but is more costly.")]
		[Range(16f, 128f)]
		public int m_raySamples = 64;

		[Tooltip("The higher the value, the larger the shadows ray will be.")]
		[Range(0.01f, 1f)]
		public float m_rayScale = 0.25f;

		[Tooltip("The higher the value, the ticker the shadows will look.")]
		[Range(0f, 1f)]
		public float m_rayThickness = 0.01f;

		[Header("TEMPORAL SETTINGS")]
		[Tooltip("Enable this option if you use temporal anti-aliasing in your project. Works better when Dithering is enabled.")]
		public bool m_Temporal;

		[Range(0f, 1f)]
		public float m_JitterScale = 0.5f;

		private int m_temporalJitter;

		private int _iterations = 1;

		private int _downGrade = 1;

		private int _width;

		private int _height;

		private int _eyes = 1;

		private RenderingPath _currentRenderingPath;

		private CommandBuffer computeShadowsCB;

		private CommandBuffer applyShadows;

		private NGSS_IExternalEnvironmentProvider provider;

		private bool _isInit;

		private bool _preRenderHooked;

		private Camera _mCamera;

		private Material _mMaterial;

		private Material _shadowApplyMaterial;

		private Mesh _fullScreenTriangle;

		private Material mMaterial
		{
			get
			{
				if (_mMaterial == null)
				{
					if (frustumShadowsShader == null)
					{
						frustumShadowsShader = Shader.Find("Hidden/NGSS_FrustumShadows");
					}
					_mMaterial = new Material(frustumShadowsShader);
					if (_mMaterial == null)
					{
						Debug.LogWarning("NGSS Warning: can't find NGSS_FrustumShadows shader, make sure it's on your project.", this);
						base.enabled = false;
					}
				}
				return _mMaterial;
			}
			set
			{
				_mMaterial = value;
			}
		}

		private Material shadowApplyMaterial
		{
			get
			{
				if (_shadowApplyMaterial == null)
				{
					if (shadowApplyShader == null)
					{
						shadowApplyShader = Shader.Find("Hidden/NGSS_FrustumShadowsApply");
					}
					_shadowApplyMaterial = new Material(shadowApplyShader);
					if (_shadowApplyMaterial == null)
					{
						Debug.LogWarning("NGSS Warning: can't find NGSS_FrustumShadowsApply shader, make sure it's on your project.", this);
						base.enabled = false;
					}
				}
				return _shadowApplyMaterial;
			}
			set
			{
				_mMaterial = value;
			}
		}

		private Mesh FullScreenTriangle
		{
			get
			{
				if ((bool)_fullScreenTriangle)
				{
					return _fullScreenTriangle;
				}
				_fullScreenTriangle = new Mesh
				{
					name = "Full-Screen Triangle",
					vertices = new Vector3[3]
					{
						new Vector3(-1f, -1f, 0f),
						new Vector3(-1f, 3f, 0f),
						new Vector3(3f, -1f, 0f)
					},
					triangles = new int[3] { 0, 1, 2 }
				};
				_fullScreenTriangle.UploadMeshData(markNoLongerReadable: true);
				return _fullScreenTriangle;
			}
		}

		public static event Action<NGSS_FrustumShadows> InstanceCreated;

		private bool IsNotSupported()
		{
			return SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES2;
		}

		private void Awake()
		{
			if ((bool)instance)
			{
				Debug.LogError("There are multiple instances of NGSS_FrustumShadows, there should be only one, investigate this", instance);
			}
			instance = this;
			NGSS_FrustumShadows.InstanceCreated?.Invoke(this);
		}

		private void AddCommandBuffers()
		{
			if (computeShadowsCB == null)
			{
				computeShadowsCB = new CommandBuffer
				{
					name = "NGSS FrustumShadows: Compute"
				};
			}
			else
			{
				computeShadowsCB.Clear();
			}
			bool flag = true;
			CommandBuffer[] commandBuffers;
			if ((bool)_mCamera)
			{
				commandBuffers = _mCamera.GetCommandBuffers((_mCamera.actualRenderingPath != RenderingPath.DeferredShading) ? CameraEvent.AfterDepthTexture : CameraEvent.BeforeLighting);
				for (int i = 0; i < commandBuffers.Length; i++)
				{
					if (!(commandBuffers[i].name != computeShadowsCB.name))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					_mCamera.AddCommandBuffer((_mCamera.actualRenderingPath != RenderingPath.DeferredShading) ? CameraEvent.AfterDepthTexture : CameraEvent.BeforeLighting, computeShadowsCB);
				}
			}
			flag = true;
			if (applyShadows == null)
			{
				applyShadows = new CommandBuffer
				{
					name = "NGSS FrustumShadows: Apply"
				};
			}
			else
			{
				applyShadows.Clear();
			}
			if (!mainShadowsLight)
			{
				return;
			}
			commandBuffers = mainShadowsLight.GetCommandBuffers(LightEvent.AfterScreenspaceMask);
			for (int i = 0; i < commandBuffers.Length; i++)
			{
				if (!(commandBuffers[i].name != applyShadows.name))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				mainShadowsLight.AddCommandBuffer(LightEvent.AfterScreenspaceMask, applyShadows);
			}
		}

		private void RemoveCommandBuffers()
		{
			_mMaterial = null;
			if ((bool)_mCamera)
			{
				_mCamera.RemoveCommandBuffer(CameraEvent.BeforeLighting, computeShadowsCB);
				_mCamera.RemoveCommandBuffer(CameraEvent.AfterDepthTexture, computeShadowsCB);
			}
			if ((bool)mainShadowsLight)
			{
				mainShadowsLight.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, applyShadows);
			}
			_isInit = false;
		}

		private void Init()
		{
			if (_mCamera == null || _mCamera.cameraType != CameraType.Game)
			{
				return;
			}
			int num = (XRSettings.enabled ? XRSettings.eyeTextureWidth : _mCamera.scaledPixelWidth);
			int num2 = (XRSettings.enabled ? XRSettings.eyeTextureHeight : _mCamera.scaledPixelHeight);
			m_shadowsBlurIterations = (m_fastBlur ? 1 : m_shadowsBlurIterations);
			if (_iterations == m_shadowsBlurIterations && _downGrade == m_shadowsDownGrade && _width == num && _height == num2 && (_isInit || mainShadowsLight == null))
			{
				return;
			}
			if (_mCamera.actualRenderingPath == RenderingPath.VertexLit)
			{
				Debug.LogWarning("Vertex Lit Rendering Path is not supported by NGSS Contact Shadows. Please set the Rendering Path in your game camera or Graphics Settings to something else than Vertex Lit.", this);
				base.enabled = false;
				return;
			}
			if (_mCamera.actualRenderingPath == RenderingPath.Forward)
			{
				_mCamera.depthTextureMode |= DepthTextureMode.Depth;
			}
			AddCommandBuffers();
			_width = num;
			_height = num2;
			_downGrade = m_shadowsDownGrade;
			_eyes = ((provider == null || !provider.IsVREnabled()) ? 1 : 2);
			int num3 = Shader.PropertyToID("NGSS_ContactShadowRT1");
			int num4 = Shader.PropertyToID("NGSS_ContactShadowRT2");
			computeShadowsCB.GetTemporaryRT(num3, num / _downGrade * _eyes, num2 / _downGrade, 0, FilterMode.Bilinear, RenderTextureFormat.RG16);
			computeShadowsCB.GetTemporaryRT(num4, num / _downGrade * _eyes, num2 / _downGrade, 0, FilterMode.Bilinear, RenderTextureFormat.RG16);
			computeShadowsCB.Blit(null, num3, mMaterial, 0);
			_iterations = m_shadowsBlurIterations;
			for (int i = 1; i <= _iterations; i++)
			{
				computeShadowsCB.SetGlobalVector("ShadowsKernel", new Vector2(0f, i));
				computeShadowsCB.Blit(num3, num4, mMaterial, 1);
				computeShadowsCB.SetGlobalVector("ShadowsKernel", new Vector2(i, 0f));
				computeShadowsCB.Blit(num4, num3, mMaterial, 1);
			}
			computeShadowsCB.SetGlobalTexture("NGSS_FrustumShadowsTexture", num3);
			computeShadowsCB.ReleaseTemporaryRT(num3);
			computeShadowsCB.ReleaseTemporaryRT(num4);
			applyShadows.SetRenderTarget(BuiltinRenderTextureType.CurrentActive);
			if (provider != null)
			{
				provider.RenderFullscreenEffect(applyShadows, _mCamera, shadowApplyMaterial, mainShadowsLight, 0);
			}
			_isInit = true;
		}

		public void SetProvider(NGSS_IExternalEnvironmentProvider newProvider)
		{
			provider = newProvider;
		}

		private void OnEnable()
		{
			if (IsNotSupported())
			{
				Debug.LogWarning("Unsupported graphics API, NGSS requires at least SM3.0 or higher and DX9 is not supported.", this);
				base.enabled = false;
				return;
			}
			Init();
			if (!_preRenderHooked)
			{
				_preRenderHooked = true;
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(PreRender));
			}
		}

		private void OnDisable()
		{
			Shader.SetGlobalFloat("NGSS_FRUSTUM_SHADOWS_ENABLED", 0f);
			if (_isInit)
			{
				RemoveCommandBuffers();
			}
			if (mMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(mMaterial);
				mMaterial = null;
			}
			if (shadowApplyMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(shadowApplyMaterial);
				shadowApplyMaterial = null;
			}
			if (_preRenderHooked)
			{
				_preRenderHooked = false;
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(PreRender));
			}
		}

		private void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
				NGSS_FrustumShadows.InstanceCreated = null;
			}
		}

		private void OnApplicationQuit()
		{
			if (_isInit)
			{
				RemoveCommandBuffers();
			}
		}

		private static bool IsCameraValid(Camera cam)
		{
			if (cam.cameraType != CameraType.Game)
			{
				return false;
			}
			if (cam.actualRenderingPath != RenderingPath.DeferredShading)
			{
				return false;
			}
			return true;
		}

		private void PreRender(Camera cam)
		{
			if (!IsCameraValid(cam))
			{
				Shader.SetGlobalFloat("NGSS_FRUSTUM_SHADOWS_OPACITY", 1f);
				return;
			}
			Init();
			if (_mCamera != cam)
			{
				OnDisable();
				_mCamera = cam;
				OnEnable();
			}
			if (_isInit && !(mainShadowsLight == null) && !(_mCamera == null))
			{
				if (_currentRenderingPath != _mCamera.actualRenderingPath)
				{
					_currentRenderingPath = _mCamera.actualRenderingPath;
					RemoveCommandBuffers();
					AddCommandBuffers();
				}
				Shader.SetGlobalFloat("NGSS_FRUSTUM_SHADOWS_ENABLED", 1f);
				Shader.SetGlobalFloat("NGSS_FRUSTUM_SHADOWS_OPACITY", 1f - mainShadowsLight.shadowStrength);
				if (m_Temporal)
				{
					m_temporalJitter = (m_temporalJitter + 1) % 8;
					mMaterial.SetFloat("TemporalJitter", (float)m_temporalJitter * m_JitterScale * 0.0002f);
				}
				else
				{
					mMaterial.SetFloat("TemporalJitter", 0f);
				}
				if (QualitySettings.shadowProjection == ShadowProjection.StableFit)
				{
					mMaterial.EnableKeyword("SHADOWS_SPLIT_SPHERES");
				}
				else
				{
					mMaterial.DisableKeyword("SHADOWS_SPLIT_SPHERES");
				}
				mMaterial.SetMatrix("WorldToView", _mCamera.worldToCameraMatrix);
				mMaterial.SetVector("LightDir", _mCamera.transform.InverseTransformDirection(-mainShadowsLight.transform.forward));
				mMaterial.SetVector("LightPosRange", new Vector4(mainShadowsLight.transform.position.x, mainShadowsLight.transform.position.y, mainShadowsLight.transform.position.z, mainShadowsLight.range * mainShadowsLight.range));
				mMaterial.SetVector("LightDirWorld", -mainShadowsLight.transform.forward);
				mMaterial.SetFloat("ShadowsEdgeTolerance", m_shadowsEdgeBlur);
				mMaterial.SetFloat("ShadowsSoftness", m_shadowsBlur);
				mMaterial.SetFloat("RayScale", m_rayScale);
				mMaterial.SetFloat("ShadowsBias", m_shadowsBias * 0.02f);
				mMaterial.SetFloat("ShadowsDistanceStart", m_shadowsDistanceStart - 10f);
				mMaterial.SetFloat("RayThickness", m_rayThickness);
				mMaterial.SetFloat("RaySamples", m_raySamples);
				if (m_deferredBackfaceOptimization && _mCamera.actualRenderingPath == RenderingPath.DeferredShading)
				{
					mMaterial.EnableKeyword("NGSS_DEFERRED_OPTIMIZATION");
					mMaterial.SetFloat("BackfaceOpacity", m_deferredBackfaceTranslucency);
				}
				else
				{
					mMaterial.DisableKeyword("NGSS_DEFERRED_OPTIMIZATION");
				}
				if (m_dithering)
				{
					mMaterial.EnableKeyword("NGSS_USE_DITHERING");
				}
				else
				{
					mMaterial.DisableKeyword("NGSS_USE_DITHERING");
				}
				if (m_fastBlur)
				{
					mMaterial.EnableKeyword("NGSS_FAST_BLUR");
				}
				else
				{
					mMaterial.DisableKeyword("NGSS_FAST_BLUR");
				}
				if (mainShadowsLight.type != LightType.Directional)
				{
					mMaterial.EnableKeyword("NGSS_USE_LOCAL_SHADOWS");
				}
				else
				{
					mMaterial.DisableKeyword("NGSS_USE_LOCAL_SHADOWS");
				}
				mMaterial.SetFloat("RayScreenScale", m_rayScreenScale ? 1f : 0f);
				applyShadows.Clear();
				applyShadows.SetRenderTarget(BuiltinRenderTextureType.CurrentActive);
				if (provider != null)
				{
					provider.RenderFullscreenEffect(applyShadows, _mCamera, shadowApplyMaterial, mainShadowsLight, 0);
				}
			}
		}

		private void BlitXR(CommandBuffer cmd, RenderTargetIdentifier src, RenderTargetIdentifier dest, Material mat, int pass)
		{
			cmd.SetRenderTarget(dest, 0, CubemapFace.Unknown, -1);
			cmd.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			cmd.DrawMesh(FullScreenTriangle, Matrix4x4.identity, mat, pass);
		}
	}
}
