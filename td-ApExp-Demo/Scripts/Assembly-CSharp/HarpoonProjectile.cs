using UnityEngine;

public class HarpoonProjectile : Unit
{
	[Header("Stats")]
	[SerializeField]
	private float speed;

	[Header("Harpoon")]
	[SerializeField]
	private GameObject attachEffect;

	[SerializeField]
	private GameObject empAOEPrefab;

	[SerializeField]
	protected GameObject explosionPrefab;

	[SerializeField]
	public float duration;

	[SerializeField]
	public float enemyDamage;

	[SerializeField]
	public float trainDamage;

	[SerializeField]
	public FakeRope rope;

	[Header("Sound")]
	[SerializeField]
	private UnitAudioController audioController;

	[SerializeField]
	private Animator anim;

	[HideInInspector]
	public Unit SourceUnit;

	[HideInInspector]
	public bool isAttached;

	private Transform targetTf;

	private E4_3Harpooner harpooner;

	private Explosion deathExplosion;

	private Rigidbody2D rb;

	[SerializeField]
	private Transform raycastPoint;

	private bool isDead;

	private float initialTrainDamage;

	private float initialEnemyDamage;

	private int burn;

	private bool isReturning;

	private float timer;

	private bool destroyed;

	private new void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		base.IsEnemy = true;
		if (SourceUnit != null)
		{
			if (base.TargetUnit.IsEnemy)
			{
				base.TargetUnit.HealthComponent.OnDeath += OnDeath;
				SourceUnit.HealthComponent.OnDeath += OnDeath;
			}
			else
			{
				SourceUnit.HealthComponent.OnDeath += delegate
				{
					if (rope != null)
					{
						Object.Destroy(rope.gameObject);
					}
					if (isAttached)
					{
						isDead = true;
					}
					else
					{
						DestroySelf();
					}
				};
			}
		}
		LevelManager.Instance.DestinationReached += DestroySelf;
		harpooner = SourceUnit.gameObject.GetComponent<E4_3Harpooner>();
		initialTrainDamage = harpooner.TrainDamage;
		initialEnemyDamage = harpooner.EnemyDamage;
		burn = harpooner.Burn;
		rope.SetObjectB(harpooner.ropePos);
	}

	private void FixedUpdate()
	{
		if (base.TargetUnit == null || targetTf == null)
		{
			return;
		}
		if (isAttached)
		{
			base.transform.position = targetTf.position;
		}
		else
		{
			if (isDead)
			{
				return;
			}
			if (!isReturning)
			{
				RaycastCollide();
				MoveTowardsTarget();
				if (Vector2.Distance(base.transform.position, targetTf.position) < 0.1f)
				{
					AttachToTarget();
				}
				return;
			}
			ReturnToGun();
			if (Vector2.Distance(base.transform.position, harpooner.ropePos.position) < 0.1f)
			{
				if ((bool)harpooner)
				{
					harpooner.ResetProjectile();
				}
				DestroySelf();
			}
		}
	}

	private void MoveTowardsTarget()
	{
		Vector2 vector = (targetTf.position - base.transform.position).normalized;
		rb.velocity = vector * speed;
		base.transform.up = base.TargetUnit.transform.position - base.transform.position;
	}

	private void ReturnToGun()
	{
		Vector2 vector = (harpooner.ropePos.position - targetTf.position).normalized;
		rb.velocity = vector * speed * 2f;
		base.transform.up = base.transform.position - harpooner.ropePos.position;
	}

	private void Update()
	{
		if (!isDead && isAttached)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				DealDamage(isInitialDamage: false);
				GameObject gameObject = Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity);
				deathExplosion = gameObject.GetComponent<Explosion>();
				deathExplosion.Initialize(this, 0.25f, 0f);
				CameraController.Instance.Shake(0.25f, 0.25f);
				isReturning = true;
				isAttached = false;
			}
		}
	}

	public void SetTarget(Unit target)
	{
		base.TargetUnit = target;
		if (base.TargetUnit is Module module)
		{
			targetTf = module.ModuleSlot.GetAnchorPoint(base.transform.position.y > 0f);
		}
		else
		{
			targetTf = base.TargetUnit.transform;
		}
	}

	private void AttachToTarget()
	{
		timer = duration;
		isAttached = true;
		rb.velocity = Vector2.zero;
		base.transform.position = targetTf.position;
		if ((bool)harpooner)
		{
			harpooner.HarpoonStuck();
		}
		DealDamage(isInitialDamage: true);
	}

	private void DealDamage(bool isInitialDamage)
	{
		if (base.TargetUnit is Module module)
		{
			if (isInitialDamage)
			{
				module.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(SourceUnit, module.HealthComponent, 0f - initialTrainDamage));
				if (burn > 0)
				{
					module.HealthComponent.ApplyBurn(burn, this);
				}
			}
			else
			{
				module.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(SourceUnit, module.HealthComponent, 0f - trainDamage));
			}
		}
		else
		{
			if (!(base.TargetUnit is EnemyBase enemyBase))
			{
				return;
			}
			if (isInitialDamage)
			{
				enemyBase.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(SourceUnit, enemyBase.HealthComponent, 0f - initialEnemyDamage));
				if (burn > 0)
				{
					enemyBase.HealthComponent.ApplyBurn(burn, this);
				}
			}
			else
			{
				enemyBase.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(SourceUnit, enemyBase.HealthComponent, 0f - enemyDamage));
			}
		}
	}

	protected virtual void OnDeath(HealthChangeInfo info)
	{
		DestroySelf();
	}

	private void DestroySelf()
	{
		if (!destroyed)
		{
			destroyed = true;
			LevelManager.Instance.DestinationReached -= DestroySelf;
			if ((bool)base.TargetUnit)
			{
				base.TargetUnit.HealthComponent.OnDeath += OnDeath;
			}
			if ((bool)SourceUnit)
			{
				SourceUnit.HealthComponent.OnDeath += OnDeath;
			}
			Object.Destroy(base.gameObject);
		}
	}

	private void RaycastCollide()
	{
		RaycastHit2D[] array = Physics2D.RaycastAll(raycastPoint.position, base.transform.up, 0.02f, LayerMask.GetMask("Unit", "Enemy"));
		foreach (RaycastHit2D raycastHit2D in array)
		{
			if (raycastHit2D.collider.TryGetComponent<Unit>(out var component) && component.isShieldPlate)
			{
				DestroySelf();
			}
		}
	}

	public void HarpoonerEMPd()
	{
		isReturning = true;
		isAttached = false;
		ReturnToGun();
	}
}
