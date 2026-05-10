using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_node_link.php")]
	public class NodeLink : GraphModifier
	{
		public Transform end;

		public float costFactor;

		public bool oneWay;

		public bool deleteConnection;

		public Transform Start => null;

		public Transform End => null;

		public override void OnPostScan()
		{
		}

		public void InternalOnPostScan()
		{
		}

		public override void OnGraphsPostUpdate()
		{
		}

		public virtual void Apply()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
