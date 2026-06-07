using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone : Weapon
{
	private enum Effect
	{
		Slow = 0,
		Stun = 1,
		Knockback = 2,
		Lightning = 3,
		Rocket = 4,
		Toxic = 5,
		Cash = 6,
		Heal = 7,
		Hurt = 8,
		Oil = 9,
		_COUNT = 10
	}

	public GameObject rocket;

	public GameObject healProjectile;

	private int pSpeed = 15;

	public override void CastSpell()
	{
		Invoke(((Effect)UnityEngine.Random.Range(0, 10)/*cast due to .constrained prefix*/).ToString(), 0f);
	}

	public void Slow()
	{
		if (base.dungeon.livingEnemies.Count != 0)
		{
			Projectile projectile = base.dungeon.animationManager.CreateExplosion("0CF1FF", "00CDF9", 10, insta: true);
			projectile.source = this;
			Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Explosion_Ice, 0.9f, 1.1f, 1f);
			projectile.transform.position = base.transform.position;
			projectile.transform.localScale = base.transform.localScale;
			projectile.debuff = Monster.Debuff.Slow;
			projectile.debuffValue = (base.UPGRADED ? 120 : 60);
			projectile.transform.localScale = Vector3.one * 1f;
		}
	}

	public void Stun()
	{
		Projectile projectile = base.animationManager.CreateCircleEffect(base.transform.position, "FDD2ED", base.UPGRADED ? (Vector3.one * 1.33333f) : Vector3.one);
		projectile.transform.localPosition = base.transform.position;
		projectile.transform.localPosition = base.transform.position;
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Explosion_Fairy, 0.9f, 1.1f, 1f);
		projectile.transform.localScale = base.transform.localScale;
		projectile.debuff = Monster.Debuff.Stun;
		projectile.source = this;
		projectile.debuffValue = (base.UPGRADED ? 1.5f : 1f);
	}

	public void Knockback()
	{
		Projectile projectile = base.animationManager.CreateCircleEffect(base.transform.position, "C7CFDD", Vector3.one * 1.3333f);
		projectile.transform.localPosition = base.transform.position;
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Bash, 0.9f, 1.1f, 1f);
		projectile.debuff = Monster.Debuff.Knockback;
		projectile.source = this;
		projectile.debuffValue = (base.UPGRADED ? 0.8f : 0.45f);
	}

	public void Lightning()
	{
		Trigger trigger = new Trigger(Trigger.Ability.Collar, owner);
		trigger.source = null;
		trigger.damage = base.damage + 1;
		trigger.ActivateTrigger(this, null, Trigger.Type.Force, owner);
	}

	public void Rocket()
	{
		if (owner.dungeon.livingEnemies.Count == 0)
		{
			return;
		}
		Monster closestMonster = base.dungeon.GetClosestMonster(base.transform.position);
		if (!(closestMonster == null))
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Rocket, 1f, 1.15f, 1f);
			float z = 180f + 180f / MathF.PI * Mathf.Atan2(base.transform.position.y - closestMonster.pos.y, base.transform.position.x - closestMonster.pos.x);
			Drone_Proj component = UnityEngine.Object.Instantiate(rocket).GetComponent<Drone_Proj>();
			component.source = this;
			component.forceDamage = base.damage * 2;
			component.transform.position = base.transform.position;
			component.transform.localEulerAngles = new Vector3(0f, 0f, z);
			component.sharedWeapon = true;
			component.transform.localScale = base.transform.localScale;
			if (owner.UPGRADED)
			{
				component.transform.localScale += Vector3.one * 0.3f;
			}
			Vector3 normalized = (closestMonster.transform.position - base.transform.position).normalized;
			owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
			owner.dungeon.animationManager.Fade(component.gameObject, 3, 240);
		}
	}

	public void Toxic()
	{
		int duration = (owner.UPGRADED ? 150 : 90);
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Potion);
		Projectile projectile = owner.dungeon.animationManager.CreateExplosion("33984B", "5AC54F", duration, insta: false, ticks: true);
		projectile.source = this;
		projectile.transform.position = base.transform.position;
	}

	public void Cash()
	{
		base.dungeon.GetBonusCash(1, base.transform.position);
	}

	public void Heal()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(healProjectile);
		owner.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Heal, 0.9f, 1.1f, 1f);
		gameObject.transform.position = base.transform.position;
		base.dungeon.animationManager.LerpTo(gameObject, base.dungeon.player.transform.position, pSpeed, 0f, slerp: true, destroy: true);
		base.dungeon.animationManager.Spin(gameObject, 10f);
		StartCoroutine(HealDelay());
	}

	private IEnumerator HealDelay()
	{
		yield return Dungeon.Wait(pSpeed);
		base.dungeon.player.Heal(owner.UPGRADED ? 4 : 2);
	}

	public void Hurt()
	{
		LightningEffect component = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.LightningEffect).GetComponent<LightningEffect>();
		List<Vector3> oP = new List<Vector3>
		{
			base.transform.position,
			base.player.transform.position
		};
		component.SetPoints(oP, "F5555D");
		base.player.Hurt(base.UPGRADED ? 6 : 3);
	}

	public void Oil()
	{
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Barrel_Splash);
		Projectile projectile = owner.dungeon.animationManager.CreateExplosion("657392", "424C6E", 10, insta: true);
		projectile.source = this;
		projectile.sharedWeapon = true;
		projectile.transform.position = base.transform.position;
		projectile.debuff = Monster.Debuff.Oil;
		projectile.debuffValue = (owner.UPGRADED ? 60 : 120);
	}
}
