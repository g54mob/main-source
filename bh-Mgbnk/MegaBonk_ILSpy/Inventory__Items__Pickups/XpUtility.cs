using System;
using Cpp2ILInjected;

namespace Inventory__Items__Pickups;

public class XpUtility
{
	public static float eliteEnemyXpMultiplier = 10f;

	private static int baseXp = 5;

	private static float increaseRate = 1.065f;

	private static float exponent = 1.065f;

	public const int maxLevel = 9999;

	public static int[] xpForLevelsTable;

	public static void Init()
	{
		//IL_00a7: Expected I, but got O
		//IL_00bd: Expected O, but got I
		//IL_00ce: Expected O, but got I4
		//IL_00d7: Expected F4, but got I4
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0047: Expected I4, but got O
		int[] array = (xpForLevelsTable = new int[10000]);
		nint num = (nint)typeof(XpUtility);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v6 (Il2CppClass<Inventory__Items__Pickups.XpUtility>)+B8]");
		object obj = (nint)0 + (nint)16;
		int[] array2 = array;
		object obj2 = 1;
		float num2 = 0f;
		object obj6 = default(object);
		bool flag;
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
			object obj3 = obj2 * increaseRate;
			object obj4 = obj3 * baseXp;
			float num3 = (((nint)obj2 != 1) ? ((float)obj4 + (float)baseXp) : 7f);
			num2 += num3;
			int[] array3 = xpForLevelsTable;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			object obj5 = obj2 + 1;
			array3[obj2] = (int)obj6;
			flag = (nint)obj5 <= 9999;
			array2 = null;
			obj2 = obj5;
			obj = obj5;
		}
		while (flag);
	}

	public static int XpToLevel(int xp)
	{
		//IL_009b: Expected O, but got I4
		//IL_00af: Expected I4, but got O
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected I4, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		object obj = 1;
		while (true)
		{
			int[] array = xpForLevelsTable;
			if ((nint)obj >= array.Length)
			{
				break;
			}
			if (xp >= array[obj])
			{
				obj++;
				if ((nint)obj > 9999)
				{
					return 9999;
				}
				continue;
			}
			return obj - 1;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
	}

	public static int XpToNextLevel(int currentXp)
	{
		//IL_0051: Expected O, but got I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected I4, but got Unknown
		int num = XpToLevel(currentXp);
		int lvl = num + 1;
		int num2 = LevelToXp(lvl);
		int num3 = LevelToXp(num);
		object obj = num2 - num3;
		int lvl2 = XpToLevel(currentXp);
		int num4 = LevelToXp(lvl2);
		object obj2 = obj - currentXp;
		return num4 + obj2;
	}

	public static int XpOnCurrentLevel(int currentXp)
	{
		int lvl = XpToLevel(currentXp);
		int num = LevelToXp(lvl);
		return currentXp - num;
	}

	public static int XpToNextLevelTotal(int currentXp)
	{
		int num = XpToLevel(currentXp);
		int lvl = num + 1;
		int num2 = LevelToXp(lvl);
		int num3 = LevelToXp(num);
		return num2 - num3;
	}

	public static float CurrentLevelProgress(int currentXp)
	{
		//IL_0036: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		int lvl = XpToLevel(currentXp);
		int num = LevelToXp(lvl);
		object obj = currentXp - num;
		int num2 = XpToLevel(currentXp);
		int lvl2 = num2 + 1;
		int num3 = LevelToXp(lvl2);
		int num4 = LevelToXp(num2);
		object obj2 = num3 - num4;
		return (float)obj / (float)obj2;
	}

	public static int LevelToXp(int lvl)
	{
		//IL_0093: Expected I4, but got O
		if (lvl >= 0)
		{
			if (lvl <= 9999)
			{
				int[] array = xpForLevelsTable;
				if (xpForLevelsTable != null)
				{
					return array[lvl];
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			return 9999;
		}
		return 0;
	}

	public static int XpTotalCurrentLevel(int xp)
	{
		int lvl = XpToLevel(xp);
		return LevelToXp(lvl);
	}

	public static int XpTotalNextLevel(int xp)
	{
		int num = XpToLevel(xp);
		int lvl = num + 1;
		return LevelToXp(lvl);
	}
}
