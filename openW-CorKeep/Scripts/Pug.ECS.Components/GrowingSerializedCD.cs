using System;
using Unity.Entities;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(12343954618917922255uL)]
[TypeManager.OverrideTypeHash(4073445497772281464uL)]
public struct GrowingSerializedCD : IComponentData, IQueryTypeParameter
{
	public int Stage;

	public float GrowTime;
}
