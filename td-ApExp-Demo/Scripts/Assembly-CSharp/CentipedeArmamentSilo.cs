using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CentipedeArmamentSilo : CentipedeArmament
{
	[SerializeField]
	private Transform missileSpawn;

	private List<EnemyBase> missiles;

	private new void Awake()
	{
		base.Awake();
		missiles = new List<EnemyBase>();
	}

	public override void Aim()
	{
	}

	public override void Fire()
	{
		CentipedeMissile component = Object.Instantiate(spawnPrefab, missileSpawn.position, base.transform.parent.rotation, base.transform).GetComponent<CentipedeMissile>();
		component.IsEnemy = true;
		missiles.Add(component);
		component.silo = this;
		component.lifetime = 10f;
		component.parentEnemy = base.transform.parent.GetComponent<Unit>();
		if (!component.IsEnemy)
		{
			component.TargetUnit = (from e in EnemyManager.Instance.Enemies
				where e.IsEnemy && e.GetComponent<APCMissile>() == null && e.gameObject != base.transform.parent
				orderby (e.transform.position - base.transform.position).sqrMagnitude
				select e).FirstOrDefault();
		}
		base.Anim.Play("Launch", 0, 0f);
	}

	public override void OnSegmentFactionChanged()
	{
		base.OnSegmentFactionChanged();
		foreach (EnemyBase missile in missiles)
		{
			missile.IsEnemy = enemyCentipede.IsEnemy;
		}
	}

	public void OnMissileDeath(EnemyBase deadMissile)
	{
		missiles.Remove(deadMissile);
	}
}
