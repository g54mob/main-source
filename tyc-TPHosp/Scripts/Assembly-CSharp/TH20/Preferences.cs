#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.IO;
using I2.Loc;
using Rewired;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class Preferences
	{
		public class ControlPreferences
		{
			public bool MouseDirectionItemRotation;

			public float MouseRotateSensitivity = 4f;

			public bool UseRoomItemSnap = true;

			public bool UseWallMagnetism;

			public bool EnableEdgeScrolling = true;

			public string RewiredKeyboardMapXML;

			public void LocaliseMappings(ControlBindingsLocalisationParamsManager controlBindingsLocalisationParamsManager)
			{
				if (controlBindingsLocalisationParamsManager == null)
				{
					return;
				}
				Logging.Info(LogChannels.Preferences, "Localising control mapping based on keyboard layout");
				if (ReInput.players == null)
				{
					Logging.Error(LogChannels.Preferences, "ReInput.players is null, exiting LocaliseMappings()");
					return;
				}
				Player player = ReInput.players.GetPlayer(0);
				KeyboardLayout.LayoutFamily currentLayoutFamily = KeyboardLayout.GetCurrentLayoutFamily();
				Logging.Info(LogChannels.Preferences, "Detected keyboard layout family: {0}", currentLayoutFamily);
				IList<ControllerMap> maps = player.controllers.maps.GetMaps(ControllerType.Keyboard, 0);
				ControllerMap controllerMap = ((maps.Count > 0) ? maps[0] : null);
				if (controllerMap != null)
				{
					ActionElementMap[] elementMaps = controllerMap.GetElementMaps();
					Logging.Info(LogChannels.Preferences, "Checking for remapping of {0} keys", elementMaps.Length);
					ActionElementMap[] array = elementMaps;
					foreach (ActionElementMap actionElementMap in array)
					{
						KeyCode keyCode = actionElementMap.keyCode;
						KeyCode keyCode2 = KeyboardLayout.MapKeyCode(keyCode, currentLayoutFamily);
						if (keyCode != keyCode2)
						{
							Logging.Info(LogChannels.Preferences, "Remapping {0} to {1} (for action {2} ({3}))", keyCode, keyCode2, actionElementMap.actionId, actionElementMap.actionDescriptiveName);
							ElementAssignment elementAssignment = new ElementAssignment(ControllerType.Keyboard, ControllerElementType.Button, actionElementMap.elementIdentifierId, AxisRange.Full, keyCode2, ModifierKeyFlags.None, actionElementMap.actionId, Pole.Positive, invert: false, actionElementMap.id);
							if (!controllerMap.ReplaceOrCreateElementMap(elementAssignment))
							{
								Logging.Warning(LogChannels.Preferences, "Failed to replace or create ActionElementMap whilst remapping default keys based on keyboard layout");
							}
						}
					}
				}
				UpdateBindingLocalisation(controlBindingsLocalisationParamsManager);
			}

			public void Apply(ControlBindingsLocalisationParamsManager controlBindingsLocalisationParamsManager)
			{
				if (controlBindingsLocalisationParamsManager == null)
				{
					return;
				}
				Logging.Info(LogChannels.Preferences, "Applying control preferences");
				UseWallMagnetism = false;
				if (RewiredKeyboardMapXML != null)
				{
					Logging.Info(LogChannels.Preferences, "Loading ReWired XML");
					Player player = ReInput.players.GetPlayer(0);
					player.controllers.maps.ClearMapsForController(ControllerType.Keyboard, 0, userAssignableOnly: true);
					if (!player.controllers.maps.AddMapFromXml<KeyboardMap>(0, RewiredKeyboardMapXML))
					{
						Logging.Warning(LogChannels.Preferences, "Failed to load keyboard mapping from XML stored in preferences");
					}
					UpdateBindingLocalisation(controlBindingsLocalisationParamsManager);
				}
				else
				{
					LocaliseMappings(controlBindingsLocalisationParamsManager);
				}
			}

			public void UpdateBindingLocalisation(ControlBindingsLocalisationParamsManager controlBindingsLocalisationParamsManager)
			{
				controlBindingsLocalisationParamsManager?.UpdateMapping();
			}
		}

		public class LanguagePreferences
		{
			public enum Language
			{
				English = 0,
				French = 1,
				Italian = 2,
				German = 3,
				Spanish = 4,
				Polish = 5,
				Russian = 6,
				SimplifiedChinese = 7,
				TraditionalChinese = 8,
				BrazilianPortuguese = 9,
				Korean = 10,
				Count = 11
			}

			public enum AudioLanguage
			{
				English = 0,
				German = 1,
				Mandarin = 2,
				Count = 3
			}

			public static readonly string[] LanguageCode = new string[11]
			{
				"en", "fr", "it", "de", "es", "pl", "ru", "zh-CN", "zh-TW", "pt-BR",
				"ko"
			};

			public static readonly string[] AudioLanguageCode = new string[3] { "en", "de", "zh-cmn" };

			private Language _selectedLanguage;

			private AudioLanguage _selectedAudioLanguage;

			public Language DefaultLanguage;

			public Action<AudioLanguage> OnAudioLanguageChanged;

			public Language SelectedLanguage
			{
				get
				{
					return _selectedLanguage;
				}
				set
				{
					_selectedLanguage = value;
					SelectedAudioLanguage = AudioLanguageFromLanguage(_selectedLanguage);
					Apply();
				}
			}

			public AudioLanguage SelectedAudioLanguage
			{
				get
				{
					return _selectedAudioLanguage;
				}
				set
				{
					_selectedAudioLanguage = value;
					OnAudioLanguageChanged.InvokeSafe(value);
				}
			}

			public static string GetLanguageCode(Language language)
			{
				return LanguageCode[(int)language];
			}

			public static Language LanguageFromSteamAPILanguageCode(string steamAPILanguageCode)
			{
				return steamAPILanguageCode switch
				{
					"french" => Language.French, 
					"italian" => Language.Italian, 
					"german" => Language.German, 
					"spanish" => Language.Spanish, 
					"polish" => Language.Polish, 
					"russian" => Language.Russian, 
					"schinese" => Language.SimplifiedChinese, 
					"tchinese" => Language.TraditionalChinese, 
					"brazilian" => Language.BrazilianPortuguese, 
					"koreana" => Language.Korean, 
					_ => Language.English, 
				};
			}

			public static AudioLanguage AudioLanguageFromLanguage(Language language)
			{
				switch (language)
				{
				case Language.German:
					return AudioLanguage.German;
				case Language.SimplifiedChinese:
				case Language.TraditionalChinese:
					return AudioLanguage.Mandarin;
				default:
					return AudioLanguage.English;
				}
			}

			public void Apply()
			{
				Logging.Info(LogChannels.Preferences, "Applying Language preferences");
				LocalizationManager.CurrentLanguageCode = LanguageCode[(int)_selectedLanguage];
			}
		}

		public class GamePreferences
		{
			public enum LevelAutoSaveFrequencyOption
			{
				EveryMonth = 0,
				Every3Months = 1,
				Every6Months = 2,
				EveryYear = 3,
				Disabled = 4,
				Count = 5
			}

			public enum CareerAutoSaveFrequencyOption
			{
				EveryChange = 0,
				MostChanges = 1,
				ImportantChangesOnly = 2,
				Disabled = 3,
				Count = 4
			}

			public enum AdvisorFilterOption
			{
				ShowAll = 0,
				ExcludeLowPriority = 1,
				ShowOnlyHighPriorityAndAbove = 2,
				ShowOnlyVeryHighPriority = 3,
				HideAll = 4,
				Count = 5
			}

			private LevelAutoSaveFrequencyOption _levelAutoSaveFrequency = LevelAutoSaveFrequencyOption.Every3Months;

			private CareerAutoSaveFrequencyOption _careerAutoSaveFrequency = CareerAutoSaveFrequencyOption.MostChanges;

			public static readonly int[] NumberOfRollingSavesOptions = new int[6] { 0, 1, 3, 5, 10, 20 };

			private int _numberOfRollingSavesToKeepIndex = 3;

			private bool _autoSaveOnLevelChange = true;

			private bool _onlineVisibility = true;

			private AdvisorFilterOption _advisorFilterOption;

			private LogLevel _logLevel = Logging.Logger.MinimumLogLevel;

			public Action<bool> OnOnlineVisiblityChanged;

			public LevelAutoSaveFrequencyOption LevelAutoSaveFrequency
			{
				get
				{
					return _levelAutoSaveFrequency;
				}
				set
				{
					_levelAutoSaveFrequency = value;
				}
			}

			public CareerAutoSaveFrequencyOption CareerAutoSaveFrequency
			{
				get
				{
					return _careerAutoSaveFrequency;
				}
				set
				{
					_careerAutoSaveFrequency = value;
				}
			}

			public int NumberOfRollingSavesToKeep => NumberOfRollingSavesOptions[_numberOfRollingSavesToKeepIndex];

			public int NumberOfRollingSavesToKeepIndex
			{
				get
				{
					return _numberOfRollingSavesToKeepIndex;
				}
				set
				{
					_numberOfRollingSavesToKeepIndex = value;
				}
			}

			public bool AutoSaveOnLevelChange
			{
				get
				{
					return _autoSaveOnLevelChange;
				}
				set
				{
					_autoSaveOnLevelChange = value;
				}
			}

			public bool OnlineVisibility
			{
				get
				{
					return _onlineVisibility;
				}
				set
				{
					_onlineVisibility = value;
					OnOnlineVisiblityChanged.InvokeSafe(value);
				}
			}

			public AdvisorFilterOption AdvisorFilter
			{
				get
				{
					return _advisorFilterOption;
				}
				set
				{
					_advisorFilterOption = value;
				}
			}

			public LogLevel LogLevel
			{
				get
				{
					LogLevel result = _logLevel;
					if (_logLevel < LogLevelHelpers.LowestLogLevelCompiledIn)
					{
						result = LogLevelHelpers.LowestLogLevelCompiledIn;
					}
					else if (_logLevel >= LogLevel.Count)
					{
						result = LogLevel.AlwaysLog;
					}
					return result;
				}
				set
				{
					if (_logLevel < LogLevelHelpers.LowestLogLevelCompiledIn)
					{
						Logging.Logger.MinimumLogLevel = LogLevelHelpers.LowestLogLevelCompiledIn;
					}
					else if (_logLevel >= LogLevel.Count)
					{
						_logLevel = LogLevel.AlwaysLog;
					}
					else
					{
						_logLevel = value;
					}
					Logging.Logger.MinimumLogLevel = _logLevel;
				}
			}

			public void Apply()
			{
				Logging.Info(LogChannels.Preferences, "Applying Game preferences");
				Logging.Logger.MinimumLogLevel = LogLevel;
			}
		}

		private ControlPreferences _controlPreferences = new ControlPreferences();

		private GamePreferences _gamePreferences = new GamePreferences();

		private LanguagePreferences _languagePreferences = new LanguagePreferences();

		public ControlPreferences Control => _controlPreferences;

		public GamePreferences Game => _gamePreferences;

		public static string PreferencesFilePath => Path.Combine(PlatformFileManager.CloudDirectory, "preferences.json");

		public LanguagePreferences Language => _languagePreferences;

		public static Preferences LoadOrCreateNew(LanguagePreferences.Language? defaultLanguage, ControlBindingsLocalisationParamsManager controlBindingsLocalisationParamsManager)
		{
			Preferences preferences = PreferencesUtils.LoadPreferencesFromFile<Preferences>(PreferencesFilePath);
			if (preferences != null)
			{
				string validityCheckMessages = "";
				if (ValidatePreferences(preferences, ref validityCheckMessages, defaultLanguage))
				{
					Logging.Warning(LogChannels.Preferences, "Preferences loaded successfully but had to be fixed during validation. Messages: {0}", validityCheckMessages);
				}
				preferences.Language.Apply();
				preferences.Control.Apply(controlBindingsLocalisationParamsManager);
				preferences.Game.Apply();
			}
			else
			{
				Logging.Info(LogChannels.Preferences, "Created new Preferences");
				preferences = new Preferences();
				if (defaultLanguage.HasValue)
				{
					preferences.Language.SelectedLanguage = defaultLanguage.Value;
					preferences.Language.DefaultLanguage = defaultLanguage.Value;
				}
				preferences.Control.Apply(controlBindingsLocalisationParamsManager);
				preferences.Game.Apply();
				if (PlatformFileManager.IsAvailable)
				{
					preferences.SaveToFile();
				}
			}
			return preferences;
		}

		private static bool ValidateFloatRange(ref float value, float min, float max, string propertyName, ref string validityCheckMessages)
		{
			if (value < min || value > max)
			{
				validityCheckMessages += $"{propertyName} \"{value}\" not in range [{min},{max}]; clamping. ";
				value = Mathf.Clamp(value, min, max);
				return true;
			}
			return false;
		}

		private static bool ValidatePreferences(Preferences preferences, ref string validityCheckMessages, LanguagePreferences.Language? defaultLanguage)
		{
			bool result = false;
			if (preferences.Control == null)
			{
				validityCheckMessages += "Control preferences missing; using default. ";
				preferences._controlPreferences = new ControlPreferences();
			}
			if (preferences.Game == null)
			{
				validityCheckMessages += "Game preferences missing; using default. ";
				preferences._gamePreferences = new GamePreferences();
			}
			if (preferences.Language == null)
			{
				validityCheckMessages += "Language preferences missing; using default. ";
				preferences._languagePreferences = new LanguagePreferences();
				if (defaultLanguage.HasValue)
				{
					preferences.Language.SelectedLanguage = defaultLanguage.Value;
					preferences.Language.DefaultLanguage = defaultLanguage.Value;
				}
			}
			else if (defaultLanguage.HasValue && defaultLanguage.Value != preferences.Language.DefaultLanguage)
			{
				Logging.Info(LogChannels.Preferences, "Default language has changed between game runs; resetting user-chosen language to default language, as that is probably their intent. Old default: {0}, New default: {1}, Old user language: {2}", preferences.Language.DefaultLanguage, defaultLanguage.Value, preferences.Language.SelectedLanguage);
				preferences.Language.SelectedLanguage = defaultLanguage.Value;
				preferences.Language.DefaultLanguage = defaultLanguage.Value;
			}
			return result;
		}

		public void SaveToFile()
		{
			PreferencesUtils.SavePreferencesToFile(PreferencesFilePath, this);
		}
	}
}
