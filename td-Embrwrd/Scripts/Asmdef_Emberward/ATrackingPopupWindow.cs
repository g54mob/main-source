using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class ATrackingPopupWindow : AUI
{
	public enum ePopupWindowLayer
	{
		MID = 0,
		TOP = 1,
		SYSTEM_TOP = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_CloseWindow_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ATrackingPopupWindow _003C_003E4__this;

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
		public _003CCR_CloseWindow_003Ed__25(int _003C_003E1__state)
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

	protected bool isClosed;

	private bool isDestroyed;

	public Action OnWindowFinished;

	private Transform trackTarget;

	private Vector3 offset;

	private bool isInitialized;

	public bool IsWindowClosed => false;

	public bool IsWindowFinished { get; private set; }

	public static T CreateWindow<T>(ePopupWindowLayer layer, Transform trackTarget, Vector3 offset, Transform parent = null, bool setFullScreen = false) where T : ATrackingPopupWindow
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

	public void ShowWindow()
	{
	}

	protected abstract void ShowWindowProc();

	public void CloseWindow()
	{
	}

	protected abstract void CloseWindowProc();

	[IteratorStateMachine(typeof(_003CCR_CloseWindow_003Ed__25))]
	private IEnumerator CR_CloseWindow()
	{
		return null;
	}

	public void OverrideIsWindowFinished(bool IsFinished)
	{
	}

	public virtual void DestroyWindow()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetTrackTarget(Transform target, Vector3 offset)
	{
	}

	protected virtual void Update()
	{
	}

	protected virtual void UpdateProc()
	{
	}
}
