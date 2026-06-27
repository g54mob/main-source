using Restory.Gameplay.Shipment;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public sealed class ShipmentDevicePack : DevicePack, IShipmentPack
	{
		[SerializeField]
		private ShipmentPackLabel packLabel;

		public int DevicePrice { get; private set; }

		public Transform Transform => base.transform;

		public void Init(DeviceContainer deviceContainer, int devicePrice)
		{
			base.transform.SetPositionAndRotation(deviceContainer.transform.position, deviceContainer.transform.rotation);
			deviceContainer.transform.SetParent(base.transform);
			deviceContainer.gameObject.SetActive(value: false);
			base.DeviceContainer = deviceContainer;
			DevicePrice = devicePrice;
			packLabel.Init(deviceContainer.Device.Info.Icon);
		}
	}
}
