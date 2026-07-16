using System;
using UnityEngine;
using UnityEngine.Localization;

public class ModuleMissile : Module
{
	public delegate void MissileSpawnHandler(GameObject missile);

	[SerializeField]
	private GameObject missilePrefab;

	[SerializeField]
	private int missilesCurrent;

	[SerializeField]
	private float delayBetweenLaunches;

	[NonSerialized]
	[HideInInspector]
	public float onHitAmmoGain;

	[NonSerialized]
	[HideInInspector]
	public float onHitAmmoGainChance;

	private Transform missileSpawn;

	private bool firing;

	private float fireTimer;

	private float reloadTimer;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString launchActionLocalized;

	[SerializeField]
	public GameObject enhancedMissilePrefab;

	[NonSerialized]
	public bool upgradedMissiles;

	[NonSerialized]
	public float upgradedMissilesHp;

	public override bool CanBeActivated => true;

	public float MissilesTimeToWaitForTargets { get; set; }

	public bool MissilesCanWaitForTargets { get; set; }

	public event Action PreMissileSpawn;

	public event MissileSpawnHandler PostMissileSpawn;

	public event Delegates.HealthChangeHandler ExplosionKill;

	public event Action OnHit;

	private new void Awake()
	{
		base.Awake();
		missileSpawn = base.transform.Find("Mount").Find("Missile Launcher").Find("Missile Spawn");
	}

	private new void Update()
	{
		base.Update();
		if (firing)
		{
			Fire();
		}
		else
		{
			Reload();
		}
	}

	public override void ShowRoofElement()
	{
		base.ShowRoofElement();
	}

	public override void TransparentRoofElement()
	{
		base.TransparentRoofElement();
	}

	public override void HideRoofElement()
	{
		base.HideRoofElement();
	}

	protected override void SetEmpSoundChannels()
	{
	}

	private void Fire()
	{
		if (missilesCurrent <= 0 || base.IsFullyBroken || base.IsEMPattached)
		{
			firing = false;
			anim.Play("Load Missiles");
			return;
		}
		fireTimer -= Time.deltaTime;
		if (!(fireTimer > 0f))
		{
			missilesCurrent--;
			fireTimer = delayBetweenLaunches;
			if (upgradedMissiles)
			{
				SpawnEnhancedMissile();
			}
			else
			{
				SpawnMissile();
			}
		}
	}

	public void SpawnMissile()
	{
		this.PreMissileSpawn?.Invoke();
		Quaternion rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
		Missile component = UnityEngine.Object.Instantiate(missilePrefab, missileSpawn.position, rotation).GetComponent<Missile>();
		component.trackingSpeed = GetUpgradedStatValueByStatType(StatTypes.tracking);
		component.damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		component.radius = GetUpgradedStatValueByStatType(StatTypes.scale);
		component.speed = GetUpgradedStatValueByStatType(StatTypes.projectileSpeed) + UnityEngine.Random.Range(0f, 0.5f);
		component.sourceUnit = this;
		component.ProjectileHit += delegate
		{
			OnHitHealth();
		};
		component.ExplosionKill += OnExplosionKill;
		component.CanWaitForTarget = MissilesCanWaitForTargets;
		component.TimeToWaitForTarget = MissilesTimeToWaitForTargets;
		PlayModuleUniqueSound();
		this.PostMissileSpawn?.Invoke(component.gameObject);
	}

	public void SpawnEnhancedMissile()
	{
		this.PreMissileSpawn?.Invoke();
		Quaternion rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
		APCMissile component = UnityEngine.Object.Instantiate(enhancedMissilePrefab, missileSpawn.position, rotation).GetComponent<APCMissile>();
		component.muteCruiseSfx = true;
		component.IsEnemy = false;
		component.TargetUnit = null;
		component.parentEnemy = this;
		component.damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		component.HealthComponent.SetMaxHealth(upgradedMissilesHp);
		component.OnHit += delegate
		{
			OnHitHealth();
		};
		component.OnKill += OnExplosionKill;
		component.TimeToWaitForTarget = MissilesTimeToWaitForTargets;
		component.CanWaitForTarget = MissilesCanWaitForTargets;
		component.MoveSpeed = GetUpgradedStatValueByStatType(StatTypes.projectileSpeed) + UnityEngine.Random.Range(0f, 0.5f);
		PlayModuleUniqueSound();
		this.PostMissileSpawn?.Invoke(component.gameObject);
	}

	public void OnHitHealth()
	{
		if (ProbUtils.CheckWithLuck(onHitAmmoGainChance))
		{
			ResourceManager.Instance.Ammo.AddValue(onHitAmmoGain);
		}
		this.OnHit?.Invoke();
	}

	private void Reload()
	{
		if ((float)missilesCurrent >= GetUpgradedStatValueByStatType(StatTypes.capacity) || base.IsFullyBroken || base.IsEMPattached)
		{
			return;
		}
		reloadTimer += Time.deltaTime;
		if (!(reloadTimer < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary)))
		{
			float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.consumption);
			if (ResourceManager.Instance.Ammo.TrySpendAmmo(upgradedStatValueByStatType))
			{
				DataTrackingManager.Instance.AddAmmoUsed((int)upgradedStatValueByStatType);
				reloadTimer = 0f;
				missilesCurrent++;
				base.Interactable.actionNameLocalized = launchActionLocalized;
				launchActionLocalized.Arguments = new object[1] { missilesCurrent };
			}
		}
	}

	public void ForceReload()
	{
		if (!((float)missilesCurrent >= GetUpgradedStatValueByStatType(StatTypes.capacity)) && !base.IsFullyBroken && !base.IsEMPattached)
		{
			missilesCurrent++;
			base.Interactable.actionNameLocalized = launchActionLocalized;
			launchActionLocalized.Arguments = new object[1] { missilesCurrent };
		}
	}

	public override bool CanInteract()
	{
		if (base.CanInteract() && !firing)
		{
			return missilesCurrent > 0;
		}
		return false;
	}

	public override void Activate()
	{
		firing = true;
		anim.SetFloat("Launch Speed Mult", delayBetweenLaunches * GetUpgradedStatValueByStatType(StatTypes.capacity));
		anim.SetFloat("Load Speed Mult", 1f / GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) / GetUpgradedStatValueByStatType(StatTypes.capacity));
		anim.Play("Launch Missiles", 0, 1f - (float)missilesCurrent / GetUpgradedStatValueByStatType(StatTypes.capacity));
		base.Activate();
	}

	private void OnExplosionKill(HealthChangeInfo info)
	{
		this.ExplosionKill?.Invoke(info);
	}

	public override void RefundConsumption()
	{
		base.RefundConsumption();
		ResourceManager.Instance.Ammo.AddValue((float)missilesCurrent * GetUpgradedStatValueByStatType(StatTypes.consumption));
	}

	public override void RefundCooldown()
	{
	}
}
