using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace CompoundRendererFeature.PostProcess
{
	[Serializable]
	[VolumeComponentMenu("Quibli/Stylized Detail")]
	public class StylizedDetail : VolumeComponent
	{
		[Tooltip("Controls the amount of contrast added to the image details.")]
		public ClampedFloatParameter intensity;

		[Tooltip("Controls smoothing amount.")]
		public ClampedFloatParameter blur;

		[Tooltip("Controls structure within the image.")]
		public ClampedFloatParameter edgePreserve;

		[Space]
		[Tooltip("The distance from the camera at which the effect starts.")]
		public MinFloatParameter rangeStart;

		[Tooltip("The distance from the camera at which the effect reaches its maximum radius.")]
		public MinFloatParameter rangeEnd;
	}
}
