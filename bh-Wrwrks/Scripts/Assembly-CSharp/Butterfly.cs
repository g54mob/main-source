using System;
using System.Collections;
using UnityEngine;

public class Butterfly : Weapon
{
	private float t;

	private int dir = 1;

	private bool init;

	private float a = 3f;

	private float b = 1.825f;

	private float rad = 1.25f;

	public GameObject projectile;

	private int attackInterval = 60;

	private int pSpeed = 15;

	private int i;

	public void ShootProjectile()
	{
		if (base.dungeon.combat)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(projectile);
			owner.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Heal, 0.9f, 1.1f, 0.4f, 0.4f);
			gameObject.transform.position = base.transform.position;
			base.dungeon.animationManager.LerpTo(gameObject, base.dungeon.player.transform.position, pSpeed, 0f, slerp: true, destroy: true);
			base.dungeon.animationManager.Spin(gameObject, 10f);
			StartCoroutine(HealDelay());
		}
	}

	private IEnumerator HealDelay()
	{
		yield return Dungeon.Wait(pSpeed);
		base.dungeon.player.Heal((!owner.UPGRADED) ? 1 : 3);
	}

	public override void ProcessFrame()
	{
		owner.counter = ((!owner.UPGRADED) ? 1 : 2);
		if (!init)
		{
			i = (int)((float)attackInterval / owner.accelMult);
			a += UnityEngine.Random.Range(-0.1f, 0.1f);
			b += UnityEngine.Random.Range(-0.1f, 0.1f);
			rad += UnityEngine.Random.Range(-0.1f, 0.1f);
			t = UnityEngine.Random.Range(0f, MathF.PI * 2f);
			init = true;
		}
		i--;
		if (i == 0)
		{
			ShootProjectile();
			i = (int)((float)attackInterval / owner.accelMult);
		}
		base.transform.localPosition = 1.25f * new Vector3(Mathf.Cos(t) * a, b * Mathf.Sin(t));
		t += (float)dir * 0.05f * owner.accelMult;
		if (t > MathF.PI * 2f)
		{
			t -= MathF.PI * 2f;
		}
		GetComponent<SpriteRenderer>().flipX = (float)dir * base.transform.localPosition.y > 0f;
	}
}
