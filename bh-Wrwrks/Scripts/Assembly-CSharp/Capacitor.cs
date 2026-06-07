using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor : Module
{
	public int t;

	public int timer = 120;

	private List<Aura> dmgBuffs = new List<Aura>();

	public override IEnumerator Increment()
	{
		while (true)
		{
			t = 1;
			yield return Dungeon.Wait((int)((float)timer / accelMult));
			t = 0;
			yield return Dungeon.Wait(1);
		}
	}

	public override void Init()
	{
		damage = 0;
		CheckDamage();
	}

	public void CheckDamage()
	{
		int num = base.board.GetNetworkCount(this, Tribe.Mech);
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
