using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ParticleSystemGroup
{
	[CompilerGenerated]
	private sealed class _003CPlayDelayed_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public ParticleSystemGroup _003C_003E4__this;

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
		public _003CPlayDelayed_003Ed__3(int _003C_003E1__state)
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

	[SerializeField]
	private List<ParticleSystem> particleSystems;

	public void Play(float delay = 0f)
	{
	}

	private void PlayNow()
	{
	}

	[IteratorStateMachine(typeof(_003CPlayDelayed_003Ed__3))]
	private IEnumerator PlayDelayed(float delay)
	{
		return null;
	}

	public void Stop(ParticleSystemStopBehavior stopBehavior = ParticleSystemStopBehavior.StopEmitting)
	{
	}
}
