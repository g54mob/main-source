using UnityEngine;

namespace TH20
{
	public class SMB_RandomTransition : SMB_ParameterSync
	{
		public string[] _states;

		public float _blendTime = 0.25f;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			int value = Random.Range(0, _states.Length);
			AnimationParameterSync[] components = animator.gameObject.GetComponents<AnimationParameterSync>();
			if (components.Length == 0 || string.IsNullOrEmpty(_outParamName))
			{
				StartTransition(animator, value);
				return;
			}
			AnimationParameterSync[] array = components;
			foreach (AnimationParameterSync animationParameterSync in array)
			{
				if (animationParameterSync.IsMaster(animator))
				{
					animator.SetInteger(_outParamName, value);
					animationParameterSync.Synchronise(this);
					StartTransition(animator, value);
				}
			}
		}

		private void StartTransition(Animator animator, int value)
		{
			string stateName = _states[value];
			_ = animator.runtimeAnimatorController != null;
			animator.CrossFadeInFixedTime(stateName, _blendTime, 0);
		}

		public override void OnParameterSynced(Animator slave, Animator master)
		{
			if (master.runtimeAnimatorController != null && (bool)slave.runtimeAnimatorController)
			{
				int integer = slave.GetInteger(_outParamName);
				StartTransition(slave, integer);
				base.OnParameterSynced(slave, master);
			}
		}
	}
}
