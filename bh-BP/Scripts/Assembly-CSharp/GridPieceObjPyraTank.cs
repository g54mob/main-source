using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using UnityEngine;

public class GridPieceObjPyraTank : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_LerpEyes_003Ed__45 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		public float len;

		public float tgtUp;

		public float tgtDown;

		private float _003CstartTime_003E5__2;

		private float _003CstartUp_003E5__3;

		private float _003CstartDown_003E5__4;

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
		public _003C_LerpEyes_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003C_RunArrows_003Ed__34 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		private GridPieceObjPyraTankStack _003CstackShooter_003E5__2;

		private int _003Cj_003E5__3;

		private int _003CtotWave_003E5__4;

		private int _003Cj_003E5__5;

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
		public _003C_RunArrows_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003C_RunBigLaser_003Ed__38 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		private GridPieceObjPyraTankStack _003CstackShooter_003E5__2;

		private float _003CwaitTime_003E5__3;

		private int _003CnWaves_003E5__4;

		private int _003Ci_003E5__5;

		private EnemyLaserObj _003Claser_003E5__6;

		private float _003CstartTime_003E5__7;

		private float _003ClastShootTime_003E5__8;

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
		public _003C_RunBigLaser_003Ed__38(int _003C_003E1__state)
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
	private sealed class _003C_RunChildStackDrop_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		public GridPieceObjPyraTankStack deadStack;

		private GridPieceObjPyraTankStack _003CnextStack_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003CdropLen_003E5__4;

		private bool _003CshrunkShadow_003E5__5;

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
		public _003C_RunChildStackDrop_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__32 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		private bool _003CisAnyoneStopping_003E5__2;

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
		public _003C_RunIdle_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003C_RunLasers_003Ed__36 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		private GridPieceObjPyraTankStack _003CstackShooter_003E5__2;

		private int _003CnWaves_003E5__3;

		private int _003Cw_003E5__4;

		private float _003CwaitTime_003E5__5;

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
		public _003C_RunLasers_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003C_RunSummon_003Ed__40 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTank _003C_003E4__this;

		private GridPieceType _003Ct_003E5__2;

		private int _003Cnum_003E5__3;

		private float _003CstartTime_003E5__4;

		private int _003Ci_003E5__5;

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
		public _003C_RunSummon_003Ed__40(int _003C_003E1__state)
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

	public static GridPieceObjPyraTank I;

	public GridPieceObjPyraTankStack[] Stack;

	public Sprite[] ShadowSprites;

	public float[] DefaultLocalZ;

	private int _stacksRemaining;

	public Animator AnimController;

	public PyraTankPhase CurPhase;

	private PyraTankPhase _prevPhase;

	private CoroutineHandle _curPhaseAnim;

	private CoroutineHandle _updateAnim;

	private EventInstance _rotateLoopingSFX;

	public CircleCollider2D MarkerArea;

	public BoxCollider2D BlockingArea;

	public Transform SandXfm;

	public PartSys SandParts;

	public PartSys MainPoisonParts;

	private float _headAngle;

	private float _headMoveDirX;

	private EnemyLaserObj[] _laserBuffer;

	private bool _isPreppingBigLaser;

	private List<Vector3> _spawnPos;

	private CoroutineHandle _curEyeAnim;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void InitShadow()
	{
	}

	protected override void OnEntryComplete()
	{
	}

	public override void Reset()
	{
	}

	private void RefreshColliders()
	{
	}

	private void MyUpdate()
	{
	}

	public override void OnChildDied(SubGridPieceObj child)
	{
	}

	public override void CreateDeathParts()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunChildStackDrop_003Ed__26))]
	private IEnumerator<float> _RunChildStackDrop(GridPieceObjPyraTankStack deadStack)
	{
		return null;
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override bool CanBeDamaged()
	{
		return false;
	}

	public void SetPhase(PyraTankPhase ph)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__32))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	private void RandomizeSpinning()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunArrows_003Ed__34))]
	private IEnumerator<float> _RunArrows()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunLasers_003Ed__36))]
	private IEnumerator<float> _RunLasers()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunBigLaser_003Ed__38))]
	private IEnumerator<float> _RunBigLaser()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSummon_003Ed__40))]
	private IEnumerator<float> _RunSummon()
	{
		return null;
	}

	public override float GetHealthPct()
	{
		return 0f;
	}

	public void SetEyePct(float up, float down)
	{
	}

	public void LerpEyes(float tgtUp, float tgtDown, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_LerpEyes_003Ed__45))]
	private IEnumerator<float> _LerpEyes(float tgtUp, float tgtDown, float len)
	{
		return null;
	}
}
