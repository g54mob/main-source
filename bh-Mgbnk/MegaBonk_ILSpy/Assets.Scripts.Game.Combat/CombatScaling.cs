using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Combat;

public static class CombatScaling
{
	private static float speedMultiplicationPerMinute = 0.025f;

	private static float hpMultiplicationPerMinute = 0.1f;

	private static float damageMultiplicationPerMinute = 0.028f;

	private static float knockbackResistancePerMinute = 0.028f;

	private static float stageSpeedMultiplier = 0.15f;

	private static float stageDamageMultiplier = 0.5f;

	private static float stageKnockbackResMultiplier = 0.5f;

	private static float GetMinutes()
	{
		return MyTime.difficultyTimer / 60f;
	}

	public static float GetStageMultiplier()
	{
		//IL_0010: Expected F4, but got I4
		return MapController.index;
	}

	public static float GetStageSpeedMultiplier()
	{
		//IL_0087: Expected F4, but got I4
		if (MapController.index != 0)
		{
			if (MapController.index != 1)
			{
				if (MapController.index != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					return 5f - 1f;
				}
				return 0.46f;
			}
			return 0.18f;
		}
		return 0f;
	}

	public static float GetStageHpMultiplier()
	{
		//IL_00b5: Expected F4, but got I4
		float stat = PlayerStats.GetStat(EStat.Difficulty);
		float num = stat * 0.45f;
		if (MapController.index != 0)
		{
			float num2 = num + 1f;
			if (MapController.index != 1)
			{
				if (MapController.index != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					return 20f - 1f;
				}
				return num2 * 145f;
			}
			return num2 * 27f;
		}
		return 0f;
	}

	public static float GetStageDamageMultiplier()
	{
		//IL_0087: Expected F4, but got I4
		if (MapController.index != 0)
		{
			if (MapController.index != 1)
			{
				if (MapController.index != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					return 20f - 1f;
				}
				return 4f;
			}
			return 2f;
		}
		return 0f;
	}

	public unsafe static float GetSpeedMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		//IL_01e0: Expected Ref, but got F4
		//IL_002c: Invalid comparison between I4 and F4
		//IL_0089: Expected F4, but got I4
		//IL_013f: Expected Ref, but got F4
		//IL_0123: Expected F4, but got I4
		//IL_016f: Expected Ref, but got F4
		//IL_0186: Expected O, but got F4
		float num = MyTime.difficultyTimer / 60f;
		float stat = PlayerStats.GetStat(EStat.EnemyScalingMultiplier);
		float num2 = speedMultiplicationPerMinute * num;
		float num3 = stat * num2;
		ref float reference = ref *(float*)num3;
		float finalSwarmMultiplier = GetFinalSwarmMultiplier();
		float num4 = finalSwarmMultiplier * 0.5f;
		if (!(0f > num4))
		{
			bool flag = !(num4 > 20f);
			float num5 = 20f;
			if (!flag)
			{
				num5 = 20f;
				num4 = 20f;
			}
		}
		else
		{
			num4 = 0f;
		}
		ref float reference2 = ref *(float*)num4;
		float num6;
		if (MapController.index != 0)
		{
			if (MapController.index != 1)
			{
				if (MapController.index != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					num6 = 5f - 1f;
				}
				else
				{
					num6 = 0.46f;
				}
			}
			else
			{
				num6 = 0.18f;
			}
		}
		else
		{
			num6 = 0f;
		}
		ref float reference3 = ref *(float*)num6;
		object obj = baseAddition + swarmAddition;
		return (float)obj + num6;
	}

	public unsafe static float GetHpMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		//IL_0190: Expected Ref, but got F4
		//IL_01c9: Expected Ref, but got F4
		//IL_00bd: Expected F4, but got I4
		//IL_011f: Expected Ref, but got F4
		//IL_0136: Expected O, but got F4
		float num = MyTime.difficultyTimer / 60f;
		float stat = PlayerStats.GetStat(EStat.EnemyScalingMultiplier);
		float num2 = hpMultiplicationPerMinute * num;
		float num3 = stat * num2;
		ref float reference = ref *(float*)num3;
		float num4 = MyTime.finalSwarmTimer / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float num5 = 4f - 1f;
		ref float reference2 = ref *(float*)num5;
		float stat2 = PlayerStats.GetStat(EStat.Difficulty);
		float num6 = stat2 * 0.45f;
		float num8;
		if (MapController.index != 0)
		{
			float num7 = num6 + 1f;
			if (MapController.index != 1)
			{
				if (MapController.index != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					num8 = 20f - 1f;
				}
				else
				{
					num8 = num7 * 145f;
				}
			}
			else
			{
				num8 = num7 * 27f;
			}
		}
		else
		{
			num8 = 0f;
		}
		ref float reference3 = ref *(float*)num8;
		object obj = baseAddition + swarmAddition;
		return (float)obj + num8;
	}

	public unsafe static float GetDamageMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		//IL_0131: Expected Ref, but got F4
		//IL_016a: Expected Ref, but got F4
		//IL_009a: Expected F4, but got I4
		//IL_00c0: Expected Ref, but got F4
		//IL_00d7: Expected O, but got F4
		float num = MyTime.difficultyTimer / 60f;
		float stat = PlayerStats.GetStat(EStat.EnemyScalingMultiplier);
		float num2 = damageMultiplicationPerMinute * num;
		float num3 = stat * num2;
		ref float reference = ref *(float*)num3;
		float num4 = MyTime.finalSwarmTimer / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float num5 = 2f - 1f;
		ref float reference2 = ref *(float*)num5;
		float num6;
		if (MapController.index != 0)
		{
			bool flag = MapController.index == 1;
			num6 = 2f;
			if (!flag)
			{
				if (MapController.index != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					num6 = 20f - 1f;
				}
				else
				{
					num6 = 4f;
				}
			}
		}
		else
		{
			num6 = 0f;
		}
		ref float reference3 = ref *(float*)num6;
		object obj = baseAddition + swarmAddition;
		return (float)obj + num6;
	}

	public unsafe static float GetKnockbackResistanceMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		//IL_009d: Expected Ref, but got F4
		//IL_00ae: Expected Ref, but got F4
		//IL_0022: Expected Ref, but got F4
		//IL_0039: Expected O, but got F4
		float num = MyTime.difficultyTimer / 60f;
		float stat = PlayerStats.GetStat(EStat.EnemyScalingMultiplier);
		float num2 = knockbackResistancePerMinute * num;
		float num3 = stat * num2;
		ref float reference = ref *(float*)num3;
		float finalSwarmMultiplier = GetFinalSwarmMultiplier();
		ref float reference2 = ref *(float*)finalSwarmMultiplier;
		float stageMultiplier = GetStageMultiplier();
		float num4 = stageMultiplier * stageKnockbackResMultiplier;
		ref float reference3 = ref *(float*)num4;
		object obj = baseAddition + swarmAddition;
		return (float)obj + num4;
	}

	public static float GetFinalSwarmMultiplier()
	{
		float num = MyTime.finalSwarmTimer / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		return 4f - 1f;
	}

	public static float GetFinalSwarmHpMultiplier()
	{
		float num = MyTime.finalSwarmTimer / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		return 4f - 1f;
	}

	public static float GetFinalSwarmDamageMultiplier()
	{
		float num = MyTime.finalSwarmTimer / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		return 2f - 1f;
	}

	public static float GetSwarmSpeedMultiplier()
	{
		//IL_0027: Invalid comparison between I4 and F4
		//IL_006a: Expected F4, but got I4
		float finalSwarmMultiplier = GetFinalSwarmMultiplier();
		float num = finalSwarmMultiplier * 0.5f;
		if (!(0f > num))
		{
			if (num > 20f)
			{
				return 20f;
			}
		}
		else
		{
			num = 0f;
		}
		return num;
	}
}
