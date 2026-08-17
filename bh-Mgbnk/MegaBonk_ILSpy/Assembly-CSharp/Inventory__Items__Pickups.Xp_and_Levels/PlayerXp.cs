using System;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Inventory__Items__Pickups.Xp_and_Levels;

public class PlayerXp
{
	public int xp;

	public int level;

	public static float maxXpMultiplier = 10f;

	public static Action<int> A_LevelUp;

	public static Action<PlayerXp, int> A_XpAdded;

	private float leftOverXp;

	public void AddXp(int amount)
	{
		//IL_0159: Invalid comparison between I4 and F4
		//IL_0168: Expected F4, but got I4
		//IL_008a: Invalid comparison between F8 and I4
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected I4, but got Unknown
		float stat = PlayerStats.GetStat(EStat.XpIncreaseMultiplier);
		bool flag = 0f > stat;
		float num = 0f;
		if (!flag)
		{
			num = maxXpMultiplier;
			if (!(stat > maxXpMultiplier))
			{
				num = stat;
			}
		}
		double num2 = (double)amount * (double)num;
		double num3 = Math.Floor(num2);
		double num4 = num2 - num3;
		double num5 = num4 + (double)leftOverXp;
		leftOverXp = (float)num5;
		double num6 = Math.Floor(num5);
		bool flag2 = !(num6 > 0.0);
		double num7 = num3;
		double num8 = num3;
		if (!flag2)
		{
			num8 = num3 + num6;
			num7 = (double)leftOverXp - num6;
			leftOverXp = (float)num7;
		}
		int num9 = (int)(xp + num8);
		xp = num9;
		Action<PlayerXp, int> a_XpAdded = A_XpAdded;
		if (A_XpAdded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v208 @ r10_v1 (System.Action`2<Inventory__Items__Pickups.Xp_and_Levels.PlayerXp, System.Int32>)+18] (should have been resolved before IL gen)");
		}
		int num10 = XpUtility.XpToLevel(xp);
		if (num10 > level)
		{
			level = num10;
			Action<int> a_LevelUp = A_LevelUp;
			if (A_LevelUp != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ r9_v3 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public int GetXpInt()
	{
		//IL_0010: Expected F8, but got I4
		//IL_0019: Expected I4, but got F8
		double num = Math.Floor((double)xp);
		return (int)num;
	}
}
