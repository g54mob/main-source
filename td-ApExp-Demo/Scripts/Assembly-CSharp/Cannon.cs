using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	public static Cannon Instance;

	private bool isActive;

	[SerializeField]
	private GameObject bulletPrefab;

	[SerializeField]
	private GameObject deflectShotPrefab;

	[SerializeField]
	private GameObject laser;

	private Transform shotPoint;

	private Transform shotPointDoubleLeft;

	private Transform shotPointDoubleRight;

	private ModuleCannon moduleCannon;

	private float damageBoost;

	private Animator anim;

	public float reloadTimePerBullet = 0.5f;

	public GameObject explosionGo;

	public float explosionSize;

	public bool hasRedirectingProjectiles;

	public float redirectRange;

	private Vector2 aimVector;

	private float crosshairDst;

	private float nonZeroRotationTime;

	private float shotTimer;

	private float damage;

	[SerializeField]
	private Color colorOnTarget;

	[SerializeField]
	private Color colorOffTarget;

	private float ammoCount;

	private int consecutiveHits;

	public float consecutiveHitsDamageIncrease;

	[NonSerialized]
	public bool isGatling;

	public bool hasLaser;

	[SerializeField]
	private GameObject deflectPsPrefab;

	[SerializeField]
	private AnimationCurve soundPitchCurve;

	private bool debugInstantReload;

	private CrosshairCannon crosshair;

	[NonSerialized]
	public bool isCharging;

	[SerializeField]
	[Tooltip("This time is affected by primary cooldown so /2 on start")]
	private float maxChargeTime;

	[SerializeField]
	private float minChargeTime;

	private float timeToMaxCharge;

	private float currentChargeTime;

	private bool hasReleasedSinceLastShot;

	[SerializeField]
	private ParticleSystem psLines;

	[SerializeField]
	private ParticleSystem psOrb;

	[SerializeField]
	private ParticleSystem.MinMaxGradient ChargeColorGradient;

	[NonSerialized]
	public float sunderChance;

	public float AdjustedReloadTimePerBullet;

	public bool splitShot;

	public float splitAngle;

	public float splitDamageReduction;

	[NonSerialized]
	public float ChargingDamageMultiplyer;

	[NonSerialized]
	public float explosionDamage;

	private int baseMagazineSize;

	private Coroutine _reloadCoroutine;

	public bool ReloadBlocked;

	private bool _reloadReady;

	private bool _reloadCoverOff;

	private Vector2 lastAimPointSet = Vector2.zero;

	public bool HasExplosiveShots { get; set; }

	private float NormalizedChargeTime => Mathf.Clamp01(currentChargeTime / timeToMaxCharge);

	public Resource AmmoResource
	{
		get
		{
			if (!UseScrapInsteadOfAmmo)
			{
				return ResourceManager.Instance.Ammo;
			}
			return ResourceManager.Instance.Scrap;
		}
	}

	public bool CanShoot => AmmoResource.Value >= moduleCannon.GetUpgradedStatValueByStatType(StatTypes.consumption);

	public bool UseScrapInsteadOfAmmo { get; set; }

	private float PendingReloadAmount => moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity) - AmmoCount;

	private float AmmoAfterNextBullet
	{
		get
		{
			float upgradedStatValueByStatType = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.consumption);
			return (UseScrapInsteadOfAmmo ? ResourceManager.Instance.Scrap.Value : ResourceManager.Instance.Ammo.Value) - AmmoCount * upgradedStatValueByStatType;
		}
	}

	private float AmmoNeededForFullReload
	{
		get
		{
			float upgradedStatValueByStatType = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity);
			float upgradedStatValueByStatType2 = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.consumption);
			return (UseScrapInsteadOfAmmo ? ResourceManager.Instance.Scrap.Value : ResourceManager.Instance.Ammo.Value) - upgradedStatValueByStatType * upgradedStatValueByStatType2;
		}
	}

	public float AmmoCount
	{
		get
		{
			return ammoCount;
		}
		set
		{
			ammoCount = value;
			this.AmmoChangedTo?.Invoke(ammoCount);
			if (AmmoCount <= 0f)
			{
				OnStartReload();
			}
		}
	}

	public float AmmoReservedByCannon => AmmoCount;

	public bool _reloading { get; private set; }

	public event Delegates.HealthChangeHandler OnProjectileHitEvent;

	public event Delegates.ProjectileSpawnHandler OnProjectileSpawnEvent;

	public event Delegates.HealthChangeHandler OnKill;

	public event Action OnFire;

	public event Action OnReleaseFire;

	public event Action<float> AmmoChangedTo;

	public event Action Upgraded;

	public event Action ReloadStart;

	public event Action<float> ReloadUpdate;

	public event Action ReloadFailed;

	public event Action<float> ReloadComplete;

	public event Action ReloadStoped;

	public event Action MagazineFull;

	public void OnUpgraded()
	{
		TryStopReload();
		this.Upgraded?.Invoke();
		AmmoCount = Mathf.Min(AmmoResource.Value, (int)moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity));
		AdjustedReloadTimePerBullet = reloadTimePerBullet * moduleCannon.GetUpgradedStatValueByStatType(StatTypes.timeToReload) / 5f;
	}

	public void OnAmmoChangedTo(int ammo)
	{
		this.AmmoChangedTo(ammo);
	}

	private void Awake()
	{
		Instance = this;
		anim = GetComponent<Animator>();
		moduleCannon = base.transform.parent.parent.GetComponent<ModuleCannon>();
		shotPoint = base.transform.GetChild(1).transform;
		shotPointDoubleLeft = base.transform.GetChild(2).transform;
		shotPointDoubleRight = base.transform.GetChild(3).transform;
		aimVector = Vector2.right;
	}

	private void Start()
	{
		ammoCount = 0f;
		AdjustedReloadTimePerBullet = reloadTimePerBullet * moduleCannon.GetUpgradedStatValueByStatType(StatTypes.timeToReload) / 5f;
		crosshair = UIManager.Instance.CannonCrosshair;
		LevelManager.Instance.LevelCompleted += delegate
		{
			aimVector = Vector2.right;
		};
		LevelManager.Instance.LevelCompleted += StopChargingShot;
		moduleCannon.ModuleBreak += delegate
		{
			StopChargingShot();
		};
		moduleCannon.OnEMPd += StopChargingShot;
		CannonAmmo.OnReloadReady += HandleReloadReady;
		CannonAmmo.OnReloadComplete += HandleReloadComplete;
		baseMagazineSize = (int)moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity);
	}

	private void OnDestroy()
	{
		LevelManager.Instance.LevelCompleted -= StopChargingShot;
		moduleCannon.OnEMPd -= StopChargingShot;
		CannonAmmo.OnReloadReady -= HandleReloadReady;
		CannonAmmo.OnReloadComplete -= HandleReloadComplete;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		shotTimer -= Time.deltaTime;
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
		{
			if (moduleCannon.GetUpgradedStatValueByStatType(StatTypes.count) == 2f)
			{
				anim.Play("CannonIdleDouble", 0);
			}
			else
			{
				anim.Play("Idle", 0);
			}
		}
		if (moduleCannon.IsFullyBroken)
		{
			return;
		}
		timeToMaxCharge = Mathf.Clamp(maxChargeTime * moduleCannon.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary), minChargeTime, maxChargeTime);
		Aim();
		if (!isActive)
		{
			return;
		}
		if (!moduleCannon.Interactable.Interactor || !moduleCannon.Interactable.Interactor.playerController.ActionPrimary)
		{
			this.OnReleaseFire?.Invoke();
		}
		if (Train.Instance.moduleDeflectOn)
		{
			DeflectShot();
		}
		if (isGatling && !isCharging)
		{
			if (moduleCannon.Interactable.Interactor.playerController.ActionPrimary)
			{
				CannonShot();
			}
		}
		else if (isCharging)
		{
			if (moduleCannon.Interactable.Interactor.playerController.ActionPrimary && hasReleasedSinceLastShot && !_reloading)
			{
				currentChargeTime += Time.deltaTime;
				if (!psLines.isPlaying)
				{
					psLines.Play();
					psOrb.Play();
				}
				ParticleSystem.MainModule main = psOrb.main;
				main.startSize = NormalizedChargeTime * 0.2f;
				main.startColor = new ParticleSystem.MinMaxGradient(ChargeColorGradient.Evaluate(NormalizedChargeTime));
				ParticleSystem.ShapeModule shape = psLines.shape;
				shape.radius = NormalizedChargeTime * 0.3f;
				ParticleSystem.MainModule main2 = psLines.main;
				main2.startLifetime = new ParticleSystem.MinMaxCurve(0.1f, NormalizedChargeTime * 0.5f);
				Color color = ChargeColorGradient.Evaluate(NormalizedChargeTime);
				color.a = 1f;
				main2.startColor = new ParticleSystem.MinMaxGradient(color);
				if (isGatling && currentChargeTime >= timeToMaxCharge)
				{
					ReleaseChargedShot();
					hasReleasedSinceLastShot = true;
				}
			}
			else
			{
				if (currentChargeTime > 0f)
				{
					ReleaseChargedShot();
				}
				if (!moduleCannon.Interactable.Interactor.playerController.ActionPrimary)
				{
					hasReleasedSinceLastShot = true;
				}
			}
		}
		else if ((bool)moduleCannon.Interactable.Interactor && moduleCannon.Interactable.Interactor.playerController.ActionPrimary)
		{
			CannonShot();
		}
	}

	public void OnStartReload()
	{
		if (debugInstantReload)
		{
			InstantFullReload(forced: true);
			this.ReloadComplete?.Invoke(ammoCount);
		}
		else if (_reloadCoroutine != null && !_reloading)
		{
			StopCoroutine(_reloadCoroutine);
			_reloadCoroutine = StartCoroutine(ReloadCoroutine());
		}
		else if (!ReloadBlocked && !_reloading)
		{
			_reloadCoroutine = StartCoroutine(ReloadCoroutine());
		}
	}

	private void HandleReloadReady()
	{
		_reloadReady = true;
		_reloadCoverOff = false;
	}

	private void HandleReloadComplete()
	{
		_reloadCoverOff = true;
	}

	private IEnumerator ReloadCoroutine()
	{
		if (_reloading)
		{
			yield break;
		}
		_reloading = true;
		yield return new WaitForSeconds(0.15f);
		float reloadAmount = PendingReloadAmount;
		if (reloadAmount <= 0f)
		{
			this.ReloadFailed?.Invoke();
			if (ammoCount == 0f)
			{
				UIManager.Instance.CannonCrosshair.OutOfAmmo();
			}
			_reloading = false;
			yield break;
		}
		float consumption = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.consumption);
		if (AmmoCount + consumption > AmmoResource.Value)
		{
			this.ReloadFailed?.Invoke();
			_reloading = false;
			yield break;
		}
		this.ReloadStart?.Invoke();
		UIManager.Instance.MouseCursor.CannonReloadStart();
		UIManager.Instance.CannonCrosshair.StartRefill(CannonAmmo.Instance.leftCover.slideInTime + CannonAmmo.Instance.leftCover.slideInTime + PendingReloadAmount * AdjustedReloadTimePerBullet, PendingReloadAmount == moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity));
		int bulletsPerSfx = Mathf.Max(1, (int)moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity) / baseMagazineSize);
		int bulletsSinceLastSfx = 0;
		_reloadReady = false;
		yield return new WaitUntil(() => _reloadReady);
		moduleCannon.PlayBulletReloadSound();
		while (reloadAmount > 0f && !(AmmoCount + consumption > AmmoResource.Value))
		{
			AmmoCount += 1f;
			reloadAmount -= 1f;
			bulletsSinceLastSfx++;
			if (bulletsSinceLastSfx >= bulletsPerSfx)
			{
				moduleCannon.PlayBulletReloadSound();
				bulletsSinceLastSfx = 0;
			}
			float bulletReloadTimer = AdjustedReloadTimePerBullet;
			while (bulletReloadTimer > 0f)
			{
				bulletReloadTimer -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
		}
		moduleCannon.PlayReloadSound();
		this.MagazineFull?.Invoke();
		_reloadCoverOff = false;
		yield return new WaitUntil(() => _reloadCoverOff);
		UIManager.Instance.MouseCursor.CannonReloadEnd();
		this.ReloadComplete?.Invoke(AmmoCount);
		_reloading = false;
	}

	public void TryStopReload()
	{
		if (_reloadCoroutine != null)
		{
			StopCoroutine(_reloadCoroutine);
			UIManager.Instance.CannonCrosshair.StopRefil();
			this.ReloadStoped?.Invoke();
			_reloadCoroutine = null;
			_reloadReady = false;
			_reloadCoverOff = false;
		}
		_reloading = false;
	}

	public void InstantFullReload(bool forced = false)
	{
		if (!(AmmoNeededForFullReload <= 0f) || forced)
		{
			ammoCount = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.capacity);
		}
	}

	public void SetAim(Vector2 point)
	{
		if (!((lastAimPointSet - point).magnitude < moduleCannon.aimPosThreashold))
		{
			lastAimPointSet = point;
			Vector3 position = point + new Vector2(-0f, 0f);
			position.z = Mathf.Abs(Camera.main.transform.position.z - base.transform.position.z);
			Vector3 vector = Camera.main.ScreenToWorldPoint(position) - base.transform.position;
			crosshairDst = Mathf.Lerp(crosshairDst, vector.magnitude, 0.5f);
			aimVector = vector.normalized * crosshairDst;
		}
	}

	public void TranslateAim(Vector2 stick)
	{
		float magnitude = stick.magnitude;
		if (!(magnitude < 0.1f))
		{
			float value = Vector2.SignedAngle(aimVector, stick);
			float num = magnitude * 180f;
			float angle = Mathf.Clamp(value, (0f - num) * Time.deltaTime, num * Time.deltaTime);
			aimVector = Quaternion.AngleAxis(angle, Vector3.forward) * aimVector;
			aimVector = aimVector.normalized;
			crosshairDst = 1f;
			aimVector *= crosshairDst;
		}
	}

	private void Aim()
	{
		Quaternion to = Quaternion.LookRotation(Vector3.forward, aimVector.normalized);
		float num = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.deltaTime;
		if ((isGatling || isCharging) && moduleCannon.Interactable.Interactor != null && moduleCannon.Interactable.Interactor.GetComponent<PlayerController>().ActionPrimary)
		{
			num *= 0.5f;
		}
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, num);
		float num2 = Vector3.Angle(base.transform.up, aimVector.normalized);
		if (num > 0f)
		{
			nonZeroRotationTime = num2 / num;
		}
		crosshair.transform.position = base.transform.position + base.transform.up * crosshairDst;
	}

	public void ApplyDamageBoost(float extraDamage)
	{
		damageBoost += extraDamage;
		Debug.Log($"Cannon damage increased by {extraDamage}. Total Boost: {damageBoost}");
	}

	private void CannonShot()
	{
		if (shotTimer > 0f || _reloading)
		{
			return;
		}
		float upgradedStatValueByStatType = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.consumption);
		if (AmmoCount < 1f)
		{
			if (AmmoAfterNextBullet < upgradedStatValueByStatType)
			{
				UIManager.Instance.CannonCrosshair.OutOfAmmo();
				CannonAmmo.Instance.TurnOnNoAmmoLight();
			}
			else
			{
				OnStartReload();
			}
			return;
		}
		float upgradedStatValueByStatType2 = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.count);
		float upgradedStatValueByStatType3 = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.spread);
		float minInclusive = (0f - upgradedStatValueByStatType3) / 2f;
		float maxInclusive = upgradedStatValueByStatType3 / 2f;
		if (UseScrapInsteadOfAmmo)
		{
			ResourceManager.Instance.Scrap.TrySpend(upgradedStatValueByStatType);
			DataTrackingManager.Instance.AddScrapUsedAsAmmo((int)upgradedStatValueByStatType);
		}
		else
		{
			ResourceManager.Instance.Ammo.TrySpend(upgradedStatValueByStatType);
			DataTrackingManager.Instance.AddAmmoUsed((int)upgradedStatValueByStatType);
		}
		float num = AmmoCount - 1f;
		if (num > 0f)
		{
			crosshair.StartRefill(shotTimer, isFullReload: false);
		}
		AmmoCount = num;
		if (!debugInstantReload && AmmoCount < 1f)
		{
			if (AmmoAfterNextBullet < upgradedStatValueByStatType)
			{
				UIManager.Instance.CannonCrosshair.OutOfAmmo();
				CannonAmmo.Instance.TurnOnNoAmmoLight();
			}
			else
			{
				OnStartReload();
			}
		}
		for (int i = 0; (float)i < upgradedStatValueByStatType2; i++)
		{
			float z = 0f;
			if (upgradedStatValueByStatType2 != 2f)
			{
				z = UnityEngine.Random.Range(minInclusive, maxInclusive);
			}
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * base.transform.rotation;
			GameObject gameObject = ((upgradedStatValueByStatType2 != 2f) ? UnityEngine.Object.Instantiate(bulletPrefab, shotPoint.position, quaternion) : ((upgradedStatValueByStatType2 == 2f && i == 0) ? UnityEngine.Object.Instantiate(bulletPrefab, shotPointDoubleLeft.position, quaternion) : ((upgradedStatValueByStatType2 != 2f || i != 1) ? UnityEngine.Object.Instantiate(bulletPrefab, shotPoint.position, quaternion) : UnityEngine.Object.Instantiate(bulletPrefab, shotPointDoubleRight.position, quaternion))));
			Projectile component = gameObject.GetComponent<Projectile>();
			Vector2 direction = quaternion * Vector2.up;
			ProjectileSpawnEventArgs args = new ProjectileSpawnEventArgs(this, component, direction);
			this.OnProjectileSpawnEvent?.Invoke(args);
			component.sourceUnit = moduleCannon;
			component.burn = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.burn);
			component.critChance = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.critChance);
			component.sunderChance = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.sunderChance);
			component.hitsRemaining = (int)moduleCannon.GetUpgradedStatValueByStatType(StatTypes.pierce) + 1;
			float upgradedStatValueByStatType4 = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.projectileSpeed);
			component.speed = upgradedStatValueByStatType4 + NormalizedChargeTime * (ChargingDamageMultiplyer - 1f) * upgradedStatValueByStatType4;
			float upgradedStatValueByStatType5 = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.damage);
			component.damage = upgradedStatValueByStatType5 + damageBoost + consecutiveHitsDamageIncrease * (float)consecutiveHits;
			if (isCharging)
			{
				component.damage += upgradedStatValueByStatType5 * (ChargingDamageMultiplyer * NormalizedChargeTime);
			}
			component.damage *= moduleCannon.GetUpgradedStatValueByStatType(StatTypes.modifier);
			if (HasExplosiveShots)
			{
				explosionDamage = component.damage;
				component.damage = 0f;
			}
			component.Scale = 1f + NormalizedChargeTime * (ChargingDamageMultiplyer - 1f);
			component.isRedirecting = hasRedirectingProjectiles;
			component.trackingSpeed = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.tracking);
			component.screenWarpCounter = Train.Instance.projectileScreenWarpCounter;
			GameManager.Instance.cannonFiresInRun++;
			component.OnProjectileMiss += ResetConsecutiveHits;
			component.ProjectileHit += delegate
			{
				IncrementConsecutiveHits();
			};
			component.ProjectileHit += OnProjectileHit;
			if (splitShot)
			{
				component.isGoingToSplit = true;
				component.splitAngle = splitAngle;
			}
			if (HasExplosiveShots)
			{
				component.explosiveShot = true;
				component.explosionGo = explosionGo;
				component.explosionSize = explosionSize;
			}
			damage = component.damage;
		}
		shotTimer = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		if (upgradedStatValueByStatType2 == 2f)
		{
			anim.Play("CannonShootDouble", 0);
		}
		else
		{
			anim.Play("Shoot", 0, 0f);
		}
		UIManager.Instance.CannonCrosshair.OnShoot();
		CameraController.Instance.Shake(0.2f, 0.15f);
		moduleCannon.PlayModuleUniqueSound(soundPitchCurve.Evaluate(damage));
		damage = moduleCannon.GetUpgradedStatValueByStatType(StatTypes.damage);
		this.OnFire?.Invoke();
	}

	private void DeflectShot()
	{
		if (Train.Instance.moduleDeflect.deflectCharges > 0 && PlayerManager.Instance.Players.Any((PlayerController p) => p.ActionSecondary))
		{
			Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, crosshair.transform.position - base.transform.position);
			DeflectAOE component = UnityEngine.Object.Instantiate(deflectPsPrefab, shotPoint.position, quaternion).GetComponent<DeflectAOE>();
			component.SetWidthMedium();
			component.deflectCanHack = Train.Instance.moduleDeflect.deflectCanHack;
			component.deflectHackProbability = Train.Instance.moduleDeflect.deflectHackProbability;
			component.speed = Train.Instance.moduleDeflect.deflectSpeed;
			component.damage = Train.Instance.moduleDeflect.deflectDamage;
			component.deflectDamageIncrease = Train.Instance.moduleDeflect.deflectDamageIncrease;
			component.canRefundCooldown = Train.Instance.moduleDeflect.deflectRefundCooldown;
			component.deflectSplitBullet = Train.Instance.moduleDeflect.deflectSplitBullet;
			moduleCannon.PlayDeflectSound();
			Train.Instance.moduleDeflect.deflectCharges--;
			Train.Instance.moduleDeflect.Activate();
			if (Train.Instance.moduleDeflect.deflectWidthIncrease)
			{
				component.SetWidthBig();
			}
			if (Train.Instance.moduleDeflect.deflectDoubleWave)
			{
				Quaternion quaternion2 = Quaternion.AngleAxis(180f, Vector3.forward);
				Quaternion rotation = quaternion * quaternion2;
				DeflectAOE component2 = UnityEngine.Object.Instantiate(deflectPsPrefab, shotPoint.position, rotation).GetComponent<DeflectAOE>();
				component2.SetWidthMedium();
				component2.deflectCanHack = Train.Instance.moduleDeflect.deflectCanHack;
				component2.deflectHackProbability = Train.Instance.moduleDeflect.deflectHackProbability;
				component2.speed = Train.Instance.moduleDeflect.deflectSpeed;
				component2.damage = Train.Instance.moduleDeflect.deflectDamage;
				component2.deflectDamageIncrease = Train.Instance.moduleDeflect.deflectDamageIncrease;
				component2.deflectSplitBullet = Train.Instance.moduleDeflect.deflectSplitBullet;
			}
		}
	}

	public void SetActive(bool isActive)
	{
		this.isActive = isActive;
		if (hasLaser)
		{
			laser.SetActive(isActive);
		}
	}

	public void DebugSetInstantReload(bool instantReload)
	{
		debugInstantReload = instantReload;
	}

	private void IncrementConsecutiveHits()
	{
		consecutiveHits++;
	}

	private void ResetConsecutiveHits()
	{
		consecutiveHits = 0;
	}

	private void OnProjectileHit(HealthChangeInfo info)
	{
		this.OnProjectileHitEvent?.Invoke(info);
		if (info.IsLethal)
		{
			this.OnKill?.Invoke(info);
		}
	}

	private void StopChargingShot()
	{
		if (isCharging)
		{
			hasReleasedSinceLastShot = false;
			currentChargeTime = 0f;
			psLines.Stop();
			psOrb.Stop();
		}
	}

	private void ReleaseChargedShot()
	{
		CannonShot();
		hasReleasedSinceLastShot = false;
		currentChargeTime = 0f;
		psLines.Stop();
		psOrb.Stop();
	}
}
