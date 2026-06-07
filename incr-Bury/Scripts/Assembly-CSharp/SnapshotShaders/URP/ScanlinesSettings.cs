using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Scanlines")]
	public sealed class ScanlinesSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Scanlines texture.")]
		public TextureParameter scanlineTex = new TextureParameter(null);

		[Tooltip("Strength of the effect.")]
		public ClampedFloatParameter strength = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("Pixel size of the scanlines.")]
		public ClampedIntParameter size = new ClampedIntParameter(8, 1, 64);

		[Tooltip("Scroll speed of scanlines vertically.")]
		public ClampedFloatParameter scrollSpeed = new ClampedFloatParameter(0f, 0f, 10f);

		public ScanlinesSettings()
		{
			base.displayName = "Scanlines";
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
