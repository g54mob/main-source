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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_RPG1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public TP_RPG1_Weapon _003C_003E4__this;

		public float2 pos;

		public float radius;
	}

	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnExplosionClustersAt_003Eb__0()
		{
			//IL_013e: Expected O, but got I4
			//IL_0164: Expected O, but got F4
			//IL_018c: Expected O, but got F4
			//IL_009e->IL0107: Incompatible stack heights: 1 vs 0
			//IL_017e->IL0107: Incompatible stack heights: 1 vs 0
			//IL_01b0->IL0107: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0107: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass5_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					if (CS_0024_003C_003E8__locals1 != null)
					{
						object obj3 = UnityEngine.Random.value;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							object obj4 = UnityEngine.Random.value;
							_003C_003Ec__DisplayClass5_0 obj5 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_RPG1_Weapon tP_RPG1_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_RPG1_Weapon._targetTransform);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Vector2 pos;

		public Vector2 velocity;

		public float radius;

		public TP_RPG1_Weapon _003C_003E4__this;

		public float startingAngle;

		public float angleUnit;
	}

	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CSpawnExplosionWavesAt_003Eb__0()
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_01bf: Expected I, but got O
			//IL_01d5: Expected O, but got I
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected O, but got Unknown
			//IL_024c: Expected I, but got O
			//IL_0276: Expected O, but got I4
			//IL_028d: Expected I, but got I8
			//IL_0235: Expected I, but got I8
			_003C_003Ec__DisplayClass6_2 obj = new _003C_003Ec__DisplayClass6_2();
			obj.CS_0024_003C_003E8__locals2 = this;
			_003C_003Ec__DisplayClass6_0 obj2 = CS_0024_003C_003E8__locals1;
			object obj3 = obj2.velocity * obj2.radius;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v6 (VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon+<>c__DisplayClass6_0)+1C]");
			object obj4 = 0 * obj2.radius;
			object obj5 = localIndex * obj4;
			object obj6 = localIndex * obj3;
			Vector2 straightPos = (Vector2)((object)obj2.pos + obj6);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v6 (VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon+<>c__DisplayClass6_0)+14]");
			object obj7 = 0 + obj5;
			obj.straightPos = straightPos;
			_003C_003Ec__DisplayClass6_0 obj8 = CS_0024_003C_003E8__locals1;
			TP_RPG1_Weapon tP_RPG1_Weapon = obj8._003C_003E4__this;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj8._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_RPG1_Weapon._targetTransform);
			if (localIndex < 1)
			{
				return;
			}
			int num = 1;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass6_3 obj9 = new _003C_003Ec__DisplayClass6_3();
				obj9.CS_0024_003C_003E8__locals3 = obj;
				obj9.localJ = num;
				_003C_003Ec__DisplayClass6_0 obj10 = CS_0024_003C_003E8__locals1;
				TP_RPG1_Weapon tP_RPG1_Weapon2 = obj10._003C_003E4__this;
				WeaponData currentWeaponData = tP_RPG1_Weapon2._currentWeaponData;
				Action action = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ r10_v5 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass6_3._003CSpawnExplosionWavesAt_003Eb__1);
				((Delegate)action).m_target = obj9;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ r10_v5 (Il2CppMethodInfo)+4C]");
				object obj11 = (nint)0 >> 4;
				object obj12 = obj11 & 1;
				nint num3;
				if (obj12 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ r10_v5 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num3 = unchecked((nint)6447293664L);
						goto IL_026d;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num3 = ((Delegate)action).method_ptr;
				goto IL_026d;
				IL_026d:
				object obj13 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float num4 = (float)num * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				float duration = num4 * 0.001f;
				Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				num++;
			}
			while (num <= localIndex);
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_2
	{
		public Vector2 straightPos;

		public _003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals2;
	}

	private sealed class _003C_003Ec__DisplayClass6_3
	{
		public int localJ;

		public _003C_003Ec__DisplayClass6_2 CS_0024_003C_003E8__locals3;

		internal void _003CSpawnExplosionWavesAt_003Eb__1()
		{
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Expected O, but got Unknown
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Expected O, but got Unknown
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Expected O, but got Unknown
			//IL_05ed: Expected O, but got I4
			//IL_02ab->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_02da->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0309->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0332->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0361->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_039d->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_03cc->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_03ee->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0440->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_046f->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_049e->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_04c7->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_04f6->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0532->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0561->IL05b6: Incompatible stack heights: 1 vs 0
			//IL_0583->IL05b6: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass6_2 obj = CS_0024_003C_003E8__locals3;
			if (CS_0024_003C_003E8__locals3 != null)
			{
				_003C_003Ec__DisplayClass6_1 obj2 = obj.CS_0024_003C_003E8__locals2;
				if (obj.CS_0024_003C_003E8__locals2 != null)
				{
					_003C_003Ec__DisplayClass6_0 obj3 = obj2.CS_0024_003C_003E8__locals1;
					if (obj2.CS_0024_003C_003E8__locals1 != null)
					{
						_003C_003Ec__DisplayClass6_2 obj4 = CS_0024_003C_003E8__locals3;
						if (CS_0024_003C_003E8__locals3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
							_003C_003Ec__DisplayClass6_2 obj5 = CS_0024_003C_003E8__locals3;
							if (CS_0024_003C_003E8__locals3 != null)
							{
								_003C_003Ec__DisplayClass6_1 obj6 = obj5.CS_0024_003C_003E8__locals2;
								if (obj5.CS_0024_003C_003E8__locals2 != null)
								{
									_003C_003Ec__DisplayClass6_0 obj7 = obj6.CS_0024_003C_003E8__locals1;
									if (obj6.CS_0024_003C_003E8__locals1 != null)
									{
										_003C_003Ec__DisplayClass6_2 obj8 = CS_0024_003C_003E8__locals3;
										_003C_003Ec__DisplayClass6_1 obj9 = obj8.CS_0024_003C_003E8__locals2;
										_003C_003Ec__DisplayClass6_0 obj10 = obj9.CS_0024_003C_003E8__locals1;
										object obj11 = localJ * obj10.angleUnit;
										object obj12 = localJ * obj10.angleUnit;
										object obj13 = obj11 + obj7.startingAngle;
										float num = obj10.startingAngle - (float)obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
										_003C_003Ec__DisplayClass6_2 obj14 = CS_0024_003C_003E8__locals3;
										_003C_003Ec__DisplayClass6_1 obj15 = obj14.CS_0024_003C_003E8__locals2;
										_003C_003Ec__DisplayClass6_0 obj16 = obj15.CS_0024_003C_003E8__locals1;
										if ((object)obj16._003C_003E4__this != null)
										{
											GameObject gameObject = obj16._003C_003E4__this.gameObject;
											if ((object)gameObject != null)
											{
												bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												object obj17 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
												if (obj17 == null)
												{
													return;
												}
												_003C_003Ec__DisplayClass6_2 obj18 = CS_0024_003C_003E8__locals3;
												if (CS_0024_003C_003E8__locals3 != null)
												{
													_003C_003Ec__DisplayClass6_1 obj19 = obj18.CS_0024_003C_003E8__locals2;
													if (obj18.CS_0024_003C_003E8__locals2 != null)
													{
														_003C_003Ec__DisplayClass6_0 obj20 = obj19.CS_0024_003C_003E8__locals1;
														if (obj19.CS_0024_003C_003E8__locals1 != null)
														{
															_003C_003Ec__DisplayClass6_2 obj21 = CS_0024_003C_003E8__locals3;
															if (CS_0024_003C_003E8__locals3 != null)
															{
																_003C_003Ec__DisplayClass6_1 obj22 = obj21.CS_0024_003C_003E8__locals2;
																if (obj21.CS_0024_003C_003E8__locals2 != null)
																{
																	_003C_003Ec__DisplayClass6_1 obj23 = obj21.CS_0024_003C_003E8__locals2;
																	_003C_003Ec__DisplayClass6_0 obj24 = obj23.CS_0024_003C_003E8__locals1;
																	if (obj23.CS_0024_003C_003E8__locals1 != null)
																	{
																		TP_RPG1_Weapon tP_RPG1_Weapon = obj24._003C_003E4__this;
																		if ((object)obj24._003C_003E4__this != null && (object)obj20._003C_003E4__this != null)
																		{
																			Vector2 pos = default(Vector2);
																			Projectile projectile = obj20._003C_003E4__this.FireOneProjectile(pos, obj22.localIndex, tP_RPG1_Weapon._targetTransform);
																			_003C_003Ec__DisplayClass6_2 obj25 = CS_0024_003C_003E8__locals3;
																			if (CS_0024_003C_003E8__locals3 != null)
																			{
																				_003C_003Ec__DisplayClass6_1 obj26 = obj25.CS_0024_003C_003E8__locals2;
																				if (obj25.CS_0024_003C_003E8__locals2 != null)
																				{
																					_003C_003Ec__DisplayClass6_0 obj27 = obj26.CS_0024_003C_003E8__locals1;
																					if (obj26.CS_0024_003C_003E8__locals1 != null)
																					{
																						_003C_003Ec__DisplayClass6_2 obj28 = CS_0024_003C_003E8__locals3;
																						if (CS_0024_003C_003E8__locals3 != null)
																						{
																							_003C_003Ec__DisplayClass6_1 obj29 = obj28.CS_0024_003C_003E8__locals2;
																							if (obj28.CS_0024_003C_003E8__locals2 != null)
																							{
																								_003C_003Ec__DisplayClass6_1 obj30 = obj28.CS_0024_003C_003E8__locals2;
																								_003C_003Ec__DisplayClass6_0 obj31 = obj30.CS_0024_003C_003E8__locals1;
																								if (obj30.CS_0024_003C_003E8__locals1 != null)
																								{
																									TP_RPG1_Weapon tP_RPG1_Weapon2 = obj31._003C_003E4__this;
																									if ((object)obj31._003C_003E4__this != null && (object)obj27._003C_003E4__this != null)
																									{
																										Projectile projectile2 = obj27._003C_003E4__this.FireOneProjectile(pos, obj29.localIndex, tP_RPG1_Weapon2._targetTransform);
																										return;
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
			throw new NullReferenceException();
		}
	}

	protected float exploRadius = 0.32f;

	private BulletPool _invisibleProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	protected override void Awake()
	{
		//IL_0070: Expected I, but got O
		//IL_0113: Expected I, but got O
		base.Awake();
		BulletPool bulletPool = new BulletPool(_invisibleProjectilePrefab);
		bulletPool.UpperLimit = 200;
		bulletPool.IsUncapped = true;
		_invisibleProjectilePool = bulletPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_invisibleProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			_explosionType = WeaponType.FIREEXPLOSION;
			return;
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe void SpawnExplosionClustersAt(float2 pos)
	{
		//IL_0039: Invalid comparison between F4 and O
		//IL_004a: Expected F4, but got O
		//IL_01f9: Invalid comparison between F4 and I4
		//IL_00f0: Expected I, but got O
		//IL_0106: Expected O, but got I
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_017d: Expected I, but got O
		//IL_0219: Expected O, but got I4
		//IL_0230: Expected I, but got I8
		//IL_01a5: Invalid comparison between F4 and I4
		//IL_0166: Expected I, but got I8
		_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		float num = base.PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref pos);
		float num2 = (float)pos;
		if (!flag)
		{
			num2 = 1f;
		}
		float num3 = base.PArea();
		float radius = (float)pos * exploRadius;
		obj.radius = radius;
		if (!(num2 > 0f))
		{
			return;
		}
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass5_1 obj2 = new _003C_003Ec__DisplayClass5_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = (flag2 ? 1 : 0);
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass5_1._003CSpawnExplosionClustersAt_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num5;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_0210;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num5 = ((Delegate)action).method_ptr;
			goto IL_0210;
			IL_0210:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num6 = (float)(flag2 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float num7 = num6 + 1f;
			float duration = num7 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while (num2 > (float)(flag2 ? 1 : 0));
	}

	public unsafe void SpawnExplosionWavesAt(Vector2 pos, Vector2 velocity)
	{
		//IL_003d: Expected I, but got O
		//IL_0050: Invalid comparison between F4 and O
		//IL_0061: Expected F4, but got O
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01e4: Expected I, but got O
		//IL_0238: Expected F4, but got I
		//IL_0241: Invalid comparison between F4 and I4
		//IL_0107: Expected I, but got O
		//IL_011d: Expected O, but got I
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0194: Expected I, but got O
		//IL_0261: Expected O, but got I4
		//IL_0278: Expected I, but got I8
		//IL_02f3: Invalid comparison between F4 and I4
		//IL_017d: Expected I, but got I8
		_003C_003Ec__DisplayClass6_0 obj = new _003C_003Ec__DisplayClass6_0();
		obj.pos = pos;
		Vector2 vector = default(Vector2);
		obj.velocity = vector;
		obj._003C_003E4__this = this;
		nint num = (nint)this;
		float num2 = base.PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
		float num3 = (float)vector;
		if (!flag)
		{
			num3 = 1f;
		}
		object obj2 = obj + 24;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Vector2 vector2 = default(Vector2);
		obj.velocity = vector2;
		nint num4 = (nint)this;
		float num5 = base.PArea();
		float radius = (float)vector2 * 0.16f;
		obj.angleUnit = (float)Math.PI / 5f;
		obj.radius = radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon+<>c__DisplayClass6_0)+1C]");
		obj.startingAngle = 0f;
		if (!(num3 > 0f))
		{
			return;
		}
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass6_1 obj3 = new _003C_003Ec__DisplayClass6_1();
			obj3.CS_0024_003C_003E8__locals1 = obj;
			obj3.localIndex = (flag2 ? 1 : 0);
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass6_1._003CSpawnExplosionWavesAt_003Eb__0);
			((Delegate)action).m_target = obj3;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num7;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num7 = unchecked((nint)6447293664L);
					goto IL_0258;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num7 = ((Delegate)action).method_ptr;
			goto IL_0258;
			IL_0258:
			object obj6 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num8 = (float)(flag2 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float num9 = num8 + 1f;
			float duration = num9 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while (num3 > (float)(flag2 ? 1 : 0));
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}
}
