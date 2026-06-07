using System;
using UnityEngine;

[Serializable]
public enum eTowerRangeType
{
	[InspectorName("圓形半徑")]
	CIRCLE = 0,
	[InspectorName("方形範圍")]
	SQUARE_AREA = 1,
	[InspectorName("圓形但只有一半外圈")]
	DONUT_CIRCLE = 2
}
