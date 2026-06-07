using System;
using System.Collections;
using UnityEngine;

public class AutoAttack_overTime : TowerAutoAttack
{
	[Serializable]
	private struct FDamageConfig
	{
		[SerializeField]
		[Tooltip("Después de cuanto tiempo atacando se empieza a usar este multiplicador")]
		public float startTime;

		[SerializeField]
		[Tooltip("Multiplicador del daño base")]
		public float damageMultiplier;
	}

	private const float CHECK_RANGE_TIME = 0.25f;

	[SerializeField]
	private FDamageConfig[] damageConfig;

	[SerializeField]
	[Tooltip("Tiempo que tarda en empezar a hacer daño")]
	private float warmUpTime;

	[SerializeField]
	[Tooltip("Cada cuanto tiempo se hace daño")]
	private float damageTickTime = 1f;

	[SerializeField]
	[Tooltip("Tiempo mínimo que se desactiva el cambio de target una vez empieza a atacar a uno. PE: Para evitar que se cambie de target si el objetivo se acaba de salir de rango al poco de empezar el casteo.")]
	private float minAttackTime;

	[SerializeField]
	[Tooltip("Si está activado, permite cambiar de target instantáneamente y sin perder la carga si el enemigo muere mienstras está siendo atacado")]
	private bool hotSwap;

	private bool isInHotSwap;

	private bool hasStartedDamage;

	private int currentDamageConfigIdx;

	private float damageTimer;

	private Transform shootTransform;

	private Tower tower;

	private CombatComponent target;

	private TowerCombatComponent towerCC;

	private Coroutine damageCoroutine;

	private Coroutine checkRangeCoroutine;

	private Coroutine minAttackTimeCoroutine;

	protected CombatComponent Target
	{
		get
		{
			return target;
		}
		private set
		{
			target = value;
		}
	}

	public Transform ShootTransform
	{
		get
		{
			return shootTransform;
		}
		set
		{
			shootTransform = value;
		}
	}

	protected override void Start()
	{
		base.Start();
		towerCC = abilityManager.CombatComponent as TowerCombatComponent;
		tower = abilityManager.Character as Tower;
		ShootTransform = towerCC.ShootTransform;
	}

	protected override void OnActivate(FActiveAbilityInputData inputData)
	{
		Target = inputData.target;
		tower.onTargetChanged += OnTargetChanged;
		Target.onDie += OnTargetDies;
		this.StartCoroutineCheckingVar(DamageCoroutine(), ref damageCoroutine);
		this.StartCoroutineCheckingVar(CheckRangeCoroutine(), ref checkRangeCoroutine);
	}

	private IEnumerator DamageCoroutine()
	{
		WaitForSeconds wfs = new WaitForSeconds(damageTickTime);
		if (!isInHotSwap)
		{
			currentDamageConfigIdx = 0;
			damageTimer = 0f;
			OnStartWarmup();
			yield return new WaitForSeconds(warmUpTime);
			isInHotSwap = false;
		}
		OnDamageIndexChanged(currentDamageConfigIdx);
		hasStartedDamage = true;
		this.StartCoroutineCheckingVar(MinAttackTimeCoroutine(), ref minAttackTimeCoroutine, stopCoroutineIfRunning: true);
		OnStartDamage();
		while ((bool)Target)
		{
			while (currentDamageConfigIdx < damageConfig.Length - 1 && damageTimer >= damageConfig[currentDamageConfigIdx + 1].startTime)
			{
				currentDamageConfigIdx++;
				OnDamageIndexChanged(currentDamageConfigIdx);
			}
			FDamageData damageData = new FDamageData(abilityManager.StatsComponent.GetStat(EStats.BaseDamage) * damageTickTime * damageConfig[currentDamageConfigIdx].damageMultiplier, towerCC.HealthMultiplier, towerCC.ArmorMultiplier, towerCC.ShieldMultiplier);
			(abilityManager.CombatComponent as TowerCombatComponent).DoDamageToEnemy(target.GetComponentInParent<Enemy>(), damageData, Target.TargetObject.transform.position, isMainDamage: true);
			yield return wfs;
			damageTimer += damageTickTime;
		}
	}

	private IEnumerator CheckRangeCoroutine()
	{
		WaitForSeconds wfs = new WaitForSeconds(0.25f);
		while (true)
		{
			if (!IsTargetInRange() && hasStartedDamage)
			{
				EndAbility();
			}
			yield return wfs;
		}
	}

	private IEnumerator MinAttackTimeCoroutine()
	{
		this.StopCoroutineCheckingVar(ref checkRangeCoroutine);
		tower.onTargetChanged -= OnTargetChanged;
		yield return new WaitForSeconds(minAttackTime);
		this.StartCoroutineCheckingVar(CheckRangeCoroutine(), ref checkRangeCoroutine);
		tower.onTargetChanged += OnTargetChanged;
		if (tower.Target == null || tower.Target.CombatComponent != Target)
		{
			EndAbility();
		}
		minAttackTimeCoroutine = null;
	}

	protected virtual void OnStartWarmup()
	{
	}

	protected virtual void OnStartDamage()
	{
	}

	protected virtual void OnDamageIndexChanged(int newIndex)
	{
	}

	protected override void OnEndAbility(bool canceled)
	{
		base.OnEndAbility(canceled);
		ApplyCooldown();
		this.StopCoroutineCheckingVar(ref minAttackTimeCoroutine);
		this.StopCoroutineCheckingVar(ref damageCoroutine);
		this.StopCoroutineCheckingVar(ref checkRangeCoroutine);
		hasStartedDamage = false;
		tower.onTargetChanged -= OnTargetChanged;
		if ((bool)Target)
		{
			Target.onDie -= OnTargetDies;
		}
	}

	private bool IsTargetInRange()
	{
		if (Target == null)
		{
			return false;
		}
		return FunctionLibrary.SqrDistanceBetweenObjects(abilityManager.gameObject, Target.gameObject) <= Mathf.Pow(abilityManager.StatsComponent.GetStat(EStats.Range), 2f);
	}

	private void OnTargetDies(CombatComponent combatComponent)
	{
		EndAbility();
		if (hotSwap)
		{
			StartCoroutine(HotSwapCoroutine());
		}
	}

	private IEnumerator HotSwapCoroutine()
	{
		isInHotSwap = true;
		yield return null;
		isInHotSwap = false;
	}

	private void OnTargetChanged(Enemy newEnemy, Enemy oldEnemy)
	{
		if (!hasStartedDamage)
		{
			if ((bool)Target)
			{
				Target.onDie -= OnTargetDies;
			}
			if ((bool)newEnemy)
			{
				Target = newEnemy.CombatComponent;
				Target.onDie += OnTargetDies;
			}
			else
			{
				Target = null;
			}
		}
		else
		{
			EndAbility();
		}
	}
}
