using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class LegionnaireWeapon : SwordWeapon
{
	private BulletPool _legionnairePool;

	private float _spawnRadius = 0.64f;

	private PhaserSprite _cursor;

	private Circle _spawnCircle;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _smokeEmitter;

	public ParticleSystem SmokeEmitter => _smokeEmitter;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_011c: Expected F4, but got I
		//IL_0131: Expected F4, but got I
		//IL_0354: Expected O, but got I
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Expected O, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0551: Expected O, but got Ref
		//IL_056b: Expected native int or pointer, but got O
		//IL_07e5: Expected O, but got I4
		//IL_0583: Expected O, but got Ref
		//IL_05aa: Expected O, but got I
		//IL_05c4: Expected native int or pointer, but got O
		//IL_05de: Expected O, but got I
		//IL_05fe: Expected O, but got Ref
		//IL_0618: Expected native int or pointer, but got O
		//IL_0632: Expected O, but got I
		//IL_0652: Expected O, but got Ref
		//IL_066c: Expected native int or pointer, but got O
		//IL_0802: Expected O, but got I4
		//IL_0691: Expected O, but got Ref
		//IL_06ab: Expected native int or pointer, but got O
		//IL_0834: Expected O, but got I
		//IL_06fc: Expected O, but got I
		//IL_07a6->IL0752: Incompatible stack heights: 1 vs 0
		//IL_01be->IL0752: Incompatible stack heights: 1 vs 0
		//IL_01ee->IL0752: Incompatible stack heights: 1 vs 0
		//IL_07cd->IL0752: Incompatible stack heights: 1 vs 0
		//IL_0222->IL0752: Incompatible stack heights: 1 vs 0
		//IL_023f->IL0752: Incompatible stack heights: 1 vs 0
		//IL_0272->IL0752: Incompatible stack heights: 1 vs 0
		//IL_03b5->IL0752: Incompatible stack heights: 2 vs 0
		//IL_03f7->IL0752: Incompatible stack heights: 2 vs 0
		//IL_04a4->IL0752: Incompatible stack heights: 2 vs 0
		//IL_052c->IL0752: Incompatible stack heights: 2 vs 0
		//IL_0724->IL0752: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		((Weapon)this).InitWeapon(characterController, weaponType);
		base._firingCounter = 0;
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((SwordWeapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
		if (_signalBus != null)
		{
			((SwordWeapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((SwordWeapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			if (_signalBus != null)
			{
				((SwordWeapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
				base._canRetaliate = true;
				_canDoFinisher = true;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						Circle circle = new Circle();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
						circle._x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+AC]");
						circle._y = 0f;
						circle._radius = _spawnRadius;
						_spawnCircle = circle;
						PhaserWorld instance = PhaserWorld.Instance;
						SwordWeapon cachedTransform = (SwordWeapon)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
							if ((object)instance != null)
							{
								Vector2 pos = default(Vector2);
								PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "foscari");
								if ((object)phaserSprite != null)
								{
									PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.65f);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null && (object)phaserSprite2 != null)
											{
												PhaserSprite phaserSprite3 = phaserSprite2.setDepth(renderer.height);
												if ((object)phaserSprite3 != null)
												{
													PhaserSprite cursor = phaserSprite3.setVisible(visible: false);
													_cursor = cursor;
													GameObject gameObject = new GameObject();
													GameObject.Internal_CreateGameObject(gameObject, (string)null);
													nint num = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rbx_v10 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
													_ = 0;
													bool flag2 = (object)gameObject == null;
													ParticleEmitterManager pfxEmitterManager;
													if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160))))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
														pfxEmitterManager = (ParticleEmitterManager)0;
													}
													else
													{
														pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
													}
													_pfxEmitterManager = pfxEmitterManager;
													ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
													List<string> list = new List<string>();
													if (list != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v48 (System.Collections.Generic.List`1<System.String>)+1C]");
														_ = (nint)0 + (nint)1;
														IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
														if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
														{
															CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v46 (System.IntPtr)+18]");
															if ((nint)cancellationTokenSource >= 0)
															{
																((List<object>)(object)list).AddWithResize((object)"Smoke1");
															}
															else
															{
																CancellationTokenSource cancellationTokenSource2 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
																((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v48 (System.Collections.Generic.List`1<System.String>)+1C]");
															_ = (nint)0 + (nint)1;
															IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list).m_CachedPtr;
															if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
															{
																CancellationTokenSource cancellationTokenSource3 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rcx_v48 (System.IntPtr)+18]");
																if ((nint)cancellationTokenSource3 >= 0)
																{
																	((List<object>)(object)list).AddWithResize((object)"Smoke2");
																}
																else
																{
																	CancellationTokenSource cancellationTokenSource4 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
																	((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource4;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																if (particleSystemConfig != null)
																{
																	particleSystemConfig._frame = list;
																	ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(10f, 20f));
																	particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																	ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
																	_ = 0;
																	_ = 2;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
																	particleSystemConfig._quantity = (int?)(object)0;
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
																	particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(50f, 150f));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
																	particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.65f, 0f));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
																	_ = 0;
																	particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
																	_ = 0;
																	ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
																	_ = 0;
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 1.25f));
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
																	_ = 0;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
																	particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
																	_ = 0;
																	_ = 0;
																	_ = 16772829;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
																	particleSystemConfig._tint = (uint?)(object)0;
																	particleSystemConfig._on = false;
																	if ((object)_pfxEmitterManager != null)
																	{
																		ParticleSystem smokeEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
																		_smokeEmitter = smokeEmitter;
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
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.FireInternal();
		FireLegionnaire();
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected override void OnStart()
	{
		//IL_0080: Expected I, but got O
		base.OnStart();
		if (_legionnairePool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.LEGIONNAIRE);
			BulletPool legionnairePool = new BulletPool(projectilePrefab);
			_legionnairePool = legionnairePool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.LegionnaireWeapon>)+390]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_legionnairePool, core.Enemies, collideCallback, processCallback, callbackContext);
		}
	}

	public void FireLegionnaire()
	{
		//IL_00a2: Expected F4, but got O
		//IL_01a8: Expected O, but got I
		//IL_0222: Expected O, but got I
		//IL_01fe: Expected I4, but got O
		float2 position = _cursor.position;
		Projectile projectile = _legionnairePool.SpawnAt(position, this);
		float num = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,xmm0\"");
		int num2 = default(int);
		if (num2 < 1)
		{
			return;
		}
		float2 position2 = _cursor.position;
		float2 position3 = _cursor.position;
		Circle circle = new Circle();
		circle._x = (float)position2;
		float y = default(float);
		circle._y = y;
		circle._radius = _spawnRadius;
		_spawnCircle = circle;
		Circle spawnCircle = _spawnCircle;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2ACE]");
		List<Vector2> list2;
		int capacity;
		List<Vector2> list4;
		if ((nint)0 == 0)
		{
			_ = 1;
			List<Vector2> list = new List<Vector2>(num2);
			list2 = list;
			List<Vector2> list3 = list;
			capacity = num2;
			list4 = list;
		}
		else
		{
			List<Vector2> list5 = new List<Vector2>(num2);
			list2 = list5;
			List<Vector2> list3 = list5;
			capacity = num2;
			list4 = list5;
		}
		int num3 = 0;
		float2 float5 = default(float2);
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,ebx\"");
			float num4 = 0f * (float)Math.PI;
			float num5 = num4 + num4;
			float num6 = num5 / (float)num2;
			list4._002Ector(capacity);
			float num7 = num6 * spawnCircle._radius;
			float num8 = num7 + spawnCircle._x;
			list4._002Ector(capacity);
			float num9 = num6 * spawnCircle._radius;
			float num10 = num9 + spawnCircle._y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			list4 = (List<Vector2>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			capacity = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v12 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if (num11 >= 0)
			{
				list2.AddWithResize((Vector2)float5);
				capacity = (int)float5;
				list4 = list2;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj = (nint)0 + (nint)1;
			}
			num3++;
		}
		while (num3 < num2);
		int num12 = 0;
		int num13 = 0;
		while (true)
		{
			int num14 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbp_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)num14 < (nint)0)
			{
				int num15 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)num15 >= (nint)0)
				{
					break;
				}
				Projectile projectile2 = _legionnairePool.SpawnAt(float5, this, num12);
				num12++;
				num13 = num12;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	protected override void OnUpdate()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 position3 = default(float2);
		PhaserSprite phaserSprite = _cursor.setPosition(position3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float angle = 0f * 57.29578f;
		_cursor.angle = angle;
	}

	protected float CalcRadAngle(float x1, float y1, float x2, float y2)
	{
		float num = x2 - x1;
		object obj = default(object);
		float result = (float)obj - y1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		return result;
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		if (((Weapon)this)._003CCanCrit_003Ek__BackingField)
		{
			base.StandardCritical(second, first);
			return false;
		}
		return ((Weapon)this).OnBulletOverlapsEnemy(context, second, first);
	}

	public LegionnaireWeapon()
	{
		base._maxFiringCounter = 5;
		((Weapon)this)._002Ector();
	}
}
