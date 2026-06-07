using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : AUISituational
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public bool doRestart;

		internal void _003CCR_QuickRestart_003Eb__0(bool result)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public bool doBackToTitle;

		internal void _003CCR_BackToTitle_003Eb__0(bool result)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_BackToTitle_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_PauseMenu _003C_003E4__this;

		private _003C_003Ec__DisplayClass22_0 _003C_003E8__1;

		private UI_Window_YesNo_Popup _003Cwindow_003E5__2;

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
		public _003CCR_BackToTitle_003Ed__22(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_QuickRestart_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_PauseMenu _003C_003E4__this;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

		private UI_Window_YesNo_Popup _003Cwindow_003E5__2;

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
		public _003CCR_QuickRestart_003Ed__17(int _003C_003E1__state)
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

	[SerializeField]
	private Button button_Resume;

	[SerializeField]
	private Button button_QuickRestart;

	[SerializeField]
	private Button button_Settings;

	[SerializeField]
	private Button button_Help;

	[SerializeField]
	private Button button_MainMenu;

	private bool isSettingWindowOn;

	private bool isConfirmWindowOn;

	private float timeSinceUIOpen;

	private bool isQuickRestarting;

	private GameObject lastSelectedGameObject;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTogglePauseMenu(bool isOn)
	{
	}

	private void OnClickButton_Resume()
	{
	}

	private void OnClickButton_QuickRestart()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_QuickRestart_003Ed__17))]
	private IEnumerator CR_QuickRestart()
	{
		return null;
	}

	private void OnClickButton_Settings()
	{
	}

	private void OnSettingWindowFinished()
	{
	}

	private void OnClickButton_Help()
	{
	}

	private void OnClickButton_MainMenu()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BackToTitle_003Ed__22))]
	private IEnumerator CR_BackToTitle()
	{
		return null;
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}
}
