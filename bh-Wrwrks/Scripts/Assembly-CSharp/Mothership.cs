using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : Monster
{
	public enum Ability
	{
		Beam = 0,
		Deathbot = 1,
		Zap = 2,
		_COUNT = 3
	}

	private int dir = 1;

	private bool reached;

	public float accel = 0.01f;

	private float t;

	public float limit = 5f;

	public float range = 1f;

	public GameObject chargeLeft;

	public GameObject chargeRight;

	public float waveAccel = 0.045f;

	private int timer = 10;

	public int attackTime = 120;

	private Ability currAttack = Ability.Zap;

	private bool zapAnim;

	public override void InitStats()
	{
		base.InitStats();
		range += Random.Range(-0.25f, 0.25f);
		limit += Random.Range(-0.5f, 0.5f);
		if (base.dungeon.harderBosses)
		{
			accel *= 1.2f;
			waveAccel *= 1.2f;
		}
		dir = Utils.RandSign();
		if (base.dungeon.state == Dungeon.State.Combat)
		{
			StartCoroutine(SpawnAdds());
		}
		timer = attackTime / 2;
	}

	public override void HitEffect()
	{
	}

	public override IEnumerator Movement()
	{
		if (knockbacking)
		{
			reached = false;
			t = 0f;
			yield break;
		}
		float num = Mathf.Atan2(base.transform.position.y - base.player.transform.position.y, base.transform.position.x - base.player.transform.position.x);
		float num2 = Vector3.Distance(base.transform.position, base.player.transform.position);
		num += (float)dir * accel * speedMult;
		if (reached && num2 >= limit + range)
		{
			reached = false;
			t = 0f;
		}
		if (num2 >= limit && !reached)
		{
			num2 -= base.speed / 16f * 2f;
		}
		else
		{
			reached = true;
		}
		if (reached)
		{
			num2 = limit - range * Mathf.Sin(t);
			t += waveAccel * speedMult;
			if (timer <= 0)
			{
				switch (currAttack)
				{
				case Ability.Beam:
					StartCoroutine(BeamPlayer());
					attackTime = 95;
					break;
				case Ability.Deathbot:
					StartCoroutine(SpawnBot());
					attackTime = 10;
					break;
				case Ability.Zap:
					StartCoroutine(ZapWeapon());
					attackTime = 110;
					break;
				default:
					attackTime = 110;
					break;
				}
				currAttack = (Ability)((int)(currAttack + 1) % 3);
				if (base.dungeon.harderBosses && attackTime > 36)
				{
					attackTime -= 35;
				}
				timer = (int)((float)attackTime * speedMult);
			}
			else
			{
				timer--;
			}
		}
		if (!zapAnim)
		{
			base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		}
		else
		{
			base.spriteRenderer.flipX = false;
		}
		base.transform.position = base.player.transform.position + Utils.Dir(num) * num2;
		yield return Wait(2);
	}

	public IEnumerator ZapWeapon()
	{
		if (base.dungeon.board.GetWeapons().Count == 0)
		{
			yield break;
		}
		zapAnim = true;
		float chargeFrames = (base.dungeon.harderBosses ? 40 : 60);
		float recoverFrames = (base.dungeon.harderBosses ? 15 : 30);
		GameObject charger = chargeLeft;
		GameObject opposite = chargeRight;
		SpriteRenderer component = chargeLeft.GetComponent<SpriteRenderer>();
		Color color = (chargeRight.GetComponent<SpriteRenderer>().color = Utils.GetColor("FFEB57"));
		component.color = color;
		float OA = accel;
		float OW = waveAccel;
		float DA = 0.003f;
		float DW = 0.01f;
		base.dungeon.animationManager.Spin(chargeLeft, -0.2f, (int)chargeFrames + 10);
		base.dungeon.animationManager.Spin(chargeRight, 0.2f, (int)chargeFrames + 10);
		for (float i = 0f; i < chargeFrames; i += 1f)
		{
			if (i == 0f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Shock_Charge, 0.8f);
			}
			if (i == 10f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Shock_Charge, 0.9f);
			}
			if (i == 30f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Shock_Charge);
			}
			accel = Mathf.Lerp(OA, DA, (i + 1f) / chargeFrames);
			waveAccel = Mathf.Lerp(OW, DW, (i + 1f) / chargeFrames);
			charger.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (i + 1f) / chargeFrames);
			opposite.transform.localScale = Vector3.zero;
			yield return Wait(1);
		}
		chargeLeft.transform.localScale = Vector3.zero;
		chargeRight.transform.localScale = Vector3.zero;
		Module target = Utils.RandElem(base.dungeon.board.GetWeapons());
		float xRange = ((target.size == Module.Size.Small) ? 0.75f : 1.5f);
		float yRange = 1.25f;
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Shock);
		target.Zap(base.dungeon.harderBosses ? 240 : 180);
		for (int j = 0; j < 3; j++)
		{
			Vector3 vector = target.transform.position + new Vector3(Random.Range(0f - xRange, xRange), yRange + Random.Range(-0.6f, 0.3f));
			Vector3 item = Vector3.Lerp(charger.transform.position, vector, 0.5f);
			Vector3 vector2 = target.transform.position + new Vector3(Random.Range(0f - xRange, xRange), 0f - yRange + Random.Range(-0.3f, 0.6f));
			Vector3 item2 = Vector3.Lerp(charger.transform.position, vector2, 0.5f);
			List<Vector3> points = new List<Vector3>
			{
				charger.transform.position,
				item,
				vector
			};
			List<Vector3> points2 = new List<Vector3>
			{
				charger.transform.position,
				item2,
				vector2
			};
			base.dungeon.animationManager.CreateLightning(points, "FFEB57", silent: true, unmasked: true);
			base.dungeon.animationManager.CreateLightning(points2, "FFEB57", silent: true, unmasked: true);
			base.dungeon.animationManager.CreateGibs("FFEB57", vector, 5f, 0.1f, unmasked: true);
			base.dungeon.animationManager.CreateGibs("FFEB57", vector2, 5f, 0.1f, unmasked: true);
			base.dungeon.animationManager.Screenshake();
			yield return Dungeon.Wait(5);
		}
		zapAnim = false;
		for (float i = 0f; i < recoverFrames; i += 1f)
		{
			accel = Mathf.Lerp(DA, OA, (i + 1f) / recoverFrames);
			waveAccel = Mathf.Lerp(DW, OW, (i + 1f) / recoverFrames);
			yield return Wait(1);
		}
		accel = OA;
		waveAccel = OW;
	}

	public IEnumerator BeamPlayer()
	{
		float chargeFrames = (base.dungeon.harderBosses ? 40 : 60);
		float recoverFrames = (base.dungeon.harderBosses ? 15 : 30);
		GameObject charger = chargeLeft;
		SpriteRenderer component = chargeLeft.GetComponent<SpriteRenderer>();
		Color color = (chargeRight.GetComponent<SpriteRenderer>().color = Utils.GetColor("EA323C"));
		component.color = color;
		float OA = accel;
		float OW = waveAccel;
		float DA = 0.003f;
		float DW = 0.01f;
		base.dungeon.animationManager.Spin(chargeLeft, -0.2f, (int)chargeFrames + 10);
		base.dungeon.animationManager.Spin(chargeRight, 0.2f, (int)chargeFrames + 10);
		for (float i = 0f; i < chargeFrames; i += 1f)
		{
			if (i == 0f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Laser_Charge, 2f);
			}
			if (i == 10f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Laser_Charge, 2f);
			}
			if (i == 20f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Laser_Charge, 2f);
			}
			if (i == chargeFrames / 2f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Laser_Charge, 2f);
			}
			accel = Mathf.Lerp(OA, DA, (i + 1f) / chargeFrames);
			waveAccel = Mathf.Lerp(OW, DW, (i + 1f) / chargeFrames);
			charger = ((base.transform.position.x < base.player.pos.x) ? chargeRight : chargeLeft);
			GameObject obj = ((base.transform.position.x < base.player.pos.x) ? chargeLeft : chargeRight);
			charger.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (i + 1f) / chargeFrames);
			obj.transform.localScale = Vector3.zero;
			yield return Wait(1);
		}
		chargeLeft.transform.localScale = Vector3.zero;
		chargeRight.transform.localScale = Vector3.zero;
		List<Vector3> points = new List<Vector3>
		{
			charger.transform.position,
			base.player.pos
		};
		base.dungeon.animationManager.CreateLaser(points, "EA323C", 0.25f);
		base.dungeon.animationManager.CreateDust(base.player.pos, "EA323C", 5, 0.65f);
		base.dungeon.player.Hurt(damage);
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser);
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser, 1.5f);
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser, 0.5f);
		for (float i = 0f; i < recoverFrames; i += 1f)
		{
			accel = Mathf.Lerp(DA, OA, (i + 1f) / recoverFrames);
			waveAccel = Mathf.Lerp(DW, OW, (i + 1f) / recoverFrames);
			yield return Wait(1);
		}
		accel = OA;
		waveAccel = OW;
	}

	public IEnumerator SpawnBot()
	{
		Bot component = base.dungeon.SpawnMonster(Type.Deathbot).GetComponent<Bot>();
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Robot_Mechanism);
		component.dir = -dir;
		component.transform.position = base.transform.position + new Vector3(0f, -0.75f);
		yield return null;
	}

	public IEnumerator SpawnAdds()
	{
		int i = 0;
		while (true)
		{
			yield return Wait(11);
			int num = Random.Range(0, 5);
			i++;
			if (i == 120)
			{
				i = 0;
				num = 6;
			}
			switch (num)
			{
			case 0:
				base.dungeon.SpawnMonster(Type.Rocket);
				yield return Wait(5);
				base.dungeon.SpawnMonster(Type.Rocket_Soldier);
				break;
			case 1:
				base.dungeon.SpawnMonster(Type.UFO);
				yield return Wait(5);
				base.dungeon.SpawnMonster(Type.UFO_Soldier);
				break;
			case 2:
				base.dungeon.SpawnMonster(Type.Asteroid_L);
				break;
			case 3:
				base.dungeon.SpawnMonster(Type.Drill);
				break;
			case 4:
				base.dungeon.SpawnMonster(Type.Asteroid_M0);
				yield return Wait(5);
				base.dungeon.SpawnMonster(Type.Asteroid_M1);
				break;
			case 6:
				base.dungeon.SpawnMonster(Type.Charger);
				break;
			}
		}
	}

	private void Ender()
	{
		StopAllCoroutines();
		StartCoroutine(DeathAnim());
	}

	public override IEnumerator Death()
	{
		GetComponent<Collider2D>().enabled = false;
		Ender();
		yield return null;
	}

	private void FlashSprite()
	{
		StartCoroutine(Flash());
	}

	private IEnumerator Flash()
	{
		base.spriteRenderer.material = base.dungeon.shadowMat;
		yield return Dungeon.Wait(10);
		base.spriteRenderer.material = default_mat;
	}

	public IEnumerator DeathAnim()
	{
		health = 0;
		int shakes = 0;
		int i = 0;
		int d = 1;
		float pitch = 0.85f;
		float s = 0.4f;
		float r = 1f;
		int c = 4;
		while (true)
		{
			if (i % 10 == 0)
			{
				FlashSprite();
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion, pitch, 0.8f);
				pitch -= 0.05f;
				base.transform.localScale += Vector3.one * -1f / 30f;
				r -= 0.05f;
				s *= 29f / 30f;
				for (int x = 0; x < 5; x++)
				{
					base.dungeon.animationManager.CreateDust(base.transform.position + Utils.RandDir(), "EA323C", c, s);
					base.dungeon.animationManager.CreateDust(base.transform.position + Utils.RandDir(), "ED7614", c, s);
					base.dungeon.animationManager.CreateDust(base.transform.position + Utils.RandDir(), "FFC825", c, s);
					base.transform.position += new Vector3(0f, 1f) * d * 3f / 16f;
					d *= -1;
					base.dungeon.animationManager.Screenshake(-1f, -1f, 2);
					yield return Wait(1);
				}
				shakes++;
				if (shakes % 3 == 0)
				{
					c--;
				}
				foreach (Monster item in new List<Monster>(base.dungeon.livingEnemies))
				{
					item.Hurt(5);
				}
			}
			i++;
			if (shakes == 10)
			{
				break;
			}
			yield return Wait(1);
		}
		base.dungeon.livingEnemies.Remove(this);
		yield return base.dungeon.animationManager.LerpZoom(base.gameObject, Vector3.zero, 5f);
		yield return Dungeon.Wait(20);
		Object.Destroy(base.gameObject);
		yield return Wait(1);
	}
}
