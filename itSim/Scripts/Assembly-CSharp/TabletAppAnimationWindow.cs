using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppAnimationWindow : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseApp_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppAnimationWindow _003C_003E4__this;

		public Action actDone;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CtargetPos_003E5__3;

		private Vector3 _003CstartScale_003E5__4;

		private Vector3 _003CtargetScale_003E5__5;

		private float _003CstartPixelsPerUnit_003E5__6;

		private float _003CtargetPixelsPerUnit_003E5__7;

		private float _003CelapsedTime_003E5__8;

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
		public _003CCloseApp_003Ed__10(int _003C_003E1__state)
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
	private sealed class _003COpenApp_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppAnimationWindow _003C_003E4__this;

		public Action actDone;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CtargetPos_003E5__3;

		private Vector3 _003CstartScale_003E5__4;

		private Vector3 _003CtargetScale_003E5__5;

		private float _003CstartPixelsPerUnit_003E5__6;

		private float _003CtargetPixelsPerUnit_003E5__7;

		private float _003CelapsedTime_003E5__8;

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
		public _003COpenApp_003Ed__9(int _003C_003E1__state)
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

	public RectTransform AppIcon;

	public RectTransform AppCanvasParent;

	public RectTransform AppCanvas;

	public Image AppCanvasImage;

	public float animationDuration;

	public bool isOpen;

	private void Start()
	{
	}

	public void Open(Action actDone = null)
	{
	}

	public void Close(Action actDone = null)
	{
	}

	[IteratorStateMachine(typeof(_003COpenApp_003Ed__9))]
	private IEnumerator OpenApp(Action actDone)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseApp_003Ed__10))]
	private IEnumerator CloseApp(Action actDone)
	{
		return null;
	}
}
