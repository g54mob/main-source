#define d_UnityURP
#define UNITY_2022_3_OR_NEWER
using System;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class UnderwaterRenderer : Versioned, MaskRenderer.IMaskReceiver, MaskRenderer.IMaskProvider
	{
		[Serializable]
		private sealed class DebugFields
		{
			[SerializeField]
			internal bool _VisualizeMask;

			[HideInInspector]
			[SerializeField]
			internal bool _DisableMask;

			[SerializeField]
			internal bool _VisualizeStencil;

			[SerializeField]
			internal bool _DisableHeightAboveWaterOptimization;

			[HideInInspector]
			[SerializeField]
			internal bool _DisableArtifactCorrection;

			[SerializeField]
			internal bool _OnlyReflectionCameras;
		}

		internal static class ShaderIDs
		{
			public static readonly int s_CameraColorTexture = Shader.PropertyToID("_Crest_CameraColorTexture");

			public static readonly int s_WaterVolumeStencil = Shader.PropertyToID("_Crest_WaterVolumeStencil");

			public static readonly int s_AmbientLighting = Shader.PropertyToID("_Crest_AmbientLighting");

			public static readonly int s_ExtinctionMultiplier = Shader.PropertyToID("_Crest_ExtinctionMultiplier");

			public static readonly int s_UnderwaterEnvironmentalLightingWeight = Shader.PropertyToID("_Crest_UnderwaterEnvironmentalLightingWeight");

			public static readonly int s_OutScatteringFactor = Shader.PropertyToID("_Crest_OutScatteringFactor");

			public static readonly int s_OutScatteringExtinctionFactor = Shader.PropertyToID("_Crest_OutScatteringExtinctionFactor");

			public static readonly int s_SunBoost = Shader.PropertyToID("_Crest_SunBoost");

			public static readonly int s_DataSliceOffset = Shader.PropertyToID("_Crest_DataSliceOffset");

			public static readonly int s_FarPlaneOffset = Shader.PropertyToID("_Crest_FarPlaneOffset");
		}

		internal enum EffectPass
		{
			FullScreen = 0,
			Reflections = 1
		}

		private sealed class UnderwaterSphericalHarmonicsData
		{
			internal Color[] _AmbientLighting = new Color[1];

			internal Vector3[] _DirectionsSH = new Vector3[1]
			{
				new Vector3(0f, 0f, 0f)
			};
		}

		internal const float k_CullLimitMinimum = 1E-06f;

		internal const float k_CullLimitMaximum = 0.01f;

		[Tooltip("Whether the underwater effect is enabled.\n\nAllocates/releases resources if state has changed.")]
		[SerializeField]
		internal bool _Enabled = true;

		[Tooltip("Any camera or probe with this layer in its culling mask will render underwater.")]
		[SerializeField]
		private int _Layer = 4;

		[Tooltip("The underwater material. The water surface material is copied into this material.")]
		[SerializeField]
		internal Material _Material;

		[Tooltip("Provides out-scattering based on the camera's underwater depth.\n\nIt scales down environmental lighting (sun, reflections, ambient etc) with the underwater depth. This works with vanilla lighting, but uncommon or custom lighting will require a custom solution (use this for reference)")]
		[SerializeField]
		internal bool _EnvironmentalLightingEnable;

		[Tooltip("How much this effect applies.\n\nValues less than 1 attenuate light less underwater. Value of 1 is physically based.")]
		[SerializeField]
		internal float _EnvironmentalLightingWeight = 1f;

		[Tooltip("This profile will be weighed in the deeper underwater the camera goes.")]
		[SerializeField]
		private VolumeProfile _EnvironmentalLightingVolumeProfile;

		private Volume _EnvironmentalLightingVolume;

		[Tooltip("Rules to exclude cameras from rendering underwater.\n\nThese are exclusion rules, so for all cameras, select Nothing. These rules are applied on top of the Layer rules.")]
		[SerializeField]
		internal WaterCameraExclusion _CameraExclusions = WaterCameraExclusion.Hidden | WaterCameraExclusion.Reflection;

		[Tooltip("Copying parameters each frame ensures underwater appearance stays consistent with the water surface.\n\nHas a small overhead so should be disabled if not needed.")]
		[SerializeField]
		private bool _CopyWaterMaterialParametersEachFrame = true;

		[HideInInspector]
		[Tooltip("Adjusts the far plane for horizon line calculation. Helps with horizon line issue.")]
		[SerializeField]
		private float _FarPlaneMultiplier = 0.68f;

		[Tooltip("Whether to enable culling of water chunks when below water.")]
		[SerializeField]
		private bool _EnableChunkCulling = true;

		[Tooltip("Proportion of visibility below which the water surface will be culled when underwater.\n\nThe larger the number, the closer to the camera the water tiles will be culled.")]
		[SerializeField]
		internal float _CullLimit = 0.001f;

		[SerializeField]
		private DebugFields _Debug = new DebugFields();

		internal WaterRenderer _Water;

		private int _MaterialLastUpdatedFrame = -1;

		private Material _SurfaceMaterial;

		private Material _VolumeMaterial;

		private readonly SampleCollisionHelper _SamplingHeightHelper = new SampleCollisionHelper();

		private float _ViewerWaterHeight;

		[Obsolete("Please use Camera Exclusion instead.")]
		[Tooltip("Whether to execute for all cameras.\n\nIf disabled, then additionally ignore any camera that is not the view camera or our reflection camera. It will require managing culling masks of all cameras.")]
		[SerializeField]
		[HideInInspector]
		private bool _AllCameras;

		internal const string k_ShaderNameEffect = "Crest/Underwater";

		internal const string k_DrawVolume = "Crest.DrawWater/Volume";

		private const string k_KeywordDebugVisualizeMask = "_DEBUG_VISUALIZE_MASK";

		private const string k_KeywordDebugVisualizeStencil = "_DEBUG_VISUALIZE_STENCIL";

		internal const string k_SampleSphericalHarmonicsMarker = "Crest.UnderwaterRenderer.SampleSphericalHarmonics";

		private static readonly ProfilerMarker s_SampleSphericalHarmonicsMarker = new ProfilerMarker("Crest.UnderwaterRenderer.SampleSphericalHarmonics");

		private CommandBuffer _EffectCommandBuffer;

		private Material _CurrentWaterMaterial;

		private readonly UnderwaterSphericalHarmonicsData _SphericalHarmonicsData = new UnderwaterSphericalHarmonicsData();

		private Action<CommandBuffer> _CopyColor;

		private Action<CommandBuffer> _SetRenderTargetToBackBuffers;

		private RenderTargetIdentifier _ColorTarget = new RenderTargetIdentifier(BuiltinRenderTextureType.CameraTarget, 0, CubemapFace.Unknown, -1);

		private RenderTargetIdentifier _DepthStencilTarget = new RenderTargetIdentifier(ShaderIDs.s_WaterVolumeStencil, 0, CubemapFace.Unknown, -1);

		private RenderTargetIdentifier _ColorCopyTarget = new RenderTargetIdentifier(ShaderIDs.s_CameraColorTexture, 0, CubemapFace.Unknown, -1);

		private const float k_DepthOutScattering = 0.25f;

		private Light _EnvironmentalLight;

		private float _EnvironmentalLightIntensity;

		private float _EnvironmentalAmbientIntensity;

		private float _EnvironmentalReflectionIntensity;

		private float _EnvironmentalFogDensity;

		private float _EnvironmentalAverageDensity;

		private bool _EnvironmentalInitialized;

		private bool _EnvironmentalNeedsRestoring;

		private bool _HasEffectCommandBuffersBeenRegistered;

		internal const string k_DrawMask = "Crest.DrawMask";

		private const string k_DrawMaskHorizon = "Horizon";

		private const string k_DrawMaskSurface = "Surface";

		internal const int k_VolumeMaskQueue = 1000;

		internal const int k_ShaderPassWaterSurfaceMask = 0;

		internal const int k_ShaderPassWaterSurfaceDepth = 1;

		internal const int k_ShaderPassWaterHorizonMask = 0;

		internal const string k_ComputeShaderKernelFillMaskArtefacts = "FillMaskArtefacts";

		internal Material _MaskMaterial;

		internal Material _HorizonMaskMaterial;

		private ComputeShader _ArtifactsShader;

		private bool _ArtifactsShaderInitialized;

		private int _ArtifactsKernel;

		private uint _ArtifactsThreadGroupSizeX;

		private uint _ArtifactsThreadGroupSizeY;

		internal bool _MaskRead;

		[Obsolete("Please use Camera Exclusion instead.")]
		public bool AllCameras
		{
			get
			{
				return _AllCameras;
			}
			set
			{
				_AllCameras = value;
			}
		}

		public WaterCameraExclusion CameraExclusions
		{
			get
			{
				return _CameraExclusions;
			}
			set
			{
				_CameraExclusions = value;
			}
		}

		public bool CopyWaterMaterialParametersEachFrame
		{
			get
			{
				return _CopyWaterMaterialParametersEachFrame;
			}
			set
			{
				_CopyWaterMaterialParametersEachFrame = value;
			}
		}

		public float CullLimit
		{
			get
			{
				return _CullLimit;
			}
			set
			{
				_CullLimit = value;
			}
		}

		public bool EnableChunkCulling
		{
			get
			{
				return _EnableChunkCulling;
			}
			set
			{
				_EnableChunkCulling = value;
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

		public bool AffectsEnvironmentalLighting
		{
			get
			{
				return _EnvironmentalLightingEnable;
			}
			set
			{
				SetAffectsEnvironmentalLighting(_EnvironmentalLightingEnable, _EnvironmentalLightingEnable = value);
			}
		}

		public float EnvironmentalLightingWeight
		{
			get
			{
				return _EnvironmentalLightingWeight;
			}
			set
			{
				_EnvironmentalLightingWeight = value;
			}
		}

		public float FarPlaneMultiplier
		{
			get
			{
				return _FarPlaneMultiplier;
			}
			set
			{
				_FarPlaneMultiplier = value;
			}
		}

		public int Layer
		{
			get
			{
				return _Layer;
			}
			set
			{
				_Layer = value;
			}
		}

		public Material Material
		{
			get
			{
				return _Material;
			}
			set
			{
				_Material = value;
			}
		}

		public static Action<WaterRenderer, Material> AfterCopyMaterial { get; set; }

		internal bool UseLegacyMask => false;

		internal bool RenderBeforeTransparency => true;

		private bool Portaled => _Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Portal);

		internal bool UseStencilBuffer { get; set; }

		internal bool RequiresFullScreenMask { get; set; }

		internal bool NeedsColorTexture { get; set; }

		internal void OnEnable()
		{
			_VolumeMaterial = _Material;
			if (_MaskMaterial == null)
			{
				_MaskMaterial = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._UnderwaterMask);
			}
			if (_HorizonMaskMaterial == null)
			{
				_HorizonMaskMaterial = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._HorizonMask);
			}
			if (_ArtifactsShader == null)
			{
				_ArtifactsShader = ScriptableSingleton<WaterResources>.Instance.Compute._UnderwaterArtifacts;
			}
			OnEnableMask();
			if (RenderPipelineHelper.IsUniversal)
			{
				UnderwaterEffectPassURP.Enable(this);
			}
			else if (!RenderPipelineHelper.IsHighDefinition)
			{
				OnEnableLegacy();
			}
			EnableEnvironmentalLighting();
			RenderPipelineManager.activeRenderPipelineTypeChanged -= OnActiveRenderPipelineTypeChanged;
			RenderPipelineManager.activeRenderPipelineTypeChanged += OnActiveRenderPipelineTypeChanged;
		}

		private void OnActiveRenderPipelineTypeChanged()
		{
			if (_Water.isActiveAndEnabled)
			{
				OnEnable();
			}
		}

		internal void OnDisable()
		{
			RenderPipelineManager.activeRenderPipelineTypeChanged -= OnActiveRenderPipelineTypeChanged;
			OnDisableMask();
			UnderwaterEffectPassURP.Disable();
			OnDisableLegacy();
			DisableEnvironmentalLighting();
			_ArtifactsShader = null;
		}

		internal void OnDestroy()
		{
			Helpers.Destroy(_MaskMaterial);
			Helpers.Destroy(_HorizonMaskMaterial);
			_MaskMaterial = null;
			_HorizonMaskMaterial = null;
		}

		internal bool ShouldRender(Camera camera)
		{
			UseStencilBuffer = false;
			NeedsColorTexture = false;
			RequiresFullScreenMask = true;
			if (!_Enabled || _Material == null)
			{
				return false;
			}
			if (!WaterRenderer.ShouldRender(camera, _Layer))
			{
				return false;
			}
			if (_Debug._OnlyReflectionCameras && camera.cameraType != CameraType.Reflection)
			{
				return false;
			}
			if (camera != _Water.Reflections.ReflectionCamera && !WaterRenderer.ShouldRender(camera, _CameraExclusions))
			{
				return false;
			}
			WaterRenderer.ActiveModules activeModules = _Water._ActiveModules;
			if (!_Debug._DisableHeightAboveWaterOptimization && !Portaled && activeModules.HasFlag(WaterRenderer.ActiveModules.Surface))
			{
				_Water.UpdatePerCameraHeight(camera);
				_ViewerWaterHeight = _Water._ViewerHeightAboveWaterPerCamera;
				if (_ViewerWaterHeight > 2f)
				{
					return false;
				}
			}
			return true;
		}

		internal void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			OnBeginCameraRendering(camera);
			if (RenderPipelineHelper.IsUniversal)
			{
				UnderwaterEffectPassURP.s_Instance?.EnqueuePass(context, camera);
			}
			else
			{
				OnBeforeLegacyRender(camera);
			}
		}

		internal void OnBeginCameraRendering(Camera camera)
		{
			_SurfaceMaterial = _Water.Surface.AboveOrBelowSurfaceMaterial;
			_VolumeMaterial = _Material;
			Vector3 position = camera.transform.position;
			foreach (WaterBody waterBody in WaterBody.WaterBodies)
			{
				if (waterBody.AboveOrBelowSurfaceMaterial == null && waterBody._VolumeMaterial == null)
				{
					continue;
				}
				Bounds aABB = waterBody.AABB;
				if (position.x >= aABB.min.x && position.x <= aABB.max.x && position.z >= aABB.min.z && position.z <= aABB.max.z)
				{
					if (waterBody.AboveOrBelowSurfaceMaterial != null)
					{
						_SurfaceMaterial = waterBody.AboveOrBelowSurfaceMaterial;
					}
					if (waterBody.VolumeMaterial != null)
					{
						_VolumeMaterial = waterBody.VolumeMaterial;
					}
					break;
				}
			}
			Vector3 vector = Vector3.zero;
			float num = 0f;
			if (_SurfaceMaterial != null)
			{
				float num2 = _VolumeMaterial.GetFloat(ShaderIDs.s_ExtinctionMultiplier);
				if (_SurfaceMaterial.HasVector(WaterRenderer.ShaderIDs.s_Absorption))
				{
					vector = _SurfaceMaterial.GetVector(WaterRenderer.ShaderIDs.s_Absorption);
					Shader.SetGlobalVector(WaterRenderer.ShaderIDs.s_Absorption, vector);
				}
				if (_SurfaceMaterial.HasProperty(WaterRenderer.ShaderIDs.s_Scattering))
				{
					Vector3 vector2 = vector + _SurfaceMaterial.GetVector(WaterRenderer.ShaderIDs.s_Scattering).XYZ();
					vector2 *= num2;
					num = Mathf.Min(Mathf.Min(vector2.x, vector2.y), vector2.z);
					Shader.SetGlobalFloat(WaterRenderer.ShaderIDs.s_VolumeExtinctionLength, (0f - Mathf.Log(1E-06f)) / num);
				}
				vector *= num2;
				num = Mathf.Min(Mathf.Min(vector.x, vector.y), vector.z);
				num = Mathf.Max(num, 0.0001f);
			}
			if (_EnvironmentalInitialized)
			{
				_Water.UpdatePerCameraHeight(camera);
				_ViewerWaterHeight = _Water._ViewerHeightAboveWaterPerCamera;
				UpdateEnvironmentalLighting(camera, vector, _ViewerWaterHeight);
			}
			if (!_EnableChunkCulling || !_Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Surface) || Portaled || _ViewerWaterHeight > -5f)
			{
				return;
			}
			float num3 = (0f - Mathf.Log(_CullLimit)) / num;
			foreach (WaterChunkRenderer chunk in _Water.Surface.Chunks)
			{
				if (!(chunk.Rend == null) && !chunk._Culled)
				{
					if ((position - chunk.Rend.bounds.ClosestPoint(position)).magnitude >= num3)
					{
						chunk.Rend.enabled = false;
					}
					else
					{
						chunk.Rend.enabled = true;
					}
				}
			}
		}

		internal void OnEndCameraRendering(Camera camera)
		{
			RestoreEnvironmentalLighting();
			if (RenderPipelineHelper.IsLegacy)
			{
				OnAfterLegacyRender(camera);
			}
		}

		internal void ExecuteHeightField(Camera camera)
		{
			if (!UseLegacyMask && RequiresFullScreenMask && _Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Surface))
			{
				_Water.Surface.UpdateDisplacedSurfaceData(camera);
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

		private void SetAffectsEnvironmentalLighting(bool previous, bool current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled && _Enabled)
			{
				if (_EnvironmentalLightingEnable)
				{
					EnableEnvironmentalLighting();
				}
				else
				{
					DisableEnvironmentalLighting();
				}
			}
		}

		private void SetRenderTargetToBackBuffers(CommandBuffer commands)
		{
			commands.SetRenderTarget(_ColorTarget);
		}

		private void CopyColorTexture(CommandBuffer buffer)
		{
			buffer.Blit(BuiltinRenderTextureType.CameraTarget, _ColorCopyTarget);
			if (UseStencilBuffer)
			{
				_EffectCommandBuffer.SetRenderTarget(_ColorTarget, _DepthStencilTarget);
			}
			else
			{
				_EffectCommandBuffer.SetRenderTarget(_ColorTarget);
			}
		}

		private void SetupUnderwaterEffect()
		{
			if (_EffectCommandBuffer == null)
			{
				_EffectCommandBuffer = new CommandBuffer
				{
					name = "Crest.DrawWater/Volume"
				};
			}
			if (_CopyColor == null)
			{
				_CopyColor = CopyColorTexture;
			}
			if (_SetRenderTargetToBackBuffers == null)
			{
				_SetRenderTargetToBackBuffers = SetRenderTargetToBackBuffers;
			}
		}

		private void OnPreRenderUnderwaterEffect(Camera camera)
		{
			RenderTextureDescriptor descriptor = Rendering.BIRP.GetCameraTargetDescriptor(camera, _Water.FrameBufferFormatOverride);
			descriptor.useDynamicScale = camera.allowDynamicResolution;
			UpdateEffectMaterial(camera);
			_EffectCommandBuffer.Clear();
			if (!RenderBeforeTransparency || NeedsColorTexture)
			{
				_EffectCommandBuffer.GetTemporaryRT(ShaderIDs.s_CameraColorTexture, descriptor);
				_EffectCommandBuffer.SetGlobalTexture(ShaderIDs.s_CameraColorTexture, _ColorCopyTarget);
			}
			Light sun = RenderSettings.sun;
			if (sun != null)
			{
				_EffectCommandBuffer.SetGlobalVector(WaveHarmonic.Crest.ShaderIDs.Unity.s_LightColor0, sun.FinalColor());
				_EffectCommandBuffer.SetGlobalVector(WaveHarmonic.Crest.ShaderIDs.Unity.s_WorldSpaceLightPos0, -sun.transform.forward);
				_EffectCommandBuffer.SetShaderKeyword("DIRECTIONAL_COOKIE", sun.cookie != null);
			}
			if (UseStencilBuffer)
			{
				descriptor.colorFormat = RenderTextureFormat.Depth;
				descriptor.depthBufferBits = (int)Rendering.GetDefaultDepthBufferBits();
				descriptor.SetMSAASamples(camera);
				descriptor.bindMS = descriptor.msaaSamples > 1;
				_EffectCommandBuffer.GetTemporaryRT(ShaderIDs.s_WaterVolumeStencil, descriptor);
				if (Helpers.IsMSAAEnabled(camera))
				{
					Helpers.Blit(_EffectCommandBuffer, _DepthStencilTarget, Rendering.BIRP.UtilityMaterial, 0);
				}
				else
				{
					_EffectCommandBuffer.CopyTexture(BuiltinRenderTextureType.Depth, _DepthStencilTarget);
					CoreUtils.SetRenderTarget(_EffectCommandBuffer, _DepthStencilTarget);
				}
				if (RenderBeforeTransparency)
				{
					_EffectCommandBuffer.SetRenderTarget(BuiltinRenderTextureType.CameraTarget, _DepthStencilTarget);
				}
			}
			if (!RenderBeforeTransparency)
			{
				CopyColorTexture(_EffectCommandBuffer);
			}
			ExecuteEffect(camera, _EffectCommandBuffer, _CopyColor, _SetRenderTargetToBackBuffers);
			if (!RenderBeforeTransparency || NeedsColorTexture)
			{
				_EffectCommandBuffer.ReleaseTemporaryRT(ShaderIDs.s_CameraColorTexture);
			}
			if (UseStencilBuffer)
			{
				_EffectCommandBuffer.ReleaseTemporaryRT(ShaderIDs.s_WaterVolumeStencil);
			}
		}

		internal void ExecuteEffect(Camera camera, CommandBuffer buffer, Action<CommandBuffer> copyColor, Action<CommandBuffer> resetRenderTargets, MaterialPropertyBlock properties = null)
		{
			if (true)
			{
				buffer.DrawProcedural(Matrix4x4.identity, _VolumeMaterial, (camera.cameraType == CameraType.Reflection) ? 1 : 0, MeshTopology.Triangles, 3, 1, properties);
			}
		}

		internal static void UpdateGlobals(Material source)
		{
			Shader.SetGlobalColor(WaterRenderer.ShaderIDs.s_Scattering, source.GetColor(WaterRenderer.ShaderIDs.s_Scattering).MaybeLinear());
			Shader.SetGlobalFloat(WaterRenderer.ShaderIDs.s_Anisotropy, source.GetFloat(WaterRenderer.ShaderIDs.s_Anisotropy));
			Shader.SetGlobalFloat(WaterRenderer.ShaderIDs.s_AmbientTerm, source.GetFloat(WaterRenderer.ShaderIDs.s_AmbientTerm));
			Shader.SetGlobalFloat(WaterRenderer.ShaderIDs.s_DirectTerm, source.GetFloat(WaterRenderer.ShaderIDs.s_DirectTerm));
			Shader.SetGlobalFloat(WaterRenderer.ShaderIDs.s_ShadowsAffectsAmbientFactor, source.GetFloat(WaterRenderer.ShaderIDs.s_ShadowsAffectsAmbientFactor));
			Shader.SetGlobalFloat(ShaderIDs.s_ExtinctionMultiplier, source.GetFloat(ShaderIDs.s_ExtinctionMultiplier));
			Shader.SetGlobalFloat(ShaderIDs.s_OutScatteringFactor, source.GetFloat(ShaderIDs.s_OutScatteringFactor));
			Shader.SetGlobalFloat(ShaderIDs.s_OutScatteringExtinctionFactor, source.GetFloat(ShaderIDs.s_OutScatteringExtinctionFactor));
			Shader.SetGlobalFloat(ShaderIDs.s_SunBoost, source.GetFloat(ShaderIDs.s_SunBoost));
			Shader.SetGlobalInteger(ShaderIDs.s_DataSliceOffset, source.GetInteger(ShaderIDs.s_DataSliceOffset));
		}

		internal void UpdateEffectMaterial(Camera camera)
		{
			if (_MaterialLastUpdatedFrame < Time.frameCount || WaterBody.WaterBodies.Count > 0)
			{
				if (_CopyWaterMaterialParametersEachFrame || _SurfaceMaterial != _CurrentWaterMaterial)
				{
					_CurrentWaterMaterial = _SurfaceMaterial;
					if (_SurfaceMaterial != null)
					{
						_VolumeMaterial.CopyMatchingPropertiesFromMaterial(_SurfaceMaterial);
						AfterCopyMaterial?.Invoke(_Water, _VolumeMaterial);
						if (RenderBeforeTransparency)
						{
							UpdateGlobals(_VolumeMaterial);
						}
					}
				}
				_VolumeMaterial.SetKeyword("_DEBUG_VISUALIZE_MASK", _Debug._VisualizeMask);
				_VolumeMaterial.SetKeyword("_DEBUG_VISUALIZE_STENCIL", _Debug._VisualizeStencil);
				_VolumeMaterial.SetInteger(Lod.ShaderIDs.s_LodIndex, 0);
				_MaterialLastUpdatedFrame = Time.frameCount;
			}
			if (camera.cameraType != CameraType.Reflection)
			{
				bool enabled = !_MaskRead || (_Water._PerCameraHeightReady && _Water._ViewerHeightAboveWaterPerCamera < -8f && !Portaled);
				_VolumeMaterial.SetKeyword("d_Crest_NoMaskColor", enabled);
				_VolumeMaterial.SetKeyword("d_Crest_NoMaskDepth", !_MaskRead || RenderBeforeTransparency);
			}
			LightProbes.GetInterpolatedProbe(camera.transform.position, null, out var probe);
			probe.Evaluate(_SphericalHarmonicsData._DirectionsSH, _SphericalHarmonicsData._AmbientLighting);
			Helpers.SetShaderVector(_VolumeMaterial, ShaderIDs.s_AmbientLighting, _SphericalHarmonicsData._AmbientLighting[0], RenderBeforeTransparency);
		}

		private void EnableEnvironmentalLighting()
		{
			if (_EnvironmentalLightingEnable)
			{
				if (_EnvironmentalLightingVolume == null && !RenderPipelineHelper.IsLegacy)
				{
					GameObject gameObject = new GameObject();
					gameObject.transform.parent = _Water.Container.transform;
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					gameObject.name = "Underwater Lighting Volume";
					_EnvironmentalLightingVolume = gameObject.AddComponent<Volume>();
					_EnvironmentalLightingVolume.weight = 0f;
					_EnvironmentalLightingVolume.priority = 1000f;
					_EnvironmentalLightingVolume.profile = _EnvironmentalLightingVolumeProfile;
				}
				_EnvironmentalInitialized = true;
			}
		}

		private void DisableEnvironmentalLighting()
		{
			RestoreEnvironmentalLighting();
			_EnvironmentalInitialized = false;
		}

		private void RestoreEnvironmentalLighting()
		{
			if (_EnvironmentalInitialized && _EnvironmentalNeedsRestoring)
			{
				if (_EnvironmentalLight != null)
				{
					_EnvironmentalLight.intensity = _EnvironmentalLightIntensity;
				}
				_EnvironmentalLight = null;
				RenderSettings.ambientIntensity = _EnvironmentalAmbientIntensity;
				RenderSettings.reflectionIntensity = _EnvironmentalReflectionIntensity;
				RenderSettings.fogDensity = _EnvironmentalFogDensity;
				Shader.SetGlobalFloat(ShaderIDs.s_UnderwaterEnvironmentalLightingWeight, 0f);
				if (_EnvironmentalLightingVolume != null)
				{
					_EnvironmentalLightingVolume.weight = 0f;
				}
				_EnvironmentalNeedsRestoring = false;
			}
		}

		private void UpdateEnvironmentalLighting(Camera camera, Vector3 extinction, float height)
		{
			if (_EnvironmentalInitialized && _Water.Surface.Material.HasColor(WaterRenderer.ShaderIDs.s_AbsorptionColor))
			{
				_EnvironmentalLight = _Water.PrimaryLight;
				if ((bool)_EnvironmentalLight)
				{
					_EnvironmentalLightIntensity = _EnvironmentalLight.intensity;
				}
				_EnvironmentalAmbientIntensity = RenderSettings.ambientIntensity;
				_EnvironmentalReflectionIntensity = RenderSettings.reflectionIntensity;
				_EnvironmentalFogDensity = RenderSettings.fogDensity;
				Vector3 vector = extinction;
				_EnvironmentalAverageDensity = (vector.x + vector.y + vector.z) / 3f;
				float num = 1f;
				if (_VolumeMaterial.HasFloat(ShaderIDs.s_OutScatteringFactor))
				{
					num = _VolumeMaterial.GetFloat(ShaderIDs.s_OutScatteringFactor);
				}
				float num2 = Mathf.Exp(_EnvironmentalAverageDensity * Mathf.Min(height * 0.25f * num, 0f) * _EnvironmentalLightingWeight);
				if (_EnvironmentalLight != null)
				{
					_EnvironmentalLight.intensity = Mathf.Lerp(0f, _EnvironmentalLightIntensity, num2);
				}
				RenderSettings.ambientIntensity = Mathf.Lerp(0f, _EnvironmentalAmbientIntensity, num2);
				RenderSettings.reflectionIntensity = Mathf.Lerp(0f, _EnvironmentalReflectionIntensity, num2);
				RenderSettings.fogDensity = Mathf.Lerp(0f, _EnvironmentalFogDensity, num2);
				Shader.SetGlobalFloat(ShaderIDs.s_UnderwaterEnvironmentalLightingWeight, 1f - num2);
				if (_EnvironmentalLightingVolume != null)
				{
					_EnvironmentalLightingVolume.weight = 1f - num2;
				}
				_EnvironmentalNeedsRestoring = true;
			}
		}

		private void OnEnableLegacy()
		{
			SetupUnderwaterEffect();
			RenderPipelineManager.activeRenderPipelineTypeChanged -= OnDisableLegacy;
			RenderPipelineManager.activeRenderPipelineTypeChanged += OnDisableLegacy;
		}

		private void OnDisableLegacy()
		{
			RenderPipelineManager.activeRenderPipelineTypeChanged -= OnDisableLegacy;
		}

		private void OnBeforeLegacyRender(Camera camera)
		{
			if (_Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Volume))
			{
				_Water.UpdateMatrices(camera);
				_Water.OnBeginCameraOpaqueTexture(camera);
				CameraEvent evt = (RenderBeforeTransparency ? CameraEvent.BeforeForwardAlpha : CameraEvent.AfterForwardAlpha);
				camera.AddCommandBuffer(evt, _EffectCommandBuffer);
				OnPreRenderUnderwaterEffect(camera);
				_HasEffectCommandBuffersBeenRegistered = true;
			}
		}

		private void OnAfterLegacyRender(Camera camera)
		{
			if (_HasEffectCommandBuffersBeenRegistered)
			{
				CameraEvent evt = (RenderBeforeTransparency ? CameraEvent.BeforeForwardAlpha : CameraEvent.AfterForwardAlpha);
				camera.RemoveCommandBuffer(evt, _EffectCommandBuffer);
				_EffectCommandBuffer?.Clear();
			}
			_Water.OnEndCameraOpaqueTexture(camera);
			_HasEffectCommandBuffersBeenRegistered = false;
		}

		internal void OnEnableMask()
		{
			_Water._Mask.Add(this);
			_Water._Mask.Add(1000, this);
			SetUpArtifactsShader();
		}

		internal void OnDisableMask()
		{
			if (!(_Water == null))
			{
				_Water._Mask?.Remove((MaskRenderer.IMaskReceiver)this);
				_Water._Mask?.Remove((MaskRenderer.IMaskProvider)this);
			}
		}

		internal void SetUpArtifactsShader()
		{
			if (!_ArtifactsShaderInitialized)
			{
				_ArtifactsKernel = _ArtifactsShader.FindKernel("FillMaskArtefacts");
				_ArtifactsShader.GetKernelThreadGroupSizes(_ArtifactsKernel, out _ArtifactsThreadGroupSizeX, out _ArtifactsThreadGroupSizeY, out var _);
				_ArtifactsShaderInitialized = true;
			}
		}

		void MaskRenderer.IMaskProvider.OnMaskPass(CommandBuffer commands, Camera camera, MaskRenderer mask)
		{
			RTHandle colorRTH = mask.ColorRTH;
			RTHandle depthRTH = mask.DepthRTH;
			Vector2Int scaledSize = colorRTH.GetScaledSize(colorRTH.rtHandleProperties.currentViewportSize);
			RenderTextureDescriptor descriptor = colorRTH.rt.descriptor;
			descriptor.width = scaledSize.x;
			descriptor.height = scaledSize.y;
			if (UseLegacyMask)
			{
				CoreUtils.SetRenderTarget(commands, colorRTH, depthRTH, UseStencilBuffer ? ClearFlag.Color : ClearFlag.DepthStencil);
				Helpers.ScaleViewport(camera, commands, colorRTH);
				PopulateMask(commands, camera);
				FixMaskArtefacts(commands, descriptor, mask._ColorRTI);
			}
			else if (RequiresFullScreenMask)
			{
				RenderLineMask(commands, camera, mask.ColorRT.descriptor, mask._ColorRTI);
			}
		}

		internal void RenderLineMask(CommandBuffer buffer, Camera camera, RenderTextureDescriptor descriptor, RenderTargetIdentifier target)
		{
			if (_Water.Surface.Enabled)
			{
				bool value = false;
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, ScriptableSingleton<WaterResources>.Instance.Compute._Mask, (int)RenderPipelineHelper.RenderPipeline);
				SurfaceRenderer.SurfaceDataParameters surfaceDataParameters = _Water.Surface._SurfaceDataParameters;
				propertyWrapperCompute.SetTexture(SurfaceRenderer.ShaderIDs.s_WaterLine, _Water.Surface.HeightRT);
				propertyWrapperCompute.SetVector(SurfaceRenderer.ShaderIDs.s_WaterLineSnappedPosition, surfaceDataParameters._SnappedPosition);
				propertyWrapperCompute.SetVector(SurfaceRenderer.ShaderIDs.s_WaterLineResolution, surfaceDataParameters._Resolution);
				propertyWrapperCompute.SetFloat(SurfaceRenderer.ShaderIDs.s_WaterLineTexel, surfaceDataParameters._Texel);
				propertyWrapperCompute.SetKeyword(new LocalKeyword(ScriptableSingleton<WaterResources>.Instance.Compute._Mask, "d_KeepValue"), value);
				propertyWrapperCompute.SetMatrix(WaveHarmonic.Crest.ShaderIDs.Unity.s_CameraToWorld, camera.cameraToWorldMatrix);
				propertyWrapperCompute.Dispatch(Mathf.CeilToInt((float)descriptor.width / 8f), Mathf.CeilToInt((float)descriptor.height / 8f), descriptor.volumeDepth);
			}
		}

		internal void FixMaskArtefacts(CommandBuffer buffer, RenderTextureDescriptor descriptor, RenderTargetIdentifier target)
		{
			if (!_Debug._DisableArtifactCorrection && (_Water.Surface.Enabled || !Portaled))
			{
				_ArtifactsShader.SetKeyword(new LocalKeyword(_ArtifactsShader, "STEREO_INSTANCING_ON"), descriptor.dimension == TextureDimension.Tex2DArray);
				buffer.SetComputeTextureParam(_ArtifactsShader, _ArtifactsKernel, MaskRenderer.ShaderIDs.s_WaterMaskTexture, target);
				buffer.DispatchCompute(_ArtifactsShader, _ArtifactsKernel, Mathf.CeilToInt((float)descriptor.width / (float)_ArtifactsThreadGroupSizeX), Mathf.CeilToInt((float)descriptor.height / (float)_ArtifactsThreadGroupSizeY), descriptor.volumeDepth);
			}
		}

		internal void PopulateMask(CommandBuffer commandBuffer, Camera camera)
		{
			if (_Water.Surface.Enabled || !Portaled)
			{
				Vector4 zBufferParameters = Helpers.GetZBufferParameters(camera);
				_HorizonMaskMaterial.SetFloat(ShaderIDs.s_FarPlaneOffset, Helpers.LinearDepthToNonLinear(_FarPlaneMultiplier, zBufferParameters));
				commandBuffer.BeginSample("Horizon");
				commandBuffer.DrawProcedural(Matrix4x4.identity, _HorizonMaskMaterial, 0, MeshTopology.Triangles, 3, 1);
				commandBuffer.EndSample("Horizon");
				if (!_Debug._DisableMask)
				{
					commandBuffer.BeginSample("Surface");
					_Water.Surface.Render(camera, commandBuffer, _MaskMaterial);
					commandBuffer.EndSample("Surface");
				}
			}
		}

		MaskRenderer.MaskInput MaskRenderer.IMaskProvider.Allocate()
		{
			if (!UseLegacyMask && !UseStencilBuffer)
			{
				return MaskRenderer.MaskInput.Color;
			}
			return MaskRenderer.MaskInput.Both;
		}

		MaskRenderer.MaskInput MaskRenderer.IMaskReceiver.Allocate()
		{
			if (!UseLegacyMask && !UseStencilBuffer)
			{
				return MaskRenderer.MaskInput.Color;
			}
			return MaskRenderer.MaskInput.Both;
		}

		MaskRenderer.MaskInput MaskRenderer.IMaskProvider.Write(Camera camera)
		{
			_MaskRead = _Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.SurfaceAndVolume);
			if (!_MaskRead)
			{
				return MaskRenderer.MaskInput.None;
			}
			if (!UseLegacyMask && !UseStencilBuffer)
			{
				return MaskRenderer.MaskInput.Color;
			}
			return MaskRenderer.MaskInput.Both;
		}
	}
}
