using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Zephyr_Character : TP_Character
{
	private List<WeaponType> adeptWeapons;

	private float cooldownBonus;

	private float moveBonus;

	private bool _previousTimeStopState;

	public override float LootMult_Orologion => 2f;

	public override float PCooldown()
	{
		//IL_003f: Expected F4, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		GameManager core = GM.Core;
		float num = ((!core._003CIsTimeStopped_003Ek__BackingField) ? 0f : cooldownBonus);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		float num2 = eggFloat2._eggVal + eggFloat2._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875F5783h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				return num2;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PMoveSpeed()
	{
		//IL_003f: Expected F4, but got I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		GameManager core = GM.Core;
		float num = ((!core._003CIsTimeStopped_003Ek__BackingField) ? 0f : moveBonus);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * MoveSpeedMultiplier;
		value2 = eggFloat2._val * MoveSpeedMultiplier;
		float num2 = eggFloat3._eggVal + eggFloat3._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875F5935h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_01a8;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_01a8;
		IL_01a8:
		return num2;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		GameManager core3;
		if (!((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			if (_previousTimeStopState != core._003CIsTimeStopped_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				if (!core2._003CIsTimeStopped_003Ek__BackingField)
				{
					((CharacterController)this)._spriteTrail.ResetGhostValues();
				}
				else
				{
					OnTimeStopStart();
				}
			}
			core3 = GM.Core;
		}
		else
		{
			core3 = GM.Core;
		}
		_previousTimeStopState = core3._003CIsTimeStopped_003Ek__BackingField;
	}

	private unsafe void OnTimeStopStart()
	{
		//IL_0076: Expected O, but got I4
		//IL_007e: Expected O, but got Ref
		SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
		spriteTrail._MaxHistory = 30;
		spriteTrail.InitialiseGhosts(expandExisting: true);
		SpriteTrail spriteTrail2 = ((CharacterController)this)._spriteTrail;
		spriteTrail2._DefaultGhostAlpha = 1f;
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		bool flag = false;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void OnTimeStopEnd()
	{
		((CharacterController)this)._spriteTrail.ResetGhostValues();
	}

	public override void OnWeaponMadeLevelOne(WeaponType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj != null)
		{
			Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(type);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				WeaponData currentWeaponData = weaponByType._currentWeaponData;
				weaponByType.IsAdept = true;
				float num = currentWeaponData._003Cinterval_003Ek__BackingField * 0.5f;
				currentWeaponData._003Cinterval_003Ek__BackingField = num;
			}
		}
	}

	public TP_Zephyr_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0362: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_038a: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_03b2: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_03da: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0402: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_042a: Expected O, but got I
		//IL_02fe: Expected O, but got I
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
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1423);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1423;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1424);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1424;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1615);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1615;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1616);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1616;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1606);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1606;
		}
		adeptWeapons = list;
		cooldownBonus = -0.33f;
		moveBonus = 1f;
		((CharacterController)this)._002Ector();
	}
}
