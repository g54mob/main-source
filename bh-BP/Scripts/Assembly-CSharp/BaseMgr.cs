using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using FMODUnity;
using MEC;
using UnityEngine;

public class BaseMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_LaunchWorkers_003Ed__52 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		public Vector2 aimDir;

		private float _003ClastShootTime_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003C_LaunchWorkers_003Ed__52(int _003C_003E1__state)
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
	private sealed class _003C_MoveXfmToHarvestUIXfm_003Ed__78 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform uiXfm;

		public Transform xfm;

		private float _003Cspeed_003E5__2;

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
		public _003C_MoveXfmToHarvestUIXfm_003Ed__78(int _003C_003E1__state)
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
	private sealed class _003C_MoveXfmToResourceGain_003Ed__77 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		public Transform xfm;

		public ResourceType rt;

		public int num;

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
		public _003C_MoveXfmToResourceGain_003Ed__77(int _003C_003E1__state)
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
	private sealed class _003C_PlayHarvestSFXOnNextBeat_003Ed__50 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		private int _003CstartBeat_003E5__2;

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
		public _003C_PlayHarvestSFXOnNextBeat_003Ed__50(int _003C_003E1__state)
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
	private sealed class _003C_RunElevatorUpgrade_003Ed__76 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		private int _003CnumGears_003E5__2;

		private List<PickupObj> _003Cgears_003E5__3;

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
		public _003C_RunElevatorUpgrade_003Ed__76(int _003C_003E1__state)
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
	private sealed class _003C_RunEnterWorkerMode_003Ed__41 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		private bool _003CisAnyoneWalking_003E5__2;

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
		public _003C_RunEnterWorkerMode_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003C_RunEnteringLvl_003Ed__64 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private bool _003CdidLeave_003E5__3;

		private float _003Clen_003E5__4;

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
		public _003C_RunEnteringLvl_003Ed__64(int _003C_003E1__state)
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
	private sealed class _003C_RunExpansionEntry_003Ed__43 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

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
		public _003C_RunExpansionEntry_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003C_RunReturningFromLvl_003Ed__69 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		private EventInstance _003CascendSfx_003E5__2;

		private EventInstance _003CloopingSfx_003E5__3;

		private float _003Clen_003E5__4;

		private float _003CstartTime_003E5__5;

		private Vector3 _003CtgtPos_003E5__6;

		private Vector3 _003CstartPos_003E5__7;

		private int _003CnCols_003E5__8;

		private int _003CnRows_003E5__9;

		private EventInstance _003CwhooshSfx_003E5__10;

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
		public _003C_RunReturningFromLvl_003Ed__69(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndTakeStuffFromBuildings_003Ed__32 : IEnumerator<float>, IEnumerator, IDisposable
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
		public _003C_WaitAndTakeStuffFromBuildings_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003C_WaitForCurrentVibrationAndVibrate_003Ed__85 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseMgr _003C_003E4__this;

		public float intensity;

		public float len;

		private float _003CendTime_003E5__2;

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
		public _003C_WaitForCurrentVibrationAndVibrate_003Ed__85(int _003C_003E1__state)
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

	public static BaseMgr I;

	public Sprite SprEmptySpace;

	public SpriteAnimClip ClipScaffold;

	public BaseState CurState;

	public float LastStateChangeTime;

	public EventReference SFXAmbience;

	public BuildingInfo BuildTgt;

	public BasePlayer BPlayer;

	public List<CharMetaInst> ActiveWorkers;

	public int CurWorkerIdx;

	public float LastHarvestTime;

	public float RemainingHarvestSecs;

	public List<BallObj> ActiveBalls;

	public List<Vector3> WorkerStartPos;

	public Material[] CharSpeedAuraMats;

	public Material[] CharSpeedTrailMats;

	public Cost ResourcesGathered;

	public List<BuildingObj> CompletedBuildings;

	public DelegateUtl.NoArgsEvent OnStateChanged;

	private CoroutineHandle _launchAnim;

	private bool _abandonedLaunch;

	private CoroutineHandle _curCutsceneAnim;

	public static bool sReturningFromGame;

	public static Cost sLastGameResources;

	public int[][] NumClockAddsPerResourcePerChar;

	public Collider2D ColBaseBottom;

	private EventInstance _loopingSFX;

	private List<NumberSprite> _resourceNumbers;

	private float _bHeldStartTime;

	private const float kBallTimeDist = 0.3f;

	private const float kNoHarvestReturnTime = 15f;

	private const float kNoHarvestWarningLen = 3f;

	private List<PickupObj> _elevatorPickups;

	private bool _skipReturningFromLvl;

	private float _lastVibrateTime;

	private float _lastVibrateIntensity;

	private float _lastVibrateLen;

	private CoroutineHandle _vbWaitAnim;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnReturnToBaseComplete()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndTakeStuffFromBuildings_003Ed__32))]
	private IEnumerator<float> _WaitAndTakeStuffFromBuildings()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	private void MyUpdate()
	{
	}

	public void OnBPressed()
	{
	}

	public void AbandonHarvest()
	{
	}

	public void SetState(BaseState st, bool force = false)
	{
	}

	public void SetUpActiveWorkers()
	{
	}

	public void InitWorkerMode()
	{
	}

	public void SnapWorkerPos()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunEnterWorkerMode_003Ed__41))]
	private IEnumerator<float> _RunEnterWorkerMode()
	{
		return null;
	}

	public void ExitWorkerMode()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunExpansionEntry_003Ed__43))]
	private IEnumerator<float> _RunExpansionEntry()
	{
		return null;
	}

	public void InitLauncherMode()
	{
	}

	public void ExitLauncherMode()
	{
	}

	public bool IsInWorkerMode()
	{
		return false;
	}

	public bool IsInWorkerMode(BaseState st)
	{
		return false;
	}

	public CharMetaInst GetCurActiveWorker()
	{
		return null;
	}

	public void LaunchWorkers(Vector2 aimDir)
	{
	}

	[IteratorStateMachine(typeof(_003C_PlayHarvestSFXOnNextBeat_003Ed__50))]
	private IEnumerator<float> _PlayHarvestSFXOnNextBeat()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_LaunchWorkers_003Ed__52))]
	private IEnumerator<float> _LaunchWorkers(Vector2 aimDir)
	{
		return null;
	}

	public void LaunchIdleLauncher(BuildingObj launcher)
	{
	}

	public void LaunchBaby(BuildingObj launcher, Vector2 aimDir)
	{
	}

	public BallObj CreateWorker(CharMetaInst w, Vector2 aimDir)
	{
		return null;
	}

	public void RemoveWorker(BallObj b)
	{
	}

	private void MoveBalls()
	{
	}

	private void OnInputChanged()
	{
	}

	public void RefreshControllerCursor()
	{
	}

	public bool ShouldShowControllerCursor()
	{
		return false;
	}

	private void InitCharsOnElevator(Transform char1Xfm, Transform char2Xfm)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunEnteringLvl_003Ed__64))]
	private IEnumerator<float> _RunEnteringLvl()
	{
		return null;
	}

	private void CompleteEnterLvl()
	{
	}

	private PickupObj CreateElevatorResource(int idx, PickupType pt, int val, float randRadius = 0f, float randHeight = 0f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunReturningFromLvl_003Ed__69))]
	private IEnumerator<float> _RunReturningFromLvl()
	{
		return null;
	}

	public void DepositResources(ResourceType rt, int num)
	{
	}

	public void DepositResources(Cost c)
	{
	}

	public void IncreaseHarvestClock(CharType c, ResourceType rt, float secs, Vector3 pos)
	{
	}

	public bool IsElevatorUpgradeVisible()
	{
		return false;
	}

	public Cost GetElevatorUpgradeCost()
	{
		return null;
	}

	public void RunElevatorUpgrade()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunElevatorUpgrade_003Ed__76))]
	private IEnumerator<float> _RunElevatorUpgrade()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveXfmToResourceGain_003Ed__77))]
	public IEnumerator<float> _MoveXfmToResourceGain(Transform xfm, ResourceType rt, int num)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveXfmToHarvestUIXfm_003Ed__78))]
	public IEnumerator<float> _MoveXfmToHarvestUIXfm(Transform xfm, RectTransform uiXfm)
	{
		return null;
	}

	public void VibrateController(float intensity, float len, bool allowOverride = false)
	{
	}

	private void WaitForCurrentVibrationAndVibrate(float intensity, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitForCurrentVibrationAndVibrate_003Ed__85))]
	private IEnumerator<float> _WaitForCurrentVibrationAndVibrate(float intensity, float len)
	{
		return null;
	}

	public void RegisterResourceNum(NumberSprite spr)
	{
	}

	public void CompleteResourceNum(int idx)
	{
	}
}
