using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[RequireComponent(typeof(Animator))]
	public class AnimationSpeed : MonoBehaviour
	{
		[Min(0f)]
		public float speed = 1f;

		private Animator animator;

		private void Awake()
		{
			animator = GetComponent<Animator>();
		}

		private void Start()
		{
			animator.speed = speed;
		}
	}
}
