using UnityEngine;

namespace Script
{
	public class StartAnimationRandomizer : MonoBehaviour
	{
		private Animator _animator;

		private void Start()
		{
			_animator = GetComponent<Animator>();
			AnimatorStateInfo currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
			_animator.Play(currentAnimatorStateInfo.fullPathHash, 0, Random.Range(0f, 1f));
		}
	}
}
