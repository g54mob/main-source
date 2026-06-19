using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(16104261336207737813uL)]
[TypeManager.OverrideTypeHash(2024114433828824476uL)]
public struct PlayerSerializedCD : IComponentData, IQueryTypeParameter
{
	public Hash128 PlayerGuid;
}
