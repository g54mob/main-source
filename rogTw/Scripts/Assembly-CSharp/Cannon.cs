using UnityEngine;

public class Cannon : Tower
{
	private float splitChance;

	private int extraDmgPerHit;

	public override void SetStats()
	{
		base.SetStats();
		splitChance = TowerManager.instance.GetSpecial1(towerType);
		extraDmgPerHit = TowerManager.instance.GetSpecial2(towerType);
	}

	protected override void Fire()
	{
		if (consumesMana)
		{
			int manaCost = (int)((float)base.damage * finalManaConsumption);
			if (!ResourceManager.instance.CheckMana(manaCost))
			{
				return;
			}
			ResourceManager.instance.SpendMana(manaCost);
		}
		GameObject gameObject = Object.Instantiate(projectile, muzzle.position, muzzle.rotation);
		gameObject.GetComponent<Projectile>().SetStats(towerType, currentTarget, projectileSpeed, base.damage, base.healthDamage, base.armorDamage, base.shieldDamage, base.slowPercent, base.bleedPercent, base.burnPercent, base.poisonPercent, base.critChance, base.stunChance);
		Cannonball component = projectile.GetComponent<Cannonball>();
		component.SetRange(2f * base.range);
		component.SetSplitChance(splitChance);
		component.SetSpecialDamage(extraDmgPerHit);
		if (extraProjectileFX != null)
		{
			GameObject gameObject2 = Object.Instantiate(extraProjectileFX, gameObject.transform.position, gameObject.transform.rotation);
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.GetComponent<ProjectileFX>().SetFX(base.bleedPercent, base.burnPercent, base.poisonPercent, base.slowPercent, consumesMana);
			Projectile component2 = gameObject.GetComponent<Projectile>();
			if (component2.detachOnDestruction == null)
			{
				component2.detachOnDestruction = gameObject2;
				component2.extraFX = gameObject2.GetComponent<ProjectileFX>();
			}
		}
	}
}
