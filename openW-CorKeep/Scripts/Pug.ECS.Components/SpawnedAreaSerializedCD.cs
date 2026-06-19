using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.OverrideTypeHash(16649060195170287046uL)]
public struct SpawnedAreaSerializedCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public int2 size;
}
