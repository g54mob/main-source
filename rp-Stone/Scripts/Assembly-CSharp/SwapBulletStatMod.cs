public class SwapBulletStatMod : StatModifier
{
	public Bullet replacementBullet;

	public override void Init()
	{
		base.Init();
		Weapon weapon = base.sourceItem as Weapon;
		if (weapon != null)
		{
			weapon.bulletPrefab = replacementBullet;
		}
	}
}
