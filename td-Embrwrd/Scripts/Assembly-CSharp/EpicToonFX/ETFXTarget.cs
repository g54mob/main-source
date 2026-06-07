using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXTarget : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRespawn_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ETFXTarget _003C_003E4__this;

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
			public _003CRespawn_003Ed__7(int _003C_003E1__state)
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

		[Header("Effect shown on target hit")]
		public GameObject hitParticle;

		[Header("Effect shown on target respawn")]
		public GameObject respawnParticle;

		private Renderer targetRenderer;

		private Collider targetCollider;

		private void Start()
		{
		}

		private void SpawnTarget()
		{
		}

		private void OnTriggerEnter(Collider col)
		{
		}

		[IteratorStateMachine(typeof(_003CRespawn_003Ed__7))]
		private IEnumerator Respawn()
		{
			return null;
		}
	}
}
