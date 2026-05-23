using System;

namespace Battle
{
	[Serializable]
	public class PriceRevision
	{
		public eMachine machine;

		public float percentValue;

		public int minusValue;

		public PriceRevision(eMachine machine, float percentValue)
		{
		}

		public PriceRevision(eMachine machine, int minusValue)
		{
		}
	}
}
