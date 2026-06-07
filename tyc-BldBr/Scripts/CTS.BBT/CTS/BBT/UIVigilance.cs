using System.Collections;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS.BBT
{
	public class UIVigilance : CTSBehaviour
	{
		[Header("Settings")]
		[Space(10f)]
		[SerializeField]
		private Image _fill;

		[SerializeField]
		private float _timeToFill = 1f;

		[SerializeField]
		private Image _contentImage;

		[SerializeField]
		[Range(0f, 1f)]
		private float _level2Threshold = 0.3f;

		[SerializeField]
		private Sprite _level2Image;

		[SerializeField]
		[Range(0f, 1f)]
		private float _level3Threshold = 0.7f;

		[SerializeField]
		private Sprite _level3Image;

		[SerializeField]
		private Sprite _panicImage;

		[SerializeField]
		private Sprite _maeveProtectionImage;

		[SerializeField]
		private TMP_Text _vigilanceText;

		[SerializeField]
		private LocalizedString _title;

		[SerializeField]
		private LocalizedString _description;

		[SerializeField]
		private LocalizedString _days;

		private float _elapsedTime;

		private bool _panicActive;

		private ToolTipsShower _tooltips;

		private int CurrentVigilance => MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance;

		private float CurrentVigilanceUnitInterval => (float)CurrentVigilance / MaxVigilance;

		private float MaxVigilance => MonoSingleton<VigilanceHandlers>.Instance.GetMaxVigilanceWithDifficulty();

		protected override void OnAwake()
		{
			_tooltips = GetComponent<ToolTipsShower>();
		}

		protected override void OnEnabled()
		{
			VigilanceHandlers.VigilanceChanged += OnVigilanceChanged;
			PanicCounter.PanicActive += OnPanicActive;
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			VigilanceHandlers.OnMaeveProtectionChanged += VigilanceHandlers_OnMaeveProtectionChanged;
		}

		private void VigilanceHandlers_OnMaeveProtectionChanged(int obj)
		{
			SetImage();
			UpdateVigilanceValueTexts();
		}

		private void OnPanicActive(bool obj)
		{
			_panicActive = obj;
			SetImage();
		}

		private void SetImage()
		{
			if (MonoSingleton<VigilanceHandlers>.Instance.CurrentMaeveProtectionRestDays > 0)
			{
				_contentImage.overrideSprite = _maeveProtectionImage;
			}
			else if (_panicActive)
			{
				_contentImage.overrideSprite = _panicImage;
			}
			else if (CurrentVigilanceUnitInterval >= _level3Threshold)
			{
				_contentImage.overrideSprite = _level3Image;
			}
			else if (CurrentVigilanceUnitInterval >= _level2Threshold)
			{
				_contentImage.overrideSprite = _level2Image;
			}
			else
			{
				_contentImage.overrideSprite = null;
			}
		}

		private void Start()
		{
			_fill.fillAmount = CurrentVigilanceUnitInterval;
			UpdateVigilanceValueTexts();
		}

		protected override void OnDisabled()
		{
			VigilanceHandlers.VigilanceChanged -= OnVigilanceChanged;
			PanicCounter.PanicActive -= OnPanicActive;
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			VigilanceHandlers.OnMaeveProtectionChanged -= VigilanceHandlers_OnMaeveProtectionChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			UpdateVigilanceValueTexts();
		}

		private void UpdateVigilanceValueTexts()
		{
			UpdateTooltip();
			if (MonoSingleton<VigilanceHandlers>.Instance.CurrentMaeveProtectionRestDays <= 0)
			{
				_vigilanceText.text = CurrentVigilance.ToString();
			}
			else
			{
				_vigilanceText.text = MonoSingleton<VigilanceHandlers>.Instance.CurrentMaeveProtectionRestDays + " " + _days.GetLocalizedString();
			}
		}

		private void UpdateTooltip()
		{
			_tooltips?.SetTootipsInfo(_title, _description.GetLocalizedString() + "\n" + CurrentVigilance + " / " + MaxVigilance);
		}

		private void OnVigilanceChanged(int p_value)
		{
			if (p_value > 0)
			{
				StartCoroutine(Fill());
				SetImage();
			}
			else
			{
				_fill.fillAmount = 0f;
				UpdateVigilanceValueTexts();
			}
		}

		private IEnumerator Fill()
		{
			_elapsedTime = 0f;
			while (_elapsedTime < _timeToFill)
			{
				_fill.fillAmount = Mathf.Lerp(_fill.fillAmount, CurrentVigilanceUnitInterval, _elapsedTime / _timeToFill);
				_elapsedTime += Time.deltaTime;
				UpdateVigilanceValueTexts();
				yield return null;
			}
			_fill.fillAmount = CurrentVigilanceUnitInterval;
			UpdateVigilanceValueTexts();
			yield return null;
		}
	}
}
