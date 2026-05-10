using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class WarningScreen : MonoBehaviour, IPopUp
{
	[CompilerGenerated]
	private sealed class _003CCheckGamepadFocus_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WarningScreen _003C_003E4__this;

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
		public _003CCheckGamepadFocus_003Ed__12(int _003C_003E1__state)
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

	private bool m_CameraControllerEnabled;

	private bool m_MovementControllerEnabled;

	private bool m_isShowing;

	private Coroutine m_GamepadCheckRoutine;

	[SerializeField]
	private GamePadUIPanel m_gamePadUIPanel;

	public Button CloseButton;

	public bool Show
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void OnEnable()
	{
	}

	private void OnEscape()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckGamepadFocus_003Ed__12))]
	private IEnumerator CheckGamepadFocus()
	{
		return null;
	}

	private void SetCursor(bool isGamepad)
	{
	}
}
