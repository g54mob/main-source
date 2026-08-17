using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_HomingAltWeapon : FB_QuantisedAngleWeapon
{
	private IDamageable _targetDamagable;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0121: Expected O, but got I4
		//IL_02bf: Expected O, but got I
		//IL_02e3: Expected F8, but got O
		//IL_02e3: Expected F8, but got I
		//IL_080f: Expected O, but got I4
		//IL_0839: Expected O, but got F4
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected O, but got Unknown
		//IL_0877: Invalid comparison between F4 and O
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_03b1: Invalid comparison between F8 and O
		//IL_08c7: Invalid comparison between F4 and I4
		//IL_032d: Invalid comparison between F8 and I4
		//IL_0356: Expected O, but got I4
		//IL_04c8: Invalid comparison between F4 and I4
		//IL_03e0: Invalid comparison between F4 and I4
		//IL_042d: Invalid comparison between F4 and I4
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_0598: Expected O, but got Ref
		//IL_05a5: Expected I, but got O
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0767->IL0698: Incompatible stack heights: 1 vs 0
		//IL_012a->IL0697: Incompatible stack heights: 1 vs 0
		//IL_097c->IL0698: Incompatible stack heights: 1 vs 0
		//IL_017f->IL0698: Incompatible stack heights: 2 vs 0
		//IL_01d3->IL0698: Incompatible stack heights: 3 vs 0
		//IL_026e->IL0698: Incompatible stack heights: 3 vs 0
		//IL_022b->IL0698: Incompatible stack heights: 3 vs 0
		//IL_029d->IL0698: Incompatible stack heights: 3 vs 0
		//IL_07d0->IL0698: Incompatible stack heights: 4 vs 0
		//IL_09fa->IL0698: Incompatible stack heights: 3 vs 0
		//IL_0826->IL0981: Incompatible stack heights: 5 vs 3
		//IL_092c->IL0698: Incompatible stack heights: 3 vs 0
		//IL_0586->IL0698: Incompatible stack heights: 3 vs 0
		//IL_0953->IL0698: Incompatible stack heights: 3 vs 0
		//IL_05da->IL0698: Incompatible stack heights: 3 vs 0
		//IL_05fc->IL0698: Incompatible stack heights: 3 vs 0
		//IL_0692->IL0958: Incompatible stack heights: 3 vs 1
		//IL_0697->IL0697: Incompatible stack heights: 3 vs 0
		base.InternalUpdate();
		Transform targetTransform = _targetTransform;
		IDamageable targetDamagable;
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
		{
			if (_targetDamagable == null)
			{
				goto IL_0698;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			bool flag = obj == null;
			targetDamagable = _targetDamagable;
			if (flag)
			{
				goto IL_009b;
			}
		}
		UpdateTargeting();
		targetDamagable = _targetDamagable;
		goto IL_009b;
		IL_0698:
		throw new NullReferenceException();
		IL_009b:
		Transform targetTransform2 = _targetTransform;
		if ((object)_targetTransform == null || ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object targetTransform3 = _targetTransform;
		if ((object)_targetTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rbx_v15 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rbx_v15 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
			List<Projectile> spawnedProjectiles = _spawnedProjectiles;
			bool flag3 = (nint)_spawnedProjectiles < 0;
			if (_spawnedProjectiles != null)
			{
				object obj2 = spawnedProjectiles._size - 1;
				if (flag3)
				{
					return;
				}
				float2 float6 = default(float2);
				object obj3 = default(object);
				float num14 = default(float);
				float x2 = default(float);
				while (true)
				{
					List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
					if (_spawnedProjectiles == null)
					{
						break;
					}
					bool flag4 = (nint)obj2 >= spawnedProjectiles2._size;
					Projectile[] items = spawnedProjectiles2._items;
					if (spawnedProjectiles2._items == null)
					{
						break;
					}
					bool flag5 = (nint)obj2 >= items.Length;
					ArcadeSprite arcadeSprite = items[obj2];
					if ((object)items[obj2] == null)
					{
						break;
					}
					float2 float5;
					float2 float7;
					if (arcadeSprite.body == null)
					{
						Transform cachedTrans = ((ArcadeSprite)items[obj2]).CachedTrans;
						if ((object)cachedTrans == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v86 (UnityEngine.Transform)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v86 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						Transform cachedTrans2 = ((ArcadeSprite)items[obj2]).CachedTrans;
						if ((object)cachedTrans2 == null)
						{
							break;
						}
						bool flag7 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out Vector3 ret3);
						ret3 = (Vector3)0;
						float5 = float6;
						float7 = float6;
					}
					else
					{
						BaseBody body = arcadeSprite.body;
						if (arcadeSprite.body == null)
						{
							break;
						}
						ArcadeTransform arcadeTransform = body._transform;
						if (body._transform == null)
						{
							break;
						}
						float7 = arcadeTransform.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rax_v85 (ArcadeTransform)+4C]");
						float5 = (float2)0;
					}
					double x = (double)ret - (double)float7;
					double y = (double)obj3 - (double)float5;
					double num = Math.Atan2(y, x);
					BaseBody body2 = arcadeSprite.body;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
					float num2 = 0f * 57.29578f;
					if (arcadeSprite.body == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v50 (BaseBody)+74]");
					double num3 = Math.Atan2(0.0, (double)body2._velocity);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
					float num4 = 0f * 57.29578f;
					object obj4 = Time.deltaTime;
					double num5 = num3 * 400.0;
					float num6 = Mathf.DeltaAngle(num4, num2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj5 = num5 ^ 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
					{
						bool flag8 = num5 < (double)num6;
						double num7 = num5 - (double)num6;
						bool flag9 = num7 == 0.0;
						bool flag10 = !flag8;
						bool flag11 = !flag9;
						object obj6 = flag11 & flag10;
						if (obj6 != null)
						{
							goto IL_088e;
						}
					}
					num2 = num6 + num4;
					float num8 = num2 - num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj7 = num8 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
					{
						float num9 = num2 - num4;
						float num10 = ((num9 < 0f) ? (-1f) : 1f);
						float num11 = num10 * (float)num5;
						num2 = num11 + num4;
					}
					goto IL_088e;
					IL_088e:
					float num12 = num2 / 45f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
					double num13 = Math.ModF(0.0, (double*)(&num14));
					float num15;
					if (!(num12 < 0f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A106E0h]\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873E5E46h\"");
						if (num12 == 0f)
						{
							object obj8 = num14 & 1;
							bool flag12 = obj8 == null;
							num15 = num14;
							if (!flag12)
							{
								num15 = num14;
							}
						}
						else
						{
							float num16 = num12 + 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
							num15 = num16;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A115C8h]\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873E5E7Eh\"");
						if (num12 == 0f)
						{
							object obj9 = num14 & 1;
							bool flag13 = obj9 == null;
							num15 = num14;
							if (!flag13)
							{
								num15 = num14;
							}
						}
						else
						{
							float num17 = num12 - 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
							num15 = num17;
						}
					}
					Transform cachedTrans3 = ((ArcadeSprite)items[obj2]).CachedTrans;
					if ((object)cachedTrans3 == null)
					{
						break;
					}
					Vector3 localEulerAngles = cachedTrans3.localEulerAngles;
					Transform cachedTrans4 = ((ArcadeSprite)items[obj2]).CachedTrans;
					if ((object)cachedTrans4 == null)
					{
						break;
					}
					cachedTrans4.localEulerAngles = (Vector3)(&x2);
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null)
					{
						break;
					}
					nint num18 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1803 @ rdx_v29 (Il2CppClass<ArcadeSprite>)+2D8] (should have been resolved before IL gen)");
					object body3 = arcadeSprite.body;
					if (arcadeSprite.body == null || (object)s_scene.physics == null)
					{
						break;
					}
					float num19 = num2 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num20 = num19 * num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					obj2--;
					float num21 = num19 * num15;
					bool flag14 = (nint)s_scene.physics >= 0;
					x2 = localEulerAngles.x;
					targetDamagable = null;
					if (!flag14)
					{
						return;
					}
				}
			}
		}
		goto IL_0698;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0079: Expected I, but got O
		//IL_012b: Expected O, but got F4
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			float num = UnityEngine.Random.Range(-15f, 15f);
			float num2 = (projectile.angle = num + _firingAngleDegrees);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num4 = (nint)projectile;
				float projectileSpeed = projectile.ProjectileSpeed;
				BaseBody body = projectile.body;
				if (projectile.body != null && (object)s_scene.physics != null)
				{
					float num5 = num2 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num6 = num5 * num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num7 = num5 * num;
					body._velocity = (float2)num6;
					goto IL_01b5;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		projectile = null;
		goto IL_01b5;
		IL_01b5:
		return projectile;
	}

	private void UpdateTargeting()
	{
		//IL_0367: Expected O, but got I
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0498->IL0396: Incompatible stack heights: 1 vs 0
		GameManager gameMan = _gameMan;
		if ((object)_gameMan != null)
		{
			Stage stage = gameMan._stage;
			if ((object)gameMan._stage != null)
			{
				List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
				float2 firingVector = GetFiringVector();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 cachedPosition = ((Equipment)this)._003COwner_003Ek__BackingField.cachedPosition;
					if (stage._spawnedEnemies != null)
					{
						object obj = null;
						IDamageable damageable = null;
						float num = -1f;
						object obj2 = null;
						object obj3 = default(object);
						ArcadeSprite arcadeSprite = default(ArcadeSprite);
						object obj6 = default(object);
						object obj7 = default(object);
						object obj10 = default(object);
						IDamageable damageable2 = default(IDamageable);
						while (true)
						{
							if ((nint)obj2 < spawnedEnemies._size)
							{
								if ((nint)obj < spawnedEnemies._size)
								{
									EnemyController[] items = spawnedEnemies._items;
									if (spawnedEnemies._items == null)
									{
										break;
									}
									if ((nint)obj < items.Length)
									{
										EnemyController enemyController = items[obj];
										if ((object)items[obj] != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											if (obj3 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v55+260]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												if ((object)arcadeSprite == null)
												{
													break;
												}
												float2 cachedPosition2 = arcadeSprite.cachedPosition;
												object obj4 = cachedPosition2 - cachedPosition;
												object obj5 = obj6 - obj6;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873E6524h\"");
												if (obj4 == null)
												{
													bool flag = obj5 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873E6524h\"");
													if (flag)
													{
														goto IL_0409;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850046E0");
												obj4 /= obj7;
												obj5 /= obj7;
												object obj8 = (object)firingVector * obj4;
												object obj9 = obj10 * obj5;
												object obj11 = obj8 + obj9;
												float num2 = (float)obj11 / (float)obj7;
												bool flag2 = !(num2 > num);
												object obj12 = obj7;
												if (!flag2)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
													obj12 = obj7;
													damageable = damageable2;
													num = num2;
												}
											}
										}
										goto IL_0409;
									}
								}
								else
								{
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								}
								throw new IndexOutOfRangeException();
							}
							if (damageable == null)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rbp_v9 (VampireSurvivors.Interfaces.IDamageable)+10]");
							if ((nint)0 != 0)
							{
								_targetDamagable = damageable;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rbp_v9 (VampireSurvivors.Interfaces.IDamageable)+68]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rbp_v9 (VampireSurvivors.Interfaces.IDamageable)+68]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v10 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v10 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform targetTransform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								_targetTransform = targetTransform;
							}
							return;
							IL_0409:
							obj++;
							obj2 = obj;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		UpdateTargeting();
	}
}
