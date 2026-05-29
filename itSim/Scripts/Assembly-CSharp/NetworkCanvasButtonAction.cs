using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class NetworkCanvasButtonAction : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeAlert_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkCanvasButtonAction _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private Color _003CstartColor_003E5__3;

		private Color _003CendColor_003E5__4;

		private float _003Celapsed_003E5__5;

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
		public _003CFadeAlert_003Ed__13(int _003C_003E1__state)
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

	public Action ActionConnect;

	public Action ActionDisconnect;

	public RectTransform UiCanvas;

	public RectTransform UiButtonConnect;

	public RectTransform UiButtonDisconnect;

	private Coroutine currentCoroutineAlert;

	public TMP_Text alertUI;

	public void ButtonConnect()
	{
	}

	public void ButtonDisconnect()
	{
	}

	public void SetActiveCanvas(bool active)
	{
	}

	public void SetActiveButtonConnect(bool active)
	{
	}

	public void SetActiveButtonDisconnect(bool active)
	{
	}

	public void SetAlert(string des)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeAlert_003Ed__13))]
	private IEnumerator FadeAlert()
	{
		return null;
	}
}
