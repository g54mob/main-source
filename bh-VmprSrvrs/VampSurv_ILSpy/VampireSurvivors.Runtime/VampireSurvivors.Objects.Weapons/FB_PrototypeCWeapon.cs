using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
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

public class FB_PrototypeCWeapon : FB_SpreadWeapon
{
	private BulletPool _planePool;

	private BulletPool _planeBulletsPool;

	private int _planeProjectileAmount = 6;

	private FB_PlaneProjectile[] planeProjectiles;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0171: Expected I, but got O
		//IL_042b: Expected I, but got O
		//IL_0439: Expected I, but got O
		//IL_0449: Expected O, but got I
		//IL_04c9: Expected O, but got I4
		//IL_0485: Expected O, but got I
		//IL_08ec: Expected I, but got O
		//IL_0839: Expected I, but got O
		//IL_0849: Expected O, but got I
		//IL_04bb: Expected O, but got I4
		//IL_0567: Expected O, but got I4
		//IL_04e3: Expected I, but got O
		//IL_0529: Expected O, but got I
		//IL_0514: Expected I, but got O
		//IL_0559: Expected O, but got I4
		//IL_0289: Expected I, but got O
		//IL_06fe: Expected O, but got I4
		//IL_08ca->IL070f: Incompatible stack heights: 1 vs 0
		//IL_03dd->IL070f: Incompatible stack heights: 1 vs 0
		//IL_05b3->IL070f: Incompatible stack heights: 2 vs 0
		//IL_0519->IL0831: Incompatible stack heights: 2 vs 1
		//IL_0607->IL070f: Incompatible stack heights: 3 vs 0
		//IL_063e->IL070f: Incompatible stack heights: 3 vs 0
		//IL_069e->IL070f: Incompatible stack heights: 4 vs 0
		//IL_06ef->IL070f: Incompatible stack heights: 4 vs 0
		//IL_0703->IL031c: Incompatible stack heights: 4 vs 0
		WeaponType weaponType2 = default(WeaponType);
		((Weapon)this).InitWeapon(characterController, weaponType2);
		_explosionType = WeaponType.FIREEXPLOSION;
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
			Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.FB_PROTOTYPE_C);
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrototypeCWeapon>)+370]");
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1346 @ r8_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrototypeCWeapon>)+3A0]");
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
						goto IL_07f2;
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
							goto IL_080f;
						}
					}
					obj3 = 0;
					goto IL_080f;
				}
				_explosionType = WeaponType.FIREEXPLOSION;
				return;
				IL_080f:
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
						goto IL_0875;
					}
				}
				obj7 = 0;
				goto IL_0875;
				IL_07f2:
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
				fB_PlaneProjectile._dist = 0.9f;
				FB_PlaneProjectile[] array4 = planeProjectiles;
				if (planeProjectiles == null)
				{
					break;
				}
				bool flag8 = num3 >= array4.Length;
				Sprite sprite = SpriteManager.GetSprite("fb_spread2", "items");
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
				IL_0875:
				bool flag9 = obj7 == null;
				projectile3 = null;
				if (!flag9)
				{
					projectile3 = projectile2;
				}
				goto IL_07f2;
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

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0033: Expected F4, but got I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_009c: Invalid comparison between O and F4
		//IL_00c8: Expected F4, but got O
		//IL_0171: Expected O, but got F4
		float? num = default(float?);
		float num2 = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_SpreadShot, 100f, 10, 0f, num, num2, detune, loop, 1f);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		FireSalvo(vector, _targetTransform);
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			characterController.OnWeaponFired(this);
		}
		FB_PlaneProjectile[] array = planeProjectiles;
		int num6 = 0;
		int num7 = 0;
		while (num6 < array.Length)
		{
			if (_planeProjectileAmount > 0)
			{
				int num8;
				do
				{
					FB_PlaneProjectile[] array2 = planeProjectiles;
					float2 position2 = array2[num7].position;
					Projectile projectile = FireOnePlaneProjectile(vector, 0, _targetTransform, (BulletPool)num, (FB_PlaneProjectile)num2);
					num8 = 0 + 1;
				}
				while (num8 < _planeProjectileAmount);
			}
			array = planeProjectiles;
			num7++;
			num6 = num7;
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_014c: Expected O, but got F4
		//IL_0169: Expected O, but got F4
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0050: Expected I, but got O
		//IL_0102: Expected O, but got F4
		float num = PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num2 = num - 3f;
		object obj = num2 >> 31;
		float num3 = num2 - (float)obj;
		object obj2 = num3 >> 1;
		object obj3 = obj2 * 4;
		object obj4 = obj2 + obj3;
		float num4 = (float)obj4 + 45f;
		bool flag = !(85f > num4);
		float num5 = 85f;
		if (!flag)
		{
			num5 = num4;
		}
		object obj5 = default(object);
		float num6 = num5 / (float)obj5;
		float num7 = (float)obj5 - 1f;
		float num8 = (float)index * num6;
		float num9 = num6 * 0.5f;
		float num10 = num8 + _firingAngleDegrees;
		float num11 = num9 * num7;
		float num12 = num10 - num11;
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num13 = (nint)projectile;
				float projectileSpeed = projectile.ProjectileSpeed;
				BaseBody body = projectile.body;
				if (projectile.body != null && (object)s_scene.physics != null)
				{
					float num14 = num12 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num15 = num14 * num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num16 = num14 * num7;
					body._velocity = (float2)num15;
					goto IL_01df;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		goto IL_01df;
		IL_01df:
		return projectile;
	}

	public Projectile FireOnePlaneProjectile(Vector2 pos, int index, Transform target, BulletPool pool, FB_PlaneProjectile planeProjectile)
	{
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_0028: Expected O, but got I
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_017d: Expected I, but got O
		//IL_022f: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm8\"");
		object obj2 = default(object);
		object obj = obj2 - 3;
		object obj3 = obj >> 31;
		object obj4 = obj - obj3;
		object obj5 = obj4 >> 1;
		object obj6 = obj5 * 4;
		object obj7 = obj5 + obj6;
		float num = (float)obj7 + 45f;
		bool flag = !(85f > num);
		float num2 = 85f;
		if (!flag)
		{
			num2 = num;
		}
		float num3 = num2 / (float)_planeProjectileAmount;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		Projectile projectile;
		if ((object)arcadeSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_30 (ArcadeSprite)+70]");
			object obj8 = (nint)0 * (nint)4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_30 (ArcadeSprite)+70]");
			object obj9 = 0 + obj8;
			object obj10 = obj9 << 2;
			Transform cachedTrans = arcadeSprite.CachedTrans;
			if ((object)cachedTrans != null)
			{
				Vector3 localEulerAngles = cachedTrans.localEulerAngles;
				float num4 = (float)_planeProjectileAmount - 1f;
				float num5 = (float)obj10 - 10f;
				float num6 = localEulerAngles.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_30 (ArcadeSprite)+D8]");
				float num7 = num6 - 0f;
				float num8 = num7 - num5;
				float num9 = (float)index * num3;
				float num10 = num3 * 0.5f;
				float num11 = num8 + num9;
				float num12 = num10 * num4;
				float num13 = num11 - num12;
				BulletPool pool2 = default(BulletPool);
				projectile = base.FireOneProjectile(pos, index, target, pool2);
				if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
				{
					goto IL_02fe;
				}
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					nint num14 = (nint)projectile;
					float projectileSpeed = projectile.ProjectileSpeed;
					BaseBody body = projectile.body;
					if (projectile.body != null && (object)s_scene.physics != null)
					{
						float num15 = num13 * ((float)Math.PI / 180f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
						float num16 = num15 * num9;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
						float num17 = num15 * num9;
						body._velocity = (float2)num16;
						goto IL_02fe;
					}
				}
			}
		}
		return (Projectile)(object)new NullReferenceException();
		IL_02fe:
		return projectile;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_planePool.Cleanup();
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

	public FB_PrototypeCWeapon()
	{
		FB_PlaneProjectile[] array = new FB_PlaneProjectile[2];
		planeProjectiles = array;
		((Weapon)this)._002Ector();
	}
}
