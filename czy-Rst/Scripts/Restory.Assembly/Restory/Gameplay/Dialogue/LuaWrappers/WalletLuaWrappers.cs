using System;
using PixelCrushers.DialogueSystem;
using Restory.Gameplay.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Dialogue.LuaWrappers
{
	public class WalletLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string CheckCurrentMoney = "Wallet_GetMoneyAmount";

			public static readonly string AddMoney = "Wallet_AddMoneyAmount";

			public static readonly string SubtractMoney = "Wallet_SubtractMoneyAmount";
		}

		private readonly Wallet wallet;

		public WalletLuaWrappers(Wallet wallet)
		{
			this.wallet = wallet;
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
			Lua.RegisterFunction(LuaNames.CheckCurrentMoney, this, SymbolExtensions.GetMethodInfo(() => GetCurrentMoneyAmount()));
			Lua.RegisterFunction(LuaNames.AddMoney, this, SymbolExtensions.GetMethodInfo(() => AddMoney(0f)));
			Lua.RegisterFunction(LuaNames.SubtractMoney, this, SymbolExtensions.GetMethodInfo(() => SubtractMoney(0f)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.CheckCurrentMoney);
			Lua.UnregisterFunction(LuaNames.AddMoney);
			Lua.UnregisterFunction(LuaNames.SubtractMoney);
		}

		private int GetCurrentMoneyAmount()
		{
			return wallet.MoneyAvailable;
		}

		private void AddMoney(float amountToAdd)
		{
			wallet.TryToAdd(Mathf.FloorToInt(amountToAdd));
		}

		private void SubtractMoney(float amountToSubtract)
		{
			wallet.TryToRemove(Mathf.FloorToInt(amountToSubtract));
		}
	}
}
