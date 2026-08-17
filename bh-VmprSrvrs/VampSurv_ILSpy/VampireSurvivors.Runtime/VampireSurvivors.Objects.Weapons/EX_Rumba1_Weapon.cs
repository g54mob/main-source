using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Weapons;

public class EX_Rumba1_Weapon : Weapon
{
	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private float fxRadius;

	public override float PSpeed()
	{
		return 1f;
	}

	public override float PAmount()
	{
		return 1f;
	}

	protected unsafe override void OnStart()
	{
		//IL_0015: Expected O, but got I
		//IL_0890: Expected I, but got O
		//IL_08c1: Expected O, but got I
		//IL_017a: Expected I, but got O
		//IL_01d3: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_08dd: Expected I, but got O
		//IL_090e: Expected O, but got I
		//IL_02ba: Expected I, but got O
		//IL_0313: Expected O, but got I
		//IL_0313: Expected O, but got I
		//IL_0333: Expected O, but got I
		//IL_092a: Expected I, but got O
		//IL_095b: Expected O, but got I
		//IL_0448: Expected O, but got I
		//IL_0448: Expected O, but got I
		//IL_0468: Expected O, but got I
		//IL_05ea: Expected O, but got I
		//IL_0685: Expected I, but got O
		//IL_0739: Expected O, but got Ref
		//IL_09db: Expected O, but got I
		//IL_09eb: Expected O, but got I
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
		base.ResetFiringTimer();
		bool flag = (object)GM.Core == null;
		ArcadePhysicsCallback arcadePhysicsCallback = (ArcadePhysicsCallback)(object)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AD90]");
			arcadePhysicsCallback = (ArcadePhysicsCallback)0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float num = renderer.width * 0.65f;
					if ((object)GM.Core != null)
					{
						arcadePhysicsCallback = (ArcadePhysicsCallback)(object)ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							IntPtr method = ((Delegate)arcadePhysicsCallback).method;
							if (((Delegate)arcadePhysicsCallback).method != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v17 (System.IntPtr)+14]");
								float num2 = 0f * 0.65f;
								if (!(num2 > num))
								{
									num = num2;
								}
								fxRadius = num;
								if (base.GetFiringAnimation() != FiringAnimation.None)
								{
									PlayNextAttackAnim();
								}
								base.ResetFiringTimer();
								nint num3 = (nint)typeof(ArcadePhysics);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ rax_v24 (Il2CppClass<ArcadePhysics>)+B8]");
								nint num4 = 0;
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								bool flag2 = ArcadePhysics.s_scene == null;
								arcadePhysicsCallback = (ArcadePhysicsCallback)num4;
								if (!flag2)
								{
									arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene2.physics;
									if ((object)s_scene2.physics != null)
									{
										GameManager gameMan = _gameMan;
										if ((object)_gameMan != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rumba1_Weapon>)+350]");
											ArcadePhysicsCallback arcadePhysicsCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
											nint num5 = (nint)this;
											bool flag3 = ((Delegate)arcadePhysicsCallback2).delegate_trampoline == (IntPtr)0;
											arcadePhysicsCallback = arcadePhysicsCallback2;
											if (!flag3)
											{
												ArcadePhysicsCallback arcadePhysicsCallback3 = default(ArcadePhysicsCallback);
												CallbackContext callbackContext = default(CallbackContext);
												Collider collider = ((Factory)(nint)((Delegate)arcadePhysicsCallback2).delegate_trampoline).overlap(_projectilePool, gameMan.Enemies, arcadePhysicsCallback2, arcadePhysicsCallback3, callbackContext);
												bool flag4 = collider == null;
												arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback2).delegate_trampoline;
												if (!flag4)
												{
													Collider collider2 = collider.setName("Projectiles>Enemies");
													nint num6 = (nint)typeof(ArcadePhysics);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rax_v32 (Il2CppClass<ArcadePhysics>)+B8]");
													nint num7 = 0;
													PhaserScene s_scene3 = ArcadePhysics.s_scene;
													bool flag5 = ArcadePhysics.s_scene == null;
													arcadePhysicsCallback = (ArcadePhysicsCallback)num7;
													if (!flag5)
													{
														arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene3.physics;
														if ((object)s_scene3.physics != null)
														{
															GameManager gameMan2 = _gameMan;
															if ((object)_gameMan != null)
															{
																arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan2._physicsManager;
																if (gameMan2._physicsManager != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rumba1_Weapon>)+3A0]");
																	ArcadePhysicsCallback arcadePhysicsCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
																	nint num8 = (nint)this;
																	bool flag6 = ((Delegate)arcadePhysicsCallback4).delegate_trampoline == (IntPtr)0;
																	arcadePhysicsCallback = arcadePhysicsCallback4;
																	if (!flag6)
																	{
																		Collider collider3 = ((Factory)(nint)((Delegate)arcadePhysicsCallback4).delegate_trampoline).overlap(_projectilePool, (ArcadeColliderType)(nint)((Delegate)arcadePhysicsCallback4).method_code, arcadePhysicsCallback4, arcadePhysicsCallback3, callbackContext);
																		bool flag7 = collider3 == null;
																		arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback4).delegate_trampoline;
																		if (!flag7)
																		{
																			Collider collider4 = collider3.setName("Projectiles>Destructibles");
																			nint num9 = (nint)typeof(ArcadePhysics);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v918 @ rax_v40 (Il2CppClass<ArcadePhysics>)+B8]");
																			nint num10 = 0;
																			PhaserScene s_scene4 = ArcadePhysics.s_scene;
																			bool flag8 = ArcadePhysics.s_scene == null;
																			arcadePhysicsCallback = (ArcadePhysicsCallback)num10;
																			if (!flag8)
																			{
																				arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene4.physics;
																				if ((object)s_scene4.physics != null)
																				{
																					GameManager gameMan3 = _gameMan;
																					if ((object)_gameMan != null)
																					{
																						arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan3._physicsManager;
																						if (gameMan3._physicsManager != null)
																						{
																							ArcadePhysicsCallback arcadePhysicsCallback5 = OnBulletOverlapsPickup;
																							bool flag9 = ((Delegate)arcadePhysicsCallback5).delegate_trampoline == (IntPtr)0;
																							arcadePhysicsCallback = arcadePhysicsCallback5;
																							if (!flag9)
																							{
																								Collider collider5 = ((Factory)(nint)((Delegate)arcadePhysicsCallback5).delegate_trampoline).overlap(_projectilePool, (ArcadeColliderType)(nint)((Delegate)arcadePhysicsCallback5).delegate_trampoline, arcadePhysicsCallback5, arcadePhysicsCallback3, callbackContext);
																								bool flag10 = collider5 == null;
																								arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback5).delegate_trampoline;
																								if (!flag10)
																								{
																									Collider collider6 = collider5.setName("Projectiles>Pickups");
																									WeaponData currentWeaponData = _currentWeaponData;
																									bool flag11 = _currentWeaponData == null;
																									arcadePhysicsCallback = (ArcadePhysicsCallback)(object)collider5;
																									if (!flag11)
																									{
																										if (!currentWeaponData._003ChitsWalls_003Ek__BackingField)
																										{
																											goto IL_07bc;
																										}
																										GameManager gameMan4 = _gameMan;
																										bool flag12 = (object)_gameMan == null;
																										arcadePhysicsCallback = (ArcadePhysicsCallback)(object)collider5;
																										if (!flag12)
																										{
																											Stage stage = gameMan4._stage;
																											if ((object)gameMan4._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
																											{
																												goto IL_07bc;
																											}
																											GameManager gameMan5 = _gameMan;
																											bool flag13 = (object)_gameMan == null;
																											arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(UnityEngine.Object);
																											if (!flag13)
																											{
																												arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan5._stage;
																												if ((object)gameMan5._stage != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v4 (ArcadePhysicsCallback)+88]");
																													if ((nint)0 == 0)
																													{
																														goto IL_07bc;
																													}
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v4 (ArcadePhysicsCallback)+208]");
																													object obj = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v4 (ArcadePhysicsCallback)+208]");
																													if ((nint)0 != 0)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																														object obj2 = default(object);
																														if (obj2 != null)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v57+18]");
																															if ((nint)0 != 0)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004430");
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1048 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rumba1_Weapon>)+3B0]");
																																ArcadePhysicsCallback arcadePhysicsCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
																																nint num11 = (nint)this;
																																World world = default(World);
																																ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
																																CallbackContext callbackContext2 = default(CallbackContext);
																																TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(world, overlapOnly: false, _projectilePool, (ArcadeColliderType)(object)arcadePhysicsCallback3, (ArcadePhysicsCallback)(object)callbackContext, processCallback, callbackContext2);
																																bool flag14 = tilemapSetCollider == null;
																																arcadePhysicsCallback = (ArcadePhysicsCallback)(object)tilemapSetCollider;
																																if (!flag14)
																																{
																																	Collider collider7 = tilemapSetCollider.setName("Projectiles>Tilemap");
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r13_v5+60]");
																																	bool flag15 = (nint)0 == 0;
																																	arcadePhysicsCallback = (ArcadePhysicsCallback)(object)tilemapSetCollider;
																																	if (!flag15)
																																	{
																																		ArcadeColliderType projectilePool = _projectilePool;
																																		PhaserTilemap phaserTilemap = null;
																																		List<PhaserTilemap>.Enumerator enumerator = default(List<PhaserTilemap>.Enumerator);
																																		if (enumerator.MoveNext())
																																		{
																																			PhaserTilemap phaserTilemap2 = null;
																																			List<PhaserTilemap>.Enumerator enumerator2 = (List<PhaserTilemap>.Enumerator)(&enumerator);
																																			throw new NullReferenceException();
																																		}
																																		PhaserScene s_scene5 = ArcadePhysics.s_scene;
																																		bool flag16 = ArcadePhysics.s_scene == null;
																																		arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
																																		if (!flag16)
																																		{
																																			bool flag17 = (object)s_scene5.physics == null;
																																			arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
																																			if (!flag17)
																																			{
																																				arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v4 (ArcadePhysicsCallback)+B8]");
																																				object obj3 = 0;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v73+18]");
																																				object obj4 = 0;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v73+18]");
																																				if ((nint)0 != 0)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rbx_v10+50]");
																																					if ((nint)0 != 0)
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
																																						goto IL_07bc;
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
		IL_07bc:
		GenerateParticleSystem();
	}

	protected unsafe override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0083: Expected O, but got Ref
		//IL_00a0: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		Destructible component = gameObject.GetComponent<Destructible>();
		if (!component._003CIsStationary_003Ek__BackingField)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 position2 = component.position;
			float2 position3 = component.position;
			float2 float5 = default(float2);
			Destructible component2 = ((GameObject)(&float5)).GetComponent<Destructible>();
			object obj = Time.deltaTime;
			float2 position4 = default(float2);
			component.position = position4;
			return false;
		}
		return false;
	}

	private bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_0118: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_019c: Expected I, but got O
		//IL_01ac: Expected O, but got I
		//IL_022c: Expected O, but got I4
		//IL_0164: Expected O, but got I
		//IL_01e8: Expected O, but got I
		//IL_021e: Expected O, but got I4
		//IL_0414: Expected I4, but got O
		//IL_026f: Expected I4, but got O
		//IL_042b: Expected O, but got F4
		//IL_029f: Expected I4, but got O
		//IL_02c5: Expected I, but got O
		ArcadeSprite arcadeSprite;
		PickupWeapon pickupWeapon;
		if (right == null)
		{
			arcadeSprite = null;
			pickupWeapon = null;
			goto IL_03b8;
		}
		nint num = (nint)typeof(Pickup);
		nint num2 = (nint)right;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v65+FFFFFFF8+v57 @ rax_v61*8]");
			if (0 == (nint)typeof(Pickup))
			{
				obj3 = 1;
				goto IL_038c;
			}
		}
		obj3 = 0;
		goto IL_038c;
		IL_03d5:
		object obj4;
		if (obj4 != null)
		{
			pickupWeapon = (PickupWeapon)arcadeSprite;
		}
		bool flag = (object)pickupWeapon == null;
		bool flag2 = (byte)(int)typeof(PickupWeapon) != 0;
		nint num4;
		if (!flag)
		{
			bool flag3 = ((UnityEngine.Object)pickupWeapon).m_CachedPtr == (IntPtr)0;
			flag2 = (byte)(int)typeof(PickupWeapon) != 0;
			if (!flag3)
			{
				bool flag4 = pickupWeapon._floatTween == null;
				flag2 = (byte)(int)typeof(PickupWeapon) != 0;
				if (!flag4)
				{
					TweenExtensions.Kill(pickupWeapon._floatTween);
					num4 = unchecked((nint)null);
					flag2 = false;
				}
			}
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = arcadeSprite.position;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj5 = obj6 - obj7;
		float2 position3 = arcadeSprite.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		object obj8 = Time.deltaTime;
		float2 position4 = default(float2);
		arcadeSprite.position = position4;
		if ((object)pickupWeapon != null && ((UnityEngine.Object)pickupWeapon).m_CachedPtr != (IntPtr)0)
		{
			pickupWeapon.ResumeFloat();
		}
		goto IL_0361;
		IL_03b8:
		if ((object)arcadeSprite == null || ((UnityEngine.Object)arcadeSprite).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0361;
		}
		nint num5 = (nint)typeof(TP_CycleGate);
		num4 = (nint)arcadeSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Items.TP_CycleGate>)+130]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r8_v4 (Il2CppClass<ArcadeSprite>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Items.TP_CycleGate>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r8_v4 (Il2CppClass<ArcadeSprite>)+C8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v54+FFFFFFF8+v400 @ rax_v10*8]");
			if (0 == (nint)typeof(TP_CycleGate))
			{
				goto IL_0361;
			}
		}
		nint num7 = (nint)typeof(PickupWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r8_v4 (Il2CppClass<ArcadeSprite>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r8_v4 (Il2CppClass<ArcadeSprite>)+C8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v52+FFFFFFF8+v425 @ rax_v12*8]");
			if (0 == (nint)typeof(PickupWeapon))
			{
				obj4 = 1;
				goto IL_03d5;
			}
		}
		obj4 = 0;
		goto IL_03d5;
		IL_038c:
		bool flag5 = obj3 == null;
		arcadeSprite = null;
		pickupWeapon = null;
		if (!flag5)
		{
			arcadeSprite = (ArcadeSprite)right;
			pickupWeapon = null;
		}
		goto IL_03b8;
		IL_0361:
		return false;
	}

	protected unsafe override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0083: Expected O, but got Ref
		//IL_00a0: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 position2 = component.position;
			float2 position3 = component.position;
			float2 float5 = default(float2);
			EnemyController component2 = ((GameObject)(&float5)).GetComponent<EnemyController>();
			object obj = Time.deltaTime;
			float2 position4 = default(float2);
			component.position = position4;
			return false;
		}
		return false;
	}

	protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0146: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		VampireSurvivors.Objects.Characters.CharacterController component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		if (!component._isDead && !component.IsDisconnectedFromOnlinePlay)
		{
			bool flag;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				object obj = (object)component - (object)((Equipment)this)._003COwner_003Ek__BackingField;
				flag = obj == null;
			}
			else
			{
				flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			}
			if (!flag)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float2 position2 = component.position;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				float2 position3 = component.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
				object obj5 = Time.deltaTime;
				float2 position4 = default(float2);
				component.position = position4;
				return false;
			}
		}
		return false;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0377: Expected O, but got I
		//IL_0393: Expected O, but got I4
		//IL_03ac: Expected O, but got Ref
		//IL_03bb: Expected O, but got I4
		//IL_03c9: Expected native int or pointer, but got O
		//IL_06f1: Expected O, but got I4
		//IL_03e1: Expected O, but got Ref
		//IL_03fb: Expected native int or pointer, but got O
		//IL_070e: Expected O, but got I4
		//IL_0520: Expected O, but got I
		//IL_053c: Expected O, but got I4
		//IL_0555: Expected O, but got Ref
		//IL_056f: Expected native int or pointer, but got O
		//IL_0748: Expected O, but got I
		//IL_05a7: Expected O, but got Ref
		//IL_05c1: Expected native int or pointer, but got O
		//IL_0782: Expected O, but got I
		//IL_05f9: Expected O, but got Ref
		//IL_0613: Expected native int or pointer, but got O
		//IL_062d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 16f;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGray.png");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGray1.png");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGray2.png");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGrayInverted");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(360f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.25f, 0.8f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(2f, 1f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			_ = 0;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			List<string> list2 = new List<string>();
			int version5 = list2._version + 1;
			list2._version = version5;
			string[] items5 = list2._items;
			if (list2._size >= items5.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"Smoke1.png");
			}
			else
			{
				int size5 = list2._size + 1;
				list2._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(360f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.2f, 0.45f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.35f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
			_ = 0;
			particleSystemConfig2._emitZone = emitZone;
			particleSystemConfig2._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
			Transform parent2 = base.transform;
			ParticleSystem particleSystem = _pfxManager.CreateEmitter(particleSystemConfig2, parent2);
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0062: Expected O, but got Ref
		ParticleSystem pfx = _pfx;
		if ((object)_pfx != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			object obj = default(object);
			_pfxManager.EmitParticleTowards(pos, (Vector3)(&obj));
		}
	}
}
