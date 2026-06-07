using System.Collections.Generic;
using UnityEngine;

public class Inductor : Module
{
	private List<Aura> dmgBuffs = new List<Aura>();

	public override void Init()
	{
		damage = 0;
		CheckDamage();
	}

	public void CheckDamage()
	{
		int num = base.board.GetNetworkCount(this, Tribe.Mech) - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (UPGRADED)
		{
			num *= 2;
		}
		while (num > dmgBuffs.Count)
		{
			Aura aura = new Aura(Aura.Type.Damage);
			AddAura(aura);
			dmgBuffs.Add(aura);
		}
		while (num < dmgBuffs.Count)
		{
			RemoveAura(dmgBuffs[0]);
			dmgBuffs.Remove(dmgBuffs[0]);
		}
		base.transform.localScale = Vector3.one;
	}
}
