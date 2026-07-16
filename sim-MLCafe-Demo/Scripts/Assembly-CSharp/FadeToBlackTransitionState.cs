using System;

public class FadeToBlackTransitionState : TransitionState
{
	public Action onFadeFinished;

	public override void OnEnter()
	{
		if (WorldTime.instance != null)
		{
			WorldTime.PauseSimulation();
		}
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
