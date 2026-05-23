using UnityEngine;

namespace Battle
{
	public abstract class SallyPoint
	{
		[Label("出撃位置オフセット")]
		public Vector2 offset;

		private Vector2 spawnPosition;

		private float? spawnDegree;

		public Vector3 UnitOrigin => default(Vector3);

		public Vector2 SpawnPosition
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float? SpawnDegree
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual void InitParameter(SallyPoint sallyPoint)
		{
		}

		public abstract Vector2 GetSallyPosition();

		public abstract Vector2 GetSallyPosition(Vector2? targetPosition);

		public static float[] GetDegreePoints(int count, float startAngle = 0f)
		{
			return null;
		}
	}
}
