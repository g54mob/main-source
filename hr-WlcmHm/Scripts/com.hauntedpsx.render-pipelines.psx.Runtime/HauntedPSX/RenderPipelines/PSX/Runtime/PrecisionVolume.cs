using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/PrecisionVolume")]
	public class PrecisionVolume : VolumeComponent
	{
		[Serializable]
		public enum DrawDistanceFalloffMode
		{
			Planar = 0,
			Cylindrical = 1,
			Spherical = 2
		}

		[Serializable]
		public sealed class DrawDistanceFalloffModeParameter : VolumeParameter<DrawDistanceFalloffMode>
		{
			public DrawDistanceFalloffModeParameter(DrawDistanceFalloffMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		public BoolParameter geometryEnabled = new BoolParameter(value: true);

		public ClampedFloatParameter geometry = new ClampedFloatParameter(1f, 0f, 1f);

		public BoolParameter geometryPushbackEnabled = new BoolParameter(value: false);

		public FloatRangeParameter geometryPushbackMinMax = new FloatRangeParameter(new Vector2(0f, 1f), 0f, 10f);

		public ClampedFloatParameter color = new ClampedFloatParameter(0.5714286f, 0f, 1f);

		public ClampedFloatParameter chroma = new ClampedFloatParameter(1f / 3f, 0f, 1f);

		public ClampedFloatParameter alpha = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedFloatParameter affineTextureWarping = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedFloatParameter framebufferDither = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedIntParameter ditherSize = new ClampedIntParameter(1, 1, 8);

		public DrawDistanceFalloffModeParameter drawDistanceFalloffMode = new DrawDistanceFalloffModeParameter(DrawDistanceFalloffMode.Planar);

		public MinFloatParameter drawDistance = new MinFloatParameter(100f, 0f);

		private static PrecisionVolume s_Default;

		public static PrecisionVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<PrecisionVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
