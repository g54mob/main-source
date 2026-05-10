using UnityEngine;

namespace PG
{
	public class TrailerController : VehicleController
	{
		[Header("TrailerController")]
		[SerializeField]
		private Transform TrailerConnectorPosition;

		[SerializeField]
		private GameObject TrailerSupportObject;

		[SerializeField]
		private Vector3 ConnectedSupportPosition;

		[SerializeField]
		private Vector3 DisconnectedSupportPosition;

		[SerializeField]
		private float ConnectSpeed;

		[SerializeField]
		private ConfigurableJointConfig JointConfig;

		private CarLighting CarLighting;

		private CarController ConnectedToCar;

		private ConfigurableJoint ConfigurableJoint;

		private Vector3 SupportTargetPos;

		private bool AfterJointCreate;

		protected override void Awake()
		{
		}

		protected override void FixedUpdate()
		{
		}

		public void ConnectVehicle(CarController car = null)
		{
		}

		public void CreateJoint()
		{
		}
	}
}
