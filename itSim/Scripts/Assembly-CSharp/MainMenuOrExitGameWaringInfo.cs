using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuOrExitGameWaringInfo : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseUIAnimation_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Image background;

		public MainMenuOrExitGameWaringInfo _003C_003E4__this;

		public RectTransform windowPanel;

		public RectTransform viewLayout;

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
		public _003CCloseUIAnimation_003Ed__13(int _003C_003E1__state)
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
	private sealed class _003COpenUIAnimation_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Image background;

		public RectTransform windowPanel;

		public MainMenuOrExitGameWaringInfo _003C_003E4__this;

		public int idButton;

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
		public _003COpenUIAnimation_003Ed__12(int _003C_003E1__state)
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

	[Header("References")]
	public RectTransform mainMenuWindowLayout;

	public Image mainMenubackgroundImage;

	public RectTransform mainMenuwindowPanel;

	public GameObject[] buttons;

	[Header("Animation Settings")]
	public float backgroundFadeTime;

	public float windowMoveDelay;

	public float windowMoveTime;

	public Vector2 hiddenPosition;

	public Vector2 visiblePosition;

	public void MainMenu()
	{
	}

	public void ExitGame()
	{
	}

	public void CloseWarningWeStay()
	{
	}

	[IteratorStateMachine(typeof(_003COpenUIAnimation_003Ed__12))]
	private IEnumerator OpenUIAnimation(RectTransform viewLayout, Image background, RectTransform windowPanel, int idButton)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseUIAnimation_003Ed__13))]
	private IEnumerator CloseUIAnimation(RectTransform viewLayout, Image background, RectTransform windowPanel)
	{
		return null;
	}
}
