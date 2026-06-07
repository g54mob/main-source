namespace DV.Tutorial.QT
{
	public class SingleRailCrewSpawnService : ACommsRadioService<CommsRadioCrewVehicle>
	{
		private RailTrack track;

		public SingleRailCrewSpawnService(RailTrack track)
		{
			this.track = track;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			base.StartService(host, phase);
			if ((bool)base.Mode)
			{
				base.Mode.SingleAllowedTrack = track;
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)base.Mode)
			{
				base.Mode.SingleAllowedTrack = null;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
