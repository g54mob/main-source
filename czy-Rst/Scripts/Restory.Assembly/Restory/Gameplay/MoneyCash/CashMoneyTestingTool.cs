using UnityEngine;
using Zenject;

namespace Restory.Gameplay.MoneyCash
{
	public class CashMoneyTestingTool : MonoBehaviour
	{
		private CashMoneyService cashMoneyService;

		[Inject]
		private void Construct(CashMoneyService cashMoneyService)
		{
			this.cashMoneyService = cashMoneyService;
		}

		private void AddMoneyToWindow(int amount)
		{
			cashMoneyService.AddMoneyFromNpcToWindowSpace(amount);
		}
	}
}
