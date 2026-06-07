using System;
using UnityEngine;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	public class RacingOffsetData
	{
		public CharacterVehicleType vehicleType { get; set; }

		public Vector2? racingOffset { get; set; }

		public float? racingAngle { get; set; }
	}
}
