using System;
using System.Collections.Generic;
using System.Globalization;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class FinancialLoaningContract : MonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private PaletteData _onDefaultBorderColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private PaletteData _onDefaultBackgroundColor;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private PaletteData _onTakeOutBorderColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private PaletteData _onTakeOutBackgroundColor;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private Image _border;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Image _loanSprite;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Image _background;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject[] _controllerButtonsContractAmount;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _contractTitle;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _prestigeLevelRequiredText;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _amountOfTheLoan;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _interestOfTheLoan;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _amountByMonth;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _amountByMonth2;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _loanDuration;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _timeDurationRemaining;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _remainingMoney;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _takeOutButton;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _refundButton;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _lockCover;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Localization")]
		private LocalizedString _amountKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _amountContractedKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _interestKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _loanDurationKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _perKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _monthKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _prestigeLevelKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _prestigeRequiredKey;

		[SerializeField]
		[BoxGroup("Localization")]
		private LocalizedString _timeDuration;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Debug")]
		private bool _debugMode;

		[SerializeField]
		private List<GameObject> _loanTake;

		[SerializeField]
		private List<GameObject> _noLoan;

		private bool _contractIsActive;

		private bool _contractUnlocked;

		private float _baseInterest;

		private float _currentInterest;

		private int _borrowingPeriod;

		private int _bankLoanIncrementation;

		private Vector2Int _bankLoanMoneyFromTo;

		private int _contractAmount;

		private int _prestigeRequired;

		private int _monthlyCharges;

		private int _remainingAmount;

		private int _remainingTimeToPay;

		private static readonly StringKey _interestMultiplierKey = "Diff_LoanInterest";

		public FinancialLoanSO FinancialLoanSO { get; private set; }

		public bool ContractIsActive => _contractIsActive;

		public int GetContractAmount()
		{
			return _contractAmount;
		}

		public int GetRemainingAmount()
		{
			return _remainingAmount;
		}

		public int GetRemainingTimeToPay()
		{
			return _remainingTimeToPay;
		}

		public float GetMonthlyInstallment()
		{
			return _monthlyCharges;
		}

		private void OnEnable()
		{
			InterestChanged();
			PrestigeChanged(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel);
			LocalizationSettings.SelectedLocaleChanged += LangChanged;
			FinancialLoaningManager.OnInterestReset += InterestReset;
			FinancialLoaningManager.OnInterestChanged += InterestChanged;
			Prestige.PrestigeLevelChanged += PrestigeChanged;
			if (_contractIsActive)
			{
				StateList(_noLoan, !_contractIsActive);
				StateList(_loanTake, _contractIsActive);
			}
		}

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= LangChanged;
			FinancialLoaningManager.OnInterestReset -= InterestReset;
			FinancialLoaningManager.OnInterestChanged -= InterestChanged;
			Prestige.PrestigeLevelChanged -= PrestigeChanged;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<FinancialLoaningManager>.Instance != null)
			{
				MonoSingleton<FinancialLoaningManager>.Instance.RemoveLoanDestroyed(this);
			}
		}

		private void LangChanged(Locale locale)
		{
			_contractTitle.text = FinancialLoanSO.LoanName.GetLocalizedString();
			_prestigeLevelRequiredText.text = $"{_prestigeLevelKey.GetLocalizedString()} {_prestigeRequired} {_prestigeRequiredKey.GetLocalizedString()}";
			UpdateInterestContent();
			UpdateAmountByMonthContent();
			UpdateLoanDurationContent();
		}

		private void InterestReset()
		{
			if (!_contractIsActive)
			{
				_currentInterest = _baseInterest;
				UpdateInterestContent();
				UpdateAmountByMonthContent();
			}
		}

		private void InterestChanged()
		{
			_currentInterest = (1f + MonoSingleton<FinancialLoaningManager>.Instance.GetLoanInterestPendingQueue(this) / 100f) * _currentInterest;
			UpdateInterestContent();
			UpdateAmountByMonthContent();
		}

		private void PrestigeChanged(PrestigeLevelData prestigeLevelData)
		{
			if (!_contractUnlocked && prestigeLevelData.Level >= _prestigeRequired)
			{
				_lockCover.SetActive(value: false);
				_contractUnlocked = true;
			}
		}

		private void UpdateContractAmountContent()
		{
			_amountOfTheLoan.text = "$" + _contractAmount.ToString("N0", new CultureInfo("fr-FR"));
			_remainingMoney.text = "$" + _remainingAmount;
		}

		private void UpdateInterestContent()
		{
			_interestOfTheLoan.text = $"{GetCurrentInterestWithDifficulty()}% {_interestKey.GetLocalizedString().ToLower()}";
			_remainingMoney.text = "$" + _remainingAmount;
		}

		private void UpdateAmountByMonthContent()
		{
			int num = (int)((float)_contractAmount + (float)_contractAmount * (GetCurrentInterestWithDifficulty() / 100f));
			num /= _borrowingPeriod;
			_amountByMonth.text = $"${num} {_perKey.GetLocalizedString().ToLower()} {_monthKey.GetLocalizedString().ToLower()}";
			_amountByMonth2.text = $"${num} {_perKey.GetLocalizedString().ToLower()} {_monthKey.GetLocalizedString().ToLower()}";
			_remainingMoney.text = "$" + _remainingAmount;
			_timeDurationRemaining.text = $"{_timeDuration.GetLocalizedString()} {_remainingTimeToPay} {_monthKey.GetLocalizedString().ToLower()}";
		}

		private void UpdateLoanDurationContent()
		{
			_loanDuration.text = $"{_loanDurationKey.GetLocalizedString()} {_borrowingPeriod} {_monthKey.GetLocalizedString().ToLower()}";
			_timeDurationRemaining.text = $"{_timeDuration.GetLocalizedString()} {_remainingTimeToPay} {_monthKey.GetLocalizedString().ToLower()}";
		}

		private float GetCurrentInterestWithDifficulty()
		{
			return _currentInterest * Difficulty.GetMultiplicativeDifficulty(_interestMultiplierKey);
		}

		public void Setup(FinancialLoanSO financialLoanSO)
		{
			_lockCover.SetActive(value: true);
			FinancialLoanSO = financialLoanSO;
			_contractIsActive = false;
			_contractUnlocked = false;
			_contractAmount = FinancialLoanSO.LoanMoneyFromTo.x;
			_prestigeRequired = FinancialLoanSO.LoanPrestigeToUnlock;
			_bankLoanIncrementation = FinancialLoanSO.LoanIncrementation;
			_bankLoanMoneyFromTo = FinancialLoanSO.LoanMoneyFromTo;
			_borrowingPeriod = FinancialLoanSO.LoanBorrowingPeriod[0];
			_baseInterest = FinancialLoanSO.LoanInterestPercent;
			_currentInterest = _baseInterest;
			_border.color = _onDefaultBorderColor;
			_background.color = _onDefaultBackgroundColor;
			if ((bool)FinancialLoanSO.LoanSprite)
			{
				_loanSprite.sprite = FinancialLoanSO.LoanSprite;
			}
			UpdateContractAmountContent();
			UpdateInterestContent();
			UpdateAmountByMonthContent();
			UpdateLoanDurationContent();
			PrestigeChanged(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel);
			_contractTitle.text = FinancialLoanSO.LoanName.GetLocalizedString();
			_prestigeLevelRequiredText.text = $"{_prestigeLevelKey.GetLocalizedString()} {_prestigeRequired} {_prestigeRequiredKey.GetLocalizedString()}";
			Array.ForEach(_controllerButtonsContractAmount, delegate(GameObject item)
			{
				item.SetActive(value: true);
			});
			LocalizationSettings.SelectedLocaleChanged += LangChanged;
		}

		public void IncreaseContractAmount()
		{
			if (_contractAmount + _bankLoanIncrementation <= _bankLoanMoneyFromTo.y)
			{
				_contractAmount += _bankLoanIncrementation;
				UpdateContractAmountContent();
				UpdateAmountByMonthContent();
			}
		}

		public void DecreaseContractAmount()
		{
			if (_contractAmount - _bankLoanIncrementation >= _bankLoanMoneyFromTo.x)
			{
				_contractAmount -= _bankLoanIncrementation;
				UpdateContractAmountContent();
				UpdateAmountByMonthContent();
			}
		}

		public void SetTheBorrowingPeriod(int _newPeriod)
		{
			_borrowingPeriod = _newPeriod;
		}

		public void TakeOutTheLoan()
		{
			_contractIsActive = true;
			_border.color = _onTakeOutBorderColor;
			_background.color = _onTakeOutBackgroundColor;
			Array.ForEach(_controllerButtonsContractAmount, delegate(GameObject item)
			{
				item.SetActive(value: false);
			});
			_takeOutButton.SetActive(value: false);
			_refundButton.SetActive(value: true);
			_remainingAmount = (int)((float)_contractAmount + (float)_contractAmount * (_currentInterest / 100f));
			_remainingMoney.text = "$" + _remainingAmount;
			_monthlyCharges = _remainingAmount / _borrowingPeriod;
			_remainingTimeToPay = _borrowingPeriod;
			_timeDurationRemaining.text = $"{_timeDuration.GetLocalizedString()} {_remainingTimeToPay} {_monthKey.GetLocalizedString().ToLower()}";
			MonoSingleton<FinancialLoaningManager>.Instance.NewLoanContraction(this);
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, _contractAmount);
			StateList(_noLoan, onOff: false);
			StateList(_loanTake, onOff: true);
		}

		public void RefundTheLoan()
		{
			_contractIsActive = false;
			_border.color = _onDefaultBorderColor;
			_background.color = _onDefaultBackgroundColor;
			Array.ForEach(_controllerButtonsContractAmount, delegate(GameObject item)
			{
				item.SetActive(value: true);
			});
			_takeOutButton.SetActive(value: true);
			_refundButton.SetActive(value: false);
			float num = _monthlyCharges * _remainingTimeToPay;
			float num2 = num / 100f * GetCurrentInterestWithDifficulty() * (1f / (float)_borrowingPeriod);
			num = ((_remainingTimeToPay < 3) ? ((float)(_monthlyCharges * _remainingTimeToPay)) : (num - num2 * 3f));
			StateList(_noLoan, onOff: true);
			StateList(_loanTake, onOff: false);
			InterestReset();
			MonoSingleton<FinancialLoaningManager>.Instance.EndLoanContraction(this);
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, -(int)Math.Ceiling(num));
		}

		public void ItsTimeToPay()
		{
			_remainingAmount -= _monthlyCharges;
			_remainingTimeToPay--;
			_timeDurationRemaining.text = $"{_timeDuration.GetLocalizedString()} {_remainingTimeToPay} {_monthKey.GetLocalizedString().ToLower()}";
			_remainingMoney.text = "$" + _remainingAmount;
			if (_remainingTimeToPay <= 0)
			{
				MonoSingleton<FinancialLoaningManager>.Instance.EndLoanContraction(this);
				_contractIsActive = false;
				_currentInterest = _baseInterest;
				_border.color = _onDefaultBorderColor;
				_background.color = _onDefaultBackgroundColor;
				Array.ForEach(_controllerButtonsContractAmount, delegate(GameObject item)
				{
					item.SetActive(value: true);
				});
			}
		}

		private void StateList(List<GameObject> list, bool onOff)
		{
			foreach (GameObject item in list)
			{
				item.SetActive(onOff);
			}
		}

		public void LoadSavingData()
		{
			_contractTitle.text = FinancialLoanSO.LoanName.GetLocalizedString();
			_border.color = (_contractIsActive ? _onTakeOutBorderColor : _onDefaultBorderColor);
			_background.color = (_contractIsActive ? _onTakeOutBackgroundColor : _onDefaultBackgroundColor);
			UpdateInterestContent();
			UpdateAmountByMonthContent();
			UpdateLoanDurationContent();
			UpdateContractAmountContent();
			_takeOutButton.SetActive(!_contractIsActive);
			_refundButton.SetActive(_contractIsActive);
			_lockCover.SetActive(!_contractUnlocked);
			if (_contractIsActive)
			{
				MonoSingleton<FinancialLoaningManager>.Instance.ActiveContracts.Add(this);
				Array.ForEach(_controllerButtonsContractAmount, delegate(GameObject item)
				{
					item.SetActive(value: false);
				});
			}
			else
			{
				Array.ForEach(_controllerButtonsContractAmount, delegate(GameObject item)
				{
					item.SetActive(value: true);
				});
			}
		}
	}
}
