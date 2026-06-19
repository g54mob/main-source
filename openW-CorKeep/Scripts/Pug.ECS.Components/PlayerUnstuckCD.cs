using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct PlayerUnstuckCD : IComponentData, IQueryTypeParameter
{
	public TickTimer stuckTimer;

	public TickTimer killIfStuckTimer;

	public FixedList128Bytes<int2> lastWalkedPositions;
}
