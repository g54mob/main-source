public class EventObjectiveAbilityDamage : EventObjectiveBase
{
	private string abilityId;

	public EventObjectiveAbilityDamage(int goal, string abilityId, string weaponName)
		: base("ability_dmg", goal)
	{
		this.abilityId = abilityId;
		description = string.Format(Te.xt("tid_q_basic_ability_damage"), TranslateIfTID(weaponName));
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
		if (dmg != null && HasTag(dmg, abilityId) && HasTag(dmg, "activated_ability") && dmg.startHitpoints > 0)
		{
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			AddProgress(num);
		}
	}

	private bool HasTag(Damage dmg, string tagToCheck)
	{
		if (!dmg.tags.Contains(tagToCheck))
		{
			if (dmg.bullet != null)
			{
				return dmg.bullet.tags.Contains(tagToCheck);
			}
			return false;
		}
		return true;
	}
}
