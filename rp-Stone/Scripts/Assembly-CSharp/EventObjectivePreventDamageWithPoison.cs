using System.Collections.Generic;

public class EventObjectivePreventDamageWithPoison : EventObjectiveBase
{
	public EventObjectivePreventDamageWithPoison(int goal)
		: base("prevent_poison", goal)
	{
		description = Te.xt("tid_q_basic_weaken_attacks");
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
		if (!(c == GameStates.Singleton.hero) || !(dmg.Owner != null) || !(dmg.Owner.statModController != null) || dmg.Owner.statModController.debuffs == null)
		{
			return;
		}
		for (int i = 0; i < dmg.Owner.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list = dmg.Owner.statModController.debuffs[i];
			if (list[0].id == "debuff_feeble" || list[0].id == "debuff_damage")
			{
				AddProgress();
				break;
			}
		}
	}
}
