using UnityEngine;

namespace Vehicles
{
	public class VehiclePlace : MonoBehaviour
	{
		[SerializeField]
		private bool _isDriverPlace;

		private IVehicleDriver _driver;

		public Transform PlaceTransform => base.transform;

		public bool IsDriverPlace => _isDriverPlace;

		public IVehicleDriver Driver => _driver;
	}
}
