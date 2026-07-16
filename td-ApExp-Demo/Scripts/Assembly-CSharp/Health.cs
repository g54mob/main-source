using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[NonSerialized]
	public float ricochetChance;

	private bool isSundered;

	[NonSerialized]
	public bool isEMPd;

	private float sunderTimer;

	private float sunderDuration = 6f;

	private bool isWeakened;

	private float weakenTimer;

	private float weakenDuration = 6f;

	private bool isArmored;

	private float burnTimer;

	private const float TIME_BETWEEN_BURN = 1f;

	[SerializeField]
	private float healthCurrent;

	public float DamageReductionPercent;

	public float DamageReductionFlat;

	private float healthPreviously;

	[SerializeField]
	private ParticleSystem burnPS;

	private ParticleSystem repairPs;

	private float originalTimeBetweenShots;

	private bool isStateMachineAttack;

	[NonSerialized]
	public bool isBurning;

	public bool isShield;

	[NonSerialized]
	public object burnSource;

	private float immunityDuration;

	private bool checkImmunity;

	[field: NonSerialized]
	public float burnStack { get; private set; }

	[field: SerializeField]
	public float HealthMax { get; private set; }

	public float HealthCurrent
	{
		get
		{
			return healthCurrent;
		}
		private set
		{
			healthPreviously = healthCurrent;
			healthCurrent = Mathf.Clamp(value, 0f, HealthMax);
		}
	}

	public float HealthMissing => HealthMax - HealthCurrent;

	[field: SerializeField]
	public bool IsImmune { get; set; }

	public bool IsDead { get; set; }

	[field: NonSerialized]
	public EnemyBase EnemyBase { get; private set; }

	public event Delegates.HealthChangeRefHandler PreHealthChange;

	public event Delegates.HealthChangeRefHandler PreLethalDamage;

	public event Delegates.HealthChangeHandler OnHealthChanged;

	public event Action OnMaxHealthChanged;

	public event Delegates.HealthChangeHandler PreDeath;

	public event Delegates.HealthChangeHandler OnDeath;

	public event Delegates.HealthChangeHandler OnRes;

	public event Delegates.HealthChangeHandler OnFullFix;

	public event Action<float> OnDamageReduced;

	public event Action<float> OnDamageAvoided;

	public event Action<bool> OnBurnEvent;

	private void Awake()
	{
		EnemyBase = base.gameObject.GetComponent<EnemyBase>();
		if (HealthCurrent == 0f && (bool)EnemyBase)
		{
			HealthMax *= 1f + DifficultyManager.Instance.enemyHealthMultiplier;
			HealthCurrent = HealthMax;
		}
		else if (HealthCurrent == 0f)
		{
			HealthCurrent = HealthMax;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(GameManager.Instance.repairPsPrefab, base.transform.position, Quaternion.identity, base.transform);
		repairPs = gameObject.GetComponent<ParticleSystem>();
		if (EnemyBase != null)
		{
			originalTimeBetweenShots = EnemyBase.timeBetweenShots;
			if (EnemyBase.Name == "Bus")
			{
				isStateMachineAttack = true;
				EnemyBase = base.gameObject.GetComponent<E1_4Bus>();
				originalTimeBetweenShots = EnemyBase.IdleTime;
			}
			else if (EnemyBase.Name == "APC")
			{
				isStateMachineAttack = true;
				EnemyBase = base.gameObject.GetComponent<E1_5APC>();
				originalTimeBetweenShots = EnemyBase.IdleTime;
			}
		}
		else
		{
			originalTimeBetweenShots = 0f;
		}
	}

	private void Update()
	{
		Burn();
		if ((bool)burnPS)
		{
			burnPS.transform.rotation = Quaternion.identity;
		}
		sunderTimer -= Time.deltaTime;
		if (isSundered && (sunderTimer <= 0f || (EnemyBase != null && EnemyBase.IsHacked)))
		{
			RemoveSunder();
		}
		weakenTimer -= Time.deltaTime;
		if (isWeakened && (weakenTimer <= 0f || (EnemyBase != null && EnemyBase.IsHacked)))
		{
			RemoveWeaken();
		}
		if (!checkImmunity)
		{
			return;
		}
		if (immunityDuration > 0f)
		{
			immunityDuration -= Time.deltaTime;
		}
		else if (immunityDuration <= 0f)
		{
			IsImmune = false;
			checkImmunity = false;
			if (base.gameObject.GetComponent<Train>() != null)
			{
				Train.Instance.SetAllModulesImmunity(isImmune: false);
			}
		}
	}

	public void ApplyArmor()
	{
		if ((bool)EnemyBase)
		{
			isArmored = true;
			EnemyBase.GetComponent<Outline>()?.SetOutline(isActive: true, Color.grey);
			UIManager.Instance.EnemyHealthbarsDisplay.ApplyArmor(EnemyBase, apply: true);
		}
	}

	public void RemoveArmor()
	{
		if ((bool)EnemyBase)
		{
			isArmored = false;
			EnemyBase.GetComponent<Outline>()?.SetOutline(isActive: false, Color.gray);
			UIManager.Instance.EnemyHealthbarsDisplay.ApplyArmor(EnemyBase, apply: false);
		}
	}

	public void ApplySunder()
	{
		if (isArmored)
		{
			RemoveArmor();
		}
		else if (!isSundered)
		{
			isSundered = true;
			sunderTimer = sunderDuration;
			UIManager.Instance.EnemyHealthbarsDisplay.ApplySunder(EnemyBase, apply: true);
		}
		else
		{
			isSundered = true;
			sunderTimer = sunderDuration;
		}
	}

	public void RemoveSunder()
	{
		isSundered = false;
		sunderTimer = -1f;
		UIManager.Instance.EnemyHealthbarsDisplay.ApplySunder(EnemyBase, apply: false);
	}

	public void ApplyWeaken(float duration = 0f)
	{
		if (duration == 0f)
		{
			duration = weakenDuration;
		}
		if (!isWeakened)
		{
			isWeakened = true;
			weakenTimer = duration;
			UIManager.Instance.EnemyHealthbarsDisplay.ApplyWeaken(EnemyBase, apply: true);
			EnemyBase.Weaken(weakened: true);
		}
		else
		{
			isWeakened = true;
			weakenTimer = duration;
		}
	}

	public void RemoveWeaken()
	{
		EnemyBase.Weaken(weakened: false);
		isWeakened = false;
		weakenTimer = -1f;
		UIManager.Instance.EnemyHealthbarsDisplay.ApplyWeaken(EnemyBase, apply: false);
	}

	public void ApplyBurn(float amount, object appliedBy)
	{
		if (IsImmune || IsDead)
		{
			return;
		}
		if (isArmored)
		{
			RemoveArmor();
			return;
		}
		burnSource = appliedBy;
		if (burnStack <= 0f && amount > 0f)
		{
			if ((bool)burnPS)
			{
				burnPS.Play(withChildren: true);
				this.OnBurnEvent?.Invoke(obj: true);
			}
			burnTimer = 1f;
			if (EnemyBase != null)
			{
				GlobalFields.Instance.AmountOfEnemiesOnFire++;
				Train.Instance.SpeedChange(GlobalFields.Instance.SpeedPerEnemyOnFire, isPercent: true);
			}
			isBurning = true;
		}
		burnStack += amount + ((amount > 0f) ? GlobalFields.Instance.PlayerBurnStackAdd : 0f);
		if (originalTimeBetweenShots != 0f)
		{
			if (!isStateMachineAttack)
			{
				EnemyBase.timeBetweenShots = originalTimeBetweenShots * (1f + GlobalFields.Instance.EnemyAttackSpeedSlowingDownWhenBurnPerStack * burnStack);
			}
			else
			{
				EnemyBase.IdleTime = originalTimeBetweenShots * (1f + GlobalFields.Instance.EnemyAttackSpeedSlowingDownWhenBurnPerStack * burnStack);
			}
		}
	}

	public void StopBurn()
	{
		burnStack = 0f;
		if ((bool)burnPS)
		{
			burnPS.Stop(withChildren: true);
			this.OnBurnEvent?.Invoke(obj: false);
		}
		if (EnemyBase != null)
		{
			GlobalFields.Instance.AmountOfEnemiesOnFire--;
			Train.Instance.SpeedChange(0f - GlobalFields.Instance.SpeedPerEnemyOnFire, isPercent: true);
		}
		isBurning = false;
	}

	private void Burn()
	{
		if ((IsImmune || IsDead) && isBurning)
		{
			StopBurn();
		}
		else if (burnStack <= 0f && isBurning)
		{
			StopBurn();
		}
		else
		{
			if (!(burnStack > 0f))
			{
				return;
			}
			burnTimer -= Time.deltaTime;
			if (!(burnTimer <= 0f))
			{
				return;
			}
			burnTimer = 1f;
			HealthChangeInfo info = new HealthChangeInfo(burnSource, this, -1f * burnStack, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: true, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.DoT);
			ChangeHealthWithInfo(info);
			if (!(UnityEngine.Random.Range(0f, 1f) <= GlobalFields.Instance.PlayerBurnStackLooseChance))
			{
				return;
			}
			burnStack--;
			if (originalTimeBetweenShots != 0f)
			{
				if (!isStateMachineAttack)
				{
					EnemyBase.timeBetweenShots = originalTimeBetweenShots * (1f + GlobalFields.Instance.EnemyAttackSpeedSlowingDownWhenBurnPerStack * burnStack);
				}
				else
				{
					EnemyBase.IdleTime = originalTimeBetweenShots * (1f + GlobalFields.Instance.EnemyAttackSpeedSlowingDownWhenBurnPerStack * burnStack);
				}
			}
		}
	}

	public void Fix(float amount, bool isPercent = false)
	{
		HealthChangeInfo healthChangeInfo = new HealthChangeInfo((PlayerRepairDamage)PlayerManager.Instance.Players[0].SM.states["RepairDamage"], this, amount, isPercent, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		Heal(healthChangeInfo.HealthChange, healthChangeInfo.source, isPercent);
	}

	public void Heal(float amount, object source = null, bool isPercent = false)
	{
		HealthChangeInfo info = new HealthChangeInfo(source, this, amount, isPercent, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		ChangeHealthWithInfo(info);
		CombatManager.Instance.OnDamageHealed(info);
	}

	public void ReduceHealthTo0(Unit source)
	{
		HealthChangeInfo info = new HealthChangeInfo(source, this, 0f - healthCurrent, isPercent: false, null, canRes: false, ignoreArmor: true, ignoreImmunity: false, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
		ChangeHealthWithInfo(info);
	}

	public void ChangeHealthWithInfo(HealthChangeInfo info)
	{
		if (HealthMax == 0f || info.Target == null || info.Target.gameObject == null)
		{
			return;
		}
		if (!IsImmune && isArmored && info.DamageType != DamageType.God)
		{
			RemoveArmor();
			return;
		}
		if (DamageReductionFlat > 0f || DamageReductionPercent > 0f)
		{
			info.IsDamageReduced = true;
		}
		if (IsImmune)
		{
			info.IsImmune = true;
		}
		this.PreHealthChange?.Invoke(ref info);
		if (IsDead && info.HealthChange > 0f && !info.CanRes)
		{
			return;
		}
		if (!info.IgnoreImmunity && IsImmune && info.HealthChange < 0f)
		{
			float f = info.HealthChange;
			if (info.IsPercent)
			{
				f = info.HealthChange / 100f * HealthMax;
			}
			this.OnDamageAvoided?.Invoke(Mathf.Abs(f));
			info.HealthChange = 0f;
			ApplyHealthChangeEffects(info);
			return;
		}
		if (info.HealthChange < 0f)
		{
			float value = UnityEngine.Random.value;
			ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
			if (value < (((object)moduleByType != null) ? new float?(moduleByType.HealingChance / 100f) : ((float?)null)) && (bool)GetComponent<Module>())
			{
				Heal(Train.Instance.GetModuleByType<ModuleHarden>().HealingAmount, Train.Instance.GetModuleByType<ModuleHarden>());
				return;
			}
		}
		float num = info.HealthChange;
		if (info.IsPercent)
		{
			num = info.HealthChange / 100f * HealthMax;
		}
		if (num < 0f)
		{
			EnemyBase component = info.Target.gameObject.GetComponent<EnemyBase>();
			if ((object)component != null && component.IsBoss)
			{
				num *= EnemyManager.Instance.BossDmgMult;
			}
			if (!info.IgnoreArmor)
			{
				float num2 = num;
				num -= num * DamageReductionPercent / 100f - DamageReductionFlat;
				float a = num2 - num;
				a = Mathf.Min(a, -0.5f);
				this.OnDamageReduced?.Invoke(Mathf.Abs(a));
			}
			num = ((DamageReductionPercent != 100f) ? Mathf.Min(num, -0.5f) : Mathf.Min(num, 0f));
			if (!info.IgnoreGrace && GetComponent<Module>() != null)
			{
				num = Mathf.Max(Train.Instance.ModuleTryTakeDamage(num));
			}
			Unit obj = info.source as Unit;
			if ((object)obj != null && !obj.IsEnemy && info.Target?.gameObject.name != "Train")
			{
				num *= (info.IsBurn ? GlobalFields.Instance.PlayerBurnDmgMult : 1f) * GlobalFields.Instance.AllPlayerDmgMult;
			}
			num *= (isSundered ? GlobalFields.Instance.SunderDmgMult : 1f);
			if (info.IsLethal)
			{
				this.PreLethalDamage?.Invoke(ref info);
			}
		}
		HealthCurrent += num;
		info.HealthChange = num;
		ApplyHealthChangeEffects(info);
	}

	public void SetHealthWithInfo(HealthChangeInfo info, bool hideHealParticles = false)
	{
		if (info.IsPercent)
		{
			float num = (info.IsPercent ? (info.HealthChange * HealthMax * 0.01f) : info.HealthChange);
			HealthCurrent += num;
		}
		else
		{
			HealthCurrent = info.HealthChange;
		}
		ApplyHealthChangeEffects(info, hideHealParticles);
	}

	private void ApplyHealthChangeEffects(HealthChangeInfo info, bool hideHealParticles = false)
	{
		if (HealthMax == 0f)
		{
			return;
		}
		CombatManager.Instance.OnHealthChanged(info);
		float healthChange = info.HealthChange;
		if ((bool)repairPs && healthChange >= 1f && !hideHealParticles)
		{
			ParticleSystem.MainModule main = repairPs.main;
			main.startColor = UIManager.Instance.GradientGYR.Evaluate(HealthCurrent / HealthMax);
			repairPs.Emit(Mathf.CeilToInt(healthChange));
		}
		this.OnHealthChanged?.Invoke(info);
		if (healthCurrent <= 0f && !IsDead)
		{
			OnPreDeath(info);
			if (HealthCurrent <= 0f)
			{
				Die(info);
			}
		}
		else if (healthCurrent > 0f && IsDead && info.CanRes)
		{
			Res(info);
		}
		else if (healthCurrent > 0f && !IsDead && info.HealthChange != 0f && healthCurrent == HealthMax)
		{
			this.OnFullFix?.Invoke(info);
		}
	}

	public void OnPreDeath(HealthChangeInfo info)
	{
		this.PreDeath?.Invoke(info);
	}

	public void ChangeMaxHealthBy(float maxHealthToAdd, bool healDeficit = true)
	{
		float num = HealthCurrent / HealthMax;
		HealthMax += maxHealthToAdd;
		if (healDeficit)
		{
			ChangeHealthWithInfo(new HealthChangeInfo(null, this, num * 100f, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
		this.OnMaxHealthChanged?.Invoke();
	}

	public void SetMaxHealth(float newMaxHealth, bool healDeficit = true)
	{
		float num = HealthCurrent / HealthMax;
		HealthMax = newMaxHealth;
		if (healDeficit)
		{
			healthCurrent = HealthMax * num;
		}
		this.OnMaxHealthChanged?.Invoke();
	}

	public void SetHealth(float amount, bool triggerEvent = true)
	{
		healthCurrent = amount;
		if (triggerEvent)
		{
			this.OnHealthChanged?.Invoke(new HealthChangeInfo(this, this, amount, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
	}

	public void RaiseMaxHealthByWithoutHeal(float amount)
	{
		HealthMax += amount;
		this.OnMaxHealthChanged?.Invoke();
	}

	public void RaiseMaxHealthByWithHeal(float amount, bool notifyHealthChanged = true)
	{
		HealthMax += amount;
		HealthCurrent += amount;
		if (notifyHealthChanged)
		{
			this.OnMaxHealthChanged?.Invoke();
		}
	}

	public void Die(HealthChangeInfo info)
	{
		if (EnemyBase != null && isBurning)
		{
			GlobalFields.Instance.AmountOfEnemiesOnFire--;
			Train.Instance.SpeedChange(0f - GlobalFields.Instance.SpeedPerEnemyOnFire, isPercent: true);
			isBurning = false;
		}
		IsDead = true;
		this.OnDeath?.Invoke(info);
	}

	public void Res(HealthChangeInfo info)
	{
		this.OnRes?.Invoke(info);
		IsDead = false;
	}

	public void ApplyImmunityBuff(float duration)
	{
		checkImmunity = true;
		IsImmune = true;
		immunityDuration = duration;
		StopBurn();
		if (base.gameObject.GetComponent<Train>() != null)
		{
			Train.Instance.SetAllModulesImmunity(isImmune: true);
		}
	}

	public void RemoveImmunityBuff()
	{
		checkImmunity = false;
		IsImmune = false;
		immunityDuration = 0f;
	}
}
