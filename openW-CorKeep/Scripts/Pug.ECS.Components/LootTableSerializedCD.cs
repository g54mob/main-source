using System;
using Unity.Entities;

[Serializable]
[TypeManager.ForcedMemoryOrdering(10675777891542292791uL)]
[TypeManager.OverrideTypeHash(15506877059273323975uL)]
public struct LootTableSerializedCD : IComponentData, IQueryTypeParameter
{
	public LootTableID Value;
}
