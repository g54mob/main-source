using UnityEngine;

public class SessionQuest_Tutorial : SessionQuest
{
	private TutorialManager tutorialManager;

	public override bool SelectableInClassicMode => false;

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		tutorialManager = Object.FindObjectOfType<TutorialManager>();
		if ((bool)tutorialManager)
		{
			tutorialManager.OnPhaseChanged += AddProgress;
			base.StartWatching(sessionQuestWatcher);
		}
	}

	private void AddProgress(int currentPhase)
	{
		currentProgress = currentPhase;
		ProgressChanged(save: false);
		ExecuteFulfillment();
	}

	public override void StopWatching()
	{
		if ((bool)tutorialManager)
		{
			tutorialManager.OnPhaseChanged -= AddProgress;
			tutorialManager = null;
			base.StopWatching();
		}
	}
}
