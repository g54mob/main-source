using System;

namespace Simulator.GameWorld
{
	[Serializable]
	public class SalariesBill : Bill
	{
		public override float GetDailyPrice()
		{
			return 0f;
		}
	}
}
