using System;
using Unity.NetCode;

[Serializable]
public struct Condition
{
	public ConditionData conditionData;

	[GhostField]
	public NetworkTick removeTick;

	[GhostField(SendData = false)]
	public bool toBeRemoved;
}
