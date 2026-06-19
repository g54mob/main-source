using System;
using Unity.Entities;
using UnityEngine.Scripting;

[Obsolete]
[Preserve]
[TypeManager.ForcedMemoryOrdering(8527608949938564408uL)]
[TypeManager.OverrideTypeHash(8366066289921811853uL)]
public struct CraftingSerializedCD : IComponentData, IQueryTypeParameter
{
	public int CurrentlyCrafting;

	public float TimeLeftToCraft;
}
