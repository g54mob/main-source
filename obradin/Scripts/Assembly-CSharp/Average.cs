using System.Collections.Generic;
using UnityEngine;

public class Average
{
	private List<float> values;

	private readonly int numSamples;

	private int addIndex;

	public float average
	{
		get
		{
			float num = 0f;
			if (values.Count == 0)
			{
				return num;
			}
			foreach (float value in values)
			{
				float num2 = value;
				num += num2;
			}
			return num / (float)values.Count;
		}
	}

	public float max
	{
		get
		{
			if (values.Count == 0)
			{
				return 0f;
			}
			float num = float.MinValue;
			foreach (float value in values)
			{
				float num2 = value;
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}
	}

	public float min
	{
		get
		{
			if (values.Count == 0)
			{
				return 0f;
			}
			float num = float.MaxValue;
			foreach (float value in values)
			{
				float num2 = value;
				if (num2 < num)
				{
					num = num2;
				}
			}
			return num;
		}
	}

	public float recentNonZero
	{
		get
		{
			for (int i = 0; i < values.Count; i++)
			{
				int index = (addIndex - i + values.Count) % values.Count;
				if (Mathf.Abs(values[index]) > 0f)
				{
					return values[index];
				}
			}
			return 0f;
		}
	}

	public Average(int numSamples_)
	{
		values = new List<float>();
		numSamples = numSamples_;
		addIndex = 0;
	}

	public void Add(float value)
	{
		if (values.Count >= numSamples)
		{
			addIndex = (addIndex + 1) % numSamples;
			values[addIndex] = value;
		}
		else
		{
			addIndex = values.Count;
			values.Add(value);
		}
	}
}
