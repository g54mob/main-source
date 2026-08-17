using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SonicWhip2_Weapon : TP_SonicWhip1_Weapon
{
	private TP_Valmanway_Weapon _subWeapon;

	private bool _totalDamageCalculated;

	protected override void Awake()
	{
		((Weapon)this).Awake();
		_weaponNodeType = WeaponType.TP_SONICWHIP1_NODE;
		_totalDamageCalculated = false;
	}

	protected override void OnStart()
	{
		//IL_004f: Expected I, but got O
		//IL_005d: Expected I, but got O
		//IL_006d: Expected O, but got I
		//IL_00ed: Expected O, but got I4
		//IL_00a9: Expected O, but got I
		//IL_00df: Expected O, but got I4
		base.OnStart();
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_VALMANWAY_SONICWHIP, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag = (object)weapon == null;
		Weapon subWeapon = weapon;
		if (flag)
		{
			goto IL_017c;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(TP_Valmanway_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Valmanway_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Valmanway_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v22+FFFFFFF8+v135 @ rax_v17*8]");
			if (0 == (nint)typeof(TP_Valmanway_Weapon))
			{
				obj3 = 1;
				goto IL_018b;
			}
		}
		obj3 = 0;
		goto IL_018b;
		IL_017c:
		_subWeapon = (TP_Valmanway_Weapon)subWeapon;
		TP_Valmanway_Weapon subWeapon2 = _subWeapon;
		if ((object)_subWeapon != null)
		{
			subWeapon2._isManualFire = true;
			if (((Weapon)subWeapon2)._firingTimer != null)
			{
				((Weapon)subWeapon2)._firingTimer.Cancel();
			}
		}
		return;
		IL_018b:
		bool flag2 = obj3 == null;
		subWeapon = null;
		if (!flag2)
		{
			subWeapon = weapon;
		}
		goto IL_017c;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		TP_Valmanway_Weapon subWeapon = _subWeapon;
		if ((object)_subWeapon != null && ((UnityEngine.Object)subWeapon).m_CachedPtr != (IntPtr)0)
		{
			_subWeapon.InternalUpdate();
		}
	}

	public override void OnSubWeaponCounter(bool skipTriggers = false)
	{
		TP_Valmanway_Weapon subWeapon = _subWeapon;
		if ((object)_subWeapon != null && ((UnityEngine.Object)subWeapon).m_CachedPtr != (IntPtr)0)
		{
			_subWeapon.Fire(skipTriggers);
		}
	}

	public override void Cleanup()
	{
		_subWeapon.Cleanup();
		if (_nodePool != null)
		{
			_nodePool.Cleanup();
		}
		((Weapon)this).Cleanup();
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			TP_Valmanway_Weapon subWeapon = _subWeapon;
			float num = ((Weapon)subWeapon)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num;
		}
		return ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_subWeapon.SetVisible(visible);
	}
}
