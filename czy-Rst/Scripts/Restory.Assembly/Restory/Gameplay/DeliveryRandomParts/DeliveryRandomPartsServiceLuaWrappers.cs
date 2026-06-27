using System;
using PixelCrushers.DialogueSystem;
using Zenject;

namespace Restory.Gameplay.DeliveryRandomParts
{
	public class DeliveryRandomPartsServiceLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SendRandomPartsToDelivery = "SendRandomPartsToDelivery";

			public static readonly string ForcedRandomPartsDelivery = "ForcedRandomPartsDelivery";

			public static readonly string StartDeliveryRandomPartsNextDay = "StartDeliveryRandomPartsNextDay";

			public static readonly string StopDeliveryRandomParts = "StopDeliveryRandomParts";
		}

		private readonly DeliveryRandomPartsService deliveryRandomPartsService;

		public DeliveryRandomPartsServiceLuaWrappers(DeliveryRandomPartsService deliveryRandomPartsService)
		{
			this.deliveryRandomPartsService = deliveryRandomPartsService;
		}

		public void Initialize()
		{
			Lua.RegisterFunction(LuaNames.SendRandomPartsToDelivery, this, SymbolExtensions.GetMethodInfo(() => SendRandomPartsToDelivery(updateLastDayDeliveryWasSent: true)));
			Lua.RegisterFunction(LuaNames.ForcedRandomPartsDelivery, this, SymbolExtensions.GetMethodInfo(() => ForcedRandomPartsDelivery(updateLastDayDeliveryWasSent: true)));
			Lua.RegisterFunction(LuaNames.StartDeliveryRandomPartsNextDay, this, SymbolExtensions.GetMethodInfo(() => StartDeliveryRandomPartsNextDay()));
			Lua.RegisterFunction(LuaNames.StopDeliveryRandomParts, this, SymbolExtensions.GetMethodInfo(() => StopDeliveryRandomParts()));
		}

		public void Dispose()
		{
			Lua.UnregisterFunction(LuaNames.SendRandomPartsToDelivery);
			Lua.UnregisterFunction(LuaNames.ForcedRandomPartsDelivery);
			Lua.UnregisterFunction(LuaNames.StartDeliveryRandomPartsNextDay);
			Lua.UnregisterFunction(LuaNames.StopDeliveryRandomParts);
		}

		private void SendRandomPartsToDelivery(bool updateLastDayDeliveryWasSent)
		{
			deliveryRandomPartsService.SendToDelivery(updateLastDayDeliveryWasSent);
		}

		private void ForcedRandomPartsDelivery(bool updateLastDayDeliveryWasSent)
		{
			deliveryRandomPartsService.ForcedDelivery(updateLastDayDeliveryWasSent);
		}

		private void StartDeliveryRandomPartsNextDay()
		{
			deliveryRandomPartsService.StartDeliveryNextDay();
		}

		private void StopDeliveryRandomParts()
		{
			deliveryRandomPartsService.StopDelivery();
		}
	}
}
