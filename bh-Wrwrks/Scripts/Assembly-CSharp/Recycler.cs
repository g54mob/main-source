using System.Collections.Generic;

public class Recycler : Module
{
	private List<Aura> buffs = new List<Aura>();

	public void AddCounter()
	{
		int num = 2;
		for (int i = 0; i < num; i++)
		{
			Aura aura = new Aura(Aura.Type.FoodBuff);
			AddAura(aura);
			buffs.Add(aura);
		}
	}

	public void ResetCounter()
	{
		foreach (Aura aura in auras)
		{
			if (aura.type == Aura.Type.FoodBuff && !buffs.Contains(aura))
			{
				buffs.Add(aura);
			}
		}
		foreach (Aura buff in buffs)
		{
			RemoveAura(buff);
		}
		buffs.Clear();
	}
}
