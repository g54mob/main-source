using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[Serializable]
	[PostProcess(typeof(TiltShiftRenderer), PostProcessEvent.AfterStack, "SC Post Effects/Blurring/Tilt Shift", true)]
	public class TiltShift : PostProcessEffectSettings
	{
		public enum TiltShiftMethod
		{
			Horizontal = 0,
			Radial = 1
		}

		[Serializable]
		public sealed class TiltShifMethodParameter : ParameterOverride<TiltShiftMethod>
		{
		}

		public enum Quality
		{
			Performance = 0,
			Appearance = 1
		}

		[Serializable]
		public sealed class TiltShiftQualityParameter : ParameterOverride<Quality>
		{
		}

		[Range(0f, 1f)]
		[Tooltip("The amount of blurring that must be performed")]
		public FloatParameter amount = new FloatParameter
		{
			value = 0f
		};

		[DisplayName("Method")]
		public TiltShifMethodParameter mode = new TiltShifMethodParameter
		{
			value = TiltShiftMethod.Horizontal
		};

		[DisplayName("Quality")]
		[Tooltip("Choose to use more texture samples, for a smoother blur when using a high blur amout")]
		public TiltShiftQualityParameter quality = new TiltShiftQualityParameter
		{
			value = Quality.Appearance
		};

		[Range(0f, 1f)]
		public FloatParameter areaSize = new FloatParameter
		{
			value = 1f
		};

		[Range(0f, 1f)]
		public FloatParameter areaFalloff = new FloatParameter
		{
			value = 1f
		};

		[Range(-1f, 1f)]
		public FloatParameter offset = new FloatParameter
		{
			value = 0f
		};

		[Range(0f, 360f)]
		public FloatParameter angle = new FloatParameter
		{
			value = 0f
		};

		public static bool debug;

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (enabled.value)
			{
				if (((float)areaSize == 0f && (float)areaFalloff == 0f) || (float)amount == 0f)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
