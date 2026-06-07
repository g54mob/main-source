using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VFXController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_Destroy_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		public VFXController _003C_003E4__this;

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
		public _003CCR_Destroy_003Ed__3(int _003C_003E1__state)
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

	private bool isDestroyed;

	private bool isMonsterEventRegistered;

	private AMonsterBase boundMonster;

	private Vector3 bindOffset;

	public void SetDestroyAfterTime(float time)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Destroy_003Ed__3))]
	private IEnumerator CR_Destroy(float time)
	{
		return null;
	}

	public void BindToMonster(AMonsterBase monster, Vector3 offset)
	{
	}

	private void Update()
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}
}
