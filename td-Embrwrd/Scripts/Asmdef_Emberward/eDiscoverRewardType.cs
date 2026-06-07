using UnityEngine;

public enum eDiscoverRewardType
{
	[InspectorName("!!未設定!!")]
	NONE = 0,
	[InspectorName("ＨＰ")]
	HP = 1,
	[InspectorName("金幣")]
	COIN = 2,
	[InspectorName("砲台卡片")]
	TOWER_CARD = 3,
	[InspectorName("底座卡片")]
	PANEL_CARD = 4,
	[InspectorName("隨機 底座卡片")]
	RANDOM_PANEL_CARD = 5,
	[InspectorName("Buff卡片")]
	BUFF_CARD = 6,
	[InspectorName("隨機 Buff卡片")]
	RANDOM_BUFF_CARD = 7,
	[InspectorName("神器卡片")]
	RELIC_CARD = 8,
	[InspectorName("升級齒輪卡片")]
	GEAR_CARD = 9
}
