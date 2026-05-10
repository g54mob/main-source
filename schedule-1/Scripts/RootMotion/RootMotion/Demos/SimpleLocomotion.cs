using System;
using UnityEngine;

namespace RootMotion.Demos
{
	public class SimpleLocomotion : MonoBehaviour
	{
		[Serializable]
		public enum RotationMode
		{
			Smooth = 0,
			Linear = 1
		}

		[Tooltip("The component that updates the camera.")]
		public CameraController cameraController;

		[Tooltip("Acceleration of movement.")]
		public float accelerationTime;

		[Tooltip("Turning speed.")]
		public float turnTime;

		[Tooltip("If true, will run on left shift, if not will walk on left shift.")]
		public bool walkByDefault;

		[Tooltip("Smooth or linear rotation.")]
		public RotationMode rotationMode;

		[Tooltip("Procedural motion speed (if not using root motion).")]
		public float moveSpeed;

		private Animator animator;

		private float speed;

		private float angleVel;

		private float speedVel;

		private Vector3 linearTargetDirection;

		private CharacterController characterController;

		public bool isGrounded { get; private set; }

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void Rotate()
		{
		}

		private void Move()
		{
		}

		private Vector3 GetInputVector()
		{
			return default(Vector3);
		}

		private Vector3 GetInputVectorRaw()
		{
			return default(Vector3);
		}
	}
}
