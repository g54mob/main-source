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

public class Guns2Weapon : Weapon
{
	[NonSerialized]
	public bool _doFiring = true;

	protected WeaponType _counterWeaponType = WeaponType.GUNS2_COUNTER;

	protected Weapon _counterWeapon;

	protected WeaponType _secondSetType;

	public override void ResetFiringTimer()
	{
		if (_doFiring)
		{
			base.ResetFiringTimer();
		}
	}

	public void ResetFiringTimerPublic()
	{
		ResetFiringTimer();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
	}

	public override void CheckArcanas()
	{
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_02fa: Expected I, but got O
		//IL_0308: Expected I, but got O
		//IL_0318: Expected O, but got I
		//IL_0398: Expected O, but got I4
		//IL_0354: Expected O, but got I
		//IL_038a: Expected O, but got I4
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
			Weapon weapon = null;
			Weapon weapon2 = null;
			while ((nint)weapon2 < wallsColliders._size)
			{
				List<Collider> wallsColliders2 = _wallsColliders;
				if ((nint)weapon < wallsColliders2._size)
				{
					Collider[] items = wallsColliders2._items;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if ((object)s_scene.physics != null)
						{
							World world = ArcadePhysics.s_world.removeCollider(items[(object)weapon]);
							wallsColliders = _wallsColliders;
							weapon = (Weapon)(weapon + 1);
							weapon2 = weapon;
							continue;
						}
					}
					throw new NullReferenceException();
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
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			base._003CFreezeChance_003Ek__BackingField = 0.25f;
		}
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager3 = core3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 <= -1)
		{
			goto IL_03e2;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core4 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon3 = core4._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon3 == null;
		Weapon weapon4 = null;
		if (flag)
		{
			goto IL_048a;
		}
		nint num = (nint)weapon3;
		nint num2 = (nint)typeof(Guns2CounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Guns2CounterWeapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Guns2CounterWeapon>)+130]");
		object obj6;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rax_v54+FFFFFFF8+v808 @ rax_v50*8]");
			if (0 == (nint)typeof(Guns2CounterWeapon))
			{
				obj6 = 1;
				goto IL_0499;
			}
		}
		obj6 = 0;
		goto IL_0499;
		IL_03e2:
		CheckBeginningArcana();
		return;
		IL_0499:
		bool flag2 = obj6 == null;
		weapon4 = null;
		if (!flag2)
		{
			weapon4 = weapon3;
		}
		goto IL_048a;
		IL_048a:
		_counterWeapon = weapon4;
		while (((Equipment)weapon4)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag3 = weapon4.LevelUp();
		}
		goto IL_03e2;
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

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}
}
