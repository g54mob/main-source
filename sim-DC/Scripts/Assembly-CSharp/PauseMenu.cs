using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public delegate void OnPauseMenuOpen();

	public delegate void OnPauseMenuClose();

	[CompilerGenerated]
	private sealed class _003CLoadWithOverlay_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PauseMenu _003C_003E4__this;

		public string savename;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLoadWithOverlay_003Ed__45(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public GameObject pauseMenuUI;

	public Player playerClass;

	public InputController inputctrl;

	[SerializeField]
	private GameObject canvasOverlay;

	[SerializeField]
	private GameObject loadSaveOverlay;

	[SerializeField]
	private TextMeshProUGUI loadSaveOverlayTopText;

	[SerializeField]
	private GameObject[] loadSaveSlots;

	[SerializeField]
	private GameObject saveConfirmOverlay;

	[SerializeField]
	private GameObject saveNameSetOverlay;

	[SerializeField]
	private TMP_InputField saveNameInputField;

	[SerializeField]
	private GameObject notAllowedSaveOverlay;

	[SerializeField]
	private GameObject deleteSaveConfirmOverlay;

	private Canvas pauseMenuCanvas;

	private string saveToDelete;

	[SerializeField]
	private GameObject resumeButton;

	[SerializeField]
	private PauseMenu_TabGroup mainPauseMenuTabGroup;

	[SerializeField]
	private PauseMenu_TabButton systemMenuTab;

	[SerializeField]
	private PauseMenu_TabGroup systemPauseMenuTabGroup;

	[SerializeField]
	private PauseMenu_TabButton subSystemMenuTab;

	[SerializeField]
	private ButtonExtended firstLoadSaveSlot;

	[Header("Console")]
	[SerializeField]
	private GameObject consoleGameObject;

	[SerializeField]
	private TMP_InputField consoleInputField;

	public bool savingGame;

	public static OnPauseMenuOpen onPauseMenuOpenCallback;

	public static OnPauseMenuClose onPauseMenuCloseCallback;

	private Action<InputAction.CallbackContext> pausePerformed;

	private Action<InputAction.CallbackContext> tutorialPerformed;

	private Action<InputAction.CallbackContext> consolePerformed;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPause(int openMenu)
	{
	}

	public void Resume()
	{
	}

	public void PopulateLoadSaveMenu(bool _savingGame)
	{
	}

	public void LoadSaveOnButtonClick(TextMeshProUGUI _text)
	{
	}

	public void NotAllowedToSaveOverlayOff()
	{
	}

	public void SaveConfirm(bool yes)
	{
	}

	public void ButtonSetNameOfSave()
	{
	}

	public void Save(string saveName = null, string _stringNameOfSave = null)
	{
	}

	public void DeleteSaveButtonClick(TextMeshProUGUI _text)
	{
	}

	public void DeleteSaveConfirm(bool yes)
	{
	}

	public void Load(string savename)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadWithOverlay_003Ed__45))]
	private IEnumerator LoadWithOverlay(string savename)
	{
		return null;
	}

	private void Pause(int openMenu)
	{
	}

	public void MainMenu()
	{
	}

	public void ExitGame()
	{
	}

	public void CloseLoadSaveOverlay()
	{
	}

	private void ProcessConsoleCommand(string input)
	{
	}

	private void HandleAddCommand(string[] parts)
	{
	}
}
