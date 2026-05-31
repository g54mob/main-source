using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EPOOutline;
using UnityEngine;

public class GateLever : Interact
{
	[CompilerGenerated]
	private sealed class _003CGateCoroutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GateLever _003C_003E4__this;

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
		public _003CGateCoroutine_003Ed__15(int _003C_003E1__state)
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

	private Outlinable outlineEffect;

	[SerializeField]
	private GameObject gate;

	[SerializeField]
	private float[] upAndDownPositions;

	[SerializeField]
	private float gateOpenDuration;

	[SerializeField]
	private AudioSource audioSourceGate;

	[SerializeField]
	private AudioSource audioSourceLever;

	[SerializeField]
	private AudioClip audioClipTruckBackingUp;

	[SerializeField]
	private AudioClip audioClipTruckLeaving;

	[SerializeField]
	private AudioClip audioClipGateOpen;

	[SerializeField]
	private AudioClip audioClipLeaver;

	private Animator leverAnimator;

	[SerializeField]
	private Animator secondLeverAnimator;

	private bool isOpeningOrClosing;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	[IteratorStateMachine(typeof(_003CGateCoroutine_003Ed__15))]
	private IEnumerator GateCoroutine()
	{
		return null;
	}

	public void OpenGate()
	{
	}

	public void CloseGate()
	{
	}

	public void TruckComing()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}
}
