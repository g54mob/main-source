using System;

public class FadeToTitleScreenTransitionState : TransitionState
{
	public Action onFadeFinished;

	public override void OnEnter()
	{
		WorldTime.PauseSimulation();
		TransitionManager.TriggerTransitionEnter(2f, onFadeFinished);
	}

	public override void OnExit()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool ExitCondition()
	{
		return false;
	}
}
