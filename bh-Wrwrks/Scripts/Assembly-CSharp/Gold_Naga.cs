using System.Collections;
using UnityEngine;

public class Gold_Naga : Monster
{
	private int side = 1;

	private float t;

	private float oy;

	public override void InitPosition(float presetAngle = -1f)
	{
		float num = Utils.RandSign(8.9f);
		side = -(int)Mathf.Sign(num);
		base.pos = base.player.transform.position + new Vector3(num, Utils.RandSign(Random.Range(4.25f, 4.75f)));
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		oy = base.pos.y;
	}

	public override IEnumerator Movement()
	{
		float x = base.speed / 16f;
		base.pos += side * new Vector3(x, 0f);
		base.pos = new Vector3(base.pos.x, oy + 0.5f * Mathf.Sin(t));
		t += 0.1f;
		if (Mathf.Abs(base.transform.position.x - base.player.transform.position.x) > 9f)
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
