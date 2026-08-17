using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class GunsCounterWeapon : GunsWeapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondSetType = WeaponType.GUNS2_COUNTER;
		((Weapon)this).InitWeapon(characterController, weaponType);
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
		_explosionType = WeaponType.FIREEXPLOSION;
		List<float> critChancesArray2 = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray2;
	}

	public override void CheckArcanas()
	{
		//IL_008e: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
			List<Collider> wallsColliders = _wallsColliders;
			_bonusBounces = 1;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj3 < wallsColliders._size)
			{
				List<Collider> wallsColliders2 = _wallsColliders;
				if ((nint)obj2 < wallsColliders2._size)
				{
					Collider[] items = wallsColliders2._items;
					World world = ArcadePhysics.s_world.removeCollider(items[obj2]);
					wallsColliders = _wallsColliders;
					obj2++;
					obj3 = obj2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			currentWeaponData2._003ChitsWalls_003Ek__BackingField = false;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj4 = default(object);
		if ((nint)obj4 != -1)
		{
			GameManager gameMan2 = _gameMan;
			ArcanaManager arcanaManager3 = gameMan2._arcanaManager;
			float heartOfFirePower = base.HeartOfFirePower;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj5 = default(object);
			if (obj5 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				float newWeaponPower = default(float);
				arcanaManager3.UpdateHeartOfFirePower(newWeaponPower);
			}
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00cb: Expected I, but got O
		//IL_00d8: Expected I, but got O
		//IL_00e8: Expected O, but got I
		//IL_0124: Expected O, but got I
		base.Fire(skipTriggers);
		if (!_hasSecondSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_secondSetType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasSecondSet = true;
				_secondSet = weaponByType;
				_secondSet.Cleanup();
				GameObject gameObject = _secondSet.gameObject;
				gameObject.SetActive(value: true);
				Weapon secondSet = _secondSet;
				nint num = (nint)typeof(Guns2Weapon);
				nint num2 = (nint)secondSet;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Guns2Weapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Guns2Weapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v37+FFFFFFF8+v292 @ rax_v36*8]");
					if (0 == (nint)typeof(Guns2Weapon))
					{
						_ = 0;
						goto IL_0239;
					}
				}
				throw new InvalidCastException();
			}
		}
		goto IL_0239;
		IL_0239:
		Weapon secondSet2 = _secondSet;
		if ((object)_secondSet != null && ((UnityEngine.Object)secondSet2).m_CachedPtr != (IntPtr)0)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			Action onComplete = delegate
			{
				_secondSet.Fire();
			};
			float num4 = currentWeaponData._003CrepeatInterval_003Ek__BackingField * 0.5f;
			float duration = num4 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public GunsCounterWeapon()
	{
		_secondSetType = WeaponType.GUNS2;
		_counterWeaponType = WeaponType.GUNS_COUNTER;
		((Weapon)this)._002Ector();
	}

	private void _003CFire_003Eb__2_0()
	{
		_secondSet.Fire();
	}
}
