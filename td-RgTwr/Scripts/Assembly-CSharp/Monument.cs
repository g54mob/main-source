using UnityEngine;

public class Monument : Tower
{
	private int healthSlaughter;

	private int armorSlaughter;

	private int shieldSlaughter;

	public override void SetStats()
	{
		base.SetStats();
		healthSlaughter = TowerManager.instance.GetSpecial1(towerType);
		armorSlaughter = TowerManager.instance.GetSpecial2(towerType);
		shieldSlaughter = TowerManager.instance.GetSpecial3(towerType);
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
		if (extraProjectileFX != null)
		{
			GameObject gameObject2 = Object.Instantiate(extraProjectileFX, gameObject.transform.position, gameObject.transform.rotation);
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.GetComponent<ProjectileFX>().SetFX(base.bleedPercent, base.burnPercent, base.poisonPercent, base.slowPercent, consumesMana);
			Projectile component = gameObject.GetComponent<Projectile>();
			if (component.detachOnDestruction == null)
			{
				component.detachOnDestruction = gameObject2;
				component.extraFX = gameObject2.GetComponent<ProjectileFX>();
			}
		}
		SpiritSword component2 = gameObject.GetComponent<SpiritSword>();
		component2.healthSlaughter = healthSlaughter;
		component2.armorSlaughter = armorSlaughter;
		component2.shieldSlaughter = shieldSlaughter;
	}
}
