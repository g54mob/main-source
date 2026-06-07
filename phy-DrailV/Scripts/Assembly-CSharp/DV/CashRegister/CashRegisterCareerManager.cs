namespace DV.CashRegister
{
	public class CashRegisterCareerManager : CashRegisterBase
	{
		private double currentCost;

		public void SetTotalCost(double cost)
		{
			currentCost = cost;
		}

		public void ClearCurrentTransaction()
		{
			SetTotalCost(0.0);
			Cancel();
		}

		public override bool Buy()
		{
			bool num = base.Buy();
			if (num)
			{
				SetTotalCost(0.0);
			}
			return num;
		}

		public override double GetTotalCost()
		{
			return currentCost;
		}

		public override float TotalUnitsInBasket()
		{
			if (!(GetTotalCost() > 0.0))
			{
				return 0f;
			}
			return 1f;
		}
	}
}
