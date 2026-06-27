using UnityEngine;

namespace Restory.Gameplay.Storages
{
	public class DeliveryZoneBoxesSpawnPoints : MonoBehaviour
	{
		[SerializeField]
		private Transform devicesBoxSpawnPoint;

		[SerializeField]
		private Transform deliveryBoxSpawnPoint;

		public Transform DevicesBoxSpawnPoint => devicesBoxSpawnPoint;

		public Transform DeliveryBoxSpawnPoint => deliveryBoxSpawnPoint;
	}
}
