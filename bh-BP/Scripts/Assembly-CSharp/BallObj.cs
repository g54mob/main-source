using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using Sirenix.Serialization;
using UnityEngine;

public class BallObj : FastPooledObject
{
	[CompilerGenerated]
	private sealed class _003C_AccelerateToSpeed_003Ed__63 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallObj _003C_003E4__this;

		public float len;

		public float sp;

		private float _003CstartSpeed_003E5__2;

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
		public _003C_AccelerateToSpeed_003Ed__63(int _003C_003E1__state)
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
	private sealed class _003C_PulseScale_003Ed__67 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public BallObj _003C_003E4__this;

		public float pulseAmt;

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
		public _003C_PulseScale_003Ed__67(int _003C_003E1__state)
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
	private sealed class _003C_RunFlicker_003Ed__55 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallObj _003C_003E4__this;

		private int _003CminDmg_003E5__2;

		private int _003CmaxDmg_003E5__3;

		private float _003CcycleLen_003E5__4;

		private float _003ClastFlickerTime_003E5__5;

		private bool _003CisLightOn_003E5__6;

		private DamageType _003CdamageType_003E5__7;

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
		public _003C_RunFlicker_003Ed__55(int _003C_003E1__state)
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
	private sealed class _003C_RunLaserCutter_003Ed__56 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallObj _003C_003E4__this;

		private LineFX _003Cfx_003E5__2;

		private LineRendFX _003ClineRendFX_003E5__3;

		private float _003CnextHitTime_003E5__4;

		private DamageType _003Cdt_003E5__5;

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
		public _003C_RunLaserCutter_003Ed__56(int _003C_003E1__state)
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

	public BallObjState CurState;

	public float StateChangeTime;

	public float SpawnTime;

	public bool IsActive;

	[NonSerialized]
	[OdinSerialize]
	public HeroInst Inst;

	public BallSourceType SrcType;

	private bool _isBaby;

	public bool IsSide;

	public float Speed;

	public float PeakSpeed;

	public float Acceleration;

	public Vector3 AimDir;

	public float PickupRange;

	public float SpeedMult;

	public bool BouncedOnAnyWall;

	public bool BouncedOnBackWall;

	public bool IsLastBounceOnWall;

	public float LastEnemyBounceTimeUnscaled;

	public int ShooterCharIdx;

	public Vector3 LobStartPos;

	public Vector3 LobTgtPos;

	public float CurLobLen;

	public float CurLobPct;

	public float CurLobHeight;

	public bool IsOnFire;

	public int MinBonusFireDamage;

	public int MaxBonusFireDamage;

	[NonSerialized]
	[OdinSerialize]
	public HeroInst ParentInst;

	[NonSerialized]
	[OdinSerialize]
	public PassiveInst PassiveSrc;

	public BallVFXController VFX;

	public PartSys PartTrail;

	public BallAttachment FireAttachment;

	public BallAttachment PowerUpAttachment;

	[NonSerialized]
	[OdinSerialize]
	public CharMetaInst WInst;

	public BuildingObj BuildingOwner;

	public List<Collider2D> JustTouchedCols;

	public List<Collider2D> JustAddedTouchingCols;

	public List<Collider2D> TouchingCols;

	public int NumBouncesSinceHit;

	public int NumBounces;

	public int NumWallBounces;

	public int NumEnemyBounces;

	public int NumShieldBounces;

	public Cost HeldResources;

	public DelegateUtl.NoArgsEvent OnBounce;

	private float _lastSpecialCheckTime;

	private int _numSpecials;

	private float[] _nextSpecialActionTime;

	private CoroutineHandle _pulseAnim;

	private CoroutineHandle _updateAnim;

	private EventInstance _loopingSfx;

	public void Init(HeroInst b, bool isSide, bool isBaby, Vector2 aimDir, BallSourceType src)
	{
	}

	public void InitWorker(CharMetaInst w, Vector2 aimDir)
	{
	}

	private void MyUpdate()
	{
	}

	private float GetCurTime()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_RunFlicker_003Ed__55))]
	private IEnumerator<float> _RunFlicker()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunLaserCutter_003Ed__56))]
	private IEnumerator<float> _RunLaserCutter()
	{
		return null;
	}

	public void SetAimDir(Vector2 aimDir)
	{
	}

	public void Bounce(Vector2 nextAimDir)
	{
	}

	public bool IsBaby()
	{
		return false;
	}

	public DamageType GetDamageType()
	{
		return default(DamageType);
	}

	public void OnAboutToRemove()
	{
	}

	public void SetState(BallObjState s)
	{
	}

	[IteratorStateMachine(typeof(_003C_AccelerateToSpeed_003Ed__63))]
	private IEnumerator<float> _AccelerateToSpeed(float sp, float len)
	{
		return null;
	}

	public int GetBabyModifiedProperty(PropertyType pt)
	{
		return 0;
	}

	public int GetBabyModifiedRangeProperty(PropertyType ptMin, ThreadSafeRandom rnd)
	{
		return 0;
	}

	public void PulseScale(float pulseAmt, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_PulseScale_003Ed__67))]
	private IEnumerator<float> _PulseScale(float pulseAmt, float len)
	{
		return null;
	}

	public void SetPos(Vector3 pos)
	{
	}

	public float GetSpeed()
	{
		return 0f;
	}

	public void LightOnFire(int minDmg, int maxDmg)
	{
	}

	public void ExtinguishFire()
	{
	}

	public void AttachPowerUp()
	{
	}

	public void ExtinguishPowerUp()
	{
	}

	public void MarkBouncedOnBackWall()
	{
	}

	public void MarkLastBounceOnWall()
	{
	}

	public void MarkBouncedOnAnyWall()
	{
	}

	public bool IsWorkerAtHarvestLength()
	{
		return false;
	}

	public bool IsSideBall()
	{
		return false;
	}
}
