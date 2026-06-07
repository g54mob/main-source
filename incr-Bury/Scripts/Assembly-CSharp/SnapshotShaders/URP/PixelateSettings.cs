using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Pixelate")]
	public sealed class PixelateSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Size of each new 'pixel' in the image.")]
		public ClampedIntParameter pixelSize = new ClampedIntParameter(1, 1, 256);

		public PixelateSettings()
		{
			base.displayName = "Pixelate";
		}

		public bool IsActive()
		{
			if (pixelSize.value > 1)
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
