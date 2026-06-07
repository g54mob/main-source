using System.Collections;
using UnityEngine;

public class Fishbones : Monster
{
	public float radius;

	public float windup;

	public int windupFrames;

	public int attackFrames;

	public int waitFrames;

	public override void InitStats()
	{
		attackDistance = radius;
	}

	public override IEnumerator Attack()
	{
		Vector3 dir = (base.player.transform.position - base.transform.position).normalized;
		yield return base.dungeon.animationManager.LerpTo(base.gameObject, base.pos - dir * windup, (int)((float)windupFrames / speedMult));
		base.dungeon.animationManager.LerpTo(base.gameObject, base.pos + dir * (radius * 2f + windup), (int)((float)attackFrames / speedMult));
		yield return Wait(attackFrames / 2);
		base.player.Hurt(damage);
		yield return Wait(attackFrames / 2);
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		_ = (base.player.transform.position - base.transform.position).normalized;
		yield return Wait(waitFrames);
	}
}
