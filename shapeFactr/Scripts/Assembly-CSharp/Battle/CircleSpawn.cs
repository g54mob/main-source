using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class CircleSpawn : SallyPoint
	{
		[Label("出撃半径(最小)")]
		public float minRadius;

		[Label("出撃半径(最大)")]
		public float maxRadius;

		private float radius;

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override void InitParameter(SallyPoint sallyPoint)
		{
		}

		public override Vector2 GetSallyPosition(Vector2? targetPos)
		{
			return default(Vector2);
		}

		public override Vector2 GetSallyPosition()
		{
			return default(Vector2);
		}

		public Vector2 GetCircleLinePosition(float? degree = null)
		{
			return default(Vector2);
		}

		public Vector2 GetCircumferentialPointByDegree(float degree)
		{
			return default(Vector2);
		}

		public Vector2 GetCircumferentialPointByDegree(float degree, float radius)
		{
			return default(Vector2);
		}

		public Vector2 GetMostNearlyAnglePosition(BaseEnemy target)
		{
			return default(Vector2);
		}

		public Vector2 GetMostNearlyAnglePosition(Vector3 target)
		{
			return default(Vector2);
		}

		public Vector3 GetPredictePosition(float degree = 0f)
		{
			return default(Vector3);
		}
	}
}
