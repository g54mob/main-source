using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

[SelectionBase]
public abstract class ABaseTower : MonoBehaviour, IPlaceable, IElectricConductor, IVisionObject, IInteractable
{
	public enum eUpgradeType
	{
		NONE = 0,
		BASIC = 1,
		UPGRADE_A = 2,
		UPGRADE_B = 3
	}

	[CompilerGenerated]
	private sealed class _003CCR_SetTowerSpawnFinished_003Ed__139 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ABaseTower _003C_003E4__this;

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
		public _003CCR_SetTowerSpawnFinished_003Ed__139(int _003C_003E1__state)
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
	private sealed class _003CCR_ShineEffect_003Ed__161 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ABaseTower _003C_003E4__this;

		public float startDuration;

		public float endDuration;

		private Material _003Cmat_003E5__2;

		private float _003Ct_003E5__3;

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
		public _003CCR_ShineEffect_003Ed__161(int _003C_003E1__state)
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
	private sealed class _003CCR_UpgradeEffect_003Ed__159 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ABaseTower _003C_003E4__this;

		private float _003CstartDuration_003E5__2;

		private float _003CendDuration_003E5__3;

		private Material _003Cmat_003E5__4;

		private float _003Ct_003E5__5;

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
		public _003CCR_UpgradeEffect_003Ed__159(int _003C_003E1__state)
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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonDespawnProc_003Ed__178 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonMoveProc_003Ed__177 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonSpawnProc_003Ed__174 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonUpgradeProc_003Ed__176 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003COnBattleStartProc_003Ed__179 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003COnRoundEndProc_003Ed__181 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003COnRoundStartProc_003Ed__180 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	[Header("設定資料")]
	protected TowerSettingData settingData;

	[SerializeField]
	protected Animator animator;

	[Header("砲台Renderer")]
	[SerializeField]
	protected Renderer renderer_Tower;

	[SerializeField]
	[Header("砲台Renderer")]
	protected List<Renderer> list_TowerRenderers;

	[SerializeField]
	protected ParticleSystem particle_ShootEffect;

	[SerializeField]
	[Header("常駐的碰撞collider")]
	protected Collider collider;

	[SerializeField]
	[Header("判斷放置時使用的collider, 不可以跟碰撞共用")]
	protected List<Collider> list_PlacementColliders;

	[Header("砲台的旋轉節點")]
	[SerializeField]
	protected Transform node_CannonHeadModel;

	[SerializeField]
	[Header("發射點node")]
	protected Transform node_ShootPosition;

	[Header("戰爭迷霧區域的Renderer")]
	[SerializeField]
	protected Renderer renderer_FogOfWar;

	[Header("是否會旋轉面向目標")]
	[SerializeField]
	protected bool doRotate;

	[SerializeField]
	[Header("升級A的替換材質")]
	protected List<TowerSkinMaterialSet> list_TowerSkin_UpgradeA;

	[SerializeField]
	[Header("升級A要額外加入list_Renderer的物件")]
	protected List<Renderer> list_ExtraRenderer_UpgradeA;

	[SerializeField]
	[Header("升級B的替換材質")]
	protected List<TowerSkinMaterialSet> list_TowerSkin_UpgradeB;

	[Header("升級B要額外加入list_Renderer的物件")]
	[SerializeField]
	protected List<Renderer> list_ExtraRenderer_UpgradeB;

	[SerializeField]
	protected eTowerTargetPriority targetPriority;

	[SerializeField]
	[Header("遠古之火休眠效果")]
	protected int dormantRoundCount;

	protected float dormantTimer;

	protected float shootTimer;

	[SerializeField]
	protected AMonsterBase currentTarget;

	[SerializeField]
	protected int level;

	[SerializeField]
	protected List<TowerImmuneData> list_ImmuneData;

	protected List<Obj_TetrisBlock> list_ConnectedTetris;

	protected bool isInitialized;

	protected int deployedRoundCount;

	protected int shootIndex;

	protected int bulletIndex;

	protected int dealtDamage;

	protected int killedCount;

	protected int buildCost;

	protected int upgradeSpentCost;

	protected int extraSellValue;

	private bool isTowerSpawnFinished;

	private float idleAnimationTimer;

	private Vector3 startRotation;

	private float tooltipDelayOnPlacement;

	private float towerStunTimer;

	private float timeSinceLastShoot;

	protected bool canReceiveBuffCardEffect;

	private bool isForceDisabled;

	private List<eItemType> list_AppliedBuff;

	protected List<APowerGrid> list_AppliedPowerGrid;

	protected IDynamicPlacementTarget dynamicPlacementTarget;

	[SerializeField]
	protected eUpgradeType upgradeType;

	[SerializeField]
	private TowerBuffModule towerBuffModule;

	public Action<ABaseTower> OnTowerSpawn;

	public Action<ABaseTower, AMonsterBase> OnTowerShoot;

	public Action<ABaseTower> OnTowerDespawn;

	public Action<ABaseTower, AMonsterBase, int, int> OnTowerHit;

	public Action<ABaseTower, AMonsterBase> OnTowerKillMonster;

	public Action<ABaseTower> OnTowerRecordChange;

	public Action<ABaseTower> OnTowerStatChanged;

	public Action<ABaseTower> OnTowerUpgrade;

	public Action<ABaseTower, float, AMonsterBase> OnMonsterApplyStunToTower;

	public Action<ABaseTower, float, AMonsterBase> OnTowerStunned;

	public Action<ABaseTower> OnTowerStunEnded;

	public Action<ABaseTower, eDamageType> OnTowerElementChanged;

	private Sequence jumpSequence;

	private UI_TowerActivateCounter ui_TowerActivateCounter;

	private Material mat_DormantEffect;

	private bool isDormantMaterial;

	private bool isRegisteredToGridSystem;

	protected List<GameObject> list_UpgradePanels;

	private bool isTooltipOn;

	private bool isOutlineOn;

	private List<Vector3Int> list_BasePositions;

	public TowerSettingData SettingData => null;

	public Animator Animator => null;

	public Renderer Renderer_Tower => null;

	public List<Renderer> List_TowerRenderers => null;

	public Collider Collider => null;

	public Vector3 ShootWorldPosition => default(Vector3);

	public bool DoRotate => false;

	public eTowerTargetPriority TargetPriority => default(eTowerTargetPriority);

	public int DormantRoundCount => 0;

	[SerializeField]
	public Vector3 TowerCenterWorldPosition => default(Vector3);

	public int Level => 0;

	public bool IsInitialized => false;

	public int DeployedRoundCount => 0;

	public int DealtDamage => 0;

	public int KilledCount => 0;

	public int UpgradeSpentCost => 0;

	public bool IsTowerSpawnFinished => false;

	public float TimeSinceLastShoot => 0f;

	public bool CanReceiveBuffCardEffect => false;

	public IDynamicPlacementTarget DynamicPlacementTarget => null;

	public eUpgradeType UpgradeType => default(eUpgradeType);

	public TowerBuffModule TowerBuffModule => null;

	protected void Awake()
	{
	}

	protected void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	protected void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	protected virtual void StunnedTowerUpdateProc(float deltaTime)
	{
	}

	private void LateUpdate()
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnRoundStart(int arg1, int arg2)
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	public void TowerJumpEffect(float jumpPower, float duration, float delay)
	{
	}

	public void AddImmuneToStun(float duration, int id)
	{
	}

	public void RemoveImmuneToStun(int id)
	{
	}

	private void UpdateImmuneData(float deltaTime)
	{
	}

	public bool IsImmuneToStun()
	{
		return false;
	}

	public void ApplyStun(float duration, bool doPlaySound = true, AMonsterBase fromMonster = null)
	{
	}

	public void RemoveTowerStunEffect()
	{
	}

	public virtual void TowerStunProc()
	{
	}

	public virtual void TowerStunEndProc()
	{
	}

	public bool IsStunned()
	{
		return false;
	}

	public bool IsNotFunctioning()
	{
		return false;
	}

	public void SetDormantRoundCount(int count)
	{
	}

	public virtual void TowerDormantEndProc()
	{
	}

	public bool IsDormant()
	{
		return false;
	}

	private void UpdateDormantEffectVisual()
	{
	}

	public void ShowVisionRange()
	{
	}

	public virtual float GetVisionRange()
	{
		return 0f;
	}

	public virtual Vector3 GetVisionPosition()
	{
		return default(Vector3);
	}

	public void Spawn(int buildCost, bool doRegisterToGrid)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SetTowerSpawnFinished_003Ed__139))]
	private IEnumerator CR_SetTowerSpawnFinished()
	{
		return null;
	}

	public void SetDynamicPlacementTarget(IDynamicPlacementTarget target)
	{
	}

	protected virtual void SetDynamicPlacementTargetProc(IDynamicPlacementTarget target)
	{
	}

	public void ShowRangeChangeWithMultiplier(float multiplier)
	{
	}

	public void ShowRangeChangeWithFlatValue(float newRange)
	{
	}

	public void HideRangeChange()
	{
	}

	private void ApplyTowerTalentBuff()
	{
	}

	public void Despawn()
	{
	}

	public void Move()
	{
	}

	public void Shoot()
	{
	}

	public void ResetShootCooldown()
	{
	}

	public void ReduceCooldown(float amount)
	{
	}

	public void OverrideDeployedRoundCount(int newCount)
	{
	}

	public int GetUpgradeCost(eUpgradeType upgradeType)
	{
		return 0;
	}

	public List<TowerStats> GetUpgradeExtraStats(eUpgradeType upgradeType)
	{
		return null;
	}

	public bool IsMaxLevel()
	{
		return false;
	}

	public bool IsUpgradeType(eUpgradeType upgradeType)
	{
		return false;
	}

	public void Upgrade(eUpgradeType upgradeType, bool isFromPlayer, bool isFree = false)
	{
	}

	public void PlayUpgradeEffect()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_UpgradeEffect_003Ed__159))]
	private IEnumerator CR_UpgradeEffect()
	{
		return null;
	}

	public void PlayShineEffect(float startDuration = 0.15f, float endDuration = 0.33f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShineEffect_003Ed__161))]
	private IEnumerator CR_ShineEffect(float startDuration = 0.15f, float endDuration = 0.33f)
	{
		return null;
	}

	public virtual void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	public virtual int GetMaxLevel()
	{
		return 0;
	}

	public int GetCost(float multiplier = 1f)
	{
		return 0;
	}

	public virtual int GetBuildCost()
	{
		return 0;
	}

	public void AddSellValue(int value)
	{
	}

	public virtual int GetSellValue()
	{
		return 0;
	}

	public float GetCritChance()
	{
		return 0f;
	}

	public string GetLocExtraBuffString()
	{
		return null;
	}

	public Vector3 GetTowerVFXScale()
	{
		return default(Vector3);
	}

	public virtual Vector3 GetTowerAttackCenter()
	{
		return default(Vector3);
	}

	public int GetAppliedPowerGridCount()
	{
		return 0;
	}

	protected abstract void ShootProc();

	[AsyncStateMachine(typeof(_003CCannonSpawnProc_003Ed__174))]
	protected virtual void CannonSpawnProc()
	{
	}

	protected virtual void CannonUpdateProc()
	{
	}

	[AsyncStateMachine(typeof(_003CCannonUpgradeProc_003Ed__176))]
	protected virtual void CannonUpgradeProc()
	{
	}

	[AsyncStateMachine(typeof(_003CCannonMoveProc_003Ed__177))]
	protected virtual void CannonMoveProc()
	{
	}

	[AsyncStateMachine(typeof(_003CCannonDespawnProc_003Ed__178))]
	protected virtual void CannonDespawnProc()
	{
	}

	[AsyncStateMachine(typeof(_003COnBattleStartProc_003Ed__179))]
	protected virtual void OnBattleStartProc()
	{
	}

	[AsyncStateMachine(typeof(_003COnRoundStartProc_003Ed__180))]
	protected virtual void OnRoundStartProc()
	{
	}

	[AsyncStateMachine(typeof(_003COnRoundEndProc_003Ed__181))]
	protected virtual void OnRoundEndProc()
	{
	}

	public virtual List<Collider> GetCollisionColliders()
	{
		return null;
	}

	public virtual List<Collider> GetPlacementColliders()
	{
		return null;
	}

	public ePlaceableType GetPlaceableType()
	{
		return default(ePlaceableType);
	}

	public Vector3 GetPlacementOffset()
	{
		return default(Vector3);
	}

	public void SwitchToPlacementMode(object data)
	{
	}

	protected virtual void SwitchToPlacementModeProc()
	{
	}

	public void OnPlacementProc()
	{
	}

	public void UpdateAfterMovedBySceneObjects()
	{
	}

	protected virtual void UpdateAfterMovedBySceneObjectsProc()
	{
	}

	public void SwitchToNextTargetPriority()
	{
	}

	public void SwitchToPreviousTargetPriority()
	{
	}

	public void OverrideUpgradeSpentCost(int newCost)
	{
	}

	public void OverrideDamageType(eDamageType newType)
	{
	}

	public void OnDamageTypeOverridden(eDamageType newType)
	{
	}

	public void OverrideTargetPriority(eTowerTargetPriority newPriority)
	{
	}

	protected void OnCreateBullet(AProjectile bullet)
	{
	}

	protected void BulletHitCallback(AMonsterBase monster, int shootIndex, int bulletIndex)
	{
	}

	public void RecordDamage(int damage)
	{
	}

	public void RecordKillCount()
	{
	}

	public void MonsterKillCallback(AMonsterBase monster)
	{
	}

	public void ToggleOverchargeAnim(bool isOn)
	{
	}

	public void PlayAnim_ApplyBuff()
	{
	}

	public TowerStats AddBuffMultiplier(eStatType statType, eModifierType modifierType, float value, float timeLimit = 0f, int id = -1)
	{
		return null;
	}

	protected virtual TowerStats AddBuffMultiplier_Prepass(TowerStats buffStat)
	{
		return null;
	}

	public void AddBuffMultiplier(TowerStats buffStat)
	{
	}

	public void RemoveBuffMultiplier(TowerStats buffStat)
	{
	}

	public void RemoveBuffMultiplier(int id)
	{
	}

	public void RemoveBuffMultiplier(eStatType type, int id)
	{
	}

	public bool IsHaveBuffMultiplierWithID(eStatType type, int id)
	{
		return false;
	}

	protected virtual void OnApplyBuffProc(TowerStats buffStat)
	{
	}

	protected virtual void OnRemoveBuffProc()
	{
	}

	protected virtual void OnBuffCardApplyProc(eItemType itemType)
	{
	}

	protected virtual void OnBuffCardExpiredProc(eItemType itemType)
	{
	}

	private void OnBuffCardApply(eItemType itemType)
	{
	}

	private void OnBuffCardExpired(eItemType itemType)
	{
	}

	public void OnPowerGridApply(APowerGrid powerGrid)
	{
	}

	public void OnPowerGridRemove(APowerGrid powerGrid)
	{
	}

	public void ToggleCollider(bool isOn)
	{
	}

	public virtual bool CanSellTower()
	{
		return false;
	}

	public int SellTower()
	{
		return 0;
	}

	protected virtual void OnSellTowerProc()
	{
	}

	public virtual string GetExtraTowerControlStat()
	{
		return null;
	}

	public virtual string GetExtraTowerControlRecord()
	{
		return null;
	}

	private void OnMouseDown()
	{
	}

	public void OpenTowerControlForThisTower()
	{
	}

	private void OnMouseEnter()
	{
	}

	protected virtual void OnMouseEnterProc()
	{
	}

	private void OnMouseExit()
	{
	}

	private void OnMouseOver()
	{
	}

	protected virtual void OnMouseOverProc()
	{
	}

	public List<Vector3Int> GetBasePositions()
	{
		return null;
	}

	protected virtual void OnMouseExitProc()
	{
	}

	public List<Vector3Int> GetElectricConnectPositions()
	{
		return null;
	}

	public void ForceDisable()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayClickDown()
	{
	}

	public void OnRayClickHold()
	{
	}

	public void OnRayClickUp()
	{
	}
}
