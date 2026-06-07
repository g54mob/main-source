using System.Collections;
using UnityEngine;

public class Skull : Monster
{
	private float radius = 2.75f;

	private float windup = 0.25f;

	public override void InitStats()
	{
		attackDistance = radius;
	}

	public override IEnumerator Attack()
	{
		Vector3 dir = (base.player.transform.position - base.transform.position).normalized;
		yield return base.dungeon.animationManager.LerpTo(base.gameObject, base.pos - dir * windup, (int)(30f / speedMult));
		base.dungeon.animationManager.LerpTo(base.gameObject, base.pos + dir * (radius * 2f + windup), (int)(10f / speedMult));
		yield return Wait(5);
		base.player.Hurt(damage);
		yield return Wait(5);
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		_ = (base.player.transform.position - base.transform.position).normalized;
		yield return Wait(90);
	}
}
