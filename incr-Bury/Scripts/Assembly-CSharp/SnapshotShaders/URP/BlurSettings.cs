using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Blur")]
	public sealed class BlurSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Blur Strength")]
		public ClampedIntParameter strength = new ClampedIntParameter(1, 1, 500);

		[Tooltip("Higher values will skip pixels during blur passes. Increase for better performance.")]
		public ClampedIntParameter blurStepSize = new ClampedIntParameter(1, 1, 16);

		[Tooltip("Type of blur. Gaussian blur is slightly more expensive, but higher fidelity.")]
		public BlurTypeParameter blurType = new BlurTypeParameter(BlurType.Gaussian);

		public BlurSettings()
		{
			base.displayName = "Blur";
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
