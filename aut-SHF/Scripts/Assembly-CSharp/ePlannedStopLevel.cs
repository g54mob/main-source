using System;
using UnityEngine;

[Flags]
public enum ePlannedStopLevel
{
	None = 0,
	[InspectorName("演出")]
	Direction = 1,
	[InspectorName("勇者")]
	Brave = 2,
	[InspectorName("騎士")]
	Knight = 4
}
