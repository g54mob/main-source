using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/nodelink.html")]
	public class NodeLink : GraphModifier
	{
		public Transform end;

		public float costFactor;

		public bool oneWay;

		public bool deleteConnection;

		public Transform Start => null;

		public Transform End => null;

		public override void OnGraphsPostUpdateBeforeAreaRecalculation()
		{
		}

		public static void DrawArch(Vector3 a, Vector3 b, Vector3 up, Color color)
		{
		}

		public virtual void Apply()
		{
		}

		public override void DrawGizmos()
		{
		}
	}
}
