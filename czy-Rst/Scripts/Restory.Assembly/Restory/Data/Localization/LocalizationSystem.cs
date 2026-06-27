using System.Collections.Generic;
using Restory.Data.GameConfigs;
using Restory.Data.Localization.Modifiers;
using Restory.Data.ReadWriteServices;
using Restory.Data.SaveLoad.FullSerializerWrappers;
using Restory.Gameplay.GameSettings;
using UnityEngine;
using Zenject;

namespace Restory.Data.Localization
{
	public class LocalizationSystem : MonoBehaviour, IInitializable
	{
		private const string LocalizationLabel = "<color=#00FF00><b>[LOCALIZATION]</b></color>";

		[SerializeField]
		private TextAsset localizationAsset;

		private LocalizationDataBase localizationDataBase;

		private GameSettingsManager gameSettingsManager;

		private GameConfig gameConfig;

		private CommonFullSerializer.Factory fsFactory;

		[Inject]
		private void Construct(GameSettingsManager gameSettingsManager, GameConfig gameConfig, CommonFullSerializer.Factory fsFactory)
		{
			this.gameSettingsManager = gameSettingsManager;
			this.gameConfig = gameConfig;
			this.fsFactory = fsFactory;
		}

		private void OnDestroy()
		{
			SaveMissingTranslation();
		}

		public void Initialize()
		{
			localizationDataBase = new LocalizationDataBase();
			string text = localizationAsset.text;
			Dictionary<string, Dictionary<string, string>> dictionary = fsFactory.Create().FromJson<Dictionary<string, Dictionary<string, string>>>(text, FileType.Localization);
			localizationDataBase.Initialize(dictionary, gameConfig.SupportedLocalizations);
			Debug.Log("<color=#00FF00><b>[LOCALIZATION]</b></color> load localization data is done");
		}

		public string GetTranslation(string stringID)
		{
			return GetAnyTranslation(stringID);
		}

		public bool TryGetTranslation(string stringID, out string translatedValue)
		{
			translatedValue = GetAnyTranslation(stringID);
			return !string.IsNullOrEmpty(translatedValue);
		}

		private string GetAnyTranslation(string stringID)
		{
			if (string.IsNullOrEmpty(stringID))
			{
				Debug.LogWarning("<color=#00FF00><b>[LOCALIZATION]</b></color> stringID can't be null or empty.");
				return string.Empty;
			}
			if (gameSettingsManager == null || localizationDataBase == null)
			{
				return string.Empty;
			}
			if (!localizationDataBase.LanguageIds.TryGetValue(gameSettingsManager.Localization, out var value))
			{
				return string.Empty;
			}
			string translation = GetTranslation(stringID, value);
			if (string.IsNullOrEmpty(translation))
			{
				string targetLanguage = localizationDataBase.LanguageIds[SystemLanguage.English];
				translation = GetTranslation(stringID, targetLanguage);
				AddMissingTranslation(stringID);
			}
			if (string.IsNullOrEmpty(translation))
			{
				translation = GetTranslation(stringID, "EnglishDraft");
			}
			return translation;
		}

		public string GetTranslation(string localizationID, string targetLanguage)
		{
			return localizationDataBase.GetTranslation(localizationID, targetLanguage);
		}

		private void AddMissingTranslation(string localizationID)
		{
			MissingLocalizationStatistic.Add(localizationID);
		}

		private void SaveMissingTranslation()
		{
			MissingLocalizationStatistic.Save();
		}

		public void AddModifier(LocalizationModifierBase newModifier)
		{
			localizationDataBase.AddModifier(newModifier);
		}

		public void RemoveModifier(LocalizationModifierBase oldModifier)
		{
			localizationDataBase.RemoveModifier(oldModifier);
		}
	}
}
