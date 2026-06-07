using System.Collections;
using Pathfinding.ECS;

namespace Pathfinding
{
	public interface IOffMeshLinkStateMachine
	{
		IEnumerable OnTraverseOffMeshLink(AgentOffMeshLinkTraversalContext context)
		{
			return null;
		}

		void OnFinishTraversingOffMeshLink(AgentOffMeshLinkTraversalContext context)
		{
		}

		void OnAbortTraversingOffMeshLink()
		{
		}
	}
}
