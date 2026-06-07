using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Mosaic")]
	public sealed class MosaicSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("Texture to overlay onto each mosaic tile.")]
		public TextureParameter overlayTexture = new TextureParameter(null);

		[Tooltip("Colour of texture overlay.")]
		public ColorParameter overlayColor = new ColorParameter(Color.white);

		[Range(5f, 500f)]
		[Tooltip("Number of tiles on the x-axis.")]
		public ClampedIntParameter xTileCount = new ClampedIntParameter(100, 5, 500);

		[Tooltip("Use sharper point filtering when downsampling?")]
		public BoolParameter usePointFiltering = new BoolParameter(value: true);

		public MosaicSettings()
		{
			base.displayName = "Mosaic";
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
