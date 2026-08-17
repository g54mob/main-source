namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileUtility
{
	public static float GetArrowSpeed(WeaponBase weaponBase)
	{
		float projectileSpeed = WeaponUtility.GetProjectileSpeed(weaponBase);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier * 0.25f;
		return num + projectileSpeed;
	}

	public static float GetArrowSpeedReduction(WeaponBase weaponBase)
	{
		float projectileSpeed = WeaponUtility.GetProjectileSpeed(weaponBase);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier * 0.25f;
		float num2 = num + projectileSpeed;
		float duration = WeaponUtility.GetDuration(weaponBase);
		float num3 = duration / 0.02f;
		return num2 / num3;
	}
}
