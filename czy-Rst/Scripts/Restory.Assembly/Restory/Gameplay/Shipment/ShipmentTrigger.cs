using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class ShipmentTrigger : MonoBehaviour
	{
		[SerializeField]
		private BoxCollider shipmentCollider;

		public bool IsActive
		{
			get
			{
				return shipmentCollider.enabled;
			}
			set
			{
				shipmentCollider.enabled = value;
			}
		}
	}
}
