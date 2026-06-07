using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class SecondsSinceLastDamage : NimbatusCondition
	{
		public HealthPool HealthPool;

		public float Seconds;

		public override bool IsTrue()
		{
			if (HealthPool != null && Time.time - HealthPool.LastDamageTime > Seconds)
			{
				return true;
			}
			return false;
		}
	}
}
