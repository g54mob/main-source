using UnityEngine;

public enum ePerkCategory
{
	NONE = 0,
	[InspectorName("(刪除)")]
	DEPRECATED = 1,
	[InspectorName("MONSTER_MODIFY - 改變怪物的強度或數量")]
	MONSTER_MODIFY = 2,
	[InspectorName("TOWER_MODIFY - 改變砲塔的強度")]
	TOWER_MODIFY = 3,
	[InspectorName("STUN_TOWER - 會讓砲塔故障")]
	STUN_TOWER = 4,
	[InspectorName("BAN_TOWER - 禁用砲塔")]
	BAN_TOWER = 5,
	[InspectorName("CREATE_GRID_ITEM - 會增加或影響地圖物件")]
	CREATE_GRID_ITEM = 6,
	[InspectorName("HAND_CARD_MODIFY - 干擾手牌或抽牌")]
	HAND_CARD_MODIFY = 7
}
