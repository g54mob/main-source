using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(2626522292662886804uL)]
[TypeManager.OverrideTypeHash(9668443093423200302uL)]
public struct DungeonNameSerializedCD : IComponentData, IQueryTypeParameter
{
	public FixedString32 Value;

	public static DungeonNameSerializedCD FromFixedString32Bytes(FixedString32Bytes value)
	{
		DungeonNameSerializedCD result = default(DungeonNameSerializedCD);
		UnsafeUtility.As<FixedString32, FixedString32Bytes>(ref result.Value) = value;
		return result;
	}

	public static FixedString32Bytes AsFixedString32Bytes(DungeonNameSerializedCD value)
	{
		return UnsafeUtility.As<FixedString32, FixedString32Bytes>(ref value.Value);
	}
}
