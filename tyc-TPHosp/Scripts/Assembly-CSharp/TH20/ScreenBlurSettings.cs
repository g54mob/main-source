using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	[Serializable]
	[PostProcess(typeof(ScreenBlurRenderer), PostProcessEvent.AfterStack, "Custom/Screen Blur", false)]
	public sealed class ScreenBlurSettings : PostProcessEffectSettings
	{
		[Tooltip("Make the size of the blur consistent on any resolution. This isnt cache friently so comes at a cost to performance")]
		public BoolParameter resolutionIndependent = new BoolParameter();

		[Range(0f, 0.2f)]
		[Tooltip("The resolution independent size of the blur")]
		public FloatParameter resolutionIndependentBlurSize = new FloatParameter
		{
			value = 0.01f
		};

		[Range(0f, 5f)]
		[Tooltip("The resolution dependent size of the blur")]
		public FloatParameter resolutionDependentBlurSize = new FloatParameter
		{
			value = 1.5f
		};

		[Range(1f, 32f)]
		[Tooltip("Blur Steps")]
		public IntParameter blurSteps = new IntParameter
		{
			value = 2
		};

		[Range(2f, 16f)]
		[Tooltip("What fraction of the size of the screen should the blur render targer be. 1/x")]
		public IntParameter renderTaragetFraction = new IntParameter
		{
			value = 4
		};
	}
}
