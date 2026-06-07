using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using UnityEngine;

public class GridPieceObjYetiQueen : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		private Vector3 _003CtgtPos_003E5__2;

		private float _003ClastScreenshakeTime_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003CstartRotSpeed_003E5__5;

		private float _003CriseLen_003E5__6;

		private bool _003CplayedRise_003E5__7;

		private bool _003CplayedBossMusic_003E5__8;

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
		public _003C_AnimateEntry_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_MoveToRadius_003Ed__46 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float r;

		public GridPieceObjYetiQueen _003C_003E4__this;

		public float speed;

		private float _003CstartRadius_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_MoveToRadius_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003C_MoveToSpacing_003Ed__48 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		public float sp;

		private float _003CstartSpacing_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_MoveToSpacing_003Ed__48(int _003C_003E1__state)
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
	private sealed class _003C_RotateToTheta_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		public float tgtTheta;

		private float _003CstartTheta_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_RotateToTheta_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_RotateToTheta_003Ed__40 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		public float tgtTheta;

		public float len;

		private float _003CstartTheta_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_RotateToTheta_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003C_RunChildStackDrop_003Ed__30 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueenStack deadStack;

		public GridPieceObjYetiQueen _003C_003E4__this;

		private GridPieceObjYetiQueenStack _003CnextStack_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_RunChildStackDrop_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__37 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

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
		public _003C_RunIdle_003Ed__37(int _003C_003E1__state)
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
	private sealed class _003C_RunShieldPunch_003Ed__54 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

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
		public _003C_RunShieldPunch_003Ed__54(int _003C_003E1__state)
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
	private sealed class _003C_RunShieldPunchSingle_003Ed__53 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		public int i;

		private GridPieceObjYetiQueenShield _003CpunchChild_003E5__2;

		private Vector3 _003CstartEulerAngles_003E5__3;

		private Vector3 _003CtgtEulerAngles_003E5__4;

		private Vector3 _003CstartPunchPos_003E5__5;

		private float _003CpunchDist_003E5__6;

		private Vector3 _003CtgtPunchPos_003E5__7;

		private float _003CstartTime_003E5__8;

		private float _003ClastPct_003E5__9;

		private bool _003CdidHitLaunch_003E5__10;

		private bool _003CdidHitRetract_003E5__11;

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
		public _003C_RunShieldPunchSingle_003Ed__53(int _003C_003E1__state)
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
	private sealed class _003C_RunShieldWave_003Ed__52 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		private bool _003CshouldFollowPlayer_003E5__2;

		private int _003CnArrows_003E5__3;

		private int _003CnIter_003E5__4;

		private int _003CcurIter_003E5__5;

		private float _003CwaitLen_003E5__6;

		private float _003CstartTime_003E5__7;

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
		public _003C_RunShieldWave_003Ed__52(int _003C_003E1__state)
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
	private sealed class _003C_RunSpawn_003Ed__57 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

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
		public _003C_RunSpawn_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003C_RunSpearWave_003Ed__51 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjYetiQueen _003C_003E4__this;

		private int _003CnArrows_003E5__2;

		private int _003Ci_003E5__3;

		private int _003Cj_003E5__4;

		private int _003Ck_003E5__5;

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
		public _003C_RunSpearWave_003Ed__51(int _003C_003E1__state)
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

	public static GridPieceObjYetiQueen I;

	public YetiQueenPhase CurPhase;

	private YetiQueenPhase _prevPhase;

	private CoroutineHandle _phaseAnim;

	private CoroutineHandle _rotAnim;

	private CoroutineHandle _spacingAnim;

	private CoroutineHandle _rAnim;

	private CoroutineHandle _updateAnim;

	private BoxRangeViz[] _punchMarker;

	public Animator AnimController;

	public AnimationCurve CrvRise;

	public GridPieceObjYetiQueenShield[] Shields;

	public GridPieceObjYetiQueenStack[] Stack;

	public CircleCollider2D ColMarker;

	public Collider2D ColBlocking;

	private float _curTheta;

	private float _curRadius;

	private float _prevTheta;

	private float _prevRadius;

	private float _rotSpeed;

	private float _curShieldSpacing;

	private const float kThetaSpeed = 0.5f;

	private EventInstance _curLoopingSFX;

	private EventInstance _shieldSlideLoopingSFX;

	private EventInstance[] _shieldPunchLoopingSFX;

	private CoroutineHandle[] _shieldPunchAnim;

	private List<Vector3> _spawnPos;

	private void Awake()
	{
	}

	public override void Init(GridPieceInst inst)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__28))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public override void OnChildDied(SubGridPieceObj child)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunChildStackDrop_003Ed__30))]
	private IEnumerator<float> _RunChildStackDrop(GridPieceObjYetiQueenStack deadStack)
	{
		return null;
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override void Reset()
	{
	}

	private void MyUpdate()
	{
	}

	public override bool CanBeDamaged()
	{
		return false;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public void SetPhase(YetiQueenPhase ph)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__37))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	public void RotateToTheta(float tgtTheta)
	{
	}

	[IteratorStateMachine(typeof(_003C_RotateToTheta_003Ed__39))]
	private IEnumerator<float> _RotateToTheta(float tgtTheta)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RotateToTheta_003Ed__40))]
	private IEnumerator<float> _RotateToTheta(float tgtTheta, float len)
	{
		return null;
	}

	public void MoveToTheta(float tgtTheta)
	{
	}

	public void SetShieldTheta(float theta)
	{
	}

	public void SetShieldRadius(float r)
	{
	}

	public void SetShieldSpacing(float sp)
	{
	}

	public void MoveToRadius(float r, float speed)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToRadius_003Ed__46))]
	private IEnumerator<float> _MoveToRadius(float r, float speed)
	{
		return null;
	}

	public void MoveToSpacing(float sp)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToSpacing_003Ed__48))]
	private IEnumerator<float> _MoveToSpacing(float sp)
	{
		return null;
	}

	private void RefreshShieldPos()
	{
	}

	public float GetThetaAtIdx(int idx)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_RunSpearWave_003Ed__51))]
	private IEnumerator<float> _RunSpearWave()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunShieldWave_003Ed__52))]
	private IEnumerator<float> _RunShieldWave()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunShieldPunchSingle_003Ed__53))]
	private IEnumerator<float> _RunShieldPunchSingle(int i)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunShieldPunch_003Ed__54))]
	private IEnumerator<float> _RunShieldPunch()
	{
		return null;
	}

	private void Spawn(GridPieceType type, int nToSpawn)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunSpawn_003Ed__57))]
	private IEnumerator<float> _RunSpawn()
	{
		return null;
	}

	public override float GetHealthPct()
	{
		return 0f;
	}
}
