using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Sharpen")]
	public sealed class SharpenSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Range(0f, 1f)]
		[Tooltip("Sharpen effect intensity.")]
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f);

		public SharpenSettings()
		{
			base.displayName = "Sharpen";
		}

		public bool IsActive()
		{
			if (intensity.value > 0f)
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
