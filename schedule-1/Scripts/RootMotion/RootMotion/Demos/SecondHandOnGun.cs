using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class SecondHandOnGun : MonoBehaviour
	{
		public AimIK aim;

		public LimbIK leftArmIK;

		public Transform leftHand;

		public Transform rightHand;

		public GrounderFBBIK grounder;

		public Vector3 leftHandPositionOffset;

		public Vector3 leftHandRotationOffset;

		private Vector3 leftHandPosRelToRight;

		private Quaternion leftHandRotRelToRight;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
