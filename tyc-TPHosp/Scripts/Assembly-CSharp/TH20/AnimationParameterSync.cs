using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnimationParameterSync : MonoBehaviour
	{
		private Animator _masterAnimator;

		private Animator _slaveAnimator;

		public void Setup(Animator masterAnimator, Animator slaveAnimator, bool sync)
		{
			_masterAnimator = masterAnimator;
			_slaveAnimator = slaveAnimator;
			if (sync)
			{
				SynchroiseAll();
			}
		}

		public bool IsMaster(Animator animator)
		{
			return _masterAnimator == animator;
		}

		public bool IsSlave(Animator animator)
		{
			return _slaveAnimator == animator;
		}

		private void SynchroiseAll()
		{
			if (_masterAnimator.runtimeAnimatorController != null)
			{
				AnimatorControllerParameter[] parameters = _masterAnimator.parameters;
				foreach (AnimatorControllerParameter param in parameters)
				{
					SyncParameter(param);
				}
			}
		}

		public void Synchronise(SMB_ParameterSync sync)
		{
			if (!(_masterAnimator.runtimeAnimatorController != null))
			{
				return;
			}
			string outParamName = sync._outParamName;
			AnimatorControllerParameter[] parameters = _masterAnimator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.name == outParamName)
				{
					SyncParameter(animatorControllerParameter);
					sync.OnParameterSynced(_slaveAnimator, _masterAnimator);
					break;
				}
			}
		}

		private void SyncParameter(AnimatorControllerParameter param)
		{
			if (!(_masterAnimator.runtimeAnimatorController != null) || !_slaveAnimator.HasParameter(param.name))
			{
				return;
			}
			switch (param.type)
			{
			case AnimatorControllerParameterType.Float:
				_slaveAnimator.SetFloat(param.name, _masterAnimator.GetFloat(param.name));
				break;
			case AnimatorControllerParameterType.Int:
				_slaveAnimator.SetInteger(param.name, _masterAnimator.GetInteger(param.name));
				break;
			case AnimatorControllerParameterType.Bool:
				_slaveAnimator.SetBool(param.name, _masterAnimator.GetBool(param.name));
				break;
			case AnimatorControllerParameterType.Trigger:
				if (_masterAnimator.GetBool(param.name))
				{
					_slaveAnimator.SetTrigger(param.name);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
