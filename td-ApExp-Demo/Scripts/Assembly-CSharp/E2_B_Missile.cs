using System;
using UnityEngine;

public class E2_B_Missile : EnemyBase
{
	[NonSerialized]
	public E2_B_ArmamentSilo silo;

	private float randomNormalize;

	private float flyStraightTimer;

	private float flyStraightDuration = 1f;

	private new void Awake()
	{
		base.Awake();
		randomNormalize = ((UnityEngine.Random.Range(0, 2) != 0) ? 1 : (-1));
		flyStraightTimer = flyStraightDuration;
	}

	public void SetTarget(Unit t)
	{
		base.TargetUnit = t;
	}

	private new void Update()
	{
		float num = 1f;
		if (base.IsEnemy)
		{
			num = EnemyManager.Instance.EnemyMissileSpeedMult;
		}
		AnimatorStateInfo currentAnimatorStateInfo = base.Anim.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.IsName("Launching") && currentAnimatorStateInfo.normalizedTime < 1f)
		{
			return;
		}
		base.Anim.Play("Cruising");
		base.transform.parent = null;
		if (flyStraightTimer > 0f)
		{
			flyStraightTimer -= Time.deltaTime;
			base.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
			base.transform.position += base.transform.up * base.MoveSpeed * num * Time.deltaTime;
			return;
		}
		Vector3 upwards = base.transform.up;
		if ((bool)base.TargetUnit)
		{
			upwards = base.TargetUnit.transform.position - base.transform.position;
		}
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, base.TurnSpeed * Time.deltaTime);
		base.transform.position += base.transform.up * base.MoveSpeed * num * Time.deltaTime;
		float angle = Mathf.Sin(Time.time) * randomNormalize;
		base.transform.Rotate(Vector3.forward, angle);
		RaycastHit2D[] array = Physics2D.RaycastAll(base.transform.position, base.transform.up, 0.02f, LayerMask.GetMask("Unit", "Enemy"));
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit2D raycastHit2D = array[i];
			if (!(raycastHit2D.collider == null) && raycastHit2D.collider.TryGetComponent<ModuleSlot>(out var component))
			{
				Unit componentInChildren = component.GetComponentInChildren<Unit>();
				if (!componentInChildren || componentInChildren.IsEnemy != base.IsEnemy)
				{
					HitDeath();
				}
			}
		}
	}

	private void HitDeath()
	{
		UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, explosionScale, 0f, 10f);
		silo.OnMissileDeath(this);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		Explosion component = UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>();
		float num = 0f;
		float enemyDamage = 0f;
		if (base.IsEnemy)
		{
			num = 10f;
		}
		else
		{
			enemyDamage = 3f;
		}
		component.Initialize(this, explosionScale, enemyDamage, num);
		silo.OnMissileDeath(this);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public override void EMP(float duration)
	{
	}
}
