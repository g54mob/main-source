using UnityEngine;

public enum ePerkActivateRequirementForMap
{
	NONE = 0,
	[InspectorName("在地圖的第X步前")]
	MAP_STEP_LESS_THAN_X = 1,
	[InspectorName("在地圖的第X步後")]
	MAP_STEP_MORE_THAN_X = 2
}
