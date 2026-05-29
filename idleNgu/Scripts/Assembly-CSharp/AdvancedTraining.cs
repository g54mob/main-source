using System;

[Serializable]
public class AdvancedTraining
{
	public int[] training = new int[10];

	public long[] level = new long[10];

	public long[] bankedLevel = new long[10];

	public long[] energy = new long[10];

	public float[] barProgress = new float[10];

	public long[] levelTarget = new long[10];

	public bool transferredBankedLevels = true;

	[NonSerialized]
	public int[] target = new int[10];

	[NonSerialized]
	public float[] cost = new float[10];

	[NonSerialized]
	public float[] speed = new float[10];

	public bool autoAdvance;

	public AdvancedTraining()
	{
		for (int i = 0; i < training.Length; i++)
		{
			training[i] = 0;
			level[i] = 0L;
			energy[i] = 0L;
			barProgress[i] = 0f;
			levelTarget[i] = 0L;
			target[i] = 0;
			speed[i] = 1f;
			bankedLevel[i] = 0L;
		}
		autoAdvance = false;
		cost[0] = 12000000f;
		cost[1] = 12000000f;
		cost[2] = 12000000f;
		cost[3] = 24000000f;
		cost[4] = 24000000f;
		cost[5] = 12000000f;
		cost[6] = 12000000f;
		cost[7] = 12000000f;
		cost[8] = 24000000f;
		transferredBankedLevels = true;
	}

	public void reset()
	{
		for (int i = 0; i < training.Length; i++)
		{
			training[i] = 0;
			energy[i] = 0L;
			barProgress[i] = 0f;
			level[i] = 0L;
		}
	}

	public void unlock()
	{
		training[0] = 0;
		training[1] = 0;
		training[2] = 0;
		training[3] = 0;
		training[4] = 0;
		training[5] = 0;
		training[6] = 0;
		training[7] = 0;
		training[8] = 0;
		training[9] = 0;
	}

	public long targetLevel(int id)
	{
		if (levelTarget[id] == 0L)
		{
			return long.MaxValue;
		}
		if (levelTarget[id] == -1)
		{
			return 0L;
		}
		return levelTarget[id];
	}
}
