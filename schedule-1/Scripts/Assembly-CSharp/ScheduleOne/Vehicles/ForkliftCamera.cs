using UnityEngine;

namespace ScheduleOne.Vehicles
{
	public class ForkliftCamera : VehicleCamera
	{
		[SerializeField]
		[Header("Forklift References")]
		protected Transform forkCamPos;

		[SerializeField]
		protected Light guidanceLight;

		protected bool forkliftCamActive;

		protected override void Update()
		{
		}

		protected override void LateUpdate()
		{
		}
	}
}
