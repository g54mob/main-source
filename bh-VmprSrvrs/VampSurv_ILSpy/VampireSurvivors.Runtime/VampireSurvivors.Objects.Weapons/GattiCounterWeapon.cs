using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class GattiCounterWeapon : GattiWeapon
{
	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		//IL_01f1: Expected O, but got I4
		//IL_01fa: Expected O, but got I4
		//IL_0245: Expected O, but got I
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"cat4_i0");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"cat6_i0");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"cat5_i0");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_CatBaseFrames = list;
		List<float> plusMinus = _plusMinus;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj3 < 0)
			{
				List<float> plusMinus2 = _plusMinus;
				object obj4 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v10+20+v91 @ r8_v13*4]");
				float num = 0f - 2f;
				object obj6 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v13 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				plusMinus = _plusMinus;
				obj = obj6;
				obj2 = obj6;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void ChangeBmRate(int value)
	{
	}

	public override void CheckArcanas()
	{
	}
}
