using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/AccumulationMotionBlurVolume")]
	public class AccumulationMotionBlurVolume : VolumeComponent
	{
		public ClampedFloatParameter weight = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter vignette = new ClampedFloatParameter(0f, -1f, 1f);

		public ClampedFloatParameter dither = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedFloatParameter zoom = new ClampedFloatParameter(0f, -1f, 1f);

		public ClampedFloatParameter zoomDither = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter anisotropy = new ClampedFloatParameter(0f, -1f, 1f);

		public BoolParameter applyToUIOverlay = new BoolParameter(value: false);

		private static AccumulationMotionBlurVolume s_Default;

		public static AccumulationMotionBlurVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<AccumulationMotionBlurVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
