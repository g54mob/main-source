using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(3060899870865786024uL)]
[TypeManager.OverrideTypeHash(8017971940887369152uL)]
public struct WorldVersionSerializedCD : IComponentData, IQueryTypeParameter
{
	public int Version;

	public const int CURRENT_VERSION = 12;
}
