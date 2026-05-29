using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(Animator))]
	public class DebugPlayAnim : MonoBehaviour
	{
		private Animator _animator;

		[SerializeField]
		private string _animationState;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void OnEnable()
		{
			_animator.CrossFadeInFixedTime(_animationState, 0.2f);
		}
	}
}
