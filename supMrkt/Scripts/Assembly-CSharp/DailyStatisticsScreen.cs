using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using __Project__.Scripts.ControllerInputModule;

public class DailyStatisticsScreen : MonoBehaviourPunCallbacks
{
	[Header("Animation")]
	[SerializeField]
	private DailyStatisticsScreenAnimation m_ScreenAnimation;

	[Header("Text Components")]
	[SerializeField]
	private TMP_Text m_DayText;

	[SerializeField]
	private GameObject clientNewDayText;

	[Space]
	[SerializeField]
	private TMP_Text m_SatisfiedCustomerText;

	[SerializeField]
	private TMP_Text m_ProductsNotFoundText;

	[SerializeField]
	private TMP_Text m_ProductsFoundExpensiveText;

	[SerializeField]
	private TMP_Text m_HarmedCustomersText;

	[SerializeField]
	private TMP_Text m_ShortChangeText;

	[SerializeField]
	private TMP_Text m_TotalCustomerText;

	[SerializeField]
	private TMP_Text m_StorePointText;

	[Space]
	[SerializeField]
	private TMP_Text m_CheckoutIncomeText;

	[SerializeField]
	private TMP_Text m_SupplyCostsText;

	[SerializeField]
	private TMP_Text m_UpgradeCostsText;

	[SerializeField]
	private TMP_Text m_CustomizationCostsText;

	[SerializeField]
	private TMP_Text m_RentText;

	[SerializeField]
	private TMP_Text m_BillsText;

	[SerializeField]
	private TMP_Text m_VendingText;

	[SerializeField]
	private TMP_Text m_LoanIncomeText;

	[SerializeField]
	private TMP_Text m_LoanPaymentText;

	[SerializeField]
	private TMP_Text m_StaffPaymentText;

	[SerializeField]
	private TMP_Text m_TotalProfitText;

	[Space]
	[SerializeField]
	private TMP_Text m_BalanceText;

	[Header("Settings")]
	[SerializeField]
	private Color m_PositiveTextColor;

	[SerializeField]
	private Color m_NeutralTextColor;

	[SerializeField]
	private Color m_NegativeTextColor;

	[Header("Bankruptcy")]
	[SerializeField]
	private BankruptcyManager m_BankruptcyManager;

	[SerializeField]
	private GameObject m_StartNextDayButton;

	[SerializeField]
	private GameObject m_StartNewGameButton;

	[SerializeField]
	private GameObject m_GetLoan;

	[SerializeField]
	private GameObject m_BankruptedText;

	[SerializeField]
	private GameObject m_BankruptDescriptionText;

	[SerializeField]
	private LocalizeStringEvent m_BankruptDescription;

	[SerializeField]
	private GameObject m_BankruptDescriptionExtra;

	[SerializeField]
	private GameObject m_BankruptedPanel;

	[Header("AutoSave")]
	[SerializeField]
	private GameObject m_SavingText;

	[SerializeField]
	private GamePadUIPanel m_gamePadUIPanel;

	private string m_PositiveColorCode;

	private string m_NegativeColorCode;

	private string m_NeutralColorCode;

	private bool m_isStatisticScreenEnabled;

	public bool EnableStatisticsScreen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void SetCursor(bool isGamepad)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void StartNextDay()
	{
	}

	[PunRPC]
	public void StaticsScreenOff()
	{
	}

	public void StartNewGame()
	{
	}

	public void GetBankruptLoan()
	{
	}

	private void OnDayFinished()
	{
	}

	[PunRPC]
	public void RPC_ReceiveStatistics(int day, int satisfied, int notFound, int expensive, int harmed, int shortChange, int totalCust, int storePoint, float checkoutIncome, float supplyCosts, float upgradeCosts, float customCosts, float rentCosts, float billCosts, float vendingIncome, float loanIncome, float loanPayment, float staffPayment, float dailyProfit, float balance)
	{
	}

	private void ApplyStatistics(int day, int satisfied, int notFound, int expensive, int harmed, int shortChange, int totalCust, int storePoint, float checkoutIncome, float supplyCosts, float upgradeCosts, float customCosts, float rentCosts, float billCosts, float vendingIncome, float loanIncome, float loanPayment, float staffPayment, float dailyProfit, float balance)
	{
	}

	private void CheckBankruptcy()
	{
	}

	private void OnDayCycleDisabled()
	{
	}

	private string StatisticPreCode(float amount)
	{
		return null;
	}

	private string StatisticPreCode(int amount)
	{
		return null;
	}

	private string StatisticPreColorCode(int amount)
	{
		return null;
	}

	private void AutoSave()
	{
	}

	public void ActivateClientNewDayText()
	{
	}
}
