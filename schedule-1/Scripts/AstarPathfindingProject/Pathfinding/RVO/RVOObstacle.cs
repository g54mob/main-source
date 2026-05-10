using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.RVO
{
	public abstract class RVOObstacle : VersionedMonoBehaviour
	{
		public enum ObstacleVertexWinding
		{
			KeepOut = 0,
			KeepIn = 1
		}

		public ObstacleVertexWinding obstacleMode;

		public RVOLayer layer;

		protected Simulator sim;

		private List<ObstacleVertex> addedObstacles;

		private List<Vector3[]> sourceObstacles;

		private bool gizmoDrawing;

		private List<Vector3[]> gizmoVerts;

		private ObstacleVertexWinding _obstacleMode;

		private Matrix4x4 prevUpdateMatrix;

		protected abstract bool ExecuteInEditor { get; }

		protected abstract bool LocalCoordinates { get; }

		protected abstract bool StaticObstacle { get; }

		protected abstract float Height { get; }

		protected abstract void CreateObstacles();

		protected abstract bool AreGizmosDirty();

		public void OnDrawGizmos()
		{
		}

		public void OnDrawGizmosSelected()
		{
		}

		public void OnDrawGizmos(bool selected)
		{
		}

		protected virtual Matrix4x4 GetMatrix()
		{
			return default(Matrix4x4);
		}

		public void OnDisable()
		{
		}

		public void OnEnable()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		protected void FindSimulator()
		{
		}

		protected void AddObstacle(Vector3[] vertices, float height)
		{
		}

		private void AddObstacleInternal(Vector3[] vertices, float height)
		{
		}

		private void WindCorrectly(Vector3[] vertices)
		{
		}
	}
}
