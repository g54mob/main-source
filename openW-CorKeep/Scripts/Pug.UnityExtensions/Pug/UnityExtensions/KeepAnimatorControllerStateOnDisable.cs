using UnityEngine;

namespace Pug.UnityExtensions
{
	[RequireComponent(typeof(Animator))]
	public class KeepAnimatorControllerStateOnDisable : MonoBehaviour
	{
		private Animator animator;

		private void Awake()
		{
			animator = GetComponent<Animator>();
			if (!animator.keepAnimatorStateOnDisable)
			{
				animator.keepAnimatorStateOnDisable = true;
			}
		}
	}
}
