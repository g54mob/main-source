namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class LoanController : SingletonMonoBehaviour<LoanController>, IPersistable
	{
		public LenderConfig[] lenders;

		[PersistenceOptIn]
		private Loan[] _currentLoanOffers;

		private void Start()
		{
		}

		public void Reset()
		{
		}

		public Loan[] GetLoanOffers()
		{
			return null;
		}

		private Loan GenerateLoan(LenderConfig config)
		{
			return null;
		}

		public void RegenerateNotTakenLoans()
		{
		}

		public void OnLoanRepaid(Loan loan)
		{
		}
	}
}
