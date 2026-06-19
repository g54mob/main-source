using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Scripting;

[Preserve]
public struct MoveeSerialized : IComponentData, IQueryTypeParameter
{
	public float2 target;

	public int moveTimer;
}
