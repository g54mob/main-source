using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ParticleTrigger : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CActivateEffectAndDisable_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ParticleTrigger _003C_003E4__this;

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
		public _003CActivateEffectAndDisable_003Ed__7(int _003C_003E1__state)
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

	[Tooltip("The GameObject containing the Particle System (will be enabled/disabled after the duration).")]
	[SerializeField]
	private GameObject effectObjectToEnable;

	[Tooltip("The GHOST GameObject (or any other object) that is enabled immediately upon trigger.")]
	[SerializeField]
	private GameObject ghostObjectToEnable;

	[Tooltip("The tag of the object that activates the trigger (e.g., 'deadrat').")]
	[SerializeField]
	private string targetTag;

	[Tooltip("The duration (in seconds) the effect GameObject stays enabled.")]
	[SerializeField]
	private float effectDuration;

	private bool isTriggered;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003CActivateEffectAndDisable_003Ed__7))]
	private IEnumerator ActivateEffectAndDisable()
	{
		return null;
	}
}
