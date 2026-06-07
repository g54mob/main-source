using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class ExterminationPanel : MonoBehaviour
	{
		public enum EExterminetionType
		{
			DownVigilance = 0,
			Protection = 1
		}

		[SerializeField]
		private LocalizedString _engageTitle;

		[SerializeField]
		private LocalizedString _daysTitle;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _effectText;

		[SerializeField]
		private TMP_Text _costText;

		[SerializeField]
		private TMP_Text _engageText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private Image _picto;

		[SerializeField]
		private Toggle _button;

		[SerializeField]
		private ToolTipsShower _moneyTooltips;

		[SerializeField]
		private ExterminationDataSO _exterminationDataSO;

		[SerializeField]
		private float _alpha;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		private int _currentDaysBeforeReuse;

		public int CurrentEffectUsedCount { get; private set; }

		public int CurrentDaysBeforeReuse
		{
			get
			{
				return _currentDaysBeforeReuse;
			}
			private set
			{
				_currentDaysBeforeReuse = value;
				SetEngageButton();
			}
		}

		private void Start()
		{
			_moneyTooltips.enabled = false;
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			_button.onValueChanged.AddListener(OnClick);
			CalendarHandlers.NewDay += CalendarHandlers_NewDay;
			MoneyHandler.MoneyAmountChanged += MoneyHandler_MoneyAmountChanged;
			MaeveExtermination.DiscountChanged += WriteEffect;
			WriteEffect();
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			_button.onValueChanged.RemoveListener(OnClick);
			CalendarHandlers.NewDay -= CalendarHandlers_NewDay;
			MoneyHandler.MoneyAmountChanged -= MoneyHandler_MoneyAmountChanged;
			MaeveExtermination.DiscountChanged -= WriteEffect;
		}

		public void SetSaveData(int usedCount, int dayBefore, int restProtectionDays)
		{
			CurrentEffectUsedCount = usedCount;
			CurrentDaysBeforeReuse = dayBefore;
			SetEffectFromSave(restProtectionDays);
			LocalizationSettings_SelectedLocaleChanged(null);
		}

		private void OnClick(bool isOn)
		{
			if (isOn)
			{
				CurrentDaysBeforeReuse = _exterminationDataSO.DayBeforeReuse;
				MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(MonoSingleton<MoneyHandler>.Instance.CurrentMoney - _exterminationDataSO.GetPriceWithDifficulty(CurrentEffectUsedCount));
				MonoSingleton<MaeveExtermination>.Instance.SetDiscount(1f);
				CurrentEffectUsedCount++;
				ActiveEffect();
				SetEngageButton();
				_canvasGroup.alpha = _alpha;
			}
		}

		private void CalendarHandlers_NewDay()
		{
			if (CurrentDaysBeforeReuse > 0)
			{
				CurrentDaysBeforeReuse--;
			}
		}

		private void MoneyHandler_MoneyAmountChanged(int obj)
		{
			SetEngageButton();
		}

		public void Init(ExterminationDataSO data)
		{
			_exterminationDataSO = data;
			WriteEffect();
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			WriteEffect();
			SetEngageButton();
		}

		private void WriteEffect()
		{
			if (!(_exterminationDataSO == null))
			{
				_titleText.text = _exterminationDataSO.Title.GetLocalizedString();
				_effectText.text = _exterminationDataSO.Effect.GetLocalizedString(_exterminationDataSO.GetValueText());
				_descriptionText.text = _exterminationDataSO.Description.GetLocalizedString(_exterminationDataSO.GetValue());
				_costText.text = "$" + _exterminationDataSO.GetPriceWithDifficulty(CurrentEffectUsedCount);
				_picto.sprite = _exterminationDataSO.Picto;
			}
		}

		private void SetEngageButton()
		{
			_moneyTooltips.enabled = MonoSingleton<MoneyHandler>.Instance.CurrentMoney < _exterminationDataSO.GetPriceWithDifficulty(CurrentEffectUsedCount) && _currentDaysBeforeReuse == 0;
			_button.isOn = _currentDaysBeforeReuse > 0;
			_button.interactable = _currentDaysBeforeReuse == 0 && MonoSingleton<MoneyHandler>.Instance.CurrentMoney >= _exterminationDataSO.GetPriceWithDifficulty(CurrentEffectUsedCount);
			if (CurrentDaysBeforeReuse > 0)
			{
				_engageText.text = CurrentDaysBeforeReuse + " " + _daysTitle.GetLocalizedString();
			}
			else
			{
				_engageText.text = _engageTitle.GetLocalizedString();
				_canvasGroup.alpha = 1f;
			}
			_costText.text = "$" + _exterminationDataSO.GetPriceWithDifficulty(CurrentEffectUsedCount);
		}

		private void ActiveEffect()
		{
			switch (_exterminationDataSO.ExterminetionType)
			{
			case EExterminetionType.DownVigilance:
				Debug.Log(_exterminationDataSO.GetNewVigilance(MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance));
				MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(_exterminationDataSO.GetNewVigilance(MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance));
				break;
			case EExterminetionType.Protection:
				MonoSingleton<VigilanceHandlers>.Instance.SetMaeveProtectionDaysCount(_exterminationDataSO.GetValue(), _exterminationDataSO.ProtectionFactor, fromSave: false);
				break;
			}
		}

		private void SetEffectFromSave(int restProtectionDays)
		{
			if (_exterminationDataSO.ExterminetionType == EExterminetionType.Protection && restProtectionDays > 0)
			{
				MonoSingleton<VigilanceHandlers>.Instance.SetMaeveProtectionDaysCount(restProtectionDays, _exterminationDataSO.ProtectionFactor, fromSave: true);
			}
		}
	}
}
