using UnityEngine;

public class E4_5Pet : EnemyBase
{
	[Header("Pet Fields")]
	[SerializeField]
	private E4_5Hunter hunter;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	private new void Start()
	{
		base.Start();
		base.IsEnemy = true;
		LevelManager.Instance.DestinationReached += KillSelf;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void FixedUpdate()
	{
		Move();
	}

	private new void Update()
	{
		empDuration -= Time.deltaTime;
		base.Anim.SetFloat("WheelSpeed", hunter.relativeSpeedMult);
		if (hunter == null || hunter.HealthComponent == null || hunter.HealthComponent.IsDead)
		{
			KillSelf();
		}
	}

	public override void Move()
	{
		Vector3 position = base.transform.position;
		float num = 0.1f;
		float num2 = 2f;
		float num3 = Mathf.Sin(Time.time * num2) * num;
		position.y += num3 * Time.deltaTime * hunter.relativeSpeedMult;
		base.transform.position = position;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
	}

	private void KillSelf()
	{
		base.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, base.HealthComponent, -100f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: false, DamageType.God));
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		hunter.AlertOfPetDeath();
		DestroySelf();
	}

	private void DestroySelf()
	{
		LevelManager.Instance.DestinationReached -= DestroySelf;
		EnemyManager.Instance.OnEnemyDestroyed(this);
		Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, explosionScale, 0f);
		GetComponent<ExplodeSprite>()?.Explode();
		if (deathSFX.clips.Count != 0 && Random.Range(0f, 1f) > chanceForSpawnSFX)
		{
			soundBuilder.Play(deathSFX);
		}
		Object.Destroy(base.gameObject);
	}
}
