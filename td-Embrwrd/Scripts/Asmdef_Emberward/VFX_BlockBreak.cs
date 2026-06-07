using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VFX_BlockBreak : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_DestroyBlockEffect_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VFX_BlockBreak _003C_003E4__this;

		public Color blockColor;

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
		public _003CCR_DestroyBlockEffect_003Ed__2(int _003C_003E1__state)
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
	private ParticleSystem particle_Destroy;

	public void SetupAndTrigger(Color blockColor)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DestroyBlockEffect_003Ed__2))]
	private IEnumerator CR_DestroyBlockEffect(Color blockColor)
	{
		return null;
	}
}
