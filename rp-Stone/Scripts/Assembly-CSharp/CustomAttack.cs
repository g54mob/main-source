using System;

[Serializable]
public class CustomAttack
{
	public int castTime;

	public int perfTime;

	public int cooldown;

	public Weapon.AttackSprites[] sprites;

	public Bullet bulletPrefab;

	public bool hasLoadedSprites { get; set; }
}
