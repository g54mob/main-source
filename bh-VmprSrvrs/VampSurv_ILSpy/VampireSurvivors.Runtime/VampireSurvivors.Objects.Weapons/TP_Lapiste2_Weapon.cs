using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Lapiste2_Weapon : Weapon
{
	private Projectile _InvisibleProjectilePrefab;

	private Projectile _BigFistProjectilePrefab;

	private BulletPool _invisibleProjectilePool;

	private BulletPool _bigFistProjectilePool;

	private const int BigFistFireInterval = 14;

	private const float BigFistDamageMultiplier = 5f;

	private int _fireCounter;

	public BulletPool InvisibleProjectilePool => _invisibleProjectilePool;

	protected override void OnStart()
	{
		//IL_008c: Expected I, but got O
		//IL_012f: Expected I, but got O
		//IL_02a8: Expected I, but got O
		base.OnStart();
		if (_invisibleProjectilePool != null)
		{
			goto IL_0167;
		}
		BulletPool invisibleProjectilePool = new BulletPool(_InvisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0167;
			}
		}
		goto IL_02e1;
		IL_02e1:
		throw new NullReferenceException();
		IL_0167:
		if (_bigFistProjectilePool != null)
		{
			return;
		}
		BulletPool bigFistProjectilePool = new BulletPool(_BigFistProjectilePrefab);
		_bigFistProjectilePool = bigFistProjectilePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemy_BigFist;
			Collider collider3 = physics3.add.overlap(_bigFistProjectilePool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider4 = physics4.add.overlap(_bigFistProjectilePool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_02e1;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		_fireCounter = 0;
	}

	public override void ParadoxFire()
	{
		Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0038: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		GetTargetTransform();
		int num = _fireCounter + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		_fireCounter = num;
		object obj = num >> 3;
		object obj2 = obj >> 31;
		object obj3 = obj + obj2;
		object obj4 = obj3 * 14;
		if (num == (nint)obj4)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0);
			Projectile projectile2 = base.FireOneProjectile(pos, 1);
		}
		base.Fire(skipTriggers);
	}

	private unsafe void GetTargetTransform()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Ref, but got Unknown
		//IL_0043: Expected O, but got Ref
		if (IsHoming)
		{
			GameManager core = GM.Core;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				Transform targetTransform = enemyController.transform;
				_targetTransform = targetTransform;
				return;
			}
		}
		GameManager gameMan = _gameMan;
		ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
		Transform targetTransform2 = gameMan._stage.PickRandomEnemy(ref rng);
		_targetTransform = targetTransform2;
	}

	private void CheckForBigFist()
	{
		//IL_0019: Expected O, but got I
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj = num + _fireCounter;
		object obj2 = obj >> 3;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 14;
		if (_fireCounter == (nint)obj5)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0);
			Projectile projectile2 = base.FireOneProjectile(pos, 1);
		}
	}

	private void FireBigFists()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0);
		Projectile projectile2 = base.FireOneProjectile(pos, 1);
	}

	private bool OnBulletOverlapsEnemy_BigFist(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015a: Expected I4, but got O
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
						goto IL_0177;
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
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 * obj2;
									float damage = (float)obj * 5f;
									base.DealDamage(component, damage);
								}
								goto IL_0177;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0177:
		return false;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_explodeOnExpire = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.5f;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				GameManager gameMan4 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan4._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan5 = _gameMan;
		ArcanaManager arcanaManager4 = gameMan5._arcanaManager;
		List<ArcanaType> list4 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}

	private void _003CParadoxFire_003Eb__11_0()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__11_1()
	{
		Fire(skipTriggers: true);
	}
}
