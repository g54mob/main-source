using System;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public class DelayedSound : ICloneable
	{
		public float Delay;

		public SoundPlayer Sound;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
