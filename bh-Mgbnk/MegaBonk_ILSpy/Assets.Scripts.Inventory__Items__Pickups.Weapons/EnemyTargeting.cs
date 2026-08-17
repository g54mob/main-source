using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public static class EnemyTargeting
{
	private static int currentBufferCount;

	private static Collider[] enemyBuffer;

	private static RaycastHit[] losBuf;

	private static EnemyScanContainer currentBufferContainer;

	private static readonly Dictionary<Type, Collider[]> buffers;

	private static readonly object nullType;

	private static readonly RaycastHit[] raycastBuffer;

	public static void Init()
	{
		//IL_0124: Expected I, but got O
		Action b = Reset;
		Delegate obj = Delegate.Combine(GameManager.A_RunStarted, b);
		if ((object)obj == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_RunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public static void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = Reset;
		Delegate obj = Delegate.Remove(GameManager.A_RunStarted, value);
		if ((object)obj == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_RunStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private static void Reset()
	{
		buffers.Clear();
	}

	public unsafe static int GetEnemiesInRadiusSafe(object owner, Vector3 pos, float range, out Collider[] buffer)
	{
		//IL_0016: Expected O, but got Ref
		//IL_02a6: Expected O, but got I4
		//IL_004a: Expected O, but got Ref
		//IL_00e5: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_0335: Expected I4, but got O
		//IL_0171: Expected I, but got O
		//IL_0181: Expected O, but got I
		//IL_01a3: Expected O, but got I
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		object obj = default(object);
		int enemiesInRadius = GetEnemiesInRadius((Vector3)(&obj), range, out var enemies);
		bool flag = owner != null;
		object obj2 = owner;
		ref object reference;
		Vector3 vector;
		if (!flag)
		{
			vector = (Vector3)(&obj);
			obj2 = nullType;
			bool flag2 = nullType == null;
			reference = ref *(object*)(&enemies);
			if (flag2)
			{
				goto IL_024c;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
		bool flag3 = buffers == null;
		Vector3 vector2 = (Vector3)0;
		reference = ref *(object*)(&enemies);
		vector = (Vector3)buffers;
		if (!flag3)
		{
			object obj3 = default(object);
			bool flag4 = ((Dictionary<object, object>)(object)buffers).TryGetValue(obj3, out System.Runtime.CompilerServices.Unsafe.As<Collider[], object>(ref buffer));
			object obj4 = obj3;
			reference = ref System.Runtime.CompilerServices.Unsafe.As<Collider[], object>(ref buffer);
			if (!flag4)
			{
				object obj5 = EnemyManager.maxNumEnemiesPooled + 1;
				Collider[] array = new Collider[obj5];
				ref Collider[] reference2 = ref *(Collider[]*)array;
				bool flag5 = buffers == null;
				vector2 = (Vector3)array;
				reference = ref System.Runtime.CompilerServices.Unsafe.As<Collider[], object>(ref buffer);
				vector = (Vector3)buffers;
				if (flag5)
				{
					goto IL_024c;
				}
				((Dictionary<object, object>)(object)buffers).set_Item(obj3, (object)buffer);
				obj4 = obj3;
				reference = ref *(object*)buffer;
			}
			bool flag6 = enemiesInRadius <= 0;
			vector2 = (Vector3)obj4;
			object obj6 = 0;
			if (flag6)
			{
				goto IL_0247;
			}
			while (true)
			{
				bool flag7 = enemies == null;
				vector = (Vector3)enemies;
				if (flag7)
				{
					break;
				}
				if ((nint)obj6 < enemies.Length)
				{
					Collider[] array2 = buffer;
					bool flag8 = buffer == null;
					vector = (Vector3)enemies;
					if (flag8)
					{
						break;
					}
					if ((object)enemies[obj6] != null)
					{
						nint num = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rdx_v11 (Il2CppClass<UnityEngine.Collider[]>)+40]");
						vector2 = (Vector3)0;
						Collider collider = enemies[obj6];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rdx_v11 (Il2CppClass<UnityEngine.Collider[]>)+40]");
						bool flag9 = ((Dictionary<Type, Collider[]>)(object)collider).TryGetValue((Type)0, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref reference));
						bool flag10 = !flag9;
						vector = (Vector3)enemies[obj6];
						if (flag10)
						{
							bool flag11 = ((Dictionary<Type, Collider[]>)vector).TryGetValue((Type)vector2, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref reference));
							throw flag11;
						}
					}
					if ((nint)obj6 < array2.Length)
					{
						array2[obj6] = enemies[obj6];
						obj6++;
						bool flag12 = (nint)obj6 < enemiesInRadius;
						vector2 = (Vector3)enemies[obj6];
						if (flag12)
						{
							continue;
						}
						goto IL_0247;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				return (int)ex;
			}
		}
		goto IL_024c;
		IL_024c:
		throw new NullReferenceException();
		IL_0247:
		return enemiesInRadius;
	}

	public unsafe static Enemy GetEnemy(Vector3 position, float range, int projectileIndex, bool useVision, GameObject exceptObject)
	{
		//IL_00af: Invalid comparison between I4 and F4
		//IL_00fa: Expected F4, but got I4
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected Ref, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_025e: Invalid comparison between F4 and I4
		//IL_0298: Expected O, but got I4
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		_ = 0;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ref Collider[] enemies;
		object obj = default(object);
		Vector3 position2;
		float range2 = default(float);
		GameObject exceptObject2 = default(GameObject);
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					float num = cfGameSettings.random_enemy_targeting;
					if (!(0f > cfGameSettings.random_enemy_targeting))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					enemies = ref *(Collider[]*)(obj - 64);
					_ = position.z;
					position2 = (Vector3)(obj - 48);
					if (projectileIndex <= 0)
					{
						_ = position.x;
						goto IL_03a9;
					}
					_ = position.x;
					if (!(num < 1f))
					{
						int enemiesInRadius = GetEnemiesInRadius(position2, range2, out enemies);
					}
					else
					{
						if (!(num > 0f))
						{
							goto IL_03a9;
						}
						int enemiesInRadius2 = GetEnemiesInRadius(position2, range2, out enemies);
						object obj2 = projectileIndex + 1;
						float num2 = (float)obj2 * num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
						float num3 = (float)projectileIndex * num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
						if (!(num2 > num3))
						{
							goto IL_011d;
						}
					}
					Vector3 pos = (Vector3)(obj - 48);
					_ = position.z;
					_ = position.x;
					return GetRandomEnemy(enemyBuffer, currentBufferCount, pos, useVision, exceptObject2);
				}
			}
		}
		goto IL_033e;
		IL_011d:
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config2 = saveManager2.config;
			if (saveManager2.config != null)
			{
				CFGameSettings cfGameSettings2 = config2.cfGameSettings;
				if (config2.cfGameSettings != null)
				{
					if (cfGameSettings2.enemy_targeting_mode != 0)
					{
						Vector3 pos2 = (Vector3)(obj - 48);
						_ = position.z;
						_ = position.x;
						return GetClosestEnemy(enemyBuffer, currentBufferCount, pos2, useVision, exceptObject2);
					}
					Vector3 pos3 = (Vector3)(obj - 48);
					_ = position.z;
					_ = position.x;
					return GetSmartEnemy(enemyBuffer, currentBufferCount, pos3, useVision, exceptObject2);
				}
			}
		}
		goto IL_033e;
		IL_03a9:
		int enemiesInRadius3 = GetEnemiesInRadius(position2, range2, out enemies);
		goto IL_011d;
		IL_033e:
		return (Enemy)(object)new NullReferenceException();
	}

	public unsafe static Enemy GetRandomEnemyInRadius(Vector3 position, float range, bool useVision, GameObject exceptObject)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0036: Expected O, but got Ref
		float num = default(float);
		int enemiesInRadius = GetEnemiesInRadius((Vector3)(&num), range, out var _);
		GameObject exceptObject2 = default(GameObject);
		return GetRandomEnemy(enemyBuffer, currentBufferCount, (Vector3)(&num), useVision, exceptObject2);
	}

	private unsafe static int GetEnemiesInRadius(Vector3 position, float range, out Collider[] enemies)
	{
		//IL_00d5: Expected I4, but got O
		//IL_001d: Expected O, but got Ref
		//IL_005d: Expected O, but got Ref
		//IL_008a: Expected O, but got F4
		if (currentBufferContainer != null)
		{
			float num = default(float);
			if (currentBufferContainer.IsEqual((Vector3)(&num), MyTime.time, range))
			{
				goto IL_015a;
			}
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				int layerMask = default(int);
				QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
				int num2 = Physics.OverlapSphereNonAlloc((Vector3)(&num), range, enemyBuffer, layerMask, queryTriggerInteraction);
				currentBufferCount = num2;
				EnemyScanContainer enemyScanContainer = currentBufferContainer;
				if (currentBufferContainer != null)
				{
					enemyScanContainer.position = (Vector3)position.x;
					enemyScanContainer.time = MyTime.time;
					_ = position.z;
					enemyScanContainer.range = range;
					goto IL_015a;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_015a:
		ref Collider[] reference = ref *(Collider[]*)enemyBuffer;
		if (currentBufferCount == 0)
		{
			return 0;
		}
		return currentBufferCount;
	}

	private unsafe static Enemy GetTargetedEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		//IL_00f6: Expected O, but got Ref
		//IL_00cf: Expected O, but got Ref
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					object obj = default(object);
					GameObject exceptObject2 = default(GameObject);
					if (cfGameSettings.enemy_targeting_mode != 0)
					{
						return GetClosestEnemy(colliders, count, (Vector3)(&obj), useVision, exceptObject2);
					}
					return GetSmartEnemy(colliders, count, (Vector3)(&obj), useVision, exceptObject2);
				}
			}
		}
		return (Enemy)(object)new NullReferenceException();
	}

	private unsafe static Enemy GetSmartEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0728: Expected I, but got O
		//IL_012d: Expected F8, but got I4
		//IL_073b: Expected I, but got O
		//IL_0754: Expected F4, but got O
		//IL_0764: Expected F4, but got I
		//IL_076d: Expected F4, but got O
		//IL_0776: Expected F4, but got O
		//IL_01e1: Expected O, but got I4
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Expected O, but got Unknown
		//IL_0287: Expected O, but got I
		//IL_033e: Expected O, but got Ref
		//IL_0412: Invalid comparison between I4 and F4
		//IL_07e1: Expected O, but got Ref
		//IL_084f: Invalid comparison between I4 and F4
		//IL_0439: Expected F4, but got I4
		//IL_0442: Expected F4, but got I4
		//IL_08a1: Expected F4, but got I4
		//IL_046f: Expected F4, but got I4
		//IL_0498: Expected F4, but got I4
		//IL_05c8: Expected O, but got Ref
		//IL_05c8: Expected O, but got Ref
		//IL_0609: Expected O, but got I4
		//IL_0612: Expected O, but got I4
		//IL_0648: Expected O, but got I4
		//IL_0651: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = count == 0;
		Enemy result = null;
		Enemy enemy;
		if (!flag)
		{
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
			{
				Transform transform = instance.playerRenderer.transform;
				if ((object)transform != null)
				{
					Vector3 forward = transform.forward;
					float x = forward.x;
					nint num = (nint)typeof(Math);
					float num2 = forward.y * forward.y;
					float num3 = forward.x * forward.x;
					float num4 = forward.z * forward.z;
					float num5 = num2 + num3;
					float num6 = num5 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm3\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rcx_v9 (Il2CppClass<System.Math>)+E4]");
					double num7;
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm3\"");
						num7 = 0.0;
					}
					else
					{
						num7 = Math.Sqrt(num6);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
					float num8;
					float num9;
					float num10;
					float num13 = default(float);
					if (num7 > 9.999999747378752E-06)
					{
						x /= (float)num7;
						num8 = forward.y / (float)num7;
						num9 = forward.z / (float)num7;
						num10 = x;
					}
					else
					{
						nint num11 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ rax_v50 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num12 = 0;
						num4 = (float)Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rcx_v35 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						num9 = 0f;
						num13 = (float)Vector3.zeroVector;
						num10 = (float)Vector3.zeroVector;
						float num14 = default(float);
						num8 = num14;
					}
					bool flag2 = count <= 0;
					enemy = null;
					if (flag2)
					{
						goto IL_06b6;
					}
					if (colliders != null)
					{
						Enemy enemy2 = null;
						object obj3 = 0;
						float num15 = -1f / 0f;
						float num16 = num6;
						Enemy enemy3 = null;
						object obj6 = default(object);
						float num37 = default(float);
						float num39 = default(float);
						float num41 = default(float);
						GameObject gameObject3 = default(GameObject);
						object obj8 = default(object);
						object obj10 = default(object);
						float num46 = default(float);
						int layerMask = default(int);
						QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
						GameObject gameObject4 = default(GameObject);
						while (true)
						{
							if ((bool)colliders[obj3])
							{
								if ((object)colliders[obj3] == null)
								{
									break;
								}
								GameObject gameObject = colliders[obj3].gameObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
								if (gameObject != (UnityEngine.Object)0)
								{
									if ((object)EnemyManager.Instance == null)
									{
										break;
									}
									if (EnemyManager.Instance.GetEnemy(colliders[obj3], out enemy2))
									{
										if ((object)enemy2 == null)
										{
											break;
										}
										if (!enemy2.IsDeadOrDyingNextFrame())
										{
											if ((object)enemy2 == null)
											{
												break;
											}
											object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
											Vector3 centerPosition = enemy2.GetCenterPosition();
											float num17 = centerPosition.x - pos.x;
											float num18 = centerPosition.y - pos.y;
											float num19 = centerPosition.z - pos.z;
											float num20 = num18 * num18;
											float num21 = num17 * num17;
											num4 = num19 * num19;
											float num22 = num20 + num21;
											num6 = num22 + num4;
											bool flag3 = 0.001f > num6;
											num7 = 0.0010000000474974513;
											if (!flag3)
											{
												float num23;
												if (!(0f > num6))
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm2\"");
													num23 = 0f;
													float num24 = 0f;
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300EA0");
													num23 = num6;
													float num24 = num6;
												}
												object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
												float num25 = num8;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v32+4]");
												float num26 = num25 * 0f;
												float num27 = num10 * (float)obj6;
												float num28 = num9;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v32+8]");
												float num29 = num28 * 0f;
												float num30 = num26 + num27;
												float num31 = num30 + num29;
												if (0f > num31)
												{
													num31 = 0f;
												}
												float num32 = num23 + 1f;
												num6 = 1f / num32;
												bool flag4 = !(0.2f > num31);
												float num33 = 0f;
												if (!flag4)
												{
													bool flag5 = !(6f > num23);
													num16 = 6f;
													num33 = 0f;
													if (!flag5)
													{
														num16 = 6f;
														num33 = 1f;
													}
												}
												num4 = num33 + num33;
												float num34 = num31 * 0.2f;
												float num35 = num34 + num6;
												if ((object)enemy2 == null)
												{
													break;
												}
												x = num35 + num4;
												if (enemy2.IsBoss())
												{
													x += 0.5f;
												}
												bool flag6 = !(num15 < x);
												num7 = 0.20000000298023224;
												if (!flag6)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
													bool flag7 = (nint)0 == 0;
													float num36 = num37;
													float num38 = num39;
													float num40 = num41;
													GameObject gameObject2 = gameObject3;
													object obj7 = obj8;
													object obj9 = obj10;
													float num42 = num19;
													float num43 = num18;
													float num44 = num16;
													if (!flag7)
													{
														num43 = num18 / num23;
														num42 = num19 / num23;
														GameManager instance2 = GameManager.Instance;
														if ((object)GameManager.Instance == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
														int num45 = Physics.RaycastNonAlloc((Vector3)(&num13), (Vector3)(&num46), raycastBuffer, num23, layerMask, queryTriggerInteraction);
														bool flag8 = num45 > 0;
														num36 = pos.z;
														num38 = num42;
														num40 = num43;
														gameObject2 = gameObject4;
														obj7 = 1;
														obj9 = 0;
														num44 = num23;
														num37 = pos.z;
														num39 = num42;
														num41 = num43;
														gameObject3 = gameObject4;
														obj8 = 1;
														obj10 = 0;
														num16 = num23;
														if (flag8)
														{
															goto IL_0783;
														}
													}
													num37 = num36;
													num39 = num38;
													num41 = num40;
													gameObject3 = gameObject2;
													obj8 = obj7;
													obj10 = obj9;
													num15 = x;
													num16 = num44;
													enemy3 = enemy2;
												}
											}
										}
									}
								}
							}
							goto IL_0783;
							IL_0783:
							obj3++;
							bool flag9 = (nint)obj3 < count;
							enemy = enemy3;
							if (flag9)
							{
								continue;
							}
							goto IL_06b6;
						}
					}
				}
			}
			return (Enemy)(object)new NullReferenceException();
		}
		goto IL_094b;
		IL_06b6:
		result = enemy;
		goto IL_094b;
		IL_094b:
		return result;
	}

	private unsafe static Enemy GetClosestEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		//IL_0031: Expected F4, but got I4
		//IL_003f: Expected O, but got I4
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_02a8: Invalid comparison between I4 and F4
		//IL_02cf: Expected F4, but got I4
		//IL_02d8: Expected F4, but got I4
		//IL_036a: Expected I4, but got O
		//IL_036a: Expected O, but got Ref
		//IL_036a: Expected O, but got Ref
		//IL_0377: Expected O, but got I4
		//IL_0394: Expected O, but got I
		//IL_03a5: Expected O, but got I4
		//IL_03b7: Expected O, but got I4
		//IL_03d4: Expected O, but got I
		//IL_03e5: Expected O, but got I4
		bool flag = count <= 0;
		Enemy result = null;
		if (!flag)
		{
			if (colliders != null)
			{
				Enemy enemy = null;
				float num = 0f;
				Enemy enemy2 = null;
				object obj = 0;
				float num2 = 3.4028235E+38f;
				UnityEngine.Object obj2 = default(UnityEngine.Object);
				object obj4 = default(object);
				float num12 = default(float);
				object obj6 = default(object);
				float num14 = default(float);
				object obj8 = default(object);
				object obj10 = default(object);
				float num16 = default(float);
				object obj11 = default(object);
				float num18 = default(float);
				object obj12 = default(object);
				GameObject gameObject2 = default(GameObject);
				QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
				while (true)
				{
					float num3;
					float num10;
					object obj3;
					float num11;
					object obj5;
					float num13;
					object obj7;
					object obj9;
					float num15;
					float num17;
					float num8;
					if ((bool)colliders[obj])
					{
						if ((object)colliders[obj] == null)
						{
							break;
						}
						GameObject gameObject = colliders[obj].gameObject;
						if (gameObject != obj2)
						{
							if ((object)EnemyManager.Instance == null)
							{
								break;
							}
							if (EnemyManager.Instance.GetEnemy(colliders[obj], out enemy2))
							{
								if ((object)enemy2 == null)
								{
									break;
								}
								if (!enemy2.IsDeadOrDyingNextFrame())
								{
									if ((object)enemy2 == null)
									{
										break;
									}
									Vector3 centerPosition = enemy2.GetCenterPosition();
									num3 = centerPosition.x - pos.x;
									float num4 = centerPosition.y - pos.y;
									float num5 = centerPosition.z - pos.z;
									float num6 = num4 * num4;
									float num7 = num3 * num3;
									num8 = num5 * num5;
									float num9 = num6 + num7;
									num10 = num9 + num8;
									bool flag2 = !(num10 < num2);
									num = num3;
									if (!flag2)
									{
										bool flag3 = !useVision;
										obj3 = obj4;
										num11 = num12;
										obj5 = obj6;
										num13 = num14;
										obj7 = obj8;
										obj9 = obj10;
										num15 = num16;
										num17 = num8;
										if (flag3)
										{
											goto IL_0411;
										}
										if (!(0f > num10))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm6\"");
											num16 = 0f;
											num8 = 0f;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300EA0");
											num16 = num10;
											num8 = num10;
										}
										bool flag4 = 0.001f > num16;
										num = num3;
										if (!flag4)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
											GameManager instance = GameManager.Instance;
											if ((object)GameManager.Instance == null)
											{
												break;
											}
											obj9 = obj11;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
											num17 = pos.x;
											bool flag5 = Physics.Raycast((Vector3)(&num18), (Vector3)(&obj12), num16, (int)gameObject2, queryTriggerInteraction);
											obj3 = 1;
											num11 = pos.z;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v24+8]");
											obj5 = 0;
											num13 = num16;
											obj7 = 0;
											num15 = num16;
											obj4 = 1;
											num12 = pos.z;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v24+8]");
											obj6 = 0;
											num14 = num16;
											obj8 = 0;
											obj10 = obj11;
											num = num3;
											num8 = pos.x;
											if (!flag5)
											{
												goto IL_0411;
											}
										}
									}
								}
							}
						}
					}
					goto IL_04a6;
					IL_0411:
					enemy = enemy2;
					obj4 = obj3;
					num12 = num11;
					obj6 = obj5;
					num14 = num13;
					obj8 = obj7;
					obj10 = obj9;
					num16 = num15;
					num = num3;
					num8 = num17;
					num2 = num10;
					goto IL_04a6;
					IL_04a6:
					obj++;
					bool flag6 = (nint)obj < count;
					result = enemy;
					if (flag6)
					{
						continue;
					}
					goto IL_046e;
				}
			}
			return (Enemy)(object)new NullReferenceException();
		}
		goto IL_046e;
		IL_046e:
		return result;
	}

	private unsafe static Enemy GetRandomEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		//IL_0045: Expected O, but got I4
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected I4, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0200: Expected O, but got Ref
		//IL_0200: Expected O, but got Ref
		if (count != 0)
		{
			int num = UnityEngine.Random.Range(0, count);
			if (count > 0)
			{
				Enemy enemy = null;
				object obj = 0;
				UnityEngine.Object obj3 = default(UnityEngine.Object);
				float num7 = default(float);
				object obj4 = default(object);
				int layerMask = default(int);
				QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
				do
				{
					object obj2 = obj + num;
					int num2 = obj2 % count;
					if (num2 < colliders.Length)
					{
						if ((bool)colliders[num2])
						{
							GameObject gameObject = colliders[num2].gameObject;
							if (gameObject != obj3 && EnemyManager.Instance.GetEnemy(colliders[num2], out enemy) && !enemy.IsDeadOrDyingNextFrame())
							{
								if (!useVision)
								{
									goto IL_0269;
								}
								Vector3 centerPosition = enemy.GetCenterPosition();
								float num3 = centerPosition.x - pos.x;
								float num4 = centerPosition.y - pos.y;
								float num5 = centerPosition.z - pos.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
								bool flag = 0.001f > num5;
								float num6 = num3;
								if (!flag)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
									GameManager instance = GameManager.Instance;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									bool flag2 = Physics.Raycast((Vector3)(&num7), (Vector3)(&obj4), num5, layerMask, queryTriggerInteraction);
									bool flag3 = !flag2;
									num6 = num3;
									num5 = pos.x;
									if (flag3)
									{
										goto IL_0269;
									}
								}
							}
						}
						obj++;
						continue;
					}
					return (Enemy)(object)new IndexOutOfRangeException();
					IL_0269:
					return enemy;
				}
				while ((nint)obj < count);
			}
		}
		return null;
	}

	private static bool ShouldPickRandom(int idx, float ratio)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_005c: Expected F4, but got I4
		//IL_008d: Invalid comparison between F4 and I4
		//IL_011a: Invalid comparison between F4 and I4
		float num;
		if (!(0f > ratio))
		{
			bool flag = !(ratio > 1f);
			num = ratio;
			if (!flag)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		if (idx > 0)
		{
			if (!(num < 1f))
			{
				return true;
			}
			if (num > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
				float num2 = 0f * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
				float num3 = 0f * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
				bool flag2 = num2 < num3;
				float num4 = num2 - num3;
				bool flag3 = num4 == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
		}
		return false;
	}

	static EnemyTargeting()
	{
		//IL_0123: Expected O, but got I4
		//IL_0093: Expected I, but got O
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0046: Expected O, but got I
		object obj = EnemyManager.maxNumEnemiesPooled + 1;
		Collider[] array = new Collider[obj];
		enemyBuffer = array;
		RaycastHit[] array2 = new RaycastHit[1];
		losBuf = array2;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v10 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v14 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		object obj2 = 0 ^ -0f;
		float num3 = (float)obj2 * 9999f;
		EnemyScanContainer enemyScanContainer = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		Vector3 position = default(Vector3);
		enemyScanContainer.position = position;
		enemyScanContainer.time = -9999f;
		enemyScanContainer.range = -1f;
		currentBufferContainer = enemyScanContainer;
		Dictionary<Type, Collider[]> dictionary = new Dictionary<Type, Collider[]>();
		buffers = dictionary;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
		RuntimeTypeHandle handle = (RuntimeTypeHandle)((nint)0 + (nint)32);
		Type typeFromHandle = Type.GetTypeFromHandle(handle);
		nullType = typeFromHandle;
		RaycastHit[] array3 = new RaycastHit[1];
		raycastBuffer = array3;
	}
}
