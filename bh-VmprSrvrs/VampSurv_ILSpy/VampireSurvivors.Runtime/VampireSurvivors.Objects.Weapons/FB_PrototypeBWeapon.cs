using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_PrototypeBWeapon : FB_RapidFireWeapon
{
	private BulletPool _planePool;

	private BulletPool _planeBulletsPool;

	private int _planeProjectileAmount;

	private FB_PlaneProjectile[] planeProjectiles;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0171: Expected I, but got O
		//IL_042b: Expected I, but got O
		//IL_0439: Expected I, but got O
		//IL_0449: Expected O, but got I
		//IL_04c9: Expected O, but got I4
		//IL_0485: Expected O, but got I
		//IL_08e1: Expected I, but got O
		//IL_082e: Expected I, but got O
		//IL_083e: Expected O, but got I
		//IL_04bb: Expected O, but got I4
		//IL_0567: Expected O, but got I4
		//IL_04e3: Expected I, but got O
		//IL_0529: Expected O, but got I
		//IL_0514: Expected I, but got O
		//IL_0559: Expected O, but got I4
		//IL_0289: Expected I, but got O
		//IL_06fe: Expected O, but got I4
		//IL_08bf->IL070f: Incompatible stack heights: 1 vs 0
		//IL_03dd->IL070f: Incompatible stack heights: 1 vs 0
		//IL_05b3->IL070f: Incompatible stack heights: 2 vs 0
		//IL_0519->IL0826: Incompatible stack heights: 2 vs 1
		//IL_0607->IL070f: Incompatible stack heights: 3 vs 0
		//IL_063e->IL070f: Incompatible stack heights: 3 vs 0
		//IL_069e->IL070f: Incompatible stack heights: 4 vs 0
		//IL_06ef->IL070f: Incompatible stack heights: 4 vs 0
		//IL_0703->IL031c: Incompatible stack heights: 4 vs 0
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		if (_planePool == null)
		{
			if ((object)_projectileFactory == null)
			{
				goto IL_070f;
			}
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FB_PLANES);
			BulletPool planePool = new BulletPool(projectilePrefab);
			_planePool = planePool;
		}
		if (_planeBulletsPool != null)
		{
			goto IL_02e5;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.FB_PROTOTYPE_B_PLANE);
			BulletPool planeBulletsPool = new BulletPool(projectilePrefab2);
			_planeBulletsPool = planeBulletsPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					ArcadePhysics physics = s_scene.physics;
					if ((object)s_scene.physics != null)
					{
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrototypeBWeapon>)+370]");
							ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (physics.add != null)
							{
								ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
								CallbackContext callbackContext = default(CallbackContext);
								Collider collider = physics.add.overlap(_planeBulletsPool, core.Enemies, collideCallback, processCallback, callbackContext);
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										ArcadePhysics physics2 = s_scene2.physics;
										if ((object)s_scene2.physics != null)
										{
											GameManager core2 = GM.Core;
											if ((object)GM.Core != null)
											{
												PhysicsManager physicsManager = core2._physicsManager;
												if (core2._physicsManager != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1346 @ r8_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrototypeBWeapon>)+3A0]");
													ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num2 = (nint)this;
													if (physics2.add != null)
													{
														Collider collider2 = physics2.add.overlap(_planeBulletsPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
														goto IL_02e5;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_070f;
		IL_070f:
		throw new NullReferenceException();
		IL_02e5:
		FB_PlaneProjectile[] array = planeProjectiles;
		bool flag = planeProjectiles == null;
		Projectile projectile = null;
		int num3 = 0;
		if (!flag)
		{
			Vector2 pos = default(Vector2);
			object obj4 = default(object);
			while (true)
			{
				FB_PlaneProjectile[] array2;
				Projectile projectile2;
				Projectile projectile3;
				object obj3;
				if ((nint)projectile < array.Length)
				{
					ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
					array2 = planeProjectiles;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						break;
					}
					Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
					if (arcadeSprite.body != null)
					{
						BaseBody body = arcadeSprite.body;
						ArcadeTransform arcadeTransform = body._transform;
						if (body._transform == null)
						{
							break;
						}
						arcadeTransform.position = ret;
					}
					projectile2 = base.FireOneProjectileIgnoreDistanceToPlayer(pos, num3, _targetTransform);
					if (planeProjectiles == null)
					{
						break;
					}
					if ((object)projectile2 == null)
					{
						projectile3 = null;
						goto IL_07e7;
					}
					nint num4 = (nint)projectile2;
					nint num5 = (nint)typeof(FB_PlaneProjectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1121 @ rax_v55+FFFFFFF8+v1079 @ rax_v42*8]");
						if (0 == (nint)typeof(FB_PlaneProjectile))
						{
							obj3 = 1;
							goto IL_0804;
						}
					}
					obj3 = 0;
					goto IL_0804;
				}
				_explosionType = WeaponType.FIREEXPLOSION;
				return;
				IL_0804:
				bool flag3 = obj3 == null;
				Projectile projectile4 = null;
				if (!flag3)
				{
					projectile4 = projectile2;
				}
				bool flag4 = (object)projectile4 == null;
				nint num7 = (nint)typeof(FB_PlaneProjectile);
				if (!flag4)
				{
					nint num8 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag5 = obj4 == null;
					num7 = (nint)typeof(FB_PlaneProjectile);
				}
				nint num9 = (nint)projectile2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1092 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1092 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
				object obj7;
				if (num10 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1292 @ rax_v50+FFFFFFF8+v1270 @ rax_v45*8]");
					if (0 == num7)
					{
						obj7 = 1;
						goto IL_086a;
					}
				}
				obj7 = 0;
				goto IL_086a;
				IL_07e7:
				bool flag6 = num3 >= array2.Length;
				array2[num3] = (FB_PlaneProjectile)projectile3;
				FB_PlaneProjectile[] array3 = planeProjectiles;
				if (planeProjectiles == null)
				{
					break;
				}
				bool flag7 = num3 >= array3.Length;
				FB_PlaneProjectile fB_PlaneProjectile = array3[num3];
				if ((object)array3[num3] == null)
				{
					break;
				}
				fB_PlaneProjectile._dist = 0.79999995f;
				FB_PlaneProjectile[] array4 = planeProjectiles;
				if (planeProjectiles == null)
				{
					break;
				}
				bool flag8 = num3 >= array4.Length;
				Sprite sprite = SpriteManager.GetSprite("fb_A2_prototype", "items");
				if ((object)array4[num3] == null)
				{
					break;
				}
				ArcadeSprite arcadeSprite2 = array4[num3].setFrame(sprite);
				array = planeProjectiles;
				num3++;
				if (planeProjectiles == null)
				{
					break;
				}
				projectile = (Projectile)num3;
				continue;
				IL_086a:
				bool flag9 = obj7 == null;
				projectile3 = null;
				if (!flag9)
				{
					projectile3 = projectile2;
				}
				goto IL_07e7;
			}
		}
		goto IL_070f;
	}

	public override void CheckArcanas()
	{
		//IL_01e6: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
		GameManager gameMan4 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan4._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
				List<Collider> wallsColliders = _wallsColliders;
				_bonusBounces = 3;
				object obj4 = 0;
				object obj5 = 0;
				while ((nint)obj5 < wallsColliders._size)
				{
					List<Collider> wallsColliders2 = _wallsColliders;
					if ((nint)obj4 < wallsColliders2._size)
					{
						Collider[] items = wallsColliders2._items;
						World world = ArcadePhysics.s_world.removeCollider(items[obj4]);
						wallsColliders = _wallsColliders;
						obj4++;
						obj5 = obj4;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				WeaponData currentWeaponData2 = _currentWeaponData;
				currentWeaponData2._003ChitsWalls_003Ek__BackingField = false;
			}
		}
		GameManager gameMan5 = _gameMan;
		ArcanaManager arcanaManager4 = gameMan5._arcanaManager;
		List<ArcanaType> list4 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0052: Expected O, but got Ref
		((Weapon)this).Fire(skipTriggers);
		if (!((Equipment)this)._003COwner_003Ek__BackingField.flipX)
		{
		}
		Transform transform = base._pfxEmitter.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		base._pfxEmitter.EmitParticleAt(pos, 20);
		FB_PlaneProjectile[] array = planeProjectiles;
		int num = 0;
		int num2 = 0;
		BulletPool pool = default(BulletPool);
		FB_PlaneProjectile planeProjectile = default(FB_PlaneProjectile);
		while (num < array.Length)
		{
			if (_planeProjectileAmount > 0)
			{
				int num3;
				do
				{
					FB_PlaneProjectile[] array2 = planeProjectiles;
					float2 position2 = array2[num2].position;
					Projectile projectile = FireOnePlaneProjectile(pos, 0, _targetTransform, pool, planeProjectile);
					num3 = 0 + 1;
				}
				while (num3 < _planeProjectileAmount);
			}
			array = planeProjectiles;
			num2++;
			num = num2;
		}
	}

	public unsafe Projectile FireOnePlaneProjectile(Vector2 pos, int index, Transform target, BulletPool pool, FB_PlaneProjectile planeProjectile)
	{
		//IL_007e: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_01d7: Expected I4, but got I8
		//IL_01db: Expected O, but got I4
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected Ref, but got Unknown
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		float2 position = arcadeSprite.position;
		Vector2 pos2 = default(Vector2);
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos2, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_30 (ArcadeSprite)+70]");
			object obj = (nint)0 * (nint)4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_30 (ArcadeSprite)+70]");
			object obj2 = 0 + obj;
			object obj3 = obj2 << 2;
			float num = (float)obj3 - 10f;
			object obj4 = UnityEngine.Random.RandomRangeInt(-10, 10);
			Transform cachedTrans = arcadeSprite.CachedTrans;
			float num2 = cachedTrans.localEulerAngles.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_30 (ArcadeSprite)+D8]");
			float num3 = num2 - 0f;
			float num4 = (float)obj4 + num;
			float num5 = num3 - num4;
			if (((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				float projectileSpeed = projectile.ProjectileSpeed;
				float rotation = num5 * ((float)Math.PI / 180f);
				ref float2 vec = ref *(float2*)(projectile.body + 112);
				float2 float5 = s_scene.physics.velocityFromRotation(rotation, num4, ref vec);
			}
			projectile.angle = num5;
		}
		return projectile;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_planePool.Cleanup();
		_planeBulletsPool.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		FB_PlaneProjectile[] array = planeProjectiles;
		_isVisible = visible;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			FB_PlaneProjectile fB_PlaneProjectile = array[obj2];
			((ArcadeSprite)array[obj2]).CheckRenderer();
			SpriteRenderer spriteRenderer = ((ArcadeSprite)fB_PlaneProjectile)._spriteRenderer;
			if ((object)((ArcadeSprite)fB_PlaneProjectile)._spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				((ArcadeSprite)fB_PlaneProjectile)._spriteRenderer.enabled = visible;
			}
			obj2++;
			obj = obj2;
		}
	}

	public FB_PrototypeBWeapon()
	{
		//IL_0044: Expected O, but got I4
		_planeProjectileAmount = 5;
		FB_PlaneProjectile[] array = new FB_PlaneProjectile[2];
		planeProjectiles = array;
		base._particlesOffset = (float2)0;
		_ = 1047904911;
		((Weapon)this)._002Ector();
	}
}
