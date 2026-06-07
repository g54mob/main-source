using Assets.Nimbatus.Scripts.Behaviours.Radar;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnRadarEnter : NimbatusEvent
	{
		public EnemyRadar Radar;

		protected override void Subscribe()
		{
			Radar.OnTargetFound += RadarTargetFound;
		}

		private void RadarTargetFound()
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			Radar.OnTargetFound -= RadarTargetFound;
		}
	}
}
