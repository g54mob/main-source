using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PolyStang
{
	public class CarController : MonoBehaviour
	{
		public enum Axel
		{
			Front = 0,
			Rear = 1
		}

		[Serializable]
		public struct Wheel
		{
			public WheelCollider wheelCollider;

			public Axel axel;
		}

		public enum TypeOfSpeedLimit
		{
			noSpeedLimit = 0,
			simple = 1,
			squareRoot = 2
		}

		[Header("Accelerations and deaccelerations")]
		public float maxAcceleration;

		public float brakeAcceleration;

		public float torqueMultiplier;

		public float noInputDeacceleration;

		[Header("Steering")]
		public float turnSensitivity;

		public float maxSteerAngle;

		[Header("Speed limit")]
		public float frontMaxSpeed;

		public float rearMaxSpeed;

		public float empiricalCoefficient;

		public TypeOfSpeedLimit typeOfSpeedLimit;

		private float frontSpeedReducer;

		private float rearSpeedReducer;

		[Header("Audio")]
		[SerializeField]
		private float minPitch;

		[SerializeField]
		private float maxPitch;

		[SerializeField]
		private float pitchMultiplier;

		private AudioSource carAudioSource;

		[Header("Impact")]
		[SerializeField]
		private float minImpactVelocity;

		[SerializeField]
		private float impactSoundCooldown;

		private float lastImpactTime;

		[Header("General")]
		public Vector3 _centerOfMass;

		public List<Wheel> wheels;

		private Vector2 move;

		private Rigidbody carRb;

		private Action<InputAction.CallbackContext> movePerformed;

		private Action<InputAction.CallbackContext> dropPerformed;

		private InputController inputManager;

		private bool isPlayerDriving;

		[SerializeField]
		private Transform playerSeat;

		[SerializeField]
		private TrolleyTrigger trolleyTrigger;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void Move()
		{
		}

		private void Steer()
		{
		}

		private void BrakeAndDeacceleration()
		{
		}

		public void TakeTheWheel()
		{
		}

		private void LeaveTheTrolley()
		{
		}

		private void StopCar()
		{
		}

		private void HandleAudio()
		{
		}

		private void TurnOffCollidersInTrolley()
		{
		}

		private void TurnBackOnCollidersInTRolley()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
