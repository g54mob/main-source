using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class FuserPickupObj : PickupObj
{
	[CompilerGenerated]
	private sealed class _003C_PulseRadius_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FuserPickupObj _003C_003E4__this;

		public float len;

		public float tgtRadius;

		private float _003CstartTime_003E5__2;

		private float _003CstartRadius_003E5__3;

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
		public _003C_PulseRadius_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003C_PulseSize_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FuserPickupObj _003C_003E4__this;

		public float len;

		public float tgtSize;

		private float _003CstartTime_003E5__2;

		private float _003CstartSize_003E5__3;

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
		public _003C_PulseSize_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003C_PulseSpeed_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FuserPickupObj _003C_003E4__this;

		public float len;

		public float tgtSpeed;

		private float _003CstartTime_003E5__2;

		private float _003CstartSpeed_003E5__3;

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
		public _003C_PulseSpeed_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003C_RunFloaty_003Ed__13 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FuserPickupObj _003C_003E4__this;

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
		public _003C_RunFloaty_003Ed__13(int _003C_003E1__state)
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

	public Transform Orb1;

	public Transform Orb2;

	public TrailRenderer Trail1;

	public TrailRenderer Trail2;

	public float SpinSpeed;

	public float SpinRadius;

	private float _rSeed;

	private CoroutineHandle _updateAnim;

	private void Start()
	{
	}

	public override void AttachPickupTrail()
	{
	}

	public override void Init(PickupInst inst)
	{
	}

	public void ResetParts()
	{
	}

	private void MyUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunFloaty_003Ed__13))]
	protected override IEnumerator<float> _RunFloaty()
	{
		return null;
	}

	public void SetSpinRadius(float sr)
	{
	}

	public void SetSize(float sz)
	{
	}

	public void SetTrailLife(float life)
	{
	}

	public void PulseSize(float tgtSize, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_PulseSize_003Ed__18))]
	public IEnumerator<float> _PulseSize(float tgtSize, float len)
	{
		return null;
	}

	public void PulseRadius(float tgtRadius, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_PulseRadius_003Ed__20))]
	public IEnumerator<float> _PulseRadius(float tgtRadius, float len)
	{
		return null;
	}

	public void PulseSpeed(float tgtSpeed, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_PulseSpeed_003Ed__22))]
	public IEnumerator<float> _PulseSpeed(float tgtSpeed, float len)
	{
		return null;
	}
}
