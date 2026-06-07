using System;

[Serializable]
public class Wish
{
	public long energy;

	public long magic;

	public long res3;

	public int level;

	public float progress;

	public Wish()
	{
		energy = 0L;
		magic = 0L;
		res3 = 0L;
		level = 0;
		progress = 0f;
	}

	public void reset()
	{
		energy = 0L;
		magic = 0L;
		res3 = 0L;
	}
}
