using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Shape Waves Input")]
	public abstract class ShapeWaves : LodInput
	{
		private protected new static class ShaderIDs
		{
			public static readonly int s_TransitionalWavelengthThreshold = Shader.PropertyToID("_Crest_TransitionalWavelengthThreshold");

			public static readonly int s_WaveResolutionMultiplier = Shader.PropertyToID("_Crest_WaveResolutionMultiplier");

			public static readonly int s_WaveBufferParameters = Shader.PropertyToID("_Crest_WaveBufferParameters");

			public static readonly int s_AlphaSource = Shader.PropertyToID("_Crest_AlphaSource");

			public static readonly int s_WaveBuffer = Shader.PropertyToID("_Crest_WaveBuffer");

			public static readonly int s_WaveBufferSliceIndex = Shader.PropertyToID("_Crest_WaveBufferSliceIndex");

			public static readonly int s_AverageWavelength = Shader.PropertyToID("_Crest_AverageWavelength");

			public static readonly int s_RespectShallowWaterAttenuation = Shader.PropertyToID("_Crest_RespectShallowWaterAttenuation");

			public static readonly int s_MaximumAttenuationDepth = Shader.PropertyToID("_Crest_MaximumAttenuationDepth");

			public static readonly int s_AxisX = Shader.PropertyToID("_Crest_AxisX");

			public static readonly int s_SeaLevelOnly = Shader.PropertyToID("_Crest_SeaLevelOnly");

			public static readonly int s_WaveBufferAttenuation = Shader.PropertyToID("_Crest_WaveBufferAttenuation");
		}

		internal enum WindSpeedSource
		{
			None = 0,
			ShapeWaves = 1,
			WaterRenderer = 2
		}

		private sealed class Reporter : IReportsDisplacement, IReportWaveDisplacement
		{
			private readonly ShapeWaves _Input;

			public Reporter(ShapeWaves input)
			{
				_Input = input;
			}

			public bool ReportDisplacement(WaterRenderer water, ref Rect bounds, ref float horizontal, ref float vertical)
			{
				return _Input.ReportDisplacement(water, ref bounds, ref horizontal, ref vertical);
			}

			public float ReportWaveDisplacement(WaterRenderer water, float displacement)
			{
				return _Input.ReportWaveDisplacement(water, displacement);
			}
		}

		private enum AlphaSource
		{
			AlwaysOne = 0,
			FromZero = 1,
			FromZeroNormalized = 2
		}

		[Tooltip("The spectrum that defines the water surface shape.")]
		[SerializeField]
		internal WaveSpectrum _Spectrum;

		[Tooltip("Whether to evaluate the spectrum every frame.\n\nWhen false, the wave spectrum is evaluated once on startup in editor play mode and standalone builds, rather than every frame. This is less flexible, but it reduces the performance cost significantly.")]
		[FormerlySerializedAs("_SpectrumFixedAtRuntime")]
		[SerializeField]
		private protected bool _EvaluateSpectrumAtRunTimeEveryFrame;

		[Tooltip("How much these waves respect the shallow water attenuation.\n\nAttenuation is defined on the Animated Waves. Set to zero to ignore attenuation.")]
		[SerializeField]
		private float _RespectShallowWaterAttenuation = 1f;

		[Tooltip("Whether global waves is applied above or below sea level.\n\nWaves are faded out to avoid hard transitionds. They are fully faded by 1m from sea level.")]
		[SerializeField]
		private bool _SeaLevelOnly = true;

		[Tooltip("Whether to use the wind direction on this component rather than the global wind direction.\n\nGlobal wind direction comes from the Water Renderer component.")]
		[SerializeField]
		private bool _OverrideGlobalWindDirection;

		[Tooltip("Primary wave direction heading (degrees).\n\nThis is the angle from x axis in degrees that the waves are oriented towards. If a spline is being used to place the waves, this angle is relative to the spline.")]
		[SerializeField]
		private protected float _WaveDirectionHeadingAngle;

		[Tooltip("Whether to use the wind speed on this component rather than the global wind speed.\n\nGlobal wind speed comes from the Water Renderer component.")]
		[SerializeField]
		private bool _OverrideGlobalWindSpeed;

		[Tooltip("Wind speed in km/h. Controls wave conditions.")]
		[SerializeField]
		private float _WindSpeed = 20f;

		[Tooltip("Resolution to use for wave generation buffers.\n\nLow resolutions are more efficient but can result in noticeable patterns in the shape.")]
		[SerializeField]
		private protected int _Resolution = 128;

		[Tooltip("Whether the maximum possible vertical displacement is used for the Drop Detail Height Based On Waves calculation.\n\nThis setting is ignored for global waves, as they always contribute. For local waves, only enable for large areas that are treated like global waves (eg a storm).")]
		[SerializeField]
		private bool _IncludeInDropDetailHeightBasedOnWaves;

		[Tooltip("In Editor, shows the wave generation buffers on screen.")]
		[SerializeField]
		internal bool _DrawSlicesInEditor;

		private static WaveSpectrum s_WindSpectrum;

		private static ComputeShader s_TransferWavesComputeShader;

		private static LocalKeyword s_KeywordTexture;

		private static LocalKeyword s_KeywordTextureBlend;

		private readonly Vector4[] _WaveBufferParameters = new Vector4[15];

		internal static int s_RenderPassOverride = -1;

		private protected WaveSpectrum _ActiveSpectrum;

		private protected const int k_CascadeCount = 16;

		private protected int _FirstCascade = -1;

		private protected int _LastCascade = -2;

		private protected bool _FirstUpdate = true;

		private protected int _LastGenerateFrameCount = -1;

		private float _Wavelength;

		private protected RenderTexture _WaveBuffers;

		internal Rect _Rect;

		private protected Vector2 _MaximumDisplacement;

		private Reporter _Reporter;

		private static int s_InstanceCount = 0;

		[HideInInspector]
		[SerializeField]
		private AlphaSource _AlphaSource;

		internal override Color GizmoColor => AnimatedWavesLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => AnimatedWavesLod.s_Inputs;

		private protected virtual WaveSpectrum DefaultSpectrum => WindSpectrum;

		private protected static WaveSpectrum WindSpectrum
		{
			get
			{
				if (s_WindSpectrum == null)
				{
					s_WindSpectrum = ScriptableObject.CreateInstance<WaveSpectrum>();
					s_WindSpectrum.name = "Wind Waves (instance)";
					s_WindSpectrum.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
				}
				return s_WindSpectrum;
			}
		}

		private protected abstract int MinimumResolution { get; }

		private protected abstract int MaximumResolution { get; }

		private protected Vector2 PrimaryWaveDirection => new Vector2(Mathf.Cos(MathF.PI * WaveDirectionHeadingAngle / 180f), Mathf.Sin(MathF.PI * WaveDirectionHeadingAngle / 180f));

		public float WindSpeedKPH
		{
			get
			{
				if (!_OverrideGlobalWindSpeed && !(ManagerBehaviour<WaterRenderer>.Instance == null))
				{
					return ManagerBehaviour<WaterRenderer>.Instance.WindSpeed;
				}
				return _WindSpeed;
			}
		}

		public float WindSpeedMPS => WindSpeedKPH / 3.6f;

		internal override bool Enabled
		{
			get
			{
				bool flag = _FirstCascade > -1 && (ManagerBehaviour<WaterRenderer>.Instance == null || ManagerBehaviour<WaterRenderer>.Instance.Gravity != 0f);
				if (flag)
				{
					bool flag2 = ((base.Mode != LodInputMode.Global) ? base.Enabled : (base.enabled && s_TransferWavesComputeShader != null));
					flag = flag2;
				}
				return flag;
			}
		}

		internal override LodInputMode DefaultMode => LodInputMode.Global;

		internal override int Pass => 0;

		private protected override bool FollowHorizontalMotion => true;

		internal RenderTexture WaveBuffer => _WaveBuffers;

		private protected float MaximumReportedHorizontalDisplacement { get; set; }

		private protected float MaximumReportedVerticalDisplacement { get; set; }

		private protected float MaximumReportedWavesDisplacement { get; set; }

		private protected bool UpdateDataEachFrame => _EvaluateSpectrumAtRunTimeEveryFrame;

		private protected override int Version => Mathf.Max(base.Version, 3);

		public bool EvaluateSpectrumAtRunTimeEveryFrame
		{
			get
			{
				return _EvaluateSpectrumAtRunTimeEveryFrame;
			}
			set
			{
				_EvaluateSpectrumAtRunTimeEveryFrame = value;
			}
		}

		public bool IncludeInDropDetailHeightBasedOnWaves
		{
			get
			{
				return _IncludeInDropDetailHeightBasedOnWaves;
			}
			set
			{
				_IncludeInDropDetailHeightBasedOnWaves = value;
			}
		}

		public bool OverrideGlobalWindDirection
		{
			get
			{
				return _OverrideGlobalWindDirection;
			}
			set
			{
				_OverrideGlobalWindDirection = value;
			}
		}

		public bool OverrideGlobalWindSpeed
		{
			get
			{
				return _OverrideGlobalWindSpeed;
			}
			set
			{
				_OverrideGlobalWindSpeed = value;
			}
		}

		public int Resolution
		{
			get
			{
				return GetResolution();
			}
			set
			{
				_Resolution = value;
			}
		}

		public float RespectShallowWaterAttenuation
		{
			get
			{
				return _RespectShallowWaterAttenuation;
			}
			set
			{
				_RespectShallowWaterAttenuation = value;
			}
		}

		public bool SeaLevelOnly
		{
			get
			{
				return _SeaLevelOnly;
			}
			set
			{
				_SeaLevelOnly = value;
			}
		}

		public WaveSpectrum Spectrum
		{
			get
			{
				return _Spectrum;
			}
			set
			{
				_Spectrum = value;
			}
		}

		public float WaveDirectionHeadingAngle
		{
			get
			{
				return GetWaveDirectionHeadingAngle();
			}
			set
			{
				_WaveDirectionHeadingAngle = value;
			}
		}

		public float WindSpeed
		{
			get
			{
				return _WindSpeed;
			}
			set
			{
				_WindSpeed = value;
			}
		}

		private protected ShapeWaves()
		{
			_FollowHorizontalWaveMotion = true;
		}

		private protected override void Attach()
		{
			base.Attach();
			if (_Reporter == null)
			{
				_Reporter = new Reporter(this);
			}
			_DisplacementReporter = _Reporter;
			_WaveDisplacementReporter = _Reporter;
		}

		private protected override void Detach()
		{
			base.Detach();
			_DisplacementReporter = null;
			_WaveDisplacementReporter = null;
		}

		internal WindSpeedSource GetWindSpeedSource()
		{
			if (WindSpeedKPH >= 150f)
			{
				return WindSpeedSource.None;
			}
			if (!OverrideGlobalWindSpeed)
			{
				return WindSpeedSource.WaterRenderer;
			}
			return WindSpeedSource.ShapeWaves;
		}

		internal override void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			if (weight * base.Weight <= 0f)
			{
				return;
			}
			if (!base.IsCompute)
			{
				GraphicsDraw(simulation, buffer, target, pass, weight, slice);
			}
			else
			{
				if (_FirstCascade < 0 || _LastCascade < 0)
				{
					return;
				}
				int slices = simulation.Slices;
				int resolution = simulation.Resolution;
				AnimatedWavesLod animatedWavesLod = (AnimatedWavesLod)simulation;
				PropertyWrapperCompute wrapper = new PropertyWrapperCompute(buffer, s_TransferWavesComputeShader, 0);
				wrapper.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, target);
				wrapper.SetFloat(LodInput.ShaderIDs.s_Weight, base.Weight);
				wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_Resolution, Resolution);
				WaterRenderer water = animatedWavesLod._Water;
				for (int num = slices - 1; num >= slices - slice; num--)
				{
					_WaveBufferParameters[num] = new Vector4(-1f, -2f, 0f, 1f);
					bool flag = false;
					AnimatedWavesLod.WavelengthFilter filter = new AnimatedWavesLod.WavelengthFilter(water, num, resolution);
					for (int i = _FirstCascade; i <= _LastCascade; i++)
					{
						_Wavelength = MinWavelength(i) / animatedWavesLod.WaveResolutionMultiplier;
						if (!(AnimatedWavesLod.FilterByWavelength(filter, _Wavelength) * base.Weight <= 0f))
						{
							if (!flag)
							{
								_WaveBufferParameters[num].x = i;
								flag = true;
							}
							_WaveBufferParameters[num].y = i;
						}
					}
				}
				if (!animatedWavesLod.PreserveWaveQuality)
				{
					_WaveBufferParameters[slices - 2].w = 1f - water.ViewerAltitudeLevelAlpha;
				}
				_WaveBufferParameters[slices - 1].w = water.ViewerAltitudeLevelAlpha;
				SetRenderParameters(water, wrapper);
				wrapper.SetFloat(ShaderIDs.s_WaveResolutionMultiplier, animatedWavesLod.WaveResolutionMultiplier);
				wrapper.SetFloat(ShaderIDs.s_TransitionalWavelengthThreshold, water.MaximumWavelength(water.LodLevels - 1, simulation.Resolution) * 0.5f);
				wrapper.SetVectorArray(ShaderIDs.s_WaveBufferParameters, _WaveBufferParameters);
				LodInputMode mode = base.Mode;
				bool flag2 = mode == LodInputMode.Paint || mode == LodInputMode.Texture;
				LodInputBlend blend = base.Blend;
				bool flag3 = blend == LodInputBlend.Off || blend == LodInputBlend.Alpha || blend == LodInputBlend.AlphaClip;
				wrapper.SetKeyword(in s_KeywordTexture, flag2 && !flag3);
				wrapper.SetKeyword(in s_KeywordTextureBlend, flag2 && flag3);
				wrapper.SetFloatArray(ShaderIDs.s_WaveBufferAttenuation, _ActiveSpectrum._Attenuation);
				if (flag2)
				{
					wrapper.SetInteger(WaveHarmonic.Crest.ShaderIDs.s_Blend, (int)_Blend);
				}
				if (base.Mode == LodInputMode.Global)
				{
					wrapper.SetBoolean(ShaderIDs.s_SeaLevelOnly, _SeaLevelOnly);
					int num2 = animatedWavesLod.Resolution / 8;
					wrapper.Dispatch(num2, num2, slice);
				}
				else
				{
					base.Draw(simulation, buffer, target, pass, weight, slice);
				}
			}
		}

		private void GraphicsDraw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass, float weight, int slice)
		{
			AnimatedWavesLod animatedWavesLod = simulation as AnimatedWavesLod;
			int resolution = simulation.Resolution;
			SetRenderParameters(wrapper: new PropertyWrapperBuffer(buffer), water: simulation._Water);
			bool flag = true;
			for (int i = _FirstCascade; i <= _LastCascade; i++)
			{
				_Wavelength = MinWavelength(i) / animatedWavesLod.WaveResolutionMultiplier;
				weight = AnimatedWavesLod.FilterByWavelength(simulation._Water, slice, _Wavelength, resolution) * base.Weight;
				if (!(weight <= 0f))
				{
					float value = _Wavelength * 1.5f * animatedWavesLod.WaveResolutionMultiplier;
					buffer.SetGlobalFloat(ShaderIDs.s_AverageWavelength, value);
					buffer.SetGlobalInt(ShaderIDs.s_WaveBufferSliceIndex, i);
					if (!flag)
					{
						s_RenderPassOverride = 1;
					}
					flag = false;
					base.Draw(simulation, buffer, target, pass, weight, slice);
				}
			}
			_Wavelength = 0f;
			s_RenderPassOverride = -1;
		}

		internal override float Filter(WaterRenderer water, int slice)
		{
			return 1f;
		}

		private protected float MinWavelength(int cascadeIdx)
		{
			return 0.5f * (float)(1 << cascadeIdx) / 8f;
		}

		private protected abstract void ReportMaxDisplacement(WaterRenderer water);

		private protected override void OnUpdate(WaterRenderer water)
		{
			base.OnUpdate(water);
			_ActiveSpectrum = ((_Spectrum != null) ? _Spectrum : DefaultSpectrum);
			_FirstUpdate = false;
		}

		private protected virtual void SetRenderParameters<T>(WaterRenderer water, T wrapper) where T : IPropertyWrapper
		{
			int s_WaveBuffer = ShaderIDs.s_WaveBuffer;
			RenderTexture waveBuffers = _WaveBuffers;
			wrapper.SetTexture(s_WaveBuffer, waveBuffers);
			int s_RespectShallowWaterAttenuation = ShaderIDs.s_RespectShallowWaterAttenuation;
			float respectShallowWaterAttenuation = _RespectShallowWaterAttenuation;
			wrapper.SetFloat(s_RespectShallowWaterAttenuation, respectShallowWaterAttenuation);
			int s_MaximumAttenuationDepth = ShaderIDs.s_MaximumAttenuationDepth;
			float shallowsMaximumDepth = water._AnimatedWavesLod.ShallowsMaximumDepth;
			wrapper.SetFloat(s_MaximumAttenuationDepth, shallowsMaximumDepth);
		}

		private protected override void Initialize()
		{
			base.Initialize();
			ScriptableSingleton<WaterResources>.Instance.AfterEnabled -= InitializeResources;
			ScriptableSingleton<WaterResources>.Instance.AfterEnabled += InitializeResources;
			InitializeResources();
			_FirstUpdate = true;
			if (_Spectrum != null)
			{
				_ActiveSpectrum = _Spectrum;
			}
			if (_ActiveSpectrum == null)
			{
				_ActiveSpectrum = DefaultSpectrum;
			}
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			ScriptableSingleton<WaterResources>.Instance.AfterEnabled -= InitializeResources;
		}

		private void InitializeResources()
		{
			s_TransferWavesComputeShader = ScriptableSingleton<WaterResources>.Instance.Compute._ShapeWavesTransfer;
			s_KeywordTexture = ScriptableSingleton<WaterResources>.Instance.Keywords.AnimatedWavesTransferWavesTexture;
			s_KeywordTextureBlend = ScriptableSingleton<WaterResources>.Instance.Keywords.AnimatedWavesTransferWavesTextureBlend;
		}

		private bool ReportDisplacement(WaterRenderer water, ref Rect bounds, ref float horizontal, ref float vertical)
		{
			if (!Enabled)
			{
				return false;
			}
			if (base.Mode == LodInputMode.Global)
			{
				horizontal += MaximumReportedHorizontalDisplacement;
				vertical += MaximumReportedVerticalDisplacement;
				return true;
			}
			_Rect = base.Data.Rect;
			if (bounds.Overlaps(_Rect, allowInverse: false))
			{
				float num = horizontal;
				float num2 = vertical;
				switch (base.Blend)
				{
				case LodInputBlend.Off:
					num = MaximumReportedHorizontalDisplacement;
					num2 = MaximumReportedVerticalDisplacement;
					break;
				case LodInputBlend.Additive:
					num += MaximumReportedHorizontalDisplacement;
					num2 += MaximumReportedVerticalDisplacement;
					break;
				case LodInputBlend.Alpha:
				case LodInputBlend.AlphaClip:
					num = Mathf.Max(num, MaximumReportedHorizontalDisplacement);
					num2 = Mathf.Max(num, MaximumReportedVerticalDisplacement);
					break;
				}
				horizontal = Mathf.Max(horizontal, num);
				vertical = Mathf.Max(vertical, num2);
				return true;
			}
			return false;
		}

		private float ReportWaveDisplacement(WaterRenderer water, float displacement)
		{
			if (base.Mode == LodInputMode.Global)
			{
				return displacement + MaximumReportedWavesDisplacement;
			}
			if (!_IncludeInDropDetailHeightBasedOnWaves)
			{
				return displacement;
			}
			if (_Rect.Contains(water.Position.XZ()))
			{
				float num;
				switch (base.Blend)
				{
				case LodInputBlend.Off:
					num = MaximumReportedWavesDisplacement;
					break;
				case LodInputBlend.Additive:
					num = displacement + MaximumReportedWavesDisplacement;
					break;
				case LodInputBlend.Alpha:
				case LodInputBlend.AlphaClip:
					num = Mathf.Max(displacement, MaximumReportedWavesDisplacement);
					break;
				default:
					num = MaximumReportedWavesDisplacement;
					break;
				}
				displacement = num;
			}
			return displacement;
		}

		private float GetWaveDirectionHeadingAngle()
		{
			if (!_OverrideGlobalWindDirection && !(ManagerBehaviour<WaterRenderer>.Instance == null))
			{
				return ManagerBehaviour<WaterRenderer>.Instance.WindDirection;
			}
			return _WaveDirectionHeadingAngle;
		}

		internal int GetResolution()
		{
			return Mathf.Clamp(_Resolution, MinimumResolution, MaximumResolution);
		}

		private protected override void Awake()
		{
			base.Awake();
			s_InstanceCount++;
		}

		private protected virtual void OnDestroy()
		{
			if (--s_InstanceCount <= 0 && s_WindSpectrum != null)
			{
				Helpers.Destroy(s_WindSpectrum);
				s_WindSpectrum = null;
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				if (_Blend == LodInputBlend.Alpha)
				{
					_Blend = _AlphaSource switch
					{
						AlphaSource.AlwaysOne => LodInputBlend.Off, 
						AlphaSource.FromZero => LodInputBlend.Alpha, 
						AlphaSource.FromZeroNormalized => LodInputBlend.AlphaClip, 
						_ => _Blend, 
					};
				}
				_EvaluateSpectrumAtRunTimeEveryFrame = !_EvaluateSpectrumAtRunTimeEveryFrame;
			}
			if (_Version < 2)
			{
				_OverrideGlobalWindDirection = true;
			}
			if (_Version < 3)
			{
				_SeaLevelOnly = false;
			}
		}
	}
}
