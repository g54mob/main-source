using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TabletAppFile : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CViewOpenCoroutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppFile _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		public bool closedNow;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003CViewOpenCoroutine_003Ed__20(int _003C_003E1__state)
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

	[Header("Window Components")]
	public TabletAppAnimationWindow tabletAppAnimationWindow;

	public TabletAppFileCloud tabletAppFileCloud;

	public TabletAppFileStorage tabletAppFileStorage;

	public RectTransform InMyDevice;

	public RectTransform Cloud;

	public RectTransform LastDeleted;

	public GameObject inMyDeviceView;

	public GameObject cloudView;

	public GameObject lastDeletedView;

	private bool isCoroutineEnded;

	public Coroutine showorhideMenuCoroutine;

	public List<FileSystemObject> tabletStorage;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void ShowInMyDevice()
	{
	}

	public void CloseInMyDevice()
	{
	}

	public void ShowCloud()
	{
	}

	public void CloseCloud()
	{
	}

	public void ShowLastDeleted()
	{
	}

	public void CloseLastDeleted()
	{
	}

	[IteratorStateMachine(typeof(_003CViewOpenCoroutine_003Ed__20))]
	private IEnumerator ViewOpenCoroutine(RectTransform obj, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}
}
