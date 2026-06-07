using System;
using SnapshotShaders.URP;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Invert")]
	public sealed class InvertSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Invert effect intensity.")]
		public ClampedFloatParameter strength = new ClampedFloatParameter(0f, 0f, 1f);

		public InvertSettings()
		{
			base.displayName = "Invert";
		}

		public bool IsActive()
		{
			if (strength.value > 0f)
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
