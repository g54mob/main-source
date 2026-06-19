using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pug.RP
{
	[RequireComponent(typeof(Camera))]
	public class PugCamera : MonoBehaviour
	{
		[SerializeField]
		private OutputMode m_outputMode;

		public bool integerScaling;

		[FormerlySerializedAs("outputSmoothing")]
		public bool preventPixelCrawl;

		[Range(-1f, 1f)]
		public float texelSnapOffset = 0.25f;

		public bool subPixelMovement = true;

		[SerializeField]
		[Min(1f)]
		private int m_outputWidth = 480;

		[SerializeField]
		[Min(1f)]
		private int m_outputHeight = 270;

		[SerializeField]
		[Min(0f)]
		private int m_minOutputWidth = 360;

		[SerializeField]
		[Min(0f)]
		private int m_maxOutputWidth = 630;

		public bool outputSkew;

		[Range(0f, 90f)]
		public float outputSkewAngle = 45f;

		public bool enableDeferredPass;

		public bool unlitDeferredPass;

		public bool enableAnalyticNormalEdges;

		public bool enableOutlines;

		public OutlineSettings outlineSettings = OutlineSettings.baseSettings;

		public bool enableOpaqueTexture;

		[Range(0f, 2f)]
		public float ditherOutput;

		public Color fadeColor = Color.clear;

		[Min(0f)]
		public float outputExposure = 1f;

		[Min(0f)]
		public float outputGamma = 1f;

		public bool outputLimitColorBitDepth;

		[Range(1f, 8f)]
		public int outputColorBitDepth = 8;

		public Texture outputColorLookup;

		public Texture outputColorLookup2;

		public bool bloom;

		[Min(0f)]
		public float bloomThreshold = 1f;

		[Min(0f)]
		public float bloomIntensity = 1f;

		[Range(1f, 10f)]
		public float bloomWidth = 5f;

		[Range(0f, 1f)]
		public float bloomBlend = 1f;

		public VolumetricLightingType volumetricLight;

		public Transform volumetricLightAnchor;

		public Vector3 volumetricLightSize = new Vector3(32f, 32f, 10f);

		public float volumetricLightPPU = 16f;

		[Min(1f)]
		public int volumetricLightDepthSlices = 4;

		[Range(0f, 8f)]
		public float volumetricLightBlur = 3f;

		[Range(0f, 1f)]
		public float volumetricLightBlurBlend;

		[Range(0f, 1f)]
		public float volumetricLightDepthBias;

		public IndirectLightingType indirectLight;

		public IndirectLighting2DGatherMethod indirectLighting2DGatherMethod = IndirectLighting2DGatherMethod.MultiResolution;

		public IndirectLightingGatherMode indirectLightingGatherMode;

		public bool indirectLightHighPrecision;

		public LayerMask indirectLightLayers = -1;

		public bool indirectLightSeparateBlockerPass;

		[Min(0f)]
		public float indirectLightEdgeRadiance;

		public LayerMask indirectLightSeparateBlockerPassLayers = 0;

		public Transform indirectLightAnchor;

		public Vector2 indirectLightSize = new Vector2(100f, 100f);

		public Vector2Int indirectLightResolution = new Vector2Int(512, 512);

		[Min(0f)]
		public float indirectLightDepth = 10f;

		[Min(0f)]
		public float indirectLightThreshold = 1f;

		[Range(1f, 16f)]
		public float indirectLightSpread = 3f;

		[Range(4f, 64f)]
		[FormerlySerializedAs("indirectLightSampleCount")]
		public int indirectLightRayCount = 8;

		[Range(1f, 2f)]
		public float indirectLightRayCountExponent = 1.5f;

		[Range(1f, 8f)]
		[FormerlySerializedAs("indirectLightPasses")]
		public int indirectLightSamplesPerPass = 4;

		[Range(1f, 8f)]
		public int indirectLightPassCount = 5;

		[Range(1f, 8f)]
		public int indirectLightRadianceCascadeCount = 5;

		[Range(0f, 1f)]
		public float indirectLightDirectionality = 0.75f;

		[Range(0f, 8f)]
		public int indirectLightInputBlur;

		[Range(0f, 7f)]
		public int indirectLightSkipPasses = 2;

		[Range(1f, 4f)]
		public int indirectLightBounceCount = 2;

		[Range(0f, 1f)]
		public float indirectLightFeedback;

		[Range(0f, 1f)]
		public float indirectLightBlockerThreshold = 0.5f;

		[Range(0f, 1f)]
		public float indirectLightLeakPrevention = 0.5f;

		[Min(0f)]
		public float indirectLightUpscaling = 4f;

		[FormerlySerializedAs("indirectLightHighQualityUpscaling")]
		public bool indirectLightHighQualityUpsampling = true;

		[Range(0f, 8f)]
		public int indirectLightBilateralBlur = 2;

		[Range(0f, 4f)]
		public float indirectLightBlur;

		[Range(0f, 1f)]
		public float indirectLightLimit;

		[Range(0f, 1f)]
		public float indirectLightBoost = 0.5f;

		[Range(0f, 1f)]
		public float indirectLightBoostLimit = 0.5f;

		[Min(0f)]
		public float indirectLightNormalBias = 1f;

		public bool lightTracing;

		[Range(8f, 64f)]
		public int lightTracingMaxSampleCount = 32;

		public bool lightTracingShadows;

		[Range(0f, 16f)]
		public int lightTracingShadowBlur;

		[Range(0f, 1f)]
		public float lightTracingShadowSharpen = 0.5f;

		public LayerMask lightTracingShadowLayers = -1;

		public bool lightTracingOcclusion;

		[Range(1f, 16f)]
		public int lightTracingOcclusionBlur = 4;

		[Range(0f, 1f)]
		public float lightTracingOcclusionStrength = 0.7f;

		public bool lightTracingTransmittance;

		public LayerMask lightTracingTransmittanceLayers = -1;

		[FormerlySerializedAs("ssaoEnabled")]
		public bool enableSSAO;

		public SSAOSettings ssaoSettings;

		public ReflectionsType reflections;

		public LayerMask reflectionsLayers = -1;

		public Transform reflectionsPlanarAnchor;

		public float reflectionsPlanarOffset;

		public bool tonemap;

		public TonemapMode tonemapMode;

		[Range(0f, 1f)]
		public float tonemapThreshold = 0.5f;

		[Range(0f, 1f)]
		public float tonemapWhiteout = 0.5f;

		[Min(0f)]
		public float tonemapWhiteoutThreshold = 0.5f;

		[Range(0f, 1f)]
		public float tonemapWeight = 0.5f;

		[Min(0f)]
		public float tonemapGamma = 1f;

		[Min(0f)]
		public float tonemapBrightness = 1f;

		public CRTFilterSettings crtFilterSettings = CRTFilterSettings.baseSettings;

		private Camera m_camera;

		private PugRPPerformanceOverlay m_perfOverlay;

		private static bool s_displayPerfInfo;

		private float m_perfInfoHoldtime = -1f;

		private bool m_perfInfoHeld;

		public Camera camera => m_camera;

		[Obsolete("Use preventPixelCrawl instead.")]
		public bool outputSmoothing
		{
			get
			{
				return preventPixelCrawl;
			}
			set
			{
				preventPixelCrawl = value;
			}
		}

		public int outputWidth
		{
			get
			{
				return m_outputWidth;
			}
			set
			{
				m_outputWidth = value;
			}
		}

		public int outputHeight
		{
			get
			{
				return m_outputHeight;
			}
			set
			{
				m_outputHeight = value;
			}
		}

		public int minOutputWidth
		{
			get
			{
				return m_minOutputWidth;
			}
			set
			{
				m_minOutputWidth = value;
			}
		}

		public int maxOutputWidth
		{
			get
			{
				return m_maxOutputWidth;
			}
			set
			{
				m_maxOutputWidth = value;
			}
		}

		public OutputMode GetOutputMode(Camera srcCamera = null)
		{
			if (srcCamera == null)
			{
				srcCamera = m_camera;
			}
			if (srcCamera != null && srcCamera.cameraType == CameraType.Game)
			{
				return m_outputMode;
			}
			return OutputMode.Native;
		}

		public void SetPreferredOutputMode(OutputMode mode)
		{
			m_outputMode = mode;
		}

		public int GetPixelWidth(Camera srcCamera = null)
		{
			if (srcCamera == null)
			{
				srcCamera = m_camera;
			}
			switch (GetOutputMode(srcCamera))
			{
			default:
				return srcCamera.pixelWidth;
			case OutputMode.MatchAspect:
			{
				int num = Mathf.Clamp(Mathf.CeilToInt(srcCamera.pixelRect.width / srcCamera.pixelRect.height * (float)m_outputHeight), m_minOutputWidth, m_maxOutputWidth);
				if (num % 2 != 0)
				{
					return num + 1;
				}
				return num;
			}
			case OutputMode.Fixed:
				return m_outputWidth;
			}
		}

		public int GetPixelHeight(Camera srcCamera = null)
		{
			if (srcCamera == null)
			{
				srcCamera = m_camera;
			}
			OutputMode outputMode = GetOutputMode(srcCamera);
			if (outputMode == OutputMode.Native || (uint)(outputMode - 1) > 1u)
			{
				return srcCamera.pixelHeight;
			}
			return m_outputHeight;
		}

		public Vector2Int GetIndirectLightSnapResolution()
		{
			return indirectLightResolution / (int)Mathf.Pow(2f, indirectLightPassCount);
		}

		public float GetIndirectLightTexelSize()
		{
			return indirectLightSize.x / (float)indirectLightResolution.x;
		}

		public int GetMaxIndirectLightSkipPasses()
		{
			return Mathf.Min(indirectLightSkipPasses, indirectLightPassCount - 1);
		}

		public int GetIntegerScale()
		{
			int a = Mathf.FloorToInt(camera.pixelRect.width / (float)GetPixelWidth(camera));
			int b = Mathf.FloorToInt(camera.pixelRect.height / (float)GetPixelHeight(camera));
			return Mathf.Min(a, b);
		}

		public bool TryGetIntegerWidthAndHeight(out int integerWidth, out int integerHeight)
		{
			if (!integerScaling)
			{
				integerWidth = -1;
				integerHeight = -1;
				return false;
			}
			int integerScale = GetIntegerScale();
			integerWidth = GetPixelWidth(camera) * integerScale;
			integerHeight = GetPixelHeight(camera) * integerScale;
			return integerScale > 0;
		}

		public Vector2 TransformMousePosition(Vector2 mousePosition)
		{
			int pixelWidth = GetPixelWidth();
			int pixelHeight = GetPixelHeight();
			float num = (float)Screen.width / (float)Screen.height;
			float num2 = (float)pixelWidth / (float)pixelHeight;
			Vector2 vector = new Vector2((mousePosition.x - (float)(Screen.width / 2)) / (float)Screen.width, (mousePosition.y - (float)(Screen.height / 2)) / (float)Screen.height);
			if (TryGetIntegerWidthAndHeight(out var integerWidth, out var integerHeight))
			{
				vector.x *= (float)Screen.width / (float)integerWidth;
				vector.y *= (float)Screen.height / (float)integerHeight;
			}
			else if (num > num2)
			{
				vector.x *= num / num2;
			}
			else if (num2 > num)
			{
				vector.y *= num2 / num;
			}
			mousePosition = new Vector2(vector.x * (float)pixelWidth, vector.y * (float)pixelHeight);
			return mousePosition;
		}

		internal void SetCamera(Camera camera)
		{
			m_camera = camera;
		}

		private void OnEnable()
		{
			m_camera = GetComponent<Camera>();
		}

		private void OnValidate()
		{
			indirectLightResolution = Vector2Int.Max(new Vector2Int(16, 16), Vector2Int.Min(indirectLightResolution, Vector2Int.one * 1024));
			if (indirectLightRayCount % 2 != 0)
			{
				indirectLightRayCount++;
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (volumetricLight == VolumetricLightingType._3DBuffer && volumetricLightAnchor != null)
			{
				for (int i = 0; i < volumetricLightDepthSlices; i++)
				{
					float num = ((float)i + 0.5f) / (float)volumetricLightDepthSlices;
					Gizmos.matrix = Matrix4x4.TRS(volumetricLightAnchor.position + volumetricLightAnchor.forward * volumetricLightSize.z * (num - 0.5f), volumetricLightAnchor.rotation, Vector3.one);
					Gizmos.color = new Color(0f, 1f, 1f, 0.1f);
					Gizmos.DrawCube(Vector3.zero, new Vector3(volumetricLightSize.x, volumetricLightSize.y, 0f));
					Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
					Gizmos.DrawWireCube(Vector3.zero, new Vector3(volumetricLightSize.x, volumetricLightSize.y, 0f));
				}
			}
			if (indirectLight == IndirectLightingType._2DBuffer && indirectLightAnchor != null)
			{
				Gizmos.matrix = Matrix4x4.TRS(indirectLightAnchor.position, indirectLightAnchor.rotation, Vector3.one);
				Gizmos.color = Color.white;
				Gizmos.DrawWireCube(Vector3.zero, indirectLightSize);
				Gizmos.color = new Color(1f, 1f, 0f, 0.1f);
				Gizmos.DrawWireCube(Vector3.zero, new Vector3(indirectLightSize.x, indirectLightSize.y, indirectLightDepth));
				Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
				Gizmos.DrawCube(-Vector3.forward * indirectLightThreshold, indirectLightSize);
			}
		}

		private void OnDrawGizmos()
		{
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F9))
			{
				if (m_perfInfoHoldtime < 0f)
				{
					m_perfInfoHoldtime = Time.unscaledTime;
					m_perfInfoHeld = false;
				}
				else if (Time.unscaledTime - m_perfInfoHoldtime > 1f && !m_perfInfoHeld)
				{
					if (m_perfOverlay == null)
					{
						m_perfOverlay = base.gameObject.AddComponent<PugRPPerformanceOverlay>();
					}
					else
					{
						m_perfOverlay.enabled = !m_perfOverlay.enabled;
					}
					s_displayPerfInfo = !s_displayPerfInfo;
					m_perfInfoHeld = true;
					Shadows.debugDirtyAreas = !Shadows.debugDirtyAreas;
				}
			}
			else
			{
				m_perfInfoHoldtime = -1f;
			}
		}
	}
}
