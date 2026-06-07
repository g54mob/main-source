using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjMoonBaby : SubGridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__4 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_AnimateEntry_003Ed__4(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_QueueRemove_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoonBaby _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_QueueRemove_003Ed__11(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_RunPulse_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoonBaby _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunPulse_003Ed__14(int _003C_003E1__state)
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

	private CoroutineHandle _updateAnim;

	private CoroutineHandle _pulseAnim;

	public SpriteRenderer BabyShadow;

	public override void Init(GridPieceInst inst)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__4))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public override void InitShadow()
	{
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override void Reset()
	{
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	private void MyUpdate()
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	[IteratorStateMachine(typeof(_003C_QueueRemove_003Ed__11))]
	protected override IEnumerator<float> _QueueRemove()
	{
		return null;
	}

	public override void CreateDeathParts()
	{
	}

	public void RunPulse()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunPulse_003Ed__14))]
	private IEnumerator<float> _RunPulse()
	{
		return null;
	}
}
