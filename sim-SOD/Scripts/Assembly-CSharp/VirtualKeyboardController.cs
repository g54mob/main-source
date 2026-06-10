using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VirtualKeyboardController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnumerateLines_003Ed__41 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private TMP_Text text;

		public TMP_Text _003C_003E3__text;

		private TMP_TextInfo _003CtextInfo_003E5__2;

		private int _003Ci_003E5__3;

		string IEnumerator<string>.Current
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
		public _003CEnumerateLines_003Ed__41(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public List<ButtonController> keyboardButtons;

	public Image capsToggle;

	public Sprite capsSprite;

	public Sprite lowerCaseSprite;

	private static VirtualKeyboardController _instance;

	public bool isActive;

	public GameObject keyboardCanvas;

	public TMP_Text keyboardLabelText;

	public TMP_InputField virtualInputField;

	private TMP_InputField _targetInputField;

	private int _lineIndex;

	public int cursorIndex;

	private Rewired.Player _player;

	public ButtonController defaultButton;

	public bool isCapsLock;

	public bool isSymbols;

	public bool isSingleLine;

	public bool forceSteamInput;

	public ButtonController lineBreakButton;

	private Callback<GamepadTextInputDismissed_t> _gamepadTextInputDismissed;

	private Callback<FloatingGamepadTextInputDismissed_t> _floatingGamepadTextInputDismissed;

	public bool steamKeyboardLaunched;

	public TMP_Text apiText;

	public TMP_Text keyboardText;

	public static VirtualKeyboardController Instance { get; private set; }

	private void OnEnable()
	{
	}

	private void OnFloatingGamepadTextInputDismissed(FloatingGamepadTextInputDismissed_t callback)
	{
	}

	private void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t callback)
	{
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

	private void ProcessHotkeys()
	{
	}

	private void SetButtonIcon(ButtonController buttonController, InteractablePreset.InteractionKey key, UnityAction action)
	{
	}

	public void SetCaretVisible(int pos)
	{
	}

	public void ToggleSymbols()
	{
	}

	public void ToggleCapsLock()
	{
	}

	public void EnterLineBreak()
	{
	}

	public void MoveCursorUp()
	{
	}

	[IteratorStateMachine(typeof(_003CEnumerateLines_003Ed__41))]
	private IEnumerable<string> EnumerateLines(TMP_Text text)
	{
		return null;
	}

	public void ForceSteamApiCall()
	{
	}

	public void ActivateVirtualKeyboard(bool isMultiline, string labelText = "", string existingText = "")
	{
	}

	public void DeactivateVirtualKeyboard()
	{
	}

	public void SendStringToVirtualKeyboardInput(string letter)
	{
	}

	public void InitializeTextFromTarget(TMP_InputField originInputField, string targetText)
	{
	}

	public void UpdateVirtualKeyboardLabel(string labelText)
	{
	}

	public void SubmitText()
	{
	}

	private void ResetIndexes()
	{
	}

	public void SelectOnAwake()
	{
	}

	public void Backspace()
	{
	}

	public void MoveCursorBack()
	{
	}

	public void SpaceBar()
	{
	}

	public void MoveCursorForward()
	{
	}
}
