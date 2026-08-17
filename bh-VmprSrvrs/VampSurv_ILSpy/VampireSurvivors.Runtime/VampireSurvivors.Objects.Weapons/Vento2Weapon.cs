using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Vento2Weapon : Weapon
{
	private BulletPool _extraPool;

	private bool _generatedPools;

	private Timer _healTimer;

	private bool _canHeal = true;

	private Timer _explodeTimer;

	private bool _canExplode = true;

	private float _walked;

	private Timer _walkedTimer;

	private float _pBonus;

	private const float Mul = 166.66667f;

	private const float HealDelay = 500f;

	private const float ExplodeDelay = 500f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		base._003CTotalTime_003Ek__BackingField = 0f;
	}

	public override float PPower()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num2 = num * currentWeaponData._003Cpower_003Ek__BackingField;
				return num2 + _pBonus;
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_0013: Invalid comparison between I4 and F4
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = deltaTime * 1000f;
		if (0f < characterController._walked)
		{
			if (_walkedTimer != null)
			{
				_walkedTimer.Cancel();
			}
			_walkedTimer = null;
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float num2 = frameWalk * 100f;
			float num3 = (_walked = num2 + _walked) / 200000f;
			bool flag = num3 > 4f;
			float pBonus = 4f;
			if (!flag)
			{
				pBonus = num3;
			}
			_pBonus = pBonus;
		}
		else if (_walkedTimer == null)
		{
			Action onComplete = delegate
			{
				//IL_001d: Invalid comparison between I4 and F4
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if (!(0f < characterController2._walked))
				{
					_walked = 0f;
					_walkedTimer = null;
					_pBonus = 0f;
				}
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer walkedTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_walkedTimer = walkedTimer;
		}
		float num4 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float frameWalk2 = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float num5 = num / 166.66667f;
		float num6 = frameWalk2 * 100f;
		float num7 = num6 * num5;
		float num8 = (base._003CTotalTime_003Ek__BackingField = num7 + num4);
		float num9 = base.PInterval();
		if (!(num8 < frameWalk2))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_extraPool != null)
		{
			_extraPool.Cleanup();
		}
		if (_healTimer != null)
		{
			_healTimer.Cancel();
		}
		if (_explodeTimer != null)
		{
			_explodeTimer.Cancel();
		}
		if (_walkedTimer != null)
		{
			_walkedTimer.Cancel();
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		GameManager core = GM.Core;
		Projectile projectile;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
			{
				projectile = null;
				goto IL_0289;
			}
			if (_projectilePool != null)
			{
				float2 pos2 = default(float2);
				projectile = _projectilePool.SpawnAt(pos2, this, index);
				if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0 && (object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					projectile.SetTarget(target);
				}
				if (_extraPool != null)
				{
					Projectile projectile2 = _extraPool.SpawnAt(pos2, this, index);
					if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0 && (object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
					{
						projectile2.SetTarget(target);
					}
					goto IL_0289;
				}
			}
		}
		return (Projectile)(object)new NullReferenceException();
		IL_0289:
		return projectile;
	}

	protected override void OnStart()
	{
		//IL_0163: Expected I, but got O
		//IL_01f4: Expected I, but got O
		//IL_0297: Expected I, but got O
		base.OnStart();
		if (!_generatedPools)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.VENTO2_EXPLO);
			BulletPool secondaryPool = new BulletPool(projectilePrefab);
			_secondaryPool = secondaryPool;
			Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.VENTO2_EXTRA);
			BulletPool extraPool = new BulletPool(projectilePrefab2);
			_extraPool = extraPool;
			_generatedPools = true;
		}
		base._003CCanCrit_003Ek__BackingField = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = OnExplosionOverlapsEnemy;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_secondaryPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Vento2Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_secondaryPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Vento2Weapon>)+350]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider3 = physics3.add.overlap(_extraPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					PhysicsManager physicsManager2 = core4._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Vento2Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					Collider collider4 = physics4.add.overlap(_extraPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0026: Expected I, but got O
		//IL_002e: Expected I, but got O
		//IL_003e: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_007a: Expected O, but got I
		//IL_00b0: Expected O, but got I4
		//IL_05cc: Expected O, but got F4
		//IL_0180: Invalid comparison between F4 and O
		//IL_06df: Expected I4, but got O
		//IL_03d3: Expected O, but got I4
		//IL_01e8: Expected I4, but got O
		//IL_03ef: Expected I, but got O
		//IL_03f7: Expected I, but got O
		//IL_0407: Expected O, but got I
		//IL_0487: Expected O, but got I4
		//IL_0659: Expected O, but got I4
		//IL_0443: Expected O, but got I
		//IL_0479: Expected O, but got I4
		//IL_069b: Expected I, but got O
		//IL_060b->IL06c5: Incompatible stack heights: 3 vs 2
		//IL_0684->IL05bd: Incompatible stack heights: 2 vs 0
		//IL_029e->IL029e: Incompatible stack heights: 3 vs 2
		//IL_04c5->IL05bd: Incompatible stack heights: 2 vs 0
		//IL_04e4->IL05bd: Incompatible stack heights: 2 vs 0
		//IL_06c5->IL05bd: Incompatible stack heights: 2 vs 0
		//IL_03bc->IL03bc: Incompatible stack heights: 3 vs 2
		//IL_037f->IL0615: Incompatible stack heights: 3 vs 2
		IDamageable damageable;
		bool flag;
		if (first == null)
		{
			damageable = null;
			flag = false;
			goto IL_05a0;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v85+FFFFFFF8+v60 @ rax_v81*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_0570;
			}
		}
		obj3 = 0;
		goto IL_0570;
		IL_0642:
		object obj4;
		bool flag2 = obj4 == null;
		Projectile projectile = (Projectile)flag;
		if (!flag2)
		{
			projectile = (Projectile)second;
		}
		goto IL_066c;
		IL_05bd:
		return false;
		IL_05a0:
		float num5;
		float num6;
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (VampireSurvivors.Interfaces.IDamageable)+260]");
				if ((nint)0 == 0)
				{
					object obj5 = UnityEngine.Random.value;
					WeaponData currentWeaponData = _currentWeaponData;
					bool flag3 = _currentWeaponData == null;
					bool flag4 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
					float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					object obj6 = default(object);
					num5 = (float)obj6 * currentWeaponData._003CcritChance_003Ek__BackingField;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
					{
						WeaponData currentWeaponData2 = _currentWeaponData;
						bool flag5 = _currentWeaponData == null;
						num6 = currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
					}
					else
					{
						num6 = 1f;
					}
					bool flag6 = !(num6 > 1f);
					int num7 = (int)first;
					if (!flag6)
					{
						bool flag7 = !_canHeal;
						num7 = (int)first;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						if (!flag7)
						{
							_canHeal = false;
							bool flag8 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
							((Equipment)this)._003COwner_003Ek__BackingField.RecoverHp(8f, showRecovery: true);
							Action onComplete = delegate
							{
								_canHeal = true;
							};
							Timer healTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag);
							_healTimer = healTimer;
							num7 = 0;
							num5 = 0.5f;
						}
						if (_canExplode)
						{
							_canExplode = false;
							Action onComplete2 = delegate
							{
								_canExplode = true;
							};
							Timer explodeTimer = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag);
							_explodeTimer = explodeTimer;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (VampireSurvivors.Interfaces.IDamageable)+10]");
							ArcadeSprite arcadeSprite;
							if ((nint)0 == 0)
							{
								arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
								bool flag9 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
							}
							else
							{
								arcadeSprite = (ArcadeSprite)damageable;
							}
							float2 position = arcadeSprite.position;
							bool flag10 = _secondaryPool == null;
							Projectile projectile2 = _secondaryPool.SpawnAt(position, this);
							num7 = 0;
							num5 = 0.5f;
						}
					}
					bool flag11 = second == null;
					projectile = (Projectile)flag;
					if (!flag11)
					{
						nint num8 = (nint)typeof(Projectile);
						nint num9 = (nint)second;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						if (num10 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ rax_v41+FFFFFFF8+v750 @ rax_v37*8]");
							if (0 == (nint)typeof(Projectile))
							{
								obj4 = 1;
								goto IL_0642;
							}
						}
						obj4 = 0;
						goto IL_0642;
					}
					goto IL_066c;
				}
			}
		}
		goto IL_05bd;
		IL_066c:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0 && !projectile.HasAlreadyHitObject(damageable))
		{
			float num11 = PPower();
			WeaponData currentWeaponData3 = _currentWeaponData;
			float num12 = num5 * num6;
			if (_currentWeaponData != null)
			{
				HitVfxType hitVfxType = currentWeaponData3._003ChitVFX_003Ek__BackingField;
			}
			else
			{
				HitVfxType hitVfxType = HitVfxType.Default;
			}
			float knockback = base.Knockback;
			nint num13 = (nint)damageable;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v289 @ rdx_v12 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+3E8] (should have been resolved before IL gen)");
			float num14 = num12 + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num14;
		}
		goto IL_05bd;
		IL_0570:
		bool flag12 = obj3 == null;
		damageable = null;
		flag = false;
		if (!flag12)
		{
			damageable = (IDamageable)first;
			flag = false;
		}
		goto IL_05a0;
	}

	protected bool OnExplosionOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0026: Expected I, but got O
		//IL_002e: Expected I, but got O
		//IL_003e: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_007a: Expected O, but got I
		//IL_00b0: Expected O, but got I4
		//IL_0467: Expected O, but got F4
		//IL_0165: Invalid comparison between F4 and O
		//IL_0532: Expected I4, but got O
		//IL_026e: Expected O, but got I4
		//IL_01b7: Expected I4, but got O
		//IL_028a: Expected I, but got O
		//IL_0292: Expected I, but got O
		//IL_02a2: Expected O, but got I
		//IL_0322: Expected O, but got I4
		//IL_04ac: Expected O, but got I4
		//IL_02de: Expected O, but got I
		//IL_0314: Expected O, but got I4
		//IL_04ee: Expected I, but got O
		IDamageable damageable;
		bool flag;
		if (first == null)
		{
			damageable = null;
			flag = false;
			goto IL_043b;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v69+FFFFFFF8+v60 @ rax_v65*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_040b;
			}
		}
		obj3 = 0;
		goto IL_040b;
		IL_0458:
		return false;
		IL_04bf:
		Projectile projectile;
		float num6;
		float num7;
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0 && !projectile.HasAlreadyHitObject(damageable))
		{
			float num4 = PPower();
			WeaponData currentWeaponData = _currentWeaponData;
			float num5 = num6 * num7;
			if (_currentWeaponData != null)
			{
				HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
			}
			else
			{
				HitVfxType hitVfxType = HitVfxType.Default;
			}
			float knockback = base.Knockback;
			nint num8 = (nint)damageable;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v286 @ rdx_v14 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+3E8] (should have been resolved before IL gen)");
			float num9 = num5 + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num9;
		}
		goto IL_0458;
		IL_043b:
		object obj8;
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v1 (VampireSurvivors.Interfaces.IDamageable)+260]");
				if ((nint)0 == 0)
				{
					object obj4 = UnityEngine.Random.value;
					WeaponData currentWeaponData2 = _currentWeaponData;
					float num10 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					object obj5 = default(object);
					num6 = (float)obj5 * currentWeaponData2._003CcritChance_003Ek__BackingField;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
					{
						WeaponData currentWeaponData3 = _currentWeaponData;
						num7 = currentWeaponData3._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
					}
					else
					{
						num7 = 1f;
					}
					bool flag2 = !(num7 > 1f);
					bool flag3 = (byte)(int)first != 0;
					if (!flag2)
					{
						bool flag4 = !_canHeal;
						flag3 = (byte)(int)first != 0;
						if (!flag4)
						{
							_canHeal = false;
							((Equipment)this)._003COwner_003Ek__BackingField.RecoverHp(8f, showRecovery: true);
							Action onComplete = delegate
							{
								_canHeal = true;
							};
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer healTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag);
							_healTimer = healTimer;
							flag3 = false;
							num6 = 0.5f;
						}
					}
					bool flag5 = second == null;
					projectile = (Projectile)flag;
					if (!flag5)
					{
						nint num11 = (nint)typeof(Projectile);
						nint num12 = (nint)second;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v667 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+130]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v667 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						if (num13 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+C8]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rax_v44+FFFFFFF8+v669 @ rax_v40*8]");
							if (0 == (nint)typeof(Projectile))
							{
								obj8 = 1;
								goto IL_0495;
							}
						}
						obj8 = 0;
						goto IL_0495;
					}
					goto IL_04bf;
				}
			}
		}
		goto IL_0458;
		IL_0495:
		bool flag6 = obj8 == null;
		projectile = (Projectile)flag;
		if (!flag6)
		{
			projectile = (Projectile)second;
		}
		goto IL_04bf;
		IL_040b:
		bool flag7 = obj3 == null;
		damageable = null;
		flag = false;
		if (!flag7)
		{
			damageable = (IDamageable)first;
			flag = false;
		}
		goto IL_043b;
	}

	public override void SetVisible(bool visible)
	{
		//IL_0018: Expected O, but got I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0179: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		bool isVisible = default(bool);
		_isVisible = isVisible;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		object obj2 = default(object);
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			Projectile projectile = items[obj];
			bool flag2 = (nint)items[obj] < 0;
			if ((object)items[obj] != null)
			{
				flag2 = (nint)((UnityEngine.Object)projectile).m_CachedPtr < 0;
				if (((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					flag2 = (nint)obj2 < 0;
					nint num = (nint)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ r8_v5 (Il2CppMethodInfo)+368] (should have been resolved before IL gen)");
				}
			}
			obj--;
			object obj3 = !flag2;
			if (obj3 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	private void _003CInternalUpdate_003Eb__14_0()
	{
		//IL_001d: Invalid comparison between I4 and F4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (!(0f < characterController._walked))
		{
			_walked = 0f;
			_walkedTimer = null;
			_pBonus = 0f;
		}
	}

	private void _003COnBulletOverlapsEnemy_003Eb__19_0()
	{
		_canHeal = true;
	}

	private void _003COnBulletOverlapsEnemy_003Eb__19_1()
	{
		_canExplode = true;
	}

	private void _003COnExplosionOverlapsEnemy_003Eb__20_0()
	{
		_canHeal = true;
	}
}
