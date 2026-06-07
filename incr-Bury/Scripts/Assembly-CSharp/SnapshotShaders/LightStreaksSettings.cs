using System;
using SnapshotShaders.URP;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Light Streaks")]
	public sealed class LightStreaksSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Light Streaks blur strength.")]
		public ClampedIntParameter strength = new ClampedIntParameter(1, 1, 1000);

		[Tooltip("Luminance Threshold - pixels above this luminance will glow.")]
		public ClampedFloatParameter luminanceThreshold = new ClampedFloatParameter(1.2f, 0f, 25f);

		[Tooltip("Divisor to apply to the screen resolution in the x-direction for the blur pass.")]
		public NoInterpClampedIntParameter downsampleAmount = new NoInterpClampedIntParameter(24, 1, 128);

		public LightStreaksSettings()
		{
			base.displayName = "Light Streaks";
		}

		public bool IsActive()
		{
			if (strength.value > 1)
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
