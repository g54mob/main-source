using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(14048376630969704601uL)]
[TypeManager.OverrideTypeHash(7953502142579949517uL)]
public struct RotationSerializedCD : IComponentData, IQueryTypeParameter
{
	public float3 Value;
}
