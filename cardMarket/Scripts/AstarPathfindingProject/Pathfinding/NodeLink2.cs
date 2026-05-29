using System.Collections.Generic;
using Pathfinding.Drawing;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link2")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/nodelink2.html")]
	public class NodeLink2 : GraphModifier
	{
		public Transform end;

		public float costFactor = 1f;

		public bool oneWay;

		public PathfindingTag pathfindingTag = 0u;

		public GraphMask graphMask = -1;

		protected OffMeshLinks.OffMeshLinkSource linkSource;

		private IOffMeshLinkHandler onTraverseOffMeshLinkHandler;

		private static readonly Color GizmosColor = new Color(0.80784315f, 8f / 15f, 16f / 85f, 0.5f);

		private static readonly Color GizmosColorSelected = new Color(47f / 51f, 41f / 85f, 0.1254902f, 1f);

		public Transform StartTransform => base.transform;

		public Transform EndTransform => end;

		internal bool isActive
		{
			get
			{
				if (linkSource != null)
				{
					return (linkSource.status & OffMeshLinks.OffMeshLinkStatus.Active) != 0;
				}
				return false;
			}
		}

		public IOffMeshLinkHandler onTraverseOffMeshLink
		{
			get
			{
				return onTraverseOffMeshLinkHandler;
			}
			set
			{
				onTraverseOffMeshLinkHandler = value;
				if (linkSource != null)
				{
					linkSource.handler = value;
				}
			}
		}

		public static NodeLink2 GetNodeLink(GraphNode node)
		{
			if (!(node is LinkNode linkNode))
			{
				return null;
			}
			return linkNode.linkSource.component as NodeLink2;
		}

		public override void OnPostScan()
		{
			TryAddLink();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying && !BatchedEvents.Has(this))
			{
				BatchedEvents.Add(this, BatchedEvents.Event.Update, OnUpdate);
			}
			TryAddLink();
		}

		private static void OnUpdate(NodeLink2[] components, int count)
		{
			if (Time.frameCount % 16 != 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				NodeLink2 nodeLink = components[i];
				Transform startTransform = nodeLink.StartTransform;
				Transform endTransform = nodeLink.EndTransform;
				bool flag = nodeLink.linkSource != null;
				if ((startTransform != null && endTransform != null) != flag || (flag && (startTransform.hasChanged || endTransform.hasChanged)))
				{
					if (startTransform != null)
					{
						startTransform.hasChanged = false;
					}
					if (endTransform != null)
					{
						endTransform.hasChanged = false;
					}
					nodeLink.RemoveLink();
					nodeLink.TryAddLink();
				}
			}
		}

		private void TryAddLink()
		{
			if (linkSource != null && (linkSource.status == OffMeshLinks.OffMeshLinkStatus.Inactive || (linkSource.status & OffMeshLinks.OffMeshLinkStatus.PendingRemoval) != 0))
			{
				linkSource = null;
			}
			if (linkSource == null && AstarPath.active != null && EndTransform != null)
			{
				StartTransform.hasChanged = false;
				EndTransform.hasChanged = false;
				linkSource = new OffMeshLinks.OffMeshLinkSource
				{
					start = new OffMeshLinks.Anchor
					{
						center = StartTransform.position,
						rotation = StartTransform.rotation,
						width = 0f
					},
					end = new OffMeshLinks.Anchor
					{
						center = EndTransform.position,
						rotation = EndTransform.rotation,
						width = 0f
					},
					directionality = ((!oneWay) ? OffMeshLinks.Directionality.TwoWay : OffMeshLinks.Directionality.OneWay),
					tag = pathfindingTag,
					costFactor = costFactor,
					graphMask = graphMask,
					maxSnappingDistance = 1f,
					component = this,
					handler = onTraverseOffMeshLink
				};
				AstarPath.active.offMeshLinks.Add(linkSource);
			}
		}

		private void RemoveLink()
		{
			if (AstarPath.active != null && linkSource != null)
			{
				AstarPath.active.offMeshLinks.Remove(linkSource);
			}
			linkSource = null;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			BatchedEvents.Remove(this);
			RemoveLink();
		}

		[ContextMenu("Recalculate neighbours")]
		private void ContextApplyForce()
		{
			Apply();
		}

		public virtual void Apply()
		{
			RemoveLink();
			TryAddLink();
		}

		public override void DrawGizmos()
		{
			if (StartTransform == null || EndTransform == null)
			{
				return;
			}
			Vector3 position = StartTransform.position;
			Vector3 position2 = EndTransform.position;
			if (linkSource != null && Time.renderedFrameCount % 16 == 0 && Application.isEditor && (linkSource.start.center != position || linkSource.end.center != position2 || linkSource.directionality != ((!oneWay) ? OffMeshLinks.Directionality.TwoWay : OffMeshLinks.Directionality.OneWay) || linkSource.costFactor != costFactor || (int)linkSource.graphMask != (int)graphMask || (uint)linkSource.tag != (uint)pathfindingTag))
			{
				Apply();
			}
			bool flag = GizmoContext.InActiveSelection(this);
			List<NavGraph> list = ((linkSource != null && AstarPath.active != null) ? AstarPath.active.offMeshLinks.ConnectedGraphs(linkSource) : null);
			Vector3 vector = Vector3.up;
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					NavGraph navGraph = list[i];
					if (navGraph != null)
					{
						if (navGraph is NavmeshBase navmeshBase)
						{
							vector = navmeshBase.transform.WorldUpAtGraphPosition(Vector3.zero);
							break;
						}
						if (navGraph is GridGraph gridGraph)
						{
							vector = gridGraph.transform.WorldUpAtGraphPosition(Vector3.zero);
							break;
						}
					}
				}
				ListPool<NavGraph>.Release(ref list);
			}
			bool num = linkSource != null && linkSource.status == OffMeshLinks.OffMeshLinkStatus.Active;
			Color color = (flag ? GizmosColorSelected : GizmosColor);
			if (num)
			{
				color = Color.green;
			}
			Draw.Circle(position, vector, 0.4f, (linkSource != null && linkSource.status.HasFlag(OffMeshLinks.OffMeshLinkStatus.FailedToConnectStart)) ? Color.red : color);
			Draw.Circle(position2, vector, 0.4f, (linkSource != null && linkSource.status.HasFlag(OffMeshLinks.OffMeshLinkStatus.FailedToConnectEnd)) ? Color.red : color);
			NodeLink.DrawArch(position, position2, vector, color);
			if (!flag)
			{
				return;
			}
			Vector3 normalized = Vector3.Cross(vector, position2 - position).normalized;
			using (Draw.WithLineWidth(2f))
			{
				NodeLink.DrawArch(position + normalized * 0f, position2 + normalized * 0f, vector, color);
			}
		}
	}
}
