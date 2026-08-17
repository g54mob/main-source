using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class Guns2CounterWeapon : Guns2Weapon
{
	public override void CheckArcanas()
	{
		//IL_008e: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
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
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj4 = default(object);
		if ((nint)obj4 > -1)
		{
			((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
		}
	}

	public Guns2CounterWeapon()
	{
		_doFiring = true;
		_counterWeaponType = WeaponType.GUNS2_COUNTER;
		((Weapon)this)._002Ector();
	}
}
