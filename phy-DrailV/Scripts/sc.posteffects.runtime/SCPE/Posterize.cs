using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[Serializable]
	[PostProcess(typeof(PosterizeRenderer), PostProcessEvent.BeforeStack, "SC Post Effects/Retro/Posterize", true)]
	public sealed class Posterize : PostProcessEffectSettings
	{
		public BoolParameter hsvMode = new BoolParameter
		{
			value = false
		};

		[Range(0f, 256f)]
		public IntParameter levels = new IntParameter
		{
			value = 256
		};

		[Header("Levels")]
		[Range(0f, 256f)]
		public IntParameter hue = new IntParameter
		{
			value = 256
		};

		[Range(0f, 256f)]
		public IntParameter saturation = new IntParameter
		{
			value = 256
		};

		[Range(0f, 256f)]
		public IntParameter value = new IntParameter
		{
			value = 256
		};

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (enabled.value)
			{
				if (!hsvMode && (int)levels == 256)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
