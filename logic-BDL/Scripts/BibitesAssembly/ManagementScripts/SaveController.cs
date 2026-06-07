using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SettingScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;

namespace ManagementScripts
{
	public class SaveController : MonoBehaviour
	{
		private SaveSystem saveSystem;

		public Text saveSystemStatus;

		public static SaveController Instance;

		[FormerlySerializedAs("SaveDialog")]
		public SaveBibiteDialogHandle saveBibiteDialog;

		private GameObject tempObj;

		private BibiteTemplate tempTemplate;

		private bool autoSaveReloadReselectTarget;

		private string lastAutoSaveFileName;

		private Coroutine autosaveCoroutine;

		private static readonly BoolUserSetting AutoSaveEnable = UserSettings.AutoSave;

		private static readonly BoolUserSetting AutoSaveRealTime = UserSettings.AutoSaveRealTime;

		private static readonly ChoiceUserSetting<UserSettings.AutoSavePeriods> AutoSavePeriod = UserSettings.AutoSavePeriod;

		private bool autoSaveEnabled;

		private bool autoSaveRealTime;

		private UserSettings.AutoSavePeriods autoSavePeriod;

		public static string SavePath => Path.Combine(Application.persistentDataPath, "Savefiles");

		public static string AutoSavePath => Path.Combine(SavePath, "Autosaves");

		private void UpdateAutoSaveRealTime(bool val)
		{
			autoSaveRealTime = val;
		}

		private void UpdateAutoSavePeriod(UserSettings.AutoSavePeriods val)
		{
			autoSavePeriod = val;
		}

		private void Awake()
		{
			Instance = this;
			saveSystem = GetComponent<SaveSystem>();
			autoSaveEnabled = AutoSaveEnable.SubscribeTo<BoolUserSetting, bool>(ToggleAutoSave);
			autoSaveRealTime = AutoSaveRealTime.SubscribeTo<BoolUserSetting, bool>(UpdateAutoSaveRealTime);
			AutoSaveRealTime.SubscribeTo<BoolUserSetting, bool>(RestartAutoSave);
			autoSavePeriod = AutoSavePeriod.SubscribeTo<ChoiceUserSetting<UserSettings.AutoSavePeriods>, UserSettings.AutoSavePeriods>(UpdateAutoSavePeriod);
			AutoSavePeriod.SubscribeTo<ChoiceUserSetting<UserSettings.AutoSavePeriods>, UserSettings.AutoSavePeriods>(RestartAutoSave);
			saveBibiteDialog.InitDialog("Save Bibite", "", "Cancel", "Save", null, SaveDialogConfirmed);
			saveBibiteDialog.gameObject.SetActive(value: false);
			saveSystem.onSavingDone.AddListener(HideSaveStatus);
			HideSaveStatus();
		}

		private void Start()
		{
			ToggleAutoSave(UserSettings.AutoSave.val);
		}

		public void ToggleAutoSave(bool toggle)
		{
			autoSaveEnabled = toggle;
			RestartAutoSave();
		}

		public void RestartAutoSave()
		{
			if (autosaveCoroutine != null)
			{
				StopCoroutine(autosaveCoroutine);
			}
			if (autoSaveEnabled)
			{
				autosaveCoroutine = StartCoroutine(AutoSave());
			}
		}

		public void SaveBibiteOrEgg(GameObject obj)
		{
			LockControls();
			tempObj = obj;
			tempTemplate = null;
			Species species = obj.GetComponent<BibiteGenes>().species;
			saveBibiteDialog.OpenDialog(species.name, species.description);
			saveBibiteDialog.CheckExistingBibite();
		}

		public void SaveTemplateOfBibite(BibiteTemplate template)
		{
			tempObj = null;
			tempTemplate = new BibiteTemplate(template);
			saveBibiteDialog.OpenDialog(template.name, template.description, allowSaved: false);
			saveBibiteDialog.CheckExistingBibite();
		}

		public void LockControls()
		{
			TimeController.Instance.TogglePauseGame("SaveSystem");
			UserControl.AllowControl = false;
			PopupManager.screenBlocker.SetActive(value: true);
		}

		public void ReleaseControl()
		{
			TimeController.Instance.TogglePauseGame("SaveSystem", isUnpause: true);
			UserControl.AllowControl = true;
			PopupManager.screenBlocker.SetActive(value: false);
		}

		public void SaveDialogConfirmed()
		{
			string savePath = saveBibiteDialog.GetSavePath();
			bool isOn = saveBibiteDialog.saveAsTemplate.isOn;
			if (tempTemplate != null)
			{
				tempTemplate.name = saveBibiteDialog.bibiteName.text;
				tempTemplate.speciesName = saveBibiteDialog.bibiteName.text;
				tempTemplate.description = saveBibiteDialog.description.text;
			}
			if (isOn)
			{
				if (tempTemplate != null)
				{
					SaveSystem.SaveTemplate(tempTemplate, savePath);
				}
				else
				{
					saveSystem.SaveBibiteAsTemplate(tempObj, savePath, saveBibiteDialog.bibiteName.text, saveBibiteDialog.description.text);
				}
			}
			else
			{
				saveSystem.SaveBibiteOrEgg(tempObj, savePath, saveBibiteDialog.description.text);
			}
			ReleaseControl();
		}

		public void QuickSave()
		{
			string worldPath = Path.Combine(SavePath, "quick.zip");
			SaveWorld(worldPath);
		}

		public void QuickLoad()
		{
			string worldPath = Path.Combine(SavePath, "quick.zip");
			LoadWorld(worldPath);
		}

		public void SaveWorld(string worldPath)
		{
			if (!string.IsNullOrEmpty(worldPath))
			{
				ShowSaveStatus();
				saveSystem.SaveGame(worldPath);
			}
		}

		public void LoadWorld(string worldPath)
		{
			if (!File.Exists(worldPath))
			{
				return;
			}
			ShowSaveStatus("Loading...");
			try
			{
				saveSystem.LoadGame(worldPath);
			}
			catch (Exception ex)
			{
				PopupManager.DisplayError("Load System", "There was an error loading this save file. \n" + ex.Message);
				Debug.LogException(ex);
			}
			finally
			{
				HideSaveStatus();
			}
		}

		private IEnumerator AutoSave()
		{
			yield return null;
			int num = (int)autoSavePeriod;
			WaitForSecondsRealtime rTDelay = new WaitForSecondsRealtime(num * 60);
			WaitForSeconds delay = new WaitForSeconds(num * 60);
			yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(0, 5));
			while (autoSaveEnabled)
			{
				if (autoSaveRealTime)
				{
					yield return rTDelay;
					while (Time.timeScale <= 0f && autoSaveEnabled)
					{
						yield return new WaitForSecondsRealtime(60f);
					}
				}
				else
				{
					yield return delay;
				}
				if (!ScenarioSettings.Instance.isChallenge)
				{
					ZoneManager.instance.RefreshPelletBiomassCounter();
					CleanUpAutosaveFolder(AutoSavePath);
					lastAutoSaveFileName = Path.Combine(AutoSavePath, $"autosave_{DateTime.Now:yyyyMMddHHmmss}.zip");
					SaveWorld(lastAutoSaveFileName);
					if (UserSettings.ReloadAfterAutosaves.val)
					{
						saveSystem.onSavingDone.AddListener(ReloadAfterAutoSave);
					}
				}
			}
		}

		public void ReloadAfterAutoSave()
		{
			saveSystem.onSavingDone.RemoveListener(ReloadAfterAutoSave);
			SimulationManager.fromAutosaveReload = true;
			SimulationManager.posAtAutoReload = CameraManager.instance.transform.position;
			SimulationManager.hadSomethingSelected = GUIManager.Instance.hasTarget;
			SimulationManager.camSizeAtAutoReload = CameraManager.camSize;
			GameManager.StartGame(lastAutoSaveFileName);
		}

		public void ShowSaveStatus(string statusText = "Saving...")
		{
			saveSystemStatus.text = statusText;
			saveSystemStatus.gameObject.SetActive(value: true);
		}

		private void HideSaveStatus()
		{
			saveSystemStatus.gameObject.SetActive(value: false);
		}

		private void CleanUpAutosaveFolder(string folder)
		{
			if (UserSettings.AutoSaveMaxFiles.val <= 0)
			{
				return;
			}
			string[] array = (from file in Directory.GetFiles(folder, "*.zip")
				orderby new FileInfo(file).LastWriteTime descending
				select file).Skip(UserSettings.AutoSaveMaxFiles.val).ToArray();
			foreach (string text in array)
			{
				try
				{
					File.Delete(text);
				}
				catch
				{
					PopupManager.DisplayError("Save System", "The save file " + text + " was to be deleted because there are more autosaves than the maximum user-defined number, but the file couldn't be accessed. It might already be opened by another application.");
				}
			}
		}

		public static bool AnySave()
		{
			if (Directory.GetFiles(SavePath, "*.zip").Length <= 0)
			{
				return Directory.GetFiles(AutoSavePath, "*.zip").Length != 0;
			}
			return true;
		}

		public static string GetLastSave()
		{
			return (from file in Directory.GetFiles(SavePath, "*.zip").Concat(Directory.GetFiles(AutoSavePath, "*.zip"))
				orderby new FileInfo(file).LastWriteTime descending
				select file).First();
		}

		public static string[] GetSaves(bool includeAutoSaves = false, bool sort = true)
		{
			IEnumerable<string> enumerable = Directory.GetFiles(SavePath, "*.zip");
			if (includeAutoSaves)
			{
				enumerable = enumerable.Concat(Directory.GetFiles(AutoSavePath, "*.zip"));
			}
			if (sort)
			{
				enumerable = enumerable.OrderByDescending((string file) => new FileInfo(file).LastWriteTime);
			}
			return enumerable.ToArray();
		}

		private void OnDestroy()
		{
			AutoSaveEnable.UnSubscribeTo<BoolUserSetting, bool>(ToggleAutoSave);
			AutoSaveRealTime.UnSubscribeTo<BoolUserSetting, bool>(UpdateAutoSaveRealTime);
			AutoSaveRealTime.UnSubscribeTo<BoolUserSetting, bool>(RestartAutoSave);
			AutoSavePeriod.UnSubscribeTo<ChoiceUserSetting<UserSettings.AutoSavePeriods>, UserSettings.AutoSavePeriods>(UpdateAutoSavePeriod);
			AutoSavePeriod.UnSubscribeTo<ChoiceUserSetting<UserSettings.AutoSavePeriods>, UserSettings.AutoSavePeriods>(RestartAutoSave);
		}
	}
}
