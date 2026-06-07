using System;

namespace Simulator.GameWorld
{
	public class CashRegisterTransaction
	{
		public float MoneyTaken { get; private set; }

		public float MoneyReturned { get; private set; }

		public float CheckedProductsCost { get; private set; }

		public static CashRegisterTransaction Current { get; private set; }

		private CashRegisterTransaction()
		{
			CheckedProductsCost = 0f;
		}

		public bool TakeMoney(float amount)
		{
			if (amount > CheckedProductsCost || PaymentSettings.IsAmountEqual(amount, CheckedProductsCost))
			{
				MoneyTaken = amount;
				return true;
			}
			return false;
		}

		public void TakeExactMoney()
		{
			MoneyTaken = CheckedProductsCost;
		}

		public void AddToReturnedMoney(float amount)
		{
			MoneyReturned += amount;
		}

		public void CheckProduct(Product product)
		{
			CheckedProductsCost = MathF.Round(CheckedProductsCost + product.Price, 2, MidpointRounding.AwayFromZero);
		}

		public float GetCurrentMoneyToReturn()
		{
			return MathF.Round(MoneyTaken - CheckedProductsCost - MoneyReturned, 2);
		}

		public float GetTotalMoneyToReturn()
		{
			return MathF.Round(MoneyTaken - CheckedProductsCost, 2);
		}

		public bool IsTransactionValid()
		{
			return IsTransactionValid(MoneyTaken - MoneyReturned);
		}

		public bool IsTransactionValid(float moneyTaken)
		{
			return PaymentSettings.IsAmountEqual(CheckedProductsCost, moneyTaken);
		}

		public static bool HasCurrent(out CashRegisterTransaction transaction)
		{
			transaction = Current;
			return transaction != null;
		}

		public static void CreateNew()
		{
			Current = new CashRegisterTransaction();
		}

		public static void Load(float moneyTaken)
		{
			Current = new CashRegisterTransaction();
			Current.MoneyTaken = moneyTaken;
		}

		public static void Clear()
		{
			Current = null;
		}
	}
}
