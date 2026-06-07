using Assets.Nimbatus.Scripts.Behaviours.Radar;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class RadarHasTarget : NimbatusCondition
	{
		public EnemyRadar Radar;

		public override bool IsTrue()
		{
			return Radar.NearestTarget != null;
		}
	}
}
