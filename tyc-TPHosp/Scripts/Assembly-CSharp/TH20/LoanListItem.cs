using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LoanListItem : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private Image _imageBackground;

		[SerializeField]
		private ButtonAnimator _button;

		[SerializeField]
		private Localize _buttonLabel;

		[SerializeField]
		private Image _iconProvider;

		[SerializeField]
		private TMP_Text _providerName;

		[SerializeField]
		private TMP_Text _loanAmountLabel;

		[SerializeField]
		private Image _loanAmountBackground;

		[SerializeField]
		private GameObject _availablePanel;

		[SerializeField]
		private TMP_Text _availableLoanRepaymentLabel;

		[SerializeField]
		private GameObject _notAvailablePanel;

		[SerializeField]
		private TMP_Text _notAvailableLoanRepaymentLabel;

		[SerializeField]
		private TMP_Text _requirementLabel;

		[SerializeField]
		private GameObject _activePanel;

		[SerializeField]
		private TMP_Text _activeLoanRepaymentLabel;

		[SerializeField]
		private ButtonAnimator _decreaseLoanAmountButton;

		[SerializeField]
		private ButtonAnimator _increaseLoanAmountButton;

		[SerializeField]
		private Slider _loanSlider;

		private const float ButtonLoanIncrement = 0.05f;

		private LoanManager _loanManager;

		private FinanceManager _financeManager;

		public LoanOffer Offer { get; private set; }

		private void Start()
		{
			_decreaseLoanAmountButton.Button.onPrimaryDown.AddListener(OnDecreaseLoanAmount);
			_increaseLoanAmountButton.Button.onPrimaryDown.AddListener(OnIncreaseLoanAmount);
			_loanSlider.onValueChanged.AddListener(OnLoanValueChanged);
		}

		public void Initialise(LoanOffer offer, FinanceManager financeManager, LoanManager loanManager)
		{
			Offer = offer;
			_loanManager = loanManager;
			_financeManager = financeManager;
			_loanSlider.wholeNumbers = true;
			_loanSlider.minValue = offer.MinLoanAmount;
			_loanSlider.maxValue = offer.MaxLoanAmount;
			_loanSlider.value = offer.Amount;
		}

		public void RefreshUI()
		{
			_iconProvider.overrideSprite = Offer.LoanProviderIcon;
			_providerName.text = ((!Offer.DisplayName.IsNull()) ? Offer.DisplayName.Translation : string.Empty);
			_decreaseLoanAmountButton.CurrentState = ((_loanSlider.normalizedValue <= 0f) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			_increaseLoanAmountButton.CurrentState = ((_loanSlider.normalizedValue >= 1f) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			bool flag = false;
			_button.Button.onPrimaryDown.RemoveAllListeners();
			if (!Offer.Available)
			{
				GameObjectUtils.SetActive(_availablePanel, isActive: false);
				GameObjectUtils.SetActive(_notAvailablePanel, isActive: true);
				GameObjectUtils.SetActive(_activePanel, isActive: false);
				_buttonLabel.SetTerm("Menu/Loans/LoanExempt");
				string loanAmount_CS = ScriptLocalization.Menu_Loans.LoanAmount_CS;
				loanAmount_CS = loanAmount_CS.Replace("{[AMOUNT]}", StringUtils.FormatCurrencyWithoutSymbol(Offer.Amount));
				loanAmount_CS = loanAmount_CS.Replace("{[APR]}", StringUtils.FormatPercentageValue((float)Offer.APR / 100f));
				_loanAmountLabel.text = loanAmount_CS;
				string loanRepaymentDetail_CS = ScriptLocalization.Menu_Loans.LoanRepaymentDetail_CS;
				loanRepaymentDetail_CS = loanRepaymentDetail_CS.Replace("{[AMOUNT]}", $"<size=140%>{StringUtils.FormatCurrency(Offer.MonthlyRepayment)}</size>");
				loanRepaymentDetail_CS = loanRepaymentDetail_CS.Replace("{[MONTHS]}", $"<size=140%>{Offer.RepaymentPeriod}</size>");
				_notAvailableLoanRepaymentLabel.text = loanRepaymentDetail_CS;
				_requirementLabel.text = Offer.RequiredString;
				_canvasGroup.alpha = 0.75f;
				_button.CurrentState = ButtonAnimator.State.Unselectable;
			}
			else if (!Offer.Active)
			{
				GameObjectUtils.SetActive(_availablePanel, isActive: true);
				GameObjectUtils.SetActive(_notAvailablePanel, isActive: false);
				GameObjectUtils.SetActive(_activePanel, isActive: false);
				_buttonLabel.SetTerm("Menu/Loans/TakeLoan");
				string loanAmount_CS2 = ScriptLocalization.Menu_Loans.LoanAmount_CS;
				loanAmount_CS2 = loanAmount_CS2.Replace("{[AMOUNT]}", StringUtils.FormatCurrencyWithoutSymbol(Offer.Amount));
				loanAmount_CS2 = loanAmount_CS2.Replace("{[APR]}", StringUtils.FormatPercentageValue((float)Offer.APR / 100f));
				_loanAmountLabel.text = loanAmount_CS2;
				string loanRepaymentDetail_CS2 = ScriptLocalization.Menu_Loans.LoanRepaymentDetail_CS;
				loanRepaymentDetail_CS2 = loanRepaymentDetail_CS2.Replace("{[AMOUNT]}", $"<size=140%>{StringUtils.FormatCurrency(Offer.MonthlyRepayment)}</size>");
				loanRepaymentDetail_CS2 = loanRepaymentDetail_CS2.Replace("{[MONTHS]}", $"<size=140%>{Offer.RepaymentPeriod}</size>");
				_availableLoanRepaymentLabel.text = loanRepaymentDetail_CS2;
				_canvasGroup.alpha = 1f;
				_button.Button.onPrimaryDown.AddListener(delegate
				{
					_loanManager.TakeOutLoan(Offer);
				});
				_button.CurrentState = ButtonAnimator.State.Selectable;
				flag = true;
			}
			else
			{
				GameObjectUtils.SetActive(_availablePanel, isActive: false);
				GameObjectUtils.SetActive(_notAvailablePanel, isActive: false);
				GameObjectUtils.SetActive(_activePanel, isActive: true);
				_buttonLabel.SetTerm("Menu/Loans/RepayLoan");
				string loanAmount_CS3 = ScriptLocalization.Menu_Loans.LoanAmount_CS;
				loanAmount_CS3 = loanAmount_CS3.Replace("{[AMOUNT]}", StringUtils.FormatCurrencyWithoutSymbol(Offer.OutstandingBalance));
				loanAmount_CS3 = loanAmount_CS3.Replace("{[APR]}", StringUtils.FormatPercentageValue((float)Offer.APR / 100f));
				_loanAmountLabel.text = loanAmount_CS3;
				string loanRepaymentDetail_CS3 = ScriptLocalization.Menu_Loans.LoanRepaymentDetail_CS;
				loanRepaymentDetail_CS3 = loanRepaymentDetail_CS3.Replace("{[AMOUNT]}", $"<size=140%>{StringUtils.FormatCurrency(Offer.MonthlyRepayment)}</size>");
				loanRepaymentDetail_CS3 = loanRepaymentDetail_CS3.Replace("{[MONTHS]}", $"<size=140%>{Offer.RemainingMonths}</size>");
				_activeLoanRepaymentLabel.text = loanRepaymentDetail_CS3;
				_canvasGroup.alpha = 1f;
				_button.Button.onPrimaryDown.AddListener(delegate
				{
					_loanManager.RepayLoan(Offer);
				});
				_button.CurrentState = ((!_financeManager.CanAfford(Offer.OutstandingBalance)) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				flag = true;
			}
			if (flag)
			{
				ButtonSFX component = _button.Button.GetComponent<ButtonSFX>();
				if (component != null)
				{
					component.UpdateListeners();
				}
			}
		}

		public void ApplyScheme(LoanMenu.ColorScheme scheme)
		{
			_imageBackground.color = scheme.BackgroundColor;
			_loanAmountLabel.color = scheme.LoanAmountTextColor;
			_loanAmountBackground.color = scheme.LoanAmountBackingColor;
		}

		private void OnLoanValueChanged(float value)
		{
			Offer.Amount = (int)value;
			RefreshUI();
		}

		private void OnIncreaseLoanAmount()
		{
			_loanSlider.normalizedValue = Mathf.Clamp01(_loanSlider.normalizedValue + 0.05f);
		}

		private void OnDecreaseLoanAmount()
		{
			_loanSlider.normalizedValue = Mathf.Clamp01(_loanSlider.normalizedValue - 0.05f);
		}
	}
}
