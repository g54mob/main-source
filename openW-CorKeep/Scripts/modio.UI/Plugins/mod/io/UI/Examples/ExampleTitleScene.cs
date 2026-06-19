using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModIO.Implementation;
using ModIO.Util;
using ModIOBrowser;
using ModIOBrowser.Implementation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Plugins.mod.io.UI.Examples
{
	public class ExampleTitleScene : MonoBehaviour
	{
		[SerializeField]
		private Selectable DefaultSelection;

		[SerializeField]
		private ExampleSettingsPanel exampleSettingsPanel;

		public string verticalControllerInput = "Vertical";

		public List<string> mouseInput = new List<string>();

		public MultiTargetDropdown languageSelectionDropdown;

		private void Start()
		{
			OpenTitle();
			languageSelectionDropdown.gameObject.SetActive(value: false);
			StartCoroutine(SetupTranslationDropDown());
		}

		private IEnumerator SetupTranslationDropDown()
		{
			while (!SelfInstancingMonoSingleton<TranslationManager>.SingletonIsInstantiated())
			{
				yield return new WaitForSeconds(0.1f);
			}
			languageSelectionDropdown.gameObject.SetActive(value: true);
			languageSelectionDropdown.ClearOptions();
			languageSelectionDropdown.AddOptions((from x in Enum.GetNames(typeof(TranslatedLanguages))
				select new TMP_Dropdown.OptionData(x.ToString())).ToList());
			languageSelectionDropdown.value = (int)SelfInstancingMonoSingleton<TranslationManager>.Instance.SelectedLanguage;
		}

		public void OnTranslationDropdownChange()
		{
			SelfInstancingMonoSingleton<TranslationManager>.Instance.ChangeLanguage((TranslatedLanguages)languageSelectionDropdown.value);
		}

		public void OpenMods()
		{
			base.gameObject.transform.parent.gameObject.SetActive(value: false);
		}

		public void OpenSettings()
		{
			exampleSettingsPanel.ActivatePanel(isActive: true);
		}

		public void OpenTitle()
		{
			base.gameObject.transform.parent.gameObject.SetActive(value: true);
			DefaultSelection.Select();
		}

		public void Quit()
		{
			Application.Quit();
		}

		public void DeselectOtherTitles()
		{
			EventSystem.current.SetSelectedGameObject(null);
		}

		private void Update()
		{
			if (Input.GetAxis(verticalControllerInput) != 0f)
			{
				Cursor.lockState = CursorLockMode.Locked;
				if (EventSystem.current.currentSelectedGameObject == null)
				{
					DefaultSelection.Select();
				}
			}
			else if (mouseInput.Any((string x) => Input.GetAxis(x) != 0f))
			{
				Cursor.lockState = CursorLockMode.None;
			}
		}
	}
}
