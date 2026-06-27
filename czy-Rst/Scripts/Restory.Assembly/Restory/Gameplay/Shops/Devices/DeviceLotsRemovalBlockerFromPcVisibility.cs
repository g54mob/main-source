using System;
using Restory.Gameplay.Common;
using Restory.Gameplay.OverlayActivators;
using Zenject;

namespace Restory.Gameplay.Shops.Devices
{
	public sealed class DeviceLotsRemovalBlockerFromPcVisibility : IInitializable, IDisposable, IActiveStateSwitchRequester
	{
		private readonly PcActivator pcActivator;

		private readonly DeviceShopTimedLotsRemovingService deviceShopTimedLotsRemover;

		public DeviceLotsRemovalBlockerFromPcVisibility(DeviceShopTimedLotsRemovingService deviceShopTimedLotsRemover, PcActivator pcActivator)
		{
			this.deviceShopTimedLotsRemover = deviceShopTimedLotsRemover;
			this.pcActivator = pcActivator;
		}

		public void Initialize()
		{
			if (pcActivator.IsPcWindowVisible)
			{
				deviceShopTimedLotsRemover.BlockLotsRemoving(this);
			}
			pcActivator.OnPcWindowVisibilityChanged += ResolvePcWindowVisibilityChanged;
		}

		public void Dispose()
		{
			pcActivator.OnPcWindowVisibilityChanged -= ResolvePcWindowVisibilityChanged;
			deviceShopTimedLotsRemover?.UnblockLotsRemoving(this);
		}

		private void ResolvePcWindowVisibilityChanged()
		{
			if (pcActivator.IsPcWindowVisible)
			{
				deviceShopTimedLotsRemover.BlockLotsRemoving(this);
			}
			else
			{
				deviceShopTimedLotsRemover.UnblockLotsRemoving(this);
			}
		}
	}
}
