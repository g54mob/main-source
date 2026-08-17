using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.Progression;

[Serializable]
public class MenuMeta
{
	public EMap lastSelectedMap = EMap.Forest;

	public Dictionary<EMap, MapProgress> mapsProgress;

	private int numRunsForUnlocks;

	private int numRunsForLeaderboards;

	private int numRunsForQuests;

	private int numRunsForQuickQuests;

	private int numRunsForShop;

	public bool hasVisitedUnlocks;

	public bool hasVisitedQuests;

	public bool hasVisitedShop;

	public unsafe bool HasMenuUnlocks()
	{
		//IL_003b: Expected O, but got Ref
		//IL_001c: Invalid comparison between F4 and I4
		object obj = default(object);
		string statName = ((Enum)(&obj)).ToString();
		float stat = MyStats.GetStat(statName);
		bool flag = stat < (float)numRunsForUnlocks;
		return !flag;
	}

	public unsafe bool HasMenuQuests()
	{
		//IL_003b: Expected O, but got Ref
		//IL_001c: Invalid comparison between F4 and I4
		object obj = default(object);
		string statName = ((Enum)(&obj)).ToString();
		float stat = MyStats.GetStat(statName);
		bool flag = stat < (float)numRunsForQuests;
		return !flag;
	}

	public unsafe bool HasMenuShop()
	{
		//IL_003b: Expected O, but got Ref
		//IL_001c: Invalid comparison between F4 and I4
		object obj = default(object);
		string statName = ((Enum)(&obj)).ToString();
		float stat = MyStats.GetStat(statName);
		bool flag = stat < (float)numRunsForShop;
		return !flag;
	}

	public unsafe bool HasQuickQuests()
	{
		//IL_003b: Expected O, but got Ref
		//IL_001c: Invalid comparison between F4 and I4
		object obj = default(object);
		string statName = ((Enum)(&obj)).ToString();
		float stat = MyStats.GetStat(statName);
		bool flag = stat < (float)numRunsForQuickQuests;
		return !flag;
	}

	public unsafe bool HasLeaderboards()
	{
		//IL_0104: Expected I4, but got O
		//IL_00ba: Expected O, but got Ref
		//IL_00da: Invalid comparison between F4 and I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					if (cfGameSettings.hide_leaderboards != 1)
					{
						object obj = default(object);
						string statName = ((Enum)(&obj)).ToString();
						float stat = MyStats.GetStat(statName);
						bool flag = stat < (float)numRunsForLeaderboards;
						return !flag;
					}
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public MapProgress GetMapProgress(EMap map)
	{
		VerifyMap(map);
		if (mapsProgress != null)
		{
			return (MapProgress)((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
		}
		return (MapProgress)(object)new NullReferenceException();
	}

	private void VerifyMap(EMap map)
	{
		if (!((Dictionary<System.Int32Enum, object>)(object)mapsProgress).ContainsKey((System.Int32Enum)map))
		{
			MapProgress value = new MapProgress();
			((Dictionary<System.Int32Enum, object>)(object)mapsProgress).Add((System.Int32Enum)map, (object)value);
		}
	}

	public void SetTier(EMap map, int tier)
	{
		VerifyMap(map);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
	}

	public void SetTierCompletion(EMap map, int tier)
	{
		//IL_0032: Expected O, but got I
		VerifyMap(map);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v5 (System.Object)+28]");
		if (!((List<int>)0).Contains(tier))
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
			((MapProgress)obj2).CompleteTier(tier);
		}
	}

	public int GetLastSelectedTier(EMap map)
	{
		//IL_0050: Expected I4, but got O
		VerifyMap(map);
		if (mapsProgress != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v5 (System.Object)+24]");
				return 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public bool IsTierCompleted(EMap map, int tier)
	{
		//IL_00af: Expected I4, but got O
		//IL_0098: Expected O, but got I
		VerifyMap(map);
		if (mapsProgress != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v6 (System.Object)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v6 (System.Object)+28]");
					return ((List<int>)0).Contains(tier);
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public int GetHighestCompletedTier(EMap map)
	{
		//IL_0043: Expected I4, but got I8
		VerifyMap(map);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)mapsProgress).get_Item((System.Int32Enum)map);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
		int num = -1;
		List<int>.Enumerator enumerator = default(List<int>.Enumerator);
		int num2 = default(int);
		while (enumerator.MoveNext())
		{
			if (num2 > num)
			{
				num = num2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		return num;
	}

	public MenuMeta()
	{
		Dictionary<EMap, MapProgress> dictionary = new Dictionary<EMap, MapProgress>();
		mapsProgress = dictionary;
		numRunsForUnlocks = 1;
		numRunsForLeaderboards = 2;
		numRunsForQuests = 4;
		numRunsForQuickQuests = 5;
		numRunsForShop = 6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
