using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Components.Particles.ForceFields
{
	[RequireComponent(typeof(ParticleSystemForceField))]
	public class ExplosionParticleForceField : g
	{
		private sealed class bks : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int tfr;

			private object tfs;

			public ExplosionParticleForceField tft;

			public float tfu;

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
			public bks(int a)
			{
			}

			[DebuggerHidden]
			private void jgl()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in jgl
				this.jgl();
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
			private void jgn()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in jgn
				this.jgn();
			}
		}

		[SerializeField]
		private ParticleSystemForceField m_forceField;

		private Coroutine tfv;

		protected override void cxh()
		{
		}

		public void jgp(float a)
		{
		}

		public void jgq(float a = 0.06f)
		{
		}

		[IteratorStateMachine(typeof(bks))]
		private IEnumerator jgr(float a)
		{
			return null;
		}

		private void OnValidate()
		{
		}

		public override void iry()
		{
		}

		private void jgs()
		{
		}

		private void jgt()
		{
		}
	}
}
