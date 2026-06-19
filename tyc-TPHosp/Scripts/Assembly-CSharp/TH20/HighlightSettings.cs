using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	[Serializable]
	[PostProcess(typeof(HighlightRenderer), PostProcessEvent.AfterStack, "Custom/Highlight", true)]
	public sealed class HighlightSettings : PostProcessEffectSettings
	{
		[DisplayName("Hightlight Keyhole Size")]
		[Range(0f, 1f)]
		[Tooltip("How much of the highlight is visible around the mouse cursor")]
		public FloatParameter HighlightKeyholeSize = new FloatParameter
		{
			value = 0.1f
		};
	}
}
