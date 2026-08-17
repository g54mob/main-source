using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class NdujaWeapon : Weapon
{
	public Vector3 FiringOffset;

	private const WeaponType COUNTER_WEAPON_TYPE = WeaponType.NDUJA_COUNTER;

	private Weapon _counterWeapon;

	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0021: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		FiringOffset = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
	}

	public override void CheckArcanas()
	{
		//IL_0115: Expected I, but got O
		//IL_0123: Expected I, but got O
		//IL_0133: Expected O, but got I
		//IL_01b3: Expected O, but got I4
		//IL_016f: Expected O, but got I
		//IL_01a5: Expected O, but got I4
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			goto IL_01fd;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.NDUJA_COUNTER, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(WeaponType.NDUJA_COUNTER, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		if (flag)
		{
			goto IL_0239;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(NdujaCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.NdujaCounterWeapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.NdujaCounterWeapon>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rax_v39+FFFFFFF8+v401 @ rax_v35*8]");
			if (0 == (nint)typeof(NdujaCounterWeapon))
			{
				obj4 = 1;
				goto IL_0248;
			}
		}
		obj4 = 0;
		goto IL_0248;
		IL_0239:
		_counterWeapon = weapon2;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag2 = weapon2.LevelUp();
		}
		goto IL_01fd;
		IL_0248:
		bool flag3 = obj4 == null;
		weapon2 = null;
		if (!flag3)
		{
			weapon2 = weapon;
		}
		goto IL_0239;
		IL_01fd:
		CheckBeginningArcana();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		float num4 = deltaTime * 10000f;
		if (num2 > num4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE570");
			if (_firingTimer != null)
			{
				_firingTimer.Cancel();
			}
		}
	}

	public NdujaWeapon()
	{
		//IL_001f: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		FiringOffset = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		base._002Ector();
	}
}
