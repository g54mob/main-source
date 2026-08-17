using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class TP_PlatinumWhip2_Weapon : TP_PlatinumWhip1_Weapon
{
	private TP_GrandCross_Weapon _subWeapon;

	private bool _totalDamageCalculated;

	protected override void Awake()
	{
		base.Awake();
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
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.TP_GRANDCROSS_PLATINUMWHIP, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag = (object)weapon == null;
		Weapon subWeapon = weapon;
		if (flag)
		{
			goto IL_0175;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(TP_GrandCross_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v33+FFFFFFF8+v151 @ rax_v28*8]");
			if (0 == (nint)typeof(TP_GrandCross_Weapon))
			{
				obj3 = 1;
				goto IL_0184;
			}
		}
		obj3 = 0;
		goto IL_0184;
		IL_0175:
		_subWeapon = (TP_GrandCross_Weapon)subWeapon;
		TP_GrandCross_Weapon subWeapon2 = _subWeapon;
		if ((object)_subWeapon != null && ((UnityEngine.Object)subWeapon2).m_CachedPtr != (IntPtr)0)
		{
			TP_GrandCross_Weapon subWeapon3 = _subWeapon;
			subWeapon3.ManualFire = true;
		}
		return;
		IL_0184:
		bool flag2 = obj3 == null;
		subWeapon = null;
		if (!flag2)
		{
			subWeapon = weapon;
		}
		goto IL_0175;
	}

	public override void OnSubWeaponCounter(bool skipTriggers = false)
	{
		TP_GrandCross_Weapon subWeapon = _subWeapon;
		if ((object)_subWeapon != null && ((UnityEngine.Object)subWeapon).m_CachedPtr != (IntPtr)0)
		{
			_subWeapon.Fire(skipTriggers);
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_subWeapon.SetVisible(visible);
	}

	public override void Cleanup()
	{
		_subWeapon.Cleanup();
		((Weapon)this).Cleanup();
		if (base._memoryWhipPool != null)
		{
			base._memoryWhipPool.Cleanup();
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		TP_GrandCross_Weapon subWeapon = _subWeapon;
		if ((object)_subWeapon != null && ((UnityEngine.Object)subWeapon).m_CachedPtr != (IntPtr)0)
		{
			_subWeapon.InternalUpdate();
		}
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			TP_GrandCross_Weapon subWeapon = _subWeapon;
			float num = ((Weapon)subWeapon)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num;
		}
		return ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public TP_PlatinumWhip2_Weapon()
	{
		_specialCounter = 3;
		_subWeaponCounter = 7;
		((Weapon)this)._002Ector();
	}
}
