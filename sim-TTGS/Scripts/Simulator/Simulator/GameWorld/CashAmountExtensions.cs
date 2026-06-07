using System;

namespace Simulator.GameWorld
{
	public static class CashAmountExtensions
	{
		public static float Value(this ECashAmount amount)
		{
			return amount switch
			{
				ECashAmount.FiftyDollar => 50f, 
				ECashAmount.TwentyDollar => 20f, 
				ECashAmount.TenDollar => 10f, 
				ECashAmount.FiveDollar => 5f, 
				ECashAmount.OneDollar => 1f, 
				ECashAmount.FiftyCent => 0.5f, 
				ECashAmount.TwentyFiveCent => 0.25f, 
				ECashAmount.TenCent => 0.1f, 
				ECashAmount.FiveCent => 0.05f, 
				ECashAmount.OneCent => 0.01f, 
				_ => 0f, 
			};
		}

		public static string Name(this ECashAmount amount)
		{
			return amount switch
			{
				ECashAmount.FiftyDollar => 50f.ToStringMoneyFormat(), 
				ECashAmount.TwentyDollar => 20f.ToStringMoneyFormat(), 
				ECashAmount.TenDollar => 10f.ToStringMoneyFormat(), 
				ECashAmount.FiveDollar => 5f.ToStringMoneyFormat(), 
				ECashAmount.OneDollar => 1f.ToStringMoneyFormat(), 
				ECashAmount.FiftyCent => 0.5f.ToStringMoneyFormat(), 
				ECashAmount.TwentyFiveCent => 0.25f.ToStringMoneyFormat(), 
				ECashAmount.TenCent => 0.1f.ToStringMoneyFormat(), 
				ECashAmount.FiveCent => 0.05f.ToStringMoneyFormat(), 
				ECashAmount.OneCent => 0.01f.ToStringMoneyFormat(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static bool IsCoin(this ECashAmount amount)
		{
			if ((uint)(amount - 5) <= 4u)
			{
				return true;
			}
			return false;
		}

		public static bool IsBill(this ECashAmount amount)
		{
			return !amount.IsCoin();
		}
	}
}
