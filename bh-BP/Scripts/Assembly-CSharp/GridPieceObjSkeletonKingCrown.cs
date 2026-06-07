using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjSkeletonKingCrown : SubGridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AlwaysMoveCrown_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKingCrown _003C_003E4__this;

		private int _003Cdir_003E5__2;

		private float _003CmoveSpeed_003E5__3;

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
		public _003C_AlwaysMoveCrown_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003C_HitFlash_003Ed__15 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKingCrown _003C_003E4__this;

		public DamageType dmgType;

		private Material[] _003CmArr_003E5__2;

		private Material _003CcrownMat_003E5__3;

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
		public _003C_HitFlash_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003C_MoveCrown_003Ed__17 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKingCrown _003C_003E4__this;

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
		public _003C_MoveCrown_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003C_RunDeath_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSkeletonKingCrown _003C_003E4__this;

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
		public _003C_RunDeath_003Ed__14(int _003C_003E1__state)
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

	private const float kMaxCrownX = 1.18f;

	public Sprite[] DamagedSprites;

	private int _numHitsSinceCrownMove;

	private bool _isAlwaysMoving;

	private CoroutineHandle _moveAnim;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	public override void ResetScale()
	{
	}

	public override void ResetRot()
	{
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override void ResetSprite()
	{
	}

	public override bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	public override void RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity = 1f, float len = 0.2f)
	{
	}

	public override void RunBounce(float zIntensity, float len = 0.2f)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDeath_003Ed__14))]
	protected override IEnumerator<float> _RunDeath()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_HitFlash_003Ed__15))]
	protected override IEnumerator<float> _HitFlash(DamageType dmgType)
	{
		return null;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_MoveCrown_003Ed__17))]
	private IEnumerator<float> _MoveCrown()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AlwaysMoveCrown_003Ed__18))]
	private IEnumerator<float> _AlwaysMoveCrown()
	{
		return null;
	}

	public override bool AlwaysPlayHitSFX()
	{
		return false;
	}

	public override void PlayHitSFX(Vector3 hitPos)
	{
	}
}
