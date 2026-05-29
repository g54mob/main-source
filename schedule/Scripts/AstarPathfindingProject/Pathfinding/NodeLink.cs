using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_node_link.php")]
	[AddComponentMenu("Pathfinding/Link")]
	public class NodeLink : GraphModifier
	{
		public static List<NodeLink> validNodeLinks;

		public Vector3 midPosition;

		public Transform end;

		public float costFactor;

		public bool oneWay;

		public bool deleteConnection;

		public Transform Start => null;

		public Vector2 Start2D => default(Vector2);

		public Transform End => null;

		public Vector2 End2D => default(Vector2);

		protected override void Awake()
		{
		}

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

		public Vector3 GetClosestPoint(Vector3 point)
		{
			return default(Vector3);
		}

		public static List<NodeLink> GetClosestLinks(Vector3 point)
		{
			return null;
		}

		public void OnDrawGizmos()
		{
		}
	}
}
