using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class CarVFX : VehicleVFX
	{
		[CompilerGenerated]
		private sealed class _003COnStartEngineCoroutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float startEngineDellay;

			public CarVFX _003C_003E4__this;

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
			public _003COnStartEngineCoroutine_003Ed__8(int _003C_003E1__state)
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

		[Header("CarVFX")]
		public List<ParticleSystem> ExhaustParticles;

		public List<ParticleSystem> BackFireParticles;

		public List<ParticleSystem> BoostParticles;

		private CarController Car;

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		private void OnBackFire()
		{
		}

		private void OnStartEngine(float startEngineDellay)
		{
		}

		[IteratorStateMachine(typeof(_003COnStartEngineCoroutine_003Ed__8))]
		private IEnumerator OnStartEngineCoroutine(float startEngineDellay)
		{
			return null;
		}
	}
}
