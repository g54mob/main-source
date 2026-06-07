#define ENABLE_DEBUG_LOGS
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI
{
	public class PlaytestDisclaimerUI : DisclaimerUI
	{
		[SerializeField]
		private GameObject _errorMessage;

		[SerializeField]
		private Toggle _toggle1;

		[SerializeField]
		private Toggle _toggle2;

		protected override void Awake()
		{
			_errorMessage.SetActive(value: false);
			base.Awake();
		}

		private void OnEnable()
		{
			_errorMessage.SetActive(value: false);
		}

		protected override void OnContinueButtonClicked()
		{
			this.Log("", "OnContinueButtonClicked", 27);
			if (_toggle1.isOn && _toggle2.isOn)
			{
				_errorMessage.SetActive(value: false);
				PlayerPrefs.SetInt("Disclaimer202502", 1);
				base.OnContinueButtonClicked();
			}
			else
			{
				_errorMessage.SetActive(value: true);
			}
		}
	}
}
