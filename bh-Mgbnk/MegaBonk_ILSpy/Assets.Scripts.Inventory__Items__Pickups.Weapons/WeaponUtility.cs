using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public static class WeaponUtility
{
	public static Action<DamageContainer> A_CreateDamageContainerPreAttack;

	private static StatComponents itemModifier;

	private static DamageContainer weaponDc;

	private static DamageContainer otherDc;

	private static List<int> availableIndexes;

	public unsafe static DamageContainer GetDamageContainer(WeaponBase weaponBase, ProjectileBase projectile, Enemy enemy, Vector3 direction, float forceDamage = -1f)
	{
		//IL_0045: Expected O, but got Ref
		//IL_0060: Expected O, but got F4
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023a: Invalid comparison between O and F4
		WeaponData weaponData = weaponBase.weaponData;
		weaponDc.Reuse(weaponData.procCoefficient, weaponData._003CdamageSourceName_003Ek__BackingField);
		DamageContainer damageContainer = weaponDc;
		object obj = default(object);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&obj));
		damageContainer.direction = (Vector3)vector.x;
		_ = vector.z;
		DamageContainer damageContainer2 = weaponDc;
		damageContainer2.enemy = enemy;
		WeaponData weaponData2 = weaponBase.weaponData;
		DamageContainer damageContainer3 = weaponDc;
		damageContainer3.element = weaponData2.element;
		DamageContainer damageContainer4 = weaponDc;
		float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)24);
		float stat = PlayerStats.GetStat(EStat.KnockbackMultiplier);
		float knockback = stat * num;
		damageContainer4.knockback = knockback;
		DamageContainer damageContainer5 = weaponDc;
		damageContainer5.canProcJoe = true;
		float stat2 = PlayerStats.GetStat(EStat.CritChance);
		float num2 = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)18);
		float critChance = stat2 + num2;
		DamageContainer damageContainer6 = weaponDc;
		float num3;
		if (!DamageUtility.GetCritDamageMultiplier(critChance, out var multiplier))
		{
			num3 = 1f;
		}
		else
		{
			if (weaponDc == null)
			{
				return (DamageContainer)(object)new NullReferenceException();
			}
			damageContainer6.crit = true;
			num3 = multiplier;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		StatComponents statComponents = inventory.itemInventory.PreAttack(weaponDc, itemModifier);
		float num5 = default(float);
		float num4 = num5 - -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = num4 & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f);
		float baseDamage = num5;
		if (!flag)
		{
			float num6 = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)12);
			WeaponData weaponData3 = weaponBase.weaponData;
			if (weaponData3.eWeapon == EWeapon.Aegis)
			{
				float stat3 = PlayerStats.GetStat(EStat.Thorns);
				baseDamage = stat3 + num6;
			}
			else
			{
				baseDamage = num6;
			}
		}
		float newDamage = GetNewDamage(baseDamage, itemModifier);
		DamageContainer damageContainer7 = weaponDc;
		float damage;
		if (damageContainer7.crit)
		{
			float stat4 = PlayerStats.GetStat(EStat.CritDamage);
			float num7 = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)19);
			float num8 = stat4 + num7;
			float num9 = num8 * num3;
			damage = num9 * newDamage;
		}
		else
		{
			damage = newDamage;
		}
		DamageContainer damageContainer8 = weaponDc;
		damageContainer8.damage = damage;
		DamageContainer damageContainer9 = weaponDc;
		if (damageContainer9.isExecute)
		{
			DamageUtility.ApplyExecute(weaponDc);
		}
		return weaponDc;
	}

	public static DamageContainer GetDamageContainer(DamageContainer recycleDc, float baseDamage, float procCoefficient, string damageSourceName, Vector3 direction, Enemy enemy)
	{
		otherDc.Reuse(procCoefficient, damageSourceName);
		DamageContainer damageContainer = otherDc;
		object direction2 = default(object);
		damageContainer.direction = (Vector3)direction2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ stack_28+8]");
		_ = 0;
		DamageContainer damageContainer2 = otherDc;
		Enemy enemy2 = default(Enemy);
		damageContainer2.enemy = enemy2;
		if (damageSourceName == PlayerHealth.thornsDamageSource)
		{
			DamageContainer damageContainer3 = otherDc;
			damageContainer3.canProcJoe = true;
		}
		float stat = PlayerStats.GetStat(EStat.CritChance);
		DamageContainer damageContainer4 = otherDc;
		float num;
		if (!DamageUtility.GetCritDamageMultiplier(stat, out var multiplier))
		{
			num = 1f;
		}
		else
		{
			if (otherDc == null)
			{
				return (DamageContainer)(object)new NullReferenceException();
			}
			damageContainer4.crit = true;
			num = multiplier;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		StatComponents statComponents = inventory.itemInventory.PreAttack(otherDc, itemModifier);
		float newDamage = GetNewDamage(baseDamage, itemModifier);
		DamageContainer damageContainer5 = otherDc;
		float damage;
		if (damageContainer5.crit)
		{
			float stat2 = PlayerStats.GetStat(EStat.CritDamage);
			float num2 = stat2 * num;
			damage = num2 * newDamage;
		}
		else
		{
			damage = newDamage;
		}
		DamageContainer damageContainer6 = otherDc;
		damageContainer6.damage = damage;
		DamageContainer damageContainer7 = otherDc;
		if (damageContainer7.isExecute)
		{
			DamageUtility.ApplyExecute(otherDc);
		}
		return otherDc;
	}

	private static float GetWeaponDamage(WeaponBase weaponBase, float forceDamage)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected F4, but got Unknown
		float num = forceDamage - -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		float num2 = num & 0;
		if (!(num2 > 0.01f))
		{
			if (weaponBase != null && weaponBase.weaponStats != null)
			{
				num2 = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)12);
				WeaponData weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					if (weaponData.eWeapon == EWeapon.Aegis)
					{
						float stat = PlayerStats.GetStat(EStat.Thorns);
						return stat + num2;
					}
					goto IL_0135;
				}
			}
			throw new NullReferenceException();
		}
		num2 = forceDamage;
		goto IL_0135;
		IL_0135:
		return num2;
	}

	private unsafe static float GetNewDamage(float baseDamage, StatComponents itemModifierStatComponents)
	{
		//IL_023b: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0266: Expected O, but got Ref
		//IL_0296: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		bool flag = itemModifierStatComponents == null;
		StatComponents statComponents = itemModifierStatComponents;
		if (!flag)
		{
			if (!itemModifierStatComponents.hasModifications)
			{
				float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
				return stat * baseDamage;
			}
			bool flag2 = (object)GameManager.Instance == null;
			statComponents = itemModifierStatComponents;
			object obj = 12;
			if (!flag2)
			{
				PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
				bool flag3 = playerInventory == null;
				statComponents = null;
				obj = 12;
				if (flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
					object obj2 = default(object);
					string text = ((Enum)(&obj2)).ToString();
					string message = "Failed to get stat: " + text;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					Exception ex = new Exception(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex;
				}
				MyPlayer instance = MyPlayer.Instance;
				bool flag4 = (object)MyPlayer.Instance == null;
				statComponents = null;
				obj = 12;
				if (!flag4)
				{
					PlayerInventory inventory = instance.inventory;
					bool flag5 = instance.inventory == null;
					statComponents = null;
					obj = 12;
					if (!flag5)
					{
						PlayerStatsNew playerStats = inventory.playerStats;
						bool flag6 = inventory.playerStats == null;
						statComponents = null;
						obj = 12;
						if (!flag6)
						{
							bool flag7 = playerStats.statValuesMap == null;
							statComponents = null;
							obj = 12;
							if (!flag7)
							{
								object obj3 = ((Dictionary<System.Int32Enum, object>)(object)playerStats.statValuesMap).get_Item((System.Int32Enum)12);
								bool flag8 = obj3 == null;
								statComponents = (StatComponents)12;
								obj = 12;
								if (!flag8)
								{
									float finalValue = ((StatComponents)obj3).GetFinalValue(itemModifierStatComponents);
									return finalValue * baseDamage;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static float GetDamage(WeaponBase weaponBase)
	{
		if (weaponBase != null && weaponBase.weaponStats != null)
		{
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)12);
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float num2;
				if (weaponData.eWeapon == EWeapon.Aegis)
				{
					float stat = PlayerStats.GetStat(EStat.Thorns);
					num2 = stat + num;
				}
				else
				{
					num2 = num;
				}
				float stat2 = PlayerStats.GetStat(EStat.DamageMultiplier);
				return stat2 * num2;
			}
		}
		throw new NullReferenceException();
	}

	private static float GetDamage(float damage)
	{
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		return stat * damage;
	}

	private static float GetDcCritMultiplier(float critChance, DamageContainer dc)
	{
		if (!DamageUtility.GetCritDamageMultiplier(critChance, out var multiplier))
		{
			return 1f;
		}
		dc.crit = true;
		return multiplier;
	}

	public static float GetAttackSizeMultiplier(WeaponBase weaponBase)
	{
		if (weaponBase != null && weaponBase.weaponStats != null)
		{
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)9);
			float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float num2 = stat * num;
				if (weaponData.maxSizeMultiplier > 1f && num2 > weaponData.maxSizeMultiplier)
				{
					num2 = weaponData.maxSizeMultiplier;
				}
				return num2;
			}
		}
		throw new NullReferenceException();
	}

	public static int GetAttackQuantity(WeaponBase weaponBase)
	{
		//IL_00f1: Expected I4, but got O
		//IL_00cb: Invalid comparison between F4 and I
		//IL_0127: Expected I4, but got O
		if (weaponBase != null)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				if (weaponData.eWeapon != EWeapon.Shotgun)
				{
					if (weaponBase.weaponStats == null)
					{
						goto IL_00e3;
					}
					float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)16);
					float stat = PlayerStats.GetStat(EStat.Projectiles);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					float num2 = (float)weaponBase.weaponData + num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
					if (!(num2 < 0f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
						return (int)weaponBase.weaponData;
					}
				}
				return 2;
			}
		}
		goto IL_00e3;
		IL_00e3:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static int GetProjectileBounces(WeaponBase weaponBase)
	{
		//IL_0081: Expected I4, but got O
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected I4, but got Unknown
		if (weaponBase != null && weaponBase.weaponStats != null)
		{
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)45);
			float stat = PlayerStats.GetStat(EStat.ProjectileBounces);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = default(object);
			return obj + 45;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static float GetProjectileSpeed(WeaponBase weaponBase)
	{
		float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)11);
		float stat = PlayerStats.GetStat(EStat.ProjectileSpeedMultiplier);
		return stat * num;
	}

	public static float GetDuration(WeaponBase weaponBase)
	{
		//IL_0098: Invalid comparison between F4 and I4
		if (weaponBase != null && weaponBase.weaponStats != null)
		{
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)10);
			float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float num2 = stat * num;
				if (weaponData.maxDuration > 0f && num2 > weaponData.maxDuration)
				{
					num2 = weaponData.maxDuration;
				}
				return num2;
			}
		}
		throw new NullReferenceException();
	}

	public static float GetBurstInterval(WeaponBase weaponBase)
	{
		//IL_0042: Invalid comparison between I4 and F4
		//IL_0054: Expected F4, but got I4
		float result;
		if (weaponBase != null)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				bool flag = !(0f < weaponData.burstTime);
				result = 0f;
				if (flag)
				{
					goto IL_0178;
				}
				int attackQuantity = GetAttackQuantity(weaponBase);
				float stat = PlayerStats.GetStat(EStat.AttackSpeed);
				WeaponData weaponData2 = weaponBase.weaponData;
				bool flag2 = (object)weaponBase.weaponData == null;
				float num = stat;
				if (!flag2)
				{
					float num2 = weaponData2.minBurstInterval / stat;
					num = Time.fixedDeltaTime;
					WeaponData weaponData3 = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null)
					{
						if (num2 < num)
						{
							num2 = num;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
						float num3 = weaponData3.burstTime / 0f;
						float num4 = num3 / stat;
						if (num4 < num2)
						{
							num4 = num2;
						}
						float fixedDeltaTime = Time.fixedDeltaTime;
						if (num4 < fixedDeltaTime)
						{
							num4 = fixedDeltaTime;
						}
						result = num4;
						goto IL_0178;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0178:
		return result;
	}

	public static float GetWeaponCooldown(WeaponBase weaponBase)
	{
		//IL_0088: Invalid comparison between I4 and F4
		//IL_009a: Expected F4, but got I4
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected I4, but got Unknown
		WeaponData weaponData;
		float num;
		float stat;
		int attackQuantity;
		float num3;
		if (weaponBase != null)
		{
			weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null && weaponBase.weaponStats != null)
			{
				num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)15);
				stat = PlayerStats.GetStat(EStat.AttackSpeed);
				attackQuantity = GetAttackQuantity(weaponBase);
				WeaponData weaponData2 = weaponBase.weaponData;
				bool flag = (object)weaponBase.weaponData == null;
				float num2 = stat;
				if (!flag)
				{
					bool flag2 = !(0f < weaponData2.burstTime);
					num3 = 0f;
					if (flag2)
					{
						goto IL_0231;
					}
					int attackQuantity2 = GetAttackQuantity(weaponBase);
					float stat2 = PlayerStats.GetStat(EStat.AttackSpeed);
					WeaponData weaponData3 = weaponBase.weaponData;
					bool flag3 = (object)weaponBase.weaponData == null;
					num2 = stat2;
					if (!flag3)
					{
						float num4 = weaponData3.minBurstInterval / stat2;
						num2 = Time.fixedDeltaTime;
						WeaponData weaponData4 = weaponBase.weaponData;
						if ((object)weaponBase.weaponData != null)
						{
							if (num4 < num2)
							{
								num4 = num2;
							}
							int num5 = (int)(weaponData4.burstTime / attackQuantity2);
							num3 = (float)num5 / stat2;
							if (num3 < num4)
							{
								num3 = num4;
							}
							float fixedDeltaTime = Time.fixedDeltaTime;
							if (num3 < fixedDeltaTime)
							{
								num3 = fixedDeltaTime;
							}
							goto IL_0231;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0231:
		bool flag4 = !(0.01f < num);
		float num6 = 0.01f;
		if (!flag4)
		{
			num6 = num;
		}
		float num7 = num6 * stat;
		float num8 = weaponData.endCooldown / num7;
		float num9 = (float)attackQuantity * num3;
		float num10 = num8 + num9;
		float fixedDeltaTime2 = Time.fixedDeltaTime;
		if (num10 < fixedDeltaTime2)
		{
			num10 = fixedDeltaTime2;
		}
		return num10;
	}

	public static float GetCritChance(WeaponBase weaponBase)
	{
		if (weaponBase != null)
		{
			float stat = PlayerStats.GetStat(EStat.CritChance);
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)18);
			return stat + num;
		}
		return PlayerStats.GetStat(EStat.CritChance);
	}

	public static float GetCritDamageMultiplier(WeaponBase weaponBase)
	{
		if (weaponBase != null)
		{
			float stat = PlayerStats.GetStat(EStat.CritDamage);
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)19);
			return stat + num;
		}
		return PlayerStats.GetStat(EStat.CritDamage);
	}

	public static float GetKnockback(WeaponBase weaponBase)
	{
		float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)24);
		float stat = PlayerStats.GetStat(EStat.KnockbackMultiplier);
		return stat * num;
	}

	public static float GetDamageProjectile(ProjectileBase projectile)
	{
		//IL_006d: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_01be: Expected O, but got I4
		WeaponBase weaponBase = projectile.weaponBase;
		float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)12);
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		float num2 = stat * num;
		bool flag = projectile.bounces < 8;
		object obj = 0;
		if (!flag)
		{
			object obj2 = projectile.bounces - 7;
			float num3 = num2;
			float num4 = default(float);
			bool flag9;
			do
			{
				if (!(num3 > 1f))
				{
					bool flag2 = 1f > 1f;
					num3 = 1f;
					if (!flag2)
					{
						bool flag3 = 1f > 1f;
						num3 = 1f;
						if (!flag3)
						{
							bool flag4 = 1f > 1f;
							num3 = 1f;
							if (!flag4)
							{
								bool flag5 = 1f > 1f;
								num3 = 1f;
								if (!flag5)
								{
									bool flag6 = 1f > 1f;
									num3 = 1f;
									if (!flag6)
									{
										bool flag7 = 1f > 1f;
										num3 = 1f;
										if (!flag7)
										{
											bool flag8 = 1f > 1f;
											num3 = 1f;
											num3 = num4;
											if (flag8)
											{
											}
										}
									}
								}
							}
						}
					}
				}
				obj = 0 + 8;
				flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				num2 = num3;
			}
			while (flag9);
		}
		bool flag10 = (nint)obj >= projectile.bounces;
		float result = num2;
		if (!flag10)
		{
			bool flag11;
			do
			{
				if (!(num2 > 1f))
				{
					num2 = 1f;
				}
				obj++;
				flag11 = (nint)obj < projectile.bounces;
				result = num2;
			}
			while (flag11);
		}
		return result;
	}

	public static float GetWeaponRange(WeaponBase weaponBase)
	{
		float num = ((!FinalFightController.isFightingFinalBoss) ? 1f : 1.33f);
		WeaponData weaponData = weaponBase.weaponData;
		return num * weaponData.spawnProjectileRange;
	}

	public static int GetMaxProjectilesPoolSize(EWeapon weapon)
	{
		return 250;
	}

	public static int GetMaxProjectileHitsPoolSize(EWeapon weapon)
	{
		return 10;
	}

	public static int GetMaxProjectileDonePoolSize(EWeapon weapon)
	{
		return 10;
	}

	public static int GetMaxAttacksPoolSize(EWeapon weapon)
	{
		return 100;
	}

	public unsafe static void WeaponAttack(WeaponBase weapon)
	{
		//IL_00ef: Expected O, but got Ref
		WeaponData weaponData = weapon.weaponData;
		if (!weaponData.isAura)
		{
			WeaponAttack attack = PoolManager.Instance.GetAttack(weapon);
			if (attack != null)
			{
				GameObject gameObject = attack.gameObject;
				gameObject.SetActive(value: true);
				Transform transform = attack.transform;
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position = transform2.position;
				object obj = default(object);
				transform.position = (Vector3)(&obj);
				attack.SetAttack(weapon, MyPlayer.Instance);
			}
		}
	}

	public unsafe static void LightningStrike(Enemy enemy, int bounces, DamageContainer dc, float bounceRange, float bounceProcCoefficient)
	{
		//IL_0079: Expected O, but got Ref
		//IL_0091: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.lightningStrikePool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Vector3 centerPosition = enemy.GetCenterPosition();
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			float num = default(float);
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
			transform.position = (Vector3)(&num);
		}
		enemy.DamageFromPlayerWeapon(dc);
		if (bounces > 0)
		{
			float bounceProcCoefficient2 = default(float);
			ChainLightning(enemy, bounces, bounceRange, dc, bounceProcCoefficient2);
		}
	}

	private unsafe static void ChainLightning(Enemy initialEnemy, int numBounces, float bounceRange, DamageContainer sourceDc, float bounceProcCoefficient)
	{
		//IL_007b: Expected O, but got I
		//IL_00d4: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_00b9: Expected O, but got Ref
		//IL_0140: Expected O, but got I4
		//IL_0157: Expected O, but got Ref
		//IL_0317: Expected O, but got Ref
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		Vector3 centerPosition = initialEnemy.GetCenterPosition();
		HashSet<GameObject> hashSet = (HashSet<GameObject>)(object)new HashSet<object>();
		GameObject gameObject = initialEnemy.gameObject;
		bool flag = hashSet.Add(gameObject);
		List<Vector3> list = new List<Vector3>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v8+18]");
		float num2 = default(float);
		if (num >= 0)
		{
			list.AddWithResize((Vector3)(&num2));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj3 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj4 = 0 + obj3;
			_ = centerPosition.x;
			_ = centerPosition.z;
		}
		if (numBounces > 0)
		{
			float damage = sourceDc.damage * 0.5f;
			object obj5 = 0;
			float procCoefficient = default(float);
			float num5 = default(float);
			do
			{
				int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(null, (Vector3)(&num2), bounceRange, out var buffer);
				if (enemiesInRadiusSafe <= 0)
				{
					break;
				}
				List<int> list2 = new List<int>();
				int num3 = 0;
				do
				{
					GameObject gameObject2 = buffer[num3].gameObject;
					if (!((HashSet<object>)(object)hashSet).Contains((object)gameObject2))
					{
						list2.Add(num3);
					}
					num3++;
				}
				while (num3 < enemiesInRadiusSafe);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 <= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
				int index = UnityEngine.Random.Range(0, 0);
				int num4 = list2.get_Item(index);
				bool enemy = EnemyManager.Instance.GetEnemy(buffer[num4], out var enemy2);
				Vector3 centerPosition2 = enemy2.GetCenterPosition();
				DamageContainer damageContainer = new DamageContainer(procCoefficient, sourceDc.damageSource);
				damageContainer.damage = damage;
				damageContainer.enemy = enemy2;
				damageContainer.element = EElement.Lightning;
				enemy2.DamageFromPlayerOther(damageContainer);
				GameObject gameObject3 = enemy2.gameObject;
				bool flag2 = hashSet.Add(gameObject3);
				list.Add((Vector3)(&num5));
				obj5++;
			}
			while ((nint)obj5 < numBounces);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)0 > (nint)1)
		{
			PoolManager instance = PoolManager.Instance;
			GameObject gameObject4 = instance.chainLightningPool.Get();
			if (gameObject4 != null)
			{
				ChainLightning component = gameObject4.GetComponent<ChainLightning>();
				component.Set(list);
			}
		}
	}

	static WeaponUtility()
	{
		StatComponents statComponents = new StatComponents();
		itemModifier = statComponents;
		DamageContainer damageContainer = new DamageContainer(0f, "");
		weaponDc = damageContainer;
		DamageContainer damageContainer2 = new DamageContainer(0f, "");
		otherDc = damageContainer2;
		List<int> list = new List<int>();
		availableIndexes = list;
	}
}
