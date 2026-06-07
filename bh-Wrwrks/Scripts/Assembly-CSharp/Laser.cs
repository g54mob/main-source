using System;
using System.Collections;
using UnityEngine;

public class Laser : Weapon
{
	public override void ProcessFrame()
	{
		Vector3 normalized = pos.normalized;
		base.transform.localPosition = normalized * Mathf.Min(pos.magnitude, 1f);
		base.transform.localScale = scale;
	}

	public override IEnumerator Spin()
	{
		_ = base.transform.position;
		_ = base.transform.localEulerAngles;
		while (true)
		{
			float num = Mathf.Atan2(base.transform.position.y - base.transform.parent.position.y, base.transform.position.x - base.transform.parent.position.x);
			num -= MathF.PI / 2f;
			num *= 180f / MathF.PI;
			base.transform.localEulerAngles = new Vector3(0f, 0f, num);
			yield return Wait(1);
		}
	}
}
