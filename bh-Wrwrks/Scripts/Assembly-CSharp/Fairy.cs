using System;
using System.Collections;
using UnityEngine;

public class Fairy : Weapon
{
	public Monster target;

	private Vector3 center = Vector3.zero;

	private float rad = 1f;

	private float t;

	private bool relock;

	public override void CastSpell()
	{
		Projectile projectile = base.animationManager.CreateCircleEffect(base.transform.position, "FDD2ED", Vector3.one);
		projectile.transform.localPosition = base.transform.position;
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Explosion_Fairy, 0.9f, 1.1f, 1f);
		projectile.debuff = Monster.Debuff.Stun;
		projectile.source = this;
		projectile.debuffValue = 1f;
	}

	public override void ProcessFrame()
	{
		if (base.dungeon.livingEnemies.Count == 0)
		{
			target = null;
		}
		else
		{
			target = base.dungeon.livingEnemies[0];
			relock = true;
		}
		if (target == null)
		{
			center = base.dungeon.player.transform.position;
			rad = 1.5f;
		}
		else
		{
			center = target.transform.position;
			rad = 1f;
		}
		Vector3 b = center + rad * new Vector3(Mathf.Cos(t), Mathf.Sin(t));
		t += 0.03f * owner.accelMult;
		if (t > MathF.PI * 2f)
		{
			t -= MathF.PI * 2f;
		}
		if (Vector3.Distance(base.transform.position, center) > rad && relock)
		{
			base.transform.position += (center - base.transform.position).normalized * 0.1f * owner.accelMult;
			return;
		}
		base.transform.position = Vector3.Lerp(base.transform.position, b, 0.1f * owner.accelMult);
		relock = false;
	}

	public override IEnumerator Spin()
	{
		return base.Spin();
	}
}
