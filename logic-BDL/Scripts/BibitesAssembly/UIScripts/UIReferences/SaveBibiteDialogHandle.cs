using System.IO;
using System.Text.RegularExpressions;
using ManagementScripts;
using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class SaveBibiteDialogHandle : ChoicePopupHandle
	{
		public TMP_InputField bibiteName;

		public TMP_InputField description;

		public GameObject warningInvalidText;

		public GameObject warningExistingText;

		private readonly Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");

		public Toggle saveAsTemplate;

		public Toggle formatJSON;

		public Button submitButton;

		public EscapableAction dialogOpen;

		private void Awake()
		{
			bibiteName.onValueChanged.AddListener(CheckExistingBibite);
			formatJSON.isOn = UserSettings.FormatBibiteJSON.val;
			formatJSON.onValueChanged.AddListener(UserSettings.FormatBibiteJSON.SetValue);
			saveAsTemplate.isOn = UserSettings.SaveBibiteAsTemplate.val;
			saveAsTemplate.onValueChanged.AddListener(UserSettings.SaveBibiteAsTemplate.SetValue);
			saveAsTemplate.onValueChanged.AddListener(delegate
			{
				CheckExistingBibite();
			});
			OnDismiss.AddListener(CloseDialog);
			dialogOpen = new EscapableAction(CloseDialog);
		}

		public void OpenDialog(string defaultText = "Bibite personalis", string defaultDescription = "", bool allowSaved = true)
		{
			base.gameObject.SetActive(value: true);
			TimeController.Instance.TogglePauseGame("BibiteSaveDialog");
			UserControl.AllowControl = false;
			PopupManager.screenBlocker.SetActive(value: true);
			if (!allowSaved)
			{
				saveAsTemplate.isOn = true;
			}
			saveAsTemplate.interactable = allowSaved;
			bibiteName.text = defaultText;
			description.text = defaultDescription;
			UINavigationManager.AddEscapableToStack(dialogOpen);
			CheckExistingBibite();
		}

		public void CloseDialog()
		{
			UINavigationManager.RemoveEscapableFromStack(dialogOpen);
			TimeController.Instance.TogglePauseGame("SaveSystem", isUnpause: true);
			UserControl.AllowControl = true;
			PopupManager.screenBlocker.SetActive(value: false);
			base.gameObject.SetActive(value: false);
		}

		public string GetSavePath()
		{
			return Path.Combine(saveAsTemplate.isOn ? SaveSystem.bibiteTemplatePath : SaveSystem.savedBibitePath, string.Concat(str1: saveAsTemplate.isOn ? ".bb8template" : ".bb8", str0: bibiteName.text));
		}

		public void CheckExistingBibite(string arg0 = "")
		{
			bool flag = containsABadCharacter.IsMatch(bibiteName.text);
			warningInvalidText.SetActive(flag);
			submitButton.interactable = !flag && !string.IsNullOrEmpty(bibiteName.text);
			warningExistingText.SetActive(File.Exists(GetSavePath()));
		}
	}
}
