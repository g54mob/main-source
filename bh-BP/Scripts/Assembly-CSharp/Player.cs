using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class Player : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_HitFlash_003Ed__72 : IEnumerator<float>, IEnumerator, IDisposable
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
		public _003C_HitFlash_003Ed__72(int _003C_003E1__state)
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
	private sealed class _003C_RunFuserFX_003Ed__79 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Player _003C_003E4__this;

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
		public _003C_RunFuserFX_003Ed__79(int _003C_003E1__state)
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
	private sealed class _003C_RunHitKnockback_003Ed__58 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Player _003C_003E4__this;

		public Vector3 startPos;

		public Vector3 tgtPos;

		private float _003Clen_003E5__2;

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
		public _003C_RunHitKnockback_003Ed__58(int _003C_003E1__state)
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
	private sealed class _003C_RunLevelUpFX_003Ed__77 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Player _003C_003E4__this;

		public StatType st;

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
		public _003C_RunLevelUpFX_003Ed__77(int _003C_003E1__state)
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
	private sealed class _003C_RunShieldBounce_003Ed__125 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Player _003C_003E4__this;

		private float _003Clen_003E5__2;

		private float _003CstartTime_003E5__3;

		private Vector3 _003CstartPos_003E5__4;

		private Vector3 _003CbouncePos_003E5__5;

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
		public _003C_RunShieldBounce_003Ed__125(int _003C_003E1__state)
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
	private sealed class _003C_RunTeleport_003Ed__121 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Player _003C_003E4__this;

		public ObstacleObj teleporter;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CdropPos_003E5__3;

		private Vector3 _003CrandomPos_003E5__4;

		private Vector3 _003CrandomPosTop_003E5__5;

		private float _003CstartTime_003E5__6;

		private TrailVFX _003Ctrail_003E5__7;

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
		public _003C_RunTeleport_003Ed__121(int _003C_003E1__state)
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
	private sealed class _003C_SetAimDirDelayed_003Ed__54 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Player _003C_003E4__this;

		public Vector2 dir;

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
		public _003C_SetAimDirDelayed_003Ed__54(int _003C_003E1__state)
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

	public static Player I;

	public PartSys FanParts;

	public PlayerCharController[] CharControllers;

	public GameObject WrapperShield;

	public float LastShieldUseTime;

	public PlayerState CurState;

	private Vector3 _mousePos;

	private Vector2 _lastAimDir;

	private Vector2 _lastMoveDir;

	private float _aimTheta;

	public float SpeedMult;

	public bool IsOverridingInput;

	public float InputXOverride;

	public float InputYOverride;

	private CoroutineHandle _colorAnim;

	private CoroutineHandle _moveAnim;

	private CoroutineHandle _hitKnockbackAnim;

	private CoroutineHandle _ballKnockbackAnim;

	private bool _isKnockingBack;

	private bool _didLetGoOfInputAfterKnockback;

	public float LastDamagedTime;

	public float LastInvalidShootTime;

	private int _lastShootBeat;

	private float _lastTouchDamageTime;

	private float _lastTouchDamageRealTime;

	public Vector3 TacticianStartPos;

	private bool _isAimingIntoMoon;

	private bool _isMoving;

	private float _lastOnionTime;

	public List<PlayerStatusEffInd> AttachedInds;

	private int _numClicksInARow;

	private float _lastClickTime;

	private float _curClickHoldLen;

	private bool _isTouchingLeft;

	private Touch _leftStartTouch;

	private Vector3 _leftTouchPos;

	private bool _isTouchingRight;

	private Touch _rightStartTouch;

	private Vector3 _rightTouchPos;

	private const float kColHalfWidth = 0.5f;

	private const float kColHalfHeight = 0.25f;

	private Collider[] _colAlloc;

	private const float kHitKnockbackLen = 0.2f;

	private float _lastVibrateTime;

	private float _lastVibrateIntensity;

	private float _lastVibrateLen;

	public bool IsRunningLevelUp;

	private PickupObj _aiTgtPickup;

	private Vector2 _aiTgtPos;

	private Vector2 _aiTgtAim;

	private float _lastAimPickTime;

	private bool _didTeleportDurCurMove;

	private const float kProjCheckRadius = 0.5f;

	private static readonly Vector3 kDefaultSpritePos;

	private const float kCharZ = -0.25f;

	private CoroutineHandle _curShieldBounce;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Init()
	{
	}

	public void SetInitialPos(Vector3 pos)
	{
	}

	private void MyUpdate()
	{
	}

	private Vector2 UpdateTouchMovementControls()
	{
		return default(Vector2);
	}

	private void FixedUpdate()
	{
	}

	private bool UpdateCursorAim(bool allowChangeAim, Vector2 dir)
	{
		return false;
	}

	private void UpdateAim(bool allowChangeAim, bool isFakeAiming)
	{
	}

	public Vector3 GetMouseWorldPos()
	{
		return default(Vector3);
	}

	private void SetAimDir(Vector2 dir)
	{
	}

	private void SetAimDirDelayed(Vector2 dir)
	{
	}

	[IteratorStateMachine(typeof(_003C_SetAimDirDelayed_003Ed__54))]
	private IEnumerator<float> _SetAimDirDelayed(Vector2 dir)
	{
		return null;
	}

	public Vector2 GetLastAimDir()
	{
		return default(Vector2);
	}

	private void RunHitKnockback(Vector3 startPos, Vector3 tgtPos)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunHitKnockback_003Ed__58))]
	private IEnumerator<float> _RunHitKnockback(Vector3 startPos, Vector3 tgtPos)
	{
		return null;
	}

	private void MyFixedUpdate()
	{
	}

	public float GetPickupRange()
	{
		return 0f;
	}

	public bool IsAIActive()
	{
		return false;
	}

	public void VibrateController(float intensity, float len)
	{
	}

	public void ResetAim()
	{
	}

	public Vector3 GetMousePos()
	{
		return default(Vector3);
	}

	public Vector3 GetAimStartPos(int idx)
	{
		return default(Vector3);
	}

	private Vector3 GetDamageNumberPos()
	{
		return default(Vector3);
	}

	public bool CanBeDamaged(PieceDmgType dmgType)
	{
		return false;
	}

	public EnemyAttackResult Damage(float amt, PieceDmgType dmgType)
	{
		return default(EnemyAttackResult);
	}

	[IteratorStateMachine(typeof(_003C_HitFlash_003Ed__72))]
	private IEnumerator<float> _HitFlash()
	{
		return null;
	}

	private void CreateDamageNumber(Color c, int amt)
	{
	}

	public void Heal(float amt)
	{
	}

	public void RunLevelUpFX(StatType st, bool hasBonusUpgrade)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLevelUpFX_003Ed__77))]
	private IEnumerator<float> _RunLevelUpFX(StatType st, bool hasBonusUpgrade)
	{
		return null;
	}

	public void RunFuserFX()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunFuserFX_003Ed__79))]
	private IEnumerator<float> _RunFuserFX()
	{
		return null;
	}

	public float GetMinX()
	{
		return 0f;
	}

	public float GetMaxX()
	{
		return 0f;
	}

	public float ClampXPos(float x)
	{
		return 0f;
	}

	public float GetMinY()
	{
		return 0f;
	}

	public float GetMaxY()
	{
		return 0f;
	}

	public float ClampYPos(float y)
	{
		return 0f;
	}

	private bool IsAnyProjectileNearPos(Vector2 pos)
	{
		return false;
	}

	public bool ShouldAvoidProjectiles()
	{
		return false;
	}

	private bool IsAnyProjectileTargetingPos(Vector3 pos)
	{
		return false;
	}

	private void PickTgtPickup()
	{
	}

	private bool IsProjectileOnTheWay(Vector3 startPos, Vector3 tgtPos)
	{
		return false;
	}

	private void RunMoveAI()
	{
	}

	private void RunAI()
	{
	}

	private void MoveToAimDir(Vector2 tgtAimDir, float speedMult)
	{
	}

	public void RunBallKnockback(Vector2 aimDir)
	{
	}

	private void OnTacticsStateChanged()
	{
	}

	public void SetPos(Vector3 pos, bool snap = false)
	{
	}

	public Vector3 GetCharDefaultLocalPos(int idx)
	{
		return default(Vector3);
	}

	private void UpdateCharCoupleFollowing()
	{
	}

	public bool IsMoving()
	{
		return false;
	}

	public bool ShouldPlayMoveAnim()
	{
		return false;
	}

	public Vector2 GetLastMoveDir()
	{
		return default(Vector2);
	}

	public PlayerStatusEffect GetStatusEffect(PlayerStatusEffectType t)
	{
		return null;
	}

	public void ApplyStatusEffect(PlayerStatusEffect ef)
	{
	}

	private void OnGameSpeedChanged()
	{
	}

	private void RefreshAnimSpeed()
	{
	}

	private void RefreshMaterial()
	{
	}

	public void MyUpdateMoonComplete()
	{
	}

	public bool IsShielded()
	{
		return false;
	}

	public void PrintLvlThresholds()
	{
	}

	public Vector3 GetTextPartPos()
	{
		return default(Vector3);
	}

	public void SetState(PlayerState ps)
	{
	}

	public void RunTeleport(ObstacleObj teleporter)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunTeleport_003Ed__121))]
	private IEnumerator<float> _RunTeleport(ObstacleObj teleporter)
	{
		return null;
	}

	public void RunGameOver()
	{
	}

	public void RunShieldBounce()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunShieldBounce_003Ed__125))]
	private IEnumerator<float> _RunShieldBounce()
	{
		return null;
	}
}
