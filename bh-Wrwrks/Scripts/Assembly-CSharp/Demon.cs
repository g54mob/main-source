using System;
using System.Collections;
using UnityEngine;

public class Demon : Weapon
{
	private float t;

	private float t2;

	private int dir = 1;

	private float rad = 2f;

	private float initRad = 2.5f;

	private bool init;

	private int attackInterval = 60;

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
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Imp_Fire, 0.9f, 1.1f, 1f);
			Monster monster = Utils.RandElem(owner.dungeon.livingEnemies);
			float num = 10f;
			int num2 = 5;
			float num3 = 180f / MathF.PI * Mathf.Atan2(monster.transform.position.y - base.transform.position.y, monster.transform.position.x - base.transform.position.x);
			num3 += 0f - (num / 4f - num + num / (float)(num2 - 2) * (float)(num2 / 2));
			for (int i = 0; i < num2; i++)
			{
				Projectile component = UnityEngine.Object.Instantiate(arrow).GetComponent<Projectile>();
				component.source = this;
				component.transform.position = base.transform.position;
				component.transform.localScale = base.transform.localScale;
				float num4 = (num3 + num / 4f - num + num / (float)(num2 - 2) * (float)i) * MathF.PI / 180f;
				Vector3 normalized = (base.transform.position + new Vector3(Mathf.Cos(num4), Mathf.Sin(num4)) - base.transform.position).normalized;
				float num5 = 0.15f;
				num5 *= (float)Mathf.Abs(num2 / 2 - i);
				component.transform.position = base.transform.position + (0f - num5) * normalized;
				owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
				component.transform.localEulerAngles = new Vector3(0f, 0f, num4 * 180f / MathF.PI);
				owner.dungeon.animationManager.Fade(component.gameObject, 3, 240);
			}
		}
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			dir = ((!Utils.RNG(50f)) ? 1 : (-1));
			initRad = UnityEngine.Random.Range(1.5f, 3.5f);
			init = true;
			t = UnityEngine.Random.Range(0f, MathF.PI * 2f);
			counter = (int)attackSpeed;
		}
		rad = initRad + 0.25f * Mathf.Sin(t2);
		if (owner.dungeon.livingEnemies.Count > 0)
		{
			counter--;
			if (counter == 0)
			{
				counter = (int)attackSpeed;
				ShootArrow();
			}
		}
		base.transform.localPosition = rad * new Vector3(Mathf.Cos(t), Mathf.Sin(t));
		t += (float)dir * 0.04f;
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
