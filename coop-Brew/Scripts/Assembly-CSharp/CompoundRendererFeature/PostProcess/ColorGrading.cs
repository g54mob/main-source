using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace CompoundRendererFeature.PostProcess
{
	[Serializable]
	[VolumeComponentMenu("Quibli/Stylized Color Grading")]
	public class ColorGrading : VolumeComponent
	{
		[Tooltip("Controls the amount to which image colors are modified.")]
		public ClampedFloatParameter intensity;

		[Space]
		public ClampedFloatParameter blueShadows;

		public ClampedFloatParameter greenShadows;

		public ClampedFloatParameter redHighlights;

		public ClampedFloatParameter contrast;

		[Space]
		public ClampedFloatParameter vibrance;

		public ClampedFloatParameter saturation;
	}
}
