using System;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Spawning.New;

public class EnemyCard
{
	private float costInfluenceOnWeight = 0.6f;

	public EnemyData enemy;

	public bool isElite;

	public float cost = 1f;

	public float weight = 1f;

	public EnemyCard(EnemyData enemy, bool isElite)
	{
		this.isElite = isElite;
		this.enemy = enemy;
		RefreshWeightAndCost();
	}

	public void RefreshWeightAndCost()
	{
		EnemyData enemyData = enemy;
		cost = enemyData.creditCost;
		bool flag = !isElite;
		weight = 1f;
		if (!flag)
		{
			float num;
			if (PlayerStats.HasStats())
			{
				float stat = PlayerStats.GetStat(EStat.EliteSpawnIncrease);
				num = stat;
			}
			else
			{
				num = 1f;
			}
			float num2 = num * 0.04f;
			float num3 = cost + cost;
			float num4 = num2 * weight;
			cost = num3;
			weight = num4;
		}
	}

	public new string ToString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172A1B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)enemy != null)
		{
			string s = enemy.ToString();
			string text = EnumUtility.EnumToReadable(s);
			bool flag = !isElite;
			string arg = text;
			if (!flag)
			{
				string text2 = "Elite " + text;
				arg = text2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			object arg3 = default(object);
			return $"{arg} |Cost: {arg2} | Weight: {arg3}";
		}
		return (string)(object)new NullReferenceException();
	}
}
