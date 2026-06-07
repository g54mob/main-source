using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace ScheduleOne
{
	public class UIScreenManager : PersistentSingleton<UIScreenManager>
	{
		public struct UIScreenInfo
		{
			public UIScreen screen;

			public Action onCloseCallback;
		}

		public const float NavigationRepeatDelay = 0.5f;

		public const float NavigationRepeatRate = 0.125f;

		public const float DefaultScrollSpeed = 0.15f;

		public const float ScrollbarScrollSpeed = 25f;

		[SerializeField]
		private UIPopupScreen[] popupScreenPrefabs;

		[Tooltip("Default 'A' button on controller for basic selectable interaction. Used in UITrigger")]
		[SerializeField]
		private InputActionReference submitInputAction;

		[Tooltip("Default 'B' button on controller, RightMouseButton for back interaction. Used in UIScreenManager")]
		[SerializeField]
		private InputActionReference backInputAction;

		[Tooltip("Default 'Start' button on controller, Escape key for back interaction. Used in UIScreenManager")]
		[SerializeField]
		private InputActionReference escapeInputAction;

		private List<UIPopupScreen> popupScreenInstances;

		private Stack<UIScreenInfo> screenStack;

		private static GameObject lastSelectedObject;

		private static bool isBackTriggeredThisFrame;

		public InputActionReference SubmitInputAction => null;

		public static GameObject LastSelectedObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool IsBackTriggeredThisFrame => false;

		public UIScreen TopScreen => null;

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void BackToCloseCurrentScreen()
		{
		}

		public bool IsActiveScreenRegisteredForBack()
		{
			return false;
		}

		private void HandleInputDeviceChanged(GameInput.InputDeviceType type)
		{
		}

		private void CheckInputDeviceMode()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		public void AddScreen(UIScreen screen, Action onCloseCallback = null)
		{
		}

		public void RemoveScreen(UIScreen screen)
		{
		}

		private bool IsScreenInStack(UIScreen screen)
		{
			return false;
		}

		public bool IsAnyScreenActive()
		{
			return false;
		}

		public bool IsAnyPopupScreenActive()
		{
			return false;
		}

		public void OpenPopupScreen(string popupID)
		{
		}

		public void OpenPopupScreen(string popupID, params object[] args)
		{
		}

		public void ClosePopupScreen(string popupID)
		{
		}

		private UIPopupScreen FindPopupScreen(string popupID)
		{
			return null;
		}
	}
}
