using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Defeat_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Defeat_Popup _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_Proc_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003CCR_Retry_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_Retry_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowLeaderboard_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Defeat_Popup _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_ShowLeaderboard_003Ed__37(int _003C_003E1__state)
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
	private CanvasGroup canvasGroup;

	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private Button button_BackToTitle;

	[SerializeField]
	private Button button_ShowMap;

	[SerializeField]
	private Button button_ShowMap_Back;

	[SerializeField]
	private GameObject node_JoystickBack;

	[SerializeField]
	private Button button_Retry;

	[SerializeField]
	private UI_LeaderBoard ui_LeaderBoard;

	[SerializeField]
	private TMP_Text text_Defeat;

	[SerializeField]
	private TMP_Text text_ChallengeComplete;

	[SerializeField]
	private TMP_Text text_WaveCleared;

	[SerializeField]
	private TMP_Text text_BestRecord;

	[SerializeField]
	private TMP_Text text_RetryCountLeft;

	[SerializeField]
	private Image image_Defeat_Skull;

	[SerializeField]
	private Image image_Defeat_Ember;

	[SerializeField]
	private Transform node_Exp;

	[SerializeField]
	private Animator animator_Exp;

	[SerializeField]
	private TMP_Text text_Exp;

	[SerializeField]
	private UIButtonNavigationBuilder navigationBuilder;

	public bool isButtonPressed;

	private bool isShowingMap;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Awake()
	{
	}

	private void OnClick_ShowMap()
	{
	}

	private void OnClick_Back()
	{
	}

	private void OnClick_BackToTitle()
	{
	}

	private void OnClick_Retry()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Retry_003Ed__28))]
	private IEnumerator CR_Retry()
	{
		return null;
	}

	private void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void Update()
	{
	}

	public void ToggleShowMap(bool isOn)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__34))]
	private IEnumerator CR_Proc()
	{
		return null;
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public void ShowLeaderboard()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowLeaderboard_003Ed__37))]
	private IEnumerator CR_ShowLeaderboard()
	{
		return null;
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
