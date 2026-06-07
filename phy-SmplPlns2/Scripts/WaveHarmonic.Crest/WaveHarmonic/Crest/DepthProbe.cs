using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Depth Probe")]
	public sealed class DepthProbe : ManagedBehaviour<WaterRenderer>
	{
		[Serializable]
		internal sealed class DebugFields
		{
			[Tooltip("Shows hidden objects like the camera which renders into the probe.")]
			[SerializeField]
			public bool _ShowHiddenObjects;

			[HideInInspector]
			[SerializeField]
			public bool _ShowSimulationDataInScene;
		}

		internal static class ShaderIDs
		{
			public static readonly int s_CamDepthBuffer = Shader.PropertyToID("_CamDepthBuffer");

			public static readonly int s_CustomZBufferParams = Shader.PropertyToID("_CustomZBufferParams");

			public static readonly int s_HeightNearHeightFar = Shader.PropertyToID("_HeightNearHeightFar");

			public static readonly int s_HeightOffset = Shader.PropertyToID("_HeightOffset");

			public static readonly int s_CameraDepthBufferBackfaces = Shader.PropertyToID("_Crest_CameraDepthBufferBackfaces");

			public static readonly int s_PreviousPlane = Shader.PropertyToID("_Crest_PreviousPlane");

			public static readonly int s_DepthProbe = Shader.PropertyToID("_Crest_DepthProbe");

			public static readonly int s_DepthProbeHeightOffset = Shader.PropertyToID("_Crest_DepthProbeHeightOffset");

			public static readonly int s_DepthProbeResolution = Shader.PropertyToID("_Crest_DepthProbeResolution");

			public static readonly int s_JumpSize = Shader.PropertyToID("_Crest_JumpSize");

			public static readonly int s_WaterLevel = Shader.PropertyToID("_Crest_WaterLevel");

			public static readonly int s_ProjectionToWorld = Shader.PropertyToID("_Crest_ProjectionToWorld");

			public static readonly int s_VoronoiPingPong0 = Shader.PropertyToID("_Crest_VoronoiPingPong0");

			public static readonly int s_VoronoiPingPong1 = Shader.PropertyToID("_Crest_VoronoiPingPong1");
		}

		private sealed class Input : ILodInput
		{
			private readonly DepthProbe _Probe;

			public bool Enabled
			{
				get
				{
					if (_Probe.enabled)
					{
						return _Probe.Texture != null;
					}
					return false;
				}
			}

			public bool IsCompute => true;

			public int Queue => 0;

			public int Pass => -1;

			public Rect Rect => _Probe.Rect;

			public MonoBehaviour Component => _Probe;

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}

			public Input(DepthProbe probe)
			{
				_Probe = probe;
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slices = -1)
			{
				WaterResources instance = ScriptableSingleton<WaterResources>.Instance;
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, instance.Compute._DepthTexture, 0);
				Vector3 position = _Probe.Position;
				Matrix4x4 matrix4x = Matrix4x4.TRS(position, _Probe.Rotation, _Probe.Scale.XNZ(1f));
				propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_TextureSize, _Probe.Scale);
				propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_TexturePosition, position.XZ());
				propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_TextureRotation, new Vector2(matrix4x.m20, matrix4x.m00).normalized);
				propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_Multiplier, Vector4.one);
				propertyWrapperCompute.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_Blend, 3);
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Texture, _Probe.Texture);
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, target);
				propertyWrapperCompute.SetFloat(DepthLodInput.ShaderIDs.s_HeightOffset, position.y);
				propertyWrapperCompute.SetInteger(DepthLodInput.ShaderIDs.s_SDF, _Probe._GenerateSignedDistanceField ? 1 : 0);
				propertyWrapperCompute.SetKeyword(instance.Keywords.DepthTextureSDF, lod._Water._DepthLod._EnableSignedDistanceFields);
				int num = lod.Resolution / 8;
				propertyWrapperCompute.Dispatch(num, num, slices);
			}
		}

		[Tooltip("Specifies the setup for this probe.")]
		[SerializeField]
		internal DepthProbeMode _Type;

		[Tooltip("Where the Depth Probe is placed.\n\nThe default performs the best.")]
		[SerializeField]
		private Placement _Placement;

		[Tooltip("Controls how the probe is refreshed in the Player.\n\nCall Populate() if scripting.\n\nWhen Placement is not set to Fixed, EveryFrame is still applicable, but the others are not (update only happens on position change).")]
		[SerializeField]
		internal DepthProbeRefreshMode _RefreshMode;

		[Tooltip("The layers to render into the probe.")]
		[SerializeField]
		internal LayerMask _Layers = 1;

		[Tooltip("The resolution of the probe.\n\nLower will be more efficient.")]
		[SerializeField]
		internal int _Resolution = 512;

		[Tooltip("The far and near plane of the depth probe camera respectively, relative to the transform.\n\nDepth is captured top-down and orthographically. The gizmo will visualize this range as the bottom box.")]
		[SerializeField]
		internal Vector2 _CaptureRange = new Vector2(-1000f, 1000f);

		[Tooltip("Fills holes left by the maximum of the capture range.\n\nSetting the maximum capture range lower than the highest point of geometry can be useful for eliminating depth artifacts from overhangs, but the side effect is there will be a hole in the depth data where geometry is clipped by the near plane. This will only capture where the holes are to fill them in. This height is relative to the maximum capture range. Set to zero to skip.")]
		[FormerlySerializedAs("_MaximumHeight")]
		[SerializeField]
		internal float _FillHolesCaptureHeight;

		[Tooltip("Increase coverage by testing mesh back faces within the Fill Holes area.\n\nUses the back-faces to include meshes where the front-face is within the Fill Holes area and the back-face is within the capture area. An example would be an upright cylinder not over a hole but was not captured due to the top being clipped by the near plane.")]
		[SerializeField]
		private bool _EnableBackFaceInclusion = true;

		[Tooltip("Overrides global quality settings.")]
		[SerializeField]
		private QualitySettingsOverride _QualitySettingsOverride = new QualitySettingsOverride
		{
			_OverrideLodBias = true,
			_LodBias = float.PositiveInfinity,
			_OverrideMaximumLodLevel = true,
			_MaximumLodLevel = 0,
			_OverrideTerrainPixelError = true,
			_TerrainPixelError = 0f
		};

		[Tooltip("Baked probe.\n\nCan only bake in edit mode.")]
		[SerializeField]
		internal Texture2D _SavedTexture;

		[Tooltip("Generate a signed distance field for the shoreline.")]
		[SerializeField]
		internal bool _GenerateSignedDistanceField = true;

		[Tooltip("How many additional Jump Flood rounds to use.\n\nThe standard number of rounds is log2(resolution). Additional rounds can reduce innaccuracies.")]
		[SerializeField]
		private int _AdditionalJumpFloodRounds = 7;

		[SerializeField]
		internal DebugFields _Debug = new DebugFields();

		private const int k_CopyKernel = 0;

		private const int k_FillKernel = 1;

		internal Camera _Camera;

		private Rect _Rect;

		private bool _RecalculateBounds = true;

		private CommandBuffer _CommandBuffer;

		private bool _Managed;

		private bool _OverridePosition;

		private Vector3 _Position;

		private Vector2 _Scale;

		private Input _Input;

		private Vector3 _PreviousPosition;

		private int _RenderedStateHash;

		private int _CurrentStateHash;

		private Rect Rect
		{
			get
			{
				if (_RecalculateBounds)
				{
					_Rect = (Managed ? new Rect(Position.XZ() - Scale * 0.5f, Scale) : base.transform.RectXZ());
					_RecalculateBounds = false;
				}
				return _Rect;
			}
		}

		internal Texture Texture
		{
			get
			{
				if (_Type != DepthProbeMode.Baked)
				{
					return RealtimeTexture;
				}
				return SavedTexture;
			}
		}

		internal RenderTexture RealtimeTexture { get; set; }

		internal RenderTexture TargetTexture { get; set; }

		internal bool Managed
		{
			get
			{
				return _Managed;
			}
			set
			{
				if (_Managed != value)
				{
					_RecalculateBounds = true;
				}
				_Managed = value;
			}
		}

		internal bool OverridePosition
		{
			get
			{
				return _OverridePosition;
			}
			set
			{
				if (Managed && _OverridePosition != value)
				{
					_RecalculateBounds = true;
				}
				_OverridePosition = value;
			}
		}

		internal Vector3 Position
		{
			get
			{
				if (!Managed || !OverridePosition)
				{
					return base.transform.position;
				}
				return _Position.XNZ(base.transform.position.y);
			}
			set
			{
				if (Managed && OverridePosition && _Position != value)
				{
					_RecalculateBounds = true;
				}
				_Position = value;
			}
		}

		internal Quaternion Rotation
		{
			get
			{
				if (!Managed)
				{
					return Quaternion.Euler(base.transform.rotation.eulerAngles.NYN());
				}
				return Quaternion.identity;
			}
		}

		internal Vector2 Scale
		{
			get
			{
				if (!Managed)
				{
					return base.transform.lossyScale.XZ();
				}
				return _Scale;
			}
			set
			{
				if (_Scale != value)
				{
					_RecalculateBounds = true;
				}
				_Scale = value;
			}
		}

		public static Action<DepthProbe> OnBeforeRender { get; set; }

		public static Action<DepthProbe> OnAfterRender { get; set; }

		internal static Action<DepthProbe> OnBakeRequest { get; set; }

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private protected override Action<WaterRenderer> OnLateUpdateMethod => OnLateUpdate;

		internal bool Outdated => _CurrentStateHash != _RenderedStateHash;

		private GraphicsFormat FinalFormat
		{
			get
			{
				if (!_GenerateSignedDistanceField)
				{
					return GraphicsFormat.R32_SFloat;
				}
				return Helpers.GetCompatibleTextureFormat(GraphicsFormat.R32G32_SFloat, Helpers.s_DataGraphicsFormatUsage, "Depth Probe", randomWrite: true);
			}
		}

		private protected override int Version => Mathf.Max(base.Version, 1);

		public int AdditionalJumpFloodRounds
		{
			get
			{
				return _AdditionalJumpFloodRounds;
			}
			set
			{
				SetDirty(_AdditionalJumpFloodRounds, _AdditionalJumpFloodRounds = value);
			}
		}

		public Vector2 CaptureRange
		{
			get
			{
				return _CaptureRange;
			}
			set
			{
				SetDirty(_CaptureRange, _CaptureRange = value);
			}
		}

		public bool EnableBackFaceInclusion
		{
			get
			{
				return _EnableBackFaceInclusion;
			}
			set
			{
				SetDirty(_EnableBackFaceInclusion, _EnableBackFaceInclusion = value);
			}
		}

		public float FillHolesCaptureHeight
		{
			get
			{
				return _FillHolesCaptureHeight;
			}
			set
			{
				SetDirty(_FillHolesCaptureHeight, _FillHolesCaptureHeight = value);
			}
		}

		public bool GenerateSignedDistanceField
		{
			get
			{
				return _GenerateSignedDistanceField;
			}
			set
			{
				SetDirty(_GenerateSignedDistanceField, _GenerateSignedDistanceField = value);
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
				SetDirty(_Layers, _Layers = value);
			}
		}

		public Placement Placement
		{
			get
			{
				return _Placement;
			}
			set
			{
				_Placement = value;
			}
		}

		public QualitySettingsOverride QualitySettingsOverride => _QualitySettingsOverride;

		public DepthProbeRefreshMode RefreshMode
		{
			get
			{
				return _RefreshMode;
			}
			set
			{
				_RefreshMode = value;
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
				SetDirty(_Resolution, _Resolution = value);
			}
		}

		public Texture2D SavedTexture
		{
			get
			{
				return _SavedTexture;
			}
			set
			{
				_SavedTexture = value;
			}
		}

		public DepthProbeMode Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}

		internal void Bind<T>(T wrapper) where T : IPropertyWrapper
		{
			int s_DepthProbe = ShaderIDs.s_DepthProbe;
			Texture texture = Texture;
			wrapper.SetTexture(s_DepthProbe, texture);
			int s_DepthProbeHeightOffset = ShaderIDs.s_DepthProbeHeightOffset;
			float y = base.transform.position.y;
			wrapper.SetFloat(s_DepthProbeHeightOffset, y);
			int s_DepthProbeResolution = ShaderIDs.s_DepthProbeResolution;
			float value = _Resolution;
			wrapper.SetFloat(s_DepthProbeResolution, value);
		}

		private protected override void OnStart()
		{
			base.OnStart();
			if (_Type == DepthProbeMode.RealTime && _RefreshMode == DepthProbeRefreshMode.OnStart)
			{
				Populate();
			}
		}

		private void OnDestroy()
		{
			if (_Camera != null)
			{
				Helpers.Destroy(_Camera.gameObject);
			}
			_CommandBuffer?.Release();
			_CommandBuffer = null;
		}

		private void OnUpdate(WaterRenderer water)
		{
			if (base.transform.hasChanged)
			{
				_RecalculateBounds = true;
				if (_Placement == Placement.Transform)
				{
					UpdatePosition(water, base.transform);
				}
			}
		}

		private void OnLateUpdate(WaterRenderer water)
		{
			base.transform.hasChanged = false;
		}

		private void OnBeforeBuildCommandBuffer(WaterRenderer water, Camera camera)
		{
			if (_Placement == Placement.Viewpoint)
			{
				UpdatePosition(water, camera.transform);
			}
		}

		private bool IsTextureOutdated(RenderTexture texture, bool target)
		{
			if ((!(texture != null) || texture.width == _Resolution) && texture.height == _Resolution)
			{
				return texture.graphicsFormat != (target ? SystemInfo.GetGraphicsFormat(DefaultFormat.DepthStencil) : FinalFormat);
			}
			return true;
		}

		private void MakeRT(RenderTexture texture, bool target)
		{
			GraphicsFormat graphicsFormat = (target ? SystemInfo.GetGraphicsFormat(DefaultFormat.DepthStencil) : FinalFormat);
			RenderTextureDescriptor descriptor = texture.descriptor;
			descriptor.graphicsFormat = ((!target) ? graphicsFormat : GraphicsFormat.None);
			descriptor.depthStencilFormat = (target ? graphicsFormat : GraphicsFormat.None);
			int width = (descriptor.height = _Resolution);
			descriptor.width = width;
			descriptor.depthBufferBits = (target ? 24 : 0);
			descriptor.useMipMap = false;
			descriptor.enableRandomWrite = !target;
			texture.descriptor = descriptor;
			texture.Create();
		}

		private bool InitObjects()
		{
			if (RealtimeTexture == null)
			{
				RealtimeTexture = new RenderTexture(0, 0, 0)
				{
					name = "_Crest_WaterDepthCache_" + base.gameObject.name,
					anisoLevel = 0
				};
			}
			else if (IsTextureOutdated(RealtimeTexture, target: false))
			{
				RealtimeTexture.Release();
			}
			if (!RealtimeTexture.IsCreated())
			{
				MakeRT(RealtimeTexture, target: false);
			}
			if ((int)_Layers == 0)
			{
				UnityEngine.Debug.LogError("Crest: No valid layers for populating depth probe, aborting.", this);
				return false;
			}
			if (_Camera == null)
			{
				_Camera = new GameObject("_Crest_DepthProbeCamera").AddComponent<Camera>();
				_Camera.transform.parent = base.transform;
				_Camera.transform.localEulerAngles = 90f * Vector3.right;
				_Camera.transform.localPosition = Vector3.zero;
				_Camera.transform.localScale = Vector3.one;
				_Camera.orthographic = true;
				_Camera.clearFlags = CameraClearFlags.Depth;
				_Camera.enabled = false;
				_Camera.allowMSAA = false;
				_Camera.allowDynamicResolution = false;
				_Camera.depthTextureMode = DepthTextureMode.Depth;
				_Camera.cameraType = CameraType.Reflection;
				_Camera.gameObject.SetActive(value: false);
				if (RenderPipelineHelper.IsUniversal)
				{
					SetUpCameraURP();
				}
				else
				{
					_ = RenderPipelineHelper.IsHighDefinition;
				}
			}
			_Camera.orthographicSize = Mathf.Max(Scale.x * 0.5f, Scale.y * 0.5f);
			_Camera.cullingMask = _Layers;
			_Camera.gameObject.hideFlags = (_Debug._ShowHiddenObjects ? HideFlags.DontSave : HideFlags.HideAndDontSave);
			if (TargetTexture == null)
			{
				TargetTexture = new RenderTexture(0, 0, 0)
				{
					name = "_Crest_WaterDepthTarget_" + base.gameObject.name
				};
			}
			else if (IsTextureOutdated(TargetTexture, target: true))
			{
				TargetTexture.Release();
			}
			if (!TargetTexture.IsCreated())
			{
				MakeRT(TargetTexture, target: true);
			}
			_Camera.targetTexture = TargetTexture;
			return true;
		}

		public void Populate()
		{
			if (_Type == DepthProbeMode.Baked)
			{
				OnBakeRequest?.Invoke(this);
			}
			else
			{
				ForcePopulate();
			}
		}

		internal void ForcePopulate()
		{
			if (WaterRenderer.RunningWithoutGraphics)
			{
				UnityEngine.Debug.LogWarning("Crest: Depth probe will not be populated at runtime when in batched/headless mode. Please pre-bake the probe in the Editor.");
			}
			else if (InitObjects())
			{
				float shadowDistance = 0f;
				if (RenderPipelineHelper.IsLegacy)
				{
					shadowDistance = QualitySettings.shadowDistance;
					QualitySettings.shadowDistance = 0f;
				}
				_QualitySettingsOverride.Override();
				OnBeforeRender?.Invoke(this);
				if (_CommandBuffer == null)
				{
					_CommandBuffer = new CommandBuffer();
				}
				_CommandBuffer.Clear();
				_CommandBuffer.name = "Crest.DepthProbe";
				RenderDepthIntoProbe(0, _CaptureRange.y);
				if (_FillHolesCaptureHeight > 0f)
				{
					Graphics.ExecuteCommandBuffer(_CommandBuffer);
					_CommandBuffer.Clear();
					RenderDepthIntoProbe(1, _CaptureRange.y + _FillHolesCaptureHeight);
				}
				_QualitySettingsOverride.Restore();
				if (RenderPipelineHelper.IsLegacy)
				{
					QualitySettings.shadowDistance = shadowDistance;
				}
				OnAfterRender?.Invoke(this);
				if (_GenerateSignedDistanceField)
				{
					_CommandBuffer.BeginSample("SDF");
					RenderSignedDistanceField(inverted: false);
					RenderSignedDistanceField(inverted: true);
					_CommandBuffer.EndSample("SDF");
				}
				Graphics.ExecuteCommandBuffer(_CommandBuffer);
			}
		}

		private void RenderDepthIntoProbe(int kernel, float height)
		{
			_Camera.transform.position = Position + Vector3.up * height;
			_Camera.farClipPlane = 0f - _CaptureRange.x + height;
			if (Managed)
			{
				_Camera.transform.forward = Vector3.down;
			}
			else
			{
				Transform transform = _Camera.transform;
				float n = ((transform.parent == null) ? transform.localEulerAngles.y : transform.parent.eulerAngles.y);
				transform.forward = Vector3.down;
				transform.eulerAngles = transform.eulerAngles.XNZ(n);
			}
			RenderTexture renderTexture = null;
			if (_EnableBackFaceInclusion && kernel == 1)
			{
				RenderTexture targetTexture = _Camera.targetTexture;
				renderTexture = RenderTexture.GetTemporary(targetTexture.descriptor);
				_Camera.targetTexture = renderTexture;
				bool invertCulling = GL.invertCulling;
				GL.invertCulling = true;
				if (RenderPipelineHelper.IsUniversal)
				{
					Helpers.RenderCameraWithoutCustomPasses(_Camera);
				}
				else
				{
					_Camera.Render();
				}
				_Camera.targetTexture = targetTexture;
				GL.invertCulling = invertCulling;
			}
			if (RenderPipelineHelper.IsUniversal)
			{
				Helpers.RenderCameraWithoutCustomPasses(_Camera);
			}
			else
			{
				_Camera.Render();
			}
			PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(_CommandBuffer, ScriptableSingleton<WaterResources>.Instance.Compute._RenderDepthProbe, kernel);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_HeightOffset, base.transform.position.y);
			float nearClipPlane = _Camera.nearClipPlane;
			float farClipPlane = _Camera.farClipPlane;
			propertyWrapperCompute.SetVector(ShaderIDs.s_CustomZBufferParams, new Vector4(1f - farClipPlane / nearClipPlane, farClipPlane / nearClipPlane, (1f - farClipPlane / nearClipPlane) / farClipPlane, farClipPlane / nearClipPlane / farClipPlane));
			float num = _Camera.transform.position.y - nearClipPlane;
			float y = num - farClipPlane;
			propertyWrapperCompute.SetVector(ShaderIDs.s_HeightNearHeightFar, new Vector4(num, y));
			propertyWrapperCompute.SetTexture(ShaderIDs.s_CamDepthBuffer, _Camera.targetTexture);
			propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, RealtimeTexture);
			if (_EnableBackFaceInclusion && kernel == 1)
			{
				nearClipPlane = _Camera.nearClipPlane;
				farClipPlane = _CaptureRange.x + _CaptureRange.y;
				num = base.transform.position.y + _CaptureRange.y - nearClipPlane;
				propertyWrapperCompute.SetTexture(ShaderIDs.s_CameraDepthBufferBackfaces, renderTexture);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_PreviousPlane, num + _Camera.nearClipPlane);
			}
			propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.DepthProbeBackFaceInclusion, _EnableBackFaceInclusion);
			int num2 = RealtimeTexture.width / 8;
			propertyWrapperCompute.Dispatch(num2, num2, 1);
			_Camera.transform.localPosition = Vector3.zero;
			RenderTexture.ReleaseTemporary(renderTexture);
		}

		private void RenderSignedDistanceField(bool inverted)
		{
			ComputeShader jumpFloodSDF = ScriptableSingleton<WaterResources>.Instance.Compute._JumpFloodSDF;
			if (!(jumpFloodSDF == null))
			{
				CommandBuffer commandBuffer = _CommandBuffer;
				Matrix4x4 val = _Camera.cameraToWorldMatrix * _Camera.projectionMatrix.inverse;
				commandBuffer.SetComputeFloatParam(jumpFloodSDF, DepthLodInput.ShaderIDs.s_HeightOffset, base.transform.position.y);
				commandBuffer.SetComputeIntParam(jumpFloodSDF, WaveHarmonic.Crest.ShaderIDs.s_TextureSize, _Resolution);
				commandBuffer.SetComputeMatrixParam(jumpFloodSDF, ShaderIDs.s_ProjectionToWorld, val);
				WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
				float val2 = ((instance != null) ? instance.SeaLevel : base.transform.position.y);
				commandBuffer.SetComputeFloatParam(jumpFloodSDF, ShaderIDs.s_WaterLevel, val2);
				commandBuffer.SetKeyword(jumpFloodSDF, ScriptableSingleton<WaterResources>.Instance.Keywords.JumpFloodStandalone, instance == null);
				RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(_Resolution, _Resolution);
				renderTextureDescriptor.autoGenerateMips = false;
				renderTextureDescriptor.graphicsFormat = Helpers.GetCompatibleTextureFormat(GraphicsFormat.R16G16_SFloat, Helpers.s_DataGraphicsFormatUsage, "Depth Probe SDF", randomWrite: true);
				renderTextureDescriptor.useMipMap = false;
				renderTextureDescriptor.enableRandomWrite = true;
				renderTextureDescriptor.depthBufferBits = 0;
				RenderTextureDescriptor desc = renderTextureDescriptor;
				int num = ShaderIDs.s_VoronoiPingPong0;
				int num2 = ShaderIDs.s_VoronoiPingPong1;
				commandBuffer.GetTemporaryRT(num, desc);
				commandBuffer.GetTemporaryRT(num2, desc);
				commandBuffer.SetKeyword(jumpFloodSDF, ScriptableSingleton<WaterResources>.Instance.Keywords.JumpFloodInverted, inverted);
				int kernelIndex = jumpFloodSDF.FindKernel("CrestInitialize");
				commandBuffer.SetComputeTextureParam(jumpFloodSDF, kernelIndex, WaveHarmonic.Crest.ShaderIDs.s_Source, RealtimeTexture);
				commandBuffer.SetComputeTextureParam(jumpFloodSDF, kernelIndex, WaveHarmonic.Crest.ShaderIDs.s_Target, num);
				commandBuffer.DispatchCompute(jumpFloodSDF, kernelIndex, RealtimeTexture.width / 8, RealtimeTexture.height / 8, 1);
				int kernel = jumpFloodSDF.FindKernel("CrestExecute");
				for (int num3 = _Resolution / 2; num3 > 0; num3 /= 2)
				{
					ApplyJumpFlood(commandBuffer, jumpFloodSDF, kernel, num3, num, num2);
					int num4 = num2;
					int num5 = num;
					num = num4;
					num2 = num5;
				}
				for (int i = 0; i < _AdditionalJumpFloodRounds; i++)
				{
					int jumpSize = 1 << i;
					ApplyJumpFlood(commandBuffer, jumpFloodSDF, kernel, jumpSize, num, num2);
					int num6 = num2;
					int num5 = num;
					num = num6;
					num2 = num5;
				}
				int kernelIndex2 = jumpFloodSDF.FindKernel("CrestApply");
				commandBuffer.SetComputeTextureParam(jumpFloodSDF, kernelIndex2, WaveHarmonic.Crest.ShaderIDs.s_Source, num);
				commandBuffer.SetComputeTextureParam(jumpFloodSDF, kernelIndex2, WaveHarmonic.Crest.ShaderIDs.s_Target, RealtimeTexture);
				commandBuffer.DispatchCompute(jumpFloodSDF, kernelIndex2, _Resolution / 8, _Resolution / 8, 1);
				commandBuffer.ReleaseTemporaryRT(num);
				commandBuffer.ReleaseTemporaryRT(num2);
			}
		}

		private void ApplyJumpFlood(CommandBuffer buffer, ComputeShader shader, int kernel, int jumpSize, RenderTargetIdentifier source, RenderTargetIdentifier target)
		{
			buffer.SetComputeIntParam(shader, ShaderIDs.s_JumpSize, jumpSize);
			buffer.SetComputeTextureParam(shader, kernel, WaveHarmonic.Crest.ShaderIDs.s_Source, source);
			buffer.SetComputeTextureParam(shader, kernel, WaveHarmonic.Crest.ShaderIDs.s_Target, target);
			buffer.DispatchCompute(shader, kernel, _Resolution / 8, _Resolution / 8, 1);
		}

		private void SetDirty<I>(I previous, I current) where I : IEquatable<I>
		{
			object.Equals(previous, current);
		}

		private void SetDirty(LayerMask previous, LayerMask current)
		{
			_ = (int)previous;
			_ = (int)current;
		}

		private protected override void Initialize()
		{
			base.Initialize();
			if (_Input == null)
			{
				_Input = new Input(this);
			}
			ILodInput.Attach(_Input, DepthLod.s_Inputs);
			WaterRenderer.s_OnBeforeBuildCommandBuffer = (Action<WaterRenderer, Camera>)Delegate.Remove(WaterRenderer.s_OnBeforeBuildCommandBuffer, new Action<WaterRenderer, Camera>(OnBeforeBuildCommandBuffer));
			WaterRenderer.s_OnBeforeBuildCommandBuffer = (Action<WaterRenderer, Camera>)Delegate.Combine(WaterRenderer.s_OnBeforeBuildCommandBuffer, new Action<WaterRenderer, Camera>(OnBeforeBuildCommandBuffer));
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			ILodInput.Detach(_Input, DepthLod.s_Inputs);
			WaterRenderer.s_OnBeforeBuildCommandBuffer = (Action<WaterRenderer, Camera>)Delegate.Remove(WaterRenderer.s_OnBeforeBuildCommandBuffer, new Action<WaterRenderer, Camera>(OnBeforeBuildCommandBuffer));
		}

		private void UpdatePosition(WaterRenderer water, Transform target)
		{
			Vector3 vector = target.position.XNZ(water.transform.position.y);
			Vector2 vector2 = Scale / _Resolution;
			vector.x = Mathf.Round(vector.x / vector2.x) * vector2.x;
			vector.z = Mathf.Round(vector.z / vector2.y) * vector2.y;
			if ((_Placement == Placement.Viewpoint && !water.IsSingleViewpointMode) || _RefreshMode == DepthProbeRefreshMode.EveryFrame || _PreviousPosition != vector)
			{
				Managed = true;
				OverridePosition = true;
				Position = vector;
				Scale = new Vector2(base.transform.lossyScale.x, base.transform.lossyScale.z);
				Populate();
				_PreviousPosition = vector;
			}
		}

		[Conditional("UNITY_EDITOR")]
		private void HashState(ref int hash)
		{
			hash = Hash.CreateHash();
			Hash.AddInt(_Layers, ref hash);
			Hash.AddInt(_Resolution, ref hash);
			Hash.AddObject(_CaptureRange, ref hash);
			Hash.AddFloat(_FillHolesCaptureHeight, ref hash);
			Hash.AddObject((object)_QualitySettingsOverride, ref hash);
			Hash.AddBool(_EnableBackFaceInclusion, ref hash);
			Hash.AddInt(_AdditionalJumpFloodRounds, ref hash);
			Hash.AddBool(_GenerateSignedDistanceField, ref hash);
			Hash.AddObject(Managed ? Vector3.zero : Position, ref hash);
			Hash.AddObject(Managed ? Quaternion.identity : Rotation, ref hash);
			Hash.AddObject(Managed ? Vector2.zero : Scale, ref hash);
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				_CaptureRange.y = _FillHolesCaptureHeight;
				_FillHolesCaptureHeight = 0f;
			}
		}

		private void SetUpCameraURP()
		{
			UniversalAdditionalCameraData universalAdditionalCameraData = _Camera.GetUniversalAdditionalCameraData();
			universalAdditionalCameraData.renderShadows = false;
			universalAdditionalCameraData.requiresColorTexture = false;
			universalAdditionalCameraData.requiresDepthTexture = false;
			universalAdditionalCameraData.renderPostProcessing = false;
			universalAdditionalCameraData.allowXRRendering = false;
		}
	}
}
