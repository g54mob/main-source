using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.MoneyCash
{
	public class CashMoneyObject : PersonalObjectBase
	{
		[SerializeField]
		private MoneyInteractiveItemSumStatesSwitcher moneySumStatesSwitcher;

		private int moneyAmountHeld;

		public int MoneyAmountHeld => moneyAmountHeld;

		public void SetUp(int moneyAmount)
		{
			moneyAmountHeld = moneyAmount;
			RefreshView();
		}

		public void AddMoney(int moneyAmount)
		{
			moneyAmountHeld += moneyAmount;
			RefreshView();
		}

		private void RefreshView()
		{
			moneySumStatesSwitcher.UpdateState(moneyAmountHeld);
		}
	}
}
