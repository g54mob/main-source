public class StartFadeTransitionState : TransitionState
{
	public override void OnEnter()
	{
		if (WorldTime.instance != null)
		{
			WorldTime.PauseSimulation();
		}
		TransitionManager.ShowBlend();
	}

	public override void OnExit()
	{
		if (WorldTime.instance != null)
		{
			WorldTime.ResumeSimulation();
		}
		TransitionManager.TriggerTransitionExit(2f);
	}

	public override void OnUpdate()
	{
		TransitionManager.ShowBlend();
	}
}
