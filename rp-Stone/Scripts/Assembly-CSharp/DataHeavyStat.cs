using UnityEngine;

public class DataHeavyStat
{
	public string itemId;

	public string statId;

	public float[] data;

	public float Compute(int itemDisplayLevel)
	{
		itemDisplayLevel--;
		if (data == null)
		{
			Debug.LogError("Error calculating data heavy stat for: " + itemId + ", " + statId);
			return 0f;
		}
		if (itemDisplayLevel < data.Length)
		{
			return data[itemDisplayLevel];
		}
		return data[data.Length - 1];
	}
}
