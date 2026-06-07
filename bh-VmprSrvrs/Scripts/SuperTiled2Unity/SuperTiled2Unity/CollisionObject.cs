using System;
using System.Collections.Generic;
using UnityEngine;

namespace SuperTiled2Unity
{
	[Serializable]
	public class CollisionObject
	{
		public int m_ObjectId;

		public string m_ObjectName;

		public string m_ObjectType;

		public Vector2 m_Position;

		public Vector2 m_Size;

		public float m_Rotation;

		public List<CustomProperty> m_CustomProperties;

		public string m_PhysicsLayer;

		public bool m_IsTrigger;

		[SerializeField]
		private Vector2[] m_Points;

		[SerializeField]
		private bool m_IsClosed;

		[SerializeField]
		private CollisionShapeType m_CollisionShapeType;

		public Vector2[] Points => null;

		public bool IsClosed => false;

		public CollisionShapeType CollisionShapeType => default(CollisionShapeType);

		public void MakePointsFromRectangle()
		{
		}

		public void MakePoint()
		{
		}

		public void MakePointsFromEllipse(int numEdges)
		{
		}

		public void MakePointsFromPolygon(Vector2[] points)
		{
		}

		public void MakePointsFromPolyline(Vector2[] points)
		{
		}

		public void RenderPoints(SuperTile tile, GridOrientation orientation, Vector2 gridSize)
		{
		}

		private Vector2 IsometricTransform(Vector2 pt, SuperTile tile, Vector2 gridSize)
		{
			return default(Vector2);
		}

		private Vector2 LocalTransform(Vector2 pt, SuperTile tile)
		{
			return default(Vector2);
		}

		private void ApplyRotationToPoints()
		{
		}
	}
}
