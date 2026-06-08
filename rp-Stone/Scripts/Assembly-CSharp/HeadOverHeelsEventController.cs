public class HeadOverHeelsEventController : BaseEventController2
{
	private static HeadOverHeelsEventController instance;

	public static HeadOverHeelsEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new HeadOverHeelsEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "hoh";
	}

	public override int GetMaxDailyObjectives()
	{
		return 15;
	}

	public override void InitObjectives()
	{
		AddObjective(new EventObjectiveStunFoesWithWeapon(90, "stun", "grappling_hook", "tid_item_04"));
		AddObjective(new EventObjectiveItemClearLocation(15, "grappling_hook", "tid_item_04"));
		AddObjective(new EventObjectiveSkullGame(1).SetMaxPlays(2));
		AddObjective(new EventObjectiveDefeatFoeType(50, "skeleton", "tid_quest_foe_type_12"));
		AddObjective(new EventObjectiveDefeatSpecificFoe(1600, "skeleton_boss", "tid_quest_boss_04", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(3));
		AddObjective(new EventObjectiveCompleteQuest(1, "epic_wild_ride", "tid_q_wrd_title").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveCraftElement(6, ItemData.Element.AEther, "tid_element_aether").SetMaxPlays(1));
		AddObjective(new EventObjectiveStunBossesWithWeapon(30, "stun", "grappling_hook", "tid_item_04"));
		AddObjective(new EventObjectiveOpenTreasure(1, "skullnata", "tid_treasure_skullnata").SetMaxPlays(1));
		AddObjective(new EventObjectiveWeaponDamage(8000, "skeleton_arm", "tid_item_50"));
		AddObjective(new EventObjectiveGetMindStone());
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(40, "import Cosmetics/PetSkully"));
		AddObjective(new EventObjectiveAbilityDamage(75, "pick_pocket", "tid_item_50").SetMaxPlays(1));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(40, "import Cosmetics/Hats/Skully"));
		AddObjective(new EventObjectiveAbilityDamage(2000, "blade_of_god", "tid_item_33").SetMaxPlays(2));
		AddObjective(new EventObjectiveRem5Requirement());
		AddObjective(new EventObjectiveCompleteWeekly().SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveReferral(1).SetMaxPlays(2));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(60, "import Cosmetics/PetCranius").SetMaxPlays(1));
		AddObjective(new EventObjectiveStonescriptAbility(5, "skeleton_arm", "tid_item_50").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveCompleteDaily(1));
	}
}
