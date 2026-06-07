using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/SobelNeon")]
	public sealed class SobelNeonSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("Saturation values lower than this will be clamped to this.")]
		public ClampedFloatParameter saturationFloor = new ClampedFloatParameter(0.75f, 0f, 1f);

		[Range(0f, 1f)]
		[Tooltip("Lightness/value values lower than this will be clamped to this.")]
		public ClampedFloatParameter lightnessFloor = new ClampedFloatParameter(0.75f, 0f, 1f);

		[Tooltip("Color of the background if Use Scene Color is turned off.")]
		public ColorParameter backgroundColor = new ColorParameter(Color.black);

		public SobelNeonSettings()
		{
			base.displayName = "Sobel Neon";
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
