using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public static class JunctionsSaveManager
{
	private const string JUNCTION_HASH_SAVE_KEY = "hash";

	private const string JUNCTION_INDICES_ARRAY_SAVE_KEY = "indices";

	private const string JUNCTION_SELECTED_BRANCHES_ARRAY_SAVE_KEY = "states";

	public static bool Load(JObject savedData)
	{
		if (savedData == null)
		{
			Debug.LogError("Given save data is null, loading will not be performed");
			return false;
		}
		string text = savedData.GetString("hash");
		if (text == null)
		{
			Debug.LogError("loadedJunctionsHash is null, junctions state loading aborted");
			return false;
		}
		if (text != SingletonBehaviour<RailTrackRegistryBase>.Instance.JunctionsHash)
		{
			Debug.LogWarning("Given junctions save data was made in a different scene, loading will not be performed");
			Debug.LogWarning("Current junctions hash '" + SingletonBehaviour<RailTrackRegistryBase>.Instance.JunctionsHash + "' doesn't match save data hash '" + text + "', will not load");
			return false;
		}
		Debug.Log("Junctions hashes match '" + SingletonBehaviour<RailTrackRegistryBase>.Instance.JunctionsHash + "'");
		int[] intArray = savedData.GetIntArray("indices");
		if (intArray == null)
		{
			Debug.LogError("junctionIndicesData not found, junctions state loading aborted");
			return false;
		}
		int[] intArray2 = savedData.GetIntArray("states");
		if (intArray2 == null)
		{
			Debug.LogError("junctionSelectedBranchesData not found, junctions state loading aborted");
			return false;
		}
		if (intArray.Length != intArray2.Length)
		{
			Debug.LogError("Unexpected different number of elements in junctionIndicesData and junctionSelectedBranchesData, junctions state loading aborted");
			return false;
		}
		Junction[] orderedJunctions = SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedJunctions;
		int num = orderedJunctions.Length;
		int num2 = intArray.Length;
		for (int i = 0; i < num2; i++)
		{
			int num3 = intArray[i];
			if (num3 < 0 || num3 >= num)
			{
				Debug.LogError($"Index {num3} is out of range, something is wrong, skipping!");
				continue;
			}
			byte b = (byte)intArray2[i];
			Junction junction = orderedJunctions[num3];
			if (junction.defaultSelectedBranch == b)
			{
				Debug.LogError("Default state of junction saved, something is wrong, skipping!");
			}
			else if (junction.outBranches.Count <= b)
			{
				Debug.LogError("loadedSelectedBranch is out of range, something is wrong, skipping!");
			}
			else
			{
				junction.Switch(Junction.SwitchMode.NO_SOUND, b);
			}
		}
		Debug.Log("Junctions state loaded");
		return true;
	}

	public static JObject GetJunctionsSaveData()
	{
		Junction[] orderedJunctions = SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedJunctions;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		int num = orderedJunctions.Length;
		for (int i = 0; i < num; i++)
		{
			Junction junction = orderedJunctions[i];
			if (junction.selectedBranch != junction.defaultSelectedBranch)
			{
				list.Add(i);
				list2.Add(junction.selectedBranch);
			}
		}
		JObject jObject = new JObject();
		jObject.SetString("hash", SingletonBehaviour<RailTrackRegistryBase>.Instance.JunctionsHash);
		jObject.SetIntArray("indices", list.ToArray());
		jObject.SetIntArray("states", list2.ToArray());
		return jObject;
	}
}
