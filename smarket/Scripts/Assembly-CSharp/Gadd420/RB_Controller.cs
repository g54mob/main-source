using UnityEngine;

namespace Gadd420
{
	[RequireComponent(typeof(Rigidbody), typeof(AutoLeveling), typeof(CrashController))]
	[RequireComponent(typeof(Input_Manager), typeof(AudioSource), typeof(NitrousManager))]
	[RequireComponent(typeof(GroundAngle))]
	public class RB_Controller : MonoBehaviour
	{
		public WheelRotationAxis wheelRotationAxis;

		[Header("Combine Brake Inputs MUST be off")]
		public bool enableStoppiesBETA;

		private Rigidbody rb;

		private Input_Manager inputs;

		private NitrousManager nitrousScript;

		private float maxLeanRight;

		private float maxLeanLeft;

		[HideInInspector]
		public bool isGrounded;

		[HideInInspector]
		public bool isCrashed;

		private bool reversing;

		[Header("All angles are in Degrees and Speed in MPH")]
		[Space]
		[Header("Engine Properties")]
		public float firstGearTorque;

		public float topGearTorque;

		public bool isAutomatic;

		[Space]
		public bool useKmph;

		[Header("MPH or KMPH")]
		public float maxSpeed;

		public float maxReverseSpeed;

		[HideInInspector]
		public float msToMph;

		private float msToKmph;

		[HideInInspector]
		public float currentSpeed;

		private float rpm;

		[Space]
		[Header("Gears")]
		public int numGears;

		[HideInInspector]
		public int currentGear;

		[Space]
		[Header("Engine Braking")]
		public bool useEngineBraking;

		public float engineBrakingDrag;

		private float ogTorque;

		private float wheelRPM;

		private float currentGearPercent;

		private float torqueDifference;

		[Space]
		[Header("Brakes")]
		public float frontBrakeTorque;

		public float backBrakeTorque;

		[Space]
		[Header("Lean Values")]
		public float LeanSteerAmount;

		public float maxLeanAngle;

		public float minLeanTorque;

		public float maxLeanTorque;

		public float speedForMaxLean;

		private float currentLeanTorque;

		[Space]
		[Header("Steer Values")]
		public float minSteerAngle;

		public float maxSteerAngle;

		public float speedForMinSteer;

		public float steerLeanTorque;

		[Space]
		[Header("Misc Properties")]
		public float wheelieTorque;

		private float ogWheelieTorque;

		public float stoppieTorque;

		public float backFlipTorque;

		public float inAirSpinTorque;

		[Space]
		[Header("Wheel Colliders")]
		public WheelCollider[] wheelColliders;

		[Space]
		[Header("Wheel Positions")]
		public GameObject[] wheels;

		[Space]
		[Header("Fork Pivot")]
		public GameObject forkPivot;

		[Space]
		[Header("Centre Of Gravity")]
		public Transform cog;

		[Space]
		[Header("Audio")]
		public float lowPitch;

		public float highPitch;

		private AudioSource sound;

		private float ogDrag;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void HandleSteering()
		{
		}

		private void HandleLeanSpeed()
		{
		}

		private void HandleEngine()
		{
		}

		private void SetWheelMeshPos()
		{
		}

		private void CalculateTorque()
		{
		}

		private void AddTorque()
		{
		}

		private void HandleBrakes()
		{
		}

		private void EngineBraking()
		{
		}

		private void GroundCheck()
		{
		}

		private void Stoppies()
		{
		}
	}
}
