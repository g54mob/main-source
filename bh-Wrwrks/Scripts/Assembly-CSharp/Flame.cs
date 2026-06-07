using System;
using UnityEngine;

public class Flame : Weapon
{
	public GameObject proj;

	public override void CastSpell()
	{
		if (base.dungeon.livingEnemies.Count != 0)
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Imp_Fire, 0.9f, 1.1f, 1f);
			ShootArrow(base.dungeon.livingEnemies[0]);
		}
	}

	private void ShootArrow(Monster m)
	{
		if (owner.dungeon.livingEnemies.Count != 0 && !(m == null))
		{
			float z = 180f + 180f / MathF.PI * Mathf.Atan2(base.player.transform.position.y - m.pos.y, base.player.transform.position.x - m.pos.x);
			Flame_Proj component = UnityEngine.Object.Instantiate(proj).GetComponent<Flame_Proj>();
			component.source = this;
			component.transform.position = base.player.transform.position;
			component.transform.localEulerAngles = new Vector3(0f, 0f, z);
			component.sharedWeapon = true;
			component.transform.localScale = scale;
			Vector3 normalized = (m.transform.position - base.player.transform.position).normalized;
			owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.3f);
			owner.dungeon.animationManager.Fade(component.gameObject, 3, 240);
		}
	}
}
