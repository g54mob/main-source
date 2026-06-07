using System.Collections;
using UnityEngine;

public class Bubble : Monster
{
	public override void InitStats()
	{
		attackDistance = 0.75f;
	}

	public override IEnumerator Movement()
	{
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		float num = base.speed / 16f;
		base.pos += normalized * num;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	public override IEnumerator Attack()
	{
		yield return Wait(1);
		base.player.Hurt(damage);
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Bubble_Solo, 0.9f, 1.1f, 1f);
		Hurt(health, null, noDeathrattle: true);
	}
}
