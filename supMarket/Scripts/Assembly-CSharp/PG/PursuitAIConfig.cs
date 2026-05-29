using System;
using UnityEngine;

namespace PG
{
	[Serializable]
	public class PursuitAIConfig
	{
		public LayerMask ObstacleHitMask;

		public float HitPointHeight;

		public float VisibilityArea;

		public float VisibilityAreaIgnoreObstacle;

		public float HitDellayTime;
	}
}
