using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnMissionCompleted : NimbatusEvent
	{
		protected override void Subscribe()
		{
			MissionManager.OnMissionCompleted += MissionCompleted;
		}

		private void MissionCompleted(NimbatusMission mission)
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			MissionManager.OnMissionCompleted -= MissionCompleted;
		}
	}
}
