using System;
using System.Collections;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.Progression;

public static class LogUtility
{
	public static int numMaxChallenges = 6;

	public static int GetNumMaxEntries()
	{
		//IL_0067: Expected I4, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EEnemy));
		Array values = Enum.GetValues(typeFromHandle);
		if (values != null)
		{
			return values.System_002ECollections_002EICollection_002ECount;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe static int GetNumUnlockedEntries()
	{
		//IL_0044: Expected O, but got Ref
		//IL_004c: Expected O, but got Ref
		//IL_00b3: Expected I, but got O
		//IL_013e: Expected I4, but got O
		//IL_00f4: Expected O, but got I4
		//IL_019b: Expected I, but got O
		//IL_01a3: Expected I, but got O
		//IL_01d2: Expected I, but got O
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_020a: Expected I, but got O
		//IL_0241: Expected I, but got O
		//IL_0249: Expected O, but got I
		//IL_0286: Expected I, but got O
		//IL_028e: Expected O, but got I
		//IL_02be: Expected I, but got O
		//IL_02eb: Expected I4, but got O
		//IL_030c: Expected I, but got O
		//IL_034f: Expected I, but got O
		//IL_0386: Expected I, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EEnemy));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerator enumerator = values.GetEnumerator();
		IEnumerator enumerator2 = default(IEnumerator);
		object obj = (object)(&enumerator2);
		object obj3 = default(object);
		object obj2 = (object)(&obj3);
		int num = 0;
		Array array = values;
		object obj4 = default(object);
		object obj8 = default(object);
		object obj10 = default(object);
		while (true)
		{
			nint num3;
			if (enumerator2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				if (obj4 != null)
				{
					bool flag = enumerator2 == null;
					array = null;
					if (!flag)
					{
						nint num2 = (nint)enumerator2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v10 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_012b;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v10 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						num3 = 0;
						object obj5 = 0;
						while (true)
						{
							object obj6 = obj5 + obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r8_v2 (Il2CppMethodInfo)+v536 @ rax_v55*8]");
							if (0 != (nint)typeof(IEnumerator))
							{
								obj5++;
								object obj7 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v10 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
								if ((nint)obj7 < 0)
								{
									continue;
								}
								goto IL_012b;
							}
							break;
						}
						goto IL_0150;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				obj2 = obj8;
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				break;
			}
			throw new NullReferenceException();
			IL_0150:
			object current = enumerator2.Current;
			bool flag2 = current == null;
			array = (Array)(object)typeof(LogUtility);
			if (!flag2)
			{
				nint num4 = (nint)typeof(EEnemy);
				nint num5 = (nint)current;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rcx_v23 (Il2CppClass<System.Object>)+40]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v20 (Il2CppClass<Actors.Enemies.EEnemy>)+40]");
				bool flag3 = num6 != 0;
				nint num7 = (nint)typeof(EEnemy);
				array = (Array)current;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					nint num8 = (nint)typeof(SaveManager);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ rax_v41 (Il2CppClass<SaveManager>)+B8]");
					nint num9 = 0;
					SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
					bool flag4 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
					num7 = (nint)typeof(EEnemy);
					array = (Array)num9;
					if (!flag4)
					{
						StatsSaveFile stats = saveManager.stats;
						bool flag5 = saveManager.stats == null;
						num7 = (nint)typeof(EEnemy);
						array = (Array)num9;
						if (!flag5)
						{
							bool flag6 = stats.enemyLogs == null;
							num7 = (nint)typeof(EEnemy);
							array = (Array)(object)stats.enemyLogs;
							if (!flag6)
							{
								object obj9 = ((Dictionary<System.Int32Enum, object>)(object)stats.enemyLogs).get_Item((System.Int32Enum)obj10);
								bool flag7 = obj9 == null;
								num3 = 0;
								num7 = (nint)obj10;
								array = (Array)(object)stats.enemyLogs;
								if (!flag7)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v44 (System.Object)+10]");
									bool flag8 = (nint)0 <= (nint)0;
									nint num10 = (nint)typeof(IEnumerator);
									array = (Array)(object)stats.enemyLogs;
									if (!flag8)
									{
										num++;
										num10 = (nint)typeof(IEnumerator);
										array = (Array)(object)stats.enemyLogs;
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				EnemyLog enemyLog = ((Dictionary<EEnemy, EnemyLog>)(object)array).get_Item((EEnemy)num7);
			}
			throw new NullReferenceException();
			IL_012b:
			EnemyLog enemyLog2 = ((Dictionary<EEnemy, EnemyLog>)enumerator2).get_Item((EEnemy)typeof(IEnumerator));
			num3 = 1;
			goto IL_0150;
		}
		return num;
	}

	public static bool IsEntryUnlocked(EEnemy enemy)
	{
		//IL_015d: Expected I4, but got O
		//IL_00d2: Expected O, but got I
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			if (saveManager.stats != null && stats.enemyLogs != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)stats.enemyLogs).get_Item((System.Int32Enum)enemy);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Object)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Object)+10]");
					object obj2 = num ^ 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Object)+10]");
					object obj3 = 0 & obj2;
					bool flag = (nint)obj3 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Object)+10]");
					bool flag2 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static void GetChallengeProgress(EEnemy eEnemy, out float currentChallengeProgress, out int numChallengesClaimed, out int numKills, out int numKillsForNextChallengeTier)
	{
		//IL_00f5: Expected F8, but got I4
		//IL_0175: Expected O, but got F8
		//IL_01a2: Invalid comparison between I4 and F4
		//IL_0131: Expected F4, but got I4
		//IL_01be: Expected Ref, but got F4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		StatsSaveFile stats = saveManager.stats;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)stats.enemyLogs).get_Item((System.Int32Enum)eEnemy);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v10 (System.Object)+10]");
		ref int reference = ref *(int*)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v10 (System.Object)+14]");
		if ((nint)0 > (nint)0)
		{
			EnemyLog enemyLog = ((Dictionary<EEnemy, EnemyLog>)(object)typeof(LogUtility)).get_Item(eEnemy);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
		}
		EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
		double num3;
		if (enemyData != null)
		{
			float num = 1f / enemyData.creditCost;
			double num2 = Math.Ceiling(num);
			num3 = num2;
		}
		else
		{
			num3 = 0.0;
		}
		object obj2 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v10 (System.Object)+14]");
		ref int reference2 = ref *(int*)null;
		float num4 = (float)numKills / (float)obj2;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		ref float reference3 = ref *(float*)num4;
	}

	public static bool HasUnclaimedReward(EEnemy eEnemy)
	{
		//IL_005c: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected I4, but got Unknown
		ref int numKillsForNextChallengeTier = default(ref int);
		GetChallengeProgress(eEnemy, out var currentChallengeProgress, out var numChallengesClaimed, out var _, out numKillsForNextChallengeTier);
		if (currentChallengeProgress < 1f)
		{
			return false;
		}
		object obj = numChallengesClaimed - numMaxChallenges;
		int num = numChallengesClaimed ^ numMaxChallenges;
		int num2 = numChallengesClaimed ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	public unsafe static bool HasAnyUnclaimedReward()
	{
		//IL_0044: Expected O, but got Ref
		//IL_004c: Expected O, but got Ref
		//IL_00ea: Expected I, but got O
		//IL_00f2: Expected I, but got O
		//IL_0151: Expected I4, but got O
		//IL_0170: Expected O, but got Ref
		//IL_025e: Expected O, but got I4
		//IL_0280: Expected O, but got Ref
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EEnemy));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerator enumerator = values.GetEnumerator();
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int num = default(int);
		object obj3 = (object)(&num);
		Array array = values;
		object obj4 = default(object);
		Array array2 = default(Array);
		object obj5 = default(object);
		ref int numKillsForNextChallengeTier = default(ref int);
		object obj7 = default(object);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				if (obj4 != null)
				{
					bool flag = obj2 == null;
					array = null;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						bool flag2 = array2 == null;
						array = (Array)(object)typeof(LogUtility);
						if (flag2)
						{
							break;
						}
						nint num2 = (nint)typeof(EEnemy);
						nint num3 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rcx_v19 (Il2CppClass<System.Array>)+40]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v15 (Il2CppClass<Actors.Enemies.EEnemy>)+40]");
						bool flag3 = num4 != 0;
						array = array2;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							GetChallengeProgress((EEnemy)obj5, out var currentChallengeProgress, out var numChallengesClaimed, out var numKills, out numKillsForNextChallengeTier);
							bool flag4 = currentChallengeProgress < 1f;
							float num5 = currentChallengeProgress;
							object obj6 = (object)(&numKills);
							array = (Array)obj5;
							if (!flag4)
							{
								array = (Array)numMaxChallenges;
								bool flag5 = numChallengesClaimed >= numMaxChallenges;
								num5 = currentChallengeProgress;
								obj6 = (object)(&numKills);
								if (!flag5)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363560");
									return true;
								}
							}
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						break;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				obj3 = obj7;
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				return false;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public static bool HasClaimedAllRewards(EEnemy eEnemy)
	{
		//IL_00c8: Expected I4, but got O
		//IL_00e8: Expected O, but got I
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected I4, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			if (saveManager.stats != null && stats.enemyLogs != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)stats.enemyLogs).get_Item((System.Int32Enum)eEnemy);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v10 (System.Object)+14]");
					object obj2 = -numMaxChallenges;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v10 (System.Object)+14]");
					int num = (int)((nint)0 ^ (nint)numMaxChallenges);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v10 (System.Object)+14]");
					object obj3 = 0 ^ obj2;
					int num2 = num & obj3;
					bool flag = num2 < 0;
					bool flag2 = (nint)obj2 < 0;
					return flag2 == flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static int GetNumChallengeKills(EEnemy eEnemy, int tier)
	{
		//IL_00bc: Expected I4, but got O
		//IL_0013: Expected O, but got I4
		//IL_00a8: Expected I4, but got F8
		if (tier > 0)
		{
			object obj = tier + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
		}
		if ((object)DataManager.Instance != null)
		{
			EEnemy eEnemy2 = default(EEnemy);
			EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy2);
			if (!(enemyData != null))
			{
				return 0;
			}
			if ((object)enemyData != null)
			{
				float num = 1f / enemyData.creditCost;
				double num2 = Math.Ceiling(num);
				return (int)num2;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static int GetReward(EEnemy eEnemy)
	{
		//IL_00ec: Expected I4, but got O
		//IL_00cb: Expected O, but got I
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected I4, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			if (saveManager.stats != null && stats.enemyLogs != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)stats.enemyLogs).get_Item((System.Int32Enum)eEnemy);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Object)+14]");
					object obj2 = (nint)0 + (nint)1;
					return obj2 * 100;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
