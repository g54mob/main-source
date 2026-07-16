using UnityEngine;

public class ReviveBomb : Projectile
{
	public Unit TargetUnit;

	public float revivePercent;

	private Animator anim;

	private new void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private new void Update()
	{
		if (sourceUnit.HealthComponent.IsDead)
		{
			DestroyProjectile();
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f)
		{
			Move();
			if (ProximityCheck())
			{
				Hit();
			}
		}
	}

	private bool ProximityCheck()
	{
		return (TargetUnit.transform.position - base.transform.position).sqrMagnitude <= 0.01f;
	}

	protected override void Move()
	{
		Vector3 normalized = (TargetUnit.transform.position - base.transform.position).normalized;
		base.transform.position += normalized * speed;
	}

	private void Hit()
	{
		HealthChangeInfo info = new HealthChangeInfo(sourceUnit, TargetUnit.HealthComponent, TargetUnit.HealthComponent.HealthMax * revivePercent / 100f, isPercent: false, null, canRes: true, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		(TargetUnit as E2_B_BossController).ReviveSelf(info);
		DestroyProjectile();
	}

	public override void DestroyProjectile()
	{
		Object.Destroy(base.gameObject);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}
}
