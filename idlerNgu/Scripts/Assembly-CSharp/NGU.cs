using System;

[Serializable]
public class NGU
{
	public float progress;

	public long level;

	public float evilProgress;

	public long evilLevel;

	public float sadisticProgress;

	public long sadisticLevel;

	public long energy;

	public long magic;

	public long target;

	public long evilTarget;

	public long sadisticTarget;

	public NGU()
	{
		progress = 0f;
		level = 0L;
		energy = 0L;
		magic = 0L;
		target = 0L;
	}

	public void reset()
	{
		energy = 0L;
		magic = 0L;
	}

	public long targetLevel()
	{
		long num = target;
		if (num == 0L)
		{
			num = long.MaxValue;
		}
		if (num == -1)
		{
			num = 0L;
		}
		return num;
	}

	public long evilTargetLevel()
	{
		long num = evilTarget;
		if (num == 0L)
		{
			num = long.MaxValue;
		}
		if (num == -1)
		{
			num = 0L;
		}
		return num;
	}

	public long sadisticTargetLevel()
	{
		long num = sadisticTarget;
		if (num == 0L)
		{
			num = long.MaxValue;
		}
		if (num == -1)
		{
			num = 0L;
		}
		return num;
	}
}
