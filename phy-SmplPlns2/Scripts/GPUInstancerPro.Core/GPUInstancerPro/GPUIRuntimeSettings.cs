using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

namespace GPUInstancerPro
{
	public class GPUIRuntimeSettings : ScriptableObject
	{
		[SerializeField]
		public GPUICameraLoadingType cameraLoadingType;

		[SerializeField]
		public GPUIOcclusionCullingCondition occlusionCullingCondition;

		[SerializeField]
		public GPUIOcclusionCullingData.GPUIOcclusionCullingMode occlusionCullingMode;

		[SerializeField]
		public Vector3 instancingBoundsSize = new Vector3(1000f, 1000f, 1000f);

		[SerializeField]
		public float defaultHDRPShadowDistance = 250f;

		[SerializeField]
		public List<GPUIBillboard> billboardAssets;

		private static GPUIRuntimeSettings _instance;

		public GraphicsDeviceType GraphicsDeviceType { get; private set; }

		public GPUIRenderPipeline RenderPipeline { get; private set; }

		public GPUIMaxComputeWorkGroupSize ComputeWorkGroupSize { get; private set; }

		public float ComputeThreadCount { get; private set; }

		public float ComputeThreadCountHeavy { get; private set; }

		public float ComputeThreadCount2D { get; private set; }

		public float ComputeThreadCount3D { get; private set; }

		public int TextureMaxSize { get; private set; }

		public bool DisableShaderBuffers { get; private set; }

		public bool DisableOcclusionCulling { get; private set; }

		public bool DisablePreviousFrameTransformBuffer { get; private set; }

		public bool DisablePerInstanceLightProbesBuffer { get; private set; }

		public long MaxBufferSize { get; private set; }

		public bool ReversedZBuffer { get; private set; }

		public bool API_HAS_GUARANTEED_R8_SUPPORT { get; private set; }

		public bool IsVREnabled { get; private set; }

		public bool Unsupported_Unity_Version { get; private set; }

		public static GPUIRuntimeSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = GetDefaultGPUIRuntimeSettings();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public bool IsHDRP => RenderPipeline == GPUIRenderPipeline.HDRP;

		public bool IsURP => RenderPipeline == GPUIRenderPipeline.URP;

		public bool IsBuiltInRP => RenderPipeline == GPUIRenderPipeline.BuiltIn;

		private static GPUIRuntimeSettings GetDefaultGPUIRuntimeSettings()
		{
			GPUIRuntimeSettings gPUIRuntimeSettings = null;
			GPUIRuntimeSettingsOverwrite gPUIRuntimeSettingsOverwrite = Object.FindFirstObjectByType<GPUIRuntimeSettingsOverwrite>();
			if (gPUIRuntimeSettingsOverwrite != null && gPUIRuntimeSettingsOverwrite.runtimeSettingsOverwrite != null)
			{
				gPUIRuntimeSettings = gPUIRuntimeSettingsOverwrite.runtimeSettingsOverwrite;
				gPUIRuntimeSettings.DetermineOperationMode();
			}
			if (gPUIRuntimeSettings == null)
			{
				gPUIRuntimeSettings = ScriptableObject.CreateInstance<GPUIRuntimeSettings>();
				gPUIRuntimeSettings.DetermineOperationMode();
				gPUIRuntimeSettings.SetDefaultValues();
			}
			return gPUIRuntimeSettings;
		}

		internal static void OverwriteSettings(GPUIRuntimeSettings overwriteSettings)
		{
			overwriteSettings.DetermineOperationMode();
			_instance = overwriteSettings;
		}

		public void DetermineRenderPipeline()
		{
			RenderPipeline = GPUIRenderPipeline.BuiltIn;
			if (TryGetURPAsset(out var _))
			{
				RenderPipeline = GPUIRenderPipeline.URP;
			}
		}

		public void DetermineOperationMode()
		{
			DetermineRenderPipeline();
			GraphicsDeviceType = SystemInfo.graphicsDeviceType;
			int maxComputeBufferInputsFragment = SystemInfo.maxComputeBufferInputsFragment;
			DisableShaderBuffers = !IsSafeAssumeMaxComputeBufferInputsFragmentGt2(Application.platform) && maxComputeBufferInputsFragment < 2;
			DisablePreviousFrameTransformBuffer = maxComputeBufferInputsFragment < 4;
			DisablePerInstanceLightProbesBuffer = maxComputeBufferInputsFragment < 4;
			if (DisableShaderBuffers)
			{
				Shader.EnableKeyword("GPUI_NO_BUFFER");
			}
			else
			{
				Shader.DisableKeyword("GPUI_NO_BUFFER");
			}
			GraphicsDeviceType graphicsDeviceType;
			if (DisableShaderBuffers)
			{
				graphicsDeviceType = GraphicsDeviceType;
				DisableOcclusionCulling = graphicsDeviceType != GraphicsDeviceType.OpenGLES3 && graphicsDeviceType != GraphicsDeviceType.Vulkan;
			}
			else
			{
				DisableOcclusionCulling = false;
			}
			graphicsDeviceType = GraphicsDeviceType;
			API_HAS_GUARANTEED_R8_SUPPORT = graphicsDeviceType != GraphicsDeviceType.OpenGLES3 && graphicsDeviceType != GraphicsDeviceType.Vulkan;
			int maxComputeWorkGroupSize = SystemInfo.maxComputeWorkGroupSize;
			if (maxComputeWorkGroupSize >= 512)
			{
				ComputeWorkGroupSize = GPUIMaxComputeWorkGroupSize.x512;
				ComputeThreadCount = 512f;
				ComputeThreadCount2D = 16f;
				ComputeThreadCount3D = 8f;
				ComputeThreadCountHeavy = 256f;
				Shader.EnableKeyword("GPUI_THREAD_SIZE_512");
				Shader.EnableKeyword("GPUI_THREAD_SIZE_HEAVY_256");
				Shader.DisableKeyword("GPUI_THREAD_SIZE_256");
			}
			else if (maxComputeWorkGroupSize >= 256)
			{
				ComputeWorkGroupSize = GPUIMaxComputeWorkGroupSize.x256;
				ComputeThreadCount = 256f;
				ComputeThreadCount2D = 16f;
				ComputeThreadCount3D = 4f;
				ComputeThreadCountHeavy = 256f;
				Shader.DisableKeyword("GPUI_THREAD_SIZE_512");
				Shader.EnableKeyword("GPUI_THREAD_SIZE_HEAVY_256");
				Shader.EnableKeyword("GPUI_THREAD_SIZE_256");
			}
			else
			{
				if (maxComputeWorkGroupSize < 64)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Max. Compute Work Group Size is: " + maxComputeWorkGroupSize + ". GPUI requires minimum work group size of 64.");
				}
				ComputeWorkGroupSize = GPUIMaxComputeWorkGroupSize.x64;
				ComputeThreadCount = 64f;
				ComputeThreadCount2D = 8f;
				ComputeThreadCount3D = 4f;
				ComputeThreadCountHeavy = 64f;
				Shader.DisableKeyword("GPUI_THREAD_SIZE_512");
				Shader.DisableKeyword("GPUI_THREAD_SIZE_HEAVY_256");
				Shader.DisableKeyword("GPUI_THREAD_SIZE_256");
			}
			TextureMaxSize = SystemInfo.maxTextureSize;
			ClearEmptyBillboardAssets();
			MaxBufferSize = SystemInfo.maxGraphicsBufferSize / 64;
			graphicsDeviceType = SystemInfo.graphicsDeviceType;
			ReversedZBuffer = graphicsDeviceType == GraphicsDeviceType.OpenGLCore || graphicsDeviceType == GraphicsDeviceType.OpenGLES3;
			GPUIConstants.CS_THREAD_COUNT = ComputeThreadCount;
			GPUIConstants.CS_THREAD_COUNT_HEAVY = ComputeThreadCountHeavy;
			GPUIConstants.CS_THREAD_COUNT_2D = ComputeThreadCount2D;
			GPUIConstants.CS_THREAD_COUNT_3D = ComputeThreadCount3D;
			GPUIConstants.TEXTURE_MAX_SIZE = TextureMaxSize;
			GPUIConstants.MAX_BUFFER_SIZE = MaxBufferSize;
		}

		public static bool IsSafeAssumeMaxComputeBufferInputsFragmentGt2(RuntimePlatform platform)
		{
			switch (platform)
			{
			case RuntimePlatform.OSXEditor:
			case RuntimePlatform.OSXPlayer:
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.WindowsEditor:
			case RuntimePlatform.LinuxPlayer:
			case RuntimePlatform.LinuxEditor:
			case RuntimePlatform.PS4:
			case RuntimePlatform.XboxOne:
			case RuntimePlatform.GameCoreXboxSeries:
			case RuntimePlatform.GameCoreXboxOne:
			case RuntimePlatform.PS5:
				return true;
			default:
				return false;
			}
		}

		public void SetDefaultValues()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer || platform == RuntimePlatform.Switch || platform == RuntimePlatform.WebGLPlayer)
			{
				occlusionCullingCondition = GPUIOcclusionCullingCondition.IfDepthAvailable;
			}
			else
			{
				occlusionCullingCondition = GPUIOcclusionCullingCondition.Always;
			}
		}

		public void ClearEmptyBillboardAssets()
		{
			if (billboardAssets == null)
			{
				billboardAssets = new List<GPUIBillboard>();
			}
			for (int i = 0; i < billboardAssets.Count; i++)
			{
				if (billboardAssets[i] == null)
				{
					billboardAssets.RemoveAt(i);
					i--;
				}
			}
		}

		public void SetRuntimeSettings()
		{
			IsVREnabled = XRSettings.enabled;
			DetermineRenderPipeline();
		}

		public bool IsSupportedPlatform()
		{
			if (!SystemInfo.supportsInstancing)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Current platform does not support GPU instancing.");
				return false;
			}
			if (!SystemInfo.supportsComputeShaders)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Current platform does not support Compute Shaders.");
				return false;
			}
			if (SystemInfo.graphicsShaderLevel < 35)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Current platform's Graphics Shader Level is under 35. Current shader level: " + SystemInfo.graphicsShaderLevel);
				return false;
			}
			if (SystemInfo.maxComputeWorkGroupSize < 64)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Current platform's Max. Compute Work Group Size is under 64. Current Max. Compute Work Group Size: " + SystemInfo.maxComputeWorkGroupSize);
				return false;
			}
			return true;
		}

		public float GetDefaultShadowDistance()
		{
			if (RenderPipeline == GPUIRenderPipeline.URP)
			{
				if (TryGetURPAsset(out var urpAsset))
				{
					return urpAsset.shadowDistance;
				}
				return QualitySettings.shadowDistance;
			}
			return QualitySettings.shadowDistance;
		}

		public static bool TryGetRenderPipelineAsset(out RenderPipelineAsset renderPipelineAsset)
		{
			if (QualitySettings.renderPipeline != null)
			{
				renderPipelineAsset = QualitySettings.renderPipeline;
				return true;
			}
			if (GraphicsSettings.defaultRenderPipeline != null)
			{
				renderPipelineAsset = GraphicsSettings.defaultRenderPipeline;
				return true;
			}
			renderPipelineAsset = null;
			return false;
		}

		public static bool TryGetURPAsset(out UniversalRenderPipelineAsset urpAsset)
		{
			if (TryGetRenderPipelineAsset(out var renderPipelineAsset) && renderPipelineAsset is UniversalRenderPipelineAsset universalRenderPipelineAsset)
			{
				urpAsset = universalRenderPipelineAsset;
				return true;
			}
			urpAsset = null;
			return false;
		}

		public static bool IsAdaptiveProbeVolumesEnabled()
		{
			if (TryGetURPAsset(out var urpAsset))
			{
				return urpAsset.supportProbeVolume;
			}
			return false;
		}
	}
}
