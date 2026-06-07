using System.Collections;
using UnityEngine;

public class Gold_UFO : Monster
{
	private int side = 1;

	public override void InitPosition(float presetAngle = -1f)
	{
		float num = Utils.RandSign(8.9f);
		side = -(int)Mathf.Sign(num);
		base.pos = base.player.transform.position + new Vector3(Utils.RandSign(Random.Range(4.75f, 5.75f)), num);
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
	}

	public override IEnumerator Movement()
	{
		float y = base.speed / 16f;
		base.pos += side * new Vector3(0f, y);
		if (Mathf.Abs(base.transform.position.y - base.player.transform.position.y) > 9f)
		{
			Hurt(health, null, noDeathrattle: true);
		}
		else
		{
			yield return Wait(2);
		}
	}

	public override void DeathEffect()
	{
		base.dungeon.GetBonusCash(5, base.transform.position + new Vector3(Utils.RandSign(0.1875f), 0.625f));
		base.DeathEffect();
	}
}
