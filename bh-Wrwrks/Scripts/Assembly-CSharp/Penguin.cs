using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : Weapon
{
	public List<Sprite> idle;

	public Sprite windup;

	public Sprite windup2;

	public List<Sprite> slide;

	public bool set;

	public bool locked;

	private Vector3 target = Vector3.zero;

	private Vector3 lingerTarget = Vector3.zero;

	public Monster targetMonster;

	private float maxDist;

	public bool hit;

	public int linger;

	private int stand;

	private Animator anim => GetComponent<Animator>();

	private float speed => 0.125f * owner.accelMult;

	public override void HitTrigger(Monster monster)
	{
		if (monster == targetMonster)
		{
			linger = 30;
			lingerTarget = base.transform.position + 5f * (monster.transform.position - base.transform.position).normalized;
			hit = true;
			if (owner.UPGRADED)
			{
				Projectile projectile = base.dungeon.animationManager.CreateExplosion("0CF1FF", "00CDF9", 10, insta: true);
				projectile.source = this;
				projectile.forceDamage = 3;
				projectile.transform.position = base.transform.position;
				projectile.debuff = Monster.Debuff.Slow;
				projectile.debuffValue = 120f;
				projectile.transform.localScale = base.transform.localScale;
				base.animationManager.BounceZoom(base.gameObject, 0.2f, 4);
			}
		}
		monster.ApplyDebuff(Monster.Debuff.Slow, 120f);
	}

	public override void ProcessFrame()
	{
		_ = speed;
		float num = 1f;
		if (base.dungeon.livingEnemies.Count == 0)
		{
			if (!set)
			{
				num = 0.5f;
				linger = 0;
				anim.CustomAnim(idle, 4f);
				set = true;
				target = base.player.pos + Utils.RandDir() * 1f;
				locked = false;
			}
		}
		else if (!locked)
		{
			Monster monster = Utils.RandElem(base.dungeon.livingEnemies);
			target = monster.pos;
			maxDist = 1.5f + Vector3.Distance(monster.pos, base.transform.position);
			StartCoroutine(slideAnim());
			targetMonster = monster;
			hit = false;
			locked = true;
			num = 1f;
			stand = 9;
		}
		else
		{
			if (stand > 0)
			{
				stand--;
				return;
			}
			if (linger > 0)
			{
				num *= 0.95f;
				linger--;
			}
			Vector3.Distance(target, base.transform.position);
			if (hit)
			{
				if (linger > 0)
				{
					num *= 0.95f;
				}
				else
				{
					locked = false;
				}
			}
			if (targetMonster != null && linger == 0)
			{
				target = targetMonster.transform.position;
				num *= 0.95f;
			}
			if (targetMonster == null && linger == 0)
			{
				locked = false;
			}
		}
		if (!(Vector3.Distance((linger > 0) ? lingerTarget : target, base.transform.position) < 0.1f))
		{
			base.transform.position += speed * num * (((linger > 0) ? lingerTarget : target) - base.transform.position).normalized;
		}
	}

	private IEnumerator slideAnim()
	{
		anim.StopAnim();
		set = false;
		SpriteRenderer s = GetComponent<SpriteRenderer>();
		s.sprite = windup;
		yield return Dungeon.Wait(4);
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Penguin, 0.9f, 1.1f, 1f);
		s.sprite = windup2;
		yield return Dungeon.Wait(4);
		anim.CustomAnim(slide, 2f);
	}

	public override IEnumerator Spin()
	{
		Vector3 last = base.transform.position;
		while (true)
		{
			float x = base.transform.position.x;
			float x2 = last.x;
			if (x != x2)
			{
				GetComponent<SpriteRenderer>().flipX = x < x2;
			}
			last = base.transform.position;
			yield return null;
		}
	}
}
