using UnityEngine;

public class TutorialEvent_SetQuestSystemConfiguration : TutorialEvent
{
	[SerializeField]
	private QuestSystemConfiguration newConfiguration;

	[SerializeField]
	private QuestManager questManager;

	public override void Begin()
	{
		questManager.SetConfiguration(newConfiguration);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
		Begin();
	}
}
