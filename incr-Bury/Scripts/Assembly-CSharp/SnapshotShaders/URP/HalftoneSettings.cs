using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Halftone")]
	public sealed class HalftoneSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("The texture used to determine the shape of the halftone 'dots'.")]
		public TextureParameter halftoneTexture = new TextureParameter(null);

		[Tooltip("How soft the transition between light and dark is.")]
		public ClampedFloatParameter softness = new ClampedFloatParameter(0.5f, 0f, 1f);

		[Tooltip("Size of the halftone 'dots' on the screen.")]
		public ClampedFloatParameter textureSize = new ClampedFloatParameter(4f, 1f, 20f);

		[Tooltip("Use this vector to remap the minimum and maximum luminance values used in calculations. Default is (0, 1).")]
		public Vector2Parameter minMaxLuminance = new Vector2Parameter(new Vector2(0f, 1f));

		[Tooltip("Color of the darkened sections.")]
		public ColorParameter darkColor = new ColorParameter(Color.black);

		[Tooltip("Color of the lighter sections.")]
		public ColorParameter lightColor = new ColorParameter(Color.white);

		[Tooltip("Use the Scene Color instead of Light Color?")]
		public BoolParameter useSceneColor = new BoolParameter(value: false);

		public HalftoneSettings()
		{
			base.displayName = "Halftone";
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
