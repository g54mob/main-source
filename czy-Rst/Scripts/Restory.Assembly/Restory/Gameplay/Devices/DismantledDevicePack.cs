using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.WorkOrders;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public sealed class DismantledDevicePack : DevicePack
	{
		[SerializeField]
		private DevicePackLabel label;

		public override bool IsActivatable => base.State == InteractiveObjectState.Placed;

		public PlacedElements PlacedElements { get; private set; }

		public void Init(DeviceContainer deviceContainer, PlacedElements placedElements, OrderCategory orderCategory, Sprite customerIcon = null)
		{
			base.transform.SetPositionAndRotation(deviceContainer.transform.position, deviceContainer.transform.rotation);
			deviceContainer.transform.SetParent(base.transform);
			base.DeviceContainer = deviceContainer;
			PlacedElements = placedElements;
			label.Init(base.DeviceContainer.Device.Info, orderCategory, customerIcon);
		}

		public void RestorePackLabel(OrderCategory orderCategory, Sprite customerIcon = null)
		{
			label.Init(base.DeviceContainer.Device.Info, orderCategory, customerIcon);
		}

		protected override void SetPackState()
		{
			base.SetPackState();
			if (base.State == InteractiveObjectState.Stored && base.DeviceContainer.State == InteractiveObjectState.Placed)
			{
				base.DeviceContainer.CachePlacedElements(PlacedElements);
			}
		}

		public override void Clear()
		{
			base.Clear();
			PlacedElements = null;
			label.Cleanup();
		}
	}
}
