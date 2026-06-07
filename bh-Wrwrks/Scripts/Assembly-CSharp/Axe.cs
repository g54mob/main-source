using System;
using UnityEngine;

public class Axe : Weapon
{
	public GameObject projectile;

	public override void HitTrigger(Monster monster)
	{
		Projectile component = UnityEngine.Object.Instantiate(projectile).GetComponent<Projectile>();
		component.source = this;
		component.transform.position = monster.transform.position;
		component.transform.localEulerAngles = base.transform.localEulerAngles;
		component.transform.localScale = base.transform.localScale * (owner.UPGRADED ? 1.25f : 1f);
		base.animationManager.BounceZoom(component.gameObject, 0.2f, 4);
		float f = (base.transform.localEulerAngles.z + 90f) * MathF.PI / 180f;
		Vector3 normalized = (base.transform.position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) - base.transform.position).normalized;
		owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.2f);
		owner.dungeon.animationManager.Fade(component.gameObject, 6, 3);
	}
}
