using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppSettings_Battery : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COptimizedChargingCoroutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public TabletAppSettings_Battery _003C_003E4__this;

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
		public _003COptimizedChargingCoroutine_003Ed__11(int _003C_003E1__state)
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

	[Header("Components")]
	public TabletAppSettings settings;

	public RectTransform This_Settings;

	public GameObject This_Settings_View;

	[Header("Optimized charging")]
	public RectTransform dotOptimizedCharging;

	public Image bgDotOptimizedCharging;

	[HideInInspector]
	public bool OptimizedCharging;

	[HideInInspector]
	public bool isCoroutineEnded;

	[HideInInspector]
	public Coroutine turnonofOptimizedChargingCoroutine;

	public void OpenThisView()
	{
	}

	public void CloseThisView()
	{
	}

	public void TurnOnOrOffOptimizedCharging()
	{
	}

	[IteratorStateMachine(typeof(_003COptimizedChargingCoroutine_003Ed__11))]
	public IEnumerator OptimizedChargingCoroutine(RectTransform obj, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}
}
