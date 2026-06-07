using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class carBackSensor : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnTriggerEnter_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Collider other;

		public carBackSensor _003C_003E4__this;

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
		public _003COnTriggerEnter_003Ed__13(int _003C_003E1__state)
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

	public GameObject gameController;

	public GameObject forwardButton;

	public GameObject ReverseButton;

	public GameObject baklucka;

	public bool bakluckaLoss;

	public GameObject outOffCarButton;

	public GameObject headAnim;

	public GameObject carReverseSound1;

	public GameObject engineOnSound;

	public GameObject crashSound;

	public GameObject CarHitTriggers;

	public GameObject optionButton;

	public GameObject granny;

	[IteratorStateMachine(typeof(_003COnTriggerEnter_003Ed__13))]
	public virtual IEnumerator OnTriggerEnter(Collider other)
	{
		return null;
	}
}
