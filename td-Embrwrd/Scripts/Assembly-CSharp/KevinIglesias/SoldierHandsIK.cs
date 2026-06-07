using UnityEngine;

namespace KevinIglesias
{
	public class SoldierHandsIK : MonoBehaviour
	{
		public Transform retargeter;

		public Transform handEffector;

		public SoldierIKGoal hand;

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
