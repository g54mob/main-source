using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Barrel Distortion")]
	public class BarrelDistortionSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Strength of the distortion. Values above zero cause CRT screen-like distortion; values below zero bulge outwards.")]
		public ClampedFloatParameter strength = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("Color of the background around the 'screen'.")]
		public ColorParameter backgroundColor = new ColorParameter(Color.black);

		public BarrelDistortionSettings()
		{
			base.displayName = "Barrel Distortion";
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
