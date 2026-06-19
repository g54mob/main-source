using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[WriteGroup(typeof(LocalToWorld))]
public struct MinionOrbitCD : IComponentData, IQueryTypeParameter
{
	public float radius;

	public float orbitSpeed;

	[GhostField]
	public float2 orbitOffset;
}
