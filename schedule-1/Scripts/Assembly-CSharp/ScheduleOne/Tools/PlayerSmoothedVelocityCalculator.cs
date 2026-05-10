using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Tools
{
	public class PlayerSmoothedVelocityCalculator : SmoothedVelocityCalculator
	{
		public Player Player;

		public override Vector3 Velocity => default(Vector3);
	}
}
