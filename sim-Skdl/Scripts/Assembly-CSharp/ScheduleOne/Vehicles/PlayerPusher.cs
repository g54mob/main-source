using UnityEngine;

namespace ScheduleOne.Vehicles
{
	[RequireComponent(typeof(BoxCollider))]
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerPusher : MonoBehaviour
	{
		private LandVehicle veh;

		[Header("Settings")]
		public float MinSpeedToPush;

		public float MaxPushSpeed;

		public float MinPushForce;

		public float MaxPushForce;

		private Collider collider;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetEnabled(bool isEnabled)
		{
		}

		private void OnTriggerStay(Collider other)
		{
		}
	}
}
