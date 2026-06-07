using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Drawing")]
	public sealed class DrawingSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Drawing overlay texture.")]
		public TextureParameter drawingTex = new TextureParameter(null);

		[Tooltip("Time taken (in seconds) per animation cycle. Set to zero for no animation.")]
		public ClampedFloatParameter animCycleTime = new ClampedFloatParameter(0.75f, 0f, 5f);

		[Tooltip("Strength of the effect.")]
		public ClampedFloatParameter strength = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("Number of times the drawing texture is tiled.")]
		public ClampedFloatParameter tiling = new ClampedFloatParameter(25f, 1f, 50f);

		[Tooltip("Amount of UV smudging based on drawing texture colour values.")]
		public ClampedFloatParameter smudge = new ClampedFloatParameter(0.001f, 0f, 5f);

		[Tooltip("Pixels past this depth threshold will not be 'drawn on'.")]
		public ClampedFloatParameter depthThreshold = new ClampedFloatParameter(0.99f, 0f, 1.01f);

		public DrawingSettings()
		{
			base.displayName = "Drawing";
		}

		public bool IsActive()
		{
			if (drawingTex.value != null)
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
