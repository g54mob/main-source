using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace __Project__.Scripts.ControllerInputModule
{
	public class ControllerInputManager : NoktaSingleton<ControllerInputManager>
	{
		public Action<bool> gamePadConnected;

		public EventSystem gamepadEventSystem;

		public EventSystem mouseKeyboardEventSystem;

		public bool isConsoleTest;

		public Material outlineMaterial;

		private bool m_WillShowHighlight;

		[HideInInspector]
		public List<GamepadUISelectable> allCreatedSelectables;

		public GamePadUIPanel lastComputerPanel;

		public GamePadUIPanel lastStandardPanel;

		private bool m_isControllerConnected;

		private GameObject m_previousSelectedObject;

		private bool m_isInitialized;

		[SerializeField]
		private PlayerInput m_playerInput;

		public bool WillShowHighlight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsControllerConnected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsPausePanelOpen => false;

		public GameObject SelectedObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void ChangeUIInputHandler(PlayerInput playerInput)
		{
		}

		public void RefreshUIInputHandler()
		{
		}

		public void OnDeviceChange(InputDevice inputDevice, InputDeviceChange inputDeviceChange)
		{
		}

		public void OnDeviceRegained(PlayerInput playerInput)
		{
		}

		public void OnDeviceLost(PlayerInput playerInput)
		{
		}

		public void ApplicationFocusChange(bool focus)
		{
		}

		private void DeselectPreviousSelectedObject(GameObject currentSelected)
		{
		}

		public void SetHighlightPosition(GamepadUISelectable selectable)
		{
		}

		private void SwitchHighlightObject(bool isGamepad)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
