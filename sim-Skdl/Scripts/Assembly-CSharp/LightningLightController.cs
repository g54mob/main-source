using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LightningLightController : MonoBehaviour
{
	[Serializable]
	public class LightEntry
	{
		public Light light;

		public AnimationCurve flashCurve;

		public float maxIntensity;

		public float strikeDuration;

		public float startDelay;
	}

	[CompilerGenerated]
	private sealed class _003CDoStrikeRoutine_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LightningLightController _003C_003E4__this;

		private float _003CelapsedTime_003E5__2;

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
		public _003CDoStrikeRoutine_003Ed__7(int _003C_003E1__state)
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

	[Header("Light Entries (max 4)")]
	public LightEntry[] lightEntries;

	[Header("Auto-Strike Timing")]
	public float minTimeBetweenStrikes;

	public float maxTimeBetweenStrikes;

	private Coroutine _strikeCo;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CDoStrikeRoutine_003Ed__7))]
	private IEnumerator DoStrikeRoutine()
	{
		return null;
	}
}
