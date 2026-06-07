using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Synthwave")]
	public sealed class SynthwaveSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Color of the background if Use Scene Color is turned off.")]
		public ColorParameter backgroundColor = new ColorParameter(Color.black);

		[Tooltip("Bottom color of the synthwave lines. HDR colors will glow if a Bloom effect is present.")]
		public ColorParameter lineColor1 = new ColorParameter(Color.white, hdr: true, showAlpha: true, showEyeDropper: true);

		[ColorUsage(true, true)]
		[Tooltip("Top color of the synthwave lines. HDR colors will glow if a Bloom effect is present.")]
		public ColorParameter lineColor2 = new ColorParameter(Color.white, hdr: true, showAlpha: true, showEyeDropper: true);

		[Tooltip("Controls the mix between the two line colors. Lower values favour the top color (2). Higher values favor the bottom color (1).")]
		public FloatParameter lineColorMix = new ClampedFloatParameter(1f, 0f, 2f);

		[Tooltip("Thickness of the lines in world space units.")]
		public FloatParameter lineWidth = new FloatParameter(0f);

		[Tooltip("Falloff between synthwave lines and background color in world space units.")]
		public FloatParameter lineFalloff = new FloatParameter(0.05f);

		[Tooltip("Space between lines along each axis in world space units.")]
		public Vector3Parameter gapWidth = new Vector3Parameter(Vector3.one);

		[Tooltip("Offset from (0, 0, 0) along each axis in world space units.")]
		public Vector3Parameter offset = new Vector3Parameter(Vector3.zero);

		[SerializeField]
		[Tooltip("Synthwave lines are shown only along these axes.")]
		public AxisMaskParameter axisMask = new AxisMaskParameter(AxisMask.XZ);

		[Tooltip("Use the Scene Color instead of Background Color?")]
		public BoolParameter useSceneColor = new BoolParameter(value: false);

		public SynthwaveSettings()
		{
			base.displayName = "Synthwave";
		}

		public bool IsActive()
		{
			if (lineWidth.value > Mathf.Epsilon)
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
