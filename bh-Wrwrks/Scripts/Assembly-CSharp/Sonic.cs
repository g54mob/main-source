using UnityEngine;

public class Sonic : Module
{
	public GameObject projObj;

	public void SonicWave(Module mod)
	{
		if (outputs.Contains(mod) && !(mod.weapon == null))
		{
			Vector3 vector = ((mod.weapon != null) ? mod.weapon.transform.position : base.dungeon.player.transform.position);
			Monster closestMonster = base.dungeon.GetClosestMonster(vector);
			if (!(closestMonster == null))
			{
				Projectile component = base.dungeon.InstantiateExternal(projObj).GetComponent<Projectile>();
				component.sourceModule = this;
				component.transform.position = vector;
				component.transform.localScale = Vector3.one;
				Dungeon.Instance.animationManager.BounceZoom(component.gameObject, 0.3f, 4);
				Vector3 normalized = (closestMonster.transform.position - vector).normalized;
				component.transform.localEulerAngles = new Vector3(0f, 0f, Weapon.PointTo(vector, closestMonster.transform.position, 90f));
				base.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
				base.dungeon.animationManager.Fade(component.gameObject, 6, 20);
				base.dungeon.animationManager.FlashSprite(component.gameObject);
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Beam);
			}
		}
	}
}
