namespace Gh.Tk
{
	public class FireBrigadeIsComingAlertBadge : AlertBadgeBase
	{
		private static string _beforeFireBrigadeCalledTextKey;

		private static string _afterFireBrigadeCalledTextKey;

		private float _maxHoursBeforeFireBrigadeCalled;

		[PersistenceOptIn]
		private float _currentHoursBeforeFireBrigadeCalled;

		private float _maxHoursBeforeExtinguish;

		[PersistenceOptIn]
		private float _currentHoursBeforeExtinguish;

		private float _maxHoursBeforeFireBrigadeReady;

		[PersistenceOptIn]
		private float _currentHoursBeforeFireBrigadeReady;

		[PersistenceOptIn]
		private bool _isFireBrigadeReady;

		[PersistenceOptIn]
		private bool _warningAlertGenerated;

		[PersistenceOptIn]
		private bool _isEvacuating;

		private bool IsFireBrigadeDisabled => false;

		protected override bool UpdateInternal()
		{
			return false;
		}

		protected override void CreateBadge()
		{
		}

		private void UpdateFireBrigadeButton()
		{
		}

		private void ApplyFireBrigadeButton()
		{
		}

		private void ClearFireBrigadeButton()
		{
		}

		private void CallFireBrigade()
		{
		}

		private void Extinguish()
		{
		}
	}
}
