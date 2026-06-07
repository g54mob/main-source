using UnityEngine;

public class Dryer : Weapon
{
	public GameObject projObj;

	public override void CastSpell()
	{
		Vector3 position = base.transform.position;
		Monster closestMonster = base.dungeon.GetClosestMonster(position);
		if (!(closestMonster == null))
		{
			Projectile component = base.dungeon.InstantiateExternal(projObj).GetComponent<Projectile>();
			component.source = this;
			component.forceDamage = 1;
			component.transform.position = position;
			component.transform.localScale = Vector3.one;
			Dungeon.Instance.animationManager.BounceZoom(component.gameObject, 0.3f, 4);
			Vector3 normalized = (closestMonster.transform.position - position).normalized;
			component.transform.localEulerAngles = new Vector3(0f, 0f, Weapon.PointTo(position, closestMonster.transform.position, 90f));
			base.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.4f);
			base.dungeon.animationManager.Fade(component.gameObject, 3, 10);
			base.dungeon.animationManager.FlashSprite(component.gameObject);
			component.debuffValue = 1f;
			component.debuff = Monster.Debuff.Knockback;
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Wind_Bolt, 0.9f, 1.1f, 0.9f, 0.9f);
		}
	}
}
