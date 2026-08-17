using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_PrototypeAWeapon : FB_FullAutoWeapon
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public FB_PrototypeAWeapon _003C_003E4__this;

		public int planeIndex;

		internal void _003CstartFiring_003Eb__0()
		{
			FB_PrototypeAWeapon fB_PrototypeAWeapon = _003C_003E4__this;
			FB_PlaneProjectile[] planeProjectiles = fB_PrototypeAWeapon.planeProjectiles;
			int num = planeIndex;
			float2 position = planeProjectiles[num].position;
			FB_PrototypeAWeapon fB_PrototypeAWeapon2 = _003C_003E4__this;
			Vector2 pos = default(Vector2);
			BulletPool pool = default(BulletPool);
			FB_PlaneProjectile planeProjectile = default(FB_PlaneProjectile);
			Projectile projectile = fB_PrototypeAWeapon.FireOnePlaneProjectile(pos, planeIndex, fB_PrototypeAWeapon2._targetTransform, pool, planeProjectile);
		}
	}

	private BulletPool _planePool;

	private BulletPool _planeBulletsPool;

	private FB_PlaneProjectile[] planeProjectiles;

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

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0171: Expected I, but got O
		//IL_0433: Expected I, but got O
		//IL_0441: Expected I, but got O
		//IL_0451: Expected O, but got I
		//IL_04d1: Expected O, but got I4
		//IL_048d: Expected O, but got I
		//IL_08fc: Expected I, but got O
		//IL_0592: Expected O, but got I4
		//IL_0845: Expected I, but got O
		//IL_0855: Expected O, but got I
		//IL_04c3: Expected O, but got I4
		//IL_056f: Expected O, but got I4
		//IL_04eb: Expected I, but got O
		//IL_0531: Expected O, but got I
		//IL_051c: Expected I, but got O
		//IL_057c: Expected I4, but got O
		//IL_0561: Expected O, but got I4
		//IL_0289: Expected I, but got O
		//IL_08da->IL0726: Incompatible stack heights: 1 vs 0
		//IL_03e1->IL0726: Incompatible stack heights: 1 vs 0
		//IL_05bb->IL0726: Incompatible stack heights: 2 vs 0
		//IL_0521->IL083d: Incompatible stack heights: 2 vs 1
		//IL_060f->IL0726: Incompatible stack heights: 3 vs 0
		//IL_0646->IL0726: Incompatible stack heights: 3 vs 0
		//IL_06a6->IL0726: Incompatible stack heights: 4 vs 0
		//IL_0706->IL0726: Incompatible stack heights: 4 vs 0
		//IL_071a->IL0320: Incompatible stack heights: 4 vs 0
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		if (_planePool == null)
		{
			if ((object)_projectileFactory == null)
			{
				goto IL_0726;
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
			Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.FB_FULLAUTO);
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrototypeAWeapon>)+370]");
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1346 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrototypeAWeapon>)+3A0]");
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
		goto IL_0726;
		IL_0726:
		throw new NullReferenceException();
		IL_02e5:
		FB_PlaneProjectile[] array = planeProjectiles;
		bool flag = planeProjectiles == null;
		int num3 = 0;
		int num4 = 0;
		if (!flag)
		{
			Vector2 pos = default(Vector2);
			object obj4 = default(object);
			while (true)
			{
				FB_PlaneProjectile[] array2;
				Projectile projectile;
				int num5;
				object obj3;
				if (num3 < array.Length)
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
					projectile = base.FireOneProjectileIgnoreDistanceToPlayer(pos, num4, _targetTransform);
					if (planeProjectiles == null)
					{
						break;
					}
					if ((object)projectile == null)
					{
						num5 = 0;
						goto IL_07fe;
					}
					nint num6 = (nint)projectile;
					nint num7 = (nint)typeof(FB_PlaneProjectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
					if (num8 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1121 @ rax_v56+FFFFFFF8+v1079 @ rax_v43*8]");
						if (0 == (nint)typeof(FB_PlaneProjectile))
						{
							obj3 = 1;
							goto IL_081b;
						}
					}
					obj3 = 0;
					goto IL_081b;
				}
				_explosionType = WeaponType.FIREEXPLOSION;
				return;
				IL_081b:
				bool flag3 = obj3 == null;
				Projectile projectile2 = null;
				if (!flag3)
				{
					projectile2 = projectile;
				}
				bool flag4 = (object)projectile2 == null;
				nint num9 = (nint)typeof(FB_PlaneProjectile);
				if (!flag4)
				{
					nint num10 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag5 = obj4 == null;
					num9 = (nint)typeof(FB_PlaneProjectile);
				}
				nint num11 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1092 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1092 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PlaneProjectile>)+130]");
				object obj7;
				if (num12 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1292 @ rax_v51+FFFFFFF8+v1270 @ rax_v46*8]");
					if (0 == num9)
					{
						obj7 = 1;
						goto IL_0881;
					}
				}
				obj7 = 0;
				goto IL_0881;
				IL_07fe:
				bool flag6 = num4 >= array2.Length;
				array2[num4] = (FB_PlaneProjectile)num5;
				FB_PlaneProjectile[] array3 = planeProjectiles;
				if (planeProjectiles == null)
				{
					break;
				}
				bool flag7 = num4 >= array3.Length;
				FB_PlaneProjectile fB_PlaneProjectile = array3[num4];
				if ((object)array3[num4] == null)
				{
					break;
				}
				fB_PlaneProjectile._dist = 1f;
				FB_PlaneProjectile[] array4 = planeProjectiles;
				if (planeProjectiles == null)
				{
					break;
				}
				bool flag8 = num4 >= array4.Length;
				Sprite sprite = SpriteManager.GetSprite("fb_A3_prototype", "items");
				if ((object)array4[num4] == null)
				{
					break;
				}
				ArcadeSprite arcadeSprite2 = array4[num4].setFrame(sprite);
				startFiring(num4);
				array = planeProjectiles;
				num4++;
				if (planeProjectiles == null)
				{
					break;
				}
				num3 = num4;
				continue;
				IL_0881:
				bool flag9 = obj7 == null;
				num5 = 0;
				if (!flag9)
				{
					num5 = (int)projectile;
				}
				goto IL_07fe;
			}
		}
		goto IL_0726;
	}

	public void startFiring(int planeIndex)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.planeIndex = planeIndex;
		FB_PlaneProjectile[] array = planeProjectiles;
		FB_PlaneProjectile fB_PlaneProjectile = array[planeIndex];
		if (fB_PlaneProjectile.timerEvent != null)
		{
			fB_PlaneProjectile.timerEvent.Cancel();
		}
		FB_PlaneProjectile[] array2 = planeProjectiles;
		int planeIndex2 = CS_0024_003C_003E8__locals7.planeIndex;
		FB_PlaneProjectile fB_PlaneProjectile2 = array2[planeIndex2];
		Action onComplete = delegate
		{
			FB_PrototypeAWeapon fB_PrototypeAWeapon = CS_0024_003C_003E8__locals7._003C_003E4__this;
			FB_PlaneProjectile[] array3 = fB_PrototypeAWeapon.planeProjectiles;
			int planeIndex3 = CS_0024_003C_003E8__locals7.planeIndex;
			float2 position = array3[planeIndex3].position;
			FB_PrototypeAWeapon fB_PrototypeAWeapon2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
			Vector2 pos = default(Vector2);
			BulletPool pool = default(BulletPool);
			FB_PlaneProjectile planeProjectile = default(FB_PlaneProjectile);
			Projectile projectile = fB_PrototypeAWeapon.FireOnePlaneProjectile(pos, CS_0024_003C_003E8__locals7.planeIndex, fB_PrototypeAWeapon2._targetTransform, pool, planeProjectile);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timerEvent = Timers.Register(0.05f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		fB_PlaneProjectile2.timerEvent = timerEvent;
	}

	public void stopFiring(int planeIndex)
	{
		FB_PlaneProjectile[] array = planeProjectiles;
		FB_PlaneProjectile fB_PlaneProjectile = array[planeIndex];
		fB_PlaneProjectile.timerEvent.Cancel();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0260: Expected I, but got O
		//IL_0166: Expected O, but got Ref
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01ee: Invalid comparison between O and F4
		//IL_0219: Expected F4, but got O
		//IL_0128->IL0254: Incompatible stack heights: 1 vs 0
		//IL_0154->IL0254: Incompatible stack heights: 1 vs 0
		//IL_023e->IL0254: Incompatible stack heights: 1 vs 0
		nint num = (nint)this;
		float2 firingVector = GetFiringVector();
		object obj = default(object);
		float num2 = (float)obj * 0.01f;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num3 = num2 * 12f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			if ((object)_muzzleFlash != null)
			{
				Transform transform = _muzzleFlash.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 value = default(Vector2);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_muzzleFlash, 2f);
				_muzzleFlash.enabled = true;
				int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
				int sortingOrder = depth + 1;
				_muzzleFlash.sortingOrder = sortingOrder;
				if (_muzzleFlashLastRotated)
				{
				}
				if ((object)_muzzleFlash != null)
				{
					Transform transform2 = _muzzleFlash.transform;
					if ((object)transform2 != null)
					{
						transform2.localEulerAngles = (Vector3)(&value);
						bool muzzleFlashLastRotated = !_muzzleFlashLastRotated;
						_muzzleFlashLastRotated = muzzleFlashLastRotated;
						Vector2 vector = default(Vector2);
						Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
						Projectile projectile2 = FireOneProjectile(vector, 1, _targetTransform);
						float num4 = PInterval();
						float num5 = _lastFiringInterval - (float)vector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj2 = num5 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
						{
							float num6 = PInterval();
							_lastFiringInterval = (float)vector;
							base.ResetFiringTimer();
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
		}
		throw new NullReferenceException();
	}

	public Projectile FireOnePlaneProjectile(Vector2 pos, int index, Transform target, BulletPool pool, FB_PlaneProjectile planeProjectile)
	{
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_025d: Expected I, but got O
		//IL_02df: Expected O, but got F4
		float2 firingVector = GetFiringVector();
		FB_PlaneProjectile[] array = planeProjectiles;
		float num = (float)firingVector * 0.01f;
		object obj = default(object);
		float num2 = (float)obj * 0.01f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = num ^ 0;
		Projectile projectile;
		if (index < array.Length)
		{
			FB_PlaneProjectile fB_PlaneProjectile = array[index];
			float num3 = _sinPhase;
			if (((Projectile)fB_PlaneProjectile)._indexInWeapon != 0)
			{
				num3 *= -1f;
			}
			if (index < array.Length)
			{
				float2 position = array[index].position;
				float num4 = num2 * 12f;
				float num5 = (float)obj + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num6 = num3 * 8f;
				float num7 = num6 * (float)obj2;
				float num8 = num6 * num2;
				float num9 = num7 + num5;
				Vector2 pos2 = default(Vector2);
				BulletPool pool2 = default(BulletPool);
				projectile = FireOneProjectile(pos2, index, target, pool2);
				if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
				{
					goto IL_02f6;
				}
				projectile.SetNullTarget();
				BaseBody body = projectile.body;
				if (projectile.body != null)
				{
					body._transform.ForceFullReupdate();
				}
				FB_PlaneProjectile[] array2 = planeProjectiles;
				if (index < array2.Length)
				{
					Transform cachedTrans = ((ArcadeSprite)array2[index]).CachedTrans;
					Vector3 localEulerAngles = cachedTrans.localEulerAngles;
					FB_PlaneProjectile[] array3 = planeProjectiles;
					if (index < array3.Length)
					{
						FB_PlaneProjectile fB_PlaneProjectile2 = array3[index];
						float num10 = localEulerAngles.z - fB_PlaneProjectile2.angleOffset;
						nint num11 = (nint)projectile;
						float projectileSpeed = projectile.ProjectileSpeed;
						BaseBody body2 = projectile.body;
						float num12 = num3 + num3;
						float num13 = num10 * ((float)Math.PI / 180f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
						float num14 = num13 * num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
						float num15 = num13 * num12;
						body2._velocity = (float2)num14;
						projectile.angle = num10;
						goto IL_02f6;
					}
				}
			}
		}
		return (Projectile)(object)new IndexOutOfRangeException();
		IL_02f6:
		return projectile;
	}

	public override void Cleanup()
	{
		((Weapon)this).Cleanup();
		_muzzleFlash.enabled = false;
		_planePool.Cleanup();
		_planeBulletsPool.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_muzzleFlash.enabled = false;
		FB_PlaneProjectile[] array = planeProjectiles;
		int num = 0;
		for (int num2 = 0; num2 < array.Length; num2 = num)
		{
			FB_PlaneProjectile[] array2 = planeProjectiles;
			ArcadeSprite arcadeSprite = array2[num].setVisible(visible);
			if (!visible)
			{
				stopFiring(num);
			}
			else
			{
				startFiring(num);
			}
			array = planeProjectiles;
			num++;
		}
	}

	public FB_PrototypeAWeapon()
	{
		FB_PlaneProjectile[] array = new FB_PlaneProjectile[2];
		planeProjectiles = array;
		((Weapon)this)._002Ector();
	}
}
