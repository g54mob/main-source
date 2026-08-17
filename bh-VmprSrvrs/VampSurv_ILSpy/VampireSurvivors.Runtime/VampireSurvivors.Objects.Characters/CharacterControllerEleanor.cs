using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerEleanor : CharacterController
{
	private List<WeaponType> _weaponsToSpawn;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		if (list._size > 0)
		{
			Equipment[] items = list._items;
			Equipment equipment = items[0];
			if ((object)items[0] != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
			{
				if (equipment._equipmentType == WeaponType.SPELL_STREAM)
				{
					List<WeaponType> weaponsToSpawn = new List<WeaponType>();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					_weaponsToSpawn = weaponsToSpawn;
				}
				if (equipment._equipmentType == WeaponType.SPELL_STRIKE)
				{
					List<WeaponType> weaponsToSpawn2 = new List<WeaponType>();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					_weaponsToSpawn = weaponsToSpawn2;
				}
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public override void LevelUp()
	{
		//IL_0276: Expected O, but got I
		//IL_0215: Expected O, but got I
		//IL_00c6: Expected I, but got O
		//IL_00d4: Expected I, but got O
		//IL_00e4: Expected O, but got I
		//IL_0164: Expected O, but got I4
		//IL_0120: Expected O, but got I
		//IL_0156: Expected O, but got I4
		//IL_01c8: Expected F4, but got O
		base.LevelUp();
		float y;
		object obj = default(object);
		GameManager core;
		WeaponType weaponType;
		float2 float7;
		WeaponType weaponType2;
		if (base._level != 10)
		{
			if (base._level != 20)
			{
				if (base._level == 30)
				{
					float2 float5 = base.position;
					float2 float6 = base.position;
					PhaserScene s_scene = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer = s_scene._renderer;
					float num = renderer.height * 0.45f;
					y = (float)obj - num;
					core = GM.Core;
					weaponType = WeaponType.ACADEMYBADGE;
					float7 = float5;
					goto IL_03a0;
				}
				return;
			}
			List<WeaponType> weaponsToSpawn = _weaponsToSpawn;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 <= (nint)1)
			{
				goto IL_0373;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v33+24]");
			weaponType2 = WeaponType.VOID;
		}
		else
		{
			List<WeaponType> weaponsToSpawn2 = _weaponsToSpawn;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0373;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v31+20]");
			weaponType2 = WeaponType.VOID;
		}
		float2 float8 = base.position;
		float2 float9 = base.position;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num2 = renderer2.height * 0.45f;
		y = (float)obj - num2;
		core = GM.Core;
		weaponType = weaponType2;
		float7 = float8;
		goto IL_03a0;
		IL_0373:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0321:
		object obj4;
		bool flag = obj4 == null;
		Pickup pickup = null;
		Pickup pickup2;
		if (!flag)
		{
			pickup = pickup2;
		}
		goto IL_0348;
		IL_0348:
		if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
		{
			_ = 1;
		}
		GameManager core2 = GM.Core;
		core2._gizmoManager.ShowHighlightAt((float)float7, y);
		return;
		IL_03a0:
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		pickup2 = core.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
		bool flag2 = (object)pickup2 == null;
		pickup = null;
		if (!flag2)
		{
			nint num3 = (nint)pickup2;
			nint num4 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v24+FFFFFFF8+v595 @ rax_v20*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj4 = 1;
					goto IL_0321;
				}
			}
			obj4 = 0;
			goto IL_0321;
		}
		goto IL_0348;
	}

	public CharacterControllerEleanor()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_013a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)125);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 125;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)126);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 126;
		}
		_weaponsToSpawn = list;
		base._002Ector();
	}
}
