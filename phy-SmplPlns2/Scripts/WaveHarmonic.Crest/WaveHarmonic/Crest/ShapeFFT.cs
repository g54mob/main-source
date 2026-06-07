using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Shape FFT")]
	public sealed class ShapeFFT : ShapeWaves
	{
		[Tooltip("Whether to apply the options shown when \"Show Advanced Controls\" is active.")]
		[SerializeField]
		private bool _ApplyAdvancedSpectrumControls;

		[Tooltip("Whether to use the wind turbulence on this component rather than the global wind turbulence.\n\nGlobal wind turbulence comes from the Water Renderer component.")]
		[SerializeField]
		private bool _OverrideGlobalWindTurbulence;

		[Tooltip("How turbulent/chaotic the waves are.")]
		[SerializeField]
		private float _WindTurbulence = 0.145f;

		[Tooltip("How aligned the waves are with wind.")]
		[SerializeField]
		private float _WindAlignment;

		[Tooltip("FFT waves will loop with a period of this many seconds.")]
		[SerializeField]
		private float _TimeLoopLength = float.PositiveInfinity;

		[Tooltip("Whether to override automatic culling based on heuristics.")]
		[SerializeField]
		private bool _OverrideCulling;

		[Tooltip("Maximum amount the surface will be displaced vertically from sea level.\n\nIncrease this if gaps appear at bottom of screen.")]
		[SerializeField]
		private float _MaximumVerticalDisplacement = 10f;

		[Tooltip("Maximum amount a point on the surface will be displaced horizontally by waves from its rest position.\n\nIncrease this if gaps appear at sides of screen.")]
		[SerializeField]
		private float _MaximumHorizontalDisplacement = 15f;

		[HideInInspector]
		[Tooltip("Enable running this FFT with baked data.\n\nThis makes the FFT periodic (repeating in time).")]
		[SerializeField]
		internal bool _EnableBakedCollision;

		[HideInInspector]
		[Tooltip("Frames per second of baked data.\n\nLarger values may help the collision track the surface closely at the cost of more frames and increase baked data size.")]
		[SerializeField]
		internal int _TimeResolution = 4;

		[HideInInspector]
		[Tooltip("Smallest wavelength required in collision.\n\nTo preview the effect of this, disable power sliders in spectrum for smaller values than this number. Smaller values require more resolution and increase baked data size.")]
		[SerializeField]
		internal float _SmallestWavelengthRequired = 2f;

		[HideInInspector]
		[Tooltip("FFT waves will loop with a period of this many seconds.\n\nSmaller values decrease data size but can make waves visibly repetitive.")]
		[SerializeField]
		internal float _BakedTimeLoopLength = 32f;

		private FFTCompute _FFTCompute;

		private FFTCompute.Parameters _OldFFTParameters;

		private static int s_InstanceCount;

		internal float LoopPeriod => _TimeLoopLength;

		private protected override int MinimumResolution => 16;

		private protected override int MaximumResolution
		{
			get
			{
				if (!Helpers.IsWebGPU)
				{
					return int.MaxValue;
				}
				return 64;
			}
		}

		private float WindDirRadForFFT
		{
			get
			{
				LodInputMode mode = base.Mode;
				if (mode == LodInputMode.Spline || mode == LodInputMode.Paint)
				{
					return 0f;
				}
				return base.WaveDirectionHeadingAngle * (MathF.PI / 180f);
			}
		}

		private protected override int Version => Mathf.Max(base.Version, 2);

		public bool ApplyAdvancedSpectrumControls
		{
			get
			{
				return _ApplyAdvancedSpectrumControls;
			}
			set
			{
				_ApplyAdvancedSpectrumControls = value;
			}
		}

		public float MaximumHorizontalDisplacement
		{
			get
			{
				return _MaximumHorizontalDisplacement;
			}
			set
			{
				_MaximumHorizontalDisplacement = value;
			}
		}

		public float MaximumVerticalDisplacement
		{
			get
			{
				return _MaximumVerticalDisplacement;
			}
			set
			{
				_MaximumVerticalDisplacement = value;
			}
		}

		public bool OverrideCulling
		{
			get
			{
				return _OverrideCulling;
			}
			set
			{
				_OverrideCulling = value;
			}
		}

		public bool OverrideGlobalWindTurbulence
		{
			get
			{
				return _OverrideGlobalWindTurbulence;
			}
			set
			{
				_OverrideGlobalWindTurbulence = value;
			}
		}

		public float TimeLoopLength
		{
			get
			{
				return _TimeLoopLength;
			}
			set
			{
				_TimeLoopLength = value;
			}
		}

		public float WindAlignment
		{
			get
			{
				return _WindAlignment;
			}
			set
			{
				_WindAlignment = value;
			}
		}

		public float WindTurbulence
		{
			get
			{
				return GetWindTurbulence();
			}
			set
			{
				_WindTurbulence = value;
			}
		}

		internal FFTCompute.Parameters GetFFTParameters(float gravity)
		{
			return new FFTCompute.Parameters(_ActiveSpectrum, base.Resolution, _TimeLoopLength, base.WindSpeedMPS, WindDirRadForFFT, WindTurbulence, _WindAlignment, gravity, _ApplyAdvancedSpectrumControls);
		}

		private protected override void OnUpdate(WaterRenderer water)
		{
			base.OnUpdate(water);
			_FirstCascade = 0;
			_LastCascade = 15;
			ReportMaxDisplacement(water);
			FFTCompute.Parameters fFTParameters = GetFFTParameters(water.Gravity);
			if (fFTParameters.GetHashCode() != _OldFFTParameters.GetHashCode())
			{
				FFTCompute.OnGenerationDataUpdated(_OldFFTParameters, fFTParameters);
			}
			_OldFFTParameters = fFTParameters;
		}

		internal override void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
		{
			if (_LastGenerateFrameCount != Time.frameCount)
			{
				FFTCompute.Parameters fFTParameters = GetFFTParameters(lod.Water.Gravity);
				_WaveBuffers = FFTCompute.GenerateDisplacements(buffer, lod.Water.CurrentTime, fFTParameters, base.UpdateDataEachFrame);
				_LastGenerateFrameCount = Time.frameCount;
			}
			base.Draw(lod, buffer, target, pass, weight, slice);
		}

		private protected override void SetRenderParameters<T>(WaterRenderer water, T wrapper)
		{
			base.SetRenderParameters(water, wrapper);
			LodInputMode mode = base.Mode;
			Vector2 vector = ((mode == LodInputMode.Spline || mode == LodInputMode.Paint) ? base.PrimaryWaveDirection : Vector2.right);
			wrapper.SetVector(ShaderIDs.s_AxisX, vector);
		}

		private protected override void ReportMaxDisplacement(WaterRenderer water)
		{
			if (!Enabled)
			{
				return;
			}
			float maximumReportedVerticalDisplacement;
			if (_OverrideCulling)
			{
				base.MaximumReportedHorizontalDisplacement = _MaximumHorizontalDisplacement * base.Weight;
				maximumReportedVerticalDisplacement = (base.MaximumReportedWavesDisplacement = _MaximumVerticalDisplacement * base.Weight);
				base.MaximumReportedVerticalDisplacement = maximumReportedVerticalDisplacement;
				return;
			}
			float num2 = 0f;
			for (int i = 0; i < 14; i++)
			{
				num2 += _ActiveSpectrum._PowerLinearScales[i];
			}
			float num3 = Mathf.Clamp01(base.WindSpeedKPH / 150f);
			float num4 = Mathf.Sqrt(num2) * 5f;
			base.MaximumReportedHorizontalDisplacement = num4 * _ActiveSpectrum._Chop * base.Weight * num3;
			maximumReportedVerticalDisplacement = (base.MaximumReportedWavesDisplacement = num4 * base.Weight * num3);
			base.MaximumReportedVerticalDisplacement = maximumReportedVerticalDisplacement;
		}

		private float GetWindTurbulence()
		{
			if (!_OverrideGlobalWindTurbulence && !(ManagerBehaviour<WaterRenderer>.Instance == null))
			{
				return ManagerBehaviour<WaterRenderer>.Instance.WindTurbulence;
			}
			return _WindTurbulence;
		}

		private protected override void Awake()
		{
			base.Awake();
			s_InstanceCount++;
		}

		private protected override void OnDestroy()
		{
			base.OnDestroy();
			if (--s_InstanceCount <= 0)
			{
				FFTCompute.CleanUpAll();
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 2)
			{
				_OverrideGlobalWindTurbulence = true;
			}
		}
	}
}
