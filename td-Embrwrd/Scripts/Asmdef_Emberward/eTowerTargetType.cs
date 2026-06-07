using System;
using UnityEngine;

[Serializable]
public enum eTowerTargetType
{
	[InspectorName("單目標")]
	SINGLE = 0,
	[InspectorName("範圍")]
	AREA = 1,
	[InspectorName("多重")]
	MULTIPLE = 2
}
