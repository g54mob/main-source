using System;
using System.Collections.Generic;
using DevCmdLine.UI;
using UnityEngine;

public class DevCmdOptionSpawn : DevCmdOptionUIBase
{
	private struct PrefabEntry : IComparable<PrefabEntry>
	{
		public GameObject prefab;

		public string text;

		public bool overridden;

		public int CompareTo(PrefabEntry other)
		{
			if (overridden != other.overridden)
			{
				if (overridden)
				{
					return -1;
				}
				return 1;
			}
			return string.Compare(text, other.text, StringComparison.Ordinal);
		}
	}

	public string mainLabel = "Spawn";

	public override bool TryGetInitial(out string optionStr, out bool isEnd)
	{
		optionStr = mainLabel;
		isEnd = false;
		return GameUtil.isReady;
	}

	public override List<DevCmdSubOption> Selected(List<object> contexts)
	{
		List<DevCmdSubOption> list = new List<DevCmdSubOption>();
		GameObject[] prefabs = DevCmdSpawn.GetPrefabs();
		List<string> list2 = new List<string>();
		HashSet<string> hashSet = new HashSet<string>();
		for (int i = 0; i < prefabs.Length; i++)
		{
			DevCmdSpawn component = prefabs[i].GetComponent<DevCmdSpawn>();
			if (string.IsNullOrEmpty(component.uiCategory))
			{
				continue;
			}
			string[] array = component.uiCategory.Split('/');
			if (array.Length <= contexts.Count)
			{
				continue;
			}
			string item = array[contexts.Count];
			if (hashSet.Contains(item))
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < contexts.Count; j++)
			{
				if ((string)contexts[j] != array[j])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				hashSet.Add(item);
				list2.Add(item);
			}
		}
		list2.Sort();
		for (int k = 0; k < list2.Count; k++)
		{
			list.Add(new DevCmdSubOption
			{
				context = list2[k],
				isEnd = false,
				text = list2[k]
			});
		}
		List<PrefabEntry> list3 = new List<PrefabEntry>();
		foreach (GameObject gameObject in prefabs)
		{
			DevCmdSpawn component2 = gameObject.GetComponent<DevCmdSpawn>();
			string[] array2 = (string.IsNullOrEmpty(component2.uiCategory) ? Array.Empty<string>() : component2.uiCategory.Split('/'));
			if (array2.Length != contexts.Count)
			{
				continue;
			}
			bool flag2 = true;
			for (int m = 0; m < contexts.Count; m++)
			{
				if ((string)contexts[m] != array2[m])
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				PrefabEntry item2 = new PrefabEntry
				{
					prefab = gameObject
				};
				if (component2.uiOverrideName)
				{
					item2.overridden = true;
					item2.text = component2.uiOverridenName;
				}
				else
				{
					item2.overridden = false;
					item2.text = gameObject.name;
				}
				list3.Add(item2);
			}
		}
		list3.Sort();
		for (int n = 0; n < list3.Count; n++)
		{
			list.Add(new DevCmdSubOption
			{
				context = list3[n].prefab.name,
				isEnd = true,
				text = list3[n].text
			});
		}
		return list;
	}

	public override string ConstructCmd(List<object> contexts)
	{
		return "spawn " + ((string)contexts[contexts.Count - 1]).Replace(" ", "");
	}
}
