using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.Progression;

[Serializable]
public class MapProgress
{
	public HashSet<int> tierNotifications;

	public HashSet<int> tierChallengeNotifications;

	public bool newMapNotification;

	public int lastSelectTier;

	public List<int> completedTiers;

	public Dictionary<int, HashSet<ECharacter>> tierCompletionsWithCharacters;

	public Dictionary<int, int> numRunsByTier;

	public Dictionary<int, float> tierHighscores;

	public Dictionary<int, float> tierFastestTimes;

	public void OnRunFinished(ECharacter character, bool victory, int tier)
	{
		if (!numRunsByTier.ContainsKey(tier))
		{
			numRunsByTier.set_Item(tier, 0);
		}
		int num = numRunsByTier.get_Item(tier);
		int value = num + 1;
		numRunsByTier.set_Item(tier, value);
		if (victory)
		{
			if (!tierCompletionsWithCharacters.ContainsKey(tier))
			{
				HashSet<ECharacter> value2 = (HashSet<ECharacter>)(object)new HashSet<System.Int32Enum>();
				((Dictionary<int, object>)(object)tierCompletionsWithCharacters).Add(tier, (object)value2);
			}
			HashSet<ECharacter> hashSet = tierCompletionsWithCharacters.get_Item(tier);
			bool flag = hashSet.Add(character);
			CompleteTier(tier);
		}
	}

	public int GetNumTierRuns(int tier)
	{
		//IL_00a3: Expected I4, but got O
		if (numRunsByTier != null)
		{
			if (!numRunsByTier.ContainsKey(tier))
			{
				if (numRunsByTier == null)
				{
					goto IL_0095;
				}
				numRunsByTier.set_Item(tier, 0);
			}
			if (numRunsByTier != null)
			{
				return numRunsByTier.get_Item(tier);
			}
		}
		goto IL_0095;
		IL_0095:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public List<ECharacter> GetTierCompletionCharacters(int tier)
	{
		if (tierCompletionsWithCharacters != null)
		{
			if (!tierCompletionsWithCharacters.ContainsKey(tier))
			{
				HashSet<ECharacter> value = (HashSet<ECharacter>)(object)new HashSet<System.Int32Enum>();
				if (tierCompletionsWithCharacters == null)
				{
					goto IL_00b5;
				}
				((Dictionary<int, object>)(object)tierCompletionsWithCharacters).set_Item(tier, (object)value);
			}
			if (tierCompletionsWithCharacters != null)
			{
				HashSet<ECharacter> source = tierCompletionsWithCharacters.get_Item(tier);
				return (List<ECharacter>)(object)Enumerable.ToList((IEnumerable<System.Int32Enum>)source);
			}
		}
		goto IL_00b5;
		IL_00b5:
		return (List<ECharacter>)(object)new NullReferenceException();
	}

	public void CompleteTier(int tier)
	{
		//IL_0058: Expected O, but got I
		//IL_00b1: Expected O, but got I
		if (!completedTiers.Contains(tier))
		{
			List<int> list = completedTiers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v5+18]");
			if (num >= 0)
			{
				list.AddWithResize(tier);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj2 = (nint)0 + (nint)1;
			}
			int item = tier + 1;
			bool flag = tierNotifications.Add(item);
			bool flag2 = tierChallengeNotifications.Add(tier);
		}
	}

	public bool IsTierCompleted(int tier)
	{
		//IL_002b: Expected I4, but got O
		if (completedTiers != null)
		{
			return completedTiers.Contains(tier);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void SetCompletedTime(float time)
	{
		if (tierFastestTimes.ContainsKey(lastSelectTier))
		{
			float num = tierFastestTimes.get_Item(lastSelectTier);
			if (!(num > time))
			{
				return;
			}
		}
		tierFastestTimes.set_Item(lastSelectTier, time);
	}

	public void SetKills(int kills)
	{
		//IL_007c: Expected F4, but got I4
		//IL_0050: Invalid comparison between I4 and F4
		if (tierHighscores.ContainsKey(lastSelectTier))
		{
			float num = tierHighscores.get_Item(lastSelectTier);
			if (!((float)kills > num))
			{
				return;
			}
		}
		tierHighscores.set_Item(lastSelectTier, (float)kills);
	}

	public string GetTierHighscoreString(int tier)
	{
		if (tierHighscores != null)
		{
			if (!tierHighscores.ContainsKey(tier))
			{
				return "-";
			}
			if (tierHighscores != null)
			{
				float number = tierHighscores.get_Item(tier);
				string text = DamageNumbers.FormatDamageNumber(number);
				return "<size=110%><sprite name=skull></size> " + text;
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe string GetTierFastestTimeString(int tier)
	{
		//IL_0114: Expected O, but got I
		if (tierFastestTimes.ContainsKey(tier))
		{
			if (tierFastestTimes != null)
			{
				float num = tierFastestTimes.get_Item(tier);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
				TimeSpan timeSpan = TimeSpan.FromSeconds(0.0);
				TimeSpan timeSpan2 = default(TimeSpan);
				int seconds = timeSpan2.Seconds;
				int milliseconds = timeSpan2.Milliseconds;
				float num2 = (float)milliseconds / 1000f;
				float num3 = num2 + (float)seconds;
				int minutes = timeSpan2.Minutes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				double num4 = Math.Floor(num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B60]");
				object obj = default(object);
				float num5 = ((Dictionary<int, float>)0).get_Item((int)(&obj));
				float num6 = num3 * 10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				object arg2 = default(object);
				object arg3 = default(object);
				string text = $"{arg:D2}:{arg2:00}<size=75%>.{arg3}</size>";
				return "<size=110%><sprite name=clock></size> " + text;
			}
			return (string)(object)new NullReferenceException();
		}
		return "-";
	}

	public MapProgress()
	{
		HashSet<int> hashSet = new HashSet<int>();
		tierNotifications = hashSet;
		HashSet<int> hashSet2 = new HashSet<int>();
		tierChallengeNotifications = hashSet2;
		List<int> list = new List<int>();
		completedTiers = list;
		Dictionary<int, HashSet<ECharacter>> dictionary = new Dictionary<int, HashSet<ECharacter>>();
		tierCompletionsWithCharacters = dictionary;
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		numRunsByTier = dictionary2;
		Dictionary<int, float> dictionary3 = new Dictionary<int, float>();
		tierHighscores = dictionary3;
		Dictionary<int, float> dictionary4 = new Dictionary<int, float>();
		tierFastestTimes = dictionary4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
