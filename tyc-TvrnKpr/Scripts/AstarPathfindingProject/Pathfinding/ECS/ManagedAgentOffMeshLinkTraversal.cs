using System;
using System.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	public class ManagedAgentOffMeshLinkTraversal : IComponentData, IQueryTypeParameter, ICloneable, ICleanupComponentData
	{
		public AgentOffMeshLinkTraversalContext context;

		public IEnumerator coroutine;

		public IOffMeshLinkHandler handler;

		public IOffMeshLinkStateMachine stateMachine;

		[Preserve]
		public ManagedAgentOffMeshLinkTraversal()
		{
		}

		public ManagedAgentOffMeshLinkTraversal(AgentOffMeshLinkTraversalContext context, IOffMeshLinkHandler handler)
		{
		}

		public object Clone()
		{
			return null;
		}
	}
}
