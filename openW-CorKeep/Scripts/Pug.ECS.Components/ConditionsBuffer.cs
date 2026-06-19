using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ConditionsBuffer : IBufferElementData
{
	[GhostField]
	public Condition condition;

	public static implicit operator ConditionsBuffer(Condition c)
	{
		return new ConditionsBuffer
		{
			condition = c
		};
	}

	public static implicit operator Condition(ConditionsBuffer c)
	{
		return c.condition;
	}
}
