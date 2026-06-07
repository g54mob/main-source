using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Painting")]
	public sealed class PaintingSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Oil Painting effect radius.")]
		public ClampedIntParameter kernelSize = new ClampedIntParameter(1, 1, 51);

		public PaintingSettings()
		{
			base.displayName = "Painting";
		}

		public bool IsActive()
		{
			if (kernelSize.value > 1)
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
