using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Kaleidoscope")]
	public sealed class KaleidoscopeSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("The number of radial segments.")]
		public ClampedFloatParameter segmentCount = new ClampedFloatParameter(1f, 1f, 20f);

		public KaleidoscopeSettings()
		{
			base.displayName = "Kaleidoscope";
		}

		public bool IsActive()
		{
			if (segmentCount.value > 1f)
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
