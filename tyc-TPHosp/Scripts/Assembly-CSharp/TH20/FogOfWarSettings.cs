using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	[Serializable]
	[PostProcess(typeof(FogOfWarRenderer), PostProcessEvent.AfterStack, "Custom/Fog of War", false)]
	public sealed class FogOfWarSettings : PostProcessEffectSettings
	{
		public FloatParameter quadScale = new FloatParameter
		{
			value = 100f
		};

		[Range(0f, 1f)]
		public FloatParameter desaturation = new FloatParameter
		{
			value = 0.5f
		};

		[Range(0f, 3f)]
		public FloatParameter brightness = new FloatParameter
		{
			value = 0.5f
		};

		[Range(0f, 32f)]
		public IntParameter startFadeDistance = new IntParameter
		{
			value = 10
		};

		[Range(0f, 32f)]
		public IntParameter endFadeDistance = new IntParameter
		{
			value = 20
		};
	}
}
