using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[Serializable]
	[PostProcess(typeof(SharpenRenderer), PostProcessEvent.AfterStack, "SC Post Effects/Image/Sharpen", true)]
	public sealed class Sharpen : PostProcessEffectSettings
	{
		[Range(0f, 1f)]
		public FloatParameter amount = new FloatParameter
		{
			value = 0f
		};

		[Range(0.1f, 2f)]
		public FloatParameter radius = new FloatParameter
		{
			value = 1f
		};

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (enabled.value)
			{
				if ((float)amount == 0f)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
