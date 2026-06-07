using Assets.Nimbatus.Scripts.Behaviours.Radar;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnRadarExit : NimbatusEvent
	{
		public EnemyRadar Radar;

		protected override void Subscribe()
		{
			Radar.OnTargetLost += OnRadarTargetLost;
		}

		private void OnRadarTargetLost()
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			Radar.OnTargetLost -= OnRadarTargetLost;
		}
	}
}
