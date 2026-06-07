namespace DV.ServicePenalty
{
	public abstract class LocoDebtTrackerBase : DebtTrackerBase
	{
		public abstract void ResetState();

		public abstract void TurnOffDebtSources();

		public abstract bool IsDebtOnlyEnvironmental();
	}
}
