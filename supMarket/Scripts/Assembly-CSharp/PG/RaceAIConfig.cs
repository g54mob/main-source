using System;
using UnityEngine;

namespace PG
{
	[Serializable]
	public class RaceAIConfig
	{
		[Range(0f, 1f)]
		public float Aggressiveness;

		public float ObstacleHitDistance;

		public float HitPointHeight;

		public float ChangeHorizontalOffsetSpeed;

		public float OffsetForMainHitPoints;

		public float OffsetForMainHitDirections;

		public float OffsetForAdditionalHitPoints;

		public float MainHitDellayTime;

		public float AdditionalHitDellayTime;
	}
}
