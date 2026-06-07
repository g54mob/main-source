using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GameCompleteObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__41 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameCompleteObj _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Transform _003Cmeteor_003E5__3;

		private Vector3 _003CmeteorStartPos_003E5__4;

		private float _003CfuserStartScale_003E5__5;

		private float _003CfuserTgtScale_003E5__6;

		private float _003Clen_003E5__7;

		private float _003CstartCamRot_003E5__8;

		private float _003CtgtCamRot_003E5__9;

		private float _003Cdist_003E5__10;

		private Vector3 _003CstartCamPos_003E5__11;

		private Vector3 _003CenviroStartPos_003E5__12;

		private float _003CstartFov_003E5__13;

		private float _003CtgtFov_003E5__14;

		private Color _003CfogStartColor_003E5__15;

		private Color _003CfogTgtColor_003E5__16;

		private bool _003CisCompletion_003E5__17;

		private float _003CentryLen_003E5__18;

		private Vector3 _003CcharRot_003E5__19;

		private float _003CstartCharXRot_003E5__20;

		private float _003CtgtCharXRot_003E5__21;

		private float _003CtgtCamDist_003E5__22;

		private bool _003CreachedPlane_003E5__23;

		private float _003CstartRadius_003E5__24;

		private int _003CrowIdx_003E5__25;

		private float _003CshrinkLen_003E5__26;

		private Vector3 _003CstartScale_003E5__27;

		private Vector3 _003CstartPos_003E5__28;

		private Vector3 _003CtgtPos_003E5__29;

		private float _003CstartFogStart_003E5__30;

		private float _003CstartFogEnd_003E5__31;

		private float _003CtgtFogStart_003E5__32;

		private float _003CtgtFogEnd_003E5__33;

		private float _003CtunnelRot_003E5__34;

		private float _003CtgtCharRadius_003E5__35;

		private Vector3 _003CcharBallylonOffset_003E5__36;

		private float _003CrotTot_003E5__37;

		private Vector3 _003CenviroTgt_003E5__38;

		private Vector3 _003CstartEnviroScale_003E5__39;

		private Vector3 _003CtgtEnviroScale_003E5__40;

		private Vector3 _003CtgtCamPos_003E5__41;

		private bool _003CplayedMusic_003E5__42;

		private int _003Cl_003E5__43;

		private LevelInfo _003ClInf_003E5__44;

		private int _003Ci_003E5__45;

		private GridPieceInfo _003CpInf_003E5__46;

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
		public _003C_Run_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003C_RunBallbylonLayers_003Ed__52 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameCompleteObj _003C_003E4__this;

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
		public _003C_RunBallbylonLayers_003Ed__52(int _003C_003E1__state)
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
	private sealed class _003C_WaitForSecondsSkippable_003Ed__50 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float secs;

		public GameCompleteObj _003C_003E4__this;

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
		public _003C_WaitForSecondsSkippable_003Ed__50(int _003C_003E1__state)
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

	public static GameCompleteObj I;

	public static bool sJustCompletedGame;

	public bool CanInterrupt;

	private List<PlayerCharController> _revolvers;

	private List<TrailRenderer> _revolverTrails;

	private List<float> _revolverSpeeds;

	private List<EnemyMeshController> _enemies;

	private List<FinaleEnemyInfo> _enemyData;

	private float _revolverMoveSpeed;

	public Transform WrapperChars;

	public GameObject WrapperBackground;

	public MeshRenderer RendBackground;

	public PartSys PartBackgroundStars;

	public Transform WrapperBackgroundAura;

	[Header("Materials")]
	public Material MatCharRainbow;

	public Material MatEnemyRainbow;

	private Material[] _matEnemyCharRainbow;

	public Material MatMoon;

	[Header("Wrappers")]
	public Transform WrapperEnemies;

	public Transform WrapperBallbylon;

	public Transform WrapperBallbylonEnviro;

	public Transform[] WrapperBallbylonLayers;

	public bool DidRunGameComplete;

	public bool DidRunCompleteProgress;

	private bool _isRunning;

	private bool _skipToNextSection;

	private bool _skipAll;

	private float _orbitTheta;

	private float _playerSpinAmt;

	private float _prevOrbitRadius;

	private float _orbitRadius;

	private bool _skipShootPortion;

	private CoroutineHandle _runAnim;

	private CoroutineHandle _updateAnim;

	private float _enemyRadiusSpeed;

	private Vector3 _moonRotSpeed;

	public TrailRenderer PrefabRainbowTrail;

	private float _skipHoldTime;

	private float _ballbyonLayerSpeed;

	private void Awake()
	{
	}

	public void Run()
	{
	}

	private void RemoveEverything()
	{
	}

	public void SkipShootPortion()
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__41))]
	private IEnumerator<float> _Run()
	{
		return null;
	}

	private void UpdateOrbitingEnemies()
	{
	}

	private void UpdatePlayerRevolution(float speed, float spinSpeed, bool isEnding = false)
	{
	}

	private void SetPlayerTheta(float theta, bool isEnding = false)
	{
	}

	private void SetOrbitRadius(float r)
	{
	}

	public bool IsRunning()
	{
		return false;
	}

	private void UpdateRunning()
	{
	}

	private float WaitForSecondsSkippable(float secs)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_WaitForSecondsSkippable_003Ed__50))]
	private IEnumerator<float> _WaitForSecondsSkippable(float secs)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunBallbylonLayers_003Ed__52))]
	private IEnumerator<float> _RunBallbylonLayers()
	{
		return null;
	}
}
