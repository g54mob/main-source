using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aggro.Core
{
	public class AggroSettingsCustomPageInputUI : AggroSettingsCustomPageUI
	{
		public RectTransform settingsContainer;

		[Space]
		public Button revertButton;

		[Space]
		public GameObject rebindingContainer;

		public EventReference revertSelected;

		private string _category;

		private InputMode _prevMode;

		private List<InputSettingUI> _uis = new List<InputSettingUI>();

		private List<AggroSettingGeneralUI> _showing = new List<AggroSettingGeneralUI>();

		private static List<InputSetting> _inputSettings = new List<InputSetting>();

		private static List<Selectable> _selectables = new List<Selectable>();

		public override void Initialize(string category)
		{
			_category = category;
			rebindingContainer.SetActive(value: false);
		}

		public override GameObject InstantiateSettingUI(GameObject prefab)
		{
			GameObject obj = Object.Instantiate(prefab, settingsContainer);
			obj.transform.ResetAll();
			InputSettingUI component = obj.GetComponent<InputSettingUI>();
			component.SetOnRebindingCallback(OnRebindStart, OnRebindComplete);
			_uis.Add(component);
			return obj;
		}

		public override void Show(float timeBetweenSettings, float fadeInDuration, EasingFunction.Ease fadeInEase, Selectable backButton)
		{
			_showing.Clear();
			_prevMode = AggroSettings.inputMode;
			for (int i = 0; i < _uis.Count; i++)
			{
				InputSettingUI inputSettingUI = _uis[i];
				if (inputSettingUI.CanShow())
				{
					inputSettingUI.gameObject.SetActive(value: true);
					inputSettingUI.Showing();
					_showing.Add(inputSettingUI.GetComponent<AggroSettingGeneralUI>());
				}
				else
				{
					inputSettingUI.gameObject.SetActive(value: false);
				}
			}
			_selectables.Clear();
			for (int j = 0; j < _showing.Count; j++)
			{
				AggroSettingGeneralUI aggroSettingGeneralUI = _showing[j];
				Button button = aggroSettingGeneralUI.GetComponent<InputSettingUI>().revertButton;
				if ((object)aggroSettingGeneralUI.selectable != null && (object)button != null)
				{
					_selectables.Add(aggroSettingGeneralUI.selectable);
				}
			}
			for (int k = 0; k < _showing.Count; k++)
			{
				AggroSettingGeneralUI aggroSettingGeneralUI2 = _showing[k];
				Button button2 = aggroSettingGeneralUI2.GetComponent<InputSettingUI>().revertButton;
				if ((object)aggroSettingGeneralUI2.selectable != null && (object)button2 != null)
				{
					_selectables.Add(button2);
				}
			}
			UIUtil.SetGridSelectablesVertical(_selectables, _showing.Count, revertButton, null, null, null);
			UIUtil.SetNavigation(revertButton, null, backButton, (_selectables.Count > 0) ? _selectables[0] : null, null);
			UIUtil.SetNavigation(backButton, null, null, (_selectables.Count > 0) ? _selectables[0] : null, revertButton);
			if (AggroSettings.inputMode == InputMode.Gamepad && EventSystem.current != null && _showing.Count > 0)
			{
				EventSystem.current.SetSelectedGameObject(_showing[0].selectable.gameObject);
			}
			StopAllCoroutines();
			StartCoroutine(DisplayCo(timeBetweenSettings, fadeInDuration, fadeInEase));
		}

		private IEnumerator DisplayCo(float timeBetweenSettings, float fadeInDuration, EasingFunction.Ease fadeInEase)
		{
			AggroFadeSettingUI buttonFade = revertButton.GetComponent<AggroFadeSettingUI>();
			buttonFade.PrepareForShow();
			for (int i = 0; i < _showing.Count; i++)
			{
				_showing[i].PrepareForShow();
			}
			float accum;
			for (accum = 0f; accum < timeBetweenSettings; accum += Time.unscaledDeltaTime)
			{
				yield return null;
			}
			buttonFade.Show(fadeInDuration, fadeInEase);
			accum -= timeBetweenSettings;
			int index = 0;
			while (index < _showing.Count)
			{
				yield return null;
				accum += Time.unscaledDeltaTime;
				while (accum >= timeBetweenSettings && index < _showing.Count)
				{
					accum -= timeBetweenSettings;
					_showing[index++].Show(fadeInDuration, fadeInEase);
				}
			}
		}

		private void Update()
		{
			if (_prevMode != AggroSettings.inputMode)
			{
				_prevMode = AggroSettings.inputMode;
				AggroSettings.RefreshCurrentCategory();
			}
		}

		public void OnRevertInput()
		{
			AggroUtil.PlaySfxIfValid(revertSelected);
			_inputSettings.Clear();
			AggroSettings.GetSettings(_category, _inputSettings);
			foreach (InputSetting inputSetting in _inputSettings)
			{
				inputSetting.SetToDefault();
			}
			AggroSettings.SaveAll();
			AggroSettings.RefreshSettingUIs();
		}

		private void OnRebindStart()
		{
			rebindingContainer.SetActive(value: true);
		}

		private void OnRebindComplete()
		{
			rebindingContainer.SetActive(value: false);
		}
	}
}
