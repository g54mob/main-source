using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class ShadowLod : PersistentLod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_DynamicSoftShadowsFactor = Shader.PropertyToID("g_Crest_DynamicSoftShadowsFactor");

			public static readonly int s_SampleColorMap = Shader.PropertyToID("_Crest_SampleColorMap");

			public static readonly int s_CenterPos = Shader.PropertyToID("_Crest_CenterPos");

			public static readonly int s_Scale = Shader.PropertyToID("_Crest_Scale");

			public static readonly int s_JitterDiameters_CurrentFrameWeights = Shader.PropertyToID("_Crest_JitterDiameters_CurrentFrameWeights");

			public static readonly int s_MainCameraProjectionMatrix = Shader.PropertyToID("_Crest_MainCameraProjectionMatrix");

			public static readonly int s_ShadowPassExecuteLastFrame = Shader.PropertyToID("_Crest_ShadowPassExecuteLastFrame");

			public static readonly int s_ClearShadows = Shader.PropertyToID("_Crest_ClearShadows");
		}

		private enum Error
		{
			None = 0,
			NoLight = 1,
			NoShadows = 2,
			IncorrectLightType = 3
		}

		[Tooltip("Whether to vary soft shadow jitter by scattering/absorption density.")]
		[SerializeField]
		private bool _DynamicSoftShadows = true;

		[Tooltip("Factor control for dynamic soft jitter.")]
		[SerializeField]
		private float _SoftJitterExtinctionFactor = 0.75f;

		[Tooltip("Jitter diameter for soft shadows, controls softness of this shadowing component.")]
		[SerializeField]
		internal float _JitterDiameterSoft = 15f;

		[Tooltip("Current frame weight for accumulation over frames for soft shadows.\n\nRoughly means 'responsiveness' for soft shadows.")]
		[SerializeField]
		internal float _CurrentFrameWeightSoft = 0.03f;

		[Tooltip("Jitter diameter for hard shadows, controls softness of this shadowing component.")]
		[SerializeField]
		internal float _JitterDiameterHard = 0.6f;

		[Tooltip("Current frame weight for accumulation over frames for hard shadows.\n\nRoughly means 'responsiveness' for hard shadows.")]
		[SerializeField]
		internal float _CurrentFrameWeightHard = 0.15f;

		[Tooltip("Whether to disable the null light warning, use this if you assign it dynamically and expect it to be null at points")]
		[SerializeField]
		internal bool _AllowNullLight;

		[Tooltip("Whether to disable the no shadows warning. Use this if you toggle the shadows on the primary light dynamically.")]
		[SerializeField]
		internal bool _AllowNoShadows;

		private const string k_DrawLodSample = "Sample";

		private const float k_MaximumJitter = 32f;

		internal static readonly Color s_GizmoColor = new Color(0f, 0f, 0f, 0.5f);

		internal static bool s_ProcessData = true;

		private Light _Light;

		private PropertyWrapperMaterial[] _RenderMaterial;

		private Error _Error;

		private bool _IsSimulationBuffer;

		internal static SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Shadow";

		internal override string Name => "Shadows";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => Color.black;

		private protected override bool NeedToReadWriteTextureData => true;

		internal override int BufferCount => 2;

		internal override bool SkipEndOfFrame => true;

		private protected override GraphicsFormat RequestedTextureFormat => _TextureFormatMode switch
		{
			LodTextureFormatMode.Performance => GraphicsFormat.R8G8_UNorm, 
			LodTextureFormatMode.Precision => GraphicsFormat.R16G16_UNorm, 
			LodTextureFormatMode.Manual => _TextureFormat, 
			_ => throw new NotImplementedException(), 
		};

		internal CommandBuffer CopyShadowMapBuffer { get; private set; }

		private protected override int Kernel => (int)RenderPipelineHelper.RenderPipeline;

		private protected override bool SkipFlipBuffers => true;

		private protected override ComputeShader SimulationShader => ScriptableSingleton<WaterResources>.Instance.Compute._UpdateShadow;

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		public float CurrentFrameWeightHard
		{
			get
			{
				return _CurrentFrameWeightHard;
			}
			set
			{
				_CurrentFrameWeightHard = value;
			}
		}

		public float CurrentFrameWeightSoft
		{
			get
			{
				return _CurrentFrameWeightSoft;
			}
			set
			{
				_CurrentFrameWeightSoft = value;
			}
		}

		public float JitterDiameterHard
		{
			get
			{
				return _JitterDiameterHard;
			}
			set
			{
				_JitterDiameterHard = value;
			}
		}

		public float JitterDiameterSoft
		{
			get
			{
				return _JitterDiameterSoft;
			}
			set
			{
				_JitterDiameterSoft = value;
			}
		}

		internal override void Initialize()
		{
			if (ScriptableSingleton<WaterResources>.Instance.Shaders._UpdateShadow == null)
			{
				_Valid = false;
				return;
			}
			bool flag = false;
			if (RenderPipelineHelper.IsLegacy)
			{
				if (QualitySettings.shadows == UnityEngine.ShadowQuality.Disable)
				{
					flag = true;
				}
			}
			else if (RenderPipelineHelper.IsUniversal)
			{
				UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
				if (universalRenderPipelineAsset.mainLightRenderingMode == LightRenderingMode.Disabled)
				{
					Debug.LogWarning("Crest: Main Light must be enabled to enable water shadowing.", _Water);
					_Valid = false;
					return;
				}
				flag = !universalRenderPipelineAsset.supportsMainLightShadows;
			}
			if (flag)
			{
				Debug.LogWarning("Crest: Shadows must be enabled in the quality settings to enable water shadowing.", _Water);
				_Valid = false;
			}
			else
			{
				base.Initialize();
			}
		}

		internal override void SetGlobals(bool enable)
		{
			base.SetGlobals(enable);
			Shader.SetGlobalFloat(ShaderIDs.s_DynamicSoftShadowsFactor, 1f);
			if (RenderPipelineHelper.IsLegacy)
			{
				Helpers.SetGlobalBoolean(ShaderIDs.s_ShadowPassExecuteLastFrame, value: true);
			}
		}

		internal override void Enable()
		{
			base.Enable();
			CleanUpShadowCommandBuffers();
			if (!RenderPipelineHelper.IsHighDefinition && RenderPipelineHelper.IsUniversal)
			{
				SampleShadowsURP.Enable(_Water);
			}
		}

		internal override void Disable()
		{
			base.Disable();
			CleanUpShadowCommandBuffers();
			Shader.SetGlobalFloat(ShaderIDs.s_DynamicSoftShadowsFactor, 1f);
		}

		internal override void Destroy()
		{
			base.Destroy();
			for (int i = 0; i < _RenderMaterial.Length; i++)
			{
				Helpers.Destroy(_RenderMaterial[i].Material);
			}
		}

		private protected override void Allocate()
		{
			base.Allocate();
			_RenderMaterial = new PropertyWrapperMaterial[base.Slices];
			Shader updateShadow = ScriptableSingleton<WaterResources>.Instance.Shaders._UpdateShadow;
			for (int i = 0; i < _RenderMaterial.Length; i++)
			{
				_RenderMaterial[i] = new PropertyWrapperMaterial(updateShadow);
				_RenderMaterial[i].SetInteger(Lod.ShaderIDs.s_LodIndex, i);
			}
			if (!RenderPipelineHelper.IsHighDefinition && RenderPipelineHelper.IsUniversal)
			{
				SampleShadowsURP.Enable(_Water);
			}
		}

		private bool ValidateLight()
		{
			if (_Light == null)
			{
				if (!_AllowNullLight)
				{
					if (_Error != Error.NoLight)
					{
						Debug.LogWarning("Crest: Primary light must be specified on WaterRenderer script to enable shadows.", _Water);
						_Error = Error.NoLight;
					}
					return false;
				}
				return true;
			}
			if (_Light.shadows == LightShadows.None && !_AllowNoShadows)
			{
				if (_Error != Error.NoShadows)
				{
					Debug.LogWarning("Crest: Shadows must be enabled on primary light to enable water shadowing (types Hard and Soft are equivalent for the water system).", _Light);
					_Error = Error.NoShadows;
				}
				return false;
			}
			if (_Light.type != LightType.Directional)
			{
				if (_Error != Error.IncorrectLightType)
				{
					Debug.LogWarning("Crest: Primary light must be of type Directional.", _Light);
					_Error = Error.IncorrectLightType;
				}
				return false;
			}
			_Error = Error.None;
			return true;
		}

		private bool SetUpLight()
		{
			if (_Light == null)
			{
				_Light = _Water.PrimaryLight;
				if (_Light == null)
				{
					return false;
				}
			}
			if (_Light.shadows == LightShadows.None)
			{
				return false;
			}
			return true;
		}

		private void ClearBufferIfLightChanged()
		{
			if (_Light != _Water.PrimaryLight)
			{
				Clear(base.DataTexture);
				Clear(_PersistentDataTexture);
				CleanUpShadowCommandBuffers();
				_Light = null;
			}
		}

		private void CleanUpShadowCommandBuffers()
		{
			if (RenderPipelineHelper.IsLegacy)
			{
				CopyShadowMapBuffer?.Release();
				CopyShadowMapBuffer = null;
			}
		}

		private void Update(CommandBuffer buffer)
		{
			if (!_Valid && Application.isPlaying)
			{
				return;
			}
			ClearBufferIfLightChanged();
			bool flag = SetUpLight();
			_Valid = ValidateLight();
			if (!s_ProcessData || !_Valid || !flag)
			{
				if (CopyShadowMapBuffer != null)
				{
					Clear(base.DataTexture);
					Clear(_PersistentDataTexture);
					CleanUpShadowCommandBuffers();
				}
				return;
			}
			if (CopyShadowMapBuffer == null)
			{
				CommandBuffer obj = new CommandBuffer
				{
					name = "Crest.LodData"
				};
				CommandBuffer commandBuffer = obj;
				CopyShadowMapBuffer = obj;
			}
			CopyShadowMapBuffer.Clear();
			buffer.BeginSample(ID);
			CoreUtils.SetRenderTarget(buffer, base.DataTexture, ClearFlag.Color, ClearColor);
			buffer.EndSample(ID);
		}

		internal override void BuildCommandBuffer(WaterRenderer water, CommandBuffer buffer)
		{
			bool flag = (_IsSimulationBuffer = buffer == _Water.SimulationBuffer);
			if (flag)
			{
				bool flag2 = true;
				if (RenderPipelineHelper.IsLegacy)
				{
					flag2 = Helpers.GetGlobalBoolean(ShaderIDs.s_ShadowPassExecuteLastFrame);
					Helpers.SetGlobalBoolean(ShaderIDs.s_ShadowPassExecuteLastFrame, value: false);
				}
				Update(buffer);
				if (flag2)
				{
					return;
				}
			}
			if (!(water.Viewer == null))
			{
				base.BuildCommandBuffer(water, buffer);
				if (RenderPipelineHelper.IsLegacy && !flag)
				{
					buffer.SetGlobalBoolean(ShaderIDs.s_ShadowPassExecuteLastFrame, value: true);
				}
			}
		}

		private protected override void SetAdditionalSimulationParameters(PropertyWrapperCompute properties)
		{
			base.SetAdditionalSimulationParameters(properties);
			Vector4 value = new Vector4(_JitterDiameterSoft, _JitterDiameterHard, _CurrentFrameWeightSoft, _CurrentFrameWeightHard);
			Material material = _Water.Surface.Material;
			bool flag = material != null && material.HasVector(WaterRenderer.ShaderIDs.s_Absorption) && material.HasProperty(WaterRenderer.ShaderIDs.s_Scattering);
			Vector3 vector = (flag ? material.GetVector(WaterRenderer.ShaderIDs.s_Absorption).XYZ() : Vector3.zero);
			Vector3 vector2 = (flag ? WaveHarmonic.Crest.Internal.Extensions.XYZ(material.GetColor(WaterRenderer.ShaderIDs.s_Scattering).MaybeLinear()) : Vector3.zero);
			bool enabled = _Water.AbsorptionLod.Enabled;
			bool enabled2 = _Water.ScatteringLod.Enabled;
			bool flag2 = enabled || enabled2;
			if (_DynamicSoftShadows && flag && !flag2)
			{
				Vector3 vector3 = vector + vector2;
				float num = Mathf.Clamp01(Mathf.Min(Mathf.Min(vector3.x, vector3.y), vector3.z) * _SoftJitterExtinctionFactor);
				value.x = (1f - num) * 32f;
			}
			Shader.SetGlobalFloat(ShaderIDs.s_DynamicSoftShadowsFactor, _DynamicSoftShadows ? _SoftJitterExtinctionFactor : 1f);
			Camera viewer = _Water.Viewer;
			properties.SetVector(ShaderIDs.s_JitterDiameters_CurrentFrameWeights, value);
			properties.SetMatrix(ShaderIDs.s_MainCameraProjectionMatrix, GL.GetGPUProjectionMatrix(viewer.projectionMatrix, renderIntoTexture: true) * viewer.worldToCameraMatrix);
			properties.SetBoolean(ShaderIDs.s_SampleColorMap, _DynamicSoftShadows && flag2);
			if (_DynamicSoftShadows && flag2)
			{
				properties.SetVector(WaterRenderer.ShaderIDs.s_Absorption, vector);
				properties.SetVector(WaterRenderer.ShaderIDs.s_Scattering, vector2);
			}
			if (RenderPipelineHelper.IsLegacy)
			{
				properties.SetBoolean(ShaderIDs.s_ClearShadows, _IsSimulationBuffer);
				properties.SetKeyword(new LocalKeyword(SimulationShader, "SHADOWS_SINGLE_CASCADE"), QualitySettings.shadowCascades == 1);
				properties.SetKeyword(new LocalKeyword(SimulationShader, "SHADOWS_SPLIT_SPHERES"), QualitySettings.shadowProjection == ShadowProjection.StableFit);
			}
		}

		internal ShadowLod()
		{
			_Enabled = true;
			_TextureFormat = GraphicsFormat.R8G8_UNorm;
			_Blur = true;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
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
			if (_Water.IsSingleViewpointMode && _Water.Viewer != camera)
			{
				return false;
			}
			return true;
		}

		internal void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			if (RenderPipelineHelper.IsUniversal)
			{
				SampleShadowsURP.EnqueuePass(context, camera);
			}
			else
			{
				if (!RenderPipelineHelper.IsLegacy)
				{
					return;
				}
				CopyShadowMapBuffer?.Clear();
				if (CopyShadowMapBuffer != null)
				{
					if (_Light != null)
					{
						_Light.RemoveCommandBuffer(LightEvent.BeforeScreenspaceMask, CopyShadowMapBuffer);
						_Light.AddCommandBuffer(LightEvent.BeforeScreenspaceMask, CopyShadowMapBuffer);
					}
					BuildCommandBuffer(_Water, CopyShadowMapBuffer);
				}
			}
		}

		internal void OnEndCameraRendering(Camera camera)
		{
			if (_Water.IsMultipleViewpointMode)
			{
				StoreCameraData(camera);
			}
			if (RenderPipelineHelper.IsLegacy && _Light != null && CopyShadowMapBuffer != null)
			{
				_Light.RemoveCommandBuffer(LightEvent.BeforeScreenspaceMask, CopyShadowMapBuffer);
			}
		}
	}
}
