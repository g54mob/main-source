using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayLoadWarningInfo : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseUIAnimation_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuPlayLoadWarningInfo _003C_003E4__this;

		public Action actAccept;

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
		public _003CCloseUIAnimation_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003COpenUIAnimation_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuPlayLoadWarningInfo _003C_003E4__this;

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
		public _003COpenUIAnimation_003Ed__17(int _003C_003E1__state)
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

	public static MenuPlayLoadWarningInfo Instance;

	[Header("References")]
	public RectTransform mainWindowLayout;

	public Image backgroundImage;

	public RectTransform windowPanel;

	public TMP_Text description;

	[Header("Animation Settings")]
	public float backgroundFadeTime;

	public float windowMoveDelay;

	public float windowMoveTime;

	public Vector2 hiddenPosition;

	public Vector2 visiblePosition;

	private Action acceptAction;

	private void Awake()
	{
	}

	public void RunOpen(Action actAccept, string saveVersionGame)
	{
	}

	private string CustomFormat(string text, params string[] args)
	{
		return null;
	}

	public void RunClose(Action actAccept)
	{
	}

	public void Close()
	{
	}

	public void Accept()
	{
	}

	[IteratorStateMachine(typeof(_003COpenUIAnimation_003Ed__17))]
	private IEnumerator OpenUIAnimation()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseUIAnimation_003Ed__18))]
	private IEnumerator CloseUIAnimation(Action actAccept)
	{
		return null;
	}
}
