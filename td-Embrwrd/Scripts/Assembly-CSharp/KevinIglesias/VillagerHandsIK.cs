using UnityEngine;

namespace KevinIglesias
{
	public class VillagerHandsIK : MonoBehaviour
	{
		public Transform retargeter;

		public Transform handEffector;

		public VillagerIKGoal hand;

		private Animator animator;

		private float weight;

		private void Awake()
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
