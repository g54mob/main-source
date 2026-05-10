using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class PlayerCar : MonoBehaviour
	{
		public List<AxleInfo> axleInfos;

		public Transform centerOfMass;

		public float maxMotorTorque;

		public float maxSteeringAngle;

		private IVehicleLightsComponent lightsComponent;

		private bool mainLights;

		private bool brake;

		private bool reverse;

		private bool blinkLeft;

		private bool blinkRifgt;

		private float realtimeSinceStartup;

		private Rigidbody rb;

		private UIInput inputScript;

		private void Start()
		{
		}

		public void ApplyLocalPositionToVisuals(WheelCollider collider)
		{
		}

		public void FixedUpdate()
		{
		}

		private void Update()
		{
		}
	}
}
