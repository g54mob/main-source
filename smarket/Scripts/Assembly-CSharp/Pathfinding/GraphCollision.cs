using System;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class GraphCollision
	{
		public ColliderType type;

		public float diameter;

		public float height;

		public float collisionOffset;

		public RayDirection rayDirection;

		public LayerMask mask;

		public LayerMask heightMask;

		public float fromHeight;

		public bool thickRaycast;

		public float thickRaycastDiameter;

		public bool unwalkableWhenNoGround;

		public bool use2D;

		public bool collisionCheck;

		public bool heightCheck;

		public Vector3 up;

		private Vector3 upheight;

		private ContactFilter2D contactFilter;

		private static Collider2D[] dummyArray;

		private float finalRadius;

		private float finalRaycastRadius;

		public const float RaycastErrorMargin = 0.005f;

		private RaycastHit[] hitBuffer;

		public void Initialize(GraphTransform transform, float scale)
		{
		}

		public bool Check(Vector3 position)
		{
			return false;
		}

		public Vector3 CheckHeight(Vector3 position)
		{
			return default(Vector3);
		}

		public Vector3 CheckHeight(Vector3 position, out RaycastHit hit, out bool walkable)
		{
			hit = default(RaycastHit);
			walkable = default(bool);
			return default(Vector3);
		}

		public RaycastHit[] CheckHeightAll(Vector3 position, out int numHits)
		{
			numHits = default(int);
			return null;
		}

		public void DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}
	}
}
