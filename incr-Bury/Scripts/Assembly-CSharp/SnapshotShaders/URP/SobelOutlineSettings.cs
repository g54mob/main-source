using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/SobelOutline")]
	public sealed class SobelOutlineSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("Edge-detection threshold.")]
		public ClampedFloatParameter threshold = new ClampedFloatParameter(0.5f, 0f, 1f);

		[Tooltip("Outline color.")]
		public ColorParameter outlineColor = new ColorParameter(Color.white);

		[Tooltip("Background color if Use Scene Color is turned off.")]
		public ColorParameter backgroundColor = new ColorParameter(Color.black);

		[Tooltip("Use the Scene Color instead of Background Color?")]
		public BoolParameter useSceneColor = new BoolParameter(value: false);

		public SobelOutlineSettings()
		{
			base.displayName = "Sobel Outlines";
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
