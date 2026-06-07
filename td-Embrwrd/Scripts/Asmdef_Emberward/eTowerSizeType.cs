using System;
using UnityEngine;

[Serializable]
public enum eTowerSizeType
{
	[InspectorName("未設定")]
	NONE = 0,
	[InspectorName("1 x 1")]
	_1x1 = 1,
	[InspectorName("1 x 2")]
	_1x2 = 2,
	[InspectorName("1 x 3")]
	_1x3 = 3,
	[InspectorName("2 x 2")]
	_2x2 = 4,
	[InspectorName("3 x 3")]
	_3x3 = 5,
	[InspectorName("3 x 3 - Cross")]
	_3x3_Cross = 6,
	[InspectorName("3 x 3 - CornerOnly")]
	_3x3_CornerOnly = 7,
	[InspectorName("3 x 3 - SideOnly")]
	_3x3_SideOnly = 8,
	[InspectorName("2 x 3 - L Shape")]
	_2x3_LShape = 9,
	[InspectorName("1 x 5")]
	_1x5 = 10
}
