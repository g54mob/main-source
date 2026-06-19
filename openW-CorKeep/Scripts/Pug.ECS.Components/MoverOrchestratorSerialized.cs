using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct MoverOrchestratorSerialized : IComponentData, IQueryTypeParameter
{
	public sbyte activeMoverIndex;

	public int nextMoverCycleIncrement;
}
