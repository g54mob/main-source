using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/FilmBars")]
	public sealed class FilmBarsSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Range(0.1f, 5f)]
		[Tooltip("Desired aspect ratio (16:9 = 1.777 approx).")]
		public ClampedFloatParameter aspect = new ClampedFloatParameter(1.777f, 0.1f, 5f);

		public FilmBarsSettings()
		{
			base.displayName = "Film Bars";
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
