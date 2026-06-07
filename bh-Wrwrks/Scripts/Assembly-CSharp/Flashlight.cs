using System;
using System.Collections;
using UnityEngine;

public class Flashlight : Weapon
{
	private bool init;

	public Projectile box;

	public override void ProcessFrame()
	{
		Vector3 normalized = pos.normalized;
		base.transform.localPosition = normalized * Mathf.Min(pos.magnitude, 1f);
		base.transform.localScale = scale;
		if (!init)
		{
			box = base.dungeon.animationManager.CreateExplosion("FFEB57", "FFEB57", -1, insta: false, ticks: true, spin: true, shake: false, 20);
			box.source = this;
			box.transform.parent = base.transform.parent;
			init = true;
		}
		box.transform.localPosition = pos;
		if (noInput)
		{
			box.transform.localPosition = normalized * 3.5f;
		}
	}

	private void OnDestroy()
	{
		if (box != null)
		{
			UnityEngine.Object.Destroy(box.gameObject);
		}
	}

	public override IEnumerator Spin()
	{
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
