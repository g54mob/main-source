using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.State;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SaveView : ProfilesView
	{
		[SerializeField]
		private SoundButton newSaveButton;

		[SerializeField]
		private TMP_InputField newSaveName;

		private new void Start()
		{
			base.Start();
			newSaveButton.onClick.RemoveAllListeners();
			newSaveButton.onClick.AddListener(ClickNewSave);
		}

		private void OnTick(float deltaTime)
		{
			if (base.gameObject.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					ClickNewSave();
				}
				if (Input.GetKeyDown(KeyCode.Tab))
				{
					newSaveName.ActivateInputField();
				}
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
		}

		public override void Show()
		{
			base.Show();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick += OnTick;
			}
			newSaveName.ActivateInputField();
		}

		public override List<VillageSaveInfo> GetProfiles()
		{
			return (from profile in MonoSingleton<GlobalSaveController>.Instance.SavesList.FindAll((VillageSaveInfo profile) => !profile.AutoSave && !profile.IsObsolete)
				orderby profile.LastPlayed descending
				select profile).ToList();
		}

		protected override List<VillageSaveInfo> GetProfilesForFoldersList()
		{
			return (from profile in MonoSingleton<GlobalSaveController>.Instance.SavesList.FindAll((VillageSaveInfo profile) => !profile.AutoSave && !profile.IsObsolete)
				orderby profile.LastPlayed descending
				select profile).ToList();
		}

		private void ClickNewSave()
		{
			if (string.IsNullOrEmpty(newSaveName.text) || string.IsNullOrWhiteSpace(newSaveName.text))
			{
				return;
			}
			if (GlobalSaveController.CurrentVillageData == null)
			{
				Log.Error("This should be called MainScene.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SaveView.cs");
				return;
			}
			VillageSaveData village = GlobalSaveController.CurrentVillageData;
			string nameWithExtenstion = newSaveName.text.ToLower() + ".sav";
			bool isEnabled;
			if (MonoSingleton<GlobalSaveController>.Instance.SavesList.FirstOrDefault((VillageSaveInfo save) => save.FileName.ToLower().Equals(nameWithExtenstion) && save.FolderName.ToLower().Equals(village.FolderName.ToLower())) != null)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SaveView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("The save already exists for village \"");
					messageBuilder.AppendFormatted(village.FolderName);
					messageBuilder.AppendLiteral(".\"");
				}
				Log.Info(messageBuilder);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_file_already_exists"));
				return;
			}
			try
			{
				Log.Info("ClickNewSave", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SaveView.cs");
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("save_in_progress"), handleInput: false);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(DoSave);
			}
			catch (Exception ex)
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SaveView.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Save failed for reason: ");
					messageBuilder2.AppendFormatted(ex.Message);
				}
				Log.Warning(messageBuilder2);
				ShowSaveFailedMessage();
			}
			void DoSave()
			{
				MonoSingleton<GlobalSaveController>.Instance.SaveCurrentVillage(newSaveName.text);
				Show();
				newSaveName.text = string.Empty;
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("game_saved"));
				MonoSingleton<UIController>.Instance.ClosePrompt();
			}
		}

		protected override void OverwriteProfile(VillageSaveInfo profile)
		{
			Log.Info("OverwriteProfile", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SaveView.cs");
			if (!MonoSingleton<GlobalSaveController>.Instance.DeleteSave(profile))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_failed"));
				return;
			}
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("save_in_progress"), handleInput: false);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(DoSave);
			void DoSave()
			{
				string path = profile.FilePath.Replace(profile.FileName, "");
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				VillageSaveInfo newSave = MonoSingleton<GlobalSaveController>.Instance.SaveCurrentVillage(profile.FileName);
				OnSaveReplaced(newSave, profile);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("game_saved"));
				MonoSingleton<UIController>.Instance.ClosePrompt();
			}
		}

		protected override bool OverrideButtonEnabled()
		{
			return true;
		}

		private static void ShowSaveFailedMessage()
		{
			KeyValuePair<string, Action> item = new KeyValuePair<string, Action>("general_ok", null);
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>> { item };
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("save_failed", buttonActions), handleInput: false);
		}
	}
}
