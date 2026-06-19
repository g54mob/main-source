using System;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrbAuthoring : MonoBehaviour
{
	[Serializable]
	public class MovementPattern
	{
		public ElectricOrbMovementPattern pattern;

		public Vector2 minMaxDurationSeconds;

		public Vector2 minMaxSpeed;

		public bool sinusoidalPattern;

		public float sinusoidalMaxTurnAngleDegrees;

		public float sinusoidalRepeatTimePerSecond;
	}

	public float startDuration;

	public float loopDuration;

	public float endDuration;

	public float hiddenEndDuration;

	public bool bounceOnWalls;

	public List<MovementPattern> movementPatterns;
}
