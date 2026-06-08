public class SpringEventController : BaseEventController2
{
	private static SpringEventController instance;

	public static SpringEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new SpringEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "spring";
	}

	public override int GetMaxDailyObjectives()
	{
		return 15;
	}

	public override void InitObjectives()
	{
		string info = string.Format(Te.xt("tid_q_obj_mod_whileactive"), "[color=#00ffff]" + Te.xt("tid_q_invadingfoe_title") + "[/color]") + string.Format(Te.xt("tid_q_obj_mod_desc_invading_foe"), "tid_mushroom_enemy_13") + Te.xt("tid_q_obj_mod_note_notimeupdate");
		string info2 = string.Format(Te.xt("tid_q_obj_mod_whileactive"), "[color=#00ffff]" + Te.xt("tid_q_enemies_drop_title") + "[/color]") + Te.xt("tid_q_obj_mod_desc_enemies_drop") + Te.xt("tid_q_obj_mod_note_notimeupdate");
		string text = Te.xt("tid_item_08");
		text = text.Replace("<element>", Te.xt("tid_replacement_vigor"));
		AddObjective(new EventObjectiveDefeatSpecificFoe(1200, "mushroom_boss", "tid_quest_boss_03", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(3).SetTitle("tid_q_basic_boss_mushroom_title"));
		AddObjective(new EventObjectiveAttackWithBuff(25, "vampiric", "tid_potion_07"));
		AddObjective(new EventObjectiveBuyTreasure(1));
		AddObjective(new EventObjectiveCraftElement(6, ItemData.Element.Vigor, "tid_element_vigor").SetMaxPlays(2));
		AddObjective(new EventObjectiveDefeatFoeType(50, "Vigor", "tid_element_vigor"));
		AddObjective(new EventObjectiveOpenTreasure(1, "skullnata", "tid_treasure_skullnata").SetMaxPlays(2));
		AddObjective(new EventObjectiveCollectVigorRuneDrop(64, text).SetTitle("tid_q_enemies_drop_title").SetInfo(info2).PreventLocationStatsUpdate());
		AddObjective(new EventObjectiveDrinkPotion(3));
		AddObjective(new EventObjectiveGetMindStone());
		AddObjective(new EventObjectiveCompleteQuest(1, "epic_croaked", "tid_q_crk_title").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(60, "import Cosmetics/PetSnowBunny"));
		AddObjective(new EventObjectiveElementDamage(4500, ItemData.Element.Vigor, "tid_element_vigor"));
		AddObjective(new EventObjectiveItemClearSpecificLocation(1, "grappling_hook", "tid_item_04", "waterfall", "tid_ftue_11").SetMaxPlays(10));
		AddObjective(new EventObjectiveDefeatFoeType(125, "ant", "tid_quest_foe_type_14"));
		AddObjective(new EventObjectiveCollectResource(75, Data.Resource.Stone, "tid_resource_stone_singular"));
		AddObjective(new EventObjectiveGetLocationStarCompleted(4, 7, "[color=#00ffff]☆☆[/color][color=#A9A9A9]☆☆☆[/color]"));
		AddObjective(new EventObjectiveDefeatInvadingFoe(20, "fluff", "Quests/FungusForest/Boss/YellowFluff", 1, "tid_mushroom_enemy_13", pointsByDifficulty: false).SetPoints(2).SetTitle("tid_q_invadingfoe_title").SetInfo(info)
			.PreventLocationStatsUpdate());
		AddObjective(new EventObjectiveCompleteDaily(1).SetMaxPlays(1));
		AddObjective(new EventObjectiveOpenTreasure(50));
		AddObjective(new EventObjectiveElementItemClearLocation(1, ItemData.Element.Vigor, "tid_element_vigor").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveRem5Requirement());
		AddObjective(new EventObjectiveCompleteWeekly().SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveHeal(80, countOverHeal: true));
		AddObjective(new EventObjectivePerfectRun(1, "fungus_forest", "tid_mushroom_2").SetMaxPlays(1));
	}
}
