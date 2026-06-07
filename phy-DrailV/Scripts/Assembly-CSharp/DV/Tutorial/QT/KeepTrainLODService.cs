namespace DV.Tutorial.QT
{
	public class KeepTrainLODService : ATutorialService
	{
		private TrainPhysicsLod lod;

		private TrainCar desiredCar;

		public KeepTrainLODService(TrainCar desiredCar = null)
		{
			this.desiredCar = desiredCar;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			TrainCar trainCar = ((desiredCar != null) ? desiredCar : PlayerManager.Car);
			if (!(trainCar != null))
			{
				return;
			}
			lod = trainCar.GetComponentInChildren<TrainPhysicsLod>();
			if (lod != null)
			{
				if (!lod.LockedHighestLOD)
				{
					lod.LockHighestLOD();
				}
				else
				{
					lod = null;
				}
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			if (lod != null)
			{
				lod.UnlockHighestLOD();
				lod = null;
			}
		}

		public override void UpdateService()
		{
		}
	}
}
