using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using UnityEngine;

public class GridPieceObjSkeletonKing : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__42 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

		private Vector3 _003CtgtPos_003E5__2;

		private float _003CmoveDist_003E5__3;

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
		public _003C_AnimateEntry_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003C_RunArrowArc_003Ed__53 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

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
		public _003C_RunArrowArc_003Ed__53(int _003C_003E1__state)
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
	private sealed class _003C_RunArrowBurst_003Ed__55 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

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
		public _003C_RunArrowBurst_003Ed__55(int _003C_003E1__state)
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
	private sealed class _003C_RunArrowWave_003Ed__51 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

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
		public _003C_RunArrowWave_003Ed__51(int _003C_003E1__state)
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
	private sealed class _003C_RunCrownDestroyed_003Ed__59 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

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
		public _003C_RunCrownDestroyed_003Ed__59(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__44 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

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
		public _003C_RunIdle_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003C_RunPunch_003Ed__57 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

		private int _003CtgtArm_003E5__2;

		private string _003CarmSuffix_003E5__3;

		private bool _003CisTransitioning_003E5__4;

		private Transform _003CarmXfm_003E5__5;

		private Vector2 _003CpDir_003E5__6;

		private float _003CstartTime_003E5__7;

		private float _003CtgtAngle_003E5__8;

		private Transform _003CforearmXfm_003E5__9;

		private Transform _003ChandXfm_003E5__10;

		private float _003CstartAngle_003E5__11;

		private float _003CstartForearmAngle_003E5__12;

		private float _003CtgtForearmAngle_003E5__13;

		private float _003CstartHandAngle_003E5__14;

		private float _003CtgtHandAngle_003E5__15;

		private Vector3 _003CstartArmPos_003E5__16;

		private Vector3 _003CtgtArmPos_003E5__17;

		private float _003ClastArrowTime_003E5__18;

		private Transform _003CpartXfm_003E5__19;

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
		public _003C_RunPunch_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003C_RunSummon_003Ed__56 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKing _003C_003E4__this;

		private GridPieceType _003Ct_003E5__2;

		private float _003CstartTime_003E5__3;

		private int _003Ci_003E5__4;

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
		public _003C_RunSummon_003Ed__56(int _003C_003E1__state)
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
	private sealed class _003C_TransitionAnimSpeedMult_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public GridPieceObjSkeletonKing _003C_003E4__this;

		public float startSpeed;

		public float tgtSpeed;

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
		public _003C_TransitionAnimSpeedMult_003Ed__33(int _003C_003E1__state)
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

	public static GridPieceObjSkeletonKing I;

	public GridPieceObjSkeletonKingCrown Crown;

	public SkinnedMeshRenderer MainMesh;

	public Collider2D[] LimbColliders;

	public Transform LeftArm;

	public Transform LeftForeArm;

	public Transform LeftHand;

	public Transform LeftGrabXfm;

	public Transform RightArm;

	public Transform RightForeArm;

	public Transform RightHand;

	public Transform RightGrabXfm;

	public Transform ShootPartXfm;

	public Transform RightPunchPartXfm;

	public Transform LeftPunchPartXfm;

	public Animator AnimController;

	public AnimEventEmitter EvEmitter;

	private BoxRangeViz _punchMarker;

	private float _animSpeedMult;

	private bool _isDragging;

	private int _curDraggingArm;

	private float _lastDragHandY;

	private CoroutineHandle _phaseAnim;

	public AnimationClip WalkAnim;

	public SkeleKingPhase CurPhase;

	private SkeleKingPhase _prevPhase;

	private List<AnimatorClipInfo> _clipInfoBuffer;

	private List<Vector3> _spawnPos;

	private EventInstance _curLoopingSFX;

	private PartSys _curLoopingPartSys;

	private float _entryPct;

	private const int kArrowsPerWave = 25;

	private const int kArrowsPerArc = 24;

	private const int kArrowsPerBurst = 30;

	private void Awake()
	{
	}

	public override void Init(GridPieceInst inst)
	{
	}

	private void SetAnimSpeedMult(float mult)
	{
	}

	[IteratorStateMachine(typeof(_003C_TransitionAnimSpeedMult_003Ed__33))]
	private IEnumerator<float> _TransitionAnimSpeedMult(float startSpeed, float tgtSpeed, float len)
	{
		return null;
	}

	public override void RegisterColliders()
	{
	}

	protected override void OnGameSpeedChanged()
	{
	}

	public override void Reset()
	{
	}

	public override bool IsShielded(Vector2 hitNormal)
	{
		return false;
	}

	public override void ResetSprite()
	{
	}

	public override void UpdateWalk()
	{
	}

	public override void DestroyTouchingPieces()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__42))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public void SetPhase(SkeleKingPhase ph)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__44))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override HitType GetDefaultHitType()
	{
		return default(HitType);
	}

	public override bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	public override void RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity = 1f, float len = 0.2f)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunArrowWave_003Ed__51))]
	private IEnumerator<float> _RunArrowWave()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunArrowArc_003Ed__53))]
	private IEnumerator<float> _RunArrowArc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunArrowBurst_003Ed__55))]
	private IEnumerator<float> _RunArrowBurst()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSummon_003Ed__56))]
	private IEnumerator<float> _RunSummon()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunPunch_003Ed__57))]
	private IEnumerator<float> _RunPunch()
	{
		return null;
	}

	public override void OnChildDied(SubGridPieceObj child)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunCrownDestroyed_003Ed__59))]
	private IEnumerator<float> _RunCrownDestroyed()
	{
		return null;
	}

	public override float GetHealthPct()
	{
		return 0f;
	}

	private void OnEventEmitted(AnimEventId id, int val)
	{
	}

	public override void PlayHitSFX(Vector3 hitPos)
	{
	}

	public override bool ShouldAIIgnore()
	{
		return false;
	}

	public override void HitFlash(DamageType dmgType)
	{
	}
}
