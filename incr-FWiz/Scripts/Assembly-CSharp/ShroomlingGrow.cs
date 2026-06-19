using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShroomlingGrow : CreatureBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGrow_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShroomlingGrow _003C_003E4__this;

		private int _003CgrowthIndex_003E5__2;

		private float _003CgrowthPhaseDuration_003E5__3;

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
		public _003CGrow_003Ed__7(int _003C_003E1__state)
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

	public List<Behaviour> EnableOnGrow;

	public List<GameObject> ActivateOnGrow;

	public Rigidbody2D Rigidbody2D;

	public float GrowthDuration;

	public SpriteRenderer BodyRenderer;

	public List<Sprite> GrowthSprites;

	protected override void OnInitiate()
	{
	}

	[IteratorStateMachine(typeof(_003CGrow_003Ed__7))]
	public IEnumerator Grow()
	{
		return null;
	}
}
