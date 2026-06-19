using TH20;
using UnityEngine;

public class SMB_Counter : SMB_ParameterSync
{
	public int _CounterStart;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		AnimationParameterSync[] components = animator.gameObject.GetComponents<AnimationParameterSync>();
		if (components.Length == 0 || string.IsNullOrEmpty(_outParamName))
		{
			SetParameter(animator);
			return;
		}
		AnimationParameterSync[] array = components;
		foreach (AnimationParameterSync animationParameterSync in array)
		{
			if (animationParameterSync.IsMaster(animator))
			{
				SetParameter(animator);
				animationParameterSync.Synchronise(this);
			}
		}
	}

	private void SetParameter(Animator animator)
	{
		animator.SetInteger(_outParamName, ++_CounterStart);
	}
}
