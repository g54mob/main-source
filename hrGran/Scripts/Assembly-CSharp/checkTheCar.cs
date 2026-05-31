using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class checkTheCar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CstartEngine_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public checkTheCar _003C_003E4__this;

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
		public _003CstartEngine_003Ed__24(int _003C_003E1__state)
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

	public GameObject granny;

	public bool batteryOK;

	public bool topplockOK;

	public bool sparkplugOK;

	public bool fuelOK;

	public bool playerHaveCarKey;

	public float topplocksskruvar;

	public GameObject startButton;

	public GameObject forwardButton;

	public GameObject reverseButton;

	public bool forwardOK;

	public bool reverseOK;

	public bool engineOn;

	public GameObject engineStartSound;

	public GameObject engineOnSound;

	public GameObject outOffCarButton;

	public GameObject canNotStartCarText;

	public GameObject needCarKeyText;

	public bool textTimerOnOff;

	public float textTimer;

	public bool carMoving;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void startCar()
	{
	}

	[IteratorStateMachine(typeof(_003CstartEngine_003Ed__24))]
	public virtual IEnumerator startEngine()
	{
		return null;
	}
}
