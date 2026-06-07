using System;
using System.Collections.Generic;

[Serializable]
public class Hacks
{
	public List<Hack> hacks;

	public bool hacksOn;

	public bool autoAdvance;

	public long target;

	public bool disabled;

	public Hacks()
	{
		hacks = new List<Hack>();
		hacksOn = false;
		updateHackSize();
		autoAdvance = true;
		target = 0L;
		disabled = false;
	}

	public int hacksSize()
	{
		return 16;
	}

	public void updateHackSize()
	{
		while (hacks.Count < hacksSize())
		{
			hacks.Add(new Hack());
		}
	}
}
