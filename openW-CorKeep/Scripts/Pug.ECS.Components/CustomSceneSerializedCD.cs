using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(9553928676620345146uL)]
[TypeManager.OverrideTypeHash(14841664605717691252uL)]
public struct CustomSceneSerializedCD : IComponentData, IQueryTypeParameter
{
	public FixedString32 Name;

	public static CustomSceneSerializedCD FromFixedString32Bytes(FixedString32Bytes value)
	{
		CustomSceneSerializedCD result = default(CustomSceneSerializedCD);
		UnsafeUtility.As<FixedString32, FixedString32Bytes>(ref result.Name) = value;
		return result;
	}

	public static FixedString32Bytes AsFixedString32Bytes(CustomSceneSerializedCD value)
	{
		return UnsafeUtility.As<FixedString32, FixedString32Bytes>(ref value.Name);
	}
}
