using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.Combat;

public class DamageUtility
{
	public const string enemyDamageSource = "Enemy";

	private static DamageContainer reuseDc;

	public static DamageContainer GetPlayerDamage(Enemy enemy, Vector3 direction, DcFlags flags)
	{
		//IL_016c: Expected O, but got F4
		//IL_019f: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		//IL_01d5: Expected O, but got I4
		//IL_0225: Expected F4, but got I4
		float damage = EnemyStats.GetDamage(enemy);
		float knockback;
		if ((object)enemy != null && (object)enemy._003CenemyData_003Ek__BackingField != null)
		{
			knockback = enemy._003CenemyData_003Ek__BackingField.GetKnockback();
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if ((object)enemy._003CenemyData_003Ek__BackingField != null)
			{
				if (!enemyData.isPoison)
				{
					goto IL_02a5;
				}
				MyPlayer instance = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory = instance.inventory;
					if (instance.inventory != null && inventory.statusEffects != null)
					{
						inventory.statusEffects.PoisonPlayer(6f);
						goto IL_02a5;
					}
				}
			}
		}
		goto IL_0266;
		IL_0266:
		return (DamageContainer)(object)new NullReferenceException();
		IL_02a5:
		DamageContainer damageContainer = reuseDc;
		if (reuseDc != null)
		{
			reuseDc.Reuse(0f, "Enemy");
			damageContainer.flags = flags;
			damageContainer.enemy = enemy;
			damageContainer.direction = (Vector3)direction.x;
			_ = direction.z;
			damageContainer.knockback = knockback;
			float num = PlayerStats.GetStat(EStat.Armor);
			object obj = flags & DcFlags.FinalBossDamage;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				object obj3 = flags & DcFlags.BossDamage;
				if (obj3 != null)
				{
					num *= 0.5f;
				}
			}
			else
			{
				num *= 0.75f;
			}
			object obj4 = flags & DcFlags.IgnoreArmor;
			if (obj4 != null)
			{
				num = 0f;
			}
			float num2 = 1f - num;
			float num3 = num2 * damage;
			if (!(1f > num3))
			{
				if (num3 > 2.1474836E+09f)
				{
					num3 = 2.1474836E+09f;
				}
			}
			else
			{
				num3 = 1f;
			}
			float stat = PlayerStats.GetStat(EStat.DamageReductionMultiplier);
			float num4 = 1f - stat;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm8\"");
			float damage2 = num4 * num3;
			damageContainer.damageBlockedByArmor = 7;
			damageContainer.damage = damage2;
			return reuseDc;
		}
		goto IL_0266;
	}

	public static DamageContainer GetPlayerDamage(float damage, float knockback, Vector3 direction, Enemy enemy, string damageSource, DcFlags flags)
	{
		//IL_0049: Expected O, but got F4
		//IL_007c: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_0102: Expected F4, but got I4
		DamageContainer damageContainer = reuseDc;
		if (reuseDc != null)
		{
			string damageSource2 = default(string);
			reuseDc.Reuse(0f, damageSource2);
			DcFlags dcFlags = default(DcFlags);
			damageContainer.flags = dcFlags;
			damageContainer.enemy = enemy;
			damageContainer.direction = (Vector3)direction.x;
			_ = direction.z;
			damageContainer.knockback = knockback;
			float num = PlayerStats.GetStat(EStat.Armor);
			object obj = dcFlags & DcFlags.FinalBossDamage;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				object obj3 = dcFlags & DcFlags.BossDamage;
				if (obj3 != null)
				{
					num *= 0.5f;
				}
			}
			else
			{
				num *= 0.75f;
			}
			object obj4 = dcFlags & DcFlags.IgnoreArmor;
			if (obj4 != null)
			{
				num = 0f;
			}
			float num2 = 1f - num;
			float num3 = num2 * damage;
			if (!(1f > num3))
			{
				if (num3 > 2.1474836E+09f)
				{
					num3 = 2.1474836E+09f;
				}
			}
			else
			{
				num3 = 1f;
			}
			float stat = PlayerStats.GetStat(EStat.DamageReductionMultiplier);
			float num4 = 1f - stat;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm8\"");
			float damage2 = num4 * num3;
			damageContainer.damageBlockedByArmor = 7;
			damageContainer.damage = damage2;
			return reuseDc;
		}
		return (DamageContainer)(object)new NullReferenceException();
	}

	public static bool CheckEvade(Enemy enemy)
	{
		//IL_004b: Expected I4, but got O
		//IL_001c: Invalid comparison between I4 and F4
		//IL_002b: Invalid comparison between I4 and F4
		float stat = PlayerStats.GetStat(EStat.Evasion);
		if (MyRandom.random != null)
		{
			double num = MyRandom.random.NextDouble();
			bool flag = 0f < stat;
			if (!(0f < stat))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				return !flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static bool GetCritDamageMultiplier(float critChance, out float multiplier)
	{
		//IL_0118: Expected I4, but got O
		//IL_002e: Expected I, but got O
		//IL_0156: Invalid comparison between F8 and I4
		//IL_0094: Invalid comparison between F8 and I4
		//IL_0172: Expected Ref, but got F4
		ref float reference = ref *(float*)1065353216;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num = Math.Floor(0.0);
		System.Random random = MyRandom.random;
		if (MyRandom.random != null)
		{
			nint num2 = (nint)random;
			double num3 = MyRandom.random.NextDouble();
			double num4 = num + 1.0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random <= 0)
			{
				num4 = num;
			}
			if (num4 != 0.0)
			{
				float num8;
				if (num4 != 1.0)
				{
					double num5 = num4 * 0.5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
					double num6 = num4 + 1.0;
					double num7 = num5 + num6;
					num8 = (float)num7;
				}
				else
				{
					num8 = 2f;
				}
				reference = ref *(float*)num8;
				return true;
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static void ApplyExecute(DamageContainer dc)
	{
		dc.damageEffect = EDamageEffect.Execute;
		dc.isExecute = true;
		bool flag = dc.enemy.IsBoss();
		Enemy enemy = dc.enemy;
		if (!flag)
		{
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if (enemyData.canBeExecuted)
			{
				dc.damage = enemy._003Chp_003Ek__BackingField;
				return;
			}
		}
		float damage = enemy.maxHp * 0.02f;
		dc.damage = damage;
	}

	static DamageUtility()
	{
		DamageContainer damageContainer = new DamageContainer(0f, "Enemy");
		reuseDc = damageContainer;
	}
}
