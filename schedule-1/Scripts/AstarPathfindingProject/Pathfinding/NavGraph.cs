using System;
using System.Collections.Generic;
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

		[Obsolete("Use the transform field (only available on some graph types) instead", true)]
		public Matrix4x4 matrix;

		[Obsolete("Use the transform field (only available on some graph types) instead", true)]
		public Matrix4x4 inverseMatrix;

		internal bool exists => false;

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

		public abstract void GetNodes(Action<GraphNode> action);

		[Obsolete("Use the transform field (only available on some graph types) instead", true)]
		public void SetMatrix(Matrix4x4 m)
		{
		}

		[Obsolete("Use RelocateNodes(Matrix4x4) instead. To keep the same behavior you can call RelocateNodes(newMatrix * oldMatrix.inverse).")]
		public void RelocateNodes(Matrix4x4 oldMatrix, Matrix4x4 newMatrix)
		{
		}

		protected void AssertSafeToUpdateGraph()
		{
		}

		public virtual void RelocateNodes(Matrix4x4 deltaMatrix)
		{
		}

		public NNInfoInternal GetNearest(Vector3 position)
		{
			return default(NNInfoInternal);
		}

		public NNInfoInternal GetNearest(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfoInternal);
		}

		public virtual NNInfoInternal GetNearest(Vector3 position, NNConstraint constraint, GraphNode hint)
		{
			return default(NNInfoInternal);
		}

		public virtual NNInfoInternal GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfoInternal);
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void DestroyAllNodes()
		{
		}

		[Obsolete("Use AstarPath.Scan instead")]
		public void ScanGraph()
		{
		}

		public void Scan()
		{
		}

		protected abstract IEnumerable<Progress> ScanInternal();

		protected virtual void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected virtual void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected virtual void PostDeserialization(GraphSerializationContext ctx)
		{
		}

		protected virtual void DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}

		public virtual void OnDrawGizmos(RetainedGizmos gizmos, bool drawNodes)
		{
		}

		protected void DrawUnwalkableNodes(float size)
		{
		}

		void IGraphInternals.OnDestroy()
		{
		}

		void IGraphInternals.DestroyAllNodes()
		{
		}

		IEnumerable<Progress> IGraphInternals.ScanInternal()
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

		void IGraphInternals.DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}
	}
}
