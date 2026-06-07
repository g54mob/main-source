using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Monster
{
	public int dir = 1;

	public float accel = 0.005f;

	public string zapColor = "EA323C";

	public override void InitStats()
	{
		attackDistance = 2f;
	}

	public override void HitEffect()
	{
	}

	public override IEnumerator Movement()
	{
		if (!knockbacking)
		{
			float num = Mathf.Atan2(base.transform.position.y - base.player.transform.position.y, base.transform.position.x - base.player.transform.position.x);
			float num2 = Vector3.Distance(base.transform.position, base.player.transform.position);
			num += (float)dir * accel * speedMult;
			num2 -= base.speed / 16f;
			base.transform.position = base.player.transform.position + Utils.Dir(num) * num2;
			yield return Wait(2);
		}
	}

	public override IEnumerator Attack()
	{
		base.player.Hurt(damage);
		Vector3 dir = (base.player.transform.position - base.transform.position).normalized;
		float dist = 0.25f;
		base.transform.position += (0f - dist) * dir;
		Dungeon.Instance.InstantiateExternal(Dungeon.Instance.LightningEffect).GetComponent<LightningEffect>().SetPoints(new List<Vector3>
		{
			base.transform.position,
			base.player.pos
		}, zapColor);
		float frames = 40f;
		for (float i = 0f; i < frames; i += 1f)
		{
			base.transform.position += dist / frames * dir;
			yield return Wait(1);
		}
	}
}
