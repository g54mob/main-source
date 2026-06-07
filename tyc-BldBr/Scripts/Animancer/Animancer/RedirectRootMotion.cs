using UnityEngine;

namespace Animancer
{
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/RedirectRootMotion_1")]
	[RequireComponent(typeof(Animator))]
	public abstract class RedirectRootMotion<T> : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The Animator which provides the root motion")]
		private Animator _Animator;

		[SerializeField]
		[Tooltip("The object which the root motion will be applied to")]
		private T _Target;

		public ref Animator Animator => ref _Animator;

		public ref T Target => ref _Target;

		public bool ApplyRootMotion
		{
			get
			{
				if (Target != null && Animator != null)
				{
					return Animator.applyRootMotion;
				}
				return false;
			}
		}

		protected virtual void OnValidate()
		{
			TryGetComponent<Animator>(out _Animator);
			if (_Target == null)
			{
				_Target = base.transform.parent.GetComponentInParent<T>();
			}
		}

		protected abstract void OnAnimatorMove();
	}
}
