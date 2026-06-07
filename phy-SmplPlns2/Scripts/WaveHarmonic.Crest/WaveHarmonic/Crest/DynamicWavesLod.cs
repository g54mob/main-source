using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class DynamicWavesLod : PersistentLod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_HorizontalDisplace = Shader.PropertyToID("_Crest_HorizontalDisplace");

			public static readonly int s_DisplaceClamp = Shader.PropertyToID("_Crest_DisplaceClamp");

			public static readonly int s_Damping = Shader.PropertyToID("_Crest_Damping");

			public static readonly int s_Gravity = Shader.PropertyToID("_Crest_Gravity");

			public static readonly int s_CourantNumber = Shader.PropertyToID("_Crest_CourantNumber");
		}

		[Tooltip("How much waves are dampened in shallow water.")]
		[SerializeField]
		private float _AttenuationInShallows = 1f;

		[Tooltip("Settings for fine tuning this simulation.")]
		[SerializeField]
		private DynamicWavesLodSettings _Settings;

		private const string k_DynamicWavesKeyword = "CREST_DYNAMIC_WAVE_SIM_ON_INTERNAL";

		internal static readonly Color s_GizmoColor = new Color(0f, 1f, 0f, 0.5f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		private DynamicWavesLodSettings _DefaultSettings;

		internal override string ID => "DynamicWaves";

		internal override string Name => "Dynamic Waves";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => Color.black;

		private protected override ComputeShader SimulationShader => ScriptableSingleton<WaterResources>.Instance.Compute._UpdateDynamicWaves;

		private protected override GraphicsFormat RequestedTextureFormat
		{
			get
			{
				switch (_TextureFormatMode)
				{
				case LodTextureFormatMode.Automatic:
				{
					GraphicsFormat result;
					if (base.Water == null)
					{
						result = GraphicsFormat.None;
					}
					else
					{
						GraphicsFormat graphicsFormat = ((base.Water.AnimatedWavesLod.TextureFormatMode != LodTextureFormatMode.Precision) ? GraphicsFormat.R16G16_SFloat : GraphicsFormat.R32G32_SFloat);
						result = graphicsFormat;
					}
					return result;
				}
				case LodTextureFormatMode.Performance:
					return GraphicsFormat.R16G16_SFloat;
				case LodTextureFormatMode.Precision:
					return GraphicsFormat.R32G32_SFloat;
				case LodTextureFormatMode.Manual:
					return _TextureFormat;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal float TimeLeftToSimulate => _TimeToSimulate;

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		public float AttenuationInShallows
		{
			get
			{
				return _AttenuationInShallows;
			}
			set
			{
				_AttenuationInShallows = value;
			}
		}

		public DynamicWavesLodSettings Settings
		{
			get
			{
				return GetSettings();
			}
			set
			{
				_Settings = value;
			}
		}

		internal DynamicWavesLod()
		{
			_OverrideResolution = false;
			_Resolution = 512;
			_TextureFormatMode = LodTextureFormatMode.Automatic;
			_TextureFormat = GraphicsFormat.R16G16_SFloat;
		}

		internal override void Enable()
		{
			base.Enable();
			Shader.EnableKeyword("CREST_DYNAMIC_WAVE_SIM_ON_INTERNAL");
		}

		internal override void Disable()
		{
			base.Disable();
			Shader.DisableKeyword("CREST_DYNAMIC_WAVE_SIM_ON_INTERNAL");
		}

		internal override void Bind<T>(T target)
		{
			base.Bind(target);
			int s_HorizontalDisplace = ShaderIDs.s_HorizontalDisplace;
			float horizontalDisplace = Settings._HorizontalDisplace;
			target.SetFloat(s_HorizontalDisplace, horizontalDisplace);
			int s_DisplaceClamp = ShaderIDs.s_DisplaceClamp;
			float displaceClamp = Settings._DisplaceClamp;
			target.SetFloat(s_DisplaceClamp, displaceClamp);
		}

		private protected override void SetAdditionalSimulationParameters(PropertyWrapperCompute simMaterial)
		{
			base.SetAdditionalSimulationParameters(simMaterial);
			simMaterial.SetFloat(ShaderIDs.s_Damping, Settings._Damping);
			simMaterial.SetFloat(ShaderIDs.s_Gravity, _Water.Gravity * Settings._GravityMultiplier);
			simMaterial.SetFloat(ShaderIDs.s_CourantNumber, Settings._CourantNumber);
			simMaterial.SetFloat(AnimatedWavesLod.ShaderIDs.s_AttenuationInShallows, _AttenuationInShallows);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}

		private DynamicWavesLodSettings GetSettings()
		{
			if (_Settings != null)
			{
				return _Settings;
			}
			if (_DefaultSettings == null)
			{
				_DefaultSettings = ScriptableObject.CreateInstance<DynamicWavesLodSettings>();
				_DefaultSettings.name = "Default " + Name + " (instance)";
				_DefaultSettings.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
			}
			return _DefaultSettings;
		}

		internal override void Destroy()
		{
			base.Destroy();
			Helpers.Destroy(_DefaultSettings);
			_DefaultSettings = null;
		}
	}
}
