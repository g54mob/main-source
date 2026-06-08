using UnityEngine;

namespace Kitchen
{
	public class RandomlyOffsetAnimator : MonoBehaviour
	{
		public Animator Animator;

		public void Start()
		{
			if (Animator != null)
			{
				Animator.speed = Random.Range(0.9f, 1.1f);
			}
		}
	}
}
