using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(15231150560887796728uL)]
[TypeManager.OverrideTypeHash(3317929161124881020uL)]
public struct KilledEnemiesSerializedBuffer : IBufferElementData
{
	public ObjectDataSerializedCD ObjectData;

	public static implicit operator KilledEnemiesSerializedBuffer(ObjectDataSerializedCD o)
	{
		return new KilledEnemiesSerializedBuffer
		{
			ObjectData = o
		};
	}

	public static implicit operator ObjectDataSerializedCD(KilledEnemiesSerializedBuffer c)
	{
		return c.ObjectData;
	}
}
