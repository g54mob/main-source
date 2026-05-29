using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class VRIKArmMocap : MonoBehaviour
	{
		public VRIK ik;

		public Transform leftElbowTarget;

		public Transform rightElbowTarget;

		private void Start()
		{
		}

		private void AfterVRIK()
		{
		}

		private static void UpdateArm(Transform upperArm, Transform forearm, Transform hand, Transform elbowTarget, Transform handTarget)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
