using System;
using PixelCrushers.DialogueSystem;
using Zenject;

namespace Restory.Gameplay.MoneyCash
{
	public class MoneyCashLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string PutMoney = "CashMoney_PutMoneyOntoCounter";
		}

		private readonly CashMoneyService cashMoneyService;

		public MoneyCashLuaWrappers(CashMoneyService cashMoneyService)
		{
			this.cashMoneyService = cashMoneyService;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.PutMoney, this, SymbolExtensions.GetMethodInfo(() => PutMoneyIntoReceivingSpace(0f)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.PutMoney);
		}

		private void PutMoneyIntoReceivingSpace(float amount)
		{
			cashMoneyService.AddMoneyFromNpcToWindowSpace((int)amount);
		}
	}
}
