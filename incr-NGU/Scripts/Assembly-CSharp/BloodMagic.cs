using System;
using System.Collections.Generic;

[Serializable]
public class BloodMagic
{
	public Ritual[] rituals = new Ritual[1];

	public List<Ritual> ritual = new List<Ritual>();

	public double bloodPoints;

	public double rebirthPower;

	public PlayerTime adventureSpellTime;

	public PlayerTime macguffin1Time;

	public PlayerTime macguffin2Time;

	public double goldSpellBlood;

	public double lootSpellBlood;

	public bool rebirthAutoSpell;

	public bool lootAutoSpell;

	public bool goldAutoSpell;

	public int size()
	{
		return 8;
	}

	public BloodMagic()
	{
		ritual = new List<Ritual>();
		updateRitualCount(size());
		bloodPoints = 0.0;
		rebirthPower = 1.0;
		adventureSpellTime = new PlayerTime();
		macguffin1Time = new PlayerTime();
		macguffin2Time = new PlayerTime();
		goldSpellBlood = 0.0;
		lootSpellBlood = 0.0;
		rebirthAutoSpell = false;
		lootAutoSpell = false;
		goldAutoSpell = false;
	}

	public void updateRitualCount(int size)
	{
		for (int i = 0; i < size; i++)
		{
			ritual.Add(new Ritual());
		}
	}
}
