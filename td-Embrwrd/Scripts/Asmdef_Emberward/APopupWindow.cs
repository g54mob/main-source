using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public abstract class APopupWindow : AUI, IControllerSupportUI
{
	public enum ePopupWindowLayer
	{
		MID = 0,
		TOP = 1,
		SYSTEM_TOP = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_CloseWindow_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public APopupWindow _003C_003E4__this;

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
		public _003CCR_CloseWindow_003Ed__28(int _003C_003E1__state)
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
	protected Animator animator;

	[SerializeField]
	protected float waitDestroyTime;

	[SerializeField]
	protected bool doSwitchControlSchemeOnOpen;

	[SerializeField]
	protected eControlScheme controlSchemeOnOpen;

	protected bool isClosed;

	private bool isDestroyed;

	public Action OnWindowFinished;

	protected GameObject lastSelectedGameObject;

	public bool IsWindowClosed => false;

	public bool IsWindowFinished { get; private set; }

	public bool IsTopWindow => false;

	public static T CreateWindow<T>(ePopupWindowLayer layer, Transform parent = null, bool setFullScreen = false) where T : APopupWindow
	{
		return null;
	}

	protected virtual void Start()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	private void OnInputSourceChanged_Interface(ControllerType controllerType)
	{
	}

	public void ShowWindow()
	{
	}

	protected abstract void ShowWindowProc();

	public void CloseWindow()
	{
	}

	protected abstract void CloseWindowProc();

	[IteratorStateMachine(typeof(_003CCR_CloseWindow_003Ed__28))]
	private IEnumerator CR_CloseWindow()
	{
		return null;
	}

	public void OverrideIsWindowFinished(bool IsFinished)
	{
	}

	public virtual void OnWindowLostFocus()
	{
	}

	public virtual void OnWindowRegainFocus()
	{
	}

	public virtual void DestroyWindow()
	{
	}

	private void OnDestroy()
	{
	}

	public abstract void OnJoystickModeActivated();

	public abstract void OnMouseModeActivated();

	public void RebuildNavigation(List<Selectable> list_NavigationTargets)
	{
	}

	public void UpdateLastSelectedGameObject()
	{
	}
}
