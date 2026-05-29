using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppSettings : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAirplaneModeCoroutine_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public TabletAppSettings _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

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
		public _003CAirplaneModeCoroutine_003Ed__14(int _003C_003E1__state)
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
	private sealed class _003CViewOpenCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public GameObject view;

		public TabletAppSettings _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

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
		public _003CViewOpenCoroutine_003Ed__13(int _003C_003E1__state)
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

	public TabletDevice tabletDevice;

	[Header("Tablet Components")]
	public TabletAppSettings_Wallpaper wallpaper;

	public TabletDeviceWiFiAdapter tabletDeviceWiFiAdapter;

	[Header("Airplane Mode")]
	public RectTransform dotAirplaneMode;

	public Image bgDotAirplaneMode;

	[HideInInspector]
	public bool AirplaneMode;

	[HideInInspector]
	public bool isCoroutineEnded;

	[HideInInspector]
	public Coroutine openCoroutine;

	[HideInInspector]
	public Coroutine turnonofAirPlaneCoroutine;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void TurnOnOrOffAirplaneMode()
	{
	}

	[IteratorStateMachine(typeof(_003CViewOpenCoroutine_003Ed__13))]
	public IEnumerator ViewOpenCoroutine(RectTransform obj, GameObject view, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAirplaneModeCoroutine_003Ed__14))]
	public IEnumerator AirplaneModeCoroutine(RectTransform obj, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}
}
