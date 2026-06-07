using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Pathfinding;
using UnityEngine;

[SelectionBase]
public abstract class AMonsterBase : MonoBehaviour, IHaveHP, IInteractable
{
	[Serializable]
	public class MonsterSpeedModifier
	{
		public bool isFromPlayer;

		public float value;

		public float duration;

		public int id;

		public MonsterSpeedModifier(float value, float duration, bool isFromPlayer, int id = -1)
		{
		}
	}

	public enum eState
	{
		NONE = 0,
		ALIVE = 1,
		KILLED = 2,
		DESPAWNED = 3,
		REMOVED = 4,
		IDLE = 5
	}

	private class AnimationSpeedModifier
	{
		public float value;

		public float duration;

		public int id;

		public AnimationSpeedModifier(float value, float duration, int id)
		{
		}
	}

	private class AdditionalMaterialSwapData
	{
		public Material material;

		public float duration;

		public string materialName;

		public AdditionalMaterialSwapData(Material mat, float duration, string materialName)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_DeathDissolveEffect_003Ed__137 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public float duration;

		public AMonsterBase _003C_003E4__this;

		private float _003Ctime_003E5__2;

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
		public _003CCR_DeathDissolveEffect_003Ed__137(int _003C_003E1__state)
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
	private sealed class _003CCR_HitFlashEffect_003Ed__139 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private float _003CmaxFlashValue_003E5__4;

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
		public _003CCR_HitFlashEffect_003Ed__139(int _003C_003E1__state)
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
	private sealed class _003CCR_Knockback_003Ed__172 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 force;

		public float duration;

		public AMonsterBase _003C_003E4__this;

		private float _003Ct_003E5__2;

		private float _003Ctime_003E5__3;

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
		public _003CCR_Knockback_003Ed__172(int _003C_003E1__state)
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
	private sealed class _003CCR_WaitRecalculatePath_003Ed__116 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase _003C_003E4__this;

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
		public _003CCR_WaitRecalculatePath_003Ed__116(int _003C_003E1__state)
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
	private struct _003CDespawnAsync_003Ed__128 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public AMonsterBase _003C_003E4__this;

		private UniTask.Awaiter _003C_003Eu__1;

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
	[Header("怪物資料")]
	protected MonsterSettingData monsterData;

	[SerializeField]
	[Header("Animator")]
	protected Animator animator;

	[Header("Collider")]
	[SerializeField]
	protected Collider collider;

	[SerializeField]
	[Header("死亡特效")]
	protected ParticleSystem particle_OnKill;

	[SerializeField]
	[Header("Renderers")]
	protected List<Renderer> list_Renderers;

	[SerializeField]
	[Header("骨架點")]
	protected List<Transform> list_VFXBoneNodes;

	[SerializeField]
	[Header("模型Node")]
	protected GameObject node_Model;

	[SerializeField]
	[Header("一般材質")]
	protected Material material_Normal;

	[SerializeField]
	[Header("腐化材質")]
	protected Material material_Corrupted;

	[Header("隨機位移")]
	[SerializeField]
	protected bool doRandomModelOffset;

	[SerializeField]
	[Header("模型位移範圍")]
	protected float randomModelOffsetRange;

	[SerializeField]
	[Header("AI Seeker")]
	protected Seeker seeker;

	[SerializeField]
	protected AIPath aiPath;

	[Header("怪物頭部位置")]
	[SerializeField]
	protected Vector3 headPosition;

	[SerializeField]
	[Header("死亡動畫的時間")]
	protected float deadAnimationLength;

	[Header("死掉後回收Prefab的延遲時間")]
	[SerializeField]
	protected float despawnDelay;

	[SerializeField]
	private string sfxKey_OnDeath;

	[SerializeField]
	protected eState state;

	[SerializeField]
	protected int hp;

	[SerializeField]
	protected int maxHP;

	[SerializeField]
	private int extraHP;

	[SerializeField]
	protected float speed;

	[SerializeField]
	protected float timeSinceSpawn;

	[SerializeField]
	protected bool isCorrupted;

	[SerializeField]
	protected bool doDropChestOnDeath;

	[SerializeField]
	protected bool isImpendingDeath;

	[SerializeField]
	private float impendingDeathTimer;

	[SerializeField]
	protected bool isUsingSkill;

	[SerializeField]
	private int flag_DisableCastSkill;

	[SerializeField]
	private bool canMove;

	[SerializeField]
	[Header("屬於哪個MonsterSpawner")]
	public MonsterSpawner monsterSpawner;

	[SerializeField]
	[Header("速度增減buff")]
	protected List<MonsterSpeedModifier> list_SpeedModifier;

	[SerializeField]
	[Header("傷害類的debuff")]
	protected List<MonsterDamageDebuff> list_MonsterDamageDebuff;

	[Header("增傷效果")]
	[SerializeField]
	protected List<DamageMultiplier> list_DamageMultiplier;

	[SerializeField]
	[Header("受爆擊機率增加效果")]
	protected List<CritMultiplier> list_CritMultiplier;

	[Header("冰冷效果")]
	[SerializeField]
	protected List<ChillEffect> list_ChillEffect;

	protected float freezeCooldown;

	[SerializeField]
	[Header("毒屬性效果")]
	protected List<PoisonEffect> list_PoisonEffect;

	[SerializeField]
	[Header("毒屬性加速效果")]
	protected List<PoisonTickSpeedMultiplier> list_PoisonTickSpeedMultiplier;

	[Header("燃燒效果")]
	[SerializeField]
	protected List<BurnEffect> list_BurnEffect;

	[Header("電擊效果")]
	[SerializeField]
	protected int electricEffect;

	protected int electricEffectMax;

	[Header("脆弱效果")]
	[SerializeField]
	protected List<FragileEffect> list_FragileEffect;

	[Header("暫停尋路效果")]
	[SerializeField]
	protected List<AIMovePauser> list_AIMovePauser;

	private bool isCalculatingPath;

	protected bool canBeTargeted;

	protected bool doNotPlayHitAnim;

	private Vector3 lastUnstuckDetectPosition;

	private float unstuckDetectTimer;

	private MaterialPropertyBlock matPropBlock;

	private Coroutine cr_HitFlashEffect;

	private bool isFreezeEffectOn;

	private bool isBurnEffectOn;

	private bool isTeleporting;

	protected bool isOverrideReward;

	protected int overrideReward;

	protected float timeSinceLastHit;

	protected bool doInterruptSkill;

	private int monsterID;

	protected float resistanceLevel;

	public Action<AMonsterBase> OnMonsterKilled;

	public Action<AMonsterBase> OnMonsterDespawn;

	public Action OnMonsterDamageDebuffChange;

	public Action OnMonsterHPChange;

	public Action<AMonsterBase, int, eDamageType, bool, ABaseTower> OnMonsterDamaged;

	public Action OnMonsterMouseEnter;

	public Action OnMonsterMouseExit;

	private List<AnimationSpeedModifier> list_AnimationSpeedModifier;

	private float movementAnimationSpeed;

	private int lastUpdateChillEffectStack;

	private float lastForceMoveTime;

	private float electricEffectTriggerCooldown;

	private float stunTimer;

	private float stunResistance;

	private float continuousStunTimer;

	private float immuneStunTimer;

	protected const float burnTickInterval = 1f;

	protected float burnTickTimer;

	protected const float poisonTickInterval = 0.75f;

	protected float poisonTickTimer;

	private int defaultMaxChillStack;

	private float baseChillDuration_Min;

	private float baseChillDuration_Max;

	private List<AdditionalMaterialSwapData> list_AdditionalMaterials;

	protected bool isAIPathPaused;

	private bool isOutlineOn;

	private OutlineController.eOutlineType currentOutlineType;

	public MonsterSettingData MonsterData => null;

	public Animator Animator => null;

	public GameObject Node_Model => null;

	public AIPath AIPath => null;

	public Vector3 HeadWorldPosition => default(Vector3);

	public eState State => default(eState);

	public int ExtraHP => 0;

	public float TimeSinceSpawn => 0f;

	public bool IsCorrupted => false;

	public bool IsImpendingDeath => false;

	public int ElectricEffect => 0;

	public int ElectricEffectMax => 0;

	public float Progress => 0f;

	public float RemainingDistance => 0f;

	public bool IsTeleporting => false;

	public float TimeSinceLastHit => 0f;

	public int MonsterID => 0;

	public float ResistanceLevel => 0f;

	protected virtual void Awake()
	{
	}

	private void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	protected virtual void Update()
	{
	}

	public virtual void Spawn(MonsterSpawner spawner, bool isCorrupted)
	{
	}

	public virtual void Spawn(MonsterSpawner spawner, bool isCorrupted, bool startWithIdle = false)
	{
	}

	public void StartMovingFromIdle()
	{
	}

	private void OnFloodPathUpdated(int spawnIndex)
	{
	}

	public void RecalculatePath()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WaitRecalculatePath_003Ed__116))]
	private IEnumerator CR_WaitRecalculatePath()
	{
		return null;
	}

	private void OnPathReady(Path path)
	{
	}

	public void ToggleMoveable(bool canMove)
	{
	}

	public void ToggleTargetable(bool canBeTargeted)
	{
	}

	private void UpdateAiPathMoveable()
	{
	}

	public void ResetUnstuckDetect()
	{
	}

	private void Unstuck()
	{
	}

	protected virtual void ReachEndOfPathProc()
	{
	}

	public void ToggleCanCastSkill(bool canCast)
	{
	}

	public bool CanCastSkill()
	{
		return false;
	}

	public void InterruptSkill()
	{
	}

	public virtual void Despawn()
	{
	}

	[AsyncStateMachine(typeof(_003CDespawnAsync_003Ed__128))]
	private UniTaskVoid DespawnAsync()
	{
		return default(UniTaskVoid);
	}

	public void PreregisterAttack(int damage)
	{
	}

	public virtual void Hit(int damage, float baseCritChance, eDamageType damageType, ABaseTower tower, bool hideDamageNumber = false, bool doTriggerHitReaction = true)
	{
	}

	public virtual void Hit(int damage, eDamageType damageType, Action<AMonsterBase> OnKillCallback = null, ABaseTower fromTower = null, bool hideDamageNumber = false, bool doTriggerHitReaction = true, float baseCritChance = 0f)
	{
	}

	public void RollApplyBurnEffect(ABaseTower fromTower)
	{
	}

	private static void RecordDamage(eDamageType damageType, ABaseTower fromTower, int effectiveDamage)
	{
	}

	public void SetDropTreasure(bool doDrop)
	{
	}

	public virtual float GetRemainingDistance()
	{
		return 0f;
	}

	public void TriggerDeathDissolveEffect(float delay, float duration = 0.5f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DeathDissolveEffect_003Ed__137))]
	protected IEnumerator CR_DeathDissolveEffect(float delay, float duration = 0.5f)
	{
		return null;
	}

	private void TriggerHitFlashEffect()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_HitFlashEffect_003Ed__139))]
	private IEnumerator CR_HitFlashEffect()
	{
		return null;
	}

	public void ApplyAnimationSpeedModifier(float value, float duration, int id = -1)
	{
	}

	public void RemoveAnimationSpeedModifier(int id)
	{
	}

	private void ResetAnimationSpeedModifiers()
	{
	}

	private void UpdateAnimatorSpeed()
	{
	}

	protected void UpdateAIPathSpeed()
	{
	}

	public void ApplySpeedModifier(float modifier, float time, bool isFromPlayer, int id = -1)
	{
	}

	public void RemoveSpeedModifier(int id)
	{
	}

	public float GetSpeedModifier()
	{
		return 0f;
	}

	public void ApplyDamageDebuff(float duration, float tickInterval, int damagePerTick, eDamageType damageType, int sourceID, ABaseTower fromTower = null)
	{
	}

	private void UpdateElementEffectVFX()
	{
	}

	public bool IsState(eState targetState)
	{
		return false;
	}

	public int GetHP()
	{
		return 0;
	}

	public int GetMaxHP(bool withDifficulty)
	{
		return 0;
	}

	public void OverrideMaxHP(int value)
	{
	}

	public void OverrideReward(int value)
	{
	}

	public int GetReward()
	{
		return 0;
	}

	public void AddExtraHP(int value)
	{
	}

	public float GetHPPercentage()
	{
		return 0f;
	}

	public void Heal(int value)
	{
	}

	public void HealToMaxHP()
	{
	}

	public void SwitchCorruptedMaterial(bool isCorrupted)
	{
	}

	public bool IsAlive()
	{
		return false;
	}

	public bool IsDead()
	{
		return false;
	}

	public bool IsHurt()
	{
		return false;
	}

	public bool IsDamageKillsMonster(int damage)
	{
		return false;
	}

	public bool IsAttackable()
	{
		return false;
	}

	public bool IsInRange(Vector3 center, float range)
	{
		return false;
	}

	public void Knockback(Vector3 force, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Knockback_003Ed__172))]
	private IEnumerator CR_Knockback(Vector3 force, float duration)
	{
		return null;
	}

	private void Move(Vector3 offset)
	{
	}

	public float GetElectricPercentage()
	{
		return 0f;
	}

	public int GetMaxElectricEffect()
	{
		return 0;
	}

	public void IncreaseElectricEffectByPercentage(float percentage)
	{
	}

	public void IncreaseElectricEffect(int value)
	{
	}

	public void RemoveElectricEffect()
	{
	}

	public void ApplyFragileEffect(float value, ABaseTower fromTower = null)
	{
	}

	public void RemoveFragileEffect()
	{
	}

	private void UpdateFragileEffect(float deltaTime)
	{
	}

	public bool IsHaveAnyFragileEffect()
	{
		return false;
	}

	public float GetFragileEffectValue()
	{
		return 0f;
	}

	public void Stun(float time, bool isFromPlayer)
	{
	}

	public bool IsStunned()
	{
		return false;
	}

	public void IncreaseResistanceLevel(float value)
	{
	}

	public bool IsBurning()
	{
		return false;
	}

	public int GetBurnTickDamage()
	{
		return 0;
	}

	public float GetMaxBurnDuration()
	{
		return 0f;
	}

	public int GetMaxBurnDamage()
	{
		return 0;
	}

	public float GetMaxBurnDamagePercentage()
	{
		return 0f;
	}

	public void ApplyBurnEffect(float duration, ABaseTower fromTower = null)
	{
	}

	public void ExtendBurnEffect(float time)
	{
	}

	public void RemoveAllBurnEffect()
	{
	}

	private void UpdateBurnEffect(float deltaTime)
	{
	}

	public void ApplyPoison(int damage, ABaseTower fromTower = null)
	{
	}

	public void AddPoisonTickIntervalMultiplier(float multiplier, float duration, int id)
	{
	}

	public void RemovePoisonTickIntervalMultiplier(int id)
	{
	}

	private float GetPoisonTickInterval()
	{
		return 0f;
	}

	private void UpdatePoisonEffect()
	{
	}

	public bool IsHavePoisonFromTower(ABaseTower tower)
	{
		return false;
	}

	public bool IsPoisoned()
	{
		return false;
	}

	public bool IsFullPoisoned()
	{
		return false;
	}

	public void RemoveAllPoison()
	{
	}

	public int GetTotalRemainingPoisonDamage()
	{
		return 0;
	}

	public int GetPoisonStackCount()
	{
		return 0;
	}

	public int GetPoisonTotalDamage()
	{
		return 0;
	}

	public float GetPoisonDamagePercentageToMaxHP()
	{
		return 0f;
	}

	public float GetPoisonDamagePercentageToCurHP()
	{
		return 0f;
	}

	public void ApplyDamageMultiplier(float multiplier, float duration, int sourceID, bool doLimitElement = false, eDamageType element = eDamageType.NONE)
	{
	}

	private void UpdateDamageMultiplier(float deltaTime)
	{
	}

	public void RemoveDamageMultiplier(int id)
	{
	}

	public float GetDamageMultiplier(eDamageType element)
	{
		return 0f;
	}

	public bool IsHaveAnyShieldMultiplier()
	{
		return false;
	}

	public void ApplyCritMultiplier(float multiplier, float duration, int sourceID)
	{
	}

	private void UpdateCritMultiplier(float deltaTime)
	{
	}

	public void RemoveCritMultiplier(int id)
	{
	}

	public float GetCritMultiplier(eDamageType element)
	{
		return 0f;
	}

	public int GetMaxChillStack()
	{
		return 0;
	}

	public void ApplyChillEffect(float time, bool isFromPlayer, int id, int stack = 1)
	{
	}

	private void UpdateChillEffect(float deltaTime)
	{
	}

	public int GetChillEffectStack()
	{
		return 0;
	}

	public bool IsChilled()
	{
		return false;
	}

	public bool IsChillStackFull()
	{
		return false;
	}

	public void RemoveChillEffectStack(int stackCount)
	{
	}

	public int RemoveAllChillEffect()
	{
		return 0;
	}

	public void Freeze(float duration)
	{
	}

	public void AddAdditionalMaterial(Material mat, float duration, string materialName)
	{
	}

	private void UpdateAdditionalMaterials(float deltaTime)
	{
	}

	public void RemoveAdditionalMaterial(string materialName)
	{
	}

	public void ResetAdditionalMaterials()
	{
	}

	public void PausePathfinding(float time, int sourceID)
	{
	}

	public void RemovePathfindingPause(int id)
	{
	}

	public bool UpdatePathfindingPause(float deltaTime)
	{
		return false;
	}

	public void SetIsTeleporting(bool isTeleporting)
	{
	}

	public void OverrideMaterial(Material mat)
	{
	}

	public void SwitchMaterial(Material mat)
	{
	}

	public void SetMaterialPropertyBlock(MaterialPropertyBlock block)
	{
	}

	public List<Transform> GetAllVFXBoneNodes()
	{
		return null;
	}

	public Transform GetRandomVFXBoneNode()
	{
		return null;
	}

	protected virtual void OnMouseEnter()
	{
	}

	protected virtual void OnMouseEnterProc()
	{
	}

	protected virtual void OnMouseExit()
	{
	}

	protected virtual void OnMouseExitProc()
	{
	}

	protected void OnMouseDown()
	{
	}

	public void OverrideOutlineType(OutlineController.eOutlineType outlineType)
	{
	}

	private void ToggleOutline(bool isOn)
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayClickDown()
	{
	}

	protected abstract void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower);

	protected abstract IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true);

	protected abstract void SpawnProc();

	protected abstract void DespawnProc();

	protected abstract void UpdateProc(float deltaTime);

	protected virtual void StunProc(float duration, bool isFromPlayer)
	{
	}
}
