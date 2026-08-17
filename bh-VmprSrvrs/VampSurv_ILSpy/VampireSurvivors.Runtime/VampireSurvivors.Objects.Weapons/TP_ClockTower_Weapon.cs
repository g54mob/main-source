using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_ClockTower_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__7_0;

		public static Predicate<Equipment> _003C_003E9__7_1;

		public static Predicate<Equipment> _003C_003E9__7_2;

		public static Predicate<Equipment> _003C_003E9__7_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__7_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1524;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CInitWeapon_003Eb__7_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1525;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CInitWeapon_003Eb__7_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1573;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CInitWeapon_003Eb__7_3(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1574;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private TP_Gear_Weapon _weaponGears;

	private TP_Pendulum_Weapon _weaponPendulum;

	private TP_Elevator_Weapon _weaponElevator;

	private TP_Heads_Weapon _weaponHeads;

	private bool _totalDamageCalculated;

	private MultiTargetTween _screenShakeTween;

	protected override void Awake()
	{
		//IL_00b2: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_0298: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_03e2: Expected O, but got I
		base.Awake();
		_totalDamageCalculated = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<WeaponType> list = config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_0412;
			}
		}
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v16+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)1524);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 1524;
		}
		goto IL_0412;
		IL_0412:
		List<WeaponType> list3 = config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				goto IL_0424;
			}
		}
		List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r9_v13+18]");
		if (num2 >= 0)
		{
			list4.AddWithResize((System.Int32Enum)1525);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1525;
		}
		goto IL_0424;
		IL_0424:
		List<WeaponType> list5 = config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			if ((nint)obj7 != -1)
			{
				goto IL_0436;
			}
		}
		List<System.Int32Enum> list6 = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v10+18]");
		if (num3 >= 0)
		{
			list6.AddWithResize((System.Int32Enum)1573);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 1573;
		}
		goto IL_0436;
		IL_0436:
		List<WeaponType> list7 = config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj10 = default(object);
			if ((nint)obj10 != -1)
			{
				return;
			}
		}
		List<System.Int32Enum> list8 = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v7+18]");
		if (num4 >= 0)
		{
			list8.AddWithResize((System.Int32Enum)1574);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj12 = (nint)0 + (nint)1;
		_ = 1574;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_1b8e: Expected I, but got O
		//IL_1bbf: Expected I, but got O
		//IL_00ad: Expected I, but got O
		//IL_00bb: Expected I, but got O
		//IL_00cb: Expected O, but got I
		//IL_014b: Expected O, but got I4
		//IL_0107: Expected O, but got I
		//IL_013d: Expected O, but got I4
		//IL_0220: Expected I, but got O
		//IL_022e: Expected I, but got O
		//IL_023e: Expected O, but got I
		//IL_02be: Expected O, but got I4
		//IL_020b: Expected I, but got O
		//IL_027a: Expected O, but got I
		//IL_02b0: Expected O, but got I4
		//IL_1ca8: Expected I, but got O
		//IL_0446: Expected I4, but got O
		//IL_0748: Expected I, but got O
		//IL_0756: Expected I, but got O
		//IL_0766: Expected O, but got I
		//IL_03be: Expected I, but got O
		//IL_03ce: Expected O, but got I
		//IL_07e6: Expected O, but got I4
		//IL_07a2: Expected O, but got I
		//IL_080a: Expected I4, but got O
		//IL_07d8: Expected O, but got I4
		//IL_0ae3: Expected I, but got O
		//IL_0af1: Expected I, but got O
		//IL_0b01: Expected O, but got I
		//IL_0b81: Expected O, but got I4
		//IL_0ace: Expected I, but got O
		//IL_0b3d: Expected O, but got I
		//IL_1dae: Expected I4, but got O
		//IL_0b73: Expected O, but got I4
		//IL_09b3: Expected I4, but got O
		//IL_09f1: Expected O, but got I
		//IL_09ff: Expected I4, but got O
		//IL_1e6e: Expected I, but got O
		//IL_0e15: Expected I, but got O
		//IL_0e23: Expected I, but got O
		//IL_0e33: Expected O, but got I
		//IL_0eb3: Expected O, but got I4
		//IL_0e6f: Expected O, but got I
		//IL_0d10: Expected I4, but got O
		//IL_0ed7: Expected I4, but got O
		//IL_0c85: Expected I, but got O
		//IL_0c95: Expected O, but got I
		//IL_0ea5: Expected O, but got I4
		//IL_119f: Expected I, but got O
		//IL_11ad: Expected I, but got O
		//IL_11bd: Expected O, but got I
		//IL_123d: Expected O, but got I4
		//IL_118a: Expected I, but got O
		//IL_11f9: Expected O, but got I
		//IL_1259: Expected I4, but got O
		//IL_122f: Expected O, but got I4
		//IL_1080: Expected I4, but got O
		//IL_10be: Expected O, but got I
		//IL_10cc: Expected I4, but got O
		//IL_209b: Expected I, but got O
		//IL_14b3: Expected I, but got O
		//IL_14c1: Expected I, but got O
		//IL_14d1: Expected O, but got I
		//IL_1551: Expected O, but got I4
		//IL_150d: Expected O, but got I
		//IL_13ae: Expected I4, but got O
		//IL_1575: Expected I4, but got O
		//IL_1323: Expected I, but got O
		//IL_1333: Expected O, but got I
		//IL_1543: Expected O, but got I4
		//IL_1817: Expected I, but got O
		//IL_18e7: Expected I4, but got O
		//IL_182d: Expected I, but got O
		//IL_183b: Expected I, but got O
		//IL_184b: Expected O, but got I
		//IL_18cb: Expected O, but got I4
		//IL_1887: Expected O, but got I
		//IL_18bd: Expected O, but got I4
		//IL_171e: Expected I4, but got O
		//IL_175c: Expected O, but got I
		//IL_176a: Expected I4, but got O
		//IL_1a3c: Expected I4, but got O
		//IL_19b1: Expected I, but got O
		//IL_19c1: Expected O, but got I
		//IL_1d95->IL1b2f: Incompatible stack heights: 1 vs 0
		//IL_0a43->IL0d46: Incompatible stack heights: 1 vs 0
		//IL_1f5b->IL1b2f: Incompatible stack heights: 1 vs 0
		//IL_1fa4->IL13e4: Incompatible stack heights: 2 vs 0
		//IL_2188->IL1b2f: Incompatible stack heights: 1 vs 0
		//IL_21c9->IL1a72: Incompatible stack heights: 2 vs 0
		base.InitWeapon(characterController, weaponType);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num;
		Equipment equipment;
		Weapon weapon;
		Equipment weaponGears;
		object obj3;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
			if ((object)characterController2._weaponsManager != null)
			{
				Predicate<Equipment> match = _003C_003Ec._003C_003E9__7_0;
				bool flag = _003C_003Ec._003C_003E9__7_0 != null;
				num = unchecked((nint)null);
				if (!flag)
				{
					Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__7_0 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj29 = x._equipmentType - 1524;
						return obj29 == null;
					});
					num = unchecked((nint)null);
					match = predicate;
				}
				if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
				{
					equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
					if ((object)equipment == null)
					{
						weapon = null;
						weaponGears = null;
						goto IL_1bcc;
					}
					num = (nint)equipment;
					nint num2 = (nint)typeof(TP_Gear_Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1482 @ rdx_v113 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gear_Weapon>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1482 @ rdx_v113 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gear_Weapon>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1531 @ rax_v393+FFFFFFF8+v1483 @ rax_v388*8]");
						if (0 == (nint)typeof(TP_Gear_Weapon))
						{
							obj3 = 1;
							goto IL_1bdb;
						}
					}
					obj3 = 0;
					goto IL_1bdb;
				}
			}
		}
		goto IL_1b2f;
		IL_1e8a:
		object obj4;
		bool flag2 = obj4 == null;
		nint num5;
		nint num4 = num5;
		Weapon weaponElevator = weapon;
		Equipment equipment2;
		if (!flag2)
		{
			num4 = num5;
			weaponElevator = (Weapon)equipment2;
		}
		goto IL_1e7b;
		IL_1cb5:
		Weapon weaponPendulum;
		_weaponPendulum = (TP_Pendulum_Weapon)weaponPendulum;
		WeaponType weaponType2 = (WeaponType)_weaponPendulum;
		if ((object)_weaponPendulum != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rbx_v17 (VampireSurvivors.Data.WeaponType)+10]");
			if ((nint)0 != 0)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
					if ((object)characterController3._weaponsManager != null && ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
						object obj5 = default(object);
						if (obj5 == null)
						{
							goto IL_097d;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
							if ((object)characterController4._weaponsManager != null && ((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField != null)
							{
								bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_weaponPendulum);
								goto IL_097d;
							}
						}
					}
				}
				goto IL_1b2f;
			}
		}
		GameManager core = GM.Core;
		if ((object)GM.Core == null || core._weaponsFacade == null)
		{
			goto IL_1b2f;
		}
		Weapon weapon2 = core._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_PENDULUM_WEAPON, ((Equipment)this)._003COwner_003Ek__BackingField);
		Weapon weaponPendulum2;
		if ((object)weapon2 == null)
		{
			num4 = unchecked((nint)null);
			weaponPendulum2 = weapon;
			goto IL_1d9a;
		}
		num4 = (nint)weapon2;
		nint num6 = (nint)typeof(TP_Pendulum_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2527 @ rdx_v90 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pendulum_Weapon>)+130]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2527 @ rdx_v90 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pendulum_Weapon>)+130]");
		object obj8;
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2572 @ rax_v305+FFFFFFF8+v2528 @ rax_v300*8]");
			if (0 == (nint)typeof(TP_Pendulum_Weapon))
			{
				obj8 = 1;
				goto IL_1db3;
			}
		}
		obj8 = 0;
		goto IL_1db3;
		IL_1fbb:
		object obj9;
		bool flag4 = obj9 == null;
		Weapon weaponElevator2 = weapon;
		Weapon weapon3;
		if (!flag4)
		{
			weaponElevator2 = weapon3;
		}
		goto IL_1fa4;
		IL_1b2f:
		throw new NullReferenceException();
		IL_097d:
		VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			WeaponType weaponType3 = (WeaponType)characterController5._weaponsManager;
			if ((object)characterController5._weaponsManager != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rbx_v40 (VampireSurvivors.Data.WeaponType)+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rbx_v40 (VampireSurvivors.Data.WeaponType)+30]");
					bool flag5 = ((List<Equipment>)0).Remove(_weaponPendulum);
					WeaponType weaponType4 = (WeaponType)_weaponPendulum;
					if ((object)_weaponPendulum != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rbx_v41 (VampireSurvivors.Data.WeaponType)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rbx_v41 (VampireSurvivors.Data.WeaponType)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							num4 = num;
							goto IL_0d46;
						}
					}
				}
			}
		}
		goto IL_1b2f;
		IL_21e0:
		object obj10;
		Weapon weapon4;
		if (obj10 != null)
		{
			weapon = weapon4;
		}
		goto IL_21c9;
		IL_104a:
		VampireSurvivors.Objects.Characters.CharacterController characterController6 = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num8;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			WeaponType weaponType5 = (WeaponType)characterController6._weaponsManager;
			if ((object)characterController6._weaponsManager != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rbx_v34 (VampireSurvivors.Data.WeaponType)+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rbx_v34 (VampireSurvivors.Data.WeaponType)+30]");
					bool flag7 = ((List<Equipment>)0).Remove(_weaponElevator);
					WeaponType weaponType6 = (WeaponType)_weaponElevator;
					if ((object)_weaponElevator != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v35 (VampireSurvivors.Data.WeaponType)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v35 (VampireSurvivors.Data.WeaponType)+10]");
						IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
						if ((object)gameObject2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v229 (UnityEngine.GameObject)+10]");
							bool flag9 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v229 (UnityEngine.GameObject)+10]");
							GameObject.SetActive_Injected((IntPtr)0, true);
							num8 = num4;
							goto IL_13e4;
						}
					}
				}
			}
		}
		goto IL_1b2f;
		IL_1a72:
		if ((object)_weaponGears != null)
		{
			_weaponGears.FindClockWeapons();
		}
		if ((object)_weaponPendulum != null)
		{
			_weaponPendulum.FindClockWeapons();
		}
		if ((object)_weaponElevator != null)
		{
			_weaponElevator.FindClockWeapons();
		}
		if ((object)_weaponHeads != null)
		{
			_weaponHeads.FindClockWeapons();
		}
		return;
		IL_13e4:
		VampireSurvivors.Objects.Characters.CharacterController characterController7 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Equipment equipment3;
		Weapon weaponHeads;
		nint num9;
		object obj13;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			CharacterWeaponsManager weaponsManager4 = characterController7._weaponsManager;
			if ((object)characterController7._weaponsManager != null)
			{
				Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__7_3;
				if (_003C_003Ec._003C_003E9__7_3 == null)
				{
					Predicate<Equipment> predicate2 = (_003C_003Ec._003C_003E9__7_3 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj29 = x._equipmentType - 1574;
						return obj29 == null;
					});
					num8 = unchecked((nint)null);
					match2 = predicate2;
				}
				if (((EquipmentManager)weaponsManager4)._003CActiveEquipment_003Ek__BackingField != null)
				{
					equipment3 = ((EquipmentManager)weaponsManager4)._003CActiveEquipment_003Ek__BackingField.Find(match2);
					if ((object)equipment3 == null)
					{
						weaponHeads = weapon;
						goto IL_20a8;
					}
					num9 = (nint)equipment3;
					nint num10 = (nint)typeof(TP_Heads_Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3736 @ rdx_v66 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Heads_Weapon>)+130]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ r9_v28 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3736 @ rdx_v66 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Heads_Weapon>)+130]");
					if (num11 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ r9_v28 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3804 @ rax_v163+FFFFFFF8+v3737 @ rax_v158*8]");
						if (0 == (nint)typeof(TP_Heads_Weapon))
						{
							obj13 = 1;
							goto IL_20b7;
						}
					}
					obj13 = 0;
					goto IL_20b7;
				}
			}
		}
		goto IL_1b2f;
		IL_1bdb:
		bool flag10 = obj3 == null;
		weapon = null;
		weaponGears = null;
		if (!flag10)
		{
			weapon = null;
			weaponGears = equipment;
		}
		goto IL_1bcc;
		IL_0679:
		VampireSurvivors.Objects.Characters.CharacterController characterController8 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Equipment equipment4;
		nint num12;
		object obj16;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			CharacterWeaponsManager weaponsManager5 = characterController8._weaponsManager;
			if ((object)characterController8._weaponsManager != null)
			{
				Predicate<Equipment> match3 = _003C_003Ec._003C_003E9__7_1;
				if (_003C_003Ec._003C_003E9__7_1 == null)
				{
					Predicate<Equipment> predicate3 = (_003C_003Ec._003C_003E9__7_1 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj29 = x._equipmentType - 1525;
						return obj29 == null;
					});
					num = unchecked((nint)null);
					match3 = predicate3;
				}
				if (((EquipmentManager)weaponsManager5)._003CActiveEquipment_003Ek__BackingField != null)
				{
					equipment4 = ((EquipmentManager)weaponsManager5)._003CActiveEquipment_003Ek__BackingField.Find(match3);
					if ((object)equipment4 == null)
					{
						weaponPendulum = weapon;
						goto IL_1cb5;
					}
					num12 = (nint)equipment4;
					nint num13 = (nint)typeof(TP_Pendulum_Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2212 @ rdx_v98 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pendulum_Weapon>)+130]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ r9_v48 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2212 @ rdx_v98 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pendulum_Weapon>)+130]");
					if (num14 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ r9_v48 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2312 @ rax_v342+FFFFFFF8+v2213 @ rax_v337*8]");
						if (0 == (nint)typeof(TP_Pendulum_Weapon))
						{
							obj16 = 1;
							goto IL_1cc4;
						}
					}
					obj16 = 0;
					goto IL_1cc4;
				}
			}
		}
		goto IL_1b2f;
		IL_20a8:
		_weaponHeads = (TP_Heads_Weapon)weaponHeads;
		WeaponType weaponType7 = (WeaponType)_weaponHeads;
		if ((object)_weaponHeads != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rbx_v23 (VampireSurvivors.Data.WeaponType)+10]");
			if ((nint)0 != 0)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController9 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					CharacterWeaponsManager weaponsManager6 = characterController9._weaponsManager;
					if ((object)characterController9._weaponsManager != null && ((EquipmentManager)weaponsManager6)._003CActiveEquipment_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
						object obj17 = default(object);
						if (obj17 == null)
						{
							goto IL_16e8;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController10 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							CharacterWeaponsManager weaponsManager7 = characterController10._weaponsManager;
							if ((object)characterController10._weaponsManager != null && ((EquipmentManager)weaponsManager7)._003CActiveEquipment_003Ek__BackingField != null)
							{
								bool flag11 = ((List<object>)(object)((EquipmentManager)weaponsManager7)._003CActiveEquipment_003Ek__BackingField).Remove((object)_weaponHeads);
								goto IL_16e8;
							}
						}
					}
				}
				goto IL_1b2f;
			}
		}
		GameManager core2 = GM.Core;
		if ((object)GM.Core == null || core2._weaponsFacade == null)
		{
			goto IL_1b2f;
		}
		weapon4 = core2._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_HEADS_WEAPON, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag12 = (object)weapon4 == null;
		nint num15 = unchecked((nint)null);
		if (flag12)
		{
			goto IL_21c9;
		}
		num15 = (nint)weapon4;
		nint num16 = (nint)typeof(TP_Heads_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4051 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Heads_Weapon>)+130]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4051 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Heads_Weapon>)+130]");
		if (num17 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r9_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4105 @ rax_v121+FFFFFFF8+v4052 @ rax_v117*8]");
			if (0 == (nint)typeof(TP_Heads_Weapon))
			{
				obj10 = 1;
				goto IL_21e0;
			}
		}
		obj10 = 0;
		goto IL_21e0;
		IL_1bcc:
		_weaponGears = (TP_Gear_Weapon)weaponGears;
		Weapon weapon5;
		nint num18;
		Weapon weaponGears2;
		object obj22;
		if (_weaponGears == null)
		{
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null && core3._weaponsFacade != null)
			{
				weapon5 = core3._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_GEARS_WEAPON, ((Equipment)this)._003COwner_003Ek__BackingField);
				if ((object)weapon5 == null)
				{
					num18 = unchecked((nint)null);
					weaponGears2 = weapon;
					goto IL_1c02;
				}
				num18 = (nint)weapon5;
				nint num19 = (nint)typeof(TP_Gear_Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1745 @ rdx_v112 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gear_Weapon>)+130]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r9_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1745 @ rdx_v112 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gear_Weapon>)+130]");
				if (num20 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r9_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1838 @ rax_v385+FFFFFFF8+v1746 @ rax_v380*8]");
					if (0 == (nint)typeof(TP_Gear_Weapon))
					{
						obj22 = 1;
						goto IL_1c11;
					}
				}
				obj22 = 0;
				goto IL_1c11;
			}
		}
		else
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController11 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				CharacterWeaponsManager weaponsManager8 = characterController11._weaponsManager;
				if ((object)characterController11._weaponsManager != null && ((EquipmentManager)weaponsManager8)._003CActiveEquipment_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
					object obj23 = default(object);
					if (obj23 == null)
					{
						goto IL_05bc;
					}
					VampireSurvivors.Objects.Characters.CharacterController characterController12 = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						CharacterWeaponsManager weaponsManager9 = characterController12._weaponsManager;
						if ((object)characterController12._weaponsManager != null && ((EquipmentManager)weaponsManager9)._003CActiveEquipment_003Ek__BackingField != null)
						{
							bool flag13 = ((List<object>)(object)((EquipmentManager)weaponsManager9)._003CActiveEquipment_003Ek__BackingField).Remove((object)_weaponGears);
							goto IL_05bc;
						}
					}
				}
			}
		}
		goto IL_1b2f;
		IL_05bc:
		VampireSurvivors.Objects.Characters.CharacterController characterController13 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController13._weaponsManager != null)
		{
			characterController13._weaponsManager.AddHiddenEquipment(_weaponGears);
			if ((object)_weaponGears != null)
			{
				GameObject gameObject3 = _weaponGears.gameObject;
				if ((object)gameObject3 != null)
				{
					gameObject3.SetActive(value: true);
					goto IL_0679;
				}
			}
		}
		goto IL_1b2f;
		IL_0d46:
		VampireSurvivors.Objects.Characters.CharacterController characterController14 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			CharacterWeaponsManager weaponsManager10 = characterController14._weaponsManager;
			if ((object)characterController14._weaponsManager != null)
			{
				Predicate<Equipment> match4 = _003C_003Ec._003C_003E9__7_2;
				if (_003C_003Ec._003C_003E9__7_2 == null)
				{
					Predicate<Equipment> predicate4 = (_003C_003Ec._003C_003E9__7_2 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj29 = x._equipmentType - 1573;
						return obj29 == null;
					});
					num4 = unchecked((nint)null);
					match4 = predicate4;
				}
				if (((EquipmentManager)weaponsManager10)._003CActiveEquipment_003Ek__BackingField != null)
				{
					equipment2 = ((EquipmentManager)weaponsManager10)._003CActiveEquipment_003Ek__BackingField.Find(match4);
					if ((object)equipment2 == null)
					{
						weaponElevator = weapon;
						goto IL_1e7b;
					}
					num5 = (nint)equipment2;
					nint num21 = (nint)typeof(TP_Elevator_Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rdx_v83 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elevator_Weapon>)+130]");
					object obj24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2939 @ r9_v38 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2940 @ rdx_v83 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elevator_Weapon>)+130]");
					if (num22 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2939 @ r9_v38 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj25 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3005 @ rax_v258+FFFFFFF8+v2941 @ rax_v253*8]");
						if (0 == (nint)typeof(TP_Elevator_Weapon))
						{
							obj4 = 1;
							goto IL_1e8a;
						}
					}
					obj4 = 0;
					goto IL_1e8a;
				}
			}
		}
		goto IL_1b2f;
		IL_1fa4:
		_weaponElevator = (TP_Elevator_Weapon)weaponElevator2;
		Weapon weapon6 = weapon3;
		WeaponType weaponType8 = (WeaponType)_weaponElevator;
		if ((object)_weaponElevator != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rbx_v32 (VampireSurvivors.Data.WeaponType)+10]");
			if ((nint)0 != 0)
			{
				TP_Elevator_Weapon weaponElevator3 = _weaponElevator;
				if ((object)_weaponElevator != null)
				{
					((Weapon)weaponElevator3)._skipAddingEvolution = true;
					TP_Elevator_Weapon weaponElevator4 = _weaponElevator;
					if ((object)_weaponElevator != null)
					{
						while (((Equipment)weaponElevator4)._003CLevel_003Ek__BackingField < 9)
						{
							TP_Elevator_Weapon weaponElevator5 = _weaponElevator;
							if ((object)_weaponElevator != null)
							{
								nint num23 = (nint)weaponElevator5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3699 @ rax_v197 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elevator_Weapon>)+210]");
								weapon6 = (Weapon)0;
								bool flag14 = _weaponElevator.LevelUp(skipFire: true);
								weaponElevator4 = _weaponElevator;
								if ((object)_weaponElevator != null)
								{
									continue;
								}
							}
							goto IL_1b2f;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController15 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							WeaponType weaponType9 = (WeaponType)characterController15._weaponsManager;
							if ((object)characterController15._weaponsManager != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rbx_v33 (VampireSurvivors.Data.WeaponType)+30]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
									goto IL_13e4;
								}
							}
						}
					}
				}
				goto IL_1b2f;
			}
		}
		goto IL_13e4;
		IL_16e8:
		VampireSurvivors.Objects.Characters.CharacterController characterController16 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			WeaponType weaponType10 = (WeaponType)characterController16._weaponsManager;
			if ((object)characterController16._weaponsManager != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v28 (VampireSurvivors.Data.WeaponType)+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v28 (VampireSurvivors.Data.WeaponType)+30]");
					bool flag15 = ((List<Equipment>)0).Remove(_weaponHeads);
					WeaponType weaponType11 = (WeaponType)_weaponHeads;
					if ((object)_weaponHeads != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v29 (VampireSurvivors.Data.WeaponType)+10]");
						bool flag16 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v29 (VampireSurvivors.Data.WeaponType)+10]");
						IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
						if ((object)gameObject4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v134 (UnityEngine.GameObject)+10]");
							bool flag17 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v134 (UnityEngine.GameObject)+10]");
							GameObject.SetActive_Injected((IntPtr)0, true);
							goto IL_1a72;
						}
					}
				}
			}
		}
		goto IL_1b2f;
		IL_1d9a:
		_weaponPendulum = (TP_Pendulum_Weapon)weaponPendulum2;
		WeaponType weaponType12 = (WeaponType)_weaponPendulum;
		if ((object)_weaponPendulum != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rbx_v38 (VampireSurvivors.Data.WeaponType)+10]");
			if ((nint)0 != 0)
			{
				TP_Pendulum_Weapon weaponPendulum3 = _weaponPendulum;
				if ((object)_weaponPendulum != null)
				{
					((Weapon)weaponPendulum3)._skipAddingEvolution = true;
					TP_Pendulum_Weapon weaponPendulum4 = _weaponPendulum;
					bool flag18 = (object)_weaponPendulum == null;
					Weapon weapon7 = weapon2;
					if (!flag18)
					{
						while (((Equipment)weaponPendulum4)._003CLevel_003Ek__BackingField < 9)
						{
							TP_Pendulum_Weapon weaponPendulum5 = _weaponPendulum;
							if ((object)_weaponPendulum != null)
							{
								nint num24 = (nint)weaponPendulum5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2913 @ rax_v292 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pendulum_Weapon>)+210]");
								weapon7 = (Weapon)0;
								bool flag19 = _weaponPendulum.LevelUp(skipFire: true);
								weaponPendulum4 = _weaponPendulum;
								if ((object)_weaponPendulum != null)
								{
									continue;
								}
							}
							goto IL_1b2f;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController17 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							WeaponType weaponType13 = (WeaponType)characterController17._weaponsManager;
							if ((object)characterController17._weaponsManager != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rbx_v39 (VampireSurvivors.Data.WeaponType)+30]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
									goto IL_0d46;
								}
							}
						}
					}
				}
				goto IL_1b2f;
			}
		}
		goto IL_0d46;
		IL_21c9:
		_weaponHeads = (TP_Heads_Weapon)weapon;
		Weapon weapon8 = weapon4;
		WeaponType weaponType14 = (WeaponType)_weaponHeads;
		if ((object)_weaponHeads != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v26 (VampireSurvivors.Data.WeaponType)+10]");
			if ((nint)0 != 0)
			{
				TP_Heads_Weapon weaponHeads2 = _weaponHeads;
				if ((object)_weaponHeads != null)
				{
					((Weapon)weaponHeads2)._skipAddingEvolution = true;
					TP_Heads_Weapon weaponHeads3 = _weaponHeads;
					if ((object)_weaponHeads != null)
					{
						while (((Equipment)weaponHeads3)._003CLevel_003Ek__BackingField < 9)
						{
							TP_Heads_Weapon weaponHeads4 = _weaponHeads;
							if ((object)_weaponHeads != null)
							{
								nint num25 = (nint)weaponHeads4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4467 @ rax_v103 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Heads_Weapon>)+210]");
								weapon8 = (Weapon)0;
								bool flag20 = _weaponHeads.LevelUp(skipFire: true);
								weaponHeads3 = _weaponHeads;
								if ((object)_weaponHeads != null)
								{
									continue;
								}
							}
							goto IL_1b2f;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController18 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							WeaponType weaponType15 = (WeaponType)characterController18._weaponsManager;
							if ((object)characterController18._weaponsManager != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rbx_v27 (VampireSurvivors.Data.WeaponType)+30]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
									goto IL_1a72;
								}
							}
						}
					}
				}
				goto IL_1b2f;
			}
		}
		goto IL_1a72;
		IL_1e7b:
		_weaponElevator = (TP_Elevator_Weapon)weaponElevator;
		WeaponType weaponType16 = (WeaponType)_weaponElevator;
		if ((object)_weaponElevator != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rbx_v20 (VampireSurvivors.Data.WeaponType)+10]");
			if ((nint)0 != 0)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController19 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					CharacterWeaponsManager weaponsManager11 = characterController19._weaponsManager;
					if ((object)characterController19._weaponsManager != null && ((EquipmentManager)weaponsManager11)._003CActiveEquipment_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
						object obj26 = default(object);
						if (obj26 == null)
						{
							goto IL_104a;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController20 = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							CharacterWeaponsManager weaponsManager12 = characterController20._weaponsManager;
							if ((object)characterController20._weaponsManager != null && ((EquipmentManager)weaponsManager12)._003CActiveEquipment_003Ek__BackingField != null)
							{
								bool flag21 = ((List<object>)(object)((EquipmentManager)weaponsManager12)._003CActiveEquipment_003Ek__BackingField).Remove((object)_weaponElevator);
								goto IL_104a;
							}
						}
					}
				}
				goto IL_1b2f;
			}
		}
		GameManager core4 = GM.Core;
		if ((object)GM.Core == null || core4._weaponsFacade == null)
		{
			goto IL_1b2f;
		}
		weapon3 = core4._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_ELEVATOR_WEAPON, ((Equipment)this)._003COwner_003Ek__BackingField);
		if ((object)weapon3 == null)
		{
			num8 = unchecked((nint)null);
			weaponElevator2 = weapon;
			goto IL_1fa4;
		}
		num8 = (nint)weapon3;
		nint num26 = (nint)typeof(TP_Elevator_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3241 @ rdx_v75 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elevator_Weapon>)+130]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3241 @ rdx_v75 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Elevator_Weapon>)+130]");
		if (num27 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3295 @ rax_v216+FFFFFFF8+v3242 @ rax_v211*8]");
			if (0 == (nint)typeof(TP_Elevator_Weapon))
			{
				obj9 = 1;
				goto IL_1fbb;
			}
		}
		obj9 = 0;
		goto IL_1fbb;
		IL_1c11:
		bool flag22 = obj22 == null;
		weaponGears2 = weapon;
		if (!flag22)
		{
			weaponGears2 = weapon5;
		}
		goto IL_1c02;
		IL_1cc4:
		bool flag23 = obj16 == null;
		num = num12;
		weaponPendulum = weapon;
		if (!flag23)
		{
			num = num12;
			weaponPendulum = (Weapon)equipment4;
		}
		goto IL_1cb5;
		IL_1db3:
		bool flag24 = obj8 == null;
		weaponPendulum2 = weapon;
		if (!flag24)
		{
			weaponPendulum2 = weapon2;
		}
		goto IL_1d9a;
		IL_1c02:
		_weaponGears = (TP_Gear_Weapon)weaponGears2;
		bool flag25 = _weaponGears;
		bool flag26 = !flag25;
		num = num18;
		if (flag26)
		{
			goto IL_0679;
		}
		TP_Gear_Weapon weaponGears3 = _weaponGears;
		if ((object)_weaponGears != null)
		{
			((Weapon)weaponGears3)._skipAddingEvolution = true;
			TP_Gear_Weapon weaponGears4 = _weaponGears;
			bool flag27 = (object)_weaponGears == null;
			Weapon weapon9 = weapon5;
			if (!flag27)
			{
				while (((Equipment)weaponGears4)._003CLevel_003Ek__BackingField < 9)
				{
					TP_Gear_Weapon weaponGears5 = _weaponGears;
					if ((object)_weaponGears != null)
					{
						nint num28 = (nint)weaponGears5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2100 @ rax_v376 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gear_Weapon>)+210]");
						weapon9 = (Weapon)0;
						bool flag28 = _weaponGears.LevelUp(skipFire: true);
						weaponGears4 = _weaponGears;
						if ((object)_weaponGears != null)
						{
							continue;
						}
					}
					goto IL_1b2f;
				}
				VampireSurvivors.Objects.Characters.CharacterController characterController21 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					WeaponType weaponType17 = (WeaponType)characterController21._weaponsManager;
					if ((object)characterController21._weaponsManager != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rbx_v44 (VampireSurvivors.Data.WeaponType)+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
							num = num18;
							goto IL_0679;
						}
					}
				}
			}
		}
		goto IL_1b2f;
		IL_20b7:
		bool flag29 = obj13 == null;
		num8 = num9;
		weaponHeads = weapon;
		if (!flag29)
		{
			num8 = num9;
			weaponHeads = (Weapon)equipment3;
		}
		goto IL_20a8;
	}

	public override void Fire(bool skipTriggers = false)
	{
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			TP_Gear_Weapon weaponGears = _weaponGears;
			TP_Pendulum_Weapon weaponPendulum = _weaponPendulum;
			TP_Elevator_Weapon weaponElevator = _weaponElevator;
			TP_Heads_Weapon weaponHeads = _weaponHeads;
			float num = ((Weapon)weaponPendulum)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)weaponGears)._003CStatsInflictedDamage_003Ek__BackingField;
			float num2 = num + ((Weapon)weaponElevator)._003CStatsInflictedDamage_003Ek__BackingField;
			float num3 = num2 + ((Weapon)weaponHeads)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			float num4 = num3 + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num4;
		}
		return base._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public override void Cleanup()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		_weaponPendulum.Cleanup();
		_weaponElevator.Cleanup();
		_weaponGears.Cleanup();
		_weaponHeads.Cleanup();
		base.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_weaponElevator.SetVisible(visible);
		_weaponGears.SetVisible(visible);
		_weaponHeads.SetVisible(visible);
		_weaponPendulum.SetVisible(visible);
	}
}
