using UnityEngine;

namespace CTS.AI
{
	public struct PathCorner
	{
		public Vector3 Position;

		public float RemainingDistance;

		public float DistanceToNext;

		public bool IsLastCorner;

		public bool IsOffLinkEntry;

		public float TurnAngle;

		public Vector2 Normal;

		public static implicit operator Vector3(PathCorner corner)
		{
			return corner.Position;
		}

		public static Vector2 operator -(PathCorner one, PathCorner two)
		{
			return one.Position -= two.Position;
		}

		public static Vector2 operator +(PathCorner one, PathCorner two)
		{
			return one.Position += two.Position;
		}
	}
}
