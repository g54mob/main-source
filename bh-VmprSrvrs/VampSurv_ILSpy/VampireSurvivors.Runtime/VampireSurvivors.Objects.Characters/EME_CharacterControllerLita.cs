using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerLita : EME_CharacterControllerShowstopper
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__1_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__1_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 407;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private float RingLevelUpEveyXLevels = 7f;

	public override void LevelUp()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected I4, but got Unknown
		//IL_00ac: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_0114: Expected I, but got O
		//IL_011c: Expected I, but got O
		//IL_012c: Expected O, but got I
		//IL_0168: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_02ba: Invalid comparison between F4 and I
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0218: Expected I, but got O
		base.LevelUp();
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__1_0;
		if (_003C_003Ec._003C_003E9__1_0 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__1_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj9 = x._equipmentType - 407;
				return obj9 == null;
			});
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
		List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018765428Ah\"");
		if (((CharacterController)this)._level != 0)
		{
			return;
		}
		int num = (int)(((CharacterController)this)._level / RingLevelUpEveyXLevels);
		List<Equipment> list3 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
		float num2 = (float)num + 1f;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= list._size)
			{
				return;
			}
			if ((nint)obj < list._size)
			{
				object[] items = list._items;
				object obj3 = items[obj];
				nint num3 = (nint)typeof(Weapon);
				nint num4 = (nint)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v6 (Il2CppClass<System.Object>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num5 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v6 (Il2CppClass<System.Object>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v20+FFFFFFF8+v111 @ rax_v19*8]");
				if (0 != (nint)typeof(Weapon))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v20+FFFFFFF8+v453 @ rcx_v12*8]");
				object obj7 = 0 - typeof(Weapon);
				bool flag = obj7 == null;
				bool flag2 = !flag;
				object obj8 = null;
				if (flag2)
				{
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v7 (System.Object)+4C]");
					if (!(num2 > 0f))
					{
						goto IL_02d1;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v7 (System.Object)+4C]");
				if ((nint)0 < (nint)8)
				{
					nint num6 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v508 @ rax_v24 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
				}
				goto IL_02d1;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
			IL_02d1:
			obj++;
			obj2 = obj;
		}
		throw new NullReferenceException();
	}

	public EME_CharacterControllerLita()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
