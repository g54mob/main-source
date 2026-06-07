using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Basic Dither")]
	public sealed class BasicDitherSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("Noise texture to use for dither thresholding.")]
		public TextureParameter noiseTex = new TextureParameter(null);

		[Tooltip("Size of the noise texture.")]
		public ClampedFloatParameter noiseSize = new ClampedFloatParameter(1f, 0.1f, 100f);

		[Tooltip("Offset used when calculating luminance threshold.")]
		public ClampedFloatParameter thresholdOffset = new ClampedFloatParameter(0f, -0.5f, 0.5f);

		[Tooltip("Color to use for dark sections of the image.")]
		public ColorParameter darkColor = new ColorParameter(Color.black);

		[Tooltip("Color to use for light sections of the image.")]
		public ColorParameter lightColor = new ColorParameter(Color.white);

		[Tooltip("Use the Scene Color instead of Light Color?")]
		public BoolParameter useSceneColor = new BoolParameter(value: false);

		public BasicDitherSettings()
		{
			base.displayName = "Basic Dither";
		}

		public bool IsActive()
		{
			if (enabled.value)
			{
				return active;
			}
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}
	}
}
