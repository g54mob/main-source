using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	[Serializable]
	[PostProcess(typeof(HeightFogRenderer), PostProcessEvent.AfterStack, "Custom/Height Fog", false)]
	public sealed class HeightFogSettings : PostProcessEffectSettings
	{
		[Tooltip("The height at which the fog fades out")]
		public FloatParameter FogFadeOutHeight = new FloatParameter
		{
			value = 10f
		};

		[Tooltip("The height at which the fog is fully faded in")]
		public FloatParameter FogFadeInHeight = new FloatParameter
		{
			value = -10f
		};

		[Tooltip("What color should the fog be?")]
		public ColorParameter FogColor = new ColorParameter
		{
			value = Color.white
		};
	}
}
