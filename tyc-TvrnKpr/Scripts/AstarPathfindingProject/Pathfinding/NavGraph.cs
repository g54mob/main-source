using System;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.Serialization;
using Pathfinding.Util;
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
		public bool drawGizmos;

		[JsonMember]
		public bool infoScreenOpen;

		[JsonMember]
		private string serializedEditorSettings;

		internal bool exists => false;

		public abstract bool isScanned { get; }

		public virtual bool persistent => false;

		public virtual bool showInInspector => false;

		public virtual Bounds bounds => default(Bounds);

		string IGraphInternals.SerializedEditorSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual int CountNodes()
		{
			return 0;
		}

		public void GetNodes(Func<GraphNode, bool> action)
		{
		}

		public virtual void GetNodes(Action<GraphNode> action)
		{
		}

		public abstract void GetNodes<T>(GraphNode.NodeActionWithData<T> action, ref T data);

		public virtual bool IsPointOnNavmesh(Vector3 position)
		{
			return false;
		}

		public virtual bool IsInsideBounds(Vector3 point)
		{
			return false;
		}

		protected void AssertSafeToUpdateGraph()
		{
		}

		protected void DirtyBounds(Bounds bounds)
		{
		}

		public virtual void RelocateNodes(Matrix4x4 deltaMatrix)
		{
		}

		public virtual float NearestNodeDistanceSqrLowerBound(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NNInfo GetNearest(Vector3 position)
		{
			return default(NNInfo);
		}

		[Obsolete("Use the overload that takes a NearestNodeConstraint instead. See the migration guide for version 5.4 for more details.")]
		public NNInfo GetNearest(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfo);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NNInfo GetNearest(Vector3 position, NearestNodeConstraint constraint)
		{
			return default(NNInfo);
		}

		public virtual NNInfo GetNearest(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return default(NNInfo);
		}

		[Obsolete("Use GetNearest instead")]
		public NNInfo GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfo);
		}

		[Obsolete("Use the overload that takes a NearestNodeConstraint instead. See the migration guide for version 5.4 for more details.")]
		public NNInfo RandomPointOnSurface(NNConstraint nnConstraint, bool highQuality = true)
		{
			return default(NNInfo);
		}

		public NNInfo RandomPointOnSurface(bool highQuality = true)
		{
			return default(NNInfo);
		}

		public virtual NNInfo RandomPointOnSurface(NearestNodeConstraint constraint, bool highQuality = true)
		{
			return default(NNInfo);
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void DisposeUnmanagedData()
		{
		}

		protected virtual void DestroyAllNodes()
		{
		}

		public virtual IGraphSnapshot Snapshot(Bounds bounds)
		{
			return null;
		}

		public void Scan()
		{
		}

		protected virtual IGraphUpdatePromise ScanInternal()
		{
			return null;
		}

		protected virtual IGraphUpdatePromise ScanInternal(bool async)
		{
			return null;
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

		public virtual void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope, bool renderInGame)
		{
		}

		protected void DrawUnwalkableNodes(DrawingData gizmos, float size, RedrawScope redrawScope, bool renderInGame)
		{
		}

		void IGraphInternals.OnDestroy()
		{
		}

		void IGraphInternals.DisposeUnmanagedData()
		{
		}

		void IGraphInternals.DestroyAllNodes()
		{
		}

		IGraphUpdatePromise IGraphInternals.ScanInternal(bool async)
		{
			return null;
		}

		void IGraphInternals.SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		void IGraphInternals.DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		void IGraphInternals.PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
