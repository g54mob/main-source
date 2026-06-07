using System.Collections.Generic;

public class FishMod : Module
{
	private List<Aura> dmgBuffs = new List<Aura>();

	public override void Init()
	{
		if (name == Name.Fish)
		{
			CalcBuffs();
		}
	}

	public void CalcBuffs()
	{
	}
}
