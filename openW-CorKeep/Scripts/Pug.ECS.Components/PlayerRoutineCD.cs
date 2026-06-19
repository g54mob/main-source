using Unity.Entities;
using Unity.NetCode;

public struct PlayerRoutineCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public PlayerRoutines activeRoutine;
}
