using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[Serializable]
	[PostProcess(typeof(TransitionRenderer), PostProcessEvent.AfterStack, "SC Post Effects/Screen/Transition", true)]
	public sealed class Transition : PostProcessEffectSettings
	{
		public TextureParameter gradientTex = new TextureParameter
		{
			value = null,
			defaultState = TextureParameterDefault.None
		};

		[Range(0f, 1f)]
		[Tooltip("Progress")]
		public FloatParameter progress = new FloatParameter
		{
			value = 0f
		};

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (enabled.value)
			{
				if ((float)progress == 0f)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
