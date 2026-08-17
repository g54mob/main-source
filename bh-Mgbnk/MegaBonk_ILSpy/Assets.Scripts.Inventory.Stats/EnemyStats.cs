using System;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory.Stats;

public static class EnemyStats
{
	private static float overrideMaxSpeedAtTime = 720f;

	private static float maxSpeedMultiplier = 90f;

	private static float maxSpeedMultiplierOverride = 250f;

	private static int maxStunsAndFreezes = 15;

	private static float startStunImmunityAtTime = 1200f;

	private static float decreaseCcImmunityOverTime = 1800f;

	private static int lastFoundCcCap = maxStunsAndFreezes;

	private static float lastFoundCcCapTime;

	private static float startPenetrationAtTime = 3600f;

	private static float penetrationPerMinute = 0.0002f;

	public static float GetHp(Enemy enemy)
	{
		//IL_00f8: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0121: Expected F4, but got O
		//IL_00ce: Expected F4, but got I4
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_0314: Invalid comparison between I4 and F4
		//IL_0326: Expected F4, but got I4
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		float hp;
		float num;
		if (enemyData.enemyName != EEnemy.GoldenSkeleton && enemyData.enemyName != EEnemy.XpSkeleton)
		{
			if (enemyData.enemyName != EEnemy.FrogGreen && enemyData.enemyName != EEnemy.FrogBlue && enemyData.enemyName != EEnemy.FrogRed)
			{
				hp = enemyData.hp;
				goto IL_0355;
			}
			MyPlayer instance = MyPlayer.Instance;
			int characterLevel = instance.inventory.GetCharacterLevel();
			object obj = characterLevel + 25;
			object obj2 = obj * 4;
			object obj3 = obj + obj2;
			num = obj3 << 2;
		}
		else
		{
			MyPlayer instance2 = MyPlayer.Instance;
			int characterLevel2 = instance2.inventory.GetCharacterLevel();
			num = (float)characterLevel2 + 30f;
		}
		hp = num;
		goto IL_0355;
		IL_0355:
		EnemyData enemyData2 = enemy._003CenemyData_003Ek__BackingField;
		if (enemyData2.enemyName != EEnemy.GhostInvincible)
		{
			float enemyHp = MapController.runConfig.GetEnemyHp(hp);
			float stat = PlayerStats.GetStat(EStat.EnemyHpMultiplier);
			float hpMultiplierAddition = CombatScaling.GetHpMultiplierAddition(out var _, out var _, out var _);
			float stat2 = PlayerStats.GetStat(EStat.Difficulty);
			float num2 = hpMultiplierAddition + 1f;
			float num3 = stat2 * 1.1f;
			float num4 = num3 + num2;
			if (!enemy.IsEliteChallenge())
			{
				if (!enemy.IsElite())
				{
					if (enemy.IsChallenge())
					{
						num4 *= 7f;
					}
				}
				else
				{
					num4 *= 10f;
				}
			}
			else
			{
				num4 *= 15f;
			}
			if (enemy.IsBoss())
			{
				if (MapController.index == 1)
				{
					num4 *= 2.5f;
				}
				else if (MapController.index == 2)
				{
					num4 *= 5f;
				}
			}
			float num5 = enemyHp * num4;
			float num6 = num5 * stat;
			object obj4 = num6 & -2147483649L;
			float result;
			if ((nint)obj4 < 2139095040)
			{
				bool flag = !(0f < num6);
				result = 0f;
				if (!flag)
				{
					result = num6;
				}
			}
			else
			{
				result = 3.4028235E+38f;
			}
			return result;
		}
		return 3.4028235E+38f;
	}

	public static float GetSpeed(EnemyData enemyData)
	{
		//IL_0157: Invalid comparison between I4 and F4
		//IL_0319: Invalid comparison between I4 and F4
		//IL_018c: Expected F4, but got I4
		//IL_027a: Expected F4, but got I4
		float num;
		if ((object)enemyData != null)
		{
			bool flag = enemyData.enemyName == EEnemy.GhostKing;
			num = enemyData.speed;
			if (flag)
			{
				goto IL_02a7;
			}
			if (MapController.runConfig != null)
			{
				float enemySpeed = MapController.runConfig.GetEnemySpeed(enemyData.speed);
				float stat = PlayerStats.GetStat(EStat.EnemySpeedMultiplier);
				float speedMultiplierAddition = CombatScaling.GetSpeedMultiplierAddition(out var _, out var _, out var _);
				float stat2 = PlayerStats.GetStat(EStat.Difficulty);
				float num2 = stat2 * 0.5f;
				GameManager instance = GameManager.Instance;
				if ((object)GameManager.Instance != null)
				{
					bool flag2 = !instance._003CisCrypt_003Ek__BackingField;
					float num3 = speedMultiplierAddition + 1f;
					float num4 = num3 + num2;
					if (!flag2)
					{
						GameManager instance2 = GameManager.Instance;
						if ((object)GameManager.Instance == null)
						{
							goto IL_027f;
						}
						float num5 = MyTime.cryptTimer - instance2._003CdungeonTimeToComplete_003Ek__BackingField;
						float num6 = ((!(0f < num5)) ? 0f : (num5 * 0.2f));
						num4 += num6;
					}
					float num10;
					if (!(overrideMaxSpeedAtTime > MyTime.finalSwarmTimer))
					{
						float num7 = MyTime.finalSwarmTimer - overrideMaxSpeedAtTime;
						float num8 = num7 / 60f;
						float num9 = num8 * 6f;
						num10 = num9 + maxSpeedMultiplier;
						if (num10 > maxSpeedMultiplierOverride)
						{
							num10 = maxSpeedMultiplierOverride;
						}
					}
					else
					{
						num10 = maxSpeedMultiplier;
					}
					float num11 = enemySpeed * num4;
					num = num11 * stat;
					if (!(0f > num))
					{
						if (num > num10)
						{
							num = num10;
						}
					}
					else
					{
						num = 0f;
					}
					goto IL_02a7;
				}
			}
		}
		goto IL_027f;
		IL_02a7:
		return num;
		IL_027f:
		throw new NullReferenceException();
	}

	private static float GetMaxSpeed()
	{
		if (!(overrideMaxSpeedAtTime > MyTime.finalSwarmTimer))
		{
			float num = MyTime.finalSwarmTimer - overrideMaxSpeedAtTime;
			float num2 = num / 60f;
			float num3 = num2 * 6f;
			float num4 = num3 + maxSpeedMultiplier;
			if (num4 > maxSpeedMultiplierOverride)
			{
				num4 = maxSpeedMultiplierOverride;
			}
			return num4;
		}
		return maxSpeedMultiplier;
	}

	public static float GetDamage(Enemy enemy)
	{
		//IL_002f: Expected F4, but got I4
		//IL_0130: Invalid comparison between I4 and F4
		//IL_0104: Expected F4, but got I4
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		float enemyDamage = MapController.runConfig.GetEnemyDamage(enemyData.damage);
		float stat = PlayerStats.GetStat(EStat.EnemyDamageMultiplier);
		float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out var _, out var _, out var _);
		float stat2 = PlayerStats.GetStat(EStat.Difficulty);
		float num = damageMultiplierAddition + 1f;
		float num2 = stat2 + num;
		if (enemy.IsElite())
		{
			num2 *= 1.5f;
		}
		float num3 = enemyDamage * num2;
		float num4 = num3 * stat;
		if (!(0f > num4))
		{
			if (num4 > 3.4028235E+38f)
			{
				num4 = 3.4028235E+38f;
			}
		}
		else
		{
			num4 = 0f;
		}
		return num4;
	}

	public static float GetEliteChance(EnemyData enemyData)
	{
		//IL_004b: Expected F4, but got I4
		if (enemyData.canBeElite)
		{
			float stat = PlayerStats.GetStat(EStat.EliteSpawnIncrease);
			return stat * 0.006f;
		}
		return 0f;
	}

	public static float GetKnockbackResistance(Enemy enemy)
	{
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804AD470");
		float knockbackResistanceMultiplierAddition = CombatScaling.GetKnockbackResistanceMultiplierAddition(out var _, out var _, out var _);
		float stat = PlayerStats.GetStat(EStat.Difficulty);
		float num = knockbackResistanceMultiplierAddition + 1f;
		float num2 = stat + num;
		if (enemy.IsElite())
		{
			num2 *= 1.5f;
		}
		float num3 = enemyData.knockbackResistance + 1f;
		object obj = default(object);
		float num4 = num3 + (float)obj;
		return num4 * num2;
	}

	public static int GetCapCC()
	{
		//IL_0018: Expected I, but got O
		if (!(lastFoundCcCapTime < MyTime.time))
		{
			return lastFoundCcCap;
		}
		lastFoundCcCapTime = MyTime.time;
		if (!(startStunImmunityAtTime > MyTime.finalSwarmTimer))
		{
			nint num = (nint)typeof(MyTime);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r8_v3 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+E4]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			int num2 = maxStunsAndFreezes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r8_v3 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
			int num3 = (int)((nint)num2 - (nint)0);
			int result = 0;
			if (!flag)
			{
				result = num3;
			}
			lastFoundCcCap = result;
			return result;
		}
		return maxStunsAndFreezes;
	}

	public static float GetEvasionAndArmorPenetration()
	{
		//IL_0058: Expected F4, but got I4
		if (!(startPenetrationAtTime > MyTime.finalSwarmTimer))
		{
			float num = MyTime.finalSwarmTimer - startPenetrationAtTime;
			float num2 = num / 60f;
			double num3 = Math.Floor(num2);
			return (float)num3 * penetrationPerMinute;
		}
		return 0f;
	}

	private static float GetParkourMultiplier()
	{
		//IL_0023: Invalid comparison between I4 and F4
		//IL_0055: Expected F4, but got I4
		GameManager instance = GameManager.Instance;
		float num = MyTime.cryptTimer - instance._003CdungeonTimeToComplete_003Ek__BackingField;
		if (0f < num)
		{
			return num * 0.2f;
		}
		return 0f;
	}
}
