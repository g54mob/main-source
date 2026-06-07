using Factory.Pools;
using UnityEngine;

namespace Motorways.UI
{
	public class NewContentIndicator : MonoBehaviour, IReusable
	{
		private static readonly int Intro = Animator.StringToHash("Intro");

		private static readonly int Idle = Animator.StringToHash("Idle");

		private static readonly int Exit = Animator.StringToHash("Exit");

		[SerializeField]
		private Animator _animator;

		public bool IsHidden => _animator.GetCurrentAnimatorStateInfo(0).IsName("Exit");

		public void PlayIntro()
		{
			_animator.SetTrigger(Intro);
		}

		public void PlayIdle()
		{
			_animator.SetTrigger(Idle);
		}

		public void PlayExit()
		{
			_animator.SetTrigger(Exit);
		}

		public void Reset()
		{
			_animator.ResetTrigger(Intro);
			_animator.ResetTrigger(Idle);
			_animator.ResetTrigger(Exit);
		}
	}
}
