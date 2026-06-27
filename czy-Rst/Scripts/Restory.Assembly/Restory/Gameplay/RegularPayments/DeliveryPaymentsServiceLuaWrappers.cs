using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.RegularPayments;
using Zenject;

namespace Restory.Gameplay.RegularPayments
{
	public class DeliveryPaymentsServiceLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SendPaymentToDelivery = "SendPaymentToDelivery";

			public static readonly string DeliverPaymentObject = "DeliverPaymentObject";
		}

		private readonly DeliveryPaymentsService deliveryPaymentsService;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public DeliveryPaymentsServiceLuaWrappers(DeliveryPaymentsService deliveryPaymentsService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			this.deliveryPaymentsService = deliveryPaymentsService;
		}

		public void Initialize()
		{
			Lua.RegisterFunction(LuaNames.SendPaymentToDelivery, this, SymbolExtensions.GetMethodInfo(() => SendPaymentToDelivery(string.Empty)));
			Lua.RegisterFunction(LuaNames.DeliverPaymentObject, this, SymbolExtensions.GetMethodInfo(() => DeliverPaymentObject(string.Empty)));
		}

		public void Dispose()
		{
			Lua.UnregisterFunction(LuaNames.SendPaymentToDelivery);
			Lua.UnregisterFunction(LuaNames.DeliverPaymentObject);
		}

		private void SendPaymentToDelivery(string paymentID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RegularPaymentInfo>(paymentID, out var entityInfo))
			{
				deliveryPaymentsService.SendToDelivery(entityInfo);
			}
		}

		private void DeliverPaymentObject(string paymentID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RegularPaymentInfo>(paymentID, out var entityInfo))
			{
				deliveryPaymentsService.DeliverPaymentObject(entityInfo);
			}
		}
	}
}
