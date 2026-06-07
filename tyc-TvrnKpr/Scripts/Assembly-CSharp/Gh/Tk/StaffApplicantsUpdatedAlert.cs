namespace Gh.Tk
{
	public class StaffApplicantsUpdatedAlert : AdvisorAlertBase
	{
		[PersistenceOptIn]
		private float _newCvsTimestamp;

		[PersistenceOptIn]
		private bool _tryToAlert;

		protected override bool TryTriggerInternal()
		{
			return false;
		}

		internal void NotifyOfNewCvs()
		{
		}
	}
}
