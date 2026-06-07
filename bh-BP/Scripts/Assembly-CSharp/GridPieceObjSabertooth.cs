using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using FSG.MeshAnimator.ShaderAnimated;
using MEC;
using UnityEngine;

public class GridPieceObjSabertooth : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

		public float delay;

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
		public _003C_AnimateEntry_003Ed__21(int _003C_003E1__state)
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
	private sealed class _003C_RunArrowSingle_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Vector3 rot;

		public Vector3 startPos;

		public Vector3 tgtPos;

		private ArrowObj _003Cao_003E5__2;

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
		public _003C_RunArrowSingle_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_RunArrowVolley_003Ed__36 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

		private int _003Cj_003E5__2;

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
		public _003C_RunArrowVolley_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003C_RunCharging_003Ed__35 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

		private Vector3 _003CfirstStartPos_003E5__2;

		private Vector3 _003CfirstTgtPos_003E5__3;

		private float _003Clen_003E5__4;

		private float _003CstartTime_003E5__5;

		private float _003ClastSpawnTime_003E5__6;

		private Vector3 _003CstartPos_003E5__7;

		private Vector3 _003CtgtPos_003E5__8;

		private float _003CprevShootTime_003E5__9;

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
		public _003C_RunCharging_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003C_RunChildrenShoot_003Ed__30 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

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
		public _003C_RunChildrenShoot_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003C_RunDeath_003Ed__45 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

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
		public _003C_RunDeath_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003C_RunIdle_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

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
		public _003C_RunIdle_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003C_RunLaser_003Ed__42 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CtgtPos_003E5__3;

		private float _003Clen_003E5__4;

		private float _003CstartTime_003E5__5;

		private int _003CnWaves_003E5__6;

		private int _003Ci_003E5__7;

		private float _003CwaitTime_003E5__8;

		private EnemyLaserObj _003Claser_003E5__9;

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
		public _003C_RunLaser_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003C_RunSingleArrowVolley_003Ed__37 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

		private Vector3 _003CdangerPos_003E5__2;

		private float _003Cradius_003E5__3;

		private RangeViz _003CrViz_003E5__4;

		private float _003CstartTime_003E5__5;

		private int _003Ci_003E5__6;

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
		public _003C_RunSingleArrowVolley_003Ed__37(int _003C_003E1__state)
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
	private sealed class _003C_RunSummon_003Ed__41 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CtgtPos_003E5__3;

		private float _003Clen_003E5__4;

		private float _003CstartTime_003E5__5;

		private int _003CnumToSpawn_003E5__6;

		private GridPieceType _003Ct_003E5__7;

		private int _003Ci_003E5__8;

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
		public _003C_RunSummon_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndPlayMusic_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSabertooth _003C_003E4__this;

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
		public _003C_WaitAndPlayMusic_003Ed__22(int _003C_003E1__state)
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

	public static GridPieceObjSabertooth I;

	public SabertoothPhase CurPhase;

	private SabertoothPhase _prevPhase;

	public ShaderMeshAnimator[] ArcherAnims;

	public Transform[] ShootXfms;

	public Transform MouthShootXfm;

	public GameObject DustParts;

	private CoroutineHandle _phaseAnim;

	private CoroutineHandle _updateAnim;

	private float _lastShootTime;

	public int MoveDirX;

	private float _nextXChangeTime;

	public Collider2D ColMarker;

	public int MoveDirY;

	private float _nextYChangeTime;

	public float XSpeed;

	public float YSpeed;

	private Vector3 _prevPos;

	private EventInstance _loopingSFX;

	private BoxRangeViz _chargeMarker;

	private List<Vector3> _spawnPos;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__21))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_WaitAndPlayMusic_003Ed__22))]
	private IEnumerator<float> _WaitAndPlayMusic()
	{
		return null;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
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

	private void MyUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunChildrenShoot_003Ed__30))]
	private IEnumerator<float> _RunChildrenShoot()
	{
		return null;
	}

	public void SetPhase(SabertoothPhase ph)
	{
	}

	public override bool CanBePushedByWind()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__33))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunCharging_003Ed__35))]
	private IEnumerator<float> _RunCharging()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunArrowVolley_003Ed__36))]
	private IEnumerator<float> _RunArrowVolley()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSingleArrowVolley_003Ed__37))]
	private IEnumerator<float> _RunSingleArrowVolley()
	{
		return null;
	}

	private void CheckVolleyHits(Vector3 pos, float radius)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunArrowSingle_003Ed__39))]
	private IEnumerator<float> _RunArrowSingle(Vector3 startPos, Vector3 tgtPos, Vector3 rot)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSummon_003Ed__41))]
	private IEnumerator<float> _RunSummon()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunLaser_003Ed__42))]
	private IEnumerator<float> _RunLaser()
	{
		return null;
	}

	public override void RefreshMat()
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDeath_003Ed__45))]
	private new IEnumerator<float> _RunDeath()
	{
		return null;
	}

	public override void PlayHitSFX(Vector3 hitPos)
	{
	}
}
