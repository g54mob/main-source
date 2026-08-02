using System;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public class DelayedCameraForce : ICloneable
	{
		public float Delay;

		public SpringForce Force;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
