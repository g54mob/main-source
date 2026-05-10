using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Audio;
using ScheduleOne.Interaction;
using ScheduleOne.Lighting;
using ScheduleOne.ScriptableObjects;
using UnityEngine;

namespace ScheduleOne.Calling
{
	public class PayPhone : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPeriodicRing_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PayPhone _003C_003E4__this;

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
			public _003CPeriodicRing_003Ed__18(int _003C_003E1__state)
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

		public const float RING_INTERVAL = 4f;

		public const float RING_RANGE = 9f;

		public PhoneCallData QueuedCall;

		public PhoneCallData ActiveCall;

		public BlinkingLight Light;

		public AudioSourceController RingSound;

		public AudioSourceController AnswerSound;

		public InteractableObject IntObj;

		public Transform CameraPosition;

		private float lastRingTime;

		private const float ringRangeSquared = 81f;

		private Coroutine periodicRingHandle;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnCallStarted(PhoneCallData data)
		{
		}

		private void OnCallCompleted(PhoneCallData data)
		{
		}

		private void OnCallQueued(PhoneCallData data)
		{
		}

		private void UpdateCallState()
		{
		}

		[IteratorStateMachine(typeof(_003CPeriodicRing_003Ed__18))]
		private IEnumerator PeriodicRing()
		{
			return null;
		}

		public void Hovered()
		{
		}

		public void Interacted()
		{
		}

		private bool CanInteract()
		{
			return false;
		}
	}
}
