using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModuleScrapinator : Module
{
	private List<EnemyBase> targetableEnemies;

	[SerializeField]
	private GameObject scrapProjectilePrefab;

	[NonSerialized]
	public bool targetPriority;

	[NonSerialized]
	public int scrapCount;

	public Delegates.HealthChangeHandler OnKill;

	public override bool CanBeActivated => true;

	private new void Awake()
	{
		base.Awake();
	}

	private new void Start()
	{
		base.Start();
	}

	private new void Update()
	{
		base.Update();
		if (!base.IsFullyBroken && !base.IsEMPattached && LevelManager.Instance.IsPlaying)
		{
			base.cooldownTimeElapsed += Time.deltaTime;
			_ = base.cooldownTimeElapsed;
			GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		if (ResourceManager.Instance.Scrap.Value <= 0f)
		{
			return false;
		}
		if (base.cooldownTimeElapsed < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
		{
			return false;
		}
		if (targetPriority)
		{
			targetableEnemies = (from e in EnemyManager.Instance.Enemies
				where e.IsEnemy && e.GetComponent<APCMissile>() == null
				orderby e.HealthComponent.HealthCurrent descending
				select e).Take((int)GetUpgradedStatValueByStatType(StatTypes.count)).ToList();
		}
		else
		{
			targetableEnemies = (from _ in EnemyManager.Instance.Enemies
				where _.IsEnemy && _.GetComponent<APCMissile>() == null
				orderby UnityEngine.Random.value
				select _).Take((int)GetUpgradedStatValueByStatType(StatTypes.count)).ToList();
		}
		if (targetableEnemies.Count == 0)
		{
			return false;
		}
		return base.CanInteract();
	}

	public override void Activate()
	{
		LaunchScrap();
		base.cooldownTimeElapsed = 0f;
		targetableEnemies = null;
		base.Activate();
	}

	private void LaunchScrap()
	{
		StartCoroutine(LaunchScrapRoutine());
	}

	private IEnumerator LaunchScrapRoutine()
	{
		int scrapPerTarget = (int)GetUpgradedStatValueByStatType(StatTypes.consumption) / targetableEnemies.Count;
		int remainingScrap = (int)GetUpgradedStatValueByStatType(StatTypes.consumption) % targetableEnemies.Count;
		List<EnemyBase> enemies = targetableEnemies;
		int enemyCount = targetableEnemies.Count;
		for (int i = 0; i < enemyCount; i++)
		{
			if (ResourceManager.Instance.Scrap.Value <= 0f)
			{
				break;
			}
			if (enemies[i] == null)
			{
				i++;
			}
			int num = scrapPerTarget;
			if (i < remainingScrap)
			{
				num++;
			}
			scrapCount = num;
			ProjectileScrapShot component = UnityEngine.Object.Instantiate(scrapProjectilePrefab, base.transform.position, Quaternion.identity).GetComponent<ProjectileScrapShot>();
			component.damage = GetUpgradedStatValueByStatType(StatTypes.damage) * (float)num;
			component.sourceUnit = this;
			component.speed = GetUpgradedStatValueByStatType(StatTypes.projectileSpeed);
			component.target = enemies[i];
			component.ProjectileHit += OnKillHandler;
			ResourceManager.Instance.Scrap.TrySpend(num);
			DataTrackingManager.Instance.AddScrapUsedAsAmmo(num);
			yield return new WaitForSeconds(GetUpgradedStatValueByStatType(StatTypes.cooldownSecondary));
		}
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
	}

	private void OnKillHandler(HealthChangeInfo info)
	{
		if (info.IsLethal)
		{
			OnKill?.Invoke(info);
		}
	}

	public override void RefundConsumption()
	{
		base.RefundConsumption();
		ResourceManager.Instance.Ammo.AddValue(GetUpgradedStatValueByStatType(StatTypes.consumption));
	}
}
