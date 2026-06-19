using System;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
[TypeManager.ForcedMemoryOrdering(664105384916819263uL)]
[TypeManager.OverrideTypeHash(12451587167075373321uL)]
public struct PheromoneSerializedCD : IComponentData, IQueryTypeParameter
{
	public int2 Position;

	public FixedArray64 Values;
}
