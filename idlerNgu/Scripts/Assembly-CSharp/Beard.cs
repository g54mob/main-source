using System;

[Serializable]
public class Beard
{
	public float progress;

	public bool active;

	public long beardLevel;

	public long permLevel;

	public long bankedLevel;

	public Beard()
	{
		progress = 0f;
		active = false;
		beardLevel = 0L;
		permLevel = 0L;
		bankedLevel = 0L;
	}

	public void reset()
	{
		progress = 0f;
		beardLevel = 0L;
	}
}
