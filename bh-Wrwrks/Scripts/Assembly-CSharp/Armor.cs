using System.Collections.Generic;
using UnityEngine;

public class Armor : Module
{
	private List<Aura> buffs = new List<Aura>();

	public override void Init()
	{
		Count();
	}

	public void Count()
	{
		counter = base.board.GetNetworkCount(this);
		CalcBuffs();
	}

	public void CalcBuffs()
	{
		int num = counter;
		if (UPGRADED)
		{
			num *= 2;
		}
		while (num > buffs.Count)
		{
			Aura aura = new Aura(Aura.Type.PlayerHP, foreign: false, temp: false, null, 5f);
			AddAura(aura);
			buffs.Add(aura);
		}
		while (num < buffs.Count)
		{
			RemoveAura(buffs[0]);
			buffs.Remove(buffs[0]);
		}
		base.transform.localScale = Vector3.one;
	}

	private void OnDestroy()
	{
		foreach (Aura item in new List<Aura>(auras))
		{
			RemoveAura(item);
		}
	}
}
