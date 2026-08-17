using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public class DamageSource
{
	public string damageSource;

	public float addedAtTime;

	public float damage;

	public DamageSource(string damageSource, float addedAtTime)
	{
		this.damageSource = damageSource;
		this.addedAtTime = addedAtTime;
	}

	public void AddDamage(float d)
	{
		float num = d + damage;
		damage = num;
	}

	public unsafe int GetLevel()
	{
		//IL_039d: Expected O, but got Ref
		//IL_0216: Expected O, but got Ref
		//IL_0249: Expected O, but got Ref
		//IL_0355: Expected O, but got Ref
		//IL_0277: Expected O, but got Ref
		//IL_00d3: Expected O, but got Ref
		//IL_029b: Expected I, but got O
		//IL_02a3: Expected I, but got O
		//IL_02d2: Expected I4, but got O
		//IL_02da: Expected O, but got Ref
		//IL_0106: Expected O, but got Ref
		//IL_030c: Expected I4, but got O
		//IL_0134: Expected O, but got Ref
		//IL_0158: Expected I, but got O
		//IL_0160: Expected I, but got O
		//IL_018f: Expected I4, but got O
		//IL_0197: Expected O, but got Ref
		//IL_01c9: Expected I4, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EWeapon));
		if (!Enum.TryParse(typeFromHandle, damageSource, ignoreCase: true, out var result))
		{
			Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EItem));
			if (!Enum.TryParse(typeFromHandle2, damageSource, ignoreCase: true, out var result2))
			{
				return 1;
			}
			Type type = typeFromHandle2;
			MyPlayer instance = MyPlayer.Instance;
			bool flag = (object)MyPlayer.Instance == null;
			bool flag2 = true;
			object obj = (object)(&result2);
			if (!flag)
			{
				PlayerInventory inventory = instance.inventory;
				bool flag3 = instance.inventory == null;
				flag2 = true;
				obj = (object)(&result2);
				if (!flag3)
				{
					bool flag4 = inventory.itemInventory == null;
					flag2 = true;
					obj = (object)(&result2);
					if (!flag4)
					{
						bool flag5 = result2 == null;
						flag2 = true;
						obj = (object)(&result2);
						type = (Type)result2;
						if (!flag5)
						{
							nint num = (nint)typeof(EItem);
							nint num2 = (nint)result2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v12 (Il2CppClass<System.Type>)+40]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ r8_v8 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+40]");
							bool flag6 = num3 != 0;
							flag2 = (byte)(int)typeof(EItem) != 0;
							obj = (object)(&result2);
							type = (Type)result2;
							if (!flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return inventory.itemInventory.GetAmount((EItem)obj2);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							goto IL_03ab;
						}
					}
				}
			}
		}
		else
		{
			Type type = typeFromHandle;
			MyPlayer instance2 = MyPlayer.Instance;
			bool flag7 = (object)MyPlayer.Instance == null;
			bool flag2 = true;
			object obj = (object)(&result);
			if (!flag7)
			{
				PlayerInventory inventory2 = instance2.inventory;
				bool flag8 = instance2.inventory == null;
				flag2 = true;
				obj = (object)(&result);
				if (!flag8)
				{
					bool flag9 = inventory2.weaponInventory == null;
					flag2 = true;
					obj = (object)(&result);
					if (!flag9)
					{
						bool flag10 = result == null;
						flag2 = true;
						obj = (object)(&result);
						type = (Type)result;
						if (!flag10)
						{
							nint num4 = (nint)typeof(EWeapon);
							nint num5 = (nint)result;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rdx_v8 (Il2CppClass<System.Type>)+40]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ r8_v5 (Il2CppClass<EWeapon>)+40]");
							bool flag11 = num6 != 0;
							flag2 = (byte)(int)typeof(EWeapon) != 0;
							obj = (object)(&result);
							type = (Type)result;
							if (!flag11)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj3 = default(object);
								return inventory2.weaponInventory.GetWeaponLevel((EWeapon)obj3);
							}
							goto IL_03ab;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03ab:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		int result3 = default(int);
		return result3;
	}

	public unsafe Texture GetIcon()
	{
		//IL_053e: Expected I, but got O
		//IL_056f: Expected O, but got Ref
		//IL_05a5: Expected O, but got Ref
		//IL_05ad: Expected I, but got O
		//IL_05c9: Expected I, but got O
		//IL_05d1: Expected I, but got O
		//IL_0600: Expected I, but got O
		//IL_0608: Expected O, but got Ref
		//IL_040a: Expected I, but got O
		//IL_043b: Expected O, but got Ref
		//IL_0636: Expected I4, but got O
		//IL_064b: Expected O, but got Ref
		//IL_0654: Expected I, but got O
		//IL_0471: Expected O, but got Ref
		//IL_0479: Expected I, but got O
		//IL_0495: Expected I, but got O
		//IL_04ca: Expected I, but got O
		//IL_04d2: Expected O, but got Ref
		//IL_02f8: Expected I, but got O
		//IL_0329: Expected O, but got Ref
		//IL_0500: Expected I4, but got O
		//IL_035f: Expected O, but got Ref
		//IL_0367: Expected I, but got O
		//IL_051a: Expected O, but got Ref
		//IL_052b: Expected I, but got O
		//IL_0290: Expected I, but got O
		//IL_02ca: Expected O, but got Ref
		//IL_0383: Expected I, but got O
		//IL_03b8: Expected I4, but got O
		//IL_03c0: Expected O, but got Ref
		//IL_03c8: Expected I, but got O
		//IL_0228: Expected I, but got O
		//IL_0262: Expected O, but got Ref
		//IL_06fd: Expected O, but got I
		//IL_06bb: Expected I, but got O
		//IL_01c0: Expected I, but got O
		//IL_01fa: Expected O, but got Ref
		//IL_03ee: Expected I4, but got O
		//IL_019a: Expected O, but got Ref
		//IL_0161: Expected O, but got Ref
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EWeapon));
		WeaponData weaponData;
		if (!Enum.TryParse(typeFromHandle, damageSource, ignoreCase: true, out var result))
		{
			Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EItem));
			if (!Enum.TryParse(typeFromHandle2, damageSource, ignoreCase: true, out var result2))
			{
				Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EDebuff));
				if (!Enum.TryParse(typeFromHandle3, damageSource, ignoreCase: true, out var result3))
				{
					if (damageSource != "Thorns")
					{
						if (damageSource != "Zap")
						{
							if (!(damageSource != "Shadowstep"))
							{
								nint num = (nint)typeof(IconManager);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v45 (Il2CppClass<Assets.Scripts.Managers.IconManager>)+B8]");
								nint num2 = 0;
								IconManager instance = IconManager.Instance;
								bool flag = (object)IconManager.Instance == null;
								bool flag2 = false;
								object obj = (object)(&result3);
								nint num3 = num2;
								if (!flag)
								{
									return instance.shadowStepIcon;
								}
							}
							else
							{
								bool flag3 = damageSource == PassiveAbilityBullseye.damageSource;
								nint num4 = (nint)typeof(IconManager);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v667 @ rax_v50 (Il2CppClass<Assets.Scripts.Managers.IconManager>)+B8]");
								nint num3 = 0;
								IconManager instance2 = IconManager.Instance;
								if (!flag3)
								{
									bool flag4 = (object)IconManager.Instance == null;
									bool flag2 = false;
									object obj = (object)(&result3);
									if (!flag4)
									{
										return instance2.questionMark;
									}
								}
								else
								{
									bool flag5 = (object)IconManager.Instance == null;
									bool flag2 = false;
									object obj = (object)(&result3);
									if (!flag5)
									{
										return instance2.bullseyeIcon;
									}
								}
							}
						}
						else
						{
							nint num5 = (nint)typeof(IconManager);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v41 (Il2CppClass<Assets.Scripts.Managers.IconManager>)+B8]");
							nint num6 = 0;
							IconManager instance3 = IconManager.Instance;
							bool flag6 = (object)IconManager.Instance == null;
							bool flag2 = false;
							object obj = (object)(&result3);
							nint num3 = num6;
							if (!flag6)
							{
								return instance3.zapIcon;
							}
						}
					}
					else
					{
						nint num7 = (nint)typeof(IconManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v37 (Il2CppClass<Assets.Scripts.Managers.IconManager>)+B8]");
						nint num8 = 0;
						IconManager instance4 = IconManager.Instance;
						bool flag7 = (object)IconManager.Instance == null;
						bool flag2 = false;
						object obj = (object)(&result3);
						nint num3 = num8;
						if (!flag7)
						{
							return instance4.thornsIcon;
						}
					}
				}
				else
				{
					nint num9 = (nint)typeof(IconManager);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v32 (Il2CppClass<Assets.Scripts.Managers.IconManager>)+B8]");
					nint num10 = 0;
					bool flag8 = (object)IconManager.Instance == null;
					bool flag2 = true;
					object obj = (object)(&result3);
					nint num3 = num10;
					if (!flag8)
					{
						bool flag9 = result3 == null;
						flag2 = true;
						obj = (object)(&result3);
						num3 = (nint)result3;
						if (!flag9)
						{
							nint num11 = (nint)typeof(EDebuff);
							IconManager instance5 = IconManager.Instance;
							Texture bloodmarkIcon = instance5.bloodmarkIcon;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ r8_v14 (Il2CppClass<Assets.Scripts.Game.Combat.EnemyDebuffs.EDebuff>)+40]");
							bool flag10 = (object)bloodmarkIcon != null;
							flag2 = (byte)(int)typeof(EDebuff) != 0;
							obj = (object)(&result3);
							num3 = (nint)result3;
							if (!flag10)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return IconManager.Instance.GetDebuffIcon((EDebuff)obj2);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							nint num12 = (flag2 ? 1 : 0);
							object obj3 = num3;
							goto IL_0702;
						}
					}
				}
			}
			else
			{
				nint num13 = (nint)typeof(DataManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v24 (Il2CppClass<DataManager>)+B8]");
				nint num14 = 0;
				bool flag11 = (object)DataManager.Instance == null;
				bool flag2 = true;
				object obj = (object)(&result2);
				nint num3 = num14;
				if (!flag11)
				{
					bool flag12 = result2 == null;
					flag2 = true;
					obj = (object)(&result2);
					num3 = (nint)result2;
					if (!flag12)
					{
						nint num15 = (nint)typeof(EItem);
						IconManager instance6 = IconManager.Instance;
						Texture bloodmarkIcon2 = instance6.bloodmarkIcon;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ r8_v11 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+40]");
						bool flag13 = (object)bloodmarkIcon2 != null;
						nint num12 = (nint)typeof(EItem);
						obj = (object)(&result2);
						object obj3 = result2;
						if (!flag13)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							object obj4 = default(object);
							ItemData item = DataManager.Instance.GetItem((EItem)obj4);
							flag2 = false;
							obj = (object)(&result2);
							weaponData = (WeaponData)(object)item;
							num3 = (nint)DataManager.Instance;
							goto IL_0659;
						}
						goto IL_0702;
					}
				}
			}
		}
		else
		{
			nint num16 = (nint)typeof(DataManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v16 (Il2CppClass<DataManager>)+B8]");
			nint num17 = 0;
			bool flag14 = (object)DataManager.Instance == null;
			bool flag2 = true;
			object obj = (object)(&result);
			nint num3 = num17;
			if (!flag14)
			{
				bool flag15 = result == null;
				flag2 = true;
				obj = (object)(&result);
				num3 = (nint)result;
				if (!flag15)
				{
					nint num18 = (nint)typeof(EWeapon);
					nint num19 = (nint)result;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdx_v12 (Il2CppClass<System.Object>)+40]");
					nint num20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r8_v8 (Il2CppClass<EWeapon>)+40]");
					bool flag16 = num20 != 0;
					nint num12 = (nint)typeof(EWeapon);
					obj = (object)(&result);
					object obj3 = result;
					if (!flag16)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj5 = default(object);
						weaponData = DataManager.Instance.GetWeapon((EWeapon)obj5);
						flag2 = false;
						obj = (object)(&result);
						num3 = (nint)DataManager.Instance;
						goto IL_0659;
					}
					goto IL_0712;
				}
			}
		}
		goto IL_0688;
		IL_0702:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0712;
		IL_0712:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		Texture result4 = default(Texture);
		return result4;
		IL_0659:
		if ((object)weaponData != null)
		{
			return weaponData.GetIcon();
		}
		goto IL_0688;
		IL_0688:
		throw new NullReferenceException();
	}
}
