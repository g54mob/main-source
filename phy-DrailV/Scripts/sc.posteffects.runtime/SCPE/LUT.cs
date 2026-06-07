using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[Serializable]
	[PostProcess(typeof(LUTRenderer), PostProcessEvent.AfterStack, "SC Post Effects/Image/Color Grading LUT", true)]
	public sealed class LUT : PostProcessEffectSettings
	{
		public enum Mode
		{
			Single = 0,
			DistanceBased = 1
		}

		[Serializable]
		public sealed class ModeParam : ParameterOverride<Mode>
		{
		}

		[DisplayName("Mode")]
		[Tooltip("Distance-based mode blends two LUTs over a distance")]
		public ModeParam mode = new ModeParam
		{
			value = Mode.Single
		};

		public FloatParameter startFadeDistance = new FloatParameter
		{
			value = 0f
		};

		public FloatParameter endFadeDistance = new FloatParameter
		{
			value = 1000f
		};

		[Range(0f, 1f)]
		[Tooltip("Fades the effect in or out")]
		public FloatParameter intensity = new FloatParameter
		{
			value = 0f
		};

		[Tooltip("Supply a LUT strip texture.")]
		public TextureParameter lutNear = new TextureParameter
		{
			value = null
		};

		[DisplayName("Far")]
		public TextureParameter lutFar = new TextureParameter
		{
			value = null
		};

		[Range(0f, 1f)]
		[Tooltip("Fades the effect in or out")]
		public FloatParameter invert = new FloatParameter
		{
			value = 0f
		};

		public static bool Bypass;

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			return enabled.value;
		}
	}
}
