using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class EndlessGenerationManager : MonoBehaviour
{
	[Header("Config")]
	public Npc[] allRandomSpawningNpcs;

	public Npc[] demoRandomSpawningNpcs;

	[Header("Runtime")]
	public string[] spawnedBefore;

	public List<Npc> GenerateNight()
	{
		if (StoreManager.Instance.demo)
		{
			allRandomSpawningNpcs = demoRandomSpawningNpcs;
		}
		HashSet<string> humanCustomers = new HashSet<string>();
		int curDay = SaveManager.Instance.curDay;
		int curDifficulty = 3;
		List<Npc> list = new List<Npc>(allRandomSpawningNpcs ?? Array.Empty<Npc>()).Where((Npc n) => n != null).ToList();
		List<Npc> list2 = list.Where((Npc n) => n.alwaysOnlySpawnOnThisDay != -1 && n.alwaysOnlySpawnOnThisDay == curDay).ToList();
		HashSet<Npc> second = new HashSet<Npc>(list.Where((Npc n) => n.alwaysOnlySpawnOnThisDay != -1 && n.alwaysOnlySpawnOnThisDay != curDay));
		if (list2.Count > 6)
		{
			Debug.LogWarning($"[EndlessGeneration] {list2.Count} NPCs are day-forced for day {curDay}, but only 6 slots exist. Truncating.");
			list2 = list2.Take(6).ToList();
		}
		Dictionary<int, Npc> dictionary = new Dictionary<int, Npc>();
		foreach (Npc item in list2)
		{
			if (item.alwaysOnlySpawnOnThisIndex >= 0 && item.alwaysOnlySpawnOnThisIndex < 6)
			{
				if (!dictionary.ContainsKey(item.alwaysOnlySpawnOnThisIndex))
				{
					dictionary[item.alwaysOnlySpawnOnThisIndex] = item;
				}
				else
				{
					Debug.LogWarning($"[EndlessGeneration] Index conflict at {item.alwaysOnlySpawnOnThisIndex} between '{dictionary[item.alwaysOnlySpawnOnThisIndex].id}' and '{item.id}'. Keeping the first.");
				}
			}
			else if (item.alwaysOnlySpawnOnThisIndex != -1)
			{
				Debug.LogWarning($"[EndlessGeneration] Forced NPC '{item.id}' requested invalid index {item.alwaysOnlySpawnOnThisIndex}. Ignoring index lock.");
			}
		}
		List<Npc> source = list.Except(second).Except(list2).ToList();
		source = source.Where((Npc n) => n.onlySpawnAfterThisDay < curDay && curDay < n.onlySpawnBeforeThisDay).ToList();
		source = source.Where(IsAliveGatePassed).ToList();
		source = source.Where((Npc n) => n.difficulty <= curDifficulty + 2).ToList();
		source = source.Where(AllMustHaveSpawnedAreMet).ToList();
		List<Npc> list3 = source.Where((Npc n) => !HasSpawnedBefore(n.id)).ToList();
		List<Npc> source2 = source;
		List<Npc> list4 = list3;
		List<Npc> list5 = new List<Npc>(6);
		foreach (Npc item2 in list2)
		{
			if (!list5.Contains(item2) && !IsHumanDuplicateBlocked(item2, humanCustomers))
			{
				list5.Add(item2);
				RegisterHuman(item2, humanCustomers);
			}
		}
		int num = Mathf.Max(0, 6 - list5.Count);
		if (num > 0)
		{
			List<Npc> collection = PickWithDoppelBalanceConsideringSeed(list4, list5, num, humanCustomers);
			list5.AddRange(collection);
		}
		if (list5.Count < 6)
		{
			System.Random rng = new System.Random();
			foreach (Npc item3 in list4.OrderBy((Npc _) => rng.Next()))
			{
				if (list5.Count == 6)
				{
					break;
				}
				if (!list5.Contains(item3) && !IsHumanDuplicateBlocked(item3, humanCustomers))
				{
					list5.Add(item3);
					RegisterHuman(item3, humanCustomers);
				}
			}
		}
		if (list5.Count < 6)
		{
			System.Random rng2 = new System.Random();
			foreach (Npc item4 in from _ in source2
				where HasSpawnedBefore(_.id)
				orderby rng2.Next()
				select _)
			{
				if (list5.Count == 6)
				{
					break;
				}
				if (!list5.Contains(item4) && !IsHumanDuplicateBlocked(item4, humanCustomers))
				{
					list5.Add(item4);
					RegisterHuman(item4, humanCustomers);
				}
			}
		}
		if (list5.Count > 6)
		{
			list5 = list5.Take(6).ToList();
		}
		List<Npc> weirdOrdered = SortByWeirdEntertainmentOrder(list5);
		return EnforceFixedIndices(weirdOrdered, dictionary, list5);
	}

	private bool HasSpawnedBefore(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return false;
		}
		if (spawnedBefore == null || spawnedBefore.Length == 0)
		{
			return false;
		}
		return Array.IndexOf(spawnedBefore, id) >= 0;
	}

	private string GetHumanBaseId(string id)
	{
		string text = NormalizeId(id);
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		int num = text.LastIndexOf(' ');
		if (num > 0 && num < text.Length - 1 && int.TryParse(text.Substring(num + 1), out var _))
		{
			return text.Substring(0, num).Trim();
		}
		return text;
	}

	private void RegisterHuman(Npc npc, HashSet<string> humanCustomers)
	{
		if (!(npc == null) && !npc.isDoppelganger)
		{
			string humanBaseId = GetHumanBaseId(npc.id);
			if (!string.IsNullOrEmpty(humanBaseId))
			{
				humanCustomers.Add(humanBaseId);
			}
		}
	}

	private bool IsHumanDuplicateBlocked(Npc npc, HashSet<string> humanCustomers)
	{
		if (npc == null || npc.isDoppelganger)
		{
			return false;
		}
		string humanBaseId = GetHumanBaseId(npc.id);
		if (!string.IsNullOrEmpty(humanBaseId))
		{
			return humanCustomers.Contains(humanBaseId);
		}
		return false;
	}

	private bool AllMustHaveSpawnedAreMet(Npc n)
	{
		if (n.mustHaveSpawnedBefore == null || n.mustHaveSpawnedBefore.Length == 0)
		{
			return true;
		}
		string[] mustHaveSpawnedBefore = n.mustHaveSpawnedBefore;
		foreach (string text in mustHaveSpawnedBefore)
		{
			if (!string.IsNullOrEmpty(text) && !HasSpawnedBefore(text))
			{
				return false;
			}
		}
		return true;
	}

	private bool IsAliveGatePassed(Npc n)
	{
		if (n.mustBeAliveToSpawn == null || n.mustBeAliveToSpawn.Length == 0)
		{
			return true;
		}
		HashSet<string> hashSet = (from k in SaveManager.Instance.npcsKilled
			where !string.IsNullOrEmpty(k)
			select k.ToLower().Replace(" ", "")).ToHashSet();
		string[] mustBeAliveToSpawn = n.mustBeAliveToSpawn;
		foreach (string text in mustBeAliveToSpawn)
		{
			if (!string.IsNullOrEmpty(text))
			{
				string item = text.ToLower().Replace(" ", "");
				if (hashSet.Contains(item))
				{
					return false;
				}
			}
		}
		return true;
	}

	private List<Npc> ApplyRelaxableFilter(List<Npc> currentPool, Func<List<Npc>, List<Npc>> filter)
	{
		List<Npc> list = filter(currentPool);
		if (list.Count < 6)
		{
			return currentPool;
		}
		return list;
	}

	private List<Npc> PickWithDoppelBalanceConsideringSeed(List<Npc> pool, List<Npc> seed, int needed, HashSet<string> humanCustomers)
	{
		System.Random rng = new System.Random();
		int num = seed.Count((Npc n) => n.isDoppelganger);
		int num2 = seed.Count - num;
		List<Npc> list = (from _ in pool
			where _.isDoppelganger
			orderby rng.Next()
			select _).ToList();
		List<Npc> list2 = (from _ in pool
			where !_.isDoppelganger
			orderby rng.Next()
			select _).ToList();
		List<Npc> list3 = new List<Npc>(needed);
		while (list3.Count < needed && num + list3.Count((Npc x) => x.isDoppelganger) < 2 && list.Count > 0)
		{
			Npc npc = list[0];
			list.RemoveAt(0);
			if (!seed.Contains(npc) && !IsHumanDuplicateBlocked(npc, humanCustomers))
			{
				list3.Add(npc);
				RegisterHuman(npc, humanCustomers);
			}
		}
		while (list3.Count < needed && num2 + list3.Count((Npc x) => !x.isDoppelganger) < 2 && list2.Count > 0)
		{
			Npc npc2 = list2[0];
			list2.RemoveAt(0);
			if (!seed.Contains(npc2) && !IsHumanDuplicateBlocked(npc2, humanCustomers))
			{
				list3.Add(npc2);
				RegisterHuman(npc2, humanCustomers);
			}
		}
		foreach (Npc item in pool.OrderBy((Npc _) => rng.Next()))
		{
			if (list3.Count >= needed)
			{
				break;
			}
			if (!seed.Contains(item) && !list3.Contains(item) && !IsHumanDuplicateBlocked(item, humanCustomers))
			{
				list3.Add(item);
				RegisterHuman(item, humanCustomers);
			}
		}
		return list3.Take(needed).ToList();
	}

	private void TryRebalanceMinCounts(List<Npc> result, List<Npc> dops, List<Npc> hums, System.Random rng)
	{
		int num = result.Count((Npc n) => n.isDoppelganger);
		int num2 = result.Count - num;
		if (num < 2)
		{
			Npc npc = dops.FirstOrDefault((Npc n) => !result.Contains(n));
			Npc npc2 = result.FirstOrDefault((Npc n) => !n.isDoppelganger);
			if ((bool)npc && (bool)npc2)
			{
				result.Remove(npc2);
				result.Add(npc);
			}
		}
		if (num2 < 2)
		{
			Npc npc3 = hums.FirstOrDefault((Npc n) => !result.Contains(n));
			Npc npc4 = result.FirstOrDefault((Npc n) => n.isDoppelganger);
			if ((bool)npc3 && (bool)npc4)
			{
				result.Remove(npc4);
				result.Add(npc3);
			}
		}
	}

	private List<Npc> SortByWeirdEntertainmentOrder(List<Npc> six)
	{
		if (six == null || six.Count == 0)
		{
			return six;
		}
		List<Npc> list = six.OrderByDescending((Npc n) => n.entertainment).ToList();
		int[] array = new int[6] { 4, 1, 5, 2, 3, 0 };
		List<Npc> list2 = new List<Npc>();
		for (int num = 0; num < array.Length && num < list.Count; num++)
		{
			int num2 = array[num];
			if (num2 < list.Count)
			{
				list2.Add(list[num2]);
			}
		}
		int num3 = 0;
		while (list2.Count < 6 && num3 < list.Count)
		{
			if (!list2.Contains(list[num3]))
			{
				list2.Add(list[num3]);
			}
			num3++;
		}
		return list2.Take(6).ToList();
	}

	private List<Npc> EnforceFixedIndices(List<Npc> weirdOrdered, Dictionary<int, Npc> forcedFixedIndex, List<Npc> selectedAll)
	{
		Dictionary<int, Npc> dictionary = new Dictionary<int, Npc>(forcedFixedIndex);
		foreach (Npc item in selectedAll)
		{
			if (item.alwaysOnlySpawnOnThisIndex >= 0 && item.alwaysOnlySpawnOnThisIndex < 6)
			{
				if (!dictionary.ContainsKey(item.alwaysOnlySpawnOnThisIndex))
				{
					dictionary[item.alwaysOnlySpawnOnThisIndex] = item;
				}
				else if (dictionary[item.alwaysOnlySpawnOnThisIndex] != item)
				{
					Debug.LogWarning($"[EndlessGeneration] Index conflict at {item.alwaysOnlySpawnOnThisIndex} between '{dictionary[item.alwaysOnlySpawnOnThisIndex].id}' and '{item.id}'. Keeping the first.");
				}
			}
			else if (item.alwaysOnlySpawnOnThisIndex != -1)
			{
				Debug.LogWarning($"[EndlessGeneration] NPC '{item.id}' selected with invalid index {item.alwaysOnlySpawnOnThisIndex}. Ignoring index lock.");
			}
		}
		Npc[] array = new Npc[6];
		HashSet<Npc> hashSet = new HashSet<Npc>();
		foreach (KeyValuePair<int, Npc> item2 in dictionary)
		{
			int key = item2.Key;
			Npc value = item2.Value;
			if (selectedAll.Contains(value) && key >= 0 && key < 6)
			{
				if (array[key] == null)
				{
					array[key] = value;
					hashSet.Add(value);
				}
				else if (array[key] != value)
				{
					Debug.LogWarning($"[EndlessGeneration] Slot {key} already filled by '{array[key].id}'. Could not place '{value.id}' at its requested index.");
				}
			}
		}
		foreach (Npc item3 in weirdOrdered)
		{
			if (hashSet.Contains(item3))
			{
				continue;
			}
			for (int i = 0; i < 6; i++)
			{
				if (array[i] == null)
				{
					array[i] = item3;
					hashSet.Add(item3);
					break;
				}
			}
		}
		return array.Where((Npc x) => x != null).Take(6).ToList();
	}

	private static string NormalizeId(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return string.Empty;
		}
		string text = input.Normalize(NormalizationForm.FormKC);
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		string text2 = text;
		foreach (char c in text2)
		{
			if (!char.IsControl(c) && c != '\u200b' && c != '\ufeff')
			{
				stringBuilder.Append(c);
			}
		}
		return Regex.Replace(stringBuilder.ToString(), "\\s+", " ").Trim().ToLowerInvariant();
	}
}
