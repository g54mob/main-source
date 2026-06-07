using System.Collections;
using UnityEngine;

public class Wizard : Monster
{
	public Sprite fireSprite;

	public GameObject projectile;

	public override void InitStats()
	{
		attackDistance = 2.5f;
	}

	public override IEnumerator Movement()
	{
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		if (base.pos.x < base.player.pos.x)
		{
			base.spriteRenderer.flipX = true;
		}
		float num = base.speed / 16f;
		base.pos += normalized * num;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	public override IEnumerator Attack()
	{
		yield return Wait(20);
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		base.animator.StopAnim();
		base.spriteRenderer.sprite = fireSprite;
		ShootProjectile(projectile, 15, normalized);
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Wizard_Shoot, 0.75f, 0.9f);
		yield return Wait(7);
		base.animator.StartAnim();
		yield return Wait(8);
		yield return Wait(50);
	}
}
