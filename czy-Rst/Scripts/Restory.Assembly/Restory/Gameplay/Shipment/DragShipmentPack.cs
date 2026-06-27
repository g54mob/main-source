using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class DragShipmentPack : MonoBehaviour
	{
		[SerializeField]
		private ShipmentPackLabel packLabel;

		public void Init(InteractiveObject targetObject)
		{
			base.gameObject.SetActive(value: true);
			base.transform.SetPositionAndRotation(targetObject.transform.position, targetObject.transform.rotation);
			if (targetObject is DeviceContainer deviceContainer)
			{
				packLabel.Init(deviceContainer.Device.Info.Icon);
				return;
			}
			if (targetObject.TryGetComponent<DecorObject>(out var component))
			{
				packLabel.Init(component.Info.Icon);
				return;
			}
			Debug.LogError("Unexpected type of InteractiveObject in DragShipmentPack");
			packLabel.Init(null);
		}
	}
}
