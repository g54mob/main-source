using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PauseMenu : MenuBase, IPauseTimeMenu
	{
		[SerializeField]
		private Button _resumeButton;

		[SerializeField]
		private Button _quickSaveButton;

		[SerializeField]
		private Button _quickLoadButton;

		[SerializeField]
		private Button _preferencesButton;

		[SerializeField]
		private Button _restartLevelButton;

		[SerializeField]
		private Button _quitToMapButton;

		[SerializeField]
		private Button _quitToMenuButton;

		[SerializeField]
		private Button _quitToDesktopButton;

		[SerializeField]
		private Button _debugSaveButton;

		[SerializeField]
		private Button _debugLoadButton;

		public void Setup(App app, GameTime gameTime, Level level)
		{
			ObjectValidationUtils.ValidateAndAssertFailures(this);
			_resumeButton.onClick.AddListener(delegate
			{
				level.HospitalHUDManager.TogglePauseMenu();
			});
			_quickSaveButton.onClick.AddListener(app.QuickSaveDeferred);
			_quickLoadButton.onClick.AddListener(delegate
			{
				app.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages.AreYouSureQuickLoad_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuickLoad_CS, app.SaveSystem), ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, app.QuickLoad);
			});
			_restartLevelButton.onClick.AddListener(delegate
			{
				NotificationGenericDecision message = new NotificationGenericDecision(level.Notifications.MessageDefinitions._restartLevelMessage, delegate(int response)
				{
					if (response == 0)
					{
						app.Metagame.GetHospitalRecord(level.Config)?.Replay();
						app.FadeOut(1f, Color.white, app.GameMode.RestartLevel);
					}
				}, level);
				level.Notifications.OpenPopup(message);
			});
			_preferencesButton.onClick.AddListener(delegate
			{
				app.PreferencesScreen.Show();
			});
			_quitToMapButton.onClick.AddListener(app.MetagameMap.Open);
			_quitToMenuButton.onClick.AddListener(delegate
			{
				app.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureQuitToMenu_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuitToMenu_CS, app.SaveSystem), ScriptLocalization.Menu_Messages.QuitSave_Button_CS, ScriptLocalization.Menu_Messages.QuitDontSave_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, app.QuitToMenu, app.QuitToMenuDontSave);
			});
			_quitToDesktopButton.onClick.AddListener(delegate
			{
				app.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureQuit_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuit_CS, app.SaveSystem), ScriptLocalization.Menu_Messages.QuitSave_Button_CS, ScriptLocalization.Menu_Messages.QuitDontSave_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, app.QuitGame, app.QuitGameDontSave);
			});
			_debugSaveButton.onClick.AddListener(delegate
			{
				ChooseSaveScreen chooseSaveScreen = base.HUD.CreateMenu<ChooseSaveScreen>();
				chooseSaveScreen.Setup(app.SaveSystem, app.Metagame.LevelList, app.MessageBox, app.Save, app.Load);
				chooseSaveScreen.ShowAsSaveScreen();
			});
			_debugLoadButton.onClick.AddListener(delegate
			{
				ChooseSaveScreen chooseSaveScreen = base.HUD.CreateMenu<ChooseSaveScreen>();
				chooseSaveScreen.Setup(app.SaveSystem, app.Metagame.LevelList, app.MessageBox, app.Save, app.Load);
				chooseSaveScreen.ShowAsLoadScreen();
			});
			_debugSaveButton.gameObject.SetActive(value: false);
			_debugLoadButton.gameObject.SetActive(value: false);
		}
	}
}
