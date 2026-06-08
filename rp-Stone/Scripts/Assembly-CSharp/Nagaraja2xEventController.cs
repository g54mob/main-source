public class Nagaraja2xEventController : BaseEventController2
{
	private static Nagaraja2xEventController instance;

	public static Nagaraja2xEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new Nagaraja2xEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "nagaraja_2x";
	}

	public override int GetMaxDailyObjectives()
	{
		return 15;
	}

	public override void InitObjectives()
	{
		AddObjective(new EventObjectiveCraftElement(6, ItemData.Element.Poison, "tid_element_poison").SetMaxPlays(2));
		AddObjective(new EventObjectiveElementDebuffFoes(150, ItemData.Element.Poison, "tid_element_poison"));
		AddObjective(new EventObjectiveDefeatSpecificFoe(450, "nagaraja", "tid_quest_boss_07", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(3));
		AddObjective(new EventObjectiveDefeatFoeType(50, "serpent", "tid_quest_foe_type_13", 10));
		AddObjective(new EventObjectiveCompleteQuest(1, "epic_initiate", "tid_q_ini_title").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveElementDamage(6000, ItemData.Element.Poison, "tid_element_poison"));
		AddObjective(new EventObjectiveItemClearSpecificLocation(1, "cult_mask", "tid_relic_53", "cross_bridge", "tid_brige_2").SetMaxPlays(1));
		AddObjective(new EventObjectiveOpenTreasure(1, "treasure_4", "tid_treasure_DT").SetMaxPlays(1));
		AddObjective(new EventObjectiveSightstoneSpecificFoe(1, "nagaraja", "tid_quest_boss_07").SetMaxPlays(1));
		AddObjective(new EventObjectiveMaskDebuffBosses(75));
		AddObjective(new EventObjectivePreventDamageWithPoison(30));
		AddObjective(new EventObjectiveGetMindStone());
		AddObjective(new EventObjectiveStonescriptAbility(5, "mask", "tid_relic_53").SetMaxPlays(1));
		AddObjective(new EventObjectivePerfectRun(1, "temple", "tid_temple_0").SetMaxPlays(1));
		AddObjective(new EventObjectiveCompleteDaily(1));
		AddObjective(new EventObjectiveItemClearSpecificLocation(1, "cult_mask", "tid_relic_53", "temple", "tid_temple_0").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveReferral(1).SetMaxPlays(2));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(60, "import Cosmetics/PetDragon").SetMobile(enabled: false));
		AddObjective(new EventObjectiveDefeatFoeType(90, "Vigor", "tid_element_vigor"));
		AddObjective(new EventObjectiveAbilityDamage(30, "mask", "tid_relic_53").SetMaxPlays(1));
		AddObjective(new EventObjectiveBuyTreasure(1));
		AddObjective(new EventObjectiveHeal(80, countOverHeal: true));
		AddObjective(new EventObjectiveElementItemClearLocation(1, ItemData.Element.Poison, "tid_element_poison").SetMaxPlays(1).SetPoints(2));
	}
}
