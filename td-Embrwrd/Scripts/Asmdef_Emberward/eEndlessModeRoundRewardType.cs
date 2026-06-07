using UnityEngine;

public enum eEndlessModeRoundRewardType
{
	[InspectorName("隱藏")]
	HIDDEN = -1,
	[InspectorName("NONE")]
	NONE = 0,
	[InspectorName("砲塔")]
	TOWER = 1,
	[InspectorName("方塊")]
	BLOCK = 2,
	[InspectorName("神器")]
	RELIC = 3,
	[InspectorName("重骰代幣")]
	REROLL_TOKEN = 4,
	[InspectorName("餘燼石")]
	EMBER_STONE = 5,
	[InspectorName("工坊")]
	WORKSHOP = 6,
	[InspectorName("迷你商店")]
	MINISHOP = 7,
	[InspectorName("骷髏王的禮物")]
	SKELETON_KING_TRIAL = 8,
	[InspectorName("寶箱")]
	TREASURE_CHEST = 9,
	[InspectorName("HP回復")]
	HP_RECOVERY = 10,
	[InspectorName("場景重置")]
	SCENE_RESET = 11,
	[InspectorName("聖誕禮物")]
	XMAS_GIFT = 12
}
