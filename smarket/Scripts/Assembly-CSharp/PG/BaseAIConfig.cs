using System;

namespace PG
{
	[Serializable]
	public class BaseAIConfig
	{
		public float MaxSpeed;

		public float MinSpeed;

		public float SetSteerAngleMultiplayer;

		public float OffsetToTargetPoint;

		public float SpeedFactorToTargetPoint;

		public float OffsetTurnPrediction;

		public float SpeedFactorToTurnPrediction;

		public float LookAngleSppedFactor;

		public float ReverseWaitTime;

		public float ReverseTime;

		public float BetweenReverseTimeForReset;
	}
}
