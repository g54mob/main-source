using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class CherryWeapon : Weapon
{
	public bool isStars;

	public void SetToStars()
	{
		//IL_0018: Expected O, but got I4
		//IL_0080: Expected I, but got O
		//IL_0088: Expected I, but got O
		//IL_0098: Expected O, but got I
		//IL_00d4: Expected O, but got I
		//IL_0111: Expected O, but got I
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		isStars = true;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			CherryProjectile cherryProjectile = (CherryProjectile)items[obj];
			nint num = (nint)typeof(CherryProjectile);
			nint num2 = (nint)cherryProjectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v12+FFFFFFF8+v64 @ rax_v11*8]");
				if (0 == (nint)typeof(CherryProjectile))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v12+FFFFFFF8+v259 @ rcx_v9*8]");
					object obj5 = 0 - typeof(CherryProjectile);
					bool flag2 = obj5 == null;
					bool flag3 = !flag2;
					CherryProjectile cherryProjectile2 = null;
					if (!flag3)
					{
						cherryProjectile2 = cherryProjectile;
					}
					cherryProjectile2.SetIsStar();
					obj--;
					if ((flag2 ? 1 : 0) < (false ? 1 : 0))
					{
						return;
					}
					continue;
				}
			}
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void CheckArcanas()
	{
		if (!_beginningArcana)
		{
			GameManager gameMan = _gameMan;
			List<WeaponType> list = gameMan._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager gameMan2 = _gameMan;
				List<WeaponType> list2 = gameMan2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj = default(object);
				if (obj != null)
				{
					int beginningAmount = _beginningAmount + 3;
					_beginningAmount = beginningAmount;
					WeaponData currentWeaponData = _currentWeaponData;
					_beginningArcana = true;
					int num = currentWeaponData._003Camount_003Ek__BackingField + 3;
					currentWeaponData._003Camount_003Ek__BackingField = num;
				}
			}
			if (!_beginningArcana)
			{
				GameManager gameMan3 = _gameMan;
				List<WeaponType> list3 = gameMan3._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 > (nint)0)
				{
					GameManager gameMan4 = _gameMan;
					List<WeaponType> list4 = gameMan4._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						int beginningAmount2 = _beginningAmount + 1;
						_beginningAmount = beginningAmount2;
						WeaponData currentWeaponData2 = _currentWeaponData;
						_beginningArcana = true;
						int num2 = currentWeaponData2._003Camount_003Ek__BackingField + 1;
						currentWeaponData2._003Camount_003Ek__BackingField = num2;
					}
				}
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list5 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 > -1)
		{
			_explodeOnExpire = true;
		}
	}
}
