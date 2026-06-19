using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Aggro.Core
{
	public sealed class AggroSettingsManagerUI : MonoBehaviour
	{
		private struct CategoryEntry
		{
			public AggroSettingsCategoryUI ui;

			public string category;

			public GameObject customPage;
		}

		private struct SettingEntry
		{
			public GameObject gameObject;

			public AggroSettingBase setting;

			public AggroSettingGeneralUI generalUI;

			public AggroSettingUI ui;

			public int categoryIndex;
		}

		public Transform categoryContainer;

		public Transform settingsContainer;

		public Transform customPageContainer;

		[Space]
		public Button backButton;

		public GameObject[] gamepadHints;

		[Header("Animation")]
		[Min(0f)]
		public float timeBetweenSettings = 0.05f;

		[Min(0f)]
		public float fadeInDuration = 0.1f;

		public EasingFunction.Ease fadeInEase = EasingFunction.Ease.Linear;

		[Header("Audio")]
		public EventReference sfxOpenSettings;

		public EventReference sfxCloseSettings;

		private List<SettingEntry> _settings = new List<SettingEntry>();

		private List<AggroSettingGeneralUI> _showing = new List<AggroSettingGeneralUI>();

		private List<CategoryEntry> _categories = new List<CategoryEntry>();

		private List<Selectable> _selectables = new List<Selectable>();

		private int _currentCategoryIndex = -1;

		private InputMode _inputMode;

		private static bool _gamepadIsSuppressingBack;

		private static bool _isSuppressionDirty;

		public static bool gamepadSuppressBack
		{
			get
			{
				return _gamepadIsSuppressingBack;
			}
			set
			{
				_gamepadIsSuppressingBack = value;
				_isSuppressionDirty = true;
			}
		}

		public void Initialize(AggroSettingBase[] settings)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (AggroSettingBase aggroSettingBase in settings)
			{
				if (dictionary.ContainsKey(aggroSettingBase.category))
				{
					continue;
				}
				if (!GlobalScriptableObject<AggroSettingsObject>.instance.TryGetCategoryLabel(aggroSettingBase.category, out var label))
				{
					Debug.LogWarning("[SETTINGS] Could not find category in AggroSettingsObject! Category: " + aggroSettingBase.category, GlobalScriptableObject<AggroSettingsObject>.instance);
					dictionary.Add(aggroSettingBase.category, -1);
					continue;
				}
				GameObject obj = Object.Instantiate(GlobalScriptableObject<AggroSettingsObject>.instance.categoryPrefab, categoryContainer);
				obj.transform.ResetAll();
				AggroSettingsCategoryUI component = obj.GetComponent<AggroSettingsCategoryUI>();
				component.Set(_categories.Count, label, OnCategorySelected);
				dictionary.Add(aggroSettingBase.category, _categories.Count);
				CategoryEntry item = new CategoryEntry
				{
					ui = component,
					category = aggroSettingBase.category
				};
				if (GlobalScriptableObject<AggroSettingsObject>.instance.TryGetCategoryPagePrefab(aggroSettingBase.category, out var pagePrefab))
				{
					item.customPage = Object.Instantiate(pagePrefab, customPageContainer);
					item.customPage.GetComponent<AggroSettingsCustomPageUI>().Initialize(aggroSettingBase.category);
					item.customPage.SetActive(value: false);
				}
				_categories.Add(item);
			}
			foreach (AggroSettingBase aggroSettingBase2 in settings)
			{
				if (!GlobalScriptableObject<AggroSettingsObject>.instance.TryGetTemplate(aggroSettingBase2.GetType(), out var template))
				{
					Debug.LogWarning("[SETTINGS] Could not find template for type in AggroSettingsObject! Type: " + TypeUtil.GetFriendlyName(aggroSettingBase2.GetType()), GlobalScriptableObject<AggroSettingsObject>.instance);
					continue;
				}
				int num = dictionary[aggroSettingBase2.category];
				CategoryEntry categoryEntry = _categories[num];
				GameObject gameObject;
				if (categoryEntry.customPage != null)
				{
					gameObject = categoryEntry.customPage.GetComponent<AggroSettingsCustomPageUI>().InstantiateSettingUI(template);
				}
				else
				{
					gameObject = Object.Instantiate(template, settingsContainer);
					gameObject.transform.ResetAll();
				}
				SettingEntry item2 = default(SettingEntry);
				item2.gameObject = gameObject;
				item2.generalUI = gameObject.GetComponent<AggroSettingGeneralUI>();
				item2.ui = gameObject.GetComponent<AggroSettingUI>();
				item2.setting = aggroSettingBase2;
				item2.categoryIndex = num;
				item2.generalUI.Set(aggroSettingBase2);
				item2.ui.Set(aggroSettingBase2);
				gameObject.SetActive(value: false);
				_settings.Add(item2);
			}
		}

		public void RefreshSettingUIs()
		{
			for (int i = 0; i < _categories.Count; i++)
			{
				_categories[i].ui.Refresh();
			}
			for (int j = 0; j < _settings.Count; j++)
			{
				SettingEntry settingEntry = _settings[j];
				settingEntry.generalUI.Refresh();
				settingEntry.ui.Refresh();
			}
		}

		private void Update()
		{
			if (AggroSettings.suppressInput)
			{
				return;
			}
			switch (_inputMode)
			{
			case InputMode.Gamepad:
				if (Gamepad.current == null)
				{
					break;
				}
				if (!_isSuppressionDirty)
				{
					if (Gamepad.current.leftShoulder.wasPressedThisFrame)
					{
						int num = _currentCategoryIndex - 1;
						if (num < 0)
						{
							num = _categories.Count - 1;
						}
						OnCategorySelected(num);
					}
					else if (Gamepad.current.rightShoulder.wasPressedThisFrame)
					{
						int num2 = _currentCategoryIndex + 1;
						if (num2 >= _categories.Count)
						{
							num2 -= _categories.Count;
						}
						OnCategorySelected(num2);
					}
					else if (!_gamepadIsSuppressingBack)
					{
						if (AggroUtil.IsCurrentGamepadProController())
						{
							if (Gamepad.current.buttonSouth.wasPressedThisFrame)
							{
								CloseSettings();
							}
						}
						else if (Gamepad.current.buttonEast.wasPressedThisFrame)
						{
							CloseSettings();
						}
					}
				}
				_isSuppressionDirty = false;
				break;
			case InputMode.KBM:
				if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponentInParent<TMP_InputField>() == null && EventSystem.current.currentSelectedGameObject.GetComponentInParent<InputField>() == null)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
				{
					CloseSettings();
				}
				break;
			default:
				throw new InvalidEnumException();
			case InputMode.None:
				break;
			}
			if (Debug.isDebugBuild && Keyboard.current != null && Keyboard.current.f5Key.wasPressedThisFrame)
			{
				AggroSettings.RefreshSettings(_categories[_currentCategoryIndex].category);
			}
		}

		public static void SuppressInput()
		{
			_isSuppressionDirty = true;
		}

		public void SetInputMode(InputMode mode)
		{
			_inputMode = mode;
			for (int i = 0; i < gamepadHints.Length; i++)
			{
				GameObject gameObject = gamepadHints[i];
				if (gameObject != null)
				{
					gameObject.SetActive(mode == InputMode.Gamepad);
				}
			}
			if (_inputMode == InputMode.Gamepad && base.gameObject.activeSelf && EventSystem.current != null && _settings.Count > 0)
			{
				SetFirstSelected();
			}
		}

		public void Show(InputMode mode, string category = null)
		{
			if (_settings.Count > 0)
			{
				_currentCategoryIndex = -1;
				if (category == null)
				{
					OnCategorySelected(0);
				}
				else
				{
					for (int i = 0; i < _categories.Count; i++)
					{
						if (_categories[i].category == category)
						{
							OnCategorySelected(i);
							break;
						}
					}
				}
				SetInputMode(mode);
			}
			AggroUtil.PlaySfxIfValid(sfxOpenSettings);
		}

		public void Closing()
		{
			AggroUtil.PlaySfxIfValid(sfxCloseSettings);
		}

		public void Refresh()
		{
			int currentCategoryIndex = _currentCategoryIndex;
			_currentCategoryIndex = -1;
			OnCategorySelected(currentCategoryIndex);
		}

		public void CloseSettings()
		{
			gamepadSuppressBack = false;
			AggroSettings.CloseSettings();
		}

		private void OnCategorySelected(int categoryIndex)
		{
			if (_currentCategoryIndex == categoryIndex)
			{
				return;
			}
			StopAllCoroutines();
			_currentCategoryIndex = categoryIndex;
			CategoryEntry categoryEntry = _categories[_currentCategoryIndex];
			for (int i = 0; i < _settings.Count; i++)
			{
				SettingEntry settingEntry = _settings[i];
				if (settingEntry.categoryIndex != categoryIndex)
				{
					settingEntry.gameObject.SetActive(value: false);
				}
			}
			for (int j = 0; j < _categories.Count; j++)
			{
				_categories[j].ui.SetSelection(j == categoryIndex);
			}
			if (categoryEntry.customPage != null)
			{
				customPageContainer.gameObject.SetActive(value: true);
				settingsContainer.gameObject.SetActive(value: false);
				categoryEntry.customPage.SetActive(value: true);
				categoryEntry.customPage.GetComponent<AggroSettingsCustomPageUI>().Show(timeBetweenSettings, fadeInDuration, fadeInEase, backButton);
				return;
			}
			customPageContainer.gameObject.SetActive(value: false);
			settingsContainer.gameObject.SetActive(value: true);
			_showing.Clear();
			for (int k = 0; k < _settings.Count; k++)
			{
				SettingEntry settingEntry2 = _settings[k];
				if (settingEntry2.categoryIndex == categoryIndex)
				{
					settingEntry2.gameObject.SetActive(value: true);
					_showing.Add(settingEntry2.generalUI);
				}
			}
			_selectables.Clear();
			for (int l = 0; l < _settings.Count; l++)
			{
				Selectable selectable = _settings[l].generalUI.selectable;
				if ((object)selectable != null)
				{
					_selectables.Add(selectable);
				}
			}
			SetNavigation();
			if (_inputMode == InputMode.Gamepad && EventSystem.current != null && _settings.Count > 0)
			{
				SetFirstSelected();
			}
			StartCoroutine(DisplayCo());
		}

		private void SetFirstSelected()
		{
			SettingEntry settingEntry = default(SettingEntry);
			for (int i = 0; i < _settings.Count; i++)
			{
				SettingEntry settingEntry2 = _settings[i];
				if (settingEntry2.categoryIndex == _currentCategoryIndex)
				{
					settingEntry = settingEntry2;
					break;
				}
			}
			EventSystem.current.SetSelectedGameObject(settingEntry.generalUI.selectable.gameObject);
		}

		private IEnumerator DisplayCo()
		{
			for (int i = 0; i < _showing.Count; i++)
			{
				_showing[i].PrepareForShow();
			}
			int index = 0;
			float accum = 0f;
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

		private void SetNavigation()
		{
			UIUtil.SetVerticalSelectables(_selectables, backButton, null, null, null);
			for (int i = 0; i < _selectables.Count; i++)
			{
				Selectable selectable = _selectables[i];
				if (selectable.GetComponent<Slider>() != null)
				{
					Navigation navigation = selectable.navigation;
					navigation.selectOnLeft = null;
					selectable.navigation = navigation;
				}
			}
			UIUtil.SetNavigation(backButton, null, null, _selectables[0], null);
		}
	}
}
