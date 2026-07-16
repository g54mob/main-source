using UnityEngine;

public class ProjectileGarbage : Projectile
{
	private Unit TargetUnit;

	[HideInInspector]
	public E2_B_GarbageThrower thrower;

	[SerializeField]
	private GameObject explosionPrefab;

	[SerializeField]
	private float explosionScale;

	[SerializeField]
	private UnitAudioController AudioController;

	[SerializeField]
	public int burnTicks;

	private bool targetSet;

	private new void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
	}

	private new void Update()
	{
		if (Time.timeScale != 0f)
		{
			if (TargetUnit == null)
			{
				DestroyProjectile();
			}
			else if (ProximityCheck())
			{
				Hit();
			}
		}
	}

	private new void FixedUpdate()
	{
		Move();
		RaycastCollide(speed);
	}

	public new void SetTarget(Unit target)
	{
		if (!targetSet)
		{
			targetSet = true;
			TargetUnit = target;
		}
	}

	private bool ProximityCheck()
	{
		if (TargetUnit != null)
		{
			return (TargetUnit.transform.position - base.transform.position).sqrMagnitude <= 0.01f;
		}
		return false;
	}

	protected override void Move()
	{
		if (!(TargetUnit == null))
		{
			Vector3 normalized = (TargetUnit.transform.position - base.transform.position).normalized;
			base.transform.position += normalized * speed;
		}
	}

	private void Hit()
	{
		TargetUnit.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(sourceUnit, TargetUnit.HealthComponent, 0f - damage));
		TargetUnit.HealthComponent.ApplyBurn(burnTicks, thrower);
		DestroyProjectile();
	}

	public override void DestroyProjectile()
	{
		Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity, null).GetComponent<Explosion>().Initialize(sourceUnit, explosionScale, 0f);
		Object.Destroy(base.gameObject);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

	protected override void RaycastCollide(float speed)
	{
		RaycastHit2D raycastHit2D = ((!isEnemyProjectile) ? Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Enemy")) : Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Unit", "Resource")));
		if (!(raycastHit2D.collider == null) && isEnemyProjectile && raycastHit2D.collider.TryGetComponent<Unit>(out var component) && component.isShieldPlate)
		{
			HealthChangeInfo info = new HealthChangeInfo(this, component.HealthComponent, trainDamage);
			component.HealthComponent.ChangeHealthWithInfo(info);
			trainDamage = 0f;
			DestroyProjectile();
		}
	}

	public override void DeflectProjectile(Unit newSourceUnit, float damageIncreasePercent = 0f)
	{
		base.DeflectProjectile(newSourceUnit, damageIncreasePercent);
		TargetUnit = thrower.boss;
	}
}
