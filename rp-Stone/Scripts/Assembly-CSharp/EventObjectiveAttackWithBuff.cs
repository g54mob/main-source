using System.Collections.Generic;

public class EventObjectiveAttackWithBuff : EventObjectiveBase
{
	private string debuffId;

	public EventObjectiveAttackWithBuff(int goal, string debuffId, string debuffName)
		: base(debuffId + "_weapon_hit_with_buff", goal)
	{
		this.debuffId = debuffId;
		description = string.Format(Te.xt("tid_q_basic_weapon_hit_with_buff"), TranslateIfTID(debuffName));
	}

	public override void Init()
	{
		Character.OnCharacterTookDamage += HandleCharacterBuffAttack;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterBuffAttack;
	}

	private void HandleCharacterBuffAttack(Character c, Damage dmg)
	{
		if (!(dmg.Owner == GameStates.Singleton.hero) || dmg.Owner.statModController == null || dmg.Owner.statModController.debuffs == null)
		{
			return;
		}
		List<List<StatModifier>> debuffs = dmg.Owner.statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == debuffId)
			{
				AddProgress();
			}
		}
	}
}
