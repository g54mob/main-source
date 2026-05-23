using System;
using Pathfinding.Drawing;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public abstract class NavGraph : IGraphInternals
	{
		public AstarPath active;

		[JsonMember]
		public Pathfinding.Util.Guid guid;

		[JsonMember]
		public uint initialPenalty;

		[JsonMember]
		public bool open;

		public uint graphIndex;

		[JsonMember]
		public string name;

		[JsonMember]
		public bool drawGizmos = true;

		[JsonMember]
		public bool infoScreenOpen;

		[JsonMember]
		private string serializedEditorSettings;

		internal bool exists => active != null;

		public abstract bool isScanned { get; }

		public virtual bool persistent => true;

		public virtual bool showInInspector => true;

		public virtual Bounds bounds => new Bounds(Vector3.zero, Vector3.positiveInfinity);

		string IGraphInternals.SerializedEditorSettings
		{
			get
			{
				return serializedEditorSettings;
			}
			set
			{
				serializedEditorSettings = value;
			}
		}

		public virtual int CountNodes()
		{
			int count = 0;
			GetNodes(delegate
			{
				count++;
			});
			return count;
		}

		public void GetNodes(Func<GraphNode, bool> action)
		{
			bool cont = true;
			GetNodes(delegate(GraphNode node)
			{
				if (cont)
				{
					cont &= action(node);
				}
			});
		}

		public abstract void GetNodes(Action<GraphNode> action);

		public virtual bool IsPointOnNavmesh(Vector3 position)
		{
			NNInfo nearest = GetNearest(position, AstarPath.NNConstraintClosestAsSeenFromAbove, 0.0001f);
			if (nearest.node != null && nearest.node.Walkable)
			{
				return nearest.distanceCostSqr < 0.0001f;
			}
			return false;
		}

		public virtual bool IsInsideBounds(Vector3 point)
		{
			return true;
		}

		protected void AssertSafeToUpdateGraph()
		{
			if (!active.IsAnyWorkItemInProgress && !active.isScanning)
			{
				throw new Exception("Trying to update graphs when it is not safe to do so. Graph updates must be done inside a work item or when a graph is being scanned. See AstarPath.AddWorkItem");
			}
		}

		protected void DirtyBounds(Bounds bounds)
		{
			active.DirtyBounds(bounds);
		}

		public virtual void RelocateNodes(Matrix4x4 deltaMatrix)
		{
			GetNodes(delegate(GraphNode node)
			{
				node.position = (Int3)deltaMatrix.MultiplyPoint((Vector3)node.position);
			});
		}

		public virtual float NearestNodeDistanceSqrLowerBound(Vector3 position, NNConstraint constraint = null)
		{
			return 0f;
		}

		public NNInfo GetNearest(Vector3 position, NNConstraint constraint = null)
		{
			float maxDistanceSqr = ((constraint == null || constraint.constrainDistance) ? active.maxNearestNodeDistanceSqr : float.PositiveInfinity);
			return GetNearest(position, constraint, maxDistanceSqr);
		}

		public virtual NNInfo GetNearest(Vector3 position, NNConstraint constraint, float maxDistanceSqr)
		{
			GraphNode minNode = null;
			GetNodes(delegate(GraphNode node)
			{
				float sqrMagnitude = (position - (Vector3)node.position).sqrMagnitude;
				if (sqrMagnitude < maxDistanceSqr && (constraint == null || constraint.Suitable(node)))
				{
					maxDistanceSqr = sqrMagnitude;
					minNode = node;
				}
			});
			if (minNode == null)
			{
				return NNInfo.Empty;
			}
			return new NNInfo(minNode, (Vector3)minNode.position, maxDistanceSqr);
		}

		[Obsolete("Use GetNearest instead")]
		public NNInfo GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return GetNearest(position, constraint);
		}

		protected virtual void OnDestroy()
		{
			DestroyAllNodes();
			DisposeUnmanagedData();
		}

		protected virtual void DisposeUnmanagedData()
		{
		}

		protected virtual void DestroyAllNodes()
		{
			GetNodes(delegate(GraphNode node)
			{
				node.Destroy();
			});
		}

		public virtual IGraphSnapshot Snapshot(Bounds bounds)
		{
			return null;
		}

		public void Scan()
		{
			active.Scan(this);
		}

		protected virtual IGraphUpdatePromise ScanInternal()
		{
			throw new NotImplementedException();
		}

		protected virtual IGraphUpdatePromise ScanInternal(bool async)
		{
			return ScanInternal();
		}

		protected virtual void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected virtual void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected virtual void PostDeserialization(GraphSerializationContext ctx)
		{
		}

		public virtual void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope)
		{
			if (!drawNodes)
			{
				return;
			}
			NodeHasher hasher = new NodeHasher(active);
			GetNodes(delegate(GraphNode node)
			{
				hasher.HashNode(node);
			});
			if (!gizmos.Draw(hasher, redrawScope))
			{
				using GraphGizmoHelper graphGizmoHelper = GraphGizmoHelper.GetGizmoHelper(gizmos, active, hasher, redrawScope);
				if (graphGizmoHelper.showSearchTree)
				{
					graphGizmoHelper.builder.PushLineWidth(2f);
				}
				GetNodes((Action<GraphNode>)graphGizmoHelper.DrawConnections);
				if (graphGizmoHelper.showSearchTree)
				{
					graphGizmoHelper.builder.PopLineWidth();
				}
			}
			if (active.showUnwalkableNodes)
			{
				DrawUnwalkableNodes(gizmos, active.unwalkableNodeDebugSize, redrawScope);
			}
		}

		protected void DrawUnwalkableNodes(DrawingData gizmos, float size, RedrawScope redrawScope)
		{
			DrawingData.Hasher hasher = DrawingData.Hasher.Create(this);
			GetNodes(delegate(GraphNode node)
			{
				hasher.Add(node.Walkable);
				if (!node.Walkable)
				{
					hasher.Add(node.position);
				}
			});
			if (gizmos.Draw(hasher, redrawScope))
			{
				return;
			}
			CommandBuilder builder = gizmos.GetBuilder(hasher);
			try
			{
				using (builder.WithColor(AstarColor.UnwalkableNode))
				{
					GetNodes(delegate(GraphNode node)
					{
						if (!node.Walkable)
						{
							builder.SolidBox((Vector3)node.position, new float3(size, size, size));
						}
					});
				}
			}
			finally
			{
				((IDisposable)builder/*cast due to .constrained prefix*/).Dispose();
			}
		}

		void IGraphInternals.OnDestroy()
		{
			OnDestroy();
		}

		void IGraphInternals.DisposeUnmanagedData()
		{
			DisposeUnmanagedData();
		}

		void IGraphInternals.DestroyAllNodes()
		{
			DestroyAllNodes();
		}

		IGraphUpdatePromise IGraphInternals.ScanInternal(bool async)
		{
			return ScanInternal(async);
		}

		void IGraphInternals.SerializeExtraInfo(GraphSerializationContext ctx)
		{
			SerializeExtraInfo(ctx);
		}

		void IGraphInternals.DeserializeExtraInfo(GraphSerializationContext ctx)
		{
			DeserializeExtraInfo(ctx);
		}

		void IGraphInternals.PostDeserialization(GraphSerializationContext ctx)
		{
			PostDeserialization(ctx);
		}
	}
}
