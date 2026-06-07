using System.Collections;
using UnityEngine;

public class Naga : Monster
{
	private float rad = 9f;

	private float angle;

	private float t;

	public override void InitPosition(float presetAngle = -1f)
	{
		base.InitPosition(presetAngle);
		rad = Vector3.Distance(base.pos, base.player.pos);
		angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
	}

	public override IEnumerator Movement()
	{
		if (knockbacking)
		{
			t = 0f;
			rad = Vector3.Distance(base.pos, base.player.pos);
			angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
			yield break;
		}
		float num = base.speed / 16f;
		rad -= num;
		base.transform.position = rad * new Vector3(Mathf.Cos(angle + t), Mathf.Sin(angle + t)) + base.player.pos;
		t += 0.01f * speedMult;
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}
}
