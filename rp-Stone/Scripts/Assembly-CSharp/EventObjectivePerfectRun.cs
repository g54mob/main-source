public class EventObjectivePerfectRun : EventObjectiveBase
{
	private string locationId;

	private bool isRunValid;

	public EventObjectivePerfectRun(int goal, string locationId, string locationName)
		: base("perfect_run", goal)
	{
		this.locationId = locationId;
		description = string.Format(Te.xt("tid_q_basic_perfect_run"), TranslateIfTID(locationName));
	}

	public override void Init()
	{
		GameStates.OnQuestStarting += HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		GameStates.OnQuestStarting -= HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted -= HandleQuestCompleted;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (isRunValid && dmg.bullet != null && c == GameStates.Singleton.hero && dmg.startHitpoints != dmg.endHitpoints)
		{
			isRunValid = false;
		}
	}

	private void HandleQuestStarted(Data.Quest quest)
	{
		if (quest.id == locationId || (isRunValid && GameStates.Singleton.parentQuest != null && GameStates.Singleton.parentQuest.id == locationId))
		{
			isRunValid = true;
		}
		else
		{
			isRunValid = false;
		}
	}

	private void HandleQuestCompleted(Data.Quest quest, bool firstCompletion)
	{
		if (isRunValid)
		{
			AddProgress();
		}
	}
}
