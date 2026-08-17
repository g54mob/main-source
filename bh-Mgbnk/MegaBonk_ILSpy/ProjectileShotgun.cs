using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class ProjectileShotgun : ProjectileBase
{
	public ParticleSystem psBullets;

	private ParticleSystem.EmissionModule psBulletsEmission;

	public float testMultiplier = 1f;

	private float forwardOffset;

	private float upOffset;

	private Vector3 attackDir;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f1: Expected O, but got F4
		//IL_0031: Expected F4, but got I
		//IL_0106: Expected I, but got O
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0149: Expected O, but got I
		//IL_0166: Expected O, but got I
		//IL_01ab: Expected O, but got Ref
		//IL_01df: Expected O, but got Ref
		//IL_0213: Expected O, but got Ref
		//IL_041d: Expected I4, but got O
		//IL_02de: Invalid comparison between F4 and I4
		//IL_0329: Expected F4, but got I4
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
		//IL_0483: Expected O, but got Ref
		//IL_0491: Expected O, but got Ref
		//IL_02fb: Invalid comparison between F4 and I4
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0347: Expected O, but got Ref
		//IL_031b: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Vector3 vector = GetAttackDir();
		WeaponBase weaponBase = base.weaponBase;
		attackDir = (Vector3)vector.x;
		_ = vector.z;
		WeaponData weaponData = weaponBase.weaponData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (WeaponData)+C8]");
		forwardOffset = 0f;
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		float num = forwardOffset * (float)attackDir;
		float num2 = forwardOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileShotgun)+88]");
		float num3 = num2 * 0f;
		float num4 = forwardOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileShotgun)+8C]");
		float num5 = num4 * 0f;
		float num6 = num + position.x;
		float num7 = num3 + position.y;
		float num8 = num5 + position.z;
		WeaponBase weaponBase2 = base.weaponBase;
		WeaponData weaponData2 = weaponBase2.weaponData;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v7 (WeaponData)+C4]");
		object obj3 = 0 * Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v7 (WeaponData)+C4]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		object obj4 = num11 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v7 (WeaponData)+C4]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		object obj5 = num12 * 0;
		float num13 = (float)obj3 + num6;
		float num14 = (float)obj4 + num7;
		float num15 = (float)obj5 + num8;
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		transform.position = position2;
		Transform transform3 = base.transform;
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileShotgun)+8C]");
		_ = 0;
		_ = attackDir;
		Quaternion quaternion = Quaternion.LookRotation(forward);
		Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = quaternion.x;
		transform3.rotation = rotation;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if ((object)psBullets != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			psBulletsEmission = emissionModule;
			float stat = PlayerStats.GetStat(EStat.Projectiles);
			if (base.weaponBase != null)
			{
				float value = base.weaponBase.GetValue(EStat.Projectiles);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
				float num16 = (float)transform3 + 2f;
				if (!(num16 < 1f))
				{
					if (num16 > 20f)
					{
						num16 = 20f;
					}
				}
				else
				{
					num16 = 1f;
				}
				ParticleSystem.EmissionModule emissionModule2 = (ParticleSystem.EmissionModule)(this + 112);
				ParticleSystem.Burst burst = ((ParticleSystem.EmissionModule*)emissionModule2)->GetBurst(0);
				_ = burst.m_Time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v24 (UnityEngine.ParticleSystem+Burst)+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v24 (UnityEngine.ParticleSystem+Burst)+20]");
				_ = 0;
				_ = burst.m_InvProbability;
				ParticleSystem.MinMaxCurve minMaxCurve = num16;
				ParticleSystem.MinMaxCurve count = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				ParticleSystem.Burst burst2 = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				_ = minMaxCurve.m_Mode;
				_ = minMaxCurve.m_CurveMax;
				((ParticleSystem.Burst*)burst2)->count = count;
				ParticleSystem.EmissionModule emissionModule3 = (ParticleSystem.EmissionModule)(this + 112);
				ParticleSystem.Burst burst3 = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				((ParticleSystem.EmissionModule*)emissionModule3)->SetBurst(0, burst3);
				if ((object)psBullets != null)
				{
					psBullets.Play();
					CheckZone(base.weaponBase);
					return true;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe Vector3 GetShootingPosition()
	{
		//IL_007f: Expected I, but got O
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_0123: Expected native int or pointer, but got O
		//IL_0130: Expected native int or pointer, but got O
		//IL_013d: Expected native int or pointer, but got O
		if ((object)MyPlayer.Instance != null)
		{
			Transform transform = MyPlayer.Instance.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				WeaponBase weaponBase = base.weaponBase;
				if (base.weaponBase != null)
				{
					WeaponData weaponData = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null)
					{
						nint num = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4 (WeaponData)+C4]");
						object obj = 0 * Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4 (WeaponData)+C4]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
						object obj2 = num3 * 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4 (WeaponData)+C4]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						object obj3 = num4 * 0;
						float x = (float)obj + position.x;
						float y = (float)obj2 + position.y;
						float z = (float)obj3 + position.z;
						Vector3 vector = default(Vector3);
						((Vector3*)(nint)vector)->x = x;
						((Vector3*)(nint)vector)->y = y;
						((Vector3*)(nint)vector)->z = z;
						return vector;
					}
				}
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe Vector3 GetAttackDir()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0630: Expected native int or pointer, but got O
		//IL_063e: Expected native int or pointer, but got O
		//IL_0078: Expected native int or pointer, but got O
		//IL_008a: Expected native int or pointer, but got O
		//IL_02b9: Expected O, but got Ref
		//IL_02c5: Expected native int or pointer, but got O
		//IL_02d2: Expected native int or pointer, but got O
		//IL_0328: Expected I4, but got O
		//IL_0328: Expected O, but got Ref
		//IL_01cf: Expected O, but got Ref
		//IL_0399: Expected I4, but got O
		//IL_0399: Expected O, but got Ref
		//IL_03c4: Expected O, but got Ref
		//IL_05a6: Expected O, but got I
		//IL_0614: Expected O, but got I4
		//IL_0258: Expected F4, but got O
		//IL_0253: Expected native int or pointer, but got O
		//IL_026d: Expected F4, but got I
		//IL_0268: Expected native int or pointer, but got O
		//IL_06c8: Expected F4, but got O
		//IL_06c3: Expected native int or pointer, but got O
		//IL_06dd: Expected F4, but got I
		//IL_06d8: Expected native int or pointer, but got O
		//IL_044d: Expected I, but got O
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		//IL_0490: Expected O, but got I
		//IL_04ad: Expected O, but got I
		//IL_051f: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
		{
			Transform transform = instance.playerRenderer.transform;
			if ((object)transform != null)
			{
				Vector3 forward = transform.forward;
				((Vector3*)(nint)vector)->x = forward.x;
				((Vector3*)(nint)vector)->z = forward.z;
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInput playerInput = instance2.playerInput;
					if ((object)instance2.playerInput != null)
					{
						float num = default(float);
						GameObject gameObject = default(GameObject);
						if (!playerInput.aiming)
						{
							Transform transform2 = base.transform;
							if ((object)transform2 != null)
							{
								Vector3 position = transform2.position;
								float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
								WeaponBase weaponBase = base.weaponBase;
								if (base.weaponBase != null)
								{
									WeaponData weaponData = weaponBase.weaponData;
									if ((object)weaponBase.weaponData != null)
									{
										Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, 0, weaponData.useVision, gameObject);
										if (!(enemy != null))
										{
											goto IL_0660;
										}
										if ((object)enemy != null)
										{
											Vector3 feetPosition = enemy.GetFeetPosition();
											if ((object)MyPlayer.Instance != null)
											{
												Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
												object obj3 = default(object);
												((Vector3*)(nint)vector)->x = (float)obj3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rax_v77+8]");
												((Vector3*)(nint)vector)->z = 0f;
												goto IL_0660;
											}
										}
									}
								}
							}
						}
						else
						{
							Vector3 crosshairRaycastPosition = CrosshairUi.GetCrosshairRaycastPosition();
							Camera main = Camera.main;
							if ((object)main != null)
							{
								Ray ray = main.ScreenPointToRay((Vector3)(&num));
								float x = default(float);
								((Vector3*)(nint)vector)->x = x;
								float z = default(float);
								((Vector3*)(nint)vector)->z = z;
								GameManager instance3 = GameManager.Instance;
								if ((object)GameManager.Instance != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									Vector3 origin = default(Vector3);
									if (!Physics.SphereCast((Ray)(&origin), 1f, out var hitInfo, 999f, (int)gameObject))
									{
										GameManager instance4 = GameManager.Instance;
										if ((object)GameManager.Instance != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
											if (!Physics.SphereCast((Ray)(&origin), 1f, out System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112)), 999f, (int)gameObject))
											{
												goto IL_0660;
											}
											object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
											if ((object)MyPlayer.Instance != null)
											{
												Transform transform3 = MyPlayer.Instance.transform;
												if ((object)transform3 != null)
												{
													Vector3 position2 = transform3.position;
													WeaponBase weaponBase2 = base.weaponBase;
													if (base.weaponBase != null)
													{
														WeaponData weaponData2 = weaponBase2.weaponData;
														if ((object)weaponBase2.weaponData != null)
														{
															nint num2 = (nint)typeof(Vector3);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v884 @ rax_v55 (Il2CppClass<UnityEngine.Vector3>)+B8]");
															nint num3 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v19 (WeaponData)+C4]");
															object obj5 = 0 * Vector3.upVector;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v19 (WeaponData)+C4]");
															nint num4 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rcx_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
															object obj6 = num4 * 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v19 (WeaponData)+C4]");
															nint num5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rcx_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
															object obj7 = num5 * 0;
															float num6 = (float)obj5 + position2.x;
															float num7 = (float)obj6 + position2.y;
															float num8 = (float)obj7 + position2.z;
															object obj8 = default(object);
															float num9 = (float)obj8 - num6;
															float num10 = 999f;
															origin = ray.m_Origin;
															num = num9;
															object obj9 = 0;
															goto IL_06b1;
														}
													}
												}
											}
										}
									}
									else
									{
										Collider collider = hitInfo.collider;
										if ((object)EnemyManager.Instance != null)
										{
											if (!EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96))))
											{
												goto IL_0660;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
												Vector3 feetPosition3 = ((Enemy)0).GetFeetPosition();
												if ((object)MyPlayer.Instance != null)
												{
													Vector3 feetPosition4 = MyPlayer.Instance.GetFeetPosition();
													object obj10 = default(object);
													float num6 = (float)obj10 - feetPosition4.x;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v32+8]");
													float num7 = 0f - feetPosition4.z;
													float num10 = 999f;
													origin = ray.m_Origin;
													num = num6;
													object obj9 = 0;
													goto IL_06b1;
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
		return (Vector3)new NullReferenceException();
		IL_06b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj11 = default(object);
		((Vector3*)(nint)vector)->x = (float)obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v25+8]");
		((Vector3*)(nint)vector)->z = 0f;
		goto IL_0660;
		IL_0660:
		return vector;
	}

	private unsafe void SetBurstCount()
	{
		//IL_0063: Invalid comparison between F4 and I4
		//IL_00ae: Expected F4, but got I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0118: Expected O, but got Ref
		//IL_0080: Invalid comparison between F4 and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00d0: Expected O, but got Ref
		//IL_00a0: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
		ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
		psBulletsEmission = emissionModule;
		float stat = PlayerStats.GetStat(EStat.Projectiles);
		float value = weaponBase.GetValue(EStat.Projectiles);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		object obj = default(object);
		float num = (float)obj + 2f;
		if (!(num < 1f))
		{
			if (num > 20f)
			{
				num = 20f;
			}
		}
		else
		{
			num = 1f;
		}
		ParticleSystem.EmissionModule emissionModule2 = (ParticleSystem.EmissionModule)(this + 112);
		ParticleSystem.Burst burst = ((ParticleSystem.EmissionModule*)emissionModule2)->GetBurst(0);
		ParticleSystem.MinMaxCurve minMaxCurve = num;
		ParticleSystem.Burst burst2 = default(ParticleSystem.Burst);
		object obj2 = default(object);
		burst2.count = (ParticleSystem.MinMaxCurve)(&obj2);
		ParticleSystem.EmissionModule emissionModule3 = (ParticleSystem.EmissionModule)(this + 112);
		object obj3 = default(object);
		((ParticleSystem.EmissionModule*)emissionModule3)->SetBurst(0, (ParticleSystem.Burst)(&obj3));
		psBullets.Play();
	}

	private float GetRange()
	{
		return projectileRadius;
	}

	public unsafe void CheckZone(WeaponBase weaponBase)
	{
		//IL_006d: Expected O, but got Ref
		//IL_006d: Expected O, but got Ref
		//IL_00af: Expected O, but got F4
		//IL_011d: Invalid comparison between F4 and I4
		//IL_012b: Expected O, but got Ref
		//IL_0147: Expected O, but got Ref
		//IL_0147: Expected O, but got F4
		//IL_0291: Expected F4, but got I4
		//IL_05b8: Invalid comparison between I4 and F4
		//IL_0246: Invalid comparison between I4 and F4
		//IL_02cd: Expected F4, but got I4
		//IL_038d: Expected O, but got Ref
		//IL_046d: Expected O, but got Ref
		//IL_046d: Expected O, but got F4
		//IL_0494: Expected I4, but got F4
		//IL_0494: Expected O, but got Ref
		//IL_0494: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		Vector3 vector = default(Vector3);
		HashSet<Collider> hashSet = RaycastUtility.ConeCastNew((Vector3)(&num), (Vector3)(&vector), projectileRadius, 35f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
		float num3 = default(float);
		float num2 = num3;
		float num4 = projectileRadius;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj = default(object);
		object obj2 = default(object);
		float num8 = default(float);
		float num12 = default(float);
		float num13 = default(float);
		Vector3 vector4 = default(Vector3);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				((HashSet<Collider>.Enumerator*)(&enumerator))->Dispose();
				return;
			}
			Enemy enemy;
			Vector3 position3;
			float num6;
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.GetEnemy((Collider)num3, out enemy))
				{
					continue;
				}
				bool flag = (object)MyPlayer.Instance == null;
				EnemyManager instance = (EnemyManager)(object)MyPlayer.Instance;
				if (!flag)
				{
					Transform transform2 = MyPlayer.Instance.transform;
					bool flag2 = (object)transform2 == null;
					instance = (EnemyManager)(object)MyPlayer.Instance;
					if (!flag2)
					{
						Vector3 position2 = transform2.position;
						bool flag3 = num3 == 0f;
						instance = (EnemyManager)(&obj);
						if (!flag3)
						{
							Vector3 vector2 = ((Collider)num3).ClosestPointOnBounds((Vector3)(&num));
							bool flag4 = (object)MyPlayer.Instance == null;
							instance = (EnemyManager)(object)MyPlayer.Instance;
							if (!flag4)
							{
								Transform transform3 = MyPlayer.Instance.transform;
								bool flag5 = (object)transform3 == null;
								instance = (EnemyManager)(object)MyPlayer.Instance;
								if (!flag5)
								{
									position3 = transform3.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
									num2 = projectileRadius * 0.2f;
									num4 = projectileRadius;
									bool flag6 = projectileRadius == num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804F2171h\"");
									if (!flag6)
									{
										float num5 = position3.x - projectileRadius;
										num2 -= projectileRadius;
										num6 = num5 / num2;
										if (!(0f > num6))
										{
											if (num6 > 1f)
											{
												num6 = 1f;
											}
											goto IL_05af;
										}
									}
									num6 = 0f;
									goto IL_05af;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_05af:
			if (!(0f > num6))
			{
				if (num6 > 1f)
				{
					num6 = 1f;
				}
			}
			else
			{
				num6 = 0f;
			}
			if (!(position3.x > num4))
			{
				int rawQuantity = GetRawQuantity();
				float num7 = (float)rawQuantity * 0.25f;
				bool flag7 = (object)enemy == null;
				EnemyManager instance = (EnemyManager)(object)this;
				if (flag7)
				{
					throw new NullReferenceException();
				}
				Vector3 centerPosition = enemy.GetCenterPosition();
				bool flag8 = (object)MyPlayer.Instance == null;
				instance = (EnemyManager)(object)MyPlayer.Instance;
				if (flag8)
				{
					throw new NullReferenceException();
				}
				Transform transform4 = MyPlayer.Instance.transform;
				bool flag9 = (object)transform4 == null;
				instance = (EnemyManager)(object)MyPlayer.Instance;
				if (flag9)
				{
					throw new NullReferenceException();
				}
				Vector3 position4 = transform4.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, this, enemy, (Vector3)(&obj2), num8);
				bool flag10 = damageContainer == null;
				instance = (EnemyManager)(object)weaponBase;
				if (flag10)
				{
					throw new NullReferenceException();
				}
				float num9 = num7 + 1f;
				float num10 = num9 * num6;
				float num11 = num10 * damageContainer.damage;
				if (!(num11 > 1f))
				{
					num11 = 1f;
				}
				damageContainer.damage = num11;
				bool flag11 = (object)enemy == null;
				instance = (EnemyManager)(object)enemy;
				if (flag11)
				{
					throw new NullReferenceException();
				}
				enemy.DamageFromPlayerWeapon(damageContainer);
				Transform transform5 = base.transform;
				bool flag12 = (object)transform5 == null;
				instance = (EnemyManager)(object)this;
				if (flag12)
				{
					break;
				}
				Vector3 position5 = transform5.position;
				Vector3 vector3 = ((Collider)num3).ClosestPoint((Vector3)(&num12));
				weaponAttack.ProjectileHit((Vector3)(&num13), (Vector3)(&vector4), hitEnemy: true, (byte)(int)num8 != 0);
			}
		}
		throw new NullReferenceException();
	}

	private int GetRawQuantity()
	{
		//IL_006c: Expected I4, but got O
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected I4, but got Unknown
		float stat = PlayerStats.GetStat(EStat.Projectiles);
		if (weaponBase != null)
		{
			float value = weaponBase.GetValue(EStat.Projectiles);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = default(object);
			return obj - 1;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private float GetRadius()
	{
		return projectileRadius;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)attackDir;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProjectileShotgun)+8C]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyFixedUpdate()
	{
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}
}
