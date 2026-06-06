using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link2")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/nodelink2.html")]
	public class NodeLink2 : GraphModifier
	{
		public Transform end;

		public float costFactor;

		public bool oneWay;

		public PathfindingTag pathfindingTag;

		public GraphMask graphMask;

		protected OffMeshLinks.OffMeshLinkSource linkSource;

		private IOffMeshLinkHandler onTraverseOffMeshLinkHandler;

		private static readonly Color GizmosColor;

		private static readonly Color GizmosColorSelected;

		public Transform StartTransform => null;

		public Transform EndTransform => null;

		internal bool isActive => false;

		public IOffMeshLinkHandler onTraverseOffMeshLink
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static NodeLink2 GetNodeLink(GraphNode node)
		{
			return null;
		}

		public override void OnPostScan()
		{
		}

		protected override void OnEnable()
		{
		}

		private static void OnUpdate(NodeLink2[] components, int count)
		{
		}

		private void TryAddLink()
		{
		}

		private void RemoveLink()
		{
		}

		protected override void OnDisable()
		{
		}

		[ContextMenu("Recalculate neighbours")]
		private void ContextApplyForce()
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
