using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FridgeDoorLightController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLightOffDelay_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FridgeDoorLightController _003C_003E4__this;

		private float _003Ctimer_003E5__2;

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
		public _003CLightOffDelay_003Ed__5(int _003C_003E1__state)
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

	public GameObject lightContainer;

	public InteractableController ic;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnSwitchStateChange()
	{
	}

	[IteratorStateMachine(typeof(_003CLightOffDelay_003Ed__5))]
	private IEnumerator LightOffDelay()
	{
		return null;
	}
}
