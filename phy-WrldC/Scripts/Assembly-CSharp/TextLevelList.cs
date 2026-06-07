using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Text Level List Data")]
public class TextLevelList : ScriptableObject
{
	[TextArea(28, 50)]
	public string levelIds;

	public string[] GetAllLevelIds()
	{
		List<string> list = new List<string>();
		string[] array = levelIds.Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Replace("\r", "");
			if (string.IsNullOrEmpty(array[i]) || string.IsNullOrWhiteSpace(array[i]) || array[i].StartsWith("#"))
			{
				continue;
			}
			if (array[i].StartsWith("!"))
			{
				if (!Debug.isDebugBuild)
				{
					continue;
				}
				array[i] = array[i].Replace("!", "");
			}
			list.Add(array[i]);
		}
		return list.ToArray();
	}
}
