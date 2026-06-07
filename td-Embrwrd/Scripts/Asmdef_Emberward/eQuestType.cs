using UnityEngine;

public enum eQuestType
{
	NONE = 0,
	[InspectorName("不受到傷害")]
	_01_NO_TAKE_DAMAGE = 1,
	[InspectorName("不讓敵人靠近3範圍內")]
	_02_NO_ENEMY_CLOSER_THAN_3_DISTANCE = 2,
	[InspectorName("不使用一種隨機塔")]
	_03_LOCK_RANDOM_1_TOWER = 3,
	[InspectorName("不使用兩種隨機塔")]
	_04_LOCK_RANDOM_2_TOWER = 4,
	[InspectorName("不在戰鬥中放置塔")]
	_05_NO_PLACE_TOWER_IN_BATTLE = 5,
	[InspectorName("不在戰鬥中放置牆壁")]
	_06_NO_PLACE_WALL_IN_BATTLE = 6,
	[InspectorName("只用三種塔通過下一關")]
	_07_ONLY_USE_3_TOWER = 7,
	[InspectorName("沒有任何砲台相鄰的情況下過關")]
	_08_NO_TOWER_ADJACENT = 8,
	[InspectorName("抽至少X張牌")]
	_09_DRAW_AT_LEAST_X_CARDS = 9,
	[InspectorName("骰子塔骰出三次六點")]
	_10_DICE_TOWER_ROLL_6_3_TIMES = 10,
	[InspectorName("不賣掉任何塔")]
	_11_NO_SELL_TOWER = 11,
	[InspectorName("用火屬性造成X點傷害")]
	_12_DEAL_FIRE_DAMAGE = 12,
	[InspectorName("用電屬性造成X點傷害")]
	_13_DEAL_ELECTRIC_DAMAGE = 13,
	[InspectorName("用毒屬性造成X點傷害")]
	_14_DEAL_POISON_DAMAGE = 14,
	[InspectorName("建造超過X座2x2塔")]
	_15_BUILD_OVER_X_2x2_TOWER = 15,
	[InspectorName("不讓敵人靠近5範圍內")]
	_16_NO_ENEMY_CLOSER_THAN_5_DISTANCE = 16,
	[InspectorName("建造超過X座隨機1x1塔")]
	_17_BUILD_OVER_X_RANDOM_1x1_TOWER = 17,
	[InspectorName("將X個砲塔以紅色選項升級")]
	_18_UPGRADE_X_TOWER_WITH_RED_OPTION = 18,
	[InspectorName("將X個砲塔以藍色選項升級")]
	_19_UPGRADE_X_TOWER_WITH_BLUE_OPTION = 19,
	[InspectorName("過關時迷宮至少有X格長")]
	_20_MAZE_AT_LEAST_X_LENGTH = 20,
	[InspectorName("用冰屬性造成X點傷害")]
	_21_DEAL_ICE_DAMAGE = 21,
	[InspectorName("用奧術屬性造成X點傷害")]
	_22_DEAL_ARCANE_DAMAGE = 22,
	[InspectorName("建造超過X座隨機2x2塔")]
	_23_BUILD_OVER_X_RANDOM_2x2_TOWER = 23
}
