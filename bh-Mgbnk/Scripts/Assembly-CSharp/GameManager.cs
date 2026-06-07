using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoDeathAnimation_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private float _003CanimationTime_003E5__2;

		private float _003Ctime_003E5__3;

		private Transform _003CplayerTransform_003E5__4;

		private Vector3 _003CrotationPoint_003E5__5;

		private Vector3 _003CrotationAxis_003E5__6;

		private Quaternion _003CinitialRotation_003E5__7;

		private Vector3 _003CradiusVector_003E5__8;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
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
		public _003CDoDeathAnimation_003Ed__41(int _003C_003E1__state)
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

	public LayerMask whatIsGround;

	public LayerMask whatIsProjectileRaycast;

	public LayerMask whatIsEnemy;

	public LayerMask whatIsObjects;

	public LayerMask whatIsPlayer;

	public LayerMask whatIsGroundAndObjects;

	public LayerMask whatIsCameraCollision;

	public LayerMask whatIsBlockingRails;

	public LayerMask whatIsProjectileObstruction;

	private float gameTimer;

	public static GameManager Instance;

	public static Action A_StageStarted;

	public static Action A_RunStarted;

	public static Action A_GameOver;

	public MyPlayer player;

	public PlayerCamera playerCamera;

	public UiManager uiManager;

	public int bossCurses;

	private bool inited;

	private bool hasSetMapDifficulty;

	private float nextGetStageTime;

	private float getMaxStageTimeInterval;

	private float lastFoundStageTime;

	public static Action A_DungeonStarted;

	public static Action A_DungeonEnded;

	private bool isPlaying;

	public bool cutscene;

	public bool isGameOver { get; private set; }

	public bool isCrypt { get; private set; }

	public bool isDungeonTimerStarted { get; private set; }

	public float dungeonTimeToComplete { get; private set; }

	public bool isDungeonOvertime { get; private set; }

	public int cryptIndex { get; private set; }

	private void Awake()
	{
	}

	private void TryInit()
	{
	}

	private void OnPlayerInit(PlayerInventory inventory)
	{
	}

	public void CreateInstances()
	{
	}

	public float GetStageTimeMax()
	{
		return 0f;
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public PlayerMovement GetPlayerMovement()
	{
		return null;
	}

	public MyPlayer GetPlayer()
	{
		return null;
	}

	public float GetAliveTime()
	{
		return 0f;
	}

	public PlayerInventory GetPlayerInventory()
	{
		return null;
	}

	private void OnDied()
	{
	}

	public void OnTeleportAway()
	{
	}

	[IteratorStateMachine(typeof(_003CDoDeathAnimation_003Ed__41))]
	private IEnumerator DoDeathAnimation()
	{
		return null;
	}

	public bool IsFinalSwarm()
	{
		return false;
	}

	public void StartDungeon(float timeToComplete)
	{
	}

	public void StopDungeon()
	{
	}

	public void StartDungeonTimer()
	{
	}

	private void ResumeEnemyGroundCollision()
	{
	}

	private void StartDungeonOvertime()
	{
	}

	public static float GetViewDistance()
	{
		return 0f;
	}

	public static float GetViewDistanceSqr()
	{
		return 0f;
	}

	public static float GetEnemyTeleportDistance()
	{
		return 0f;
	}

	public static float GetEnemyTeleportDistanceSqr()
	{
		return 0f;
	}

	public bool IsTimeFreeze()
	{
		return false;
	}

	public bool IsPlaying()
	{
		return false;
	}

	public bool IsFinalBossDead()
	{
		return false;
	}

	public void StartPlaying()
	{
	}

	public bool HasEnteredBossRoom()
	{
		return false;
	}

	private void OnStageBossDied()
	{
	}
}
