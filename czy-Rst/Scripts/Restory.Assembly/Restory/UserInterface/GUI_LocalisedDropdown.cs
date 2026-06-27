using System.Collections.Generic;
using Restory.Data.Localization;
using Restory.Gameplay.GameSettings.Observers;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_LocalisedDropdown : SerializedMonoBehaviour
	{
		[SerializeField]
		private TMP_Dropdown targetDropdown;

		[SerializeField]
		private List<string> optionsLocalisationIDs = new List<string>();

		[SerializeField]
		private bool forceUppercase;

		[OdinSerialize]
		private Dictionary<string, string> formatSubstrings = new Dictionary<string, string>();

		private LocalizationSystem localizationSystem;

		private GameSettingsLanguageChangeObserver gameSettingsManager;

		public int Value
		{
			get
			{
				return targetDropdown.value;
			}
			set
			{
				targetDropdown.value = value;
			}
		}

		public List<string> OptionsLocalisationIDs
		{
			get
			{
				return optionsLocalisationIDs;
			}
			set
			{
				optionsLocalisationIDs = value;
				UpdateDropdown();
			}
		}

		public TMP_Dropdown TargetDropdown => targetDropdown;

		private void Awake()
		{
			if (targetDropdown == null)
			{
				TryGetComponent<TMP_Dropdown>(out targetDropdown);
			}
			if (formatSubstrings == null)
			{
				formatSubstrings = new Dictionary<string, string>();
			}
		}

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, GameSettingsLanguageChangeObserver gameSettingsManager)
		{
			this.localizationSystem = localizationSystem;
			this.gameSettingsManager = gameSettingsManager;
			if (base.isActiveAndEnabled)
			{
				gameSettingsManager.RemoveSubscriber(this);
				gameSettingsManager.AddSubscriber(this, OnLocalisationChanged);
				UpdateDropdown();
			}
		}

		private void OnEnable()
		{
			gameSettingsManager?.AddSubscriber(this, OnLocalisationChanged);
			UpdateDropdown();
		}

		private void OnDisable()
		{
			gameSettingsManager?.RemoveSubscriber(this);
		}

		public void SetValueWithoutNotify(int input)
		{
			targetDropdown.SetValueWithoutNotify(input);
		}

		public void SetFormattedValue(string key, string newValue)
		{
			formatSubstrings[key] = newValue;
			UpdateDropdown();
		}

		public void AddOptions(List<string> options)
		{
			for (int i = 0; i < options.Count; i++)
			{
				optionsLocalisationIDs.Add(options[i]);
			}
			UpdateDropdown();
		}

		public void ClearOptions()
		{
			optionsLocalisationIDs.Clear();
			UpdateDropdown();
		}

		private void UpdateDropdown()
		{
			if (localizationSystem == null)
			{
				return;
			}
			for (int i = 0; i < optionsLocalisationIDs.Count; i++)
			{
				string text = localizationSystem.GetTranslation(optionsLocalisationIDs[i]);
				if (forceUppercase)
				{
					text = text.ToUpper();
				}
				text = FormatString(text);
				if (i < targetDropdown.options.Count)
				{
					targetDropdown.options[i].text = text;
				}
				else
				{
					targetDropdown.options.Add(new TMP_Dropdown.OptionData(text));
				}
			}
			if (targetDropdown.options.Count > optionsLocalisationIDs.Count)
			{
				targetDropdown.options.RemoveRange(optionsLocalisationIDs.Count, targetDropdown.options.Count - optionsLocalisationIDs.Count);
			}
			targetDropdown.RefreshShownValue();
		}

		private string FormatString(string targetString)
		{
			if (string.IsNullOrEmpty(targetString))
			{
				return string.Empty;
			}
			foreach (KeyValuePair<string, string> formatSubstring in formatSubstrings)
			{
				string key = formatSubstring.Key;
				string value = formatSubstring.Value;
				targetString = targetString.Replace(key, value);
			}
			return targetString;
		}

		private void OnLocalisationChanged(SystemLanguage newLanguage)
		{
			UpdateDropdown();
		}
	}
}
