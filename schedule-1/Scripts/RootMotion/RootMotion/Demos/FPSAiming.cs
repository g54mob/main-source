using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class FPSAiming : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float aimWeight;

		[Range(0f, 1f)]
		public float sightWeight;

		[Range(0f, 180f)]
		public float maxAngle;

		public Vector3 aimOffset;

		public bool animatePhysics;

		public Transform gun;

		public Transform gunTarget;

		public FullBodyBipedIK ik;

		public AimIK gunAim;

		public AimIK headAim;

		public CameraControllerFPS cam;

		public Recoil recoil;

		[Range(0f, 1f)]
		public float cameraRecoilWeight;

		private Vector3 gunTargetDefaultLocalPosition;

		private Vector3 gunTargetDefaultLocalRotation;

		private Vector3 camDefaultLocalPosition;

		private Vector3 camRelativeToGunTarget;

		private bool updateFrame;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void Aiming()
		{
		}

		private void LookDownTheSight()
		{
		}

		private void RotateCharacter()
		{
		}
	}
}
