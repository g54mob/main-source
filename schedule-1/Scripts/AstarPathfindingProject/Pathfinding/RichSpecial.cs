using UnityEngine;

namespace Pathfinding
{
	public class RichSpecial : RichPathPart
	{
		public NodeLink2 nodeLink;

		public Transform first;

		public Transform second;

		public bool reverse;

		public override void OnEnterPool()
		{
		}

		public RichSpecial Initialize(NodeLink2 nodeLink, GraphNode first)
		{
			return null;
		}
	}
}
