using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Posterize")]
	public sealed class PosterizeSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("How many red levels are supported.")]
		public ClampedIntParameter redLevels = new ClampedIntParameter(2, 2, 256);

		[Tooltip("How many green levels are supported.")]
		public ClampedIntParameter greenLevels = new ClampedIntParameter(2, 2, 256);

		[Tooltip("How many blue levels are supported.")]
		public ClampedIntParameter blueLevels = new ClampedIntParameter(2, 2, 256);

		[Tooltip("Modify the input colors via a power ramp. 1 = original mapping, higher = favors darker output, lower = favors lighter output.")]
		public ClampedFloatParameter powerRamp = new ClampedFloatParameter(1f, 0f, 4f);

		public PosterizeSettings()
		{
			base.displayName = "Posterize";
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
