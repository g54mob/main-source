using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.WorkOrders;
using Restory.ObjectPools;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public abstract class DevicePackageBase : InteractiveObjectPackage, ICleanableComponent, IDevicePackage
	{
		[SerializeField]
		private DevicePackLabel label;

		[SerializeField]
		private Transform tooltipTargetTransform;

		private DeviceContainer packedDevice;

		public Transform TooltipTargetTransform
		{
			get
			{
				if ((bool)tooltipTargetTransform)
				{
					return tooltipTargetTransform;
				}
				return base.transform;
			}
		}

		public DeviceContainer PackedDevice => packedDevice;

		public void Init(DeviceContainer deviceContainer, OrderCategory orderCategory, Sprite customerIcon)
		{
			packedDevice = deviceContainer;
			label.Init(deviceContainer.Device.Info, orderCategory, customerIcon);
			packageInteractionTrigger.Init(deviceContainer);
		}

		public void UpdatePackLabel(OrderCategory orderCategory, Sprite customerIcon = null)
		{
			label.Init(packedDevice.Device.Info, orderCategory, customerIcon);
		}

		public void Clean()
		{
			packedDevice = null;
			label.Cleanup();
			packageInteractionTrigger.Cleanup();
		}
	}
}
