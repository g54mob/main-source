using System;
using System.Collections;
using UnityEngine;

public class Beehive : Weapon
{
	public GameObject bee;

	private bool init;

	private int i;

	private float t;

	private Vector3 p;

	private int attackRate => (int)((float)(owner.UPGRADED ? 20 : 30) / owner.accelMult);

	public override void KillTrigger(Monster monster)
	{
		owner.counter++;
		owner.TriggerBounce();
		if (owner.counter % 20 == 0)
		{
			Module module = base.dungeon.board.CreateModuleSmall(Module.Name.Honey);
			if (base.UPGRADED)
			{
				base.dungeon.board.UpgradeModule(module, silent: true, load: false, module.bankItem);
			}
		}
	}

	public override void ProjectileHit(Monster monster)
	{
		if (monster.health <= 0)
		{
			KillTrigger(monster);
		}
		base.ProjectileHit(monster);
	}

	private void SpawnBee()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(bee);
		gameObject.transform.position = base.transform.position;
		gameObject.transform.localScale = Vector3.zero;
		gameObject.GetComponent<ScytheSpirit>().source = this;
		gameObject.GetComponent<ScytheSpirit>().forceDamage = base.damage;
		gameObject.GetComponent<ScytheSpirit>().transform.localScale = base.transform.localScale;
		gameObject.GetComponent<ScytheSpirit>().speed = 0.125f * owner.accelMult;
		gameObject.GetComponent<ScytheSpirit>().StartCoroutine(gameObject.GetComponent<ScytheSpirit>().Seeker());
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			init = true;
			p = Utils.RandDir() * 1.5f;
		}
		base.transform.localPosition = p + new Vector3(0f, Mathf.Sin(t)) * 2f / 16f;
		t += 0.025f;
		if (t >= MathF.PI * 2f)
		{
			t = 0f;
		}
		if (base.dungeon.livingEnemies.Count != 0)
		{
			if (i >= attackRate)
			{
				SpawnBee();
				i = 0;
			}
			i++;
		}
	}

	public override IEnumerator Spin()
	{
		base.transform.localPosition = Utils.RandDir() * 1.5f;
		yield break;
	}
}
