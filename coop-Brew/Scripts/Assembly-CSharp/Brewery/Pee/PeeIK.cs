using UnityEngine;

namespace Brewery.Pee
{
	[RequireComponent(typeof(Animator))]
	public class PeeIK : MonoBehaviour
	{
		[Header("IK Targets (male only — female uses crouch animation, no IK)")]
		[SerializeField]
		private Transform leftHandTarget;

		[SerializeField]
		private Transform rightHandTarget;

		[Header("Blend Settings")]
		[Tooltip("How fast IK blends in/out (higher = faster)")]
		[SerializeField]
		private float blendSpeed;

		[Tooltip("Maximum IK weight (1 = full IK override)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float maxWeight;

		private Animator animator;

		private bool isActive;

		private float currentWeight;

		private float targetWeight;

		private void Awake()
		{
		}

		public void SetActive(bool active, bool female = false)
		{
		}

		private void Update()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		private void OnDisable()
		{
		}
	}
}
