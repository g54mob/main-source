using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Cutout")]
	public sealed class CutoutSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Is the effect active?")]
		public BoolParameter enabled = new BoolParameter(value: false);

		[Tooltip("The texture to use for the cutout.")]
		public TextureParameter cutoutTexture = new TextureParameter(null);

		[Tooltip("The colour of the area outside the cutout.")]
		public ColorParameter borderColor = new ColorParameter(Color.white);

		[Tooltip("Should the cutout texture stretch to fit the screen's aspect ratio?")]
		public BoolParameter stretch = new BoolParameter(value: false);

		[Tooltip("How zoomed-in the texture is. 1 = unzoomed.")]
		public NoInterpClampedFloatParameter zoom = new NoInterpClampedFloatParameter(1f, 0.01f, 10f);

		[Tooltip("How offset the texture is from the centre of the screen (in UV space).")]
		public NoInterpVector2Parameter offset = new NoInterpVector2Parameter(Vector2.zero);

		[Range(0f, 360f)]
		[Tooltip("How much the texture is rotated (anticlockwise, in degrees).")]
		public NoInterpClampedFloatParameter rotation = new NoInterpClampedFloatParameter(0f, 0f, 360f);

		public CutoutSettings()
		{
			base.displayName = "Cutout";
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
