using System;
using System.Collections.Generic;
using System.Globalization;
using I2.Loc;
using JetBrains.Annotations;
using TH20.ExtContent;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OptionsMenu : AnimatedMenuBase
	{
		[SerializeField]
		private DynamicButton _closeButton;

		[SerializeField]
		private Button _resumeButton;

		[SerializeField]
		private Button _quickSaveButton;

		[SerializeField]
		private Button _quickLoadButton;

		[SerializeField]
		private Button _restartCareerButton;

		[SerializeField]
		private Button _preferencesButton;

		[SerializeField]
		private Button _quitToMenuButton;

		[SerializeField]
		private Button _quitButton;

		[SerializeField]
		private Button _debugSaveButton;

		[SerializeField]
		private Button _debugLoadButton;

		[SerializeField]
		private Button _networkDebugViewButton;

		private App _app;

		private MetagameMap _metagameMap;

		private SaveSystem _saveSystem;

		private LevelList _levelList;

		private MessageBox _messageBox;

		private Action<string> _saveFunction;

		private Action<SaveFileHeader> _loadFunction;

		public void Setup(App app, MetagameMap metagameMap, SaveSystem saveSystem, Preferences userPreferences, MessageBox messageBox, Action<string> saveFunction, Action<SaveFileHeader> loadFunction, Action quickSaveFunction, Action quickLoadFunction)
		{
			_app = app;
			_metagameMap = metagameMap;
			_saveSystem = saveSystem;
			_levelList = _app.Metagame.LevelList;
			_messageBox = messageBox;
			_saveFunction = saveFunction;
			_loadFunction = loadFunction;
			GameObjectUtils.SetActive(_resumeButton.gameObject, isActive: false);
			_closeButton.onPrimaryDown.AddListener(CloseMenu);
			_quickSaveButton.onClick.AddListener(delegate
			{
				quickSaveFunction();
			});
			GameObjectUtils.SetInteractable(_quickLoadButton, saveSystem.MostRecentSave != null);
			_quickLoadButton.onClick.AddListener(delegate
			{
				app.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages.AreYouSureQuickLoad_Title_CS, AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuickLoad_CS, app.SaveSystem), ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, quickLoadFunction);
			});
			ButtonAnimator component = _quickLoadButton.GetComponent<ButtonAnimator>();
			if (component != null)
			{
				component.CurrentState = ((saveSystem.MostRecentSave == null) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			_debugSaveButton.onClick.AddListener(ShowDebugSaveScreen);
			_debugLoadButton.onClick.AddListener(ShowDebugLoadScreen);
			_restartCareerButton.onClick.AddListener(delegate
			{
				messageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages.AreYouSureRestart_Title_CS, ScriptLocalization.Menu_Messages.AreYouSureRestart_CS, ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
				{
					CloseMenuImmediately();
					app.GameMode.Restart();
				});
			});
			_preferencesButton.onClick.AddListener(ShowPreferencesScreen);
			_quitToMenuButton.onClick.AddListener(delegate
			{
				if (_app.GameMode.AllowGameToBeSaved())
				{
					messageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureQuitToMenu_Title_CS, AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuitToMenu_CS, _saveSystem), ScriptLocalization.Menu_Messages.QuitSave_Button_CS, ScriptLocalization.Menu_Messages.QuitDontSave_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
					{
						CloseMenuImmediately();
						app.QuitToMenu();
					}, delegate
					{
						CloseMenuImmediately();
						app.QuitToMenuDontSave();
					});
				}
				else
				{
					CloseMenuImmediately();
					app.QuitToMenuDontSave();
				}
			});
			_quitButton.onClick.AddListener(delegate
			{
				if (_app.GameMode.AllowGameToBeSaved())
				{
					messageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureQuit_Title_CS, AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuit_CS, _saveSystem), ScriptLocalization.Menu_Messages.QuitSave_Button_CS, ScriptLocalization.Menu_Messages.QuitDontSave_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
					{
						CloseMenuImmediately();
						app.QuitGame();
					}, delegate
					{
						CloseMenuImmediately();
						app.QuitGameDontSave();
					});
				}
				else
				{
					CloseMenuImmediately();
					app.QuitGameDontSave();
				}
			});
			_networkDebugViewButton.onClick.AddListener(ShowNetworkDebugger);
			_networkDebugViewButton.gameObject.SetActive(value: false);
			base.OnClosed = (Action)Delegate.Combine(base.OnClosed, new Action(OnOptionsMenuClosed));
			_metagameMap.HUD.HUDEvents.OnOptionsMenuOpen.InvokeSafe();
			_debugLoadButton.gameObject.SetActive(value: false);
			_debugSaveButton.gameObject.SetActive(value: false);
			if (_app.GameMode is GameModeSandbox)
			{
				GameObjectUtils.SetActive(_quickLoadButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_quickSaveButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_restartCareerButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_networkDebugViewButton.gameObject, isActive: false);
			}
		}

		public static string AddLastSaveInfoIfAppropriate(string baseTextTranslated, SaveSystem saveSystem)
		{
			SaveFileHeader mostRecentSave = saveSystem.MostRecentSave;
			DateTime date;
			if (mostRecentSave != null)
			{
				date = mostRecentSave.Date;
			}
			else
			{
				if (saveSystem.MostRecentMetagameSaveSlotIndex == -1)
				{
					return baseTextTranslated;
				}
				date = saveSystem.GetMetagameSaveHeaderForSlot(saveSystem.MostRecentMetagameSaveSlotIndex).Date;
			}
			return baseTextTranslated + "\n\n" + ApplyLocalisationParam(ScriptLocalization.Menu_Messages.TimeSinceLastSave_CS, "LAST_SAVE_DATE_TIME", date.ToString(CultureInfo.CurrentCulture));
		}

		public static string ApplyLocalisationParam(string translatedText, string paramName, object paramValue)
		{
			LocalizationManager.ApplyLocalizationParams(ref translatedText, new Dictionary<string, object> { { paramName, paramValue } });
			return translatedText;
		}

		public override void CloseMenu()
		{
			_closeButton.interactable = false;
			_resumeButton.interactable = false;
			_quickSaveButton.interactable = false;
			_quickLoadButton.interactable = false;
			_restartCareerButton.interactable = false;
			_preferencesButton.interactable = false;
			_quitToMenuButton.interactable = false;
			_quitButton.interactable = false;
			_debugSaveButton.interactable = false;
			_debugLoadButton.interactable = false;
			_networkDebugViewButton.interactable = false;
			base.CloseMenu();
		}

		protected void OnDestroy()
		{
			base.OnClosed = (Action)Delegate.Remove(base.OnClosed, new Action(OnOptionsMenuClosed));
		}

		protected void OnOptionsMenuClosed()
		{
			_metagameMap.HUD.HUDEvents.OnOptionsMenuClose.InvokeSafe();
		}

		private void ShowNetworkDebugger()
		{
			SetVisible(visible: false);
			ResearchNetworkDebugMenu researchNetworkDebugMenu = _metagameMap.HUD.CreateMenu<ResearchNetworkDebugMenu>();
			researchNetworkDebugMenu.Setup(_app);
			researchNetworkDebugMenu.OnClosed = (Action)Delegate.Combine(researchNetworkDebugMenu.OnClosed, new Action(OnSubMenuClosed));
		}

		private void ShowDebugSaveScreen()
		{
			SetVisible(visible: false);
			ChooseSaveScreen chooseSaveScreen = _metagameMap.HUD.CreateMenu<ChooseSaveScreen>();
			chooseSaveScreen.Setup(_saveSystem, _levelList, _messageBox, _saveFunction, _loadFunction);
			chooseSaveScreen.ShowAsSaveScreen();
			chooseSaveScreen.OnClosed = (Action)Delegate.Combine(chooseSaveScreen.OnClosed, new Action(OnSubMenuClosed));
		}

		private void ShowDebugLoadScreen()
		{
			SetVisible(visible: false);
			ChooseSaveScreen chooseSaveScreen = _metagameMap.HUD.CreateMenu<ChooseSaveScreen>();
			chooseSaveScreen.Setup(_saveSystem, _levelList, _messageBox, _saveFunction, _loadFunction);
			chooseSaveScreen.ShowAsLoadScreen();
			chooseSaveScreen.OnClosed = (Action)Delegate.Combine(chooseSaveScreen.OnClosed, new Action(OnSubMenuClosed));
		}

		private void OnSubMenuClosed()
		{
			SetVisible(visible: true);
		}

		private void ShowPreferencesScreen()
		{
			_app.PreferencesScreen.Show();
		}

		protected override void Update()
		{
			base.Update();
			ExtContentUtils.CheckShowGameItemDevInfoPanelInput();
		}
	}
}
