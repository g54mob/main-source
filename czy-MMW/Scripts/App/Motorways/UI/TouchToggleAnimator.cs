using UnityEngine;

namespace Motorways.UI
{
	[RequireComponent(typeof(Animator))]
	public class TouchToggleAnimator : MonoBehaviour
	{
		public TouchToggle toggle;

		public string IsOnAnimationTrigger;

		public string IsOffAnimationTrigger;

		private bool _isOnVisually;

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			if (toggle.IsOn && !_isOnVisually)
			{
				_animator.SetTrigger(IsOnAnimationTrigger);
				_isOnVisually = true;
			}
			else if (!toggle.IsOn && _isOnVisually)
			{
				_animator.SetTrigger(IsOffAnimationTrigger);
				_isOnVisually = false;
			}
		}
	}
}
