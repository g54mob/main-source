using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[Serializable]
	[PostProcess(typeof(KuwaharaRenderer), PostProcessEvent.AfterStack, "SC Post Effects/Stylized/Kuwahara", true)]
	public sealed class Kuwahara : PostProcessEffectSettings
	{
		public enum KuwaharaMode
		{
			FullScreen = 0,
			DepthFade = 1
		}

		[Serializable]
		public sealed class KuwaharaModeParam : ParameterOverride<KuwaharaMode>
		{
		}

		[DisplayName("Method")]
		[Tooltip("Choose to apply the effect to the entire screen, or fade in/out over a distance")]
		public KuwaharaModeParam mode = new KuwaharaModeParam
		{
			value = KuwaharaMode.FullScreen
		};

		[Range(0f, 8f)]
		[DisplayName("Radius")]
		public IntParameter radius = new IntParameter
		{
			value = 0
		};

		public FloatParameter startFadeDistance = new FloatParameter
		{
			value = 100f
		};

		public FloatParameter endFadeDistance = new FloatParameter
		{
			value = 500f
		};

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (enabled.value)
			{
				if ((int)radius == 0)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
