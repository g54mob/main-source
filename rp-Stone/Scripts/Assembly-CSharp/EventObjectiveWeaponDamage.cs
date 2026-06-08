public class EventObjectiveWeaponDamage : EventObjectiveBase
{
	private string weaponId;

	public EventObjectiveWeaponDamage(int goal, string weaponId, string weaponName)
		: base("weapon_dmg", goal)
	{
		this.weaponId = weaponId;
		description = string.Format(Te.xt("tid_q_basic_weapon_damage"), TranslateIfTID(weaponName));
	}

	public override void Init()
	{
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.bullet != null && dmg.bullet.weapon != null && dmg.bullet.weapon.id == weaponId && dmg.startHitpoints > 0)
		{
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			AddProgress(num);
		}
	}
}
