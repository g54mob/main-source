public class ToweringEventController : BaseEventController2
{
	private static ToweringEventController instance;

	public static ToweringEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new ToweringEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "towering";
	}

	public override int GetMaxDailyObjectives()
	{
		return 15;
	}

	public override void InitObjectives()
	{
		string info = string.Format(Te.xt("tid_q_obj_mod_whileactive"), Te.xt("tid_q_basic_armor_damage")) + Te.xt("tid_q_obj_mod_desc_armor") + Te.xt("tid_q_obj_mod_note_notimeupdate");
		AddObjective(new EventObjectiveArmorDamage(7500).SetTitle("tid_q_armordamage_title").SetInfo(info).PreventLocationStatsUpdate());
		AddObjective(new EventObjectiveCraftType(6, "shield", "tid_item_09").SetMaxPlays(2));
		AddObjective(new EventObjectiveItemClearLocation(450, "tower_shield", "tid_item_28").SetMaxPlays(1).SetPoints(3));
		AddObjective(new EventObjectiveCompleteDaily(1));
		AddObjective(new EventObjectiveDefeatFoeType(75, "stone", "tid_replacement_stone", 10));
		AddObjective(new EventObjectiveDefeatSpecificFoe(450, "bronze_guardian", "tid_boiling_mine_enemy_10", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectivePreventDamageWithShield(50));
		AddObjective(new EventObjectiveStunFoesWithWeapon(30, "stun", "bashing_shield", "tid_item_23"));
		AddObjective(new EventObjectiveBuyTreasure(1));
		AddObjective(new EventObjectiveGetMindStone());
		AddObjective(new EventObjectiveDefeatBossWithCosmetic(45, "import Cosmetics/Knight"));
		AddObjective(new EventObjectiveDefeatFoeType(40, "snail", "tid_quest_foe_type_15"));
		AddObjective(new EventObjectiveStunBossesWithWeapon(30, "stun", "heavy_hammer", "tid_item_26").SetMaxPlays(2));
		AddObjective(new EventObjectiveDebuffBosses(5, "debuff_armor_fatigue", "tid_item_26d").SetMaxPlays(2).SetPoints(2));
		AddObjective(new EventObjectivePerfectRun(1, "deadwood_valley", "tid_ftue_09").SetMaxPlays(1));
		AddObjective(new EventObjectiveHeal(80, countOverHeal: true).SetMaxPlays(1));
		AddObjective(new EventObjectiveDefeatFoeUsingBuff(450, "strength", "tid_potion_09", "bronze_guardian", "tid_boiling_mine_enemy_10", pointsByDifficulty: true).SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveDrinkPotion(3, Potion.Type.Armor, "tid_potion_03"));
		AddObjective(new EventObjectiveOpenTreasure(2, "treasure_4", "tid_treasure_DT").SetMaxPlays(2));
		AddObjective(new EventObjectiveSkullGame(1));
		AddObjective(new EventObjectiveElementItemClearLocation(1, ItemData.Element.Stone, "tid_replacement_stone", "deadwood_valley", "tid_ftue_09").SetMaxPlays(1).SetPoints(2));
		AddObjective(new EventObjectiveStunBossesWithWeapon(20, "stun", "compound_shield", "tid_item_27"));
		AddObjective(new EventObjectiveRem5Requirement());
		AddObjective(new EventObjectiveCompleteWeekly().SetMaxPlays(1).SetPoints(2));
	}
}
