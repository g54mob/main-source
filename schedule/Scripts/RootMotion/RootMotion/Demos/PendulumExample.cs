using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class PendulumExample : MonoBehaviour
	{
		[Range(0f, 1f)]
		[Tooltip("The master weight of this script.")]
		public float weight;

		[Tooltip("Multiplier for the distance of the root to the target.")]
		public float hangingDistanceMlp;

		[HideInInspector]
		[Tooltip("Where does the root of the character land when weight is blended out?")]
		public Vector3 rootTargetPosition;

		[HideInInspector]
		[Tooltip("How is the root of the character rotated when weight is blended out?")]
		public Quaternion rootTargetRotation;

		public Transform target;

		public Transform leftHandTarget;

		public Transform rightHandTarget;

		public Transform leftFootTarget;

		public Transform rightFootTarget;

		public Transform pelvisTarget;

		public Transform bodyTarget;

		public Transform headTarget;

		public Vector3 pelvisDownAxis;

		private FullBodyBipedIK ik;

		private Quaternion rootRelativeToPelvis;

		private Vector3 pelvisToRoot;

		private float lastWeight;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
