using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public sealed class CompetitionDevicePack : DevicePack
	{
		[SerializeField]
		private CompetitionDevicePackLabel label;

		public override bool IsActivatable => base.State == InteractiveObjectState.Placed;

		public PlacedElements PlacedElements { get; private set; }

		public void Init(DeviceContainer deviceContainer, PlacedElements placedElements)
		{
			base.transform.SetPositionAndRotation(deviceContainer.transform.position, deviceContainer.transform.rotation);
			deviceContainer.transform.SetParent(base.transform);
			base.DeviceContainer = deviceContainer;
			PlacedElements = placedElements;
			label.Init(base.DeviceContainer.Device.Info);
		}

		public void RestorePackLabel()
		{
			label.Init(base.DeviceContainer.Device.Info);
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
