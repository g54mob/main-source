using Pathfinding.ECS;

namespace Pathfinding
{
	public interface IOffMeshLinkHandler
	{
		string name => null;

		IOffMeshLinkStateMachine GetOffMeshLinkStateMachine(AgentOffMeshLinkTraversalContext context);
	}
}
