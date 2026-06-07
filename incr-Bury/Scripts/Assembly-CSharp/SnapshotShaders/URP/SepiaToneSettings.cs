using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/SepiaTone")]
	public sealed class SepiaToneSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Sepia Tone effect intensity.")]
		public ClampedFloatParameter strength = new ClampedFloatParameter(0f, 0f, 1f);

		public SepiaToneSettings()
		{
			base.displayName = "Sepia Tone";
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
