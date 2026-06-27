using Restory.Gameplay.Common;
using Restory.Gameplay.TimeSystems;
using Restory.TimeSystems;
using Restory.Utils;
using UnityEngine;

namespace Restory.Gameplay.Shops.Devices
{
	public sealed class DeviceShopTimedLotsRemovingService
	{
		private readonly ShopsService shopsService;

		private readonly DeviceShopInteractor deviceShopInteractor;

		private readonly MainDayTimeSwitchingService mainDayTimeSwitchingService;

		private readonly GameCalendar gameCalendar;

		private readonly ActiveStateSwitcher activeStateSwitcher = new ActiveStateSwitcher(ActiveStateSwitcher.WorkMode.ActiveByDefaultAndRequestersMakeItInactive);

		private bool shouldRemoveTimedOutLotsWhenUnblocked;

		public DeviceShopTimedLotsRemovingService(ShopsService shopsService, DeviceShopInteractor deviceShopInteractor, GameCalendar gameCalendar)
		{
			this.deviceShopInteractor = deviceShopInteractor;
			this.gameCalendar = gameCalendar;
			this.shopsService = shopsService;
		}

		public void BlockLotsRemoving(IActiveStateSwitchRequester blockingSource)
		{
			activeStateSwitcher?.AddRequester(blockingSource);
		}

		public void UnblockLotsRemoving(IActiveStateSwitchRequester blockingSource)
		{
			if (activeStateSwitcher != null && !(shopsService == null) && gameCalendar.MonoShellExists())
			{
				activeStateSwitcher.RemoveRequester(blockingSource);
				if (shouldRemoveTimedOutLotsWhenUnblocked)
				{
					RemoveTimedOutLots();
					shouldRemoveTimedOutLotsWhenUnblocked = false;
				}
			}
		}

		public void RemoveTimedOutLotsIfPossible()
		{
			if (!activeStateSwitcher.ShouldSystemBeActive)
			{
				shouldRemoveTimedOutLotsWhenUnblocked = true;
			}
			else
			{
				RemoveTimedOutLots();
			}
		}

		private void RemoveTimedOutLots()
		{
			for (int num = shopsService.Lots.Count - 1; num >= 0; num--)
			{
				ILot lot = shopsService.Lots[num];
				if ((!(lot is Object obj) || (bool)obj) && lot != null && lot.DaysBeforeRemoving >= 0 && gameCalendar.CurrentDayNumber > lot.Day + lot.DaysBeforeRemoving)
				{
					shopsService.RemoveDeviceFromShop(lot);
					deviceShopInteractor.TryToRemoveLotFromShoppingCart(lot);
				}
			}
		}
	}
}
