using System;
using System.Collections.Generic;
using Factory;
using Motorways.Themes;
using Motorways.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class ResumeMapButton : AnimatedCard
	{
		public LocalizedTextUI header;

		public LocalizedTextUI description;

		public TextMeshProUGUI date;

		public TextMeshProUGUI device;

		public TouchButton playTouchButton;

		private ResumeGameScreen _screen;

		private string _gameId;

		private MapDefinition _mapDefinition;

		public TouchButton deleteButton;

		public Image previewImage;

		protected List<ThemedComponent> _themedMapScreenComponents;

		private MotorwaysThemeDatabase _themeDatabase;

		private IScope _scope;

		[SerializeField]
		private LocalizedTextUI _modeNameText;

		[SerializeField]
		private ThemedComponent _modeNameTextThemedComponent;

		private VisualConstantsData _visualConstantsData;

		private ActivePlayer _player;

		private MotorwaysGameJournalSave _saveGame;

		public string GameID => _gameId;

		public void OnClicked()
		{
			_screen.SelectGame(this);
		}

		public void ScrollToMe()
		{
			_screen.ScrollToButton(this);
		}

		public void OnDelete()
		{
			_screen.DeleteGame(this);
		}

		public void Initialize(ResumeGameScreen screen, string savedGameId, MotorwaysGameJournalSave savedGame, MapDefinition cityDefinition, IScope scope)
		{
			_screen = screen;
			_gameId = savedGameId;
			_mapDefinition = cityDefinition;
			_scope = scope;
			_saveGame = savedGame;
			header.SetStringId(_scope, cityDefinition.mapName);
			StringId result = StringId.None;
			switch (savedGame.ChallengeType)
			{
			case MapChallenge.ChallengeType.Daily:
				result = StringId.DailyChallenge;
				break;
			case MapChallenge.ChallengeType.Weekly:
				result = StringId.WeeklyChallenge;
				break;
			case MapChallenge.ChallengeType.Mystery:
				result = StringId.MysteryUpgradeName;
				break;
			case MapChallenge.ChallengeType.City:
				if (Diagnostics.Verify(savedGame.ChallengeIndex >= 0, "Somehow marked this save as a City challenge but doesn't have a challenge index?"))
				{
					Diagnostics.Verify(Enum.TryParse<StringId>(cityDefinition.cityChallenges[savedGame.ChallengeIndex].titleStringId, out result));
				}
				break;
			}
			if (result != StringId.None)
			{
				description.SetStringId(_scope, result);
			}
			else
			{
				description.TextField.text = "";
			}
			_player = _scope.Get<ActivePlayer>();
			Locale currentLocale = _scope.Get<LocaleDatabase>().CurrentLocale;
			date.text = currentLocale.FormatDateTime(savedGame.UtcTimestamp.ToLocalTime(), formatForLocString: false);
			FontDatabase fontDatabase = _scope.Get<FontDatabase>();
			date.font = fontDatabase.GetFont(currentLocale.Charset).FontAsset;
			device.text = DeviceStringLookup.GetDeviceDisplayStringFromModel(savedGame.DeviceModel);
			_themeDatabase = _scope.Get<MotorwaysThemeDatabase>();
			_visualConstantsData = _scope.Get<VisualConstantsData>();
			_themedMapScreenComponents = new List<ThemedComponent>();
			GetComponentsInChildren(includeInactive: true, _themedMapScreenComponents);
			previewImage.sprite = _mapDefinition.themePreviewSprites[(int)_themeDatabase.ThemePreference];
			deleteButton.gameObject.SetActive(savedGame.CanDelete);
		}

		public void ApplyTheme()
		{
			foreach (ThemedComponent themedMapScreenComponent in _themedMapScreenComponents)
			{
				themedMapScreenComponent.ApplyTheme(_mapDefinition.themes[(int)_themeDatabase.ThemePreference]);
			}
			previewImage.sprite = _mapDefinition.themePreviewSprites[(int)_themeDatabase.ThemePreference];
			UpdateModeStrings();
		}

		private void UpdateModeStrings()
		{
			if (_saveGame.ChallengeType == MapChallenge.ChallengeType.None)
			{
				MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
				GameMode mode = _saveGame.Mode;
				_modeNameText.gameObject.SetActive(value: true);
				switch (mode)
				{
				case GameMode.Normal:
					motorwaysStringKey.InitWithStringId(StringId.Normal);
					_modeNameTextThemedComponent.ApplyTheme(_themeDatabase.GetTheme());
					break;
				case GameMode.Endless:
					motorwaysStringKey.InitWithStringId(StringId.Endless);
					_modeNameTextThemedComponent.enabled = false;
					_modeNameText.TextField.color = _visualConstantsData.EndlessTabButtonColor;
					break;
				case GameMode.Expert:
					motorwaysStringKey.InitWithStringId(StringId.Expert);
					_modeNameTextThemedComponent.enabled = false;
					_modeNameText.TextField.color = _visualConstantsData.ExpertTabButtonColor;
					break;
				case GameMode.Creative:
					motorwaysStringKey.InitWithStringId(StringId.Creative);
					_modeNameTextThemedComponent.enabled = false;
					_modeNameText.TextField.color = _visualConstantsData.CreativeTabButtonColor;
					break;
				}
				_modeNameText.LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
			}
			else
			{
				_modeNameText.gameObject.SetActive(value: false);
			}
		}
	}
}
