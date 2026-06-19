using System;
using UnityEngine.Rendering;

namespace URPGlitch
{
	[Serializable]
	[VolumeComponentMenu("Analog Glitch")]
	public class AnalogGlitchVolume : VolumeComponent
	{
		public ClampedFloatParameter scanLineJitter = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter verticalJump = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter horizontalShake = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter colorDrift = new ClampedFloatParameter(0f, 0f, 1f);
	}
}
