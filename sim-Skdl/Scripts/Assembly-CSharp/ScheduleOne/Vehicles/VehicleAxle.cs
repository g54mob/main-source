using UnityEngine;

namespace ScheduleOne.Vehicles
{
	public class VehicleAxle : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		protected Wheel wheel;

		private Transform model;

		protected virtual void Awake()
		{
		}

		protected virtual void LateUpdate()
		{
		}
	}
}
