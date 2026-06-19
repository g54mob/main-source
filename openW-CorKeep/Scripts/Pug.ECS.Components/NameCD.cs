using System;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

[Serializable]
[InventoryAuxDataComponent]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct NameCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public FixedString64Bytes Value;
}
