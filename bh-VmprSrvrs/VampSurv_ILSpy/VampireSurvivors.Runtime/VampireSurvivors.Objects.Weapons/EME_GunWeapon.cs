using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_GunWeapon : Weapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
		_explosionType = WeaponType.FIREEXPLOSION;
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
		if ((nint)0 != 0)
		{
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
		CheckBeginningArcana();
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_01ab->IL012e: Incompatible stack heights: 1 vs 0
		//IL_0219->IL012e: Incompatible stack heights: 3 vs 0
		//IL_0268->IL012e: Incompatible stack heights: 4 vs 0
		//IL_02c0->IL0309: Incompatible stack heights: 4 vs 0
		//IL_02c5->IL02e9: Incompatible stack heights: 4 vs 0
		GameManager core = GM.Core;
		Projectile projectile;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
			{
				projectile = null;
				goto IL_02e9;
			}
			int num = 0;
			float2 pos2 = default(float2);
			while (true)
			{
				bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if ((object)transform == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag3 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)transform2 == null)
				{
					break;
				}
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				if (_projectilePool == null)
				{
					break;
				}
				projectile = _projectilePool.SpawnAt(pos2, this, num);
				if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0 && (object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					projectile.SetTarget(target);
				}
				int num2 = num + 1;
				bool flag5 = num2 < 4;
				num = num2;
				if (!flag5)
				{
					goto IL_02e9;
				}
			}
		}
		throw new NullReferenceException();
		IL_02e9:
		return projectile;
	}
}
