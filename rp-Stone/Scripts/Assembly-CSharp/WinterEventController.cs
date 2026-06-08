public class WinterEventController : BaseEventController2
{
	private static WinterEventController instance;

	public static WinterEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new WinterEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "winter";
	}

	public override int GetMaxDailyObjectives()
	{
		return 15;
	}

	public override void InitObjectives()
	{
		AddObjective(new EventObjectiveCraftElement(5, ItemData.Element.Fire, "tid_element_fire", "shield", "tid_item_10").SetMaxPlays(1));
		AddObjective(new EventObjectiveDefeatFoeType(50, "Ice", "tid_element_ice"));
		AddObjective(new EventObjectiveDefeatSpecificFoe(800, "yeti", "tid_quest_boss_06", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(3));
		AddObjective(new EventObjectiveDebuffFoes(90, "debuff_dot", "tid_element_fire"));
		AddObjective(new EventObjectiveOpenTreasure(50).SetMaxPlays(2));
		AddObjective(new EventObjectiveVisitScotty().SetMaxPlays(1));
		AddObjective(new EventObjectiveVisitUulaa().SetMaxPlays(1));
		AddObjective(new EventObjectiveCraftElement(5, ItemData.Element.Ice, "tid_element_ice").SetMaxPlays(2));
		AddObjective(new EventObjectiveDebuffBosses(350, "debuff_chill", "tid_immune_to_debuff_chill"));
		AddObjective(new EventObjectiveElementDamage(8000, ItemData.Element.Ice, "tid_element_ice"));
		AddObjective(new EventObjectiveCompleteQuest(1, "epic_ascension", "tid_q_asc_title").SetMaxPlays(1));
		AddObjective(new EventObjectiveBuyTreasure(1));
		AddObjective(new EventObjectiveGetMindStone());
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(40, "import Cosmetics/SleepyStonehead"));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(40, "import Cosmetics/PetSnowBunny"));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(60, "import Cosmetics/PetSnowman").SetMaxPlays(1));
		AddObjective(new EventObjectiveRem5Requirement());
		AddObjective(new EventObjectiveCompleteWeekly().SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveReferral(1).SetMaxPlays(2));
		AddObjective(new EventObjectiveVisitLocationWithCosmetic(1, "waterfall", "tid_ftue_11", "import CozyCave").SetMaxPlays(1));
	}
}
