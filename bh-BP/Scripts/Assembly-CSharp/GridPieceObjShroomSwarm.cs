using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjShroomSwarm : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

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
		public _003C_AnimateEntry_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003C_BounceChild_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

		public int idx;

		public float zIntensity;

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
		public _003C_BounceChild_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_MoveChildToPos_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

		public int idx;

		public Vector3 pos;

		public float speed;

		private SubGridPieceObj _003Cchild_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003Clen_003E5__5;

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
		public _003C_MoveChildToPos_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_MoveToThetaPos_003Ed__23 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

		public float tgtTheta;

		public float tgtRadius;

		private float _003CstartTime_003E5__2;

		private float _003CstartTheta_003E5__3;

		private float _003CstartRadius_003E5__4;

		private float _003CdiffTheta_003E5__5;

		private float _003CthetaDir_003E5__6;

		private float _003Clen_003E5__7;

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
		public _003C_MoveToThetaPos_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003C_RunCannon_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

		private int _003Cj_003E5__2;

		private int _003CnumCannon_003E5__3;

		private bool _003CtargetedPlayer_003E5__4;

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
		public _003C_RunCannon_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_RunDeath_003Ed__34 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

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
		public _003C_RunDeath_003Ed__34(int _003C_003E1__state)
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

		public GridPieceObjShroomSwarm _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

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
	private sealed class _003C_RunSummon_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

		private int _003CnumToSpawn_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003CtgtTheta_003E5__4;

		private float _003CtgtRadius_003E5__5;

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
		public _003C_RunSummon_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_RunTar_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShroomSwarm _003C_003E4__this;

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
		public _003C_RunTar_003Ed__27(int _003C_003E1__state)
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

	public ShroomSwarmPhase CurPhase;

	private ShroomSwarmPhase _prevPhase;

	public EnemyMeshController[] EnemyControllers;

	public Vector3[] DefaultPos;

	public float[] DefaultTheta;

	public float[] DefaultRadius;

	private Vector3[] _childPooledPos;

	private CoroutineHandle[] _bounceAnims;

	private float _curTheta;

	private float _curRadius;

	private int _numActiveChildren;

	private CoroutineHandle _phaseAnim;

	private float _thetaSpeed;

	private const float kIdleCycleLen = 20f;

	private List<Vector3> _spawnPos;

	private void Awake()
	{
	}

	public override void InitEditor()
	{
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override bool CanBeDamaged()
	{
		return false;
	}

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__18))]
	public override IEnumerator<float> _AnimateEntry(float delay = 0f)
	{
		return null;
	}

	public override void InitShadow()
	{
	}

	protected override void InitChildren()
	{
	}

	private void SetPhase(ShroomSwarmPhase ph)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToThetaPos_003Ed__23))]
	private IEnumerator<float> _MoveToThetaPos(float tgtTheta, float tgtRadius)
	{
		return null;
	}

	private void SetThetaPos(float thetaOffset, float radiusMult)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunIdle_003Ed__26))]
	private IEnumerator<float> _RunIdle()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunTar_003Ed__27))]
	private IEnumerator<float> _RunTar()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunCannon_003Ed__28))]
	private IEnumerator<float> _RunCannon()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveChildToPos_003Ed__29))]
	private IEnumerator<float> _MoveChildToPos(int idx, Vector3 pos, float speed)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunSummon_003Ed__31))]
	private IEnumerator<float> _RunSummon()
	{
		return null;
	}

	public override void OnChildDied(SubGridPieceObj child)
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDeath_003Ed__34))]
	protected override IEnumerator<float> _RunDeath()
	{
		return null;
	}

	protected override void OnDeathComplete()
	{
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override float GetHealthPct()
	{
		return 0f;
	}

	public void BounceChild(int idx, float zIntensity)
	{
	}

	[IteratorStateMachine(typeof(_003C_BounceChild_003Ed__39))]
	private IEnumerator<float> _BounceChild(int idx, float zIntensity)
	{
		return null;
	}
}
