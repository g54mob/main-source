using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using UnityEngine;

public class GridPieceObjDragon : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjDragon _003C_003E4__this;

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
		public _003C_AnimateEntry_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003C_RunFireballBurst_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjDragon _003C_003E4__this;

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
		public _003C_RunFireballBurst_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_RunFireballLine_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjDragon _003C_003E4__this;

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
		public _003C_RunFireballLine_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003C_RunFireballWave_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjDragon _003C_003E4__this;

		private int _003Ci_003E5__2;

		private float _003CbaseOffset_003E5__3;

		private float _003CwaveDir_003E5__4;

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
		public _003C_RunFireballWave_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjDragon _003C_003E4__this;

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
		public _003C_RunIdle_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003C_RunLunge_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjDragon _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CogPos_003E5__3;

		private Vector3 _003CtgtPos_003E5__4;

		private int _003CnumLunges_003E5__5;

		private Vector3 _003CretStartPos_003E5__6;

		private float _003CretLen_003E5__7;

		private int _003Ci_003E5__8;

		private CardinalDir _003CtgtDir_003E5__9;

		private Vector3 _003CstartPos_003E5__10;

		private float _003Clen_003E5__11;

		private bool _003CenteredWall_003E5__12;

		private bool _003CexitedWall_003E5__13;

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
		public _003C_RunLunge_003Ed__27(int _003C_003E1__state)
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

	public static GridPieceObjDragon I;

	public DragonPhase CurPhase;

	private DragonPhase _prevPhase;

	private BoxRangeViz _dangerMarker;

	public Transform ShootXfm;

	public PartSys ShootPart;

	public Animator AnimController;

	private List<Vector3> _spawnPos;

	private CoroutineHandle _phaseAnim;

	public Collider2D[] ExtraCols;

	private CoroutineHandle _updateAnim;

	private EventInstance _lungeSfx;

	private PartSys _lungeTrail;

	private PartSys _wallBurstPart1;

	private PartSys _wallBurstPart2;

	private const int kBallsPerBurst = 8;

	private const int kArrowsPerArc = 12;

	private const int kArrowsPerLine = 18;

	public override void Init(GridPieceInst inst)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__16))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override void RegisterColliders()
	{
	}

	private void MyUpdate()
	{
	}

	public override void DestroyTouchingPieces()
	{
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

	public void SetPhase(DragonPhase ph)
	{
	}

	public override void ResetRot()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__26))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunLunge_003Ed__27))]
	private IEnumerator<float> _RunLunge()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunFireballBurst_003Ed__29))]
	private IEnumerator<float> _RunFireballBurst()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunFireballWave_003Ed__31))]
	private IEnumerator<float> _RunFireballWave()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunFireballLine_003Ed__33))]
	private IEnumerator<float> _RunFireballLine()
	{
		return null;
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override bool ShouldAffectFrontEnemyY()
	{
		return false;
	}

	public override void RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity = 1f, float len = 0.2f)
	{
	}
}
