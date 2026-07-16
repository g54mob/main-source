using System;
using System.Collections;
using UnityEngine;

public class E2_B_GarbageThrower : EnemyComponent
{
	[SerializeField]
	private int ID;

	[SerializeField]
	public E2_B_BossAController boss;

	[SerializeField]
	private Transform muzzleTf;

	public event Action OnGarbageThrown;

	public void ThrowGarbage()
	{
		ProjectileGarbage component = UnityEngine.Object.Instantiate(bullet, muzzleTf.position, muzzleTf.rotation).GetComponent<ProjectileGarbage>();
		component.sourceUnit = boss;
		component.isEnemyProjectile = base.IsEnemy;
		component.thrower = this;
		component.SetTarget(base.TargetUnit);
		component.speed = projSpeed;
		component.damage = boss.turretDamage;
		component.trainDamage = boss.turretDamage;
		soundBuilder.Play(shootSound);
		component.ProjectileHit += boss.OnTargetDamaged;
		CombatManager.Instance.RegisterProjectile(component);
		StartCoroutine(SwitchTarget());
	}

	private IEnumerator SwitchTarget()
	{
		yield return new WaitForSeconds(0.5f);
		if (ID == 0)
		{
			boss.Target1();
		}
		else
		{
			boss.Target2();
		}
	}

	public override void EMP(float duration)
	{
	}

	public override void OnEMPEnd()
	{
	}

	public new void Burn(bool burn)
	{
		if ((bool)base.Anim)
		{
			if (burn)
			{
				base.Anim.Play("Thrower_Burning");
			}
			else
			{
				base.Anim.Play("Thrower_Idle");
			}
		}
	}

	public void Explode()
	{
		soundBuilder.Play(deathSFX);
		GetComponent<ExplodeSprite>().Explode();
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
