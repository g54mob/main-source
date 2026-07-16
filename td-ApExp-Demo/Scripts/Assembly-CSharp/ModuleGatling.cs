using System;
using System.Collections;
using AudioSystem;
using UnityEngine;

public class ModuleGatling : Module
{
	[SerializeField]
	private GameObject projPrefab;

	[SerializeField]
	private Transform gatlingTf;

	[SerializeField]
	private SpriteRenderer gunSr;

	[SerializeField]
	private Transform muzzle;

	private Transform currentTargetTf;

	public float autoTrackingSpeed;

	[SerializeField]
	private GameObject crosshairPrefab;

	private Crosshair crosshair;

	private GameObject pressToFire;

	private Vector2 aimPos;

	private bool waitingForInput;

	private float spinTimer;

	private Vector3 bulletRainPosition;

	private bool prepareToShoot;

	private bool startShooting;

	private float shootDuration;

	private bool positionSet;

	private Vector2 aimingPosition;

	private bool readyToInteract;

	private float maxSpinSpeed = 10f;

	private float currentSpinSpeed = 0.1f;

	private bool isCharging;

	public int killCount;

	[SerializeField]
	private Sprite lmbIcon;

	[SerializeField]
	private Sprite rtLtIcon;

	private bool shouldRefundCD;

	private Vector2 lastAimPoint = Vector2.zero;

	public event Action<HealthChangeInfo> OnProjectileHitEvent;

	public event Action<HealthChangeInfo> OnKill;

	private new void Awake()
	{
		base.Awake();
		crosshair = UIManager.Instance.GatlingCrosshair;
		readyToInteract = true;
		if (InputManager.Instance.IsLastInputGamepad)
		{
			pressToFire = UIManager.Instance.GatlingCrosshairFireIndicatorGamepad;
		}
		else
		{
			pressToFire = UIManager.Instance.GatlingCrosshairFireIndicator;
		}
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	protected override void SetEmpSoundChannels()
	{
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		base.OnInteractStart(interactor);
		crosshair.gameObject.SetActive(value: true);
		waitingForInput = true;
		if (base.cooldownTimeElapsed <= 0f)
		{
			if (interactor.playerController.IsGamepad)
			{
				pressToFire = UIManager.Instance.GatlingCrosshairFireIndicatorGamepad;
			}
			else
			{
				pressToFire = UIManager.Instance.GatlingCrosshairFireIndicator;
			}
			pressToFire.SetActive(value: true);
		}
		ModuleStartAiming();
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		base.OnInteractEnd(interactor);
		waitingForInput = false;
		pressToFire.SetActive(value: false);
		ModuleEndAiming();
	}

	public override bool CanInteract()
	{
		if (!readyToInteract || base.cooldownTimeElapsed < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
		{
			return false;
		}
		return base.CanInteract();
	}

	private new void Update()
	{
		base.Update();
		crosshair.transform.position = aimPos;
		if (base.IsFullyBroken || base.IsEMPattached)
		{
			return;
		}
		spinTimer -= Time.deltaTime;
		shootDuration -= Time.deltaTime;
		base.cooldownTimeElapsed += Time.deltaTime;
		GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
		if (base.cooldownTimeElapsed < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
		{
			if (!isCharging)
			{
				isCharging = true;
				anim.Play("Charging", 0, 0f);
			}
			float normalizedTime = base.cooldownTimeElapsed / GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
			anim.Play("Charging", 0, normalizedTime);
			return;
		}
		if (isCharging)
		{
			isCharging = false;
			anim.Play("Idle");
		}
		if (waitingForInput && !GameManager.Instance.IsPaused && base.Interactable.Interactor.GetComponent<PlayerController>().ActionPrimary)
		{
			Activate();
		}
		if (prepareToShoot)
		{
			aimingPosition = bulletRainPosition;
			Aim(bulletRainPosition);
			if (currentSpinSpeed < maxSpinSpeed)
			{
				currentSpinSpeed += Time.deltaTime;
			}
			if (GetUpgradedStatValueByStatType(StatTypes.cooldownSecondary) == 0f)
			{
				currentSpinSpeed = maxSpinSpeed;
			}
			anim.SetFloat("SpinMult", currentSpinSpeed);
			anim.Play("Spinning");
			if (spinTimer <= 0f && positionSet)
			{
				startShooting = true;
				prepareToShoot = false;
				shootDuration = GetUpgradedStatValueByStatType(StatTypes.duration);
				positionSet = false;
			}
		}
		if (startShooting)
		{
			if (currentSpinSpeed < maxSpinSpeed)
			{
				currentSpinSpeed += Time.deltaTime / 2f;
			}
			StartCoroutine(StartShooting());
			startShooting = false;
		}
	}

	protected override void OnSetPoint(Vector2 point)
	{
		if (!((lastAimPoint - point).magnitude < aimPosThreashold))
		{
			lastAimPoint = point;
			Vector3 position = point + new Vector2(-0.1f, 0f);
			position.z = Mathf.Abs(Camera.main.transform.position.z - base.transform.position.z);
			aimPos = Camera.main.ScreenToWorldPoint(position);
		}
	}

	protected override void OnTranslatePoint(Vector2 point)
	{
		if (!(point.magnitude < 0.1f))
		{
			Vector2 vector = aimPos - (Vector2)base.transform.position;
			float value = Vector2.SignedAngle(vector, point);
			float num = point.magnitude * 180f * Time.deltaTime;
			vector = Quaternion.AngleAxis(Mathf.Clamp(value, 0f - num, num), Vector3.forward) * vector;
			aimPos = (Vector2)base.transform.position + vector.normalized;
		}
	}

	private void Aim(Vector3 position)
	{
		if (currentTargetTf != null)
		{
			position = currentTargetTf.position;
			Vector3 normalized = (currentTargetTf.position - gatlingTf.position).normalized;
			Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, normalized);
			gatlingTf.rotation = Quaternion.RotateTowards(gatlingTf.rotation, quaternion, autoTrackingSpeed * Time.deltaTime);
			positionSet = Quaternion.Angle(gatlingTf.rotation, quaternion) < 0.5f;
		}
		else
		{
			position = gatlingTf.up + gatlingTf.position;
			float maxDegreesDelta = GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.deltaTime;
			Vector2 vector = aimingPosition - (Vector2)gatlingTf.position;
			Quaternion quaternion2 = Quaternion.LookRotation(Vector3.forward, vector);
			gatlingTf.rotation = Quaternion.RotateTowards(gatlingTf.rotation, quaternion2, maxDegreesDelta);
			positionSet = Quaternion.Angle(gatlingTf.rotation, quaternion2) < 0.5f;
		}
	}

	private void Fire()
	{
		float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.spread);
		float minInclusive = (0f - upgradedStatValueByStatType) / 2f;
		float maxInclusive = upgradedStatValueByStatType / 2f;
		float z = UnityEngine.Random.Range(minInclusive, maxInclusive);
		Quaternion quaternion = Quaternion.Euler(0f, 0f, z);
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, quaternion * gatlingTf.up);
		Projectile component = UnityEngine.Object.Instantiate(projPrefab, muzzle.position, rotation, null).GetComponent<Projectile>();
		component.damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		component.hitsRemaining += (int)GetUpgradedStatValueByStatType(StatTypes.pierce);
		component.sourceUnit = this;
		component.screenWarpCounter = Train.Instance.projectileScreenWarpCounter;
		component.speed = GetUpgradedStatValueByStatType(StatTypes.projectileSpeed);
		component.ProjectileHit += OnProjectileHit;
		PlayModuleUniqueSound();
	}

	private IEnumerator StartShooting()
	{
		if (GetUpgradedStatValueByStatType(StatTypes.count) <= 0f || GetUpgradedStatValueByStatType(StatTypes.duration) <= 0f)
		{
			yield break;
		}
		float timeBetweenShots = GetUpgradedStatValueByStatType(StatTypes.duration) / GetUpgradedStatValueByStatType(StatTypes.count);
		float nextShotTime = Time.time;
		int bulletsFired = 0;
		while ((float)bulletsFired < GetUpgradedStatValueByStatType(StatTypes.count))
		{
			for (; Time.time >= nextShotTime; nextShotTime += timeBetweenShots)
			{
				if (!((float)bulletsFired < GetUpgradedStatValueByStatType(StatTypes.count)))
				{
					break;
				}
				Fire();
				bulletsFired++;
			}
			yield return null;
		}
		anim.Play("Idle");
		currentSpinSpeed = 0.1f;
		readyToInteract = true;
		if (!shouldRefundCD)
		{
			base.cooldownTimeElapsed = 0f;
		}
		shouldRefundCD = false;
	}

	private void OnProjectileHit(HealthChangeInfo info)
	{
		this.OnProjectileHitEvent?.Invoke(info);
		if (info.IsLethal)
		{
			this.OnKill?.Invoke(info);
		}
	}

	public override void Activate()
	{
		anim.Play("Idle");
		float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.consumption);
		ResourceManager.Instance.Ammo.TrySpend(upgradedStatValueByStatType);
		DataTrackingManager.Instance.AddAmmoUsed((int)upgradedStatValueByStatType);
		readyToInteract = false;
		prepareToShoot = true;
		bulletRainPosition = crosshair.transform.position;
		waitingForInput = false;
		pressToFire.SetActive(value: false);
		spinTimer = GetUpgradedStatValueByStatType(StatTypes.cooldownSecondary);
		base.Activate();
	}

	public override void RefundConsumption()
	{
		base.RefundConsumption();
		float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.consumption);
		ResourceManager.Instance.Ammo.AddValue(upgradedStatValueByStatType);
	}

	public override void RefundCooldown()
	{
		base.RefundCooldown();
		shouldRefundCD = true;
	}
}
