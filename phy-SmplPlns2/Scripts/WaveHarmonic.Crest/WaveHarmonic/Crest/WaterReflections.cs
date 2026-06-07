using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class WaterReflections : Versioned
	{
		[Serializable]
		private sealed class DebugFields
		{
			[SerializeField]
			internal bool _ShowHiddenObjects;

			[Tooltip("Rendering reflections per-camera requires recursive rendering. Check this toggle if experiencing issues. The other downside without it is a one-frame delay.")]
			[SerializeField]
			internal bool _DisableRecursiveRendering;

			[Tooltip("Whether to create a context more compatible for planar reflections camera. Try enabling this if you are getting exceptions.")]
			[SerializeField]
			internal bool _ForceCompatibility;
		}

		private static class ShaderIDs
		{
			public static int s_ReflectionColorTexture = Shader.PropertyToID("_Crest_ReflectionColorTexture");

			public static int s_ReflectionDepthTexture = Shader.PropertyToID("_Crest_ReflectionDepthTexture");

			public static int s_ReflectionPositionNormal = Shader.PropertyToID("_Crest_ReflectionPositionNormal");

			public static readonly int s_ReflectionMatrixIVP = Shader.PropertyToID("_Crest_ReflectionMatrixIVP");

			public static readonly int s_ReflectionMatrixV = Shader.PropertyToID("_Crest_ReflectionMatrixV");

			public static readonly int s_Crest_ReflectionOverscan = Shader.PropertyToID("_Crest_ReflectionOverscan");

			public static readonly int s_PlanarReflectionsApplySmoothness = Shader.PropertyToID("_Crest_PlanarReflectionsApplySmoothness");
		}

		private sealed class CopyDepthRenderPass : ScriptableRenderPass
		{
			private class CopyPassData
			{
				public TextureHandle _Source;

				public TextureHandle _Target;

				public int _Slice;
			}

			private readonly WaterReflections _Renderer;

			private RTHandle _Wrapper;

			public CopyDepthRenderPass(WaterReflections renderer)
			{
				_Renderer = renderer;
				base.renderPassEvent = RenderPassEvent.AfterRendering;
			}

			public void Dispose()
			{
				_Wrapper?.Release();
				_Wrapper = null;
			}

			public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
			{
				TextureHandle cameraDepth = frame.Get<UniversalResourceData>().cameraDepth;
				if (!cameraDepth.IsValid())
				{
					return;
				}
				if (_Wrapper == null)
				{
					_Wrapper = RTHandles.Alloc(_Renderer._DepthTexture);
				}
				_Wrapper.SetRenderTexture(_Renderer._DepthTexture);
				graph.ImportTexture(_Wrapper);
				CopyPassData passData;
				using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = graph.AddUnsafePass<CopyPassData>("Crest.CopyDepth", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Surface\\WaterReflections.Universal.cs", 85);
				passData._Source = cameraDepth;
				passData._Target = graph.ImportTexture(_Wrapper);
				passData._Slice = _Renderer._ActiveSlice;
				unsafeRenderGraphBuilder.UseTexture(in passData._Source);
				unsafeRenderGraphBuilder.UseTexture(in passData._Target, AccessFlags.Write);
				unsafeRenderGraphBuilder.SetRenderFunc(delegate(CopyPassData data, UnsafeGraphContext context)
				{
					RTHandle rTHandle = data._Source;
					RTHandle rTHandle2 = data._Target;
					if (!(rTHandle.rt == null) && rTHandle.rt.graphicsFormat == rTHandle2.rt.graphicsFormat && rTHandle.rt.depthStencilFormat == rTHandle2.rt.depthStencilFormat)
					{
						context.cmd.m_WrappedCommandBuffer.CopyTexture(rTHandle.rt, 0, 0, rTHandle2.rt, data._Slice, 0);
					}
				});
			}
		}

		[Tooltip("Whether planar reflections are enabled.\n\nAllocates/releases resources if state has changed.")]
		[SerializeField]
		internal bool _Enabled;

		[Tooltip("What side of the water surface to render planar reflections for.")]
		[SerializeField]
		internal WaterReflectionSide _Mode = WaterReflectionSide.Above;

		[Tooltip("The layers to rendering into reflections.")]
		[SerializeField]
		private LayerMask _Layers = 1;

		[Tooltip("Resolution of the reflection texture.")]
		[SerializeField]
		private int _Resolution = 256;

		[Tooltip("Overscan amount to capture off-screen content.\n\nRenders the reflections at a larger viewport size to capture off-screen content when the surface reflects off-screen. This avoids a category of artifacts - especially when looking down. This can be expensive, as the value is a multiplier to the capture size.")]
		[SerializeField]
		private float _Overscan = 1.5f;

		[Tooltip("Whether to render the sky or fallback to default reflections.\n\nNot rendering the sky can prevent other custom shaders (like tree leaves) from being in the final output. Enable for best compatibility.")]
		[SerializeField]
		internal bool _Sky = true;

		[Tooltip("Disables pixel lights (BIRP only).")]
		[SerializeField]
		private bool _DisablePixelLights = true;

		[Tooltip("Disables shadows.")]
		[SerializeField]
		private bool _DisableShadows = true;

		[Tooltip("Whether to allow HDR.")]
		[SerializeField]
		private bool _HDR = true;

		[Tooltip("Whether to allow stencil operations.")]
		[SerializeField]
		private bool _Stencil;

		[Tooltip("Overrides global quality settings.")]
		[SerializeField]
		private QualitySettingsOverride _QualitySettingsOverride = new QualitySettingsOverride
		{
			_OverrideLodBias = false,
			_LodBias = 0.5f,
			_OverrideMaximumLodLevel = false,
			_MaximumLodLevel = 1,
			_OverrideTerrainPixelError = false,
			_TerrainPixelError = 10f
		};

		[Tooltip("The near clip plane clips any geometry before it, removing it from reflections.\n\nCan be used to reduce reflection leaks and support varied water level.")]
		[SerializeField]
		private float _ClipPlaneOffset;

		[Tooltip("Anything beyond the far clip plane is not rendered.")]
		[SerializeField]
		private float _FarClipPlane = 1000f;

		[Tooltip("Disables occlusion culling.")]
		[SerializeField]
		private bool _DisableOcclusionCulling = true;

		[Tooltip("Refresh reflection every x frames (one is every frame)")]
		[SerializeField]
		private int _RefreshPerFrames = 1;

		[SerializeField]
		private int _FrameRefreshOffset;

		[Tooltip("An oblique matrix will clip anything below the surface for free.\n\nDisable if you have problems with certain effects. Disabling can cause other artifacts like objects below the surface to appear in reflections.")]
		[SerializeField]
		private bool _UseObliqueMatrix = true;

		[Tooltip("Planar relfections using an oblique frustum for better performance.\n\nThis can cause depth issues for TIRs, especially near the surface.")]
		[SerializeField]
		private bool _NonObliqueNearSurface;

		[Tooltip("If within this distance from the surface, disable the oblique matrix.")]
		[SerializeField]
		private float _NonObliqueNearSurfaceThreshold = 0.05f;

		[Tooltip("Whether to render to the viewer camera only.\n\nWhen disabled, reflections will render for all cameras rendering the water layer, which currently this prevents Refresh Rate from working. Enabling will unlock the Refresh Rate heading.")]
		[SerializeField]
		internal bool _RenderOnlySingleCamera;

		[Tooltip("Renderer index for the reflection camera.")]
		[SerializeField]
		private int _RendererIndex;

		[SerializeField]
		private DebugFields _Debug = new DebugFields();

		internal WaterRenderer _Water;

		internal UnderwaterRenderer _UnderWater;

		private bool _ApplySmoothness;

		private RenderTexture _ColorTexture;

		private RenderTexture _DepthTexture;

		private readonly Vector4[] _ReflectionPositionNormal = new Vector4[2];

		private readonly Matrix4x4[] _ReflectionMatrixIVP = new Matrix4x4[2];

		private readonly Matrix4x4[] _ReflectionMatrixV = new Matrix4x4[2];

		internal int _ActiveSlice;

		private Camera _CameraViewpoint;

		private Skybox _CameraViewpointSkybox;

		private Camera _CameraReflections;

		private Skybox _CameraReflectionsSkybox;

		private long _LastRefreshOnFrame = -1L;

		private readonly float[] _CullDistances = new float[32];

		private Texture _CameraDepthTexture;

		private bool _UpdateCamera;

		[HideInInspector]
		[Obsolete("MSAA for the planar reflection camera is no longer supported. This setting will be ignored.")]
		[Tooltip("Whether to allow MSAA.")]
		[SerializeField]
		private bool _AllowMSAA;

		private CopyDepthRenderPass _CopyTargetsRenderPass;

		[Obsolete("MSAA for the planar reflection camera is no longer supported. This setting will be ignored.")]
		public bool AllowMSAA
		{
			get
			{
				return _AllowMSAA;
			}
			set
			{
				_AllowMSAA = value;
			}
		}

		public float ClipPlaneOffset
		{
			get
			{
				return _ClipPlaneOffset;
			}
			set
			{
				_ClipPlaneOffset = value;
			}
		}

		public bool DisableOcclusionCulling
		{
			get
			{
				return _DisableOcclusionCulling;
			}
			set
			{
				_DisableOcclusionCulling = value;
			}
		}

		public bool DisablePixelLights
		{
			get
			{
				return _DisablePixelLights;
			}
			set
			{
				_DisablePixelLights = value;
			}
		}

		public bool DisableShadows
		{
			get
			{
				return _DisableShadows;
			}
			set
			{
				SetDisableShadows(_DisableShadows, _DisableShadows = value);
			}
		}

		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				SetEnabled(_Enabled, _Enabled = value);
			}
		}

		public float FarClipPlane
		{
			get
			{
				return _FarClipPlane;
			}
			set
			{
				_FarClipPlane = value;
			}
		}

		public bool HDR
		{
			get
			{
				return _HDR;
			}
			set
			{
				_HDR = value;
			}
		}

		public LayerMask Layers
		{
			get
			{
				return _Layers;
			}
			set
			{
				_Layers = value;
			}
		}

		public WaterReflectionSide ReflectionSide
		{
			get
			{
				return _Mode;
			}
			set
			{
				SetReflectionSide(_Mode, _Mode = value);
			}
		}

		public bool NonObliqueNearSurface
		{
			get
			{
				return _NonObliqueNearSurface;
			}
			set
			{
				_NonObliqueNearSurface = value;
			}
		}

		public float NonObliqueNearSurfaceThreshold
		{
			get
			{
				return _NonObliqueNearSurfaceThreshold;
			}
			set
			{
				_NonObliqueNearSurfaceThreshold = value;
			}
		}

		public float Overscan
		{
			get
			{
				return _Overscan;
			}
			set
			{
				_Overscan = value;
			}
		}

		public QualitySettingsOverride QualitySettingsOverride
		{
			get
			{
				return _QualitySettingsOverride;
			}
			set
			{
				_QualitySettingsOverride = value;
			}
		}

		public int RendererIndex
		{
			get
			{
				return _RendererIndex;
			}
			set
			{
				SetRendererIndex(_RendererIndex, _RendererIndex = value);
			}
		}

		public bool RenderOnlySingleCamera
		{
			get
			{
				return _RenderOnlySingleCamera;
			}
			set
			{
				_RenderOnlySingleCamera = value;
			}
		}

		public int Resolution
		{
			get
			{
				return _Resolution;
			}
			set
			{
				_Resolution = value;
			}
		}

		public bool Sky
		{
			get
			{
				return _Sky;
			}
			set
			{
				_Sky = value;
			}
		}

		public bool Stencil
		{
			get
			{
				return _Stencil;
			}
			set
			{
				_Stencil = value;
			}
		}

		public bool UseObliqueMatrix
		{
			get
			{
				return _UseObliqueMatrix;
			}
			set
			{
				_UseObliqueMatrix = value;
			}
		}

		internal RenderTexture ColorTexture => _ColorTexture;

		internal RenderTexture DepthTexture => _DepthTexture;

		internal Camera ReflectionCamera => _CameraReflections;

		private int RefreshPerFrames
		{
			get
			{
				if (!_RenderOnlySingleCamera)
				{
					return 1;
				}
				return _RefreshPerFrames;
			}
		}

		internal bool SupportsRecursiveRendering
		{
			get
			{
				if (_Water.SupportsRecursiveRendering)
				{
					return !_Debug._DisableRecursiveRendering;
				}
				return false;
			}
		}

		public static Action<Camera> OnCameraAdded { get; set; }

		private bool RequireTemporaryTargets => !RenderPipelineHelper.IsUniversal;

		[Obsolete("Please use ReflectionSide instead.")]
		public WaterReflectionSide Mode
		{
			get
			{
				return _Mode;
			}
			set
			{
				_Mode = value;
			}
		}

		internal void OnEnable()
		{
			RenderPipelineManager.beginCameraRendering -= CaptureTargetDepth;
			RenderPipelineManager.beginCameraRendering += CaptureTargetDepth;
		}

		internal void OnDisable()
		{
			Shader.SetGlobalTexture(ShaderIDs.s_ReflectionColorTexture, Texture2D.blackTexture);
			Shader.SetGlobalTexture(ShaderIDs.s_ReflectionDepthTexture, Texture2D.blackTexture);
			RenderPipelineManager.beginCameraRendering -= CaptureTargetDepth;
		}

		internal void OnDestroy()
		{
			if ((bool)_CameraReflections)
			{
				Helpers.Destroy(_CameraReflections.gameObject);
				_CameraReflections = null;
			}
			if ((bool)_ColorTexture)
			{
				_ColorTexture.Release();
				Helpers.Destroy(_ColorTexture);
				_ColorTexture = null;
			}
			if ((bool)_DepthTexture)
			{
				_DepthTexture.Release();
				Helpers.Destroy(_DepthTexture);
				_DepthTexture = null;
			}
		}

		internal bool ShouldRender(Camera camera)
		{
			if (!_Enabled)
			{
				return false;
			}
			if (!_Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Surface))
			{
				return false;
			}
			if (camera == _CameraReflections)
			{
				return false;
			}
			if (camera.cameraType == CameraType.Reflection)
			{
				return false;
			}
			return true;
		}

		internal void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			if (SupportsRecursiveRendering)
			{
				if (_RenderOnlySingleCamera && camera != _Water.Viewer)
				{
					return;
				}
				_CameraViewpoint = camera;
				LateUpdate(context);
			}
			if (camera == _CameraViewpoint)
			{
				Shader.SetGlobalTexture(ShaderIDs.s_ReflectionColorTexture, _ColorTexture);
				Shader.SetGlobalTexture(ShaderIDs.s_ReflectionDepthTexture, _DepthTexture);
			}
		}

		internal void OnEndReflectionCameraRendering(Camera camera)
		{
			if (camera == ReflectionCamera)
			{
				_CameraDepthTexture = Shader.GetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_CameraDepthTexture);
			}
		}

		internal void OnEndCameraRendering(Camera camera)
		{
			Shader.SetGlobalTexture(ShaderIDs.s_ReflectionColorTexture, Texture2D.blackTexture);
		}

		internal void LateUpdate()
		{
			_ApplySmoothness = false;
			CheckSurfaceMaterial(_Water.Surface.Material);
			foreach (WaterBody waterBody in WaterBody.WaterBodies)
			{
				CheckSurfaceMaterial(waterBody._Material);
			}
			if (!SupportsRecursiveRendering)
			{
				LateUpdate(default(ScriptableRenderContext));
			}
		}

		internal void LateUpdate(ScriptableRenderContext context)
		{
			if ((_LastRefreshOnFrame > 0 && RefreshPerFrames > 1 && Math.Abs(_FrameRefreshOffset) % _RefreshPerFrames != Time.renderedFrameCount % _RefreshPerFrames) || _Water == null)
			{
				return;
			}
			if (!SupportsRecursiveRendering)
			{
				_CameraViewpoint = _Water.Viewer;
			}
			if (_CameraViewpoint == null)
			{
				return;
			}
			CreateWaterObjects(_CameraViewpoint);
			if ((bool)_CameraReflections)
			{
				UpdateCameraModes();
				ForceDistanceCulling(_FarClipPlane);
				if (_Mode != WaterReflectionSide.Both)
				{
					Helpers.ClearRenderTexture(_ColorTexture, Color.clear);
					Helpers.ClearRenderTexture(_DepthTexture, Color.clear);
				}
				bool activeSelf = _Water.Surface.Root.gameObject.activeSelf;
				_Water.Surface.Root.gameObject.SetActive(value: false);
				int pixelLightCount = QualitySettings.pixelLightCount;
				if (_DisablePixelLights)
				{
					QualitySettings.pixelLightCount = 0;
				}
				UnityEngine.ShadowQuality shadows = QualitySettings.shadows;
				if (_DisableShadows)
				{
					QualitySettings.shadows = UnityEngine.ShadowQuality.Disable;
				}
				_QualitySettingsOverride.Override();
				bool invertCulling = GL.invertCulling;
				GL.invertCulling = !invertCulling;
				Render(context);
				GL.invertCulling = invertCulling;
				if (_DisableShadows)
				{
					QualitySettings.shadows = shadows;
				}
				if (_DisablePixelLights)
				{
					QualitySettings.pixelLightCount = pixelLightCount;
				}
				_QualitySettingsOverride.Restore();
				_Water.Surface.Root.gameObject.SetActive(activeSelf);
				_LastRefreshOnFrame = Time.renderedFrameCount;
			}
		}

		private void Render(ScriptableRenderContext context)
		{
			RenderTexture renderTexture = _ColorTexture;
			RenderTexture renderTexture2 = _DepthTexture;
			if (RequireTemporaryTargets)
			{
				RenderTextureDescriptor descriptor = _ColorTexture.descriptor;
				descriptor.dimension = TextureDimension.Tex2D;
				descriptor.volumeDepth = 1;
				descriptor.useMipMap = false;
				renderTexture = RenderTexture.GetTemporary(descriptor);
				if (RenderPipelineHelper.IsLegacy)
				{
					descriptor = _DepthTexture.descriptor;
					descriptor.dimension = TextureDimension.Tex2D;
					descriptor.volumeDepth = 1;
					descriptor.useMipMap = false;
					renderTexture2 = RenderTexture.GetTemporary(descriptor);
				}
			}
			if (RenderPipelineHelper.IsLegacy)
			{
				_CameraReflections.SetTargetBuffers(renderTexture.colorBuffer, renderTexture2.depthBuffer);
			}
			else
			{
				_CameraReflections.targetTexture = renderTexture;
			}
			if (_Mode != WaterReflectionSide.Below)
			{
				if (_UnderWater._Enabled)
				{
					_CameraReflections.cullingMask = (int)_Layers & ~(1 << _UnderWater.Layer);
				}
				_ActiveSlice = 0;
				RenderCamera(context, _CameraReflections, Vector3.up, nonObliqueNearSurface: false, 0);
				CopyTargets(renderTexture, renderTexture2, 0);
				_ReflectionPositionNormal[0] = ComputeHorizonPositionAndNormal(_CameraReflections, _Water.SeaLevel, 0.5f / (float)_Resolution, flipped: false);
				_CameraReflections.ResetProjectionMatrix();
			}
			if (_Mode != WaterReflectionSide.Above)
			{
				if (_UnderWater._Enabled)
				{
					_CameraReflections.cullingMask = (int)_Layers | (1 << _UnderWater.Layer);
					_CameraReflections.depthTextureMode = DepthTextureMode.Depth;
				}
				_ActiveSlice = 1;
				RenderCamera(context, _CameraReflections, Vector3.down, _NonObliqueNearSurface, 1);
				CopyTargets(renderTexture, renderTexture2, 1);
				_ReflectionPositionNormal[1] = ComputeHorizonPositionAndNormal(_CameraReflections, _Water.SeaLevel, -0.05f, flipped: true);
				_CameraReflections.ResetProjectionMatrix();
			}
			if (RequireTemporaryTargets)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
				if (RenderPipelineHelper.IsLegacy)
				{
					RenderTexture.ReleaseTemporary(renderTexture2);
				}
			}
			if (_ApplySmoothness)
			{
				_ColorTexture.GenerateMips();
			}
			Shader.SetGlobalVectorArray(ShaderIDs.s_ReflectionPositionNormal, _ReflectionPositionNormal);
			Shader.SetGlobalMatrixArray(ShaderIDs.s_ReflectionMatrixIVP, _ReflectionMatrixIVP);
			Shader.SetGlobalMatrixArray(ShaderIDs.s_ReflectionMatrixV, _ReflectionMatrixV);
		}

		private void RenderCamera(ScriptableRenderContext context, Camera camera, Vector3 planeNormal, bool nonObliqueNearSurface, int slice)
		{
			Vector3 position = _Water.Position;
			float num = _ClipPlaneOffset;
			Transform transform = _CameraViewpoint.transform;
			if (num == 0f && transform.position.y == position.y)
			{
				num = ((transform.position.magnitude >= 15000f) ? 0.01f : 0.001f);
			}
			float w = 0f - Vector3.Dot(planeNormal, position) - num;
			Vector4 plane = new Vector4(planeNormal.x, planeNormal.y, planeNormal.z, w);
			Matrix4x4 reflectionMat = Matrix4x4.zero;
			CalculateReflectionMatrix(ref reflectionMat, plane);
			camera.worldToCameraMatrix = _CameraViewpoint.worldToCameraMatrix * reflectionMat;
			Vector4 clipPlane = CameraSpacePlane(camera, position, planeNormal, 1f);
			if (_UseObliqueMatrix && (!nonObliqueNearSurface || Mathf.Abs(_CameraViewpoint.transform.position.y - position.y) > _NonObliqueNearSurfaceThreshold))
			{
				Matrix4x4 projectionMatrix = _CameraViewpoint.CalculateObliqueMatrix(clipPlane);
				float num2 = 1f - (_Overscan - 1f) * 0.5f;
				projectionMatrix[0, 0] *= num2;
				projectionMatrix[1, 1] *= num2;
				camera.projectionMatrix = projectionMatrix;
			}
			camera.cullingMatrix = _CameraViewpoint.projectionMatrix * _CameraViewpoint.worldToCameraMatrix;
			camera.transform.position = reflectionMat.MultiplyPoint(_CameraViewpoint.transform.position);
			Vector3 eulerAngles = _CameraViewpoint.transform.eulerAngles;
			camera.transform.eulerAngles = new Vector3(0f - eulerAngles.x, eulerAngles.y, eulerAngles.z);
			camera.cullingMatrix = camera.projectionMatrix * camera.worldToCameraMatrix;
			_ReflectionMatrixV[slice] = camera.worldToCameraMatrix;
			_ReflectionMatrixIVP[slice] = (GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true) * camera.worldToCameraMatrix).inverse;
			if (SupportsRecursiveRendering)
			{
				Helpers.RenderCamera(camera, context, slice, _Debug._ForceCompatibility);
			}
			else
			{
				camera.Render();
			}
		}

		private void CopyTargets(Texture color, Texture depth, int slice)
		{
			if (RequireTemporaryTargets)
			{
				Graphics.CopyTexture(color, 0, 0, 0, 0, _Resolution, _Resolution, _ColorTexture, slice, 0, 0, 0);
			}
			if (!RenderPipelineHelper.IsLegacy)
			{
				depth = _CameraDepthTexture;
			}
			if (!Rendering.IsRenderGraph)
			{
				if (depth != null && depth.graphicsFormat != _DepthTexture.graphicsFormat)
				{
					RecreateDepth(depth);
				}
				if (depth != null && depth.width >= _Resolution)
				{
					Graphics.CopyTexture(depth, 0, 0, 0, 0, _Resolution, _Resolution, _DepthTexture, slice, 0, 0, 0);
				}
			}
		}

		private void ForceDistanceCulling(float farClipPlane)
		{
			if (RenderPipelineHelper.IsLegacy)
			{
				for (int i = 0; i < _CullDistances.Length; i++)
				{
					_CullDistances[i] = farClipPlane;
				}
				_CameraReflections.layerCullDistances = _CullDistances;
				_CameraReflections.layerCullSpherical = true;
			}
		}

		private void UpdateCameraModes()
		{
			_CameraReflections.clearFlags = (_Sky ? CameraClearFlags.Skybox : CameraClearFlags.Color);
			if (_Sky && _CameraViewpoint.TryGetComponent<Skybox>(out _CameraViewpointSkybox))
			{
				if (_CameraReflectionsSkybox == null)
				{
					_CameraReflectionsSkybox = _CameraReflections.gameObject.AddComponent<Skybox>();
				}
				_CameraReflectionsSkybox.enabled = _CameraViewpointSkybox.enabled;
				_CameraReflectionsSkybox.material = _CameraViewpointSkybox.material;
			}
			else
			{
				Helpers.Destroy(_CameraViewpointSkybox);
				_CameraViewpointSkybox = null;
			}
			_CameraReflections.farClipPlane = _CameraViewpoint.farClipPlane;
			_CameraReflections.nearClipPlane = _CameraViewpoint.nearClipPlane;
			_CameraReflections.orthographic = _CameraViewpoint.orthographic;
			_CameraReflections.fieldOfView = _CameraViewpoint.fieldOfView;
			_CameraReflections.orthographicSize = _CameraViewpoint.orthographicSize;
			_CameraReflections.allowMSAA = false;
			_CameraReflections.aspect = _CameraViewpoint.aspect;
			_CameraReflections.useOcclusionCulling = !_DisableOcclusionCulling && _CameraViewpoint.useOcclusionCulling;
			_CameraReflections.depthTextureMode = _CameraViewpoint.depthTextureMode;
			_CameraReflections.usePhysicalProperties = _Overscan > 1f;
			Vector2 vector = new Vector2(36f, 24f);
			float focalLength = vector.y * 0.5f / Mathf.Tan(_CameraViewpoint.fieldOfView * 0.5f * (MathF.PI / 180f));
			float num = 1f - (_Overscan - 1f) * 0.5f;
			_CameraReflections.sensorSize = vector / num;
			_CameraReflections.focalLength = focalLength;
			Shader.SetGlobalFloat(ShaderIDs.s_Crest_ReflectionOverscan, num);
		}

		private void RecreateDepth(Texture depth)
		{
			if (_DepthTexture != null && _DepthTexture.IsCreated())
			{
				_DepthTexture.Release();
				_DepthTexture.descriptor = depth.GetDescriptor();
			}
			else
			{
				_DepthTexture = new RenderTexture(depth.GetDescriptor());
			}
			_DepthTexture.name = "_Crest_ReflectionDepth";
			RenderTexture depthTexture = _DepthTexture;
			int width = (_DepthTexture.height = _Resolution);
			depthTexture.width = width;
			_DepthTexture.isPowerOfTwo = true;
			_DepthTexture.useMipMap = false;
			_DepthTexture.autoGenerateMips = false;
			_DepthTexture.filterMode = FilterMode.Point;
			_DepthTexture.volumeDepth = 2;
			_DepthTexture.dimension = TextureDimension.Tex2DArray;
			_DepthTexture.Create();
		}

		private void CreateWaterObjects(Camera currentCamera)
		{
			GraphicsFormat defaultColorFormat = Rendering.GetDefaultColorFormat(_HDR);
			GraphicsFormat defaultDepthFormat = Rendering.GetDefaultDepthFormat(_Stencil || RenderPipelineHelper.IsUniversal);
			if (!_ColorTexture || _ColorTexture.width != _Resolution || _ColorTexture.graphicsFormat != defaultColorFormat || _ColorTexture.depthStencilFormat != defaultDepthFormat)
			{
				if ((bool)_ColorTexture)
				{
					Helpers.Destroy(_ColorTexture);
					Helpers.Destroy(_DepthTexture);
				}
				RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(_Resolution, _Resolution);
				renderTextureDescriptor.dimension = TextureDimension.Tex2DArray;
				renderTextureDescriptor.volumeDepth = 2;
				renderTextureDescriptor.depthStencilFormat = defaultDepthFormat;
				renderTextureDescriptor.msaaSamples = 1;
				renderTextureDescriptor.useMipMap = false;
				RenderTextureDescriptor desc = renderTextureDescriptor;
				_ColorTexture = new RenderTexture(desc)
				{
					name = "_Crest_ReflectionColor",
					graphicsFormat = defaultColorFormat,
					isPowerOfTwo = true,
					useMipMap = true,
					autoGenerateMips = false,
					filterMode = FilterMode.Trilinear
				};
				_ColorTexture.Create();
				_DepthTexture = new RenderTexture(desc)
				{
					name = "_Crest_ReflectionDepth",
					graphicsFormat = GraphicsFormat.None,
					isPowerOfTwo = true,
					useMipMap = false,
					autoGenerateMips = false,
					filterMode = FilterMode.Point
				};
				if (RenderPipelineHelper.IsHighDefinition)
				{
					_DepthTexture.graphicsFormat = GraphicsFormat.R32_SFloat;
					_DepthTexture.depthStencilFormat = GraphicsFormat.None;
				}
				_DepthTexture.Create();
			}
			bool num = _CameraReflections == null;
			if (num)
			{
				GameObject gameObject = new GameObject("_Crest_WaterReflectionCamera");
				gameObject.transform.SetParent(_Water.Container.transform, worldPositionStays: true);
				_CameraReflections = gameObject.AddComponent<Camera>();
				_CameraReflections.enabled = false;
				_CameraReflections.cameraType = CameraType.Reflection;
				_CameraReflections.backgroundColor = Color.clear;
				if (RenderPipelineHelper.IsLegacy)
				{
					_CameraReflections.gameObject.AddComponent<FlareLayer>();
				}
				if (RenderPipelineHelper.IsUniversal)
				{
					_CameraReflections.gameObject.AddComponent<UniversalAdditionalCameraData>().requiresDepthTexture = true;
				}
				_UpdateCamera = true;
			}
			if (_UpdateCamera)
			{
				_CameraReflections.gameObject.hideFlags = (_Debug._ShowHiddenObjects ? HideFlags.DontSave : HideFlags.HideAndDontSave);
				if (RenderPipelineHelper.IsUniversal)
				{
					UniversalAdditionalCameraData universalAdditionalCameraData = _CameraReflections.GetUniversalAdditionalCameraData();
					universalAdditionalCameraData.SetRenderer(_RendererIndex);
					universalAdditionalCameraData.renderShadows = !_DisableShadows;
					universalAdditionalCameraData.requiresColorTexture = _Mode != WaterReflectionSide.Above;
				}
				_UpdateCamera = false;
			}
			if (num)
			{
				OnCameraAdded?.Invoke(_CameraReflections);
			}
		}

		private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
		{
			float num = _ClipPlaneOffset;
			Transform transform = _CameraViewpoint.transform;
			if (num == 0f && transform.position.y == 0f && transform.rotation.eulerAngles.y == 0f)
			{
				num = 1E-05f;
			}
			Vector3 point = pos + normal * num;
			Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
			Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
			Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
			return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
		}

		private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
		{
			reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
			reflectionMat.m01 = -2f * plane[0] * plane[1];
			reflectionMat.m02 = -2f * plane[0] * plane[2];
			reflectionMat.m03 = -2f * plane[3] * plane[0];
			reflectionMat.m10 = -2f * plane[1] * plane[0];
			reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
			reflectionMat.m12 = -2f * plane[1] * plane[2];
			reflectionMat.m13 = -2f * plane[3] * plane[1];
			reflectionMat.m20 = -2f * plane[2] * plane[0];
			reflectionMat.m21 = -2f * plane[2] * plane[1];
			reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
			reflectionMat.m23 = -2f * plane[3] * plane[2];
			reflectionMat.m30 = 0f;
			reflectionMat.m31 = 0f;
			reflectionMat.m32 = 0f;
			reflectionMat.m33 = 1f;
		}

		private static Vector4 ComputeHorizonPositionAndNormal(Camera camera, float positionY, float offset, bool flipped)
		{
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			NativeArray<Vector3> nativeArray = new NativeArray<Vector3>(4, Allocator.Temp);
			NativeArray<Vector3> nativeArray2 = new NativeArray<Vector3>(4, Allocator.Temp);
			try
			{
				float farClipPlane = camera.farClipPlane;
				nativeArray[0] = new Vector3(0f, 0f, farClipPlane);
				nativeArray[1] = new Vector3(0f, 1f, farClipPlane);
				nativeArray[2] = new Vector3(1f, 1f, farClipPlane);
				nativeArray[3] = new Vector3(1f, 0f, farClipPlane);
				for (int i = 0; i < nativeArray2.Length; i++)
				{
					nativeArray2[i] = camera.ViewportToWorldPoint(nativeArray[i]);
				}
				NativeArray<Vector2> nativeArray3 = new NativeArray<Vector2>(2, Allocator.Temp);
				NativeArray<Vector3> nativeArray4 = new NativeArray<Vector3>(2, Allocator.Temp);
				try
				{
					int num = 0;
					for (int j = 0; j < 4; j++)
					{
						int index = (j + 1) % 4;
						if ((nativeArray2[j].y - positionY) * (nativeArray2[index].y - positionY) < 0f)
						{
							float t = Mathf.Abs((positionY - nativeArray2[j].y) / (nativeArray2[index].y - nativeArray2[j].y));
							nativeArray3[num] = Vector2.Lerp(nativeArray[j], nativeArray[index], t);
							nativeArray4[num] = Vector3.Lerp(nativeArray2[j], nativeArray2[index], t);
							num++;
						}
					}
					if (num == 2)
					{
						vector = nativeArray3[0];
						Vector2 vector3 = nativeArray3[0] - nativeArray3[1];
						vector2.x = 0f - vector3.y;
						vector2.y = vector3.x;
						if (Vector3.Dot(nativeArray4[0] - nativeArray4[1], camera.transform.right) > 0f)
						{
							vector2 = -vector2;
						}
						if (camera.transform.up.y <= 0f)
						{
							vector2 = -vector2;
						}
						float num2 = Vector3.Dot(camera.transform.right, Vector3.up);
						float num3 = Vector2.Dot(vector2, Vector2.right);
						if (num2 > 0.75f && num3 > 0.9f)
						{
							vector2 = -vector2;
						}
						else if (num2 < -0.75f && num3 < -0.9f)
						{
							vector2 = -vector2;
						}
						vector += vector2.normalized * offset;
					}
				}
				finally
				{
					nativeArray3.Dispose();
					nativeArray4.Dispose();
				}
			}
			finally
			{
				nativeArray.Dispose();
				nativeArray2.Dispose();
			}
			vector2 = vector2.normalized;
			if (flipped)
			{
				vector2 = -vector2;
			}
			else if (vector.y == 0f)
			{
				vector.y = 1f;
			}
			return new Vector4(vector.x, vector.y, vector2.x, vector2.y);
		}

		private void CheckSurfaceMaterial(Material material)
		{
			if (!(material == null) && !_ApplySmoothness)
			{
				_ApplySmoothness = material.GetBoolean(ShaderIDs.s_PlanarReflectionsApplySmoothness);
			}
		}

		private void SetEnabled(bool previous, bool current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled)
			{
				if (_Enabled)
				{
					OnEnable();
				}
				else
				{
					OnDisable();
				}
			}
		}

		private void SetReflectionSide(WaterReflectionSide previous, WaterReflectionSide current)
		{
			if (previous != current)
			{
				_UpdateCamera = true;
			}
		}

		private void SetDisableShadows(bool previous, bool current)
		{
			if (previous != current)
			{
				_UpdateCamera = true;
			}
		}

		private void SetRendererIndex(int previous, int current)
		{
			if (previous != current)
			{
				_UpdateCamera = true;
			}
		}

		private void CaptureTargetDepth(ScriptableRenderContext context, Camera camera)
		{
			if (!(camera != ReflectionCamera) && RenderPipelineHelper.IsUniversal && !GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
			{
				if (_CopyTargetsRenderPass == null)
				{
					_CopyTargetsRenderPass = new CopyDepthRenderPass(this);
				}
				camera.GetUniversalAdditionalCameraData().scriptableRenderer.EnqueuePass(_CopyTargetsRenderPass);
			}
		}
	}
}
