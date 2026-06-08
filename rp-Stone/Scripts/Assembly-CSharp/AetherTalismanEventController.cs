public class AetherTalismanEventController : BaseEventController2
{
	private static AetherTalismanEventController instance;

	public static AetherTalismanEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new AetherTalismanEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "aether_talisman";
	}

	public override int GetMaxDailyObjectives()
	{
		return 15;
	}

	public override void InitObjectives()
	{
		string info = string.Format(Te.xt("tid_q_obj_mod_whileactive"), "[color=#00ffff]" + Te.xt("tid_q_basic_unmake_boss_title") + "[/color]") + Te.xt("tid_q_obj_mod_desc_unmake_boss") + Te.xt("tid_q_obj_mod_note_notimeupdate");
		string text = Te.xt("tid_item_49");
		text = text.Replace("<element>", Te.xt("tid_replacement_aether"));
		AddObjective(new EventObjectiveElementDamage(4500, ItemData.Element.AEther, "tid_element_aether"));
		AddObjective(new EventObjectiveSummonDamage(200, "voidweaver", "tid_item_53f"));
		AddObjective(new EventObjectiveDefeatFoeWithDevour(300, "voidweaver", "tid_item_53f").SetMaxPlays(1).SetPoints(3));
		AddObjective(new EventObjectiveCompleteDaily(1));
		AddObjective(new EventObjectiveCraftElement(6, ItemData.Element.AEther, "tid_element_aether").SetMaxPlays(2));
		AddObjective(new EventObjectiveDefeatFoeWithUnmake(50));
		AddObjective(new EventObjectiveDefeatFoeType(25, "AEther", "tid_element_aether"));
		AddObjective(new EventObjectiveDebuffFoes(100, "unstable", "tid_item_53d").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(45, "Import Cosmetics/PetBoo"));
		AddObjective(new EventObjectiveOpenTreasure(1));
		AddObjective(new EventObjectiveItemClearLocation(1, "aether_talisman", text));
		AddObjective(new EventObjectiveCompleteQuest(1).SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveDefeatBossWithUnmake(15).SetMaxPlays(1).SetPoints(3).SetTitle("tid_q_basic_unmake_boss_title")
			.SetInfo(info)
			.PreventLocationStatsUpdate());
		AddObjective(new EventObjectiveGetMindStone());
		AddObjective(new EventObjectiveStonescriptAbility(3, "blade_of_god", "tid_item_33").SetMaxPlays(1));
		AddObjective(new EventObjectiveSkullGame(1).SetMaxPlays(2));
		AddObjective(new EventObjectiveBuyTreasure(1));
		AddObjective(new EventObjectiveRem5Requirement());
		AddObjective(new EventObjectiveReferral(1).SetMaxPlays(2));
		AddObjective(new EventObjectiveCompleteWeekly().SetMaxPlays(1));
		AddObjective(new EventObjectiveStonescriptAbility(3, "skeleton_arm", "tid_item_50").SetMaxPlays(1));
		AddObjective(new EventObjectiveDefeatSpecificFoe(450, "skeleton_boss", "tid_quest_boss_04", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveElementItemClearLocation(1, ItemData.Element.AEther, "tid_element_aether").SetMaxPlays(1).SetPoints(2));
	}
}
