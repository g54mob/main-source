using System.Collections.Generic;

public class CinderwispDevourAbility : SummonDevourAbility, IAbilityActivationProvider
{
	public int damagePerIgnite { get; set; }

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		List<Character> targets = new List<Character>();
		List<Damage> damages = new List<Damage>();
		for (int num = IgnitionStatMod.allIgnitions.Count - 1; num >= 0; num--)
		{
			IgnitionStatMod ignitionStatMod = IgnitionStatMod.allIgnitions[num];
			Character character = ignitionStatMod.character;
			int num2 = targets.IndexOf(character);
			if (num2 >= 0)
			{
				damages[num2].amount += damagePerIgnite;
			}
			else
			{
				Damage damage = new Damage();
				damages.Add(damage);
				targets.Add(character);
				damage.Owner = GetComponent<Cinderwisp>();
				damage.amount = damagePerIgnite;
				damage.type = Damage.Type.Super;
				damage.isCritical = true;
				damage.tags.Add("Fire");
				damage.tags.Add("magic");
				damage.tags.Add("Devour");
				damage.tags.Add("activated_ability");
			}
			ignitionStatMod.End();
		}
		GetComponent<Cinderwisp>().PlaySuperAbilityState(delegate
		{
			for (int i = 0; i < targets.Count; i++)
			{
				if (targets[i].Alive)
				{
					targets[i].InflictDamage(damages[i]);
				}
			}
		});
		return null;
	}
}
