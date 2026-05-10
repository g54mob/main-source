using System;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : NoktaSingleton<BankManager>
{
	[SerializeField]
	private List<BankCreditSO> m_Loans;

	[SerializeField]
	private float m_LatePaymentFeePenaltyPercentage;

	[SerializeField]
	private int m_RepaymentsDueDate;

	[SerializeField]
	private int m_AutoPayingRepaymentsDueDate;

	private List<LoanData> m_LoanDatas;

	private List<PlayerPaymentData> m_LoanBillDatas;

	public Action<int> onTakenLoan;

	public Action<int> onCompletedLoan;

	public Action onDisabled;

	public Action<PlayerPaymentData, bool> OnLoanBillDataChanged;

	private LoanPaymentsTab m_LoanPaymentsTab;

	private LoansTab m_LoansTab;

	public List<LoanData> Loans => null;

	public float LatePaymentFeePenaltyPercentage => 0f;

	public List<PlayerPaymentData> OverdueRepayments => null;

	public int RepaymentDueDate => 0;

	public int TakenLoanCount => 0;

	public int PaymentsRemaining => 0;

	public float TotalLatePaymentFee => 0f;

	public float TotalDebt => 0f;

	private void Awake()
	{
	}

	public void LoadSaveProgress()
	{
	}

	private void OnDisable()
	{
	}

	public void PayRepayment(PlayerPaymentData loanData, bool byForce = false)
	{
	}

	private void LoadLoanDatas()
	{
	}

	private void LoadLoanRepaymentDatas()
	{
	}

	private void RemoveBill(PlayerPaymentData loanData)
	{
	}

	public void CompleteLoan(LoanData loanData, float earlyPayment)
	{
	}

	private void TryAddingLoanBills()
	{
	}

	private void UnsubscribeDayCycle()
	{
	}

	private void InitializeLoanMenu()
	{
	}

	public void PayRepayment_Order(int loanId)
	{
	}

	public void CompleteLoan_Order(int loanId)
	{
	}

	public void AddLoanBills_Order(LoanData loanData, PlayerPaymentData bill)
	{
	}

	public void LoanTaken_Order(int loanID)
	{
	}
}
