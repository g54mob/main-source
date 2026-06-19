using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct AffixSerializedBuffer : IBufferElementData
{
	public ConditionSerialized condition;

	public int state;

	public float remainingCooldown;
}
