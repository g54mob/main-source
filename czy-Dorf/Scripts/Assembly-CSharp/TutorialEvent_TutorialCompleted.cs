using UnityEngine;

public class TutorialEvent_TutorialCompleted : TutorialEvent
{
	[SerializeField]
	private VfxManager vfxManager;

	[SerializeField]
	private SessionQuest tutorialSessionQuest;

	public override void Begin()
	{
		tutorialManager.SetTutorialPlayed(newValue: true);
		if (tutorialSessionQuest.CurrentLevelIndex > 0)
		{
			vfxManager.AddSessionQuestEffectToQueue(tutorialSessionQuest, 0, SessionQuestFxType.ChallengeFulfilled);
		}
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
	}
}
