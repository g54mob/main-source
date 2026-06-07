using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjPyraTankStack : SubGridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_HitFlash_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTankStack _003C_003E4__this;

		public DamageType dmgType;

		private Material[] _003CmArr_003E5__2;

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
		public _003C_HitFlash_003Ed__21(int _003C_003E1__state)
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
	private sealed class _003C_MyUpdate_003Ed__15 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTankStack _003C_003E4__this;

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
		public _003C_MyUpdate_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003C_PauseSpinning_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTankStack _003C_003E4__this;

		public float secs;

		private float _003CstartGameTime_003E5__2;

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
		public _003C_PauseSpinning_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_QueueRemove_003Ed__23 : IEnumerator<float>, IEnumerator, IDisposable
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
		public _003C_QueueRemove_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003C_RunDeath_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjPyraTankStack _003C_003E4__this;

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
		public _003C_RunDeath_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003C_RunHitTilt_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
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
		public _003C_RunHitTilt_003Ed__16(int _003C_003E1__state)
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

	public int StackIdx;

	public float DefaultZPos;

	public Transform XfmToRotate;

	public float RotSpeed;

	private float _curRot;

	private float _rotDir;

	public bool StopAt90;

	private bool _isSpinningPaused;

	public Transform[] ProjectilePoints;

	private CoroutineHandle _update;

	private CoroutineHandle _pauseAnim;

	public override void InitEditor()
	{
	}

	public override void Init(GridPieceInst inst)
	{
	}

	public override void InitShadow()
	{
	}

	public void SetRot(float rot)
	{
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__15))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunHitTilt_003Ed__16))]
	protected override IEnumerator<float> _RunHitTilt(Vector2 hitNormal, Vector3 hitOffset, float intensity, float len)
	{
		return null;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override bool CanBeDamaged()
	{
		return false;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override void RefreshMat()
	{
	}

	[IteratorStateMachine(typeof(_003C_HitFlash_003Ed__21))]
	protected override IEnumerator<float> _HitFlash(DamageType dmgType)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunDeath_003Ed__22))]
	protected override IEnumerator<float> _RunDeath()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_QueueRemove_003Ed__23))]
	protected override IEnumerator<float> _QueueRemove()
	{
		return null;
	}

	public new bool IsActive()
	{
		return false;
	}

	public override bool IsBottomOfStack()
	{
		return false;
	}

	public override bool IsTopOfStack()
	{
		return false;
	}

	public void SetDir(float dir)
	{
	}

	public Vector3 GetProjectileAimDir(int idx)
	{
		return default(Vector3);
	}

	public void SetSpinningPaused(bool isPaused)
	{
	}

	public void PauseSpinning(float secs)
	{
	}

	[IteratorStateMachine(typeof(_003C_PauseSpinning_003Ed__31))]
	private IEnumerator<float> _PauseSpinning(float secs)
	{
		return null;
	}

	public override void PlayHitSFX(Vector3 hitPos)
	{
	}
}
