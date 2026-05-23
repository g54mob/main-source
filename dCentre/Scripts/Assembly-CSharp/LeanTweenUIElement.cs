using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LeanTweenUIElement : MonoBehaviour
{
	private enum LeanTweanType
	{
		Horizontal = 0,
		Vertical = 1,
		Scale = 2,
		Rotate = 3
	}

	[CompilerGenerated]
	private sealed class _003CDisabling_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeanTweenUIElement _003C_003E4__this;

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
		public _003CDisabling_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003CKeepRotating_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeanTweenUIElement _003C_003E4__this;

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
		public _003CKeepRotating_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003CTweenScaleInOut_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeanTweenUIElement _003C_003E4__this;

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
		public _003CTweenScaleInOut_003Ed__23(int _003C_003E1__state)
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
	private LeanTweanType leanTweanType;

	[SerializeField]
	private float howFast;

	[SerializeField]
	private float howFar;

	[SerializeField]
	private float startingScale;

	[SerializeField]
	private bool turnOnInput;

	[SerializeField]
	private bool holdInteract;

	private bool isInteractPressed;

	[SerializeField]
	private bool returnBack;

	[SerializeField]
	private float stayTime;

	private float holdSkipButtonTimer;

	[SerializeField]
	private Image skipButtonHoldProgress;

	private Action<InputAction.CallbackContext> waitForPressKeyAction;

	private Action<InputAction.CallbackContext> interactHoldperformed;

	private Action<InputAction.CallbackContext> interactHoldCanceled;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnWaitForPressKey()
	{
	}

	[IteratorStateMachine(typeof(_003CDisabling_003Ed__20))]
	private IEnumerator Disabling()
	{
		return null;
	}

	private void TweenHorizontal(bool leanout)
	{
	}

	private void TweenVertical(bool leanout)
	{
	}

	[IteratorStateMachine(typeof(_003CTweenScaleInOut_003Ed__23))]
	private IEnumerator TweenScaleInOut()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CKeepRotating_003Ed__24))]
	private IEnumerator KeepRotating()
	{
		return null;
	}

	private void OnDestroy()
	{
	}
}
