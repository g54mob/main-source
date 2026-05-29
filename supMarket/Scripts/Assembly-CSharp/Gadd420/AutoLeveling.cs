using UnityEngine;

namespace Gadd420
{
	public class AutoLeveling : MonoBehaviour
	{
		private Vector3 flatFwd;

		private Vector3 flatRight;

		private float forwardDot;

		private float rightDot;

		private Rigidbody rb;

		private RB_Controller rbController;

		private Input_Manager inputs;

		private GroundAngle groundAngle;

		[Header("Gyro Strength Recommended 2")]
		public float autoLevelForce;

		private CrashController crashScript;

		public bool safeWheelies;

		public float antiLoopStrength;

		public float maxWheelieAngle;

		public float maxAngleMultiplier;

		[Range(0f, 1f)]
		public float dotForAutoLevel;

		private float forwardAngle;

		public float antiSpinTorque;

		private float upAngluarVelocity;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void CalculateAngles()
		{
		}

		private void AutoLevel(Rigidbody rb)
		{
		}
	}
}
