using System;

namespace HQFPSTemplate
{
	[Serializable]
	public class SpringControlInfo
	{
		public float SpringLerpSpeed = 25f;

		public float PositionBobOffset;

		public float RotationBobOffset = 0.5f;

		public float SpringForceMultiplier = 1f;
	}
}
