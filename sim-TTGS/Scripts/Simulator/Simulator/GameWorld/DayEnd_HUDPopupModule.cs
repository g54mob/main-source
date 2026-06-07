using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class DayEnd_HUDPopupModule : HUDPopupModule
	{
		[Header("Game State")]
		[SerializeField]
		protected Localize m_dayLocalize;

		[SerializeField]
		protected TextMeshProUGUI m_shopLevelText;

		[SerializeField]
		protected Image m_xpSlider;

		[SerializeField]
		protected TextMeshProUGUI m_moneyText;

		[Header("Shop")]
		[SerializeField]
		protected TextMeshProUGUI m_xpText;

		[SerializeField]
		protected TextMeshProUGUI m_levelGainedText;

		[SerializeField]
		protected TextMeshProUGUI m_productsSoldText;

		[SerializeField]
		protected TextMeshProUGUI m_productsIncomeText;

		[Header("Clients")]
		[SerializeField]
		protected TextMeshProUGUI m_visitsText;

		[SerializeField]
		protected TextMeshProUGUI m_satisfactionText;

		[SerializeField]
		protected TextMeshProUGUI m_averageBuyText;

		[Header("Balance")]
		[SerializeField]
		protected TextMeshProUGUI m_totalIncomesText;

		[SerializeField]
		protected TextMeshProUGUI m_supplyCostText;

		[SerializeField]
		protected TextMeshProUGUI m_licenceCostText;

		[SerializeField]
		protected TextMeshProUGUI m_dailyRentText;

		[SerializeField]
		protected TextMeshProUGUI m_dailyElecBillText;

		[SerializeField]
		protected TextMeshProUGUI m_dailySalariesText;

		[SerializeField]
		protected TextMeshProUGUI m_totalBalanceText;

		[Space(10f)]
		[SerializeField]
		protected Button m_nextDayButton;

		[Header("Bills")]
		[SerializeField]
		protected TextMeshProUGUI m_rentUnpayedDaysText;

		[SerializeField]
		protected TextMeshProUGUI m_rentDueText;

		[SerializeField]
		protected Button m_rentPayButton;

		[SerializeField]
		protected TextMeshProUGUI m_elecUnpayedDaysText;

		[SerializeField]
		protected TextMeshProUGUI m_elecDueText;

		[SerializeField]
		protected Button m_elecPayButton;

		[SerializeField]
		protected TextMeshProUGUI m_salariesUnpayedDaysText;

		[SerializeField]
		protected TextMeshProUGUI m_salariesDueText;

		[SerializeField]
		protected Button m_salariesPayButton;

		[Space(10f)]
		[SerializeField]
		protected TextMeshProUGUI m_totalBillsText;

		[SerializeField]
		protected Button m_payAllBillsButton;

		protected const char PositiveSign = '+';

		protected const char NegativeSign = '-';

		public override EHUDPopupModuleType Type => EHUDPopupModuleType.DAY_END;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_nextDayButton.onClick.AddListener(OnButton_NextDay);
			m_rentPayButton.onClick.AddListener(OnButton_PayRent);
			m_elecPayButton.onClick.AddListener(OnButton_PayElec);
			m_salariesPayButton.onClick.AddListener(OnButton_PaySalaries);
			m_payAllBillsButton.onClick.AddListener(OnButton_PayAllBills);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_nextDayButton.onClick.RemoveListener(OnButton_NextDay);
			m_rentPayButton.onClick.RemoveListener(OnButton_PayRent);
			m_elecPayButton.onClick.RemoveListener(OnButton_PayElec);
			m_salariesPayButton.onClick.RemoveListener(OnButton_PaySalaries);
			m_payAllBillsButton.onClick.RemoveListener(OnButton_PayAllBills);
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			ICancelInputReceiver.SetCurrent(null);
			UpdateContent();
			World.BillsManager.RentBill.OnPay += UpdateBills;
			World.BillsManager.ElecBill.OnPay += UpdateBills;
			World.BillsManager.SalariesBill.OnPay += UpdateBills;
			GameState.MoneyAmountChanged += OnMoneyAmountChanged;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			World.BillsManager.RentBill.OnPay -= UpdateBills;
			World.BillsManager.ElecBill.OnPay -= UpdateBills;
			World.BillsManager.SalariesBill.OnPay -= UpdateBills;
			GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
		}

		protected virtual void UpdateContent()
		{
			DayScoreTracker dayScoreTracker = World.DayScoreTracker;
			m_dayLocalize.TermSuffix = " " + World.TimeController.DateElapsed.GetTotalDays();
			m_dayLocalize.OnLocalize(Force: true);
			m_shopLevelText.text = GameState.ShopLevel.ToString();
			m_xpSlider.fillAmount = World.GameState.GetNormalizedShopXP();
			UpdateMoney();
			m_xpText.text = "+" + dayScoreTracker.XP;
			m_levelGainedText.text = "+" + dayScoreTracker.Levels;
			m_productsSoldText.text = "+" + dayScoreTracker.ProductsSold;
			m_productsIncomeText.text = "+" + dayScoreTracker.ProductsIncome.ToStringMoneyFormat();
			m_visitsText.text = "+" + dayScoreTracker.Visits;
			m_satisfactionText.text = "100%";
			m_averageBuyText.text = "+" + dayScoreTracker.AverageBuy.ToStringMoneyFormat();
			m_totalIncomesText.text = "+" + dayScoreTracker.TotalIncomes.ToStringMoneyFormat();
			m_supplyCostText.text = "-" + dayScoreTracker.SupplyCost.ToStringMoneyFormat();
			m_licenceCostText.text = "-" + dayScoreTracker.LicenseCost.ToStringMoneyFormat();
			m_dailyRentText.text = "-" + World.BillsManager.RentBill.GetDailyPrice().ToStringMoneyFormat();
			m_dailyElecBillText.text = "-" + World.BillsManager.ElecBill.GetDailyPrice().ToStringMoneyFormat();
			m_dailySalariesText.text = "-" + World.BillsManager.SalariesBill.GetDailyPrice().ToStringMoneyFormat();
			float totalBalance = dayScoreTracker.TotalBalance;
			string text = ((totalBalance >= 0f) ? '+'.ToString() : string.Empty);
			m_totalBalanceText.text = text + totalBalance.ToStringMoneyFormat();
			UpdateBills();
		}

		private void UpdateBills()
		{
			m_rentUnpayedDaysText.text = World.BillsManager.RentBill.UnpaidDays.ToString();
			m_rentDueText.text = World.BillsManager.RentBill.DueAmount.ToStringMoneyFormat();
			m_elecUnpayedDaysText.text = World.BillsManager.ElecBill.UnpaidDays.ToString();
			m_elecDueText.text = World.BillsManager.ElecBill.DueAmount.ToStringMoneyFormat();
			m_salariesUnpayedDaysText.text = World.BillsManager.SalariesBill.UnpaidDays.ToString();
			m_salariesDueText.text = World.BillsManager.SalariesBill.DueAmount.ToStringMoneyFormat();
			m_totalBillsText.text = World.BillsManager.GetTotalBills().ToStringMoneyFormat();
		}

		protected virtual void OnButton_NextDay()
		{
			Validate();
			World.NextDay();
		}

		protected virtual void OnButton_PayRent()
		{
			World.BillsManager.RentBill.TryPay();
		}

		protected virtual void OnButton_PayElec()
		{
			World.BillsManager.ElecBill.TryPay();
		}

		protected virtual void OnButton_PaySalaries()
		{
			World.BillsManager.SalariesBill.TryPay();
		}

		protected virtual void OnButton_PayAllBills()
		{
			World.BillsManager.TryPayAll();
		}

		private void OnMoneyAmountChanged(float _)
		{
			UpdateMoney();
		}

		private void UpdateMoney()
		{
			m_moneyText.text = GameState.MoneyAmount.ToStringMoneyFormat();
		}
	}
}
