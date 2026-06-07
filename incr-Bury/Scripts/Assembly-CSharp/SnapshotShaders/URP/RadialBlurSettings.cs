using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/RadialBlur")]
	public sealed class RadialBlurSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Blur Strength. Higher values require more system resources.")]
		public ClampedIntParameter strength = new ClampedIntParameter(1, 1, 500);

		[Range(1f, 20f)]
		[Tooltip("Distance between samples. Larger values may result in artefacts.")]
		public ClampedIntParameter stepSize = new ClampedIntParameter(5, 1, 20);

		public RadialBlurSettings()
		{
			base.displayName = "Radial Blur";
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
