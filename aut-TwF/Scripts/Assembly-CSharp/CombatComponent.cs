using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent))]
public class CombatComponent : MonoBehaviour, ISavable
{
	public delegate void OnDamageTaken(GameObject cuaser, float damageTaken);

	public delegate void HealthChangedDelegate(float newValue, float oldValue);

	public delegate void DieDelegate(CombatComponent combatComponent);

	[SerializeField]
	private bool bCanBeDamaged = true;

	[SerializeField]
	[Tooltip("Posición a la que se dirigen los ataques recibidos")]
	private GameObject targetObject;

	[SerializeField]
	private float aimRotationSpeed = 640f;

	[SerializeField]
	private Transform aimTransform;

	[SerializeField]
	[Tooltip("Only yaw aiming")]
	private bool onlyYawAiming = true;

	private bool isAiming;

	private StatsComponent statsComponent;

	[Savable("savedHealth", true, false)]
	private float savedHealth;

	[Savable("savedArmor", true, false)]
	private float savedArmor;

	[Savable("savedShield", true, false)]
	private float savedShield;

	public virtual float Health => statsComponent.GetStat(EStats.Health);

	public virtual float MaxHealth => statsComponent.GetStat(EStats.HealthMax);

	public virtual float Armor => statsComponent.GetStat(EStats.Armor);

	public virtual float MaxArmor => statsComponent.GetStat(EStats.ArmorMax);

	public virtual float Shield => statsComponent.GetStat(EStats.Shield);

	public virtual float MaxShield => statsComponent.GetStat(EStats.ShieldMax);

	public virtual float Life => Health + Armor + Shield;

	public virtual float MaxLife => MaxHealth + MaxArmor + MaxShield;

	public bool IsAiming
	{
		get
		{
			return isAiming;
		}
		set
		{
			isAiming = value;
		}
	}

	public bool BCanBeDamaged
	{
		get
		{
			return bCanBeDamaged;
		}
		set
		{
			bCanBeDamaged = value;
		}
	}

	protected float AimRotationSpeed
	{
		get
		{
			return aimRotationSpeed;
		}
		set
		{
			aimRotationSpeed = value;
		}
	}

	protected Transform AimTransform => aimTransform;

	public GameObject TargetObject
	{
		get
		{
			if (!targetObject)
			{
				return base.gameObject;
			}
			return targetObject;
		}
	}

	public event OnDamageTaken onDamageTaken;

	public event HealthChangedDelegate onHealthChanged;

	public event DieDelegate onDie;

	protected virtual void Awake()
	{
		statsComponent = GetComponent<StatsComponent>();
	}

	protected virtual void Start()
	{
		statsComponent.onStatChanged += OnStatChanged;
	}

	public virtual void Aim(GameObject go)
	{
		if ((bool)AimTransform)
		{
			Aim(go.transform.position - AimTransform.position);
		}
	}

	public bool IsAlive()
	{
		return statsComponent.GetStat(EStats.Health) > 0f;
	}

	public virtual bool IsTargetable()
	{
		if (!FogOfWarController.instance.IsPositionVisible(base.transform.position))
		{
			return false;
		}
		return true;
	}

	public virtual void Aim(Vector3 direction)
	{
		if (!AimTransform)
		{
			Debug.LogWarning(base.name + " is calling \"Aim\" without an aim transform assigned");
			return;
		}
		if (!isAiming)
		{
			IsAiming = true;
		}
		Vector3 normalized = direction.normalized;
		if (onlyYawAiming)
		{
			normalized.y = 0f;
		}
		if (direction.sqrMagnitude != 0f)
		{
			AimTransform.rotation = Quaternion.RotateTowards(AimTransform.rotation, Quaternion.LookRotation(normalized), AimRotationSpeed * Time.deltaTime);
		}
	}

	public virtual FDamageReport DoDamage(GameObject causer, FDamageData damageData, bool reportDamage = false)
	{
		if (BCanBeDamaged && damageData.damage > 0f)
		{
			FDamageReport fDamageReport = new FDamageReport();
			float num = damageData.damage;
			float stat = statsComponent.GetStat(EStats.Shield);
			float stat2 = statsComponent.GetStat(EStats.Armor);
			float stat3 = statsComponent.GetStat(EStats.Health);
			if (stat > 0f && num > 0f)
			{
				float stat4 = statsComponent.GetStat(EStats.Shield);
				statsComponent.SetStat(EStats.Shield, MathF.Max(0f, stat - num * GetDamageMultiplier(damageData.shieldMultiplier)));
				fDamageReport.ShieldDamage = stat4 - statsComponent.GetStat(EStats.Shield);
				num -= (stat - statsComponent.GetStat(EStats.Shield)) / GetDamageMultiplier(damageData.shieldMultiplier);
			}
			if (stat2 > 0f && num > 0f)
			{
				float stat4 = statsComponent.GetStat(EStats.Armor);
				statsComponent.SetStat(EStats.Armor, MathF.Max(0f, stat2 - num * GetDamageMultiplier(damageData.armorMultiplier)));
				fDamageReport.ArmorDamage = stat4 - statsComponent.GetStat(EStats.Armor);
				num -= (stat2 - statsComponent.GetStat(EStats.Armor)) / GetDamageMultiplier(damageData.armorMultiplier);
			}
			if (stat3 > 0f && num > 0f)
			{
				float stat4 = statsComponent.GetStat(EStats.Health);
				statsComponent.SetStat(EStats.Health, MathF.Max(0f, stat3 - num * GetDamageMultiplier(damageData.healthMultiplier)));
				fDamageReport.HealthDamage = stat4 - statsComponent.GetStat(EStats.Health);
			}
			this.onDamageTaken?.Invoke(causer, damageData.damage);
			if (reportDamage)
			{
				LTFunctionLibrary.GetGameStatsManager().ReportDamage(fDamageReport, null);
			}
			return fDamageReport;
		}
		return null;
	}

	public float GetDamageMultiplier(EDamageMultiplier damageMultiplier)
	{
		return damageMultiplier switch
		{
			EDamageMultiplier.Low => 0.5f, 
			EDamageMultiplier.Normal => 1f, 
			EDamageMultiplier.High => 2f, 
			_ => 1f, 
		};
	}

	public void Kill()
	{
		statsComponent.SetStat(EStats.Shield, 0f);
		statsComponent.SetStat(EStats.Armor, 0f);
		statsComponent.SetStat(EStats.Health, 0f);
	}

	protected virtual void Die()
	{
		this.onDie?.Invoke(this);
	}

	private void LoadLife()
	{
		statsComponent.SetStat(EStats.Health, savedHealth);
		statsComponent.SetStat(EStats.Armor, savedArmor);
		statsComponent.SetStat(EStats.Shield, savedShield);
		OnStatChanged(EStats.Health, statsComponent.GetStat(EStats.Health), 0f);
		OnStatChanged(EStats.Armor, statsComponent.GetStat(EStats.Armor), 0f);
		OnStatChanged(EStats.Shield, statsComponent.GetStat(EStats.Shield), 0f);
	}

	protected void InvokeOnDamageTaken(GameObject causer, float damageTaken)
	{
		this.onDamageTaken?.Invoke(causer, damageTaken);
	}

	protected void InvokeOnHealthChanged(float newValue, float oldValue)
	{
		this.onHealthChanged?.Invoke(newValue, oldValue);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Health)
		{
			this.onHealthChanged?.Invoke(newValue, oldValue);
			if (newValue <= 0f)
			{
				Die();
			}
		}
	}

	public void OnSave()
	{
		savedHealth = Health;
		savedArmor = Armor;
		savedShield = Shield;
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
			{
				LoadLife();
				return;
			}
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(LoadLife));
		}
	}
}
