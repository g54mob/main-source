using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/SNES")]
	public sealed class SNESSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("How many colors are supported by each color channel.")]
		public ClampedIntParameter bandingValues = new ClampedIntParameter(6, 1, 16);

		[Tooltip("Modify the input colors via a power ramp. 1 = original mapping, higher = favors darker output, lower = favors lighter output.")]
		public ClampedFloatParameter powerRamp = new ClampedFloatParameter(1f, 0f, 4f);

		public SNESSettings()
		{
			base.displayName = "SNES";
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
