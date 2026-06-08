public class EventObjectiveItemClearLocation : EventObjectiveBase
{
	private string itemId;

	private bool isRunValid;

	public EventObjectiveItemClearLocation(int goal, string itemId, string itemName)
		: base("item_clears", goal)
	{
		this.itemId = itemId;
		description = string.Format(Te.xt("tid_q_basic_weapon_clear"), TranslateIfTID(itemName));
	}

	public override void Init()
	{
		GameStates.OnQuestStarting += HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
		Character.OnCharacterUnequippedWeapon += HandleWeaponUnequipped;
	}

	public override void End()
	{
		GameStates.OnQuestStarting -= HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted -= HandleQuestCompleted;
		Character.OnCharacterUnequippedWeapon -= HandleWeaponUnequipped;
	}

	private bool HasGrapplingHook()
	{
		Hero hero = GameStates.Singleton.hero;
		if (!(hero.LeftHand != null) || !hero.LeftHand.id.Contains(itemId))
		{
			if (hero.RightHand != null)
			{
				return hero.RightHand.id.Contains(itemId);
			}
			return false;
		}
		return true;
	}

	private void HandleWeaponUnequipped(Character c, Weapon w)
	{
		if (isRunValid && c == GameStates.Singleton.hero && w.id.Contains(itemId))
		{
			isRunValid = false;
		}
	}

	private void HandleQuestStarted(Data.Quest quest)
	{
		isRunValid = HasGrapplingHook();
	}

	private void HandleQuestCompleted(Data.Quest quest, bool firstCompletion)
	{
		if (isRunValid)
		{
			AddProgress(quest.level, quest.level);
		}
	}
}
