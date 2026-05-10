using Gley.TrafficSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem
{
	[RequireComponent(typeof(Rigidbody))]
	public class TrailerComponent : MonoBehaviour, ITrafficParticipant
	{
		[Header("Object References")]
		[Tooltip("RigidBody of the vehicle")]
		public Rigidbody rb;

		[Tooltip("Empty GameObject used to rotate the vehicle from the correct point")]
		public Transform trailerHolder;

		[Tooltip("The point where the trailer attaches to the truck")]
		public Transform truckConnectionPoint;

		[Tooltip("The joint that will connect to the truck")]
		public ConfigurableJoint joint;

		[Tooltip("All trailer wheels and their properties")]
		public Wheel[] allWheels;

		[Tooltip("If suspension is set to 0, the value of suspension will be half of the wheel radius")]
		public float maxSuspension;

		[Tooltip("How rigid the suspension will be. Higher the value -> more rigid the suspension")]
		public float springStiffness;

		[HideInInspector]
		public float width;

		[HideInInspector]
		public float height;

		[HideInInspector]
		public float length;

		private VehicleComponent _associatedVehicle;

		private float _springForce;

		internal void Initialize(VehicleComponent associatedVehicle)
		{
		}

		public float GetCurrentSpeedMS()
		{
			return 0f;
		}

		internal void DeactivateVehicle()
		{
		}

		internal int GetNrOfWheels()
		{
			return 0;
		}

		internal float GetSpringForce()
		{
			return 0f;
		}

		internal float GetSpringStiffness()
		{
			return 0f;
		}
	}
}
