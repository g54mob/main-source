using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Silhouette")]
	public sealed class SilhouetteSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("Color at the camera's near clip plane.")]
		public ColorParameter nearColor = new ColorParameter(new Color(0f, 0f, 0f, 1f));

		[Tooltip("Color at the camera's far clip plane.")]
		public ColorParameter farColor = new ColorParameter(new Color(1f, 1f, 1f, 1f));

		[Tooltip("Modify the input colors via a power ramp. 1 = original mapping, higher = favors near color, lower = favors far color.")]
		public ClampedFloatParameter powerRamp = new ClampedFloatParameter(1f, 0f, 4f);

		public SilhouetteSettings()
		{
			base.displayName = "Silhouette";
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
