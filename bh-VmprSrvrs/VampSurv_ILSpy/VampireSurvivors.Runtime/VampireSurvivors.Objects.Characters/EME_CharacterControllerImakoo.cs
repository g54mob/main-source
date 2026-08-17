using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerImakoo : EME_CharacterControllerShowstopper
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public WeaponType weaponType;

		internal bool _003CCheckHiddenWeaponLevelUp_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private float _ShowstopperStatBonus;

	private float _MaxBonus = 1000f;

	private float _BonusUnit = 0.05f;

	private float _HiddenWeaponsLevelUpEveyXLevels = 7f;

	protected unsafe override void OnShowStopperStarted()
	{
		//IL_00f8: Expected O, but got F4
		//IL_00c7: Expected O, but got Ref
		if (_MaxBonus > _ShowstopperStatBonus)
		{
			object obj = UnityEngine.Random.value;
			PlayerModifierStats playerStats = _playerStats;
			float num = _MaxBonus * 9f;
			float num2 = num + 1f;
			float num3 = num2 * _BonusUnit;
			float showstopperStatBonus = num3 + _ShowstopperStatBonus;
			_ShowstopperStatBonus = showstopperStatBonus;
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + num3;
			playerStats._003CPower_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string value2 = System.Number.FormatSingle(num3, "0.00", currentInfo);
			Color coopColour = GetCoopColour();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj2 = default(object);
			CharacterController character = default(CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.POWER, value2, (Color?)(object)(&obj2), character, displayTimeMultiplier, vOffset);
		}
	}

	public override void LevelUp()
	{
		base.LevelUp();
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			WeaponType weaponType = Enum.Parse<WeaponType>(null);
			CheckHiddenWeaponLevelUp(weaponType);
		}
	}

	private void CheckHiddenWeaponLevelUp(WeaponType weaponType)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected I4, but got Unknown
		//IL_00d7: Expected O, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_0163: Expected I, but got O
		//IL_016b: Expected I, but got O
		//IL_017b: Expected O, but got I
		//IL_01b7: Expected O, but got I
		//IL_01f4: Expected O, but got I
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_02ad: Invalid comparison between F4 and I
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_0267: Expected I, but got O
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals2.weaponType = weaponType;
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			object obj9 = x._equipmentType - CS_0024_003C_003E8__locals2.weaponType;
			return obj9 == null;
		};
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018765363Ah\"");
		if (((CharacterController)this)._level != 0)
		{
			return;
		}
		int num = (int)(((CharacterController)this)._level / _HiddenWeaponsLevelUpEveyXLevels);
		List<Equipment> list3 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
		float num2 = (float)num + 1f;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj >= list._size)
			{
				return;
			}
			if ((nint)obj2 < list._size)
			{
				object[] items = list._items;
				object obj3 = items[obj2];
				nint num3 = (nint)typeof(Weapon);
				nint num4 = (nint)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v6 (Il2CppClass<System.Object>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num5 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v6 (Il2CppClass<System.Object>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v19+FFFFFFF8+v103 @ rax_v18*8]");
				if (0 != (nint)typeof(Weapon))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v19+FFFFFFF8+v345 @ rcx_v11*8]");
				object obj7 = 0 - typeof(Weapon);
				bool flag = obj7 == null;
				bool flag2 = !flag;
				object obj8 = null;
				if (flag2)
				{
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v7 (System.Object)+4C]");
					if (!(num2 > 0f))
					{
						goto IL_02c4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v7 (System.Object)+4C]");
				if ((nint)0 < (nint)8)
				{
					nint num6 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v400 @ rax_v23 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
				}
				goto IL_02c4;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
			IL_02c4:
			obj2++;
			obj = obj2;
		}
		throw new NullReferenceException();
	}

	public EME_CharacterControllerImakoo()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
