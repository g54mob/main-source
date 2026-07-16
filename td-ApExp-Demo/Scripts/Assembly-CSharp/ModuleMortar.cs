using System;
using UnityEngine;

public class ModuleMortar : Module
{
	private const float STEP_SIZE = 0.01f;

	[SerializeField]
	private Transform mortarTF;

	[SerializeField]
	private GameObject mortarProjPrefab;

	[SerializeField]
	private AnimationCurve trajectory;

	private Vector2 aimPos;

	[NonSerialized]
	public float shotTimer;

	[SerializeField]
	private GameObject crosshairPrefab;

	private Crosshair crosshair;

	public Delegates.HealthChangeHandler OnExplosionHit;

	public Delegates.HealthChangeHandler OnExplosionKill;

	[NonSerialized]
	public int secondaryCount;

	[NonSerialized]
	public float secondaryMult;

	[NonSerialized]
	public bool areShellsMines;

	[NonSerialized]
	public bool dropsBurnAOE;

	private float autoAngle;

	[SerializeField]
	private float autoAimDst = 1.5f;

	[SerializeField]
	private float autoAimSpeed = 15f;

	[SerializeField]
	private float minAimDst = 0.5f;

	[NonSerialized]
	public bool splashBullets;

	private Vector2 lastAimPointSet;

	public float TrajectoryIntegral { get; private set; }

	public AnimationCurve Trajectory => trajectory;

	public bool IsAutomatic { get; set; }

	protected new void Awake()
	{
		base.Awake();
		crosshair = UIManager.Instance.MortarCrosshair;
		TrajectoryIntegral = CurveSum(Trajectory);
		base.FullyBroken += OnFullyBroken;
	}

	protected override void SetEmpSoundChannels()
	{
	}

	protected override void HandleLevelCompleted()
	{
		base.HandleLevelCompleted();
		crosshair.gameObject.SetActive(value: false);
	}

	protected override void HandleLevelStarted()
	{
		base.HandleLevelStarted();
		if (IsAutomatic)
		{
			OnStartFiring();
		}
	}

	protected override void OnFullyBroken()
	{
		crosshair.gameObject.SetActive(value: false);
	}

	protected override void OnFix(HealthChangeInfo info)
	{
		base.OnFix(info);
		if (IsAutomatic)
		{
			OnStartFiring();
		}
	}

	public override bool CanInteract()
	{
		if (!IsAutomatic)
		{
			return base.CanInteract();
		}
		return false;
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		base.OnInteractStart(interactor);
		ModuleStartAiming();
		OnStartFiring();
	}

	protected override void OnInteractUpdate(Interactor interactor)
	{
		base.OnInteractUpdate(interactor);
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		base.OnInteractEnd(interactor);
		ModuleEndAiming();
	}

	protected override void OnSetPoint(Vector2 point)
	{
		if (!((lastAimPointSet - point).magnitude < aimPosThreashold))
		{
			lastAimPointSet = point;
			aimPos = Camera.main.ScreenToWorldPoint(point + new Vector2(-0f, 0f));
		}
	}

	protected override void OnTranslatePoint(Vector2 point)
	{
		if (!(point.magnitude < 0.1f))
		{
			aimPos += point.normalized * Time.deltaTime * point.magnitude * 2f;
			Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f));
			Vector3 vector2 = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f));
			aimPos.x = Mathf.Clamp(aimPos.x, vector.x + 0.5f, vector2.x - 0.5f);
			aimPos.y = Mathf.Clamp(aimPos.y, vector.y + 0f, vector2.y - 0f);
		}
	}

	private new void Update()
	{
		base.Update();
		if (!crosshair.gameObject.activeSelf || !LevelManager.Instance.IsPlaying || base.IsFullyBroken || base.IsEMPattached)
		{
			shotTimer = GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
			return;
		}
		if (IsAutomatic)
		{
			autoAngle += Time.deltaTime * autoAimSpeed;
			aimPos = base.transform.position + Quaternion.Euler(0f, 0f, autoAngle) * Vector3.up * autoAimDst;
		}
		Aim();
		Fire();
	}

	private void Aim()
	{
		Vector2 vector = aimPos - (Vector2)base.transform.position;
		if (vector.magnitude < minAimDst)
		{
			crosshair.transform.position = mortarTF.up * minAimDst + mortarTF.position;
		}
		else
		{
			crosshair.transform.position = mortarTF.up * vector.magnitude + mortarTF.position;
		}
		float maxDegreesDelta = GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.deltaTime;
		Vector2 vector2 = aimPos - (Vector2)mortarTF.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, vector2);
		mortarTF.rotation = Quaternion.RotateTowards(mortarTF.rotation, to, maxDegreesDelta);
	}

	private void Fire()
	{
		shotTimer += Time.deltaTime;
		if (!(shotTimer < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary)))
		{
			float upgradedStatValueByStatType = GetUpgradedStatValueByStatType(StatTypes.consumption);
			if (ResourceManager.Instance.Ammo.TrySpendAmmo(upgradedStatValueByStatType))
			{
				DataTrackingManager.Instance.AddAmmoUsed((int)upgradedStatValueByStatType);
				shotTimer = 0f;
				PlayModuleUniqueSound();
				OnStartFiring();
				SpawnProjectile();
				crosshair.StartRefill(GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary));
			}
		}
	}

	public void SpawnProjectile(Vector2? targetPos = null, float damage = 0f)
	{
		ProjectileMortarShell component = UnityEngine.Object.Instantiate(mortarProjPrefab, base.transform.position, Quaternion.identity, null).GetComponent<ProjectileMortarShell>();
		if (targetPos.HasValue)
		{
			component.targetPos = targetPos.Value;
		}
		else
		{
			Vector2 vector = aimPos - (Vector2)base.transform.position;
			component.targetPos = mortarTF.up * vector.magnitude + mortarTF.position;
		}
		if (damage == 0f)
		{
			component.damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		}
		else
		{
			component.damage = damage;
		}
		component.mortar = this;
		component.OnExplosionKill += OnExplosionKillHandler;
		component.radius = GetUpgradedStatValueByStatType(StatTypes.scale);
		component.sourceUnit = this;
		component.isMine = areShellsMines;
		component.secondaryCount = secondaryCount;
		component.secondaryMult = secondaryMult;
		component.dropsBurnAOE = dropsBurnAOE;
		component.OnExplosionHit += OnExplosionHit;
		anim.Play("Shoot", 0, 0f);
	}

	private void OnExplosionKillHandler(HealthChangeInfo info)
	{
		if (info.IsLethal)
		{
			OnExplosionKill?.Invoke(info);
		}
	}

	public static float CurveSum(AnimationCurve curve)
	{
		float num = 0f;
		for (int i = 0; (float)i < 100f; i++)
		{
			num += IntegralOnStep(0.01f * (float)i, curve.Evaluate(0.01f * (float)i), 0.01f * (float)(i + 1), curve.Evaluate(0.01f * (float)(i + 1)));
		}
		return num;
	}

	public static float IntegralOnStep(float x0, float y0, float x1, float y1)
	{
		float num = (y1 - y0) / (x1 - x0);
		float num2 = y0 - num * x0;
		return num / 2f * x1 * x1 + num2 * x1 - (num / 2f * x0 * x0 + num2 * x0);
	}

	private void OnStartFiring()
	{
		if (!crosshair.gameObject.activeSelf)
		{
			shotTimer = 0f;
			crosshair.gameObject.SetActive(value: true);
			crosshair.StartRefill(GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary));
		}
	}
}
