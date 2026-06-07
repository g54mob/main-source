using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Colorize")]
	public sealed class ColorizeSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[ColorUsage(true, true)]
		[Tooltip("Tint colour to use.")]
		public ColorParameter tintColor = new ColorParameter(new Color(1f, 1f, 1f, 0f));

		public ColorizeSettings()
		{
			base.displayName = "Colorize";
		}

		public bool IsActive()
		{
			if (tintColor.value.a > 0f)
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
