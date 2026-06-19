using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(2238760741437376544uL)]
[TypeManager.OverrideTypeHash(13313812645501089251uL)]
public struct PlayerGuidSerializedCD : IComponentData, IQueryTypeParameter
{
	public Hash128 Value;

	public bool IsCreated => Value != default(Hash128);
}
