using System;
using System.Collections;
using UnityEngine;

public class ImpWeapon : Weapon
{
	private float t;

	private float t2;

	private int dir = 1;

	private float rad = 2f;

	private float initRad = 2.5f;

	private bool init;

	public int attackInterval = 40;

	private int counter;

	public GameObject arrow;

	private float attackSpeed => (float)attackInterval / owner.accelMult;

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	private void ShootArrow()
	{
		if (owner.dungeon.livingEnemies.Count != 0)
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Imp_Fire, 0.9f, 1.1f, 0.6f, 0.7f);
			Monster monster = Utils.RandElem(owner.dungeon.livingEnemies);
			float z = 180f + 180f / MathF.PI * Mathf.Atan2(base.transform.position.y - monster.pos.y, base.transform.position.x - monster.pos.x);
			Projectile component = UnityEngine.Object.Instantiate(arrow).GetComponent<Projectile>();
			component.source = this;
			component.transform.position = base.transform.position;
			component.transform.localEulerAngles = new Vector3(0f, 0f, z);
			component.transform.localScale = base.transform.localScale;
			Vector3 normalized = (monster.transform.position - base.transform.position).normalized;
			owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
			owner.dungeon.animationManager.Fade(component.gameObject, 3, 240);
		}
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			dir = ((!Utils.RNG(50f)) ? 1 : (-1));
			initRad = UnityEngine.Random.Range(1.5f, 3.5f);
			t = UnityEngine.Random.Range(0f, MathF.PI * 2f);
			init = true;
		}
		rad = initRad + 0.35f * Mathf.Sin(t2);
		if (owner.dungeon.livingEnemies.Count > 0)
		{
			counter++;
			if (counter >= (int)attackSpeed)
			{
				counter = 0;
				ShootArrow();
			}
		}
		base.transform.localPosition = rad * new Vector3(Mathf.Cos(t), Mathf.Sin(t));
		t += (float)dir * 0.07f;
		if (t > MathF.PI * 2f)
		{
			t -= MathF.PI * 2f;
		}
		t2 += 0.2f;
		if (t2 > MathF.PI * 2f)
		{
			t2 -= MathF.PI * 2f;
		}
		base.transform.localScale = scale;
	}

	public override IEnumerator Spin()
	{
		Vector3 last = pos;
		while (true)
		{
			float x = base.transform.position.x;
			float x2 = last.x;
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 70f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
