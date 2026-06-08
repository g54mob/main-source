public class EventObjectiveElementItemClearLocation : EventObjectiveBase
{
	private ItemData.Element element;

	private bool isRunValid;

	private string locationId;

	public EventObjectiveElementItemClearLocation(int goal, ItemData.Element element, string elementName, string locationId = "any", string locationName = "any")
		: base("element_item_clears", goal)
	{
		this.element = element;
		this.locationId = locationId;
		if (locationId == "any")
		{
			description = string.Format(Te.xt("tid_q_basic_element_clear_location"), TranslateIfTID(elementName));
		}
		else
		{
			description = string.Format(Te.xt("tid_q_basic_element_clear_specific_location"), TranslateIfTID(locationName), TranslateIfTID(elementName));
		}
	}

	public override void Init()
	{
		GameStates.OnQuestStarting += HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
		Character.OnCharacterEquippedWeapon += HandleWeaponEquipped;
	}

	public override void End()
	{
		GameStates.OnQuestStarting -= HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted -= HandleQuestCompleted;
		Character.OnCharacterEquippedWeapon -= HandleWeaponEquipped;
	}

	private void HandleWeaponEquipped(Character c, Weapon w)
	{
		if (isRunValid && c == GameStates.Singleton.hero && w.element != element)
		{
			isRunValid = false;
		}
	}

	private bool OnlyElement()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.LeftHand != null && hero.LeftHand.element != element)
		{
			return false;
		}
		if (hero.RightHand != null && hero.RightHand.element != element)
		{
			return false;
		}
		return true;
	}

	private void HandleQuestStarted(Data.Quest quest)
	{
		isRunValid = OnlyElement();
		if (locationId != "any")
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
	}

	private void HandleQuestCompleted(Data.Quest quest, bool firstCompletion)
	{
		if (isRunValid)
		{
			AddProgress(quest.level, quest.level);
		}
	}
}
