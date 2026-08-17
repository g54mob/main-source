using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects;

public class CharacterAccessoriesManager : EquipmentManager
{
	private bool _playerIsDeadInMultiplayer;

	public Accessory GetAccessoryByType(WeaponType accessoryType, bool searchHidden = false)
	{
		//IL_0012: Expected I, but got O
		//IL_0020: Expected I, but got O
		//IL_0030: Expected O, but got I
		//IL_00b0: Expected O, but got I4
		//IL_006c: Expected O, but got I
		//IL_00a2: Expected O, but got I4
		Accessory equipmentByType = (Accessory)GetEquipmentByType(accessoryType, searchHidden);
		if ((object)equipmentByType == null)
		{
			return equipmentByType;
		}
		nint num = (nint)equipmentByType;
		nint num2 = (nint)typeof(Accessory);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v9+FFFFFFF8+v58 @ rax_v3*8]");
			if (0 == (nint)typeof(Accessory))
			{
				obj3 = 1;
				goto IL_00f4;
			}
		}
		obj3 = 0;
		goto IL_00f4;
		IL_00f4:
		bool flag = obj3 == null;
		Accessory result = null;
		if (!flag)
		{
			result = equipmentByType;
		}
		return result;
	}

	protected override void OnUpdate()
	{
		//IL_005a: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		if (PauseSystem._paused || _playerIsDeadInMultiplayer)
		{
			return;
		}
		List<Equipment> list = base._003CActiveEquipment_003Ek__BackingField;
		bool flag = (nint)base._003CActiveEquipment_003Ek__BackingField < 0;
		object obj = list._size - 1;
		if (flag)
		{
			goto IL_00e7;
		}
		while (true)
		{
			List<Equipment> list2 = base._003CActiveEquipment_003Ek__BackingField;
			if ((nint)obj >= list2._size)
			{
				break;
			}
			Equipment[] items = list2._items;
			items[obj].InternalUpdate();
			obj--;
			if ((nint)items[obj] >= 0)
			{
				continue;
			}
			goto IL_00e7;
		}
		goto IL_01ad;
		IL_00e7:
		List<Equipment> list3 = base._003CHiddenEquipment_003Ek__BackingField;
		bool flag2 = (nint)base._003CHiddenEquipment_003Ek__BackingField < 0;
		object obj2 = list3._size - 1;
		if (flag2)
		{
			return;
		}
		while (true)
		{
			List<Equipment> list4 = base._003CHiddenEquipment_003Ek__BackingField;
			if ((nint)obj2 >= list4._size)
			{
				break;
			}
			Equipment[] items2 = list4._items;
			items2[obj2].InternalUpdate();
			obj2--;
			if ((nint)items2[obj2] < 0)
			{
				return;
			}
		}
		goto IL_01ad;
		IL_01ad:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
