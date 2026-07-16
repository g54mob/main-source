using UnityEngine;

public class RPG : Projectile
{
	private float randomDirectionNormalized;

	public event Delegates.HealthChangeHandler ExplosionKill;

	private new void Awake()
	{
		base.Awake();
		randomDirectionNormalized = ((Random.Range(0, 2) != 0) ? 1 : (-1));
	}

	private new void Update()
	{
		lifetimeTimer -= Time.deltaTime;
		if (lifetimeTimer < 0f)
		{
			DestroyProjectile();
		}
		if (targetUnit == null)
		{
			FindTrackingTarget();
		}
		else if (Mathf.Abs(Vector2.Distance(base.transform.position, targetUnit.transform.position)) <= 0.1f && targetUnit.HealthComponent.IsImmune)
		{
			DestroyProjectile();
		}
	}

	protected override void Move()
	{
		float num = 1f;
		if (isEnemyProjectile)
		{
			num = EnemyManager.Instance.EnemyMissileSpeedMult;
		}
		Vector3 translation = (isEnemyProjectile ? (base.transform.up * speed * num * Time.deltaTime) : (base.transform.up * speed * Time.deltaTime));
		base.transform.Translate(translation, Space.World);
		if (targetUnit != null)
		{
			Vector2 vector = targetUnit.transform.position - base.transform.position;
			float angle = Mathf.Atan2(vector.y, vector.x) * 57.29578f - 90f;
			base.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	public override void DestroyProjectile()
	{
		Explosion component = Object.Instantiate(explosionGo, base.transform.position, Quaternion.identity).GetComponent<Explosion>();
		component.Initialize(sourceUnit, explosionSize, 0f, trainDamage);
		component.OnExplosionKill += OnExplosionKill;
		base.DestroyProjectile();
	}

	private void OnExplosionKill(HealthChangeInfo info)
	{
		this.ExplosionKill?.Invoke(info);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.ExplosionKill = null;
	}
}
