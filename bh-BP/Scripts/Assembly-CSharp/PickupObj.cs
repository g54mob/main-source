using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using MEC;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class PickupObj : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateBaseCollect_003Ed__37 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PickupObj _003C_003E4__this;

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
		public _003C_AnimateBaseCollect_003Ed__37(int _003C_003E1__state)
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
	private sealed class _003C_AnimateDrop_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PickupObj _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003CdelayLen_003E5__3;

		private float _003CdropLen_003E5__4;

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
		public _003C_AnimateDrop_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003C_AnimateElevatorUpgradeEntry_003Ed__38 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PickupObj _003C_003E4__this;

		public Vector3 startPos;

		public Vector3 tgtPos;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private Vector3 _003CstartRot_003E5__4;

		private Vector3 _003CtgtRot_003E5__5;

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
		public _003C_AnimateElevatorUpgradeEntry_003Ed__38(int _003C_003E1__state)
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
	private sealed class _003C_AnimateElevatorUpgradeExit_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public PickupObj _003C_003E4__this;

		public Vector3 startPos;

		public Vector3 tgtPos;

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
		public _003C_AnimateElevatorUpgradeExit_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_AnimatePlayerPickUp_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PickupObj _003C_003E4__this;

		public int controllerIdx;

		private float _003Cspeed_003E5__2;

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
		public _003C_AnimatePlayerPickUp_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_RunFloaty_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PickupObj _003C_003E4__this;

		private float _003Ch_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003CrotDir_003E5__4;

		private Transform _003CtgtTransform_003E5__5;

		private float _003CzOffset_003E5__6;

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
		public _003C_RunFloaty_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003C_RunNonFloaty_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PickupObj _003C_003E4__this;

		private Transform _003CtgtTransform_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003CrotDir_003E5__4;

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
		public _003C_RunNonFloaty_003Ed__22(int _003C_003E1__state)
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

	[NonSerialized]
	[OdinSerialize]
	public PickupInst Inst;

	public PickupObjState CurState;

	public PickupVFX VFX;

	public GridSpriteObj SpriteObj;

	public Collider2D Col;

	private CoroutineHandle _curAnim;

	private CoroutineHandle _timerAnim;

	public float RotSpeed;

	public bool AttachTrailOnPickup;

	public PartSys PartTrail;

	public Color TrailColor;

	public EventReference SFXOnPickupComplete;

	public const bool kScrollWithGrid = true;

	public static readonly int[] kXPVals;

	public const int kXP2Val = 10;

	public const int kXP3Val = 100;

	public const int kXP4Val = 1000;

	public const int kGoldVal = 10;

	public const int kGoldBagValSmall = 100;

	private void Awake()
	{
	}

	private void InitInternal(PickupInst inst)
	{
	}

	public virtual void Init(PickupInst inst)
	{
	}

	public void InitBase(PickupInst inst)
	{
	}

	public void SetState(PickupObjState st)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateDrop_003Ed__18))]
	private IEnumerator<float> _AnimateDrop()
	{
		return null;
	}

	public void RunFloaty()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunFloaty_003Ed__20))]
	protected virtual IEnumerator<float> _RunFloaty()
	{
		return null;
	}

	public void RunNonFloaty()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunNonFloaty_003Ed__22))]
	protected virtual IEnumerator<float> _RunNonFloaty()
	{
		return null;
	}

	public void Reset()
	{
	}

	public void CancelAnims()
	{
	}

	public virtual void AttachPickupTrail()
	{
	}

	public void ClearPickupTrail()
	{
	}

	public void StartPlayerPickUp(int controllerIdx)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimatePlayerPickUp_003Ed__28))]
	private IEnumerator<float> _AnimatePlayerPickUp(int controllerIdx)
	{
		return null;
	}

	private void CompletePickup()
	{
	}

	public void AnimateBaseCollect()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateBaseCollect_003Ed__37))]
	private IEnumerator<float> _AnimateBaseCollect()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateElevatorUpgradeEntry_003Ed__38))]
	public IEnumerator<float> _AnimateElevatorUpgradeEntry(Vector3 startPos, Vector3 tgtPos)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateElevatorUpgradeExit_003Ed__39))]
	public IEnumerator<float> _AnimateElevatorUpgradeExit(Vector3 startPos, Vector3 tgtPos, float len)
	{
		return null;
	}
}
