using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.NPCs;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools
{
	[RequireComponent(typeof(Rigidbody))]
	public class CombatNPCDetector : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CUpdateWhileDetected_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombatNPCDetector _003C_003E4__this;

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
			public _003CUpdateWhileDetected_003Ed__7(int _003C_003E1__state)
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

		public bool DetectOnlyInCombat;

		public UnityEvent onDetected;

		public float ContactTimeForDetection;

		private NPC npcInContact;

		private float contactTime;

		private Coroutine detectionRoutine;

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateWhileDetected_003Ed__7))]
		private IEnumerator UpdateWhileDetected()
		{
			return null;
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}
	}
}
