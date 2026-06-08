using System;

public class EventObjectiveItemClearSpecificLocation : EventObjectiveBase
{
	private string itemId;

	private string locationID;

	private bool isRunValid;

	public EventObjectiveItemClearSpecificLocation(int goal, string itemId, string itemName, string locationID, string locationName)
		: base("item_clears_location", goal)
	{
		this.itemId = itemId;
		this.locationID = locationID;
		description = string.Format(Te.xt("tid_q_basic_location_clear_weapon"), TranslateIfTID(locationName).Trim(), TranslateIfTID(itemName));
	}

	public override void Init()
	{
		GameStates.OnQuestStarting += HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
		Character.OnCharacterUnequippedWeapon += HandleWeaponUnequipped;
		Level.OnCustomEvent = (Action<string, string>)Delegate.Combine(Level.OnCustomEvent, new Action<string, string>(HandleCustomEvent));
	}

	public override void End()
	{
		GameStates.OnQuestStarting -= HandleQuestStarted;
		QuestController.singleton.OnQuestCompleted -= HandleQuestCompleted;
		Character.OnCharacterUnequippedWeapon -= HandleWeaponUnequipped;
		Level.OnCustomEvent = (Action<string, string>)Delegate.Remove(Level.OnCustomEvent, new Action<string, string>(HandleCustomEvent));
	}

	private bool HasItem()
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
		if (HasItem() && quest.id == locationID)
		{
			isRunValid = true;
		}
	}

	private void HandleCustomEvent(string reason, string arg2)
	{
		if (isRunValid && reason == "complete")
		{
			AddProgress();
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
