using UnityEngine;

namespace Brewery.Vehicle
{
	public class VehiclePassengerIK : MonoBehaviour
	{
		[Header("IK Weights")]
		[Range(0f, 1f)]
		[SerializeField]
		private float footIkWeight;

		[SerializeField]
		private float ikBlendSpeed;

		private Animator animator;

		private Transform leftFootTarget;

		private Transform rightFootTarget;

		private float currentFootWeight;

		private bool isActivePassenger;

		private bool savedApplyRootMotion;

		private bool rootMotionSaved;

		public bool IsActive => false;

		public void Initialize(Transform leftFoot, Transform rightFoot)
		{
		}

		public void ClearTargets()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}
	}
}
