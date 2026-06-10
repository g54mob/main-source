using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkeletonCollisionChecker : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckCollision_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SkeletonCollisionChecker _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCheckCollision_003Ed__6(int _003C_003E1__state)
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

	public float delay;

	public int iterations;

	public MeshCollider meshCollider;

	public LayerMask collisionMask;

	public CorpseCollisionCorrection corpseCollisionCorrection;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckCollision_003Ed__6))]
	private IEnumerator CheckCollision()
	{
		return null;
	}
}
