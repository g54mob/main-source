using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using UnityEngine;

public class GridPieceObjMoon : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__24 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		public float delay;

		private bool _003CplayedEntrySFX_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003Clen_003E5__4;

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
		public _003C_AnimateEntry_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003C_MyUpdate_003Ed__48 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		private float _003Cr_003E5__2;

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
		public _003C_MyUpdate_003Ed__48(int _003C_003E1__state)
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
	private sealed class _003C_QueueRemove_003Ed__53 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CtgtPos_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003Clen_003E5__5;

		private float _003CstartTheta_003E5__6;

		private float _003CtgtTheta_003E5__7;

		private float _003CstartScale_003E5__8;

		private float _003CtgtScale_003E5__9;

		private Vector3 _003CtgtRot_003E5__10;

		private Vector3 _003CentranceStart_003E5__11;

		private Vector3 _003CentranceTgt_003E5__12;

		private EventInstance _003CrecedeEv_003E5__13;

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
		public _003C_QueueRemove_003Ed__53(int _003C_003E1__state)
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
	private sealed class _003C_RunAllDeadChildren_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

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
		public _003C_RunAllDeadChildren_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_RunBabies_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		private Vector2 _003CminWorld_003E5__2;

		private Vector2 _003CmaxWorld_003E5__3;

		private int _003Ci_003E5__4;

		private int _003Cj_003E5__5;

		private float _003CstartTime_003E5__6;

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
		public _003C_RunBabies_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_RunBoulders_003Ed__37 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003Cj_003E5__3;

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
		public _003C_RunBoulders_003Ed__37(int _003C_003E1__state)
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
	private sealed class _003C_RunDeadChild_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		public SubGridPieceObj child;

		private float _003CstartTime_003E5__2;

		private int _003Cidx_003E5__3;

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
		public _003C_RunDeadChild_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_RunHitTilt_003Ed__32 : IEnumerator<float>, IEnumerator, IDisposable
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
		public _003C_RunHitTilt_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__36 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

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
		public _003C_RunIdle_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003C_RunMagicArrows_003Ed__40 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003Cj_003E5__3;

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
		public _003C_RunMagicArrows_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003C_RunWideArrows_003Ed__43 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

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
		public _003C_RunWideArrows_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003C_RunWideSpears_003Ed__46 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjMoon _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003Cj_003E5__3;

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
		public _003C_RunWideSpears_003Ed__46(int _003C_003E1__state)
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

	public static GridPieceObjMoon I;

	private CoroutineHandle _update;

	private CoroutineHandle _phaseAnim;

	public GridPieceObjMoonBaby[] MoonBabies;

	public MoonPhase CurPhase;

	private MoonPhase _prevPhase;

	private bool _childrenDead;

	private float _revolveTheta;

	private float _revolveDir;

	private Vector2 _moveDir;

	private float _moveSpeed;

	private float[] _childRadius;

	private EventInstance _curLoopingSFX;

	private EventInstance _spinSFX;

	public Collider2D ColEndGameBlocker;

	public Collider2D ColEndGame;

	public bool IsEnteringEndGame;

	public GridPieceObjMoonBaby EntranceBaby;

	public const float kOuterRadius = 3.7f;

	public const float kInnerRadius = 2.375f;

	public const float kModelScale = 1.25f;

	public PartSys LandParts;

	private List<Vector3> _spawnPos;

	private const float kWideArrowArc = 180f;

	private const int kNumWideArrows = 5;

	private const float kWideSpearArc = 90f;

	private const int kNumWideSpears = 5;

	public override void Init(GridPieceInst inst)
	{
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__24))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public override void DestroyTouchingPieces()
	{
	}

	protected override void InitChildren()
	{
	}

	public override void OnChildDied(SubGridPieceObj child)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDeadChild_003Ed__28))]
	private IEnumerator<float> _RunDeadChild(SubGridPieceObj child)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunAllDeadChildren_003Ed__29))]
	private IEnumerator<float> _RunAllDeadChildren()
	{
		return null;
	}

	public override void HitFlash(DamageType dmgType)
	{
	}

	public override bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunHitTilt_003Ed__32))]
	protected override IEnumerator<float> _RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity, float len)
	{
		return null;
	}

	public override bool CanBeDamaged()
	{
		return false;
	}

	public override void Reset()
	{
	}

	public void SetPhase(MoonPhase ph)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__36))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunBoulders_003Ed__37))]
	private IEnumerator<float> _RunBoulders()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunBabies_003Ed__39))]
	private IEnumerator<float> _RunBabies()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunMagicArrows_003Ed__40))]
	private IEnumerator<float> _RunMagicArrows()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunWideArrows_003Ed__43))]
	private IEnumerator<float> _RunWideArrows()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunWideSpears_003Ed__46))]
	private IEnumerator<float> _RunWideSpears()
	{
		return null;
	}

	private void SetTheta(float theta)
	{
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__48))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override float GetHealthPct()
	{
		return 0f;
	}

	private void PulseBabies()
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	[IteratorStateMachine(typeof(_003C_QueueRemove_003Ed__53))]
	protected override IEnumerator<float> _QueueRemove()
	{
		return null;
	}

	public override float GetLocalPlatformTopZ()
	{
		return 0f;
	}

	public bool IsChildrenDead()
	{
		return false;
	}

	private void SetRevolveDir(float dir)
	{
	}
}
