using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_TP_Savrog2_Weapon : TP_Savrog_Weapon
{
	public Color[] _SpriteColours;

	public Color[] _TrailColours;

	private Trapano2Weapon _trapanoWeapon;

	private bool _totalDamageCalculated;

	protected override void Awake()
	{
		base.Awake();
		_totalDamageCalculated = false;
	}

	protected override void OnStart()
	{
		base.OnStart();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x187487D30\"");
	}

	private void SetupTrapanoWeapon()
	{
		//IL_0059: Expected I, but got O
		//IL_0067: Expected I, but got O
		//IL_0077: Expected O, but got I
		//IL_00f7: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_01ac: Expected I, but got O
		//IL_01ba: Expected I, but got O
		//IL_01ca: Expected O, but got I
		//IL_024a: Expected O, but got I4
		//IL_0206: Expected O, but got I
		//IL_023c: Expected O, but got I4
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.TRAPANO2, ((Equipment)this)._003COwner_003Ek__BackingField);
		Equipment equipment;
		Weapon trapanoWeapon;
		if ((object)weapon == null)
		{
			equipment = null;
			trapanoWeapon = null;
			goto IL_02c4;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(Trapano2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Trapano2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Trapano2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v57+FFFFFFF8+v204 @ rax_v52*8]");
			if (0 == (nint)typeof(Trapano2Weapon))
			{
				obj3 = 1;
				goto IL_02d3;
			}
		}
		obj3 = 0;
		goto IL_02d3;
		IL_0332:
		object obj4;
		Equipment removedEquipment;
		if (obj4 != null)
		{
			equipment = removedEquipment;
		}
		goto IL_0354;
		IL_02c4:
		_trapanoWeapon = (Trapano2Weapon)trapanoWeapon;
		Trapano2Weapon trapanoWeapon2 = _trapanoWeapon;
		if ((object)_trapanoWeapon != null && ((UnityEngine.Object)trapanoWeapon2).m_CachedPtr != (IntPtr)0)
		{
			Trapano2Weapon trapanoWeapon3 = _trapanoWeapon;
			trapanoWeapon3._003CIsUnion_003Ek__BackingField = true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		removedEquipment = characterController._weaponsManager.GetRemovedEquipment(WeaponType.TRAPANO2);
		if ((object)removedEquipment != null)
		{
			nint num4 = (nint)removedEquipment;
			nint num5 = (nint)typeof(Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v37+FFFFFFF8+v471 @ rax_v33*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj4 = 1;
					goto IL_0332;
				}
			}
			obj4 = 0;
			goto IL_0332;
		}
		goto IL_0354;
		IL_02d3:
		bool flag = obj3 == null;
		equipment = null;
		trapanoWeapon = null;
		if (!flag)
		{
			equipment = null;
			trapanoWeapon = weapon;
		}
		goto IL_02c4;
		IL_0354:
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks((Weapon)equipment, _trapanoWeapon);
		}
		GameManager core2 = GM.Core;
		core2._levelUpFactory.ForceExclude(WeaponType.TRAPANO2);
	}

	public override void InternalUpdate()
	{
		//IL_009f: Invalid comparison between F4 and I4
		((Weapon)this).InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float num3 = num / 16.666666f;
		float num4 = frameWalk * 100f;
		float num5 = num4 * num3;
		float num6 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num5 + num2);
		float num7 = base.PInterval();
		if (!(num6 < frameWalk))
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController._walked > 0f)
			{
				((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
		Trapano2Weapon trapanoWeapon = _trapanoWeapon;
		if ((object)_trapanoWeapon != null && ((UnityEngine.Object)trapanoWeapon).m_CachedPtr != (IntPtr)0)
		{
			_trapanoWeapon.InternalUpdate();
		}
	}

	public override void SetVisible(bool visible)
	{
		Trapano2Weapon trapanoWeapon = _trapanoWeapon;
		_isVisible = visible;
		if ((object)_trapanoWeapon == null || ((UnityEngine.Object)trapanoWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		_trapanoWeapon.SetVisible(visible);
		Trapano2Weapon trapanoWeapon2 = _trapanoWeapon;
		if (!visible)
		{
			if (((Weapon)trapanoWeapon2)._firingTimer != null)
			{
				((Weapon)trapanoWeapon2)._firingTimer.Cancel();
			}
			if (((Weapon)trapanoWeapon2)._firingAnimEvent != null)
			{
				((Weapon)trapanoWeapon2)._firingAnimEvent.Cancel();
			}
		}
		else
		{
			_trapanoWeapon.ResetFiringTimer();
		}
	}

	public override void Cleanup()
	{
		_trapanoWeapon.Cleanup();
		base.Cleanup();
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			Trapano2Weapon trapanoWeapon = _trapanoWeapon;
			float num = ((Weapon)trapanoWeapon)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num;
		}
		return ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
	}
}
