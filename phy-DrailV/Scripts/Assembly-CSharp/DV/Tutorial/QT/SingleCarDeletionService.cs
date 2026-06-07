namespace DV.Tutorial.QT
{
	public class SingleCarDeletionService : ACommsRadioService<CommsRadioCarDeleter>
	{
		private TrainCar car;

		public SingleCarDeletionService(TrainCar car)
		{
			this.car = car;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			base.StartService(host, phase);
			if ((bool)base.Mode)
			{
				base.Mode.SingleAllowedCar = car;
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			if ((bool)base.Mode)
			{
				base.Mode.SingleAllowedCar = null;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
