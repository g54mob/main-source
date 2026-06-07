using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_QuestRangeIndicator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_LerpRange_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_QuestRangeIndicator _003C_003E4__this;

		public float duration;

		public float targetRange;

		private float _003CstartRange_003E5__2;

		private float _003Celapsed_003E5__3;

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
		public _003CCR_LerpRange_003Ed__7(int _003C_003E1__state)
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
	private SpriteRenderer spriteRenderer_Area;

	[SerializeField]
	private SpriteRenderer spriteRenderer_Border;

	private Vector2 range;

	private bool isActivated;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetRange(float range)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpRange_003Ed__7))]
	private IEnumerator CR_LerpRange(float targetRange, float duration)
	{
		return null;
	}

	public void ToggleShowRange(bool doShow)
	{
	}
}
