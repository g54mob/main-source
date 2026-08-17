using System;
using System.Collections.Generic;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class StatInventory
{
	public Dictionary<EStat, List<StatModifier>> permanentChanges;

	public Dictionary<EStat, List<TemporaryStat>> temporaryChanges;

	public Dictionary<string, StatModifier> movingStats;

	public static Action<EStat> A_StatsChanged;

	private HashSet<EStat> refreshStats;

	public void ChangeStat(StatModifier stat, bool permanent, float timeout, bool addToShrineLog)
	{
		//IL_0031: Expected F4, but got I
		//IL_006e: Expected F4, but got O
		//IL_00da: Expected O, but got I
		//IL_0133: Expected O, but got I
		if (!permanent)
		{
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)temporaryChanges).ContainsKey((System.Int32Enum)stat.stat);
			float expirationTime = 0f;
			if (!flag)
			{
				List<TemporaryStat> list = new List<TemporaryStat>();
				((Dictionary<System.Int32Enum, object>)(object)temporaryChanges).Add((System.Int32Enum)stat.stat, (object)list);
				expirationTime = (float)list;
			}
			TemporaryStat temporaryStat = new TemporaryStat(null, expirationTime);
			temporaryStat.modifier = stat;
			float expirationTime2 = MyTime.time + timeout;
			temporaryStat.expirationTime = expirationTime2;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)temporaryChanges).get_Item((System.Int32Enum)stat.stat);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v30 (System.Object)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v30 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v30 (System.Object)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v25+18]");
			if (num >= 0)
			{
				((List<object>)obj).AddWithResize((object)temporaryStat);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v30 (System.Object)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
		}
		else
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)permanentChanges).ContainsKey((System.Int32Enum)stat.stat))
			{
				List<StatModifier> value = new List<StatModifier>();
				((Dictionary<System.Int32Enum, object>)(object)permanentChanges).Add((System.Int32Enum)stat.stat, (object)value);
			}
			object obj4 = ((Dictionary<System.Int32Enum, object>)(object)permanentChanges).get_Item((System.Int32Enum)stat.stat);
			((List<StatModifier>)obj4).Add(stat);
			object obj5 = default(object);
			if (obj5 != null && UiManager.Instance != null)
			{
				UiManager instance = UiManager.Instance;
				instance.shrineLogs.AddLog(stat);
			}
		}
		bool flag2 = refreshStats.Add(stat.stat);
	}

	public void ChangeMovingStat(string name, StatModifier statModifier)
	{
		((Dictionary<object, object>)(object)movingStats).set_Item((object)name, (object)statModifier);
		bool flag = refreshStats.Add(statModifier.stat);
	}

	public void RemoveMovingStat(string name)
	{
		if (movingStats.ContainsKey(name))
		{
			StatModifier statModifier = movingStats.get_Item(name);
			bool flag = ((Dictionary<object, object>)(object)movingStats).Remove((object)name);
			bool flag2 = refreshStats.Add(statModifier.stat);
		}
	}

	public unsafe void Tick()
	{
		//IL_008b: Expected O, but got Ref
		//IL_00ae: Expected O, but got Ref
		if (temporaryChanges != null)
		{
			int count = temporaryChanges.Count;
			if (count <= 0)
			{
				goto IL_02a3;
			}
			List<EStat> list = new List<EStat>();
			if (temporaryChanges != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
				Dictionary<EStat, List<TemporaryStat>>.Enumerator enumerator = default(Dictionary<EStat, List<TemporaryStat>>.Enumerator);
				List<TemporaryStat> list2 = default(List<TemporaryStat>);
				System.Int32Enum int32Enum = default(System.Int32Enum);
				while (enumerator.MoveNext())
				{
					bool flag = list2 == null;
					List<TemporaryStat> list3 = (List<TemporaryStat>)(&enumerator);
					if (!flag)
					{
						int num = list2._size;
						list3 = (List<TemporaryStat>)(&enumerator);
						while (true)
						{
							num--;
							if (num < 0)
							{
								break;
							}
							TemporaryStat temporaryStat = list2.get_Item(num);
							if (temporaryStat != null)
							{
								if (!(MyTime.time < temporaryStat.expirationTime))
								{
									((List<object>)(object)list2).RemoveAt(num);
									if (refreshStats == null)
									{
										throw new NullReferenceException();
									}
									bool flag2 = refreshStats.Add((EStat)int32Enum);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						if (list2._size <= 0)
						{
							if (list == null)
							{
								throw new NullReferenceException();
							}
							list.Add((EStat)int32Enum);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				enumerator.Dispose();
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
					List<EStat>.Enumerator enumerator2 = default(List<EStat>.Enumerator);
					while (enumerator2.MoveNext())
					{
						if (temporaryChanges != null)
						{
							bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)temporaryChanges).Remove(int32Enum);
							continue;
						}
						throw new NullReferenceException();
					}
					enumerator2.Dispose();
					goto IL_02a3;
				}
			}
		}
		goto IL_0256;
		IL_02a3:
		HashSet<EStat> hashSet = refreshStats;
		if (refreshStats != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v20 (System.Collections.Generic.HashSet`1<Assets.Scripts.Menu.Shop.EStat>)+20]");
			if ((nint)0 <= (nint)0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18106E6B0");
			HashSet<EStat>.Enumerator enumerator3 = default(HashSet<EStat>.Enumerator);
			while (enumerator3.MoveNext())
			{
				Action<EStat> a_StatsChanged = A_StatsChanged;
				if (A_StatsChanged != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v572 @ rax_v30 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
				}
			}
			enumerator3.Dispose();
			HashSet<EStat> hashSet2 = (HashSet<EStat>)(object)new HashSet<System.Int32Enum>();
			refreshStats = hashSet2;
			return;
		}
		goto IL_0256;
		IL_0256:
		throw new NullReferenceException();
	}

	public StatInventory()
	{
		Dictionary<EStat, List<StatModifier>> dictionary = new Dictionary<EStat, List<StatModifier>>();
		permanentChanges = dictionary;
		Dictionary<EStat, List<TemporaryStat>> dictionary2 = new Dictionary<EStat, List<TemporaryStat>>();
		temporaryChanges = dictionary2;
		Dictionary<string, StatModifier> dictionary3 = new Dictionary<string, StatModifier>();
		movingStats = dictionary3;
		HashSet<EStat> hashSet = (HashSet<EStat>)(object)new HashSet<System.Int32Enum>();
		refreshStats = hashSet;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
