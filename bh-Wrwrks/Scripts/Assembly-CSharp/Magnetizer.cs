using System.Collections.Generic;
using UnityEngine;

public class Magnetizer : Module
{
	private List<Aura> dmgBuffs = new List<Aura>();

	public override void Init()
	{
		CalcBuffs();
	}

	public void CalcBuffs()
	{
		int num = 0;
		foreach (Module adjacent in GetAdjacents())
		{
			if (!adjacent.MECH)
			{
				continue;
			}
			num += adjacent.damage;
			foreach (Aura aura in adjacent.auras)
			{
				if (aura.source != null)
				{
					if (aura.type == Aura.Type.Damage && aura.source.type == Aura.Type.Dogwhistle)
					{
						num -= (int)aura.value;
					}
					if (aura.type == Aura.Type.Damage && aura.source.type == Aura.Type.Magnetizer)
					{
						num -= (int)aura.value;
					}
				}
			}
		}
		if (num != 0)
		{
			AddAura(new Aura(Aura.Type.Damage, foreign: true, temp: false, auras[0], num));
			base.transform.localScale = Vector3.one;
		}
	}
}
