using System.ComponentModel;
using Restory.Gameplay.MoneyCash;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class MoneyCheats : SRDebugCheatBase
	{
		private readonly CashMoneyService cashMoneyService;

		private const string COMMON_CATEGORY = "Money Cheats";

		[Category("Money Cheats")]
		[DisplayName("Add ¥1,000")]
		public void AddOneThousand()
		{
			cashMoneyService.AddMoneyFromNpcToWindowSpace(1000);
			Debug.Log("Cheat command: AddOneThousand success – ¥1,000 granted");
		}

		[Category("Money Cheats")]
		[DisplayName("Add ¥10,000")]
		public void AddTenThousand()
		{
			cashMoneyService.AddMoneyFromNpcToWindowSpace(10000);
			Debug.Log("Cheat command: AddTenThousand success – ¥10,000 granted");
		}

		[Category("Money Cheats")]
		[DisplayName("Add ¥100,000")]
		public void AddOneHundredThousand()
		{
			cashMoneyService.AddMoneyFromNpcToWindowSpace(100000);
			Debug.Log("Cheat command: AddOneHundredThousand success – ¥100,000 granted");
		}

		[Category("Money Cheats")]
		[DisplayName("Add ¥1,000,000")]
		public void AddOneMillion()
		{
			cashMoneyService.AddMoneyFromNpcToWindowSpace(1000000);
			Debug.Log("Cheat command: AddOneMillion success – ¥1,000,000 granted");
		}

		[Inject]
		public MoneyCheats(CashMoneyService cashMoneyService)
		{
			this.cashMoneyService = cashMoneyService;
		}
	}
}
