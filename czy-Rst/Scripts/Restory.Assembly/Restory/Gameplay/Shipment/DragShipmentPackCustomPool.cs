using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class DragShipmentPackCustomPool : MonoBehaviour
	{
		[SerializeField]
		private DragShipmentPack dragShipmentPackPrefab;

		private DragShipmentPack dragShipmentPack;

		public DragShipmentPack GetPack()
		{
			if (!dragShipmentPack)
			{
				dragShipmentPack = Object.Instantiate(dragShipmentPackPrefab, base.transform);
			}
			dragShipmentPack.gameObject.SetActive(value: true);
			return dragShipmentPack;
		}

		public void ReleasePack(DragShipmentPack pack)
		{
			if ((bool)dragShipmentPack)
			{
				dragShipmentPack.gameObject.SetActive(value: false);
				dragShipmentPack.transform.SetParent(base.transform);
			}
			if ((bool)pack && pack != dragShipmentPack)
			{
				Object.Destroy(pack.gameObject);
			}
		}
	}
}
