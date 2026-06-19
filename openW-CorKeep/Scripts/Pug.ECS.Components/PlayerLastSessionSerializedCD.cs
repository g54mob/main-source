using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct PlayerLastSessionSerializedCD : IComponentData, IQueryTypeParameter
{
	public Hash128 Value;
}
