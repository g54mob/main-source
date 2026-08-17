namespace VampireSurvivors.Framework.TimerSystem;

public class TimerManagerGame : TimerManager
{
	private void Update()
	{
		UpdateAllTimers();
	}

	private void FixedUpdate()
	{
		UpdateAllTimers();
	}

	protected override void OnPause()
	{
		PauseAllTimers();
	}

	protected override void OnResume()
	{
		ResumeAllTimers();
	}

	public void SyncPauseState()
	{
		HandlePauseResume();
	}
}
