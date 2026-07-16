using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModuleNeedler : Module
{
	[Header("Needler Fields")]
	public GameObject bulletPrefab;

	private float cdTimeElapsed;

	[NonSerialized]
	public float chanceForDirectHit;

	private int currentBurstID;

	private Dictionary<int, int> burstHitCounts = new Dictionary<int, int>();

	public event Action OnBurstCountReached;

	public event Action<HealthChangeInfo> OnHit;

	private new void Update()
	{
		base.Update();
		if (!base.IsFullyBroken && !base.IsEMPattached)
		{
			cdTimeElapsed += Time.deltaTime;
			float normalizedTime = cdTimeElapsed * 0.67f;
			anim.Play("Charging", 0, normalizedTime);
			Fire();
		}
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
		StartCoroutine(CleanupOldBursts());
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public void Fire()
	{
		if (!LevelManager.Instance.IsPlaying || base.IsFullyBroken || ResourceManager.Instance.AvailableAmmo < GetUpgradedStatValueByStatType(StatTypes.consumption))
		{
			cdTimeElapsed = 0f;
		}
		else
		{
			if (cdTimeElapsed < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
			{
				return;
			}
			currentBurstID++;
			burstHitCounts[currentBurstID] = 0;
			cdTimeElapsed = 0f;
			float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.count);
			for (int i = 0; (float)i < upgradedStatValueByStatType; i++)
			{
				if (ProbUtils.CheckWithLuck(chanceForDirectHit) && EnemyManager.Instance.Enemies != null && EnemyManager.Instance.Enemies.Count > 0)
				{
					Unit unit = null;
					Unit[] validEnemyTargets = UnitHelper.GetValidEnemyTargets(this);
					if (validEnemyTargets.Length != 0)
					{
						unit = validEnemyTargets[UnityEngine.Random.Range(0, validEnemyTargets.Length)];
					}
					if (unit != null)
					{
						Vector2 vector = unit.transform.position - base.transform.position;
						float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
						SpawnProjectile(num - 90f, currentBurstID);
					}
				}
				else
				{
					float angle = UnityEngine.Random.Range(0f, 360f);
					SpawnProjectile(angle, currentBurstID);
				}
			}
			PlayModuleUniqueSound();
			ResourceManager.Instance.Ammo.TrySpend(GetUpgradedStatValueByStatType(StatTypes.consumption));
			DataTrackingManager.Instance.AddAmmoUsed((int)GetUpgradedStatValueByStatType(StatTypes.consumption));
		}
	}

	public IEnumerator EmergencyFire(int amountOfWavesFired)
	{
		float shotCount = GetUpgradedStatValueByStatType(StatTypes.count);
		currentBurstID++;
		burstHitCounts[currentBurstID] = 0;
		for (int i = 0; i < amountOfWavesFired; i++)
		{
			for (int j = 0; (float)j < shotCount; j++)
			{
				float angle = UnityEngine.Random.Range(0f, 360f);
				SpawnProjectile(angle, currentBurstID);
			}
			PlayModuleUniqueSound();
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void SpawnProjectile(float angle, int burstID)
	{
		Projectile component = UnityEngine.Object.Instantiate(bulletPrefab, base.transform.position, Quaternion.Euler(0f, 0f, angle)).GetComponent<Projectile>();
		component.sourceUnit = this;
		component.damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		component.hitsRemaining += (int)GetUpgradedStatValueByStatType(StatTypes.pierce);
		component.ProjectileHit += delegate(HealthChangeInfo info)
		{
			if (burstID >= 0 && info.Target.gameObject.GetComponent<Unit>().IsEnemy && burstHitCounts.TryGetValue(burstID, out var value))
			{
				burstHitCounts[burstID] = value + 1;
				if (value + 1 == 4)
				{
					Debug.Log($"Burst {burstID} reached 4 enemy hits!");
					this.OnBurstCountReached?.Invoke();
				}
			}
		};
		component.ProjectileHit += delegate
		{
			HealLowestHealthModule();
		};
		component.ProjectileHit += Hit;
		component.screenWarpCounter = Train.Instance.projectileScreenWarpCounter;
		component.speed = GetUpgradedStatValueByStatType(StatTypes.projectileSpeed);
		if (GetUpgradedStatValueByStatType(StatTypes.sunder) > 0f)
		{
			component.isSundering = true;
		}
	}

	public override bool CanInteract()
	{
		return false;
	}

	public void Hit(HealthChangeInfo info)
	{
		this.OnHit?.Invoke(info);
	}

	private void HealLowestHealthModule()
	{
		Health component = (from module in Train.Instance.Modules
			where (bool)module && (bool)module.HealthComponent
			orderby module.HealthComponent.HealthCurrent
			select module).FirstOrDefault().GetComponent<Health>();
		float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.leech);
		HealthChangeInfo info = new HealthChangeInfo(this, component, upgradedStatValueByStatType, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		component.ChangeHealthWithInfo(info);
	}

	private IEnumerator CleanupOldBursts()
	{
		while (true)
		{
			yield return new WaitForSeconds(5f);
			foreach (int item in burstHitCounts.Keys.Where((int k) => k < currentBurstID - 10).ToList())
			{
				burstHitCounts.Remove(item);
			}
		}
	}
}
