using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(15774323510541663350uL)]
[TypeManager.OverrideTypeHash(13551751101155193141uL)]
public struct CharacterGuidSerializedCD : IComponentData, IQueryTypeParameter
{
	public Hash128 Value;

	public bool IsCreated => Value != default(Hash128);
}
