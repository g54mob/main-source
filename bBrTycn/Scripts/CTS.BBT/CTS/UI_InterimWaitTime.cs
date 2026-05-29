using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class UI_InterimWaitTime : CTSBehaviour
	{
		[SerializeField]
		private TMP_Text _waitText;

		[SerializeField]
		private Image _fillImage;

		[SerializeField]
		private LocalizedString _day;

		private void Start()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			InterimAgency.OnAgencyEnter += InterimAgency_OnAgencyEnter;
			InterimAgency.OnAgencyQuit += InterimAgency_OnAgencyQuit;
			base.gameObject.SetActive(value: false);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			InterimAgency.RefreshChanged += OnRefreshChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			InterimAgency.RefreshChanged -= OnRefreshChanged;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			InterimAgency.OnAgencyEnter -= InterimAgency_OnAgencyEnter;
			InterimAgency.OnAgencyQuit -= InterimAgency_OnAgencyQuit;
		}

		private void OnRefreshChanged()
		{
			RefreshVisual();
		}

		private void InterimAgency_OnAgencyQuit()
		{
			base.gameObject.SetActive(value: false);
		}

		private void InterimAgency_OnAgencyEnter()
		{
			base.gameObject.SetActive(value: true);
			RefreshVisual();
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			RefreshVisual();
		}

		private void RefreshVisual()
		{
			_fillImage.fillAmount = GetUnitProgression();
			_waitText.text = GetDayCount() + " " + _day.GetLocalizedStringSafe();
		}

		private float GetUnitProgression()
		{
			if (!MonoSingleton<InterimAgency>.InstanceExists())
			{
				return 1f;
			}
			return 1f - (float)MonoSingleton<InterimAgency>.Instance.NextRefresh / (float)MonoSingleton<InterimAgency>.Instance.RefreshCooldown;
		}

		private int GetDayCount()
		{
			if (!MonoSingleton<InterimAgency>.InstanceExists())
			{
				return 1;
			}
			return MonoSingleton<InterimAgency>.Instance.NextRefresh;
		}
	}
}
