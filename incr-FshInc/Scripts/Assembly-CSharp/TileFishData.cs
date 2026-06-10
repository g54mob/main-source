using System.Collections.Generic;
using UnityEngine;

public class TileFishData : MonoBehaviour
{
	[SerializeField]
	private List<Fish> fishKeys = new List<Fish>();

	[SerializeField]
	private List<float> multiplierValues = new List<float>();

	public float GetMultiplier(Fish fish)
	{
		int num = fishKeys.IndexOf(fish);
		if (num != -1)
		{
			return multiplierValues[num];
		}
		return 1f;
	}

	public Dictionary<Fish, float> GetAllBoosts()
	{
		Dictionary<Fish, float> dictionary = new Dictionary<Fish, float>();
		for (int i = 0; i < fishKeys.Count; i++)
		{
			Debug.Log("Adding boost To output " + fishKeys[i].ToString());
			dictionary.Add(fishKeys[i], multiplierValues[i]);
		}
		return dictionary;
	}

	public void SetMultiplier(Fish fish, float multiplier)
	{
		int num = fishKeys.IndexOf(fish);
		if (num != -1)
		{
			multiplierValues[num] = multiplier;
			return;
		}
		fishKeys.Add(fish);
		multiplierValues.Add(multiplier);
	}
}
