using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class FoamLod : PersistentLod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_MinimumWavesSlice = Shader.PropertyToID("_Crest_MinimumWavesSlice");

			public static readonly int s_FoamMaximum = Shader.PropertyToID("_Crest_FoamMaximum");

			public static readonly int s_FoamFadeRate = Shader.PropertyToID("_Crest_FoamFadeRate");

			public static readonly int s_WaveFoamStrength = Shader.PropertyToID("_Crest_WaveFoamStrength");

			public static readonly int s_WaveFoamCoverage = Shader.PropertyToID("_Crest_WaveFoamCoverage");

			public static readonly int s_ShorelineFoamMaxDepth = Shader.PropertyToID("_Crest_ShorelineFoamMaxDepth");

			public static readonly int s_ShorelineFoamStrength = Shader.PropertyToID("_Crest_ShorelineFoamStrength");

			public static readonly int s_NeedsPrewarming = Shader.PropertyToID("_Crest_NeedsPrewarming");

			public static readonly int s_FoamNegativeDepthPriming = Shader.PropertyToID("_Crest_FoamNegativeDepthPriming");
		}

		[Tooltip("Prewarms the simulation on load and teleports.\n\nResults are only an approximation.")]
		[SerializeField]
		private bool _Prewarm = true;

		[Tooltip("Settings for fine tuning this simulation.")]
		[SerializeField]
		private FoamLodSettings _Settings;

		internal static readonly Color s_GizmoColor = new Color(1f, 1f, 1f, 0.5f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		private FoamLodSettings _DefaultSettings;

		internal override string ID => "Foam";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor => Color.black;

		private protected override ComputeShader SimulationShader => ScriptableSingleton<WaterResources>.Instance.Compute._UpdateFoam;

		private protected override GraphicsFormat RequestedTextureFormat => _TextureFormatMode switch
		{
			LodTextureFormatMode.Performance => GraphicsFormat.R16_SFloat, 
			LodTextureFormatMode.Precision => GraphicsFormat.R32_SFloat, 
			LodTextureFormatMode.Manual => _TextureFormat, 
			_ => throw new NotImplementedException(), 
		};

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		public bool Prewarm
		{
			get
			{
				return _Prewarm;
			}
			set
			{
				_Prewarm = value;
			}
		}

		public FoamLodSettings Settings
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

		private protected override void SetAdditionalSimulationParameters(PropertyWrapperCompute properties)
		{
			base.SetAdditionalSimulationParameters(properties);
			properties.SetBoolean(ShaderIDs.s_NeedsPrewarming, _Prewarm && _NeedsPrewarmingThisStep);
			properties.SetFloat(ShaderIDs.s_FoamFadeRate, Settings._FoamFadeRate);
			properties.SetFloat(ShaderIDs.s_WaveFoamStrength, Settings._WaveFoamStrength);
			properties.SetFloat(ShaderIDs.s_WaveFoamCoverage, Settings._WaveFoamCoverage);
			properties.SetFloat(ShaderIDs.s_ShorelineFoamMaxDepth, Settings._ShorelineFoamMaximumDepth);
			properties.SetFloat(ShaderIDs.s_ShorelineFoamStrength, Settings._ShorelineFoamStrength);
			properties.SetFloat(ShaderIDs.s_FoamMaximum, Settings.Maximum);
			properties.SetFloat(ShaderIDs.s_FoamNegativeDepthPriming, 0f - Settings._ShorelineFoamPriming);
			properties.SetInteger(ShaderIDs.s_MinimumWavesSlice, Settings.FilterWaves);
		}

		internal FoamLod()
		{
			_Enabled = true;
			_TextureFormat = GraphicsFormat.R16_SFloat;
			_SimulationFrequency = 30;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}

		private FoamLodSettings GetSettings()
		{
			if (_Settings != null)
			{
				return _Settings;
			}
			if (_DefaultSettings == null)
			{
				_DefaultSettings = ScriptableObject.CreateInstance<FoamLodSettings>();
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
