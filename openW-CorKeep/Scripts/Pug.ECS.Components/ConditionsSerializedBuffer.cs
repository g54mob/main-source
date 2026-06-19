using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(6682437030782645294uL)]
[TypeManager.OverrideTypeHash(10190325920577701639uL)]
public struct ConditionsSerializedBuffer : IBufferElementData
{
	public ConditionSerialized Value;

	public static implicit operator ConditionsSerializedBuffer(ConditionSerialized c)
	{
		return new ConditionsSerializedBuffer
		{
			Value = c
		};
	}

	public static implicit operator ConditionSerialized(ConditionsSerializedBuffer c)
	{
		return c.Value;
	}
}
