using System;

namespace Brewery.Minigames
{
	[Serializable]
	public struct ControlEffect
	{
		public int meterIndex;

		public float rateScale;

		public float instantDelta;

		public bool invertWhenOff;

		public bool affectsDriftRate;
	}
}
