using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class ControllerManager : MonoBehaviour
	{
		public static ControllerManager instance;

		public ControllerPresetManager presetManager;

		public GameObject firstSelected;

		public List<PanelManager> panels = new List<PanelManager>();

		public List<ButtonManager> buttons = new List<ButtonManager>();

		public List<BoxButtonManager> boxButtons = new List<BoxButtonManager>();

		public List<ShopButtonManager> shopButtons = new List<ShopButtonManager>();

		public List<SettingsElement> settingsElements = new List<SettingsElement>();

		[Tooltip("Objects in this list will be enabled when the gamepad is un-plugged.")]
		public List<GameObject> keyboardObjects = new List<GameObject>();

		[Tooltip("Objects in this list will be enabled when the gamepad is plugged.")]
		public List<GameObject> gamepadObjects = new List<GameObject>();

		public List<HotkeyEvent> hotkeyObjects = new List<HotkeyEvent>();

		[Tooltip("Checks for input changes each frame.")]
		public bool alwaysUpdate = true;

		public bool affectCursor = true;

		public InputAction gamepadHotkey;

		private Vector3 cursorPos;

		private Vector3 lastCursorPos;

		private Navigation customNav;

		[HideInInspector]
		public int currentManagerIndex;

		[HideInInspector]
		public bool gamepadConnected;

		[HideInInspector]
		public bool gamepadEnabled;

		[HideInInspector]
		public bool keyboardEnabled;

		[HideInInspector]
		public float hAxis;

		[HideInInspector]
		public float vAxis;

		[HideInInspector]
		public string currentController;

		[HideInInspector]
		public ControllerPreset currentControllerPreset;

		private void Awake()
		{
			instance = this;
		}

		private void Start()
		{
			InitInput();
		}

		private void Update()
		{
			if (alwaysUpdate)
			{
				CheckForController();
				CheckForEmptyObject();
			}
		}

		private void InitInput()
		{
			gamepadHotkey.Enable();
			if (Gamepad.current == null)
			{
				gamepadConnected = false;
				SwitchToKeyboard();
			}
			else
			{
				gamepadConnected = true;
				SwitchToGamepad();
			}
		}

		private void CheckForEmptyObject()
		{
			if (gamepadEnabled && (!(EventSystem.current.currentSelectedGameObject != null) || !EventSystem.current.currentSelectedGameObject.gameObject.activeInHierarchy) && gamepadHotkey.triggered && panels.Count != 0 && panels[currentManagerIndex].panels[panels[currentManagerIndex].currentPanelIndex].firstSelected != null)
			{
				SelectUIObject(panels[currentManagerIndex].panels[panels[currentManagerIndex].currentPanelIndex].firstSelected);
			}
		}

		public void CheckForController()
		{
			if (Gamepad.current == null)
			{
				gamepadConnected = false;
			}
			else
			{
				gamepadConnected = true;
				hAxis = Gamepad.current.rightStick.x.ReadValue();
				vAxis = Gamepad.current.rightStick.y.ReadValue();
			}
			if (Mouse.current != null)
			{
				cursorPos = Mouse.current.position.ReadValue();
			}
			if (gamepadConnected && gamepadEnabled && !keyboardEnabled && cursorPos != lastCursorPos)
			{
				SwitchToKeyboard();
			}
			else if (gamepadConnected && !gamepadEnabled && keyboardEnabled && gamepadHotkey.triggered)
			{
				SwitchToGamepad();
			}
			else if (!gamepadConnected && !keyboardEnabled)
			{
				SwitchToKeyboard();
			}
		}

		private void CheckForCurrentObject()
		{
			if ((EventSystem.current.currentSelectedGameObject == null || !EventSystem.current.currentSelectedGameObject.activeInHierarchy) && panels.Count != 0)
			{
				SelectUIObject(panels[currentManagerIndex].panels[panels[currentManagerIndex].currentPanelIndex].firstSelected);
			}
		}

		public void SwitchToGamepad()
		{
			if (affectCursor)
			{
				Cursor.visible = false;
			}
			for (int i = 0; i < keyboardObjects.Count; i++)
			{
				if (!(keyboardObjects[i] == null))
				{
					keyboardObjects[i].SetActive(value: false);
				}
			}
			for (int j = 0; j < gamepadObjects.Count; j++)
			{
				if (!(gamepadObjects[j] == null))
				{
					gamepadObjects[j].SetActive(value: true);
					LayoutRebuilder.ForceRebuildLayoutImmediate(gamepadObjects[j].GetComponentInParent<RectTransform>());
				}
			}
			customNav.mode = Navigation.Mode.Automatic;
			for (int k = 0; k < buttons.Count; k++)
			{
				if (buttons[k] != null && !buttons[k].useUINavigation)
				{
					buttons[k].AddUINavigation();
				}
			}
			for (int l = 0; l < boxButtons.Count; l++)
			{
				if (boxButtons[l] != null && !boxButtons[l].useUINavigation)
				{
					boxButtons[l].AddUINavigation();
				}
			}
			for (int m = 0; m < shopButtons.Count; m++)
			{
				if (shopButtons[m] != null && !shopButtons[m].useUINavigation)
				{
					shopButtons[m].AddUINavigation();
				}
			}
			for (int n = 0; n < settingsElements.Count; n++)
			{
				if (settingsElements[n] != null && !settingsElements[n].useUINavigation)
				{
					settingsElements[n].AddUINavigation();
				}
			}
			gamepadEnabled = true;
			keyboardEnabled = false;
			if (Mouse.current != null)
			{
				lastCursorPos = Mouse.current.position.ReadValue();
			}
			CheckForGamepadType();
			CheckForCurrentObject();
		}

		private void CheckForGamepadType()
		{
			if (Gamepad.current == null)
			{
				return;
			}
			currentController = Gamepad.current.displayName;
			if (Gamepad.current is XInputController && presetManager != null && presetManager.xboxPreset != null)
			{
				currentControllerPreset = presetManager.xboxPreset;
			}
			else if (Gamepad.current is DualSenseGamepadHID && presetManager != null && presetManager.dualsensePreset != null)
			{
				currentControllerPreset = presetManager.dualsensePreset;
			}
			else
			{
				for (int i = 0; i < presetManager.customPresets.Count; i++)
				{
					if (currentController == presetManager.customPresets[i].controllerName)
					{
						currentControllerPreset = presetManager.customPresets[i];
						break;
					}
				}
			}
			foreach (HotkeyEvent hotkeyObject in hotkeyObjects)
			{
				if (!(hotkeyObject == null))
				{
					hotkeyObject.controllerPreset = currentControllerPreset;
					hotkeyObject.UpdateUI();
				}
			}
		}

		public void SwitchToKeyboard()
		{
			if (affectCursor)
			{
				Cursor.visible = true;
			}
			if (presetManager != null && presetManager.keyboardPreset != null)
			{
				currentControllerPreset = presetManager.keyboardPreset;
				foreach (HotkeyEvent hotkeyObject in hotkeyObjects)
				{
					if (!(hotkeyObject == null))
					{
						hotkeyObject.controllerPreset = currentControllerPreset;
						hotkeyObject.UpdateUI();
					}
				}
			}
			for (int i = 0; i < gamepadObjects.Count; i++)
			{
				if (!(gamepadObjects[i] == null))
				{
					gamepadObjects[i].SetActive(value: false);
				}
			}
			for (int j = 0; j < keyboardObjects.Count; j++)
			{
				if (!(keyboardObjects[j] == null))
				{
					keyboardObjects[j].SetActive(value: true);
					LayoutRebuilder.ForceRebuildLayoutImmediate(keyboardObjects[j].GetComponentInParent<RectTransform>());
				}
			}
			customNav.mode = Navigation.Mode.None;
			for (int k = 0; k < buttons.Count; k++)
			{
				if (buttons[k] != null && !buttons[k].useUINavigation)
				{
					buttons[k].DisableUINavigation();
				}
			}
			for (int l = 0; l < boxButtons.Count; l++)
			{
				if (boxButtons[l] != null && !boxButtons[l].useUINavigation)
				{
					boxButtons[l].DisableUINavigation();
				}
			}
			for (int m = 0; m < shopButtons.Count; m++)
			{
				if (shopButtons[m] != null && !shopButtons[m].useUINavigation)
				{
					shopButtons[m].DisableUINavigation();
				}
			}
			for (int n = 0; n < settingsElements.Count; n++)
			{
				if (settingsElements[n] != null && !settingsElements[n].useUINavigation)
				{
					settingsElements[n].DisableUINavigation();
				}
			}
			gamepadEnabled = false;
			keyboardEnabled = true;
		}

		public void SelectUIObject(GameObject tempObj)
		{
			if (gamepadEnabled && !(tempObj == null))
			{
				EventSystem.current.SetSelectedGameObject(tempObj.gameObject);
			}
		}
	}
}
