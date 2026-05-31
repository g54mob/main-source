using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class LoanItem : MonoBehaviour
{
	[Header("Layouts")]
	[SerializeField]
	private GameObject m_LockedLayout;

	[SerializeField]
	private GameObject m_AvailableLayout;

	[SerializeField]
	private GameObject m_TakenLayout;

	[Header("Locked Layout")]
	[SerializeField]
	private LocalizeStringEvent m_RequiredLevelText;

	[Header("Available Layout")]
	[SerializeField]
	private TMP_Text m_CreditName;

	[SerializeField]
	private TMP_Text m_LoanAmountText;

	[SerializeField]
	private TMP_Text m_DailyInterestText;

	[SerializeField]
	private TMP_Text m_ReturnPaymentText;

	[SerializeField]
	private TMP_Text m_DailyPaymentText;

	[SerializeField]
	private TMP_Text m_LoanTermLengthText;

	[SerializeField]
	private Button m_LoanButton;

	[SerializeField]
	private Slider m_LoanTermLengthSlider;

	[Header("Taken Layout")]
	[SerializeField]
	private TMP_Text m_TakenLoanAmountText;

	[SerializeField]
	private TMP_Text m_RemainingPaymentText;

	[SerializeField]
	private TMP_Text m_EarlyPayOffAmountText;

	[SerializeField]
	private TMP_Text m_NumberOfPaymentsLeftText;

	[SerializeField]
	private Button m_PayOffEarlyButton;

	protected LoanStatus m_LoanStatus;

	private float m_Amount;

	private float m_floatLength;

	private int m_LoanID;

	protected BankCreditSO m_Loan;

	private int m_LoanTermLength;

	public LoanData m_Data;

	public int LoanID => 0;

	public bool Taken => false;

	protected bool m_Locked => false;

	public virtual void Setup(LoanData loanData)
	{
	}

	public void TakeLoan()
	{
	}

	public void TakeLoan_Order()
	{
	}

	public void PayOffEarly()
	{
	}

	public void UpdateTakenLayoutUI()
	{
	}

	public void ConfirmForGamepad()
	{
	}

	public void SetSliderValueGamepad(bool isLeft)
	{
	}

	public virtual void SetStatus(LoanStatus status)
	{
	}

	protected void SetupLockedLayout()
	{
	}

	private void SetupInvisibleLayout()
	{
	}

	private void SetupAvailableLayout()
	{
	}

	protected void SetupTakenLayout()
	{
	}

	protected void UpdateAvailableLayoutUI()
	{
	}

	private void CheckIfReachedRequiredLevel(bool _)
	{
	}

	private void UpdatePayOffButton(float _amount, MoneyManager.TransitionType _type)
	{
	}

	private void OnLoanTermLengthChanged(float value)
	{
	}

	private void OnMoneyManagerDisabled()
	{
	}

	private void OnStoreLevelDisabled()
	{
	}
}
