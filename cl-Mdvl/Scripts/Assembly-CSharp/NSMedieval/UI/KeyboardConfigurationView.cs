using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class KeyboardConfigurationView : OptionsView
	{
		[SerializeField]
		private LayoutGroupView contentGroup;

		[SerializeField]
		private BasicLayoutItemView groupTitle;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private SoundButton resetButton;

		[SerializeField]
		private SoundButton cancelButton;

		[SerializeField]
		private SoundButton buttonOk;

		[SerializeField]
		private GameObject keyInputPanel;

		private KeybindingLayoutItemView currentKeybindingView;

		private bool initialized;

		private Dictionary<KeybindingLayoutItemView, int> keyInputEventByView;

		private bool primaryKeyBindChanging;

		private Dictionary<int, KeybindingLayoutItemView> viewByKeyInputEvent;

		public static bool WaitingForInput { get; private set; }

		private void Start()
		{
			resetButton.onClick.AddListener(MonoSingleton<KeybindingController>.Instance.ReloadDefaultKeybindings);
			cancelButton.onClick.AddListener(delegate
			{
				MonoSingleton<KeybindingController>.Instance.CancelAllChanges();
				Hide();
			});
			buttonOk.onClick.AddListener(delegate
			{
				MonoSingleton<KeybindingController>.Instance.SaveKeybindings();
				Hide();
			});
			title.SetText(MonoSingleton<LocalizationController>.Instance.GetText("menu_keyboard_configuration"));
			Initialize();
		}

		private void OnEnable()
		{
			MonoSingleton<KeybindingController>.Instance.KeybindingsUpdatedEvent += UpdateData;
			if (initialized)
			{
				UpdateData();
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<KeybindingController>.IsInstantiated())
			{
				MonoSingleton<KeybindingController>.Instance.KeybindingsUpdatedEvent -= UpdateData;
			}
		}

		private void ActivateKeyInputPanel(bool active)
		{
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(active);
			}
			keyInputPanel.SetActive(active);
		}

		private void OnKeybindingClicked(KeybindingLayoutItemView sender, bool primaryKeybinding)
		{
			SetButtonsActive(active: false);
			ActivateKeyInputPanel(active: true);
			currentKeybindingView = sender;
			primaryKeyBindChanging = primaryKeybinding;
			WaitingForInput = true;
			StartCoroutine(WaitForKeyInput());
		}

		private IEnumerator WaitForKeyInput()
		{
			while (WaitingForInput)
			{
				if (Input.anyKeyDown)
				{
					CheckKeyPressed();
				}
				yield return null;
			}
		}

		private void CheckKeyPressed()
		{
			foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					WaitingForInput = false;
					ActivateKeyInputPanel(active: false);
					SetButtonsActive(active: true);
					break;
				}
				if (MonoSingleton<KeybindingController>.Instance.RestrictedKeys.Contains(value) || !Input.GetKeyDown(value))
				{
					continue;
				}
				WaitingForInput = false;
				ActivateKeyInputPanel(active: false);
				SetButtonsActive(active: true);
				if (value == MonoSingleton<KeybindingController>.Instance.KeybindingCancelKey)
				{
					break;
				}
				RemoveReferencesToKeyCode(value);
				if (keyInputEventByView.ContainsKey(currentKeybindingView))
				{
					int keyInputEvent = keyInputEventByView[currentKeybindingView];
					Keybinding keybinding = MonoSingleton<KeybindingController>.Instance.Keybindings.FirstOrDefault((Keybinding kb) => kb.KeyInputEvent == (KeyInputEvent)keyInputEvent);
					if (keybinding != null)
					{
						UpdateKeybindingItem(keybinding, currentKeybindingView, value, primaryKeyBindChanging);
					}
				}
			}
		}

		private void SetButtonsActive(bool active)
		{
			resetButton.interactable = active;
			cancelButton.interactable = active;
			buttonOk.interactable = active;
		}

		private void Initialize()
		{
			viewByKeyInputEvent = new Dictionary<int, KeybindingLayoutItemView>();
			keyInputEventByView = new Dictionary<KeybindingLayoutItemView, int>();
			string text = string.Empty;
			List<KeyInputEvent> list = new List<KeyInputEvent>();
			foreach (object value in Enum.GetValues(typeof(KeyInputEvent)))
			{
				list.Add((KeyInputEvent)value);
			}
			Keybinding[] keybindings = MonoSingleton<KeybindingController>.Instance.Keybindings;
			for (int i = 0; i < keybindings.Length; i++)
			{
				if (keybindings[i].Group == "Hidden" || !list.Contains(keybindings[i].KeyInputEvent))
				{
					continue;
				}
				if (keybindings[i].Group != text)
				{
					text = keybindings[i].Group;
					if (i > 0)
					{
						UnityEngine.Object.Instantiate(groupTitle, contentGroup.transform).SetText(string.Empty);
					}
					UnityEngine.Object.Instantiate(groupTitle, contentGroup.transform).GetComponent<BasicLayoutItemView>().SetText(base.Localize.GetText("keybinding_group_" + text));
				}
				KeybindingLayoutItemView component = UnityEngine.Object.Instantiate(contentGroup.Prefab, contentGroup.transform).GetComponent<KeybindingLayoutItemView>();
				component.SetKeybindButtonCallback(OnKeybindingClicked);
				component.SetBackground((i + 10) % 2 == 0);
				viewByKeyInputEvent.Add((int)keybindings[i].KeyInputEvent, component);
				keyInputEventByView.Add(component, (int)keybindings[i].KeyInputEvent);
			}
			initialized = true;
			UpdateData();
		}

		private void UpdateData()
		{
			Keybinding[] keybindings = MonoSingleton<KeybindingController>.Instance.Keybindings;
			foreach (Keybinding keybinding in keybindings)
			{
				if (keybinding != null && viewByKeyInputEvent.ContainsKey((int)keybinding.KeyInputEvent))
				{
					viewByKeyInputEvent[(int)keybinding.KeyInputEvent].InitializeText(MonoSingleton<LocalizationController>.Instance.GetText("ctrl_" + keybinding.KeyInputEvent), MonoSingleton<LocalizationController>.Instance.GetText("keycode_" + keybinding.PrimaryKey), MonoSingleton<LocalizationController>.Instance.GetText("keycode_" + keybinding.AlternativeKey));
				}
			}
		}

		private void RemoveReferencesToKeyCode(KeyCode key)
		{
			Keybinding[] keybindings = MonoSingleton<KeybindingController>.Instance.Keybindings;
			foreach (Keybinding keybinding in keybindings)
			{
				if (keybinding != null && viewByKeyInputEvent.ContainsKey((int)keybinding.KeyInputEvent))
				{
					KeybindingLayoutItemView viewItem = viewByKeyInputEvent[(int)keybinding.KeyInputEvent];
					if (keybinding.PrimaryKey == key)
					{
						UpdateKeybindingItem(keybinding, viewItem, KeyCode.None, primary: true);
						break;
					}
					if (keybinding.AlternativeKey == key)
					{
						UpdateKeybindingItem(keybinding, viewItem, KeyCode.None, primary: false);
						break;
					}
				}
			}
		}

		private void UpdateKeybindingItem(Keybinding keybinding, KeybindingLayoutItemView viewItem, KeyCode key, bool primary)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("keycode_" + key);
			if (primary)
			{
				keybinding.SetPrimaryKey(key);
				viewItem.SetPrimaryKeybindText(text);
			}
			else
			{
				keybinding.SetAlternativeKey(key);
				viewItem.SetAlternativeKeybingText(text);
			}
		}
	}
}
