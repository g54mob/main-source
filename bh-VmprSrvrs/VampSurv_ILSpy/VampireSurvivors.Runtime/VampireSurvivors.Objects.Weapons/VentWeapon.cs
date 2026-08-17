using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class VentWeapon : Weapon
{
	private int _ventLimit = 100;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0079: Expected I4, but got O
		base.InitWeapon(characterController, weaponType);
		BulletPool projectilePool = _projectilePool;
		projectilePool.IsUncapped = false;
		WeaponData currentWeaponData = _currentWeaponData;
		if ((object)currentWeaponData._003CpoolLimit_003Ek__BackingField != null)
		{
			if ((object)currentWeaponData._003CpoolLimit_003Ek__BackingField != null)
			{
				int ventLimit = (object?)currentWeaponData._003CpoolLimit_003Ek__BackingField >> 32;
				_ventLimit = ventLimit;
			}
			else
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00f6: Expected I, but got O
		//IL_0116: Expected O, but got I4
		//IL_0124: Expected I, but got O
		//IL_0136: Expected O, but got I4
		//IL_07ac: Expected O, but got F4
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Expected O, but got Unknown
		//IL_08dd: Invalid comparison between O and F4
		//IL_0483: Expected O, but got I4
		//IL_048c: Expected O, but got I4
		//IL_075c: Expected O, but got I4
		//IL_0292: Expected I, but got O
		//IL_04e7: Expected I, but got O
		//IL_04f4: Expected O, but got I
		//IL_0504: Expected O, but got I
		//IL_01df: Expected I, but got O
		//IL_01ef: Expected O, but got I
		//IL_0540: Expected O, but got I
		//IL_0850: Expected O, but got I
		//IL_0858: Expected I, but got O
		//IL_022b: Expected O, but got I
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Expected O, but got Unknown
		//IL_0577: Expected O, but got I
		//IL_058c: Expected O, but got I
		//IL_05ab: Expected I, but got O
		//IL_083b: Expected O, but got I
		//IL_0843: Expected I, but got O
		//IL_02ad: Expected O, but got I
		//IL_05d7: Expected O, but got I
		//IL_0414: Expected I, but got O
		//IL_0422: Expected I, but got O
		//IL_0909: Expected O, but got I
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_031e: Expected F4, but got I
		//IL_0737: Expected I, but got O
		//IL_036e: Expected F4, but got I
		//IL_064d: Expected O, but got I
		//IL_0662: Expected O, but got I
		//IL_03c1: Invalid comparison between F4 and I4
		//IL_03ea: Expected O, but got I4
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected O, but got Unknown
		//IL_06ac: Expected O, but got I
		float num = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r15d,xmm0\"");
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num2 = (float)position - 0.16f;
		float num4 = default(float);
		float num3 = num4 - 0.16f;
		float num5 = num2 + 0.32f;
		float num6 = num3 + 0.32f;
		ArcadePhysics s_instance = ArcadePhysics.s_instance;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float y = num4 - 0.16f;
		float x = (float)position2 - 0.16f;
		float height = default(float);
		bool includeDynamic = default(bool);
		bool includeStatic = default(bool);
		Group specificGroup = default(Group);
		List<BaseBody> list = ArcadePhysics.s_instance.OverlapRect(x, y, 0.32f, height, includeDynamic, includeStatic, specificGroup);
		bool flag = list._size <= 0;
		nint num7 = (nint)typeof(VentProjectile);
		float num8 = 0.32f;
		float num13 = default(float);
		float num12;
		if (!flag)
		{
			object obj = 0;
			num7 = (nint)typeof(VentProjectile);
			num8 = 0.32f;
			object obj2 = 0;
			while ((nint)obj2 < list._size)
			{
				if ((nint)obj >= list._size)
				{
					goto IL_0821;
				}
				BaseBody[] items = list._items;
				BaseBody baseBody = items[obj];
				nint num11;
				if (items[obj] != null)
				{
					baseBody = (BaseBody)(object)baseBody._gameObject;
					if ((object)baseBody._gameObject != null)
					{
						nint num9 = (nint)baseBody;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentProjectile>)+130]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ r9_v13 (Il2CppClass<BaseBody>)+130]");
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentProjectile>)+130]");
						Transform transform;
						if (num10 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ r9_v13 (Il2CppClass<BaseBody>)+C8]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ rax_v80+FFFFFFF8+v1078 @ rax_v77*8]");
							if (0 == num7)
							{
								s_instance = null;
								s_instance = (ArcadePhysics)(object)baseBody._gameObject;
								transform = (Transform)num9;
								num11 = (nint)baseBody;
								goto IL_094c;
							}
						}
						s_instance = null;
						transform = (Transform)num9;
						num11 = (nint)baseBody;
						goto IL_094c;
					}
				}
				s_instance = null;
				num11 = (nint)baseBody;
				goto IL_094c;
				IL_094c:
				if ((object)s_instance != null && ((UnityEngine.Object)s_instance).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v11 (ArcadePhysics)+E8]");
					Bounds bounds = ((PhaserSprite)0).Bounds;
					num12 = (float)bounds.m_Center - num13;
					bool flag2 = num12 > num5;
					num8 = num13;
					if (!flag2)
					{
						float num14 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v67 (UnityEngine.Bounds)+10]");
						num12 = num14 - 0f;
						bool flag3 = num12 > num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v67 (UnityEngine.Bounds)+10]");
						x = 0f;
						num8 = num13;
						y = num13;
						if (!flag3)
						{
							num8 = num13 + (float)bounds.m_Center;
							bool flag4 = num2 > num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v67 (UnityEngine.Bounds)+10]");
							x = 0f;
							y = num13;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v67 (UnityEngine.Bounds)+10]");
								x = 0f + num13;
								bool flag5 = num3 < x;
								float num15 = num3 - x;
								bool flag6 = num15 == 0f;
								bool flag7 = !flag5;
								bool flag8 = !flag6;
								object obj5 = flag8 & flag7;
								bool flag9 = obj5 == null;
								y = num13;
								if (flag9)
								{
									goto IL_0427;
								}
							}
						}
					}
					num11 = unchecked((nint)null);
					num7 = (nint)typeof(VentProjectile);
				}
				obj++;
				obj2 = obj;
			}
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		if (spawnedProjectiles._size < _ventLimit)
		{
			goto IL_0788;
		}
		List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
		object obj6 = 0;
		object obj7 = 0;
		object obj17 = default(object);
		while (true)
		{
			if ((nint)obj7 < spawnedProjectiles2._size)
			{
				List<Projectile> spawnedProjectiles3 = _spawnedProjectiles;
				if ((nint)obj6 >= spawnedProjectiles3._size)
				{
					break;
				}
				Projectile[] items2 = spawnedProjectiles3._items;
				nint num11 = (nint)items2[obj6];
				Transform transform = (Transform)num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentProjectile>)+130]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v9 (UnityEngine.Transform)+130]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentProjectile>)+130]");
				if (num16 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v9 (UnityEngine.Transform)+C8]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v43+FFFFFFF8+v242 @ rax_v42*8]");
					if (0 == num7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentProjectile>)+130]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v43+FFFFFFF8+v1242 @ rcx_v32*8]");
						object obj11 = -num7;
						bool flag10 = obj11 == null;
						bool flag11 = !flag10;
						nint num17 = unchecked((nint)null);
						if (!flag11)
						{
							num17 = num11;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v11 (Il2CppMethodInfo)+F8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v11 (Il2CppMethodInfo)+F8]");
							if (((MultiTargetTween)0).IsAlive())
							{
								goto IL_070c;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v11 (Il2CppMethodInfo)+108]");
						bool flag12 = (nint)0 <= (nint)0;
						s_instance = null;
						if (!flag12)
						{
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v11 (Il2CppMethodInfo)+100]");
								object obj12 = 0;
								ArcadePhysics arcadePhysics = s_instance;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v50+18]");
								if ((nint)arcadePhysics >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v50+10]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v38+20+v120 @ rbx_v11 (ArcadePhysics)*8]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v27+18]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v53+18]");
									if (((MultiTargetTween)0).IsAlive())
									{
										goto IL_070c;
									}
								}
								s_instance = (ArcadePhysics)(s_instance + 1);
								ArcadePhysics arcadePhysics2 = s_instance;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v11 (Il2CppMethodInfo)+108]");
								if ((nint)arcadePhysics2 < 0)
								{
									continue;
								}
								goto IL_06f0;
							}
							break;
						}
						goto IL_06f0;
					}
				}
				throw new NullReferenceException();
			}
			List<Projectile> spawnedProjectiles4 = _spawnedProjectiles;
			object obj15 = 0;
			goto IL_090e;
			IL_090e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			object obj16 = obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ r8_v12+370]");
			num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v889 @ r8_v12+368] (should have been resolved before IL gen)");
			goto IL_0788;
			IL_070c:
			spawnedProjectiles2 = _spawnedProjectiles;
			obj6++;
			num7 = (nint)typeof(VentProjectile);
			obj7 = obj6;
			continue;
			IL_06f0:
			spawnedProjectiles4 = _spawnedProjectiles;
			obj15 = obj6;
			goto IL_090e;
		}
		goto IL_0821;
		IL_0788:
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		int num18 = default(int);
		Projectile projectile = base.FireOneProjectile((Vector2)num13, num18, _targetTransform);
		num12 = num13;
		goto IL_08a4;
		IL_0821:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_08a4:
		float num19 = base.PInterval();
		float num20 = _lastFiringInterval - num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj18 = num20 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num21 = base.PInterval();
			_lastFiringInterval = num12;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		return;
		IL_0427:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v11 (ArcadePhysics)+D8]");
		_ = (nint)0 + (nint)num18;
		goto IL_08a4;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02cb: Expected I4, but got O
		//IL_013e: Invalid comparison between I4 and F4
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
						goto IL_02e8;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							VentProjectile component2 = gameObject2.GetComponent<VentProjectile>();
							if ((object)component2 != null)
							{
								if (component2._uses > 0 && component2._readyForUse && !(0f < component2._repeatIntervalCounter))
								{
									EnemyData currentEnemyData = component._currentEnemyData;
									if (component._currentEnemyData == null)
									{
										goto IL_02bd;
									}
									if (!currentEnemyData._003CpassThroughWalls_003Ek__BackingField)
									{
										if (!component.IsBossEnemy() && component._enemyType != EnemyType.BOSS_XLDROWNER && component._enemyType != EnemyType.BOSS_DROWNER_NORMAL && component._enemyType != EnemyType.BOSS_DROWNER_RASH)
										{
											component2.OnHasHitAnObject((IDamageable)component);
										}
										else
										{
											float num = base.PPower();
											float num2 = base.PAmount();
											WeaponData currentWeaponData = _currentWeaponData;
											float num3 = 0f * 0f;
											HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
											float knockback = base.Knockback;
											component.GetDamaged(num3, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
											component2.Despawn();
											float num4 = num3 + base._003CStatsInflictedDamage_003Ek__BackingField;
											base._003CStatsInflictedDamage_003Ek__BackingField = num4;
										}
									}
								}
								goto IL_02e8;
							}
						}
					}
				}
			}
		}
		goto IL_02bd;
		IL_02bd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02e8:
		return false;
	}

	protected override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01ae: Expected I4, but got O
		//IL_0164: Invalid comparison between I4 and F4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Destructible component = gameObject.GetComponent<Destructible>();
				if ((object)component != null)
				{
					if (component._isDead || !component.DoesAllowVenting())
					{
						goto IL_01cb;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							VentProjectile component2 = gameObject2.GetComponent<VentProjectile>();
							if ((object)component2 != null)
							{
								if (component2._uses > 0 && component2._readyForUse && !(0f < component2._repeatIntervalCounter))
								{
									component2.OnHasHitAnObject((IDamageable)component);
								}
								goto IL_01cb;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01cb:
		return false;
	}

	protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		return false;
	}
}
