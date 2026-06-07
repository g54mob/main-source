using System;
using System.Collections;
using UnityEngine;

public class Drone : Weapon
{
	private float t;

	private float maxT = 2f;

	private bool init;

	public GameObject proj;

	private float attackInterval = 40f;

	private int counter;

	private int x;

	private float amp = 2f;

	private float ang;

	private float attackSpeed => attackInterval / owner.accelMult;

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	private void ShootArrow(Monster m)
	{
		if (owner.dungeon.livingEnemies.Count != 0 && !(m == null))
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Rocket, 1f, 1.15f, 1f);
			float z = 180f + 180f / MathF.PI * Mathf.Atan2(base.transform.position.y - m.pos.y, base.transform.position.x - m.pos.x);
			Drone_Proj component = UnityEngine.Object.Instantiate(proj).GetComponent<Drone_Proj>();
			component.source = this;
			component.transform.position = base.transform.position;
			component.transform.localEulerAngles = new Vector3(0f, 0f, z);
			component.sharedWeapon = true;
			component.transform.localScale = base.transform.localScale;
			if (owner.UPGRADED)
			{
				component.transform.localScale += Vector3.one * 0.3f;
			}
			Vector3 normalized = (m.transform.position - base.transform.position).normalized;
			owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
			owner.dungeon.animationManager.Fade(component.gameObject, 3, 240);
		}
	}

	private IEnumerator motion()
	{
		while (true)
		{
			t += 0.045f;
			if (t >= maxT)
			{
				t = 0f;
				x++;
				if (x == 3)
				{
					x = 0;
				}
			}
			yield return Dungeon.Wait(1);
		}
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			amp = UnityEngine.Random.Range(3f, 3.2f);
			ang = UnityEngine.Random.Range(0, 90);
			init = true;
			StartCoroutine(motion());
		}
		if (owner.dungeon.livingEnemies.Count > 0)
		{
			counter++;
			Monster monster = null;
			foreach (Monster livingEnemy in owner.dungeon.livingEnemies)
			{
				if (Vector3.Distance(base.transform.position, livingEnemy.transform.position) < 5f)
				{
					monster = livingEnemy;
					break;
				}
			}
			if (counter >= (int)attackSpeed && monster != null)
			{
				counter = 0;
				ShootArrow(monster);
			}
		}
		float num = (ang - 180f) * MathF.PI / 180f;
		Vector3 vector = amp * new Vector3(Mathf.Cos(num), Mathf.Sin(num));
		Vector3 vector2 = amp * new Vector3(Mathf.Cos(num + MathF.PI * 2f / 3f), Mathf.Sin(num + MathF.PI * 2f / 3f));
		Vector3 vector3 = amp * new Vector3(Mathf.Cos(num + 4.1887903f), Mathf.Sin(num + 4.1887903f));
		Vector3 vector4 = vector;
		float num2 = t / maxT;
		switch (x)
		{
		case 0:
			vector4 = Vector3.Lerp(vector, vector2, num2);
			break;
		case 1:
			vector4 = Vector3.Lerp(vector2, vector3, num2);
			break;
		case 2:
			vector4 = Vector3.Lerp(vector3, vector, num2);
			break;
		}
		if (noInput)
		{
			pos = Vector3.zero;
		}
		base.transform.localPosition = vector4 + pos;
	}
}
