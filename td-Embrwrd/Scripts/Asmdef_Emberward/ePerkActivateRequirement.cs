using UnityEngine;

public enum ePerkActivateRequirement
{
	NONE = 0,
	[InspectorName("有超過X個砲塔")]
	MORE_THAN_X_TOWER = 1,
	[InspectorName("有超過X個1x1砲塔")]
	MORE_THAN_X_1X1_TOWER = 2,
	[InspectorName("有超過X個非1x1砲塔")]
	MORE_THAN_X_LARGER_THAN_1X1_TOWER = 3,
	[InspectorName("在第X回合前")]
	CURRENT_ROUND_LESS_THAN_X = 4,
	[InspectorName("在第X回合或之後")]
	CURRENT_ROUND_EQUAL_OR_MORE_THAN_X = 5,
	[InspectorName("有超過X個神器")]
	MORE_THAN_X_RELIC = 6,
	[InspectorName("有超過X個方塊在場上")]
	MORE_THAN_X_TETRIS_ON_FIELD = 7,
	[InspectorName("有少於X個神器")]
	LESS_THAN_X_RELIC = 8,
	[InspectorName("啟動次數少於X次")]
	ACTIVATED_LESS_THAN_X_TIMES = 9
}
