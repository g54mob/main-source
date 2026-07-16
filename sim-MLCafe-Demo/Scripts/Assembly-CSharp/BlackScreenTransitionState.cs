using UnityEngine;

public class BlackScreenTransitionState : TransitionState
{
	[SerializeField]
	private UIContentAnimator animator;

	public override void OnEnter()
	{
		animator.BeginWithNormalState();
	}

	public override void OnExit()
	{
		animator.OnReverse();
	}

	public override void OnUpdate()
	{
	}
}
