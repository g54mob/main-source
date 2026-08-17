using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public class StatTrackingUtility
{
	private static HashSet<EEnemy> skeletonEnemies;

	private static HashSet<EEnemy> wispEnemies;

	private static HashSet<EEnemy> goblinEnemies;

	private static Dictionary<ECharacter, string> keysKillsCharacters;

	private static Dictionary<EEnemy, string> keysKillsEnemies;

	private static Dictionary<string, string> keysKillsSources;

	public static bool IsSkeleton(Enemy enemy)
	{
		//IL_007c: Expected I4, but got O
		if ((object)enemy != null)
		{
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if ((object)enemy._003CenemyData_003Ek__BackingField != null && skeletonEnemies != null)
			{
				return skeletonEnemies.Contains(enemyData.enemyName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static bool IsWisp(Enemy enemy)
	{
		//IL_007c: Expected I4, but got O
		if ((object)enemy != null)
		{
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if ((object)enemy._003CenemyData_003Ek__BackingField != null && wispEnemies != null)
			{
				return wispEnemies.Contains(enemyData.enemyName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static bool IsGoblin(Enemy enemy)
	{
		//IL_007c: Expected I4, but got O
		if ((object)enemy != null)
		{
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if ((object)enemy._003CenemyData_003Ek__BackingField != null && goblinEnemies != null)
			{
				return goblinEnemies.Contains(enemyData.enemyName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static string GetKeyKillsCharacter(ECharacter character)
	{
		//IL_0113: Expected O, but got Ref
		//IL_0066: Expected O, but got Ref
		if (((Dictionary<System.Int32Enum, object>)(object)keysKillsCharacters).ContainsKey((System.Int32Enum)character))
		{
			goto IL_00ee;
		}
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		if (text != null)
		{
			char c = text.get_Chars(0);
			char c2 = char.ToLower(c);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
			IntPtr intPtr = default(IntPtr);
			string text2 = ((Enum)(&intPtr)).ToString();
			if (text2 != null)
			{
				string text3 = text2.Substring(1);
				string text4 = default(string);
				string value = text4 + text3 + "Kills";
				if (keysKillsCharacters != null)
				{
					((Dictionary<System.Int32Enum, object>)(object)keysKillsCharacters).Add((System.Int32Enum)character, (object)value);
					goto IL_00ee;
				}
			}
		}
		return (string)(object)new NullReferenceException();
		IL_00ee:
		return (string)((Dictionary<System.Int32Enum, object>)(object)keysKillsCharacters).get_Item((System.Int32Enum)character);
	}

	public unsafe static string GetKeyKillsEnemy(Enemy enemy)
	{
		//IL_004a: Expected O, but got Ref
		//IL_00c9: Expected O, but got Ref
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (((Dictionary<System.Int32Enum, object>)(object)keysKillsEnemies).ContainsKey((System.Int32Enum)enemyData.enemyName))
		{
			goto IL_01b4;
		}
		EnemyData enemyData2 = enemy._003CenemyData_003Ek__BackingField;
		if ((object)enemy._003CenemyData_003Ek__BackingField != null)
		{
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			if (text != null)
			{
				char c = text.get_Chars(0);
				char c2 = char.ToLower(c);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
				if ((object)enemy._003CenemyData_003Ek__BackingField != null)
				{
					IntPtr intPtr2 = default(IntPtr);
					string text2 = ((Enum)(&intPtr2)).ToString();
					if (text2 != null)
					{
						string text3 = text2.Substring(1);
						string text4 = default(string);
						string value = text4 + text3 + "Kills";
						if (keysKillsEnemies != null)
						{
							((Dictionary<System.Int32Enum, object>)(object)keysKillsEnemies).Add((System.Int32Enum)enemyData2.enemyName, (object)value);
							goto IL_01b4;
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
		IL_01b4:
		EnemyData enemyData3 = enemy._003CenemyData_003Ek__BackingField;
		return (string)((Dictionary<System.Int32Enum, object>)(object)keysKillsEnemies).get_Item((System.Int32Enum)enemyData3.enemyName);
	}

	public static string GetKeyKillsSource(DamageContainer dc)
	{
		if (dc != null && keysKillsSources != null)
		{
			if (keysKillsSources.ContainsKey(dc.damageSource))
			{
				goto IL_0169;
			}
			if (dc.damageSource != null)
			{
				char c = dc.damageSource.get_Chars(0);
				char c2 = char.ToLower(c);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
				if (dc.damageSource != null)
				{
					string text = dc.damageSource.Substring(1);
					string text2 = default(string);
					string value = text2 + text + "Kills";
					if (keysKillsSources != null)
					{
						((Dictionary<object, object>)(object)keysKillsSources).Add((object)dc.damageSource, (object)value);
						goto IL_0169;
					}
				}
			}
		}
		goto IL_0134;
		IL_0169:
		if (keysKillsSources != null)
		{
			return keysKillsSources.get_Item(dc.damageSource);
		}
		goto IL_0134;
		IL_0134:
		return (string)(object)new NullReferenceException();
	}

	static StatTrackingUtility()
	{
		HashSet<EEnemy> hashSet = (HashSet<EEnemy>)(object)new HashSet<System.Int32Enum>();
		bool flag = hashSet.Add(EEnemy.Skeleton);
		bool flag2 = hashSet.Add(EEnemy.SkeletonDusty);
		bool flag3 = hashSet.Add(EEnemy.ArmoredSkeleton);
		bool flag4 = hashSet.Add(EEnemy.GoldenSkeleton);
		bool flag5 = hashSet.Add(EEnemy.XpSkeleton);
		bool flag6 = hashSet.Add(EEnemy.ArmoredSkeletonDusty);
		skeletonEnemies = hashSet;
		HashSet<EEnemy> hashSet2 = (HashSet<EEnemy>)(object)new HashSet<System.Int32Enum>();
		bool flag7 = hashSet2.Add(EEnemy.Wisp);
		wispEnemies = hashSet2;
		HashSet<EEnemy> hashSet3 = (HashSet<EEnemy>)(object)new HashSet<System.Int32Enum>();
		bool flag8 = hashSet3.Add(EEnemy.Goblin);
		bool flag9 = hashSet3.Add(EEnemy.GoblinStrong);
		bool flag10 = hashSet3.Add(EEnemy.GoblinTank);
		goblinEnemies = hashSet3;
		Dictionary<ECharacter, string> dictionary = new Dictionary<ECharacter, string>();
		keysKillsCharacters = dictionary;
		Dictionary<EEnemy, string> dictionary2 = new Dictionary<EEnemy, string>();
		keysKillsEnemies = dictionary2;
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
		keysKillsSources = dictionary3;
	}
}
