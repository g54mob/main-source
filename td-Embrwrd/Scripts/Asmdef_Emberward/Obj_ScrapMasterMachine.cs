using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_ScrapMasterMachine : MonoBehaviour, IVisionObject
{
	[CompilerGenerated]
	private sealed class _003CCR_LevelUp_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_ScrapMasterMachine _003C_003E4__this;

		private UI_ChooseScrapMasterPerk_Popup _003CupgradeWindow_003E5__2;

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
		public _003CCR_LevelUp_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003CStart_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_ScrapMasterMachine _003C_003E4__this;

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
		public _003CStart_003Ed__50(int _003C_003E1__state)
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
	private sealed class _003CStepRoutine_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_ScrapMasterMachine _003C_003E4__this;

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
		public _003CStepRoutine_003Ed__63(int _003C_003E1__state)
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

	public static Obj_ScrapMasterMachine Instance;

	[Header("設定檔案")]
	[SerializeField]
	private ScrapMasterSettingAssetData scrapMasterSettingAssetData;

	[Header("Animator")]
	[SerializeField]
	private Animator animator;

	[SerializeField]
	[Header("移動速度")]
	private float moveSpeed;

	[SerializeField]
	[Header("轉動速度")]
	private float rotateSpeed;

	[SerializeField]
	[Header("移動時的傾斜角度")]
	private float tiltAngle;

	[SerializeField]
	[Header("傾斜速度")]
	private float tiltSpeed;

	[SerializeField]
	[Header("Particle: 開始控制時的蒸氣")]
	private ParticleSystem list_StartControlSteam;

	[Header("Particle: Overcharge特效")]
	[SerializeField]
	private List<ParticleSystem> list_OverchargeParticles;

	[SerializeField]
	[Header("Particle: 升級")]
	private ParticleSystem particle_LevelUp;

	[SerializeField]
	[Header("FogOfWar範圍物件")]
	private Transform fogOfWarRangeObject;

	[SerializeField]
	[Header("1x1建造平台")]
	private List<Obj_ScrapMasterPlatform_1x1> list_Panel_1x1;

	[Header("2x2建造平台")]
	[SerializeField]
	private List<Obj_ScrapMasterPlatform_1x1> list_Panel_2x2;

	[SerializeField]
	[Header("3x3建造平台")]
	private Obj_ScrapMasterPlatform_1x1 obj_panel_3x3;

	[SerializeField]
	[Header("Base節點")]
	private Transform node_Base;

	[SerializeField]
	[Header("瞄準框物件")]
	private Transform node_AimPosition;

	[Header("所有武器的連結")]
	[SerializeField]
	private List<AObj_ScrapMasterMachineWeapon> list_Weapons;

	[Header("所有腳部的連結")]
	[SerializeField]
	private List<SpiderLegIK> legs;

	[Header("收集經驗值範圍")]
	[SerializeField]
	private float collectExpRange;

	[SerializeField]
	[Header("每隻腳觸發移動的最小間隔")]
	private float stepCooldown;

	[Header("最多幾隻腳同時移動")]
	[SerializeField]
	private int maxLegsMovingAtOnce;

	private float collectExpRangeMultiplier;

	private List<Obj_ScrapMasterPlatform_1x1> list_DynamicPlacementTargets;

	private List<ABaseTower> list_TowersOnMachine;

	private Vector3 movingDirection;

	private Vector3 targetBaseTilt;

	private bool isInControl;

	private Obj_FireSource playerOrigin;

	private bool isSkeletonKing;

	public Action<bool> OnControlStateChanged;

	private float moveRangeLimit;

	private float overChargeTimer;

	private int scheduledLevelUpCount;

	private bool isInLevelupProcess;

	private UI_ScrapMasterMachineControlTip_Popup ui_ControlTipPopup;

	private bool isTopOpen;

	private float interactiveEventInterval;

	private float interactiveEventTimer;

	private List<SpiderLegIK> list_MovedLegs;

	private int collectedExpInTime;

	private float collectExpTimer;

	private float collectExpResetInterval;

	private Vector3 currentAimPosition;

	private bool isAimRingVisible;

	private bool doShowAimRing;

	public Transform Node_Base => null;

	public int ScheduledLevelUpCount => 0;

	public Vector3 CurrentAimPosition => default(Vector3);

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestSwitchScrapMachineControl()
	{
	}

	private void OnPlayerVictoryOrDefeat()
	{
	}

	private void OnRequestOverchargeScrapMasterMachine()
	{
	}

	private void OnScrapMasterLevelUp()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LevelUp_003Ed__45))]
	private IEnumerator CR_LevelUp()
	{
		return null;
	}

	private List<ScrapMasterCardData> GetAvailableUpgradeCards(int curLevel, int count)
	{
		return null;
	}

	private void OnUpgradeSelected(ScrapMasterCardData data)
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__50))]
	private IEnumerator Start()
	{
		return null;
	}

	private void OnDynamicPlacementTargetPlaced(ABaseTower tower)
	{
	}

	public void SwitchControl(bool isControl)
	{
	}

	public void ToggleTop(bool isOpen)
	{
	}

	private void Update()
	{
	}

	private bool IsTargetPositionAvailable(Vector3 targetPosition, Vector3 moveDirection)
	{
		return false;
	}

	public static bool IsChildOf(GameObject target, Transform findIn)
	{
		return false;
	}

	private static bool IsChildRecursive(Transform target, Transform parent)
	{
		return false;
	}

	private bool RaycastCheckIfGroundExist(Vector3 position)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CStepRoutine_003Ed__63))]
	private IEnumerator StepRoutine()
	{
		return null;
	}

	public float GetCollectExpRange()
	{
		return 0f;
	}

	public void CollectExp(int value)
	{
	}

	private void UpdateAimPosition()
	{
	}

	private void UpdateAimRingVisibility()
	{
	}

	private void InitializeFromData()
	{
	}

	public float GetVisionRange()
	{
		return 0f;
	}

	public Vector3 GetVisionPosition()
	{
		return default(Vector3);
	}
}
