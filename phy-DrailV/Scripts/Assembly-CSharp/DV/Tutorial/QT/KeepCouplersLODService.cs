namespace DV.Tutorial.QT
{
	public class KeepCouplersLODService : ATutorialService
	{
		private ChainCouplerVisibilityOptimizer[] chainOptimizers;

		private CouplingHoseRig[] hoseOptimizers;

		public KeepCouplersLODService(TrainCar car)
		{
			chainOptimizers = car.GetComponentsInChildren<ChainCouplerVisibilityOptimizer>(includeInactive: true);
			hoseOptimizers = car.interior.GetComponentsInChildren<CouplingHoseRig>(includeInactive: true);
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			for (int i = 0; i < chainOptimizers.Length; i++)
			{
				if (chainOptimizers[i].IsLODLocked)
				{
					chainOptimizers[i] = null;
				}
				else
				{
					chainOptimizers[i].LockLOD();
				}
			}
			for (int j = 0; j < hoseOptimizers.Length; j++)
			{
				if (hoseOptimizers[j].LODManager.IsLODLocked)
				{
					hoseOptimizers[j] = null;
				}
				else
				{
					hoseOptimizers[j].LODManager.LockLOD();
				}
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			ChainCouplerVisibilityOptimizer[] array = chainOptimizers;
			foreach (ChainCouplerVisibilityOptimizer chainCouplerVisibilityOptimizer in array)
			{
				if ((bool)chainCouplerVisibilityOptimizer)
				{
					chainCouplerVisibilityOptimizer.UnlockLOD();
				}
			}
			CouplingHoseRig[] array2 = hoseOptimizers;
			foreach (CouplingHoseRig couplingHoseRig in array2)
			{
				if ((bool)couplingHoseRig)
				{
					couplingHoseRig.LODManager.UnlockLOD();
				}
			}
		}

		public override void UpdateService()
		{
		}
	}
}
