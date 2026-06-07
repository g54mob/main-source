using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace VolFx
{
	[Serializable]
	[VolumeComponentMenu("VolFx/Vhs")]
	public sealed class VhsVol : VolumeComponent, IPostProcessComponent
	{
		[Serializable]
		public class ModeParameter : VolumeParameter<VhsPass.Mode>
		{
			public ModeParameter(VhsPass.Mode value, bool overrideState)
				: base(value, overrideState)
			{
			}
		}

		[Tooltip("Total blending of full applied effect")]
		public ClampedFloatParameter _weight = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("Tape noises impact")]
		public ClampedFloatParameter _tape = new ClampedFloatParameter(0f, 0f, 2f);

		[Tooltip("Tape noises impact")]
		public ClampedFloatParameter _shades = new ClampedFloatParameter(0f, 0f, 3f);

		[Header("Distort")]
		[Tooltip("Frame distortions")]
		public ClampedFloatParameter _rocking = new ClampedFloatParameter(0f, 0f, 0.1f);

		[Tooltip("Tape squeeze distortions")]
		public ClampedFloatParameter _squeeze = new ClampedFloatParameter(0f, 0f, 1f);

		[Header("Noise")]
		[Tooltip("White noise density")]
		public ClampedFloatParameter _density = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("White noise intensity")]
		public ClampedFloatParameter _intensity = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("White noise scale")]
		public ClampedFloatParameter _scale = new ClampedFloatParameter(1f, 0.3f, 3f);

		[Tooltip("Grain flickering")]
		public ClampedFloatParameter _flickering = new ClampedFloatParameter(0f, -1f, 1f);

		[Tooltip("Line distortion")]
		public BoolParameter _lines = new BoolParameter(value: true);

		[Header("Glow")]
		[Tooltip("Crt glow color")]
		public ColorParameter _color = new ColorParameter(new Color(1f, 0f, 0f, 1f));

		[Tooltip("Crt glow offset")]
		public ClampedFloatParameter _bleed = new ClampedFloatParameter(0.7f, 0f, 3f);

		[Header("Anim")]
		[Tooltip("Speed of flow animations")]
		public ClampedFloatParameter _flow = new ClampedFloatParameter(1f, 0f, 24f);

		[Tooltip("Speed of pulsating animations")]
		public ClampedFloatParameter _pulsation = new ClampedFloatParameter(1f, 0f, 14f);

		public bool IsActive()
		{
			if (active)
			{
				return _weight.value > 0f;
			}
			return false;
		}

		public bool IsTileCompatible()
		{
			return true;
		}
	}
}
