#define ENABLE_DEBUG_WARNINGS
using Data.UI.Controls;
using TMPro;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor.Toolbar
{
	public class GameplayTooltip : MonoBehaviour
	{
		[SerializeField]
		private GameplayTooltipEventSO _gameplayTooltipSO;

		[SerializeField]
		private TextMeshProUGUI _tooltipText;

		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		private void Awake()
		{
			_gameplayTooltipSO.ActiveStateChanged += ActiveStateChanged;
			_gameplayTooltipSO.LocalizationKeyChanged += LocalizationKeyChanged;
			base.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			_gameplayTooltipSO.ActiveStateChanged -= ActiveStateChanged;
			_gameplayTooltipSO.LocalizationKeyChanged -= LocalizationKeyChanged;
		}

		private void ActiveStateChanged(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void LocalizationKeyChanged(string localizationKey)
		{
			string localizedText = LocalizationUtility.GetLocalizedText(localizationKey);
			if (TryGetInputActionTexts(out var inputActionStrings))
			{
				TextMeshProUGUI tooltipText = _tooltipText;
				object[] args = inputActionStrings;
				tooltipText.SetText(string.Format(localizedText, args));
			}
			else
			{
				_tooltipText.SetText(localizedText);
			}
		}

		private bool TryGetInputActionTexts(out string[] inputActionStrings)
		{
			if (_gameplayTooltipSO.InputActions.IsNullOrEmpty())
			{
				inputActionStrings = null;
				return false;
			}
			inputActionStrings = new string[_gameplayTooltipSO.InputActions.Length];
			for (int i = 0; i < _gameplayTooltipSO.InputActions.Length; i++)
			{
				if (!_rebindInfo.TryGetBindingString(_gameplayTooltipSO.InputActions[i], out var bindingString, getLongVersion: true, ", "))
				{
					this.LogWarning("Failed to get bindingString?", "TryGetInputActionTexts", 59);
					inputActionStrings[i] = "_";
				}
				else
				{
					inputActionStrings[i] = bindingString;
				}
			}
			return true;
		}
	}
}
