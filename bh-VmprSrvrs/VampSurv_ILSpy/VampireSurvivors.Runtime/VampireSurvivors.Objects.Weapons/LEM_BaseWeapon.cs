using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_BaseWeapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__0_0;

		public static Predicate<Equipment> _003C_003E9__0_1;

		public static Predicate<Equipment> _003C_003E9__1_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CAddOuterSaboteur_003Eb__0_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CAddOuterSaboteur_003Eb__0_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CAddInnerSaboteur_003Eb__1_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public void AddOuterSaboteur()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__0_0;
		if (_003C_003Ec._003C_003E9__0_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__0_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 1700;
				return obj == null;
			});
		}
		Equipment equipment = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterAccessoriesManager accessoriesManager2 = characterController2._accessoriesManager;
		Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__0_1;
		if (_003C_003Ec._003C_003E9__0_1 == null)
		{
			match2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 1700;
				return obj == null;
			});
		}
		Equipment equipment2 = ((EquipmentManager)accessoriesManager2)._003CRemovedEquipment_003Ek__BackingField.Find(match2);
		if ((object)equipment2 == null || ((UnityEngine.Object)equipment2).m_CachedPtr == (IntPtr)0)
		{
			GameManager core = GM.Core;
			core._accessoriesFacade.AddAccessory(WeaponType.LEM_ACC_SABOTEUR, ((Equipment)this)._003COwner_003Ek__BackingField);
		}
	}

	public void AddInnerSaboteur()
	{
		//IL_0069: Expected I, but got O
		//IL_0077: Expected I, but got O
		//IL_0087: Expected O, but got I
		//IL_0107: Expected O, but got I4
		//IL_00c3: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_019d: Expected I, but got O
		//IL_01a5: Expected I, but got O
		//IL_01b5: Expected O, but got I
		//IL_0235: Expected O, but got I4
		//IL_01f1: Expected O, but got I
		//IL_0227: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__1_0;
		if (_003C_003Ec._003C_003E9__1_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__1_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj7 = x._equipmentType - 1700;
				return obj7 == null;
			});
		}
		Equipment equipment = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		AccessoryLEM_ACC_SABOTEUR accessoryLEM_ACC_SABOTEUR;
		if ((object)equipment == null)
		{
			accessoryLEM_ACC_SABOTEUR = null;
			goto IL_034d;
		}
		nint num = (nint)equipment;
		nint num2 = (nint)typeof(AccessoryLEM_ACC_SABOTEUR);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryLEM_ACC_SABOTEUR>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryLEM_ACC_SABOTEUR>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v48+FFFFFFF8+v302 @ rax_v44*8]");
			if (0 == (nint)typeof(AccessoryLEM_ACC_SABOTEUR))
			{
				obj3 = 1;
				goto IL_0326;
			}
		}
		obj3 = 0;
		goto IL_0326;
		IL_036f:
		object obj4;
		bool flag = obj4 == null;
		CharacterController_LEM_SABOTEUR characterController_LEM_SABOTEUR = null;
		if (!flag)
		{
			characterController_LEM_SABOTEUR = (CharacterController_LEM_SABOTEUR)accessoryLEM_ACC_SABOTEUR.FollowerCharacterController;
		}
		goto IL_0396;
		IL_0326:
		bool flag2 = obj3 == null;
		accessoryLEM_ACC_SABOTEUR = null;
		if (!flag2)
		{
			accessoryLEM_ACC_SABOTEUR = (AccessoryLEM_ACC_SABOTEUR)equipment;
		}
		goto IL_034d;
		IL_0396:
		if ((object)characterController_LEM_SABOTEUR != null && ((UnityEngine.Object)characterController_LEM_SABOTEUR).m_CachedPtr != (IntPtr)0)
		{
			characterController_LEM_SABOTEUR.Deactivate();
		}
		GameManager core = GM.Core;
		core._accessoriesFacade.RemoveAccessory(WeaponType.LEM_ACC_SABOTEUR, ((Equipment)this)._003COwner_003Ek__BackingField);
		return;
		IL_034d:
		if ((object)accessoryLEM_ACC_SABOTEUR == null || ((UnityEngine.Object)accessoryLEM_ACC_SABOTEUR).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		accessoryLEM_ACC_SABOTEUR.AddAnimation_Saboteur();
		VampireSurvivors.Objects.Characters.CharacterController followerCharacterController = accessoryLEM_ACC_SABOTEUR.FollowerCharacterController;
		if ((object)accessoryLEM_ACC_SABOTEUR.FollowerCharacterController == null)
		{
			characterController_LEM_SABOTEUR = null;
			goto IL_0396;
		}
		nint num4 = (nint)typeof(CharacterController_LEM_SABOTEUR);
		nint num5 = (nint)followerCharacterController;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController_LEM_SABOTEUR>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController_LEM_SABOTEUR>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v37+FFFFFFF8+v531 @ rax_v33*8]");
			if (0 == (nint)typeof(CharacterController_LEM_SABOTEUR))
			{
				obj4 = 1;
				goto IL_036f;
			}
		}
		obj4 = 0;
		goto IL_036f;
	}
}
