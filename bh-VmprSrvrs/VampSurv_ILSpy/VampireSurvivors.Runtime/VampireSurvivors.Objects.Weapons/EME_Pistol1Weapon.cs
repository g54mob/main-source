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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Pistol1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public EnemyController enemy;

		public int localIndex;

		public EME_Pistol1Weapon _003C_003E4__this;

		internal void _003CSpawnSpecialProjectiles_003Eb__0()
		{
			//IL_0289: Expected O, but got I4
			//IL_0174: Expected I, but got O
			//IL_017c: Expected I, but got O
			//IL_018c: Expected O, but got I
			//IL_020c: Expected O, but got I4
			//IL_01c8: Expected O, but got I
			//IL_01fe: Expected O, but got I4
			//IL_009f->IL0233: Incompatible stack heights: 1 vs 0
			//IL_0121->IL0233: Incompatible stack heights: 1 vs 0
			Projectile projectile;
			object obj4;
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)enemy;
					if ((object)enemy == null || ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					ArcadeSprite arcadeSprite = enemy;
					if ((object)enemy != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v20 (ArcadeSprite)+260]");
						if ((nint)0 != 0 || arcadeSprite.body == null)
						{
							return;
						}
						float2 position = enemy.position;
						EME_Pistol1Weapon eME_Pistol1Weapon = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							projectile = _003C_003E4__this.FireOneProjectile(pos, localIndex, eME_Pistol1Weapon._targetTransform);
							if ((object)projectile == null)
							{
								return;
							}
							nint num = (nint)typeof(EME_PistolProjectile);
							nint num2 = (nint)projectile;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+130]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rcx_v24+FFFFFFF8+v471 @ rcx_v20*8]");
								if (0 == (nint)typeof(EME_PistolProjectile))
								{
									obj4 = 1;
									goto IL_02ca;
								}
							}
							obj4 = 0;
							goto IL_02ca;
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_02ca:
			bool flag2 = obj4 == null;
			EME_PistolProjectile eME_PistolProjectile = null;
			if (!flag2)
			{
				eME_PistolProjectile = (EME_PistolProjectile)projectile;
			}
			eME_PistolProjectile?.setEnemyTarget(enemy);
		}
	}

	private BulletPool _bdShotPool;

	protected Projectile _bdShotPrefsb;

	private BulletPool _ffExplosionPool;

	protected Projectile _ffExplosionPrefsb;

	private BulletPool _destructibleProjectilePool;

	private Projectile _destructibleProjectilePrefab;

	private float _timeSinceLastFalconFire = 3.4028235E+38f;

	private float _range;

	private float _defaultRange;

	protected override int EvolutionLevel => 8;

	protected override int _comboIndex1 => 4;

	protected override int _comboIndex2 => 8;

	protected override int ComboIndexFinal => base.ComboIndex1;

	protected override bool CanWeaponGlimmer
	{
		get
		{
			//IL_00d7: Expected I4, but got O
			//IL_009f: Invalid comparison between F4 and O
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core._stage;
				if ((object)core._stage != null)
				{
					List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
					if (stage._spawnedEnemies != null)
					{
						if (spawnedEnemies._size > 0)
						{
							float num = base.PInterval();
							float timeSinceLastFalconFire = _timeSinceLastFalconFire;
							object obj = default(object);
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)timeSinceLastFalconFire) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
							{
								return !_ShouldGlimmerNextFire;
							}
						}
						return false;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private bool CanFireFalconFire
	{
		get
		{
			//IL_0014: Invalid comparison between F4 and O
			float num = base.PInterval();
			float timeSinceLastFalconFire = _timeSinceLastFalconFire;
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)timeSinceLastFalconFire) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				return false;
			}
			return !_ShouldGlimmerNextFire;
		}
	}

	public override float PSpeed()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		float num2 = default(float);
		bool flag = !(2.5f > num2);
		float num3 = 2.5f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num4 *= value;
			}
		}
		return num4;
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		if (level == 1)
		{
			return WeaponType.EME_PISTOL_TECH_01;
		}
		bool flag = level != 2;
		WeaponType result = WeaponType.VOID;
		if (!flag)
		{
			result = WeaponType.EME_PISTOL_TECH_02;
		}
		return result;
	}

	protected override void OnStart()
	{
		//IL_0054: Expected I, but got O
		//IL_00f7: Expected I, but got O
		//IL_0249: Expected I, but got O
		//IL_0315: Expected I, but got O
		((Weapon)this).OnStart();
		base.InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		BulletPool bdShotPool = new BulletPool(_bdShotPrefsb, 20);
		_bdShotPool = bdShotPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_bdShotPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_bdShotPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			BulletPool ffExplosionPool = new BulletPool(_ffExplosionPrefsb, 20);
			_ffExplosionPool = ffExplosionPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemyHighDamage;
				Collider collider3 = physics3.add.overlap(_ffExplosionPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					PhysicsManager physicsManager2 = core4._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					Collider collider4 = physics4.add.overlap(_ffExplosionPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
					BulletPool destructibleProjectilePool = new BulletPool(_destructibleProjectilePrefab, 20);
					_destructibleProjectilePool = destructibleProjectilePool;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene5 = ArcadePhysics.s_scene;
						ArcadePhysics physics5 = s_scene5.physics;
						GameManager core5 = GM.Core;
						PhysicsManager physicsManager3 = core5._physicsManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+3A0]");
						ArcadePhysicsCallback collideCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
						nint num4 = (nint)this;
						Collider collider5 = physics5.add.overlap(_destructibleProjectilePool, physicsManager3._destructiblesGroup, collideCallback5, processCallback, callbackContext);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene6 = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer = s_scene6._renderer;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene7 = ArcadePhysics.s_scene;
								PhaserScene.Renderer renderer2 = s_scene7._renderer;
								float num5 = renderer2.height * 0.2f;
								float num6 = renderer.width * 0.2f;
								if (!(num5 > num6))
								{
									num6 = num5;
								}
								_defaultRange = num6;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void DoFalconFireExplosionAt(Vector2 position)
	{
		float num = base.PArea();
		float num2 = default(float);
		if (2f > num2)
		{
		}
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0);
		Projectile projectile2 = base.FireOneProjectile(pos, 0);
		Projectile projectile3 = base.FireOneProjectile(pos, 0);
		Projectile projectile4 = base.FireOneProjectile(pos, 0);
	}

	public void DoBoundingShotExplosionAt(Vector2 position)
	{
		Projectile projectile = base.FireOneProjectile(position, 0);
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		if (index == 0)
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		if (index == 0)
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}

	public unsafe void SpawnSpecialProjectiles(float2 position, BulletPool pool, float amountMul = 1f, float areaMul = 1f)
	{
		//IL_002f: Expected O, but got Ref
		//IL_0038: Expected I, but got O
		//IL_0048: Expected O, but got I
		//IL_036b: Invalid comparison between F4 and I4
		//IL_03bc: Invalid comparison between F4 and I4
		//IL_032d: Invalid comparison between F4 and I4
		//IL_016b: Expected I, but got O
		//IL_0173: Expected I4, but got O
		//IL_0183: Expected O, but got I
		//IL_0203: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		//IL_01f5: Expected O, but got I4
		float num = base.PArea();
		GameManager core = GM.Core;
		object obj = default(object);
		object obj2 = default(object);
		float maxRange = (float)obj * (float)obj2;
		object obj3 = default(object);
		List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&obj3), excludeDead: true, maxRange);
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+408]");
		Action<float> action = (Action<float>)0;
		float num3 = base.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		Action<float> action2 = default(Action<float>);
		float num4 = (float)action2 * amountMul;
		float num5 = currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		float num6 = base.PInterval();
		float num7 = num4 + 1f;
		float num8 = (float)action2 / num7;
		if (!(num8 > currentWeaponData._003CrepeatInterval_003Ek__BackingField))
		{
			num5 = num8;
		}
		if (!(num4 > 0f))
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		EME_PistolProjectile eME_PistolProjectile = default(EME_PistolProjectile);
		float num11 = default(float);
		EnemyController enemy = default(EnemyController);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool flag5;
		do
		{
			float num9 = (float)(flag2 ? 1 : 0) * num5;
			object obj6;
			if (!(num9 > 0f))
			{
				int num10 = (flag ? 1 : 0) % closestEnemiesSorted._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				float2 position2 = arcadeSprite.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				bool flag3 = (object)eME_PistolProjectile == null;
				bool flag4 = flag;
				action = action2;
				num7 = num11;
				if (!flag3)
				{
					nint num12 = (nint)typeof(EME_PistolProjectile);
					flag4 = (byte)(int)eME_PistolProjectile != 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r9_v3 (System.Boolean)+130]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+130]");
					if (num13 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r9_v3 (System.Boolean)+C8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rcx_v27+FFFFFFF8+v520 @ rcx_v21*8]");
						if (0 == (nint)typeof(EME_PistolProjectile))
						{
							obj6 = 1;
							goto IL_0382;
						}
					}
					obj6 = 0;
					goto IL_0382;
				}
			}
			else
			{
				_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass22_0();
				CS_0024_003C_003E8__locals15._003C_003E4__this = this;
				CS_0024_003C_003E8__locals15.localIndex = (flag ? 1 : 0);
				int num14 = (flag ? 1 : 0) % closestEnemiesSorted._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				CS_0024_003C_003E8__locals15.enemy = enemy;
				Action onComplete = delegate
				{
					//IL_0289: Expected O, but got I4
					//IL_0174: Expected I, but got O
					//IL_017c: Expected I, but got O
					//IL_018c: Expected O, but got I
					//IL_020c: Expected O, but got I4
					//IL_01c8: Expected O, but got I
					//IL_01fe: Expected O, but got I4
					//IL_009f->IL0233: Incompatible stack heights: 1 vs 0
					//IL_0121->IL0233: Incompatible stack heights: 1 vs 0
					Projectile projectile;
					object obj10;
					if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
					{
						GameObject gameObject = CS_0024_003C_003E8__locals15._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj7 == null)
							{
								return;
							}
							GameObject enemy2 = (GameObject)(object)CS_0024_003C_003E8__locals15.enemy;
							if ((object)CS_0024_003C_003E8__locals15.enemy == null || ((UnityEngine.Object)enemy2).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							ArcadeSprite enemy3 = CS_0024_003C_003E8__locals15.enemy;
							if ((object)CS_0024_003C_003E8__locals15.enemy != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v20 (ArcadeSprite)+260]");
								if ((nint)0 != 0 || enemy3.body == null)
								{
									return;
								}
								float2 position3 = CS_0024_003C_003E8__locals15.enemy.position;
								EME_Pistol1Weapon eME_Pistol1Weapon = CS_0024_003C_003E8__locals15._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									projectile = CS_0024_003C_003E8__locals15._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals15.localIndex, eME_Pistol1Weapon._targetTransform);
									if ((object)projectile == null)
									{
										return;
									}
									nint num16 = (nint)typeof(EME_PistolProjectile);
									nint num17 = (nint)projectile;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+130]");
									object obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									nint num18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+130]");
									if (num18 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
										object obj9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rcx_v24+FFFFFFF8+v471 @ rcx_v20*8]");
										if (0 == (nint)typeof(EME_PistolProjectile))
										{
											obj10 = 1;
											goto IL_02ca;
										}
									}
									obj10 = 0;
									goto IL_02ca;
								}
							}
						}
					}
					throw new NullReferenceException();
					IL_02ca:
					bool flag9 = obj10 == null;
					EME_PistolProjectile eME_PistolProjectile3 = null;
					if (!flag9)
					{
						eME_PistolProjectile3 = (EME_PistolProjectile)projectile;
					}
					eME_PistolProjectile3?.setEnemyTarget(CS_0024_003C_003E8__locals15.enemy);
				};
				float num15 = (float)(flag2 ? 1 : 0) * num5;
				float duration = num15 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
				bool flag4 = false;
				action = null;
			}
			goto IL_0317;
			IL_0317:
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag5 = num4 > (float)(flag ? 1 : 0);
			flag2 = flag;
			continue;
			IL_0382:
			bool flag6 = obj6 == null;
			EME_PistolProjectile eME_PistolProjectile2 = null;
			if (!flag6)
			{
				eME_PistolProjectile2 = eME_PistolProjectile;
			}
			bool flag7 = (object)eME_PistolProjectile2 == null;
			action = (Action<float>)(object)typeof(EME_PistolProjectile);
			num7 = num11;
			if (!flag7)
			{
				eME_PistolProjectile2.setEnemyTarget((EnemyController)arcadeSprite);
				action = null;
				num7 = num11;
			}
			goto IL_0317;
		}
		while (flag5);
	}

	protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									object obj = default(object);
									float num3 = (float)obj * 2.5f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = base.PInterval();
		float num3 = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField;
		float timeSinceLastFalconFire = num + _timeSinceLastFalconFire;
		((Weapon)this)._003CTotalTime_003Ek__BackingField = num3;
		_timeSinceLastFalconFire = timeSinceLastFalconFire;
		if (!(num3 < deltaTime))
		{
			((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
			PlayNextAttackAnim();
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected unsafe override void Fire_DoAttacks(BulletPool glimmerPool, bool skipTriggers = false)
	{
		//IL_001a: Invalid comparison between F4 and O
		//IL_0439: Expected I, but got O
		//IL_0141: Expected O, but got Ref
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_02f8: Invalid comparison between O and F4
		//IL_0456->IL0388: Incompatible stack heights: 1 vs 0
		//IL_01e2->IL0388: Incompatible stack heights: 2 vs 0
		//IL_0239->IL0388: Incompatible stack heights: 3 vs 0
		//IL_026d->IL035f: Incompatible stack heights: 3 vs 1
		//IL_028c->IL0388: Incompatible stack heights: 3 vs 0
		//IL_0464->IL0469: Incompatible stack heights: 3 vs 1
		//IL_0349->IL0388: Incompatible stack heights: 3 vs 0
		//IL_035f->IL0469: Incompatible stack heights: 3 vs 1
		Vector2 vector2 = default(Vector2);
		if (glimmerPool != null)
		{
			float num = base.PInterval();
			float timeSinceLastFalconFire = _timeSinceLastFalconFire;
			Vector2 vector = default(Vector2);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)timeSinceLastFalconFire) >= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) && !_ShouldGlimmerNextFire)
			{
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					Fire_FireGlimmerProjectile(vector2, 0, _targetTransform);
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						((Equipment)this)._003COwner_003Ek__BackingField.OnGlimmeredTechniqueFired();
						_timeSinceLastFalconFire = 0f;
						goto IL_03ad;
					}
				}
				goto IL_0388;
			}
		}
		goto IL_03ad;
		IL_035f:
		float num2 = base.PInterval();
		float num4;
		float num3 = num4 - 100f;
		((Weapon)this)._003CTotalTime_003Ek__BackingField = num3;
		return;
		IL_0388:
		throw new NullReferenceException();
		IL_03ad:
		float num5 = base.PArea();
		float maxRange = (_range = (float)vector2 * _defaultRange) * 1.45f;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((EventEmitter)(object)transform).callbacks == null;
				float ret;
				Transform.get_position_Injected((IntPtr)((EventEmitter)(object)transform).callbacks, out *(Vector3*)(&ret));
				if ((object)core._stage != null)
				{
					object obj = default(object);
					List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&obj), excludeDead: true, maxRange);
					bool flag2 = closestEnemiesSorted == null;
					num4 = ret;
					if (!flag2)
					{
						bool flag3 = closestEnemiesSorted._size <= 0;
						num4 = ret;
						if (!flag3)
						{
							bool flag4 = closestEnemiesSorted._size <= 0;
							EnemyController[] items = closestEnemiesSorted._items;
							if (closestEnemiesSorted._items != null)
							{
								bool flag5 = items.Length <= 0;
								EnemyController enemyController = items[0];
								if ((object)items[0] != null)
								{
									num4 = _range * _range;
									if (num4 < enemyController.Distance)
									{
										goto IL_035f;
									}
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
									{
										float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
										float areaMul = default(float);
										SpawnSpecialProjectiles(position2, _projectilePool, 3f, areaMul);
										float num6 = base.PInterval();
										float num7 = _lastFiringInterval - 1f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
										object obj2 = num7 & 0;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
										{
											float num8 = base.PInterval();
											_lastFiringInterval = 1f;
											ResetFiringTimer();
										}
										if (skipTriggers)
										{
											return;
										}
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
										{
											((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
											return;
										}
									}
								}
							}
							goto IL_0388;
						}
					}
					goto IL_035f;
				}
			}
		}
		goto IL_0388;
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
		Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	private void _003CParadoxFire_003Eb__33_0()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__33_1()
	{
		Fire(skipTriggers: true);
	}
}
