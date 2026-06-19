using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EventTerminalCD : IComponentData, IQueryTypeParameter
{
	public float radius;

	public float radiusSq;

	public float duration;

	[GhostField]
	public bool terminalIsActive;

	[GhostField]
	public float timerSpeed;

	[GhostField]
	public float timer;

	[GhostField]
	public bool anyPlayerIsInsideZone;

	public int prevSequenceIndex;

	public int currentSequenceIndex;

	public int loopIndex;

	public float currentElementTime;

	public LootTableID lootTable;
}
