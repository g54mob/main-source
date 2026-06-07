using UnityEngine;

public class BankruptcyManager : NoktaSingleton<BankruptcyManager>
{
	[SerializeField]
	public BankCreditSO m_Loan;

	[SerializeField]
	private int m_LoanTermLength;

	[SerializeField]
	private LoansTab m_loansTab;

	public int LoanTermLength => 0;

	public void TakeLoan()
	{
	}

	public bool IsBankruptLoanAlreadyTaken()
	{
		return false;
	}

	public bool CheckForBankruptcy()
	{
		return false;
	}

	public void SpendMoney()
	{
	}

	public void GetMoney()
	{
	}
}
