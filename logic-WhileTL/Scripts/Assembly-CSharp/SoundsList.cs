using System.Collections.Generic;
using UnityEngine;

public class SoundsList : MonoBehaviour
{
	public SoundItem[] Items;

	public Dictionary<string, AudioClip> GetItems()
	{
		Dictionary<string, AudioClip> dictionary = new Dictionary<string, AudioClip>();
		SoundItem[] items = Items;
		foreach (SoundItem soundItem in items)
		{
			bool flag = string.IsNullOrEmpty(soundItem.Name);
			bool flag2 = soundItem.Clip == null;
			if (flag || flag2)
			{
				if (flag)
				{
					Debug.LogWarning($"SoundsList contains entry with empty name '{(flag2 ? string.Empty : soundItem.Clip.name)}'");
				}
				if (flag2)
				{
					Debug.LogWarning($"SoundsList contains entry without clip '{soundItem.Name}'");
				}
			}
			else if (dictionary.ContainsKey(soundItem.Name))
			{
				Debug.LogWarning($"SoundsList contains entries with same name '{soundItem.Name}'");
			}
			else
			{
				dictionary.Add(soundItem.Name, soundItem.Clip);
			}
		}
		return dictionary;
	}
}
