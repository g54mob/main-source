using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dorfromantik
{
	[RequireComponent(typeof(MainMenuScreen))]
	public class CustomModeConfigScreen : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField configStringInput;

		private CustomRuleSlider[] customRuleSliders;

		[SerializeField]
		private NumberSystemConverter numberConverter;

		[SerializeField]
		private CustomModeConfiguration configuration;

		[SerializeField]
		private NetworkEventRouter networkEventRouter;

		[SerializeField]
		private CustomModeData customModeData;

		private string configStringWithSeparators;

		private List<string> configStringParts = new List<string>();

		private List<string> cleanedConfigStringParts = new List<string>();

		private MainMenuScreen mainMenuScreen;

		public event Action<CustomRuleType, int> OnRuleUpdated;

		private void Awake()
		{
			customRuleSliders = GetComponentsInChildren<CustomRuleSlider>();
			configStringInput.characterLimit = configuration.configStringLength + configuration.configStringLength / configuration.separatorIndex - 1;
			CustomRuleSlider[] array = customRuleSliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnValueChanged += UpdateRuleFromSlider;
			}
			mainMenuScreen = GetComponent<MainMenuScreen>();
			mainMenuScreen.OnShow += RandomizeSeedOnShow;
		}

		private void RandomizeSeedOnShow(bool show)
		{
			if (show)
			{
				if (PlayerPrefsAccessor.HasKey("LastCustomizedConfigString"))
				{
					configStringInput.text = PlayerPrefsAccessor.GetString("LastCustomizedConfigString");
				}
				else
				{
					ResetRules();
				}
				RandomizeSeed();
			}
		}

		public void RandomizeSeed()
		{
			customModeData.seed = Randomizer.GetRandomSeed();
			UpdateConfigString();
		}

		public void RandomizeRules()
		{
			CustomRuleSlider[] array = customRuleSliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Randomize();
			}
		}

		public void ResetRules()
		{
			CustomRuleSlider[] array = customRuleSliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
		}

		private void UpdateConfigString(bool updateInputFieldValue = true)
		{
			string text = "";
			configStringWithSeparators = "";
			configStringParts.Clear();
			configStringParts.Add(numberConverter.EncodeNumber(customModeData.seed, 6));
			foreach (int item in EncodeRulesAsInt())
			{
				configStringParts.Add(numberConverter.EncodeNumber(item, 6, alsoEncodeNegativeNumbers: false));
			}
			foreach (string configStringPart in configStringParts)
			{
				text += configStringPart;
			}
			for (int i = 0; i < text.Length; i++)
			{
				configStringWithSeparators += text[i];
				if ((i + 1) % configuration.separatorIndex == 0 && i < text.Length - 1)
				{
					configStringWithSeparators += "-";
				}
			}
			customModeData.configString = text;
			PlayerPrefsAccessor.SetString("LastCustomizedConfigString", customModeData.configString);
			if (updateInputFieldValue)
			{
				configStringInput.SetTextWithoutNotify(configStringWithSeparators);
			}
		}

		private List<int> EncodeRulesAsInt()
		{
			return customModeData.GetRuleIntegers();
		}

		public void StartEditInputField()
		{
			networkEventRouter.RequestOpenSystemKeyboard(LocalizationManager.Instance.GetLocalizedValue("customMode_seed", useFallbackText: true), 20, configStringInput.text, FinishedExternalKeyboardInput);
		}

		private void FinishedExternalKeyboardInput(string enteredText)
		{
			UpdateConfigString(updateInputFieldValue: false);
			mainMenuScreen.UpdateAndSelectDefaultSelectable();
		}

		public void SeedInputChanged(string seedInput)
		{
			int.TryParse(seedInput, out customModeData.seed);
			UpdateConfigString();
		}

		public void ConfigInputChanged(string inputFieldValue)
		{
			string text = inputFieldValue.Replace("-", "");
			while (text.Length < configuration.configStringLength)
			{
				text += "0";
			}
			if (text.Length > configuration.configStringLength)
			{
				text = text.Substring(0, configuration.configStringLength);
			}
			customModeData.seed = numberConverter.DecodeNumber(text.Substring(0, 6));
			numberConverter.DecodeNumber(text.Substring(6, 6), numberCanBeNegative: false);
			List<int> list = numberConverter.DecodeNumberAsDigits(text.Substring(6, 6));
			while (list.Count < 10)
			{
				list.Insert(0, 0);
			}
			UpdateRule(CustomRuleType.VillageProbability, list[1], updateConfigString: false);
			UpdateRule(CustomRuleType.ForestProbability, list[2], updateConfigString: false);
			UpdateRule(CustomRuleType.AgricultureProbability, list[3], updateConfigString: false);
			UpdateRule(CustomRuleType.WaterProbability, list[4], updateConfigString: false);
			UpdateRule(CustomRuleType.TrainTrackProbability, list[5], updateConfigString: false);
			UpdateRule(CustomRuleType.TileStackHeight, list[6], updateConfigString: false);
			UpdateRule(CustomRuleType.TileLimit, list[7], updateConfigString: false);
			UpdateRule(CustomRuleType.Density, list[8], updateConfigString: false);
			UpdateRule(CustomRuleType.QuestProbability, list[9], updateConfigString: false);
			List<int> list2 = numberConverter.DecodeNumberAsDigits(text.Substring(12, 6));
			while (list2.Count < 10)
			{
				list2.Insert(0, 0);
			}
			UpdateRule(CustomRuleType.QuestDifficulty, list2[1], updateConfigString: false);
			UpdateRule(CustomRuleType.FlagQuestProbability, list2[2], updateConfigString: false);
			UpdateRule(CustomRuleType.WorldBorderRadius, list2[3], updateConfigString: false);
			UpdateConfigString(updateInputFieldValue: false);
		}

		private void UpdateRuleFromSlider(CustomRuleType customRuleType, int newValue)
		{
			UpdateRule(customRuleType, newValue);
		}

		private void UpdateRule(CustomRuleType customRuleType, int newValue, bool updateConfigString = true)
		{
			if (newValue == 0)
			{
				newValue = configuration.GetDefaultLevel(customRuleType);
			}
			customModeData.SetCustomRuleValue(customRuleType, newValue);
			if (updateConfigString)
			{
				UpdateConfigString();
			}
			this.OnRuleUpdated?.Invoke(customRuleType, newValue);
		}

		public void CopyConfigStringToClipboard()
		{
			ClipboardUtility.CopyToClipboard(configStringInput.text);
		}

		public void PasteConfigStringToInputField()
		{
			configStringInput.text = ClipboardUtility.GetClipboardEntry();
			configStringInput.onEndEdit.Invoke(configStringInput.text);
		}

		public void StoreConfigStringInPlayerPrefs()
		{
			PlayerPrefsAccessor.SetString("CustomModeConfigString", customModeData.configString);
			PlayerPrefsAccessor.SetInt("CustomModeSeed", customModeData.seed);
		}
	}
}
