using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnimatedMenuBase : MenuBase
	{
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private bool _resetParametersOnEnable;

		protected virtual void OnEnable()
		{
			if (_resetParametersOnEnable && _animator != null && _animator.runtimeAnimatorController != null)
			{
				_animator.SetBool("Close", IsClosed() || IsClosing());
			}
		}

		public override void OpenMenu()
		{
			if (IsClosing() || IsClosed() || IsFirstOpen())
			{
				base.OpenMenu();
				if (_animator != null && _animator.runtimeAnimatorController != null)
				{
					_animator.SetBool("Close", value: false);
				}
			}
		}

		public override void CloseMenu()
		{
			if (!IsClosing() && !IsClosed())
			{
				base.CloseMenu();
				if (base.isActiveAndEnabled && _animator != null && _animator.runtimeAnimatorController != null)
				{
					_animator.SetBool("Close", value: true);
				}
			}
		}

		protected override bool HasMenuClosed()
		{
			if (base.isActiveAndEnabled && !(_animator == null) && !(_animator.runtimeAnimatorController == null))
			{
				return _animator.IsInState("Exit");
			}
			return true;
		}

		protected bool GetAnimatorParameterBool(string parameterName)
		{
			return _animator.GetBool(parameterName);
		}

		protected int GetAnimatorParameterInt(string parameterName)
		{
			return _animator.GetInteger(parameterName);
		}

		protected float GetAnimatorParameterFloat(string parameterName)
		{
			return _animator.GetFloat(parameterName);
		}

		protected AnimatorStateInfo GetAnimatorState()
		{
			return _animator.GetCurrentAnimatorStateInfo(0);
		}
	}
}
