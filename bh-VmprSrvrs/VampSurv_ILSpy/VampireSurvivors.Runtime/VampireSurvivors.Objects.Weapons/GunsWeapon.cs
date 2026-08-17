using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GunsWeapon : Weapon
{
	protected bool _hasSecondSet;

	protected Weapon _secondSet;

	protected WeaponType _secondSetType = WeaponType.GUNS2;

	protected WeaponType _counterWeaponType = WeaponType.GUNS_COUNTER;

	protected Weapon _counterWeapon;

	[NonSerialized]
	public BulletPool _explosionPool;

	private Projectile _explosionPrefab;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
		_explosionType = WeaponType.FIREEXPLOSION;
	}

	public override void CheckArcanas()
	{
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_03b4: Expected I, but got O
		//IL_03c2: Expected I, but got O
		//IL_03d2: Expected O, but got I
		//IL_0452: Expected O, but got I4
		//IL_040e: Expected O, but got I
		//IL_0444: Expected O, but got I4
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
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				GameManager gameMan2 = _gameMan;
				ArcanaManager arcanaManager3 = gameMan2._arcanaManager;
				float heartOfFirePower = base.HeartOfFirePower;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					float newWeaponPower = default(float);
					arcanaManager3.UpdateHeartOfFirePower(newWeaponPower);
				}
			}
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager4 = core2._arcanaManager;
		List<ArcanaType> list3 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj4 = default(object);
		if ((nint)obj4 <= -1)
		{
			goto IL_0476;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core3 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon3 = core3._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon3 == null;
		Weapon weapon4 = null;
		if (flag)
		{
			goto IL_04e3;
		}
		nint num = (nint)weapon3;
		nint num2 = (nint)typeof(GunsCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.GunsCounterWeapon>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.GunsCounterWeapon>)+130]");
		object obj7;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rax_v51+FFFFFFF8+v954 @ rax_v47*8]");
			if (0 == (nint)typeof(GunsCounterWeapon))
			{
				obj7 = 1;
				goto IL_04f2;
			}
		}
		obj7 = 0;
		goto IL_04f2;
		IL_04e3:
		_counterWeapon = weapon4;
		while (((Equipment)weapon4)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag2 = weapon4.LevelUp();
		}
		goto IL_0476;
		IL_04f2:
		bool flag3 = obj7 == null;
		weapon4 = null;
		if (!flag3)
		{
			weapon4 = weapon3;
		}
		goto IL_04e3;
		IL_0476:
		CheckBeginningArcana();
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
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_secondSetType);
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

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_025e: Expected I4, but got O
		//IL_00df: Expected I, but got O
		//IL_00e7: Expected I, but got O
		//IL_00f7: Expected O, but got I
		//IL_0177: Expected O, but got I4
		//IL_0133: Expected O, but got I
		//IL_0169: Expected O, but got I4
		//IL_02f7: Expected I, but got O
		IDamageable damageable;
		Projectile projectile;
		if (first == null)
		{
			damageable = null;
			projectile = null;
			goto IL_027e;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v24+FFFFFFF8+v56 @ rax_v20*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_029b;
			}
		}
		obj3 = 0;
		goto IL_029b;
		IL_02c2:
		object obj4;
		if (obj4 != null)
		{
			projectile = (Projectile)second;
		}
		goto IL_0321;
		IL_0321:
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v1 (VampireSurvivors.Interfaces.IDamageable)+260]");
			if ((nint)0 == 0)
			{
				if ((object)projectile == null)
				{
					goto IL_0250;
				}
				if (!projectile.HasAlreadyHitObject(damageable))
				{
					float num4 = base.PPower();
					WeaponData currentWeaponData = _currentWeaponData;
					object obj5 = default(object);
					float num5 = (float)obj5 * 0.5f;
					if (_currentWeaponData != null)
					{
						HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
					}
					else
					{
						HitVfxType hitVfxType = HitVfxType.Default;
					}
					float knockback = base.Knockback;
					nint num6 = (nint)damageable;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v302 @ rdx_v8 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+3E8] (should have been resolved before IL gen)");
					float num7 = num5 + base._003CStatsInflictedDamage_003Ek__BackingField;
					base._003CStatsInflictedDamage_003Ek__BackingField = num7;
				}
			}
			return false;
		}
		goto IL_0250;
		IL_027e:
		if (second != null)
		{
			nint num8 = (nint)typeof(Projectile);
			nint num9 = (nint)second;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v18+FFFFFFF8+v141 @ rax_v14*8]");
				if (0 == (nint)typeof(Projectile))
				{
					obj4 = 1;
					goto IL_02c2;
				}
			}
			obj4 = 0;
			goto IL_02c2;
		}
		goto IL_0321;
		IL_0250:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_029b:
		bool flag = obj3 == null;
		damageable = null;
		projectile = null;
		if (!flag)
		{
			damageable = (IDamageable)first;
			projectile = null;
		}
		goto IL_027e;
	}

	private void _003CFire_003Eb__10_0()
	{
		_secondSet.Fire();
	}
}
