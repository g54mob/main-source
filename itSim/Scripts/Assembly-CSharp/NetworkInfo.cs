using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NetworkInfo : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimate_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkInfo _003C_003E4__this;

		private Vector2 _003CtargetPosition_003E5__2;

		private float _003CmoveDuration_003E5__3;

		private float _003CelapsedTime_003E5__4;

		private Vector2 _003CtargetSize_003E5__5;

		private float _003CresizeDuration_003E5__6;

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
		public _003CAnimate_003Ed__6(int _003C_003E1__state)
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
	private sealed class _003CCloseAnimate_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkInfo _003C_003E4__this;

		private Vector2 _003CtargetSize_003E5__2;

		private float _003CresizeDuration_003E5__3;

		private float _003CelapsedTime_003E5__4;

		private Vector2 _003CtargetPosition_003E5__5;

		private float _003CmoveDuration_003E5__6;

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
		public _003CCloseAnimate_003Ed__7(int _003C_003E1__state)
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

	public GameObject hiddenObject;

	public GameObject elementsHidden;

	private RectTransform rectTransform;

	private Vector2 originalPosition;

	private int openOption;

	public void AnimateObjectOnClick()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimate_003Ed__6))]
	private IEnumerator Animate()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseAnimate_003Ed__7))]
	private IEnumerator CloseAnimate()
	{
		return null;
	}

	public void CloseInformation()
	{
	}
}
