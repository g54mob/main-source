using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class BallMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RecallBalls_003Ed__60 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallMgr _003C_003E4__this;

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
		public _003C_RecallBalls_003Ed__60(int _003C_003E1__state)
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
	private sealed class _003C_RunBalls_003Ed__41 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallMgr _003C_003E4__this;

		private float _003CcurTime_003E5__2;

		private float _003CnextLaunchTime_003E5__3;

		private int _003CballIdx_003E5__4;

		private int _003CfollowerIdx_003E5__5;

		private int _003CmaxBallIdx_003E5__6;

		private int _003CmaxFollowerIdx_003E5__7;

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
		public _003C_RunBalls_003Ed__41(int _003C_003E1__state)
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

	public static BallMgr I;

	public List<BallObj> ActiveBalls;

	public List<BallObj> EarlyReturnedBalls;

	public List<BallObj> SideBalls;

	public List<BallObj> AdultSideBalls;

	private int _curBallIdx;

	private int _numActiveFollowers;

	private int _earlyReturnedFollowers;

	public List<float> RechargingFollowers;

	private bool _didAnyBallStartToReturn;

	private bool _didAnyBallReturn;

	private float _lastShootCompleteUnityTime;

	private BallState _curState;

	private bool _allowAutoChange;

	public float LastShootCompleteTime;

	public DelegateUtl.NoArgsEvent OnStateChanged;

	public DelegateUtl.NoArgsEvent OnCurBallChanged;

	private CoroutineHandle _ballAnim;

	private bool _isShootInterrupted;

	private ContactFilter2D _filtBounce;

	private ContactFilter2D _filtEnemies;

	private ContactFilter2D _filtObstacles;

	public const float kMinAngle = 20f;

	public const float kMaxAngle = 160f;

	private List<BallObj> _justLaunchedBalls;

	private List<BallObj> _justLaunchedAltBalls;

	private Vector3 _lobTgtPos;

	private Vector2 _altAimDir;

	public const int kSideBallLimit = 1000;

	public const int kAdultSideBallLimit = 30;

	public const float kShootRecencyLen = 0.5f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void MyUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	public float GetMinTheta()
	{
		return 0f;
	}

	public float GetMaxTheta()
	{
		return 0f;
	}

	public Vector2 MousePosToAimDir(Vector3 mousePos, int charIdx)
	{
		return default(Vector2);
	}

	public static Vector2 ClampAimDir(Vector2 aimDir, AimMode aimMode, int charIdx)
	{
		return default(Vector2);
	}

	public float AimDirToTheta(Vector2 aimDir)
	{
		return 0f;
	}

	public Vector2 ThetaToAimDir(float theta)
	{
		return default(Vector2);
	}

	public Vector2 GetCurAimDir()
	{
		return default(Vector2);
	}

	public void RunBalls()
	{
	}

	public Vector2 GetCachedAltAimDir()
	{
		return default(Vector2);
	}

	[IteratorStateMachine(typeof(_003C_RunBalls_003Ed__41))]
	private IEnumerator<float> _RunBalls()
	{
		return null;
	}

	public void CancelShoot()
	{
	}

	public void RefreshBallPreview()
	{
	}

	private void RotateBall(BallObj b)
	{
	}

	public bool MoveBall(BallObj b, bool isSide, Vector3 playerPos, Vector3 playerCharPos1, Vector3 playerCharPos2, bool[] propArray)
	{
		return false;
	}

	public void MoveBalls()
	{
	}

	public void LaunchRandomBabiesPassive(PassiveInst p, Vector3 pos, int min, int max, float minTheta = 9999f, float maxTheta = 9999f)
	{
	}

	public void LaunchRandomBabies(Vector3 pos, int min, int max, BallSourceType src, HeroInst srcHero, float minTheta = 9999f, float maxTheta = 9999f)
	{
	}

	public BallObj CreateBall(HeroInst b, bool isBaby, Vector2 aimDir, BallSourceType src)
	{
		return null;
	}

	private void RunSelfDestroyer(BallObj b, Vector3 hitPoint, bool isSide)
	{
	}

	private void LobBall(BallObj bObj, Vector3 startPos)
	{
	}

	public BallObj CreatePassiveSideBall(PassiveInst p, Vector3 pos, Vector2 aimDir)
	{
		return null;
	}

	public BallObj CreateSideBall(HeroInst parent, Vector3 pos, Vector2 aimDir, BallSourceType src)
	{
		return null;
	}

	public BallObj CreateAdultSideBall(HeroInst parent, HeroInst hInst, Vector3 pos, Vector2 aimDir, BallSourceType src)
	{
		return null;
	}

	public void RemoveBall(BallObj b, bool isSide, BallReturnType retType)
	{
	}

	public bool DidAnyBallReturn()
	{
		return false;
	}

	public void RecallBalls()
	{
	}

	[IteratorStateMachine(typeof(_003C_RecallBalls_003Ed__60))]
	private IEnumerator<float> _RecallBalls()
	{
		return null;
	}

	public int GetNumActiveNotReturningBalls()
	{
		return 0;
	}

	public int GetNumRecalledBalls()
	{
		return 0;
	}

	public float GetRecalledBallPct()
	{
		return 0f;
	}

	public void SetBallState(BallState bs)
	{
	}

	public BallState GetBallState()
	{
		return default(BallState);
	}

	private void OnGameSpeedChanged()
	{
	}

	public int GetNumReadyFollowers()
	{
		return 0;
	}

	public int GetNumActiveFollowers()
	{
		return 0;
	}

	public int GetNumEarlyReturnedFollowers()
	{
		return 0;
	}

	private void CycleToNextReadyBall(bool stayIfNone)
	{
	}

	public void SetCurBallIdx(int idx)
	{
	}

	public int GetCurBallIdx()
	{
		return 0;
	}

	private void OnHeroesChanged()
	{
	}

	public void SetAllowAutoChange(bool isOn)
	{
	}

	public HeroInst GetCurHero()
	{
		return null;
	}

	public bool IsReadyToShoot()
	{
		return false;
	}

	public float GetBounceRecencyThreshold()
	{
		return 0f;
	}

	public void DamageRandomPiece(BallObj b)
	{
	}

	public bool DidShootRecently()
	{
		return false;
	}
}
