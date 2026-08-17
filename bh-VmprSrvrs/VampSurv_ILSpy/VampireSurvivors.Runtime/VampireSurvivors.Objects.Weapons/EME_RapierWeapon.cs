using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_RapierWeapon : EME_Weapon
{
	protected Projectile _MegaSinglePrefab;

	protected Projectile _NoDamageFreezePrefab;

	protected Projectile _NoDamageSlowPrefab;

	public int[] _FireAngles;

	public int[] _FireX;

	public int[] _FireY;

	protected BulletPool _megaSinglePool;

	protected BulletPool _freezeOnlyPool;

	protected BulletPool _slowOnlyPool;

	public BulletPool FreezeOnlyPool => _freezeOnlyPool;

	public BulletPool SlowOnlyPool => _slowOnlyPool;

	public BulletPool MegaSinglePool => _megaSinglePool;

	protected override int _comboIndex1 => 1;

	protected override int _comboIndex2 => 3;

	protected override int _comboIndex3 => 5;

	protected override int ComboIndexFinal => base.ComboIndex3;

	public virtual int DisplayedSlashes()
	{
		return 1;
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		object obj = level - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				if ((nint)obj3 != 1)
				{
					return WeaponType.VOID;
				}
				return WeaponType.EME_RAPIER_TECH_03;
			}
			return WeaponType.EME_RAPIER_TECH_02;
		}
		return WeaponType.EME_RAPIER_TECH_01;
	}

	public override float PPower()
	{
		//IL_0068: Invalid comparison between F4 and I4
		float num = base.PSpeed();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj - 1f;
		float num3 = num2 + num2;
		if (_currentWeaponData != null)
		{
			float num4 = currentWeaponData._003Cpower_003Ek__BackingField;
			if (num3 > 0f)
			{
				num3++;
				num4 *= num3;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num5 = num3 * num4;
					return num3 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override float FinalGlimmerChance()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		object obj = default(object);
		float num2 = (float)obj * _glimmerChance;
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		return (float)obj * num2;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.35f;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected override void InitGlimmer1BulletPool()
	{
		//IL_00dd: Expected I, but got O
		BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
		_glimmer1Pool = glimmer1Pool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Freeze;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	protected override void InitGlimmer2BulletPool()
	{
		//IL_00dd: Expected I, but got O
		BulletPool glimmer2Pool = new BulletPool(_Glimmer2Prefab, 20);
		_glimmer2Pool = glimmer2Pool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Shock;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_glimmer2Pool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer2Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		//IL_0155: Expected I, but got O
		((Weapon)this).OnStart();
		InitGlimmer1BulletPool();
		InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		Projectile megaSinglePrefab = _MegaSinglePrefab;
		if ((object)_MegaSinglePrefab == null || ((UnityEngine.Object)megaSinglePrefab).m_CachedPtr == (IntPtr)0)
		{
			goto IL_018d;
		}
		BulletPool megaSinglePool = new BulletPool(_MegaSinglePrefab, 20);
		_megaSinglePool = megaSinglePool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Mega;
			Collider collider = physics.add.overlap(_megaSinglePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Collider collider2 = physics2.add.overlap(_megaSinglePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_018d;
			}
		}
		goto IL_0376;
		IL_018d:
		Projectile noDamageFreezePrefab = _NoDamageFreezePrefab;
		if ((object)_NoDamageFreezePrefab != null && ((UnityEngine.Object)noDamageFreezePrefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool freezeOnlyPool = new BulletPool(_NoDamageFreezePrefab, 20);
			_freezeOnlyPool = freezeOnlyPool;
			if ((object)GM.Core == null)
			{
				goto IL_0376;
			}
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemy_NoDamageFreeze;
			Collider collider3 = physics3.add.overlap(_freezeOnlyPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
		}
		Projectile noDamageSlowPrefab = _NoDamageSlowPrefab;
		if ((object)_NoDamageSlowPrefab != null && ((UnityEngine.Object)noDamageSlowPrefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool slowOnlyPool = new BulletPool(_NoDamageSlowPrefab, 20);
			_slowOnlyPool = slowOnlyPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				ArcadePhysicsCallback collideCallback4 = OnBulletOverlapsEnemy_NoDamageSlow;
				Collider collider4 = physics4.add.overlap(_slowOnlyPool, core4.Enemies, collideCallback4, processCallback, callbackContext);
				return;
			}
			goto IL_0376;
		}
		return;
		IL_0376:
		throw new NullReferenceException();
	}

	protected bool OnBulletOverlapsEnemy_Mega(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0159: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0176;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 * obj2;
									float damage = (float)obj + (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0176;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0176:
		return false;
	}

	protected bool OnBulletOverlapsEnemy_Freeze(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0136: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0153;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									bool flag = component2.TryFreeze(component);
									base.DealDamage(component);
								}
								goto IL_0153;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0153:
		return false;
	}

	protected bool OnBulletOverlapsEnemy_Shock(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01fd: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_021a;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									GameObject gameObject3 = component.gameObject;
									if ((object)gameObject3 == null)
									{
										goto IL_01ef;
									}
									EnemyController component3 = gameObject3.GetComponent<EnemyController>();
									float num = default(float);
									if ((object)component3 != null && ((UnityEngine.Object)component3).m_CachedPtr != (IntPtr)0 && ((object)component3._003CResDebuffs_003Ek__BackingField == null || num < 1f) && component3._003CSlow_003Ek__BackingField > 0.5f)
									{
										component3._003CSlow_003Ek__BackingField = 0.5f;
									}
									base.DealDamage(component);
								}
								goto IL_021a;
							}
						}
					}
				}
			}
		}
		goto IL_01ef;
		IL_01ef:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_021a:
		return false;
	}

	protected bool OnBulletOverlapsEnemy_NoDamageFreeze(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0132: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_011e;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									bool flag = component2.TryFreeze(component);
								}
								goto IL_011e;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_011e:
		return false;
	}

	protected bool OnBulletOverlapsEnemy_NoDamageSlow(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01fd: Expected I4, but got O
		//IL_01a0: Invalid comparison between O and F4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_021a;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									GameObject gameObject3 = component.gameObject;
									if ((object)gameObject3 == null)
									{
										goto IL_01ef;
									}
									EnemyController component3 = gameObject3.GetComponent<EnemyController>();
									object obj = default(object);
									if ((object)component3 != null && ((UnityEngine.Object)component3).m_CachedPtr != (IntPtr)0 && ((object)component3._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && component3._003CSlow_003Ek__BackingField > 0.2f)
									{
										component3._003CSlow_003Ek__BackingField = 0.2f;
									}
								}
								goto IL_021a;
							}
						}
					}
				}
			}
		}
		goto IL_01ef;
		IL_01ef:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_021a:
		return false;
	}

	protected override void Fire_DoTargeting()
	{
		//IL_0133: Expected O, but got F4
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_011c->IL00c0: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL00c0: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		List<EnemyController> list = Closest(((Equipment)this)._003COwner_003Ek__BackingField, core.Enemies);
		if (list._size <= 1)
		{
			if (list._size != 0)
			{
				bool flag = list._size <= 0;
				EnemyController[] items = list._items;
				Transform targetTransform = items[0].transform;
				_targetTransform = targetTransform;
			}
			else
			{
				_targetTransform = null;
			}
			return;
		}
		object obj = UnityEngine.Random.value;
		object obj3 = default(object);
		object obj2 = list._size * obj3;
		float num = (float)obj2 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj5 = default(object);
		object obj4 = list._size - obj5;
		object obj6 = obj4 - 1;
		bool flag2 = (nint)obj6 >= list._size;
		EnemyController[] items2 = list._items;
		object obj7 = obj4 - 1;
		Transform targetTransform2 = items2[obj7].transform;
		_targetTransform = targetTransform2;
	}

	public EME_RapierWeapon()
	{
		int[] fireAngles = new int[6];
		_FireAngles = fireAngles;
		_FireX = new int[6] { -16, 16, 0, 16, -16, 0 };
		_FireY = new int[6] { -16, 16, 0, 16, -16, 0 };
		base._002Ector();
	}
}
