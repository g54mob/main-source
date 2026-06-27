using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.RegularPayments;
using Zenject;

namespace Restory.Gameplay.RegularPayments
{
	public class RegularPaymentsLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string AddPayment = "RegularPayments_AddPayment";

			public static readonly string AddPaymentAndMakeFirstPaymentImmediately = "RegularPayments_AddPaymentAndMakeFirstPaymentImmediately";

			public static readonly string RemovePayment = "RegularPayments_RemovePayment";
		}

		private readonly RegularPaymentsService regularPaymentsService;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public RegularPaymentsLuaWrappers(RegularPaymentsService regularPaymentsService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.regularPaymentsService = regularPaymentsService;
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
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
			Lua.RegisterFunction(LuaNames.AddPayment, this, SymbolExtensions.GetMethodInfo(() => AddRegularPayment(string.Empty)));
			Lua.RegisterFunction(LuaNames.AddPaymentAndMakeFirstPaymentImmediately, this, SymbolExtensions.GetMethodInfo(() => AddRegularPaymentAndPayImmediately(string.Empty)));
			Lua.RegisterFunction(LuaNames.RemovePayment, this, SymbolExtensions.GetMethodInfo(() => RemoveRegularPayment(string.Empty)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.AddPayment);
			Lua.UnregisterFunction(LuaNames.AddPaymentAndMakeFirstPaymentImmediately);
			Lua.UnregisterFunction(LuaNames.RemovePayment);
		}

		private void AddRegularPaymentAndPayImmediately(string regularPaymentID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RegularPaymentInfo>(regularPaymentID, out var entityInfo))
			{
				regularPaymentsService.AddNewRegularPayment(entityInfo, sendFirstBillImmediately: true);
			}
		}

		private void AddRegularPayment(string regularPaymentID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RegularPaymentInfo>(regularPaymentID, out var entityInfo))
			{
				regularPaymentsService.AddNewRegularPayment(entityInfo);
			}
		}

		private void RemoveRegularPayment(string regularPaymentID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RegularPaymentInfo>(regularPaymentID, out var entityInfo))
			{
				regularPaymentsService.RemoveExistingRegularPayment(entityInfo);
			}
		}
	}
}
