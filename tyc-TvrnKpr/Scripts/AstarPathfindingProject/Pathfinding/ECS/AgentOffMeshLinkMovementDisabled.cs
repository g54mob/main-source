using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct AgentOffMeshLinkMovementDisabled : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
