using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class TwoHandedProp : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float weight;

		[Tooltip("The left hand target parented to the right hand.")]
		public Transform leftHandTarget;

		[Tooltip("Left hand poser (poses fingers to match the left hand target).")]
		public Poser leftHandPoser;

		[Range(0f, 1f)]
		[Tooltip("The weight of pinning the left hand to the prop.")]
		public float leftHandWeight;

		private FullBodyBipedIK ik;

		private Vector3 targetPosRelativeToRight;

		private Quaternion targetRotRelativeToRight;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private void AfterFBBIK()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
