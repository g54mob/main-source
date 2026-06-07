using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjOwl : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__25 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

		private Vector3 _003CtgtPos_003E5__2;

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
		public _003C_AnimateEntry_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003C_RunDashing_003Ed__42 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CtgtPos_003E5__4;

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
		public _003C_RunDashing_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003C_RunFlyingShootingArc_003Ed__40 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003CxDir_003E5__3;

		private int _003Cj_003E5__4;

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
		public _003C_RunFlyingShootingArc_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003C_RunFlyingShootingMagic_003Ed__44 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003C_RunFlyingShootingMagic_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__38 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

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
		public _003C_RunIdle_003Ed__38(int _003C_003E1__state)
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
	private sealed class _003C_RunLaser_003Ed__41 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

		private int _003Ci_003E5__2;

		private float _003CwaitTime_003E5__3;

		private EnemyLaserObj _003Claser_003E5__4;

		private float _003CstartTime_003E5__5;

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
		public _003C_RunLaser_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003C_RunSpawn_003Ed__43 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjOwl _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003C_RunSpawn_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003C_TransitionFlying_003Ed__48 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public bool newFlying;

		public GridPieceObjOwl _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CtgtPos_003E5__4;

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
		public _003C_TransitionFlying_003Ed__48(int _003C_003E1__state)
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

	public static GridPieceObjOwl I;

	public Animator AnimController;

	public bool IsFlying;

	public Collider2D FlyingCol;

	public AnimEventEmitter EvEmitter;

	public OwlPhase CurPhase;

	private OwlPhase _prevPhase;

	private List<Vector3> _spawnPos;

	private bool _isTransitioning;

	private CoroutineHandle _phaseAnim;

	private CoroutineHandle _flyAnim;

	private CoroutineHandle _updateAnim;

	private BoxRangeViz _dangerMarker;

	public Transform LaserShootXfm;

	public Transform[] ArrowShootXfm;

	public float MaxSpeed;

	public Vector2 Velocity;

	public Vector2 TgtVelocity;

	private float _nextXChangeTime;

	private float _nextYChangeTime;

	private const OwlPhase kDebugPhase = OwlPhase.kNum;

	private const int kArrowsPerArc = 3;

	private const float kFlyHeight = -1.5f;

	private const float kFlyTime = 1f;

	private void Awake()
	{
	}

	public override void Init(GridPieceInst inst)
	{
	}

	public override void RegisterColliders()
	{
	}

	public override void DeregisterColliders()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__25))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public override void Reset()
	{
	}

	private new void OnGameSpeedChanged()
	{
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public void SetPhase(OwlPhase ph)
	{
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	private void MyUpdate()
	{
	}

	public override void DestroyTouchingPieces()
	{
	}

	private float GetMinX()
	{
		return 0f;
	}

	private float GetMaxX()
	{
		return 0f;
	}

	private float GetMinY()
	{
		return 0f;
	}

	private float GetMaxY()
	{
		return 0f;
	}

	public override void UpdateWalk()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__38))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunFlyingShootingArc_003Ed__40))]
	private IEnumerator<float> _RunFlyingShootingArc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunLaser_003Ed__41))]
	private IEnumerator<float> _RunLaser()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunDashing_003Ed__42))]
	private IEnumerator<float> _RunDashing()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSpawn_003Ed__43))]
	private IEnumerator<float> _RunSpawn()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunFlyingShootingMagic_003Ed__44))]
	private IEnumerator<float> _RunFlyingShootingMagic()
	{
		return null;
	}

	private void SetFlying(bool isFlying, bool immediate = false)
	{
	}

	[IteratorStateMachine(typeof(_003C_TransitionFlying_003Ed__48))]
	private IEnumerator<float> _TransitionFlying(bool newFlying)
	{
		return null;
	}

	private void SetSortLayer(SortLayerType t)
	{
	}

	public override float GetCharLocalTopZ()
	{
		return 0f;
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override void PlayHitSFX(Vector3 hitPos)
	{
	}

	private void OnEventEmitted(AnimEventId animId)
	{
	}
}
