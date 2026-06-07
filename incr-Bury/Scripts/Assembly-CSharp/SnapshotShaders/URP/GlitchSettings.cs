using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Glitch")]
	public class GlitchSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("Texture which controls the strength of the glitch offset based on y-coordinate.")]
		public TextureParameter offsetTexture = new TextureParameter(null);

		[Tooltip("Glitch effect intensity.")]
		public ClampedFloatParameter offsetStrength = new ClampedFloatParameter(0.1f, 0f, 5f);

		[Tooltip("Controls how many times the glitch texture repeats vertically.")]
		public ClampedFloatParameter verticalTiling = new ClampedFloatParameter(5f, 0f, 25f);

		public GlitchSettings()
		{
			base.displayName = "Glitch";
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
