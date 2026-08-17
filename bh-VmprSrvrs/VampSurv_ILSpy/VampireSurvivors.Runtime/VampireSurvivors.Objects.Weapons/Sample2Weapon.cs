using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Sample2Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public Sample2Weapon _003C_003E4__this;

		public float reactorDuration;

		internal void _003CstartReactor_003Eb__0()
		{
			//IL_0025: Expected O, but got I
			//IL_0046: Expected I, but got O
			//IL_004e: Expected I, but got O
			//IL_005e: Expected O, but got I
			//IL_009a: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_012f: Expected O, but got I4
			//IL_0121: Expected O, but got I4
			//IL_01e3: Invalid comparison between O and F4
			Weapon weapon = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (VampireSurvivors.Objects.Weapons.Weapon)+1B0]");
			float2 pos = default(float2);
			Projectile projectile = ((BulletPool)0).SpawnAt(pos, _003C_003E4__this);
			Sample2Weapon sample2Weapon = _003C_003E4__this;
			nint num = (nint)typeof(Sample2Reactor);
			nint num2 = (nint)projectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Reactor>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Reactor>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v8+FFFFFFF8+v91 @ rax_v7*8]");
				if (0 == (nint)typeof(Sample2Reactor))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Reactor>)+130]");
					object obj3 = 0;
					object obj4 = sample2Weapon._samplesAmount * reactorDuration;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v8+FFFFFFF8+v96 @ rcx_v5*8]");
					object obj5 = ((0 != (nint)typeof(Sample2Reactor)) ? ((object)0) : ((object)1));
					bool flag = obj5 == null;
					Projectile projectile2 = null;
					if (!flag)
					{
						projectile2 = projectile;
					}
					BaseBody body = projectile2.body;
					body._enable = true;
					float num4 = 100f;
					float num5 = 111.111115f;
					float num6 = default(float);
					num4 = num6;
					float num7 = default(float);
					num5 = num7;
					do
					{
						num4 += num5;
						num5 = num4 / 0.9f;
					}
					while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5));
					((Sample2Reactor)projectile2).fireThruster(num5);
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public Sample2Weapon _003C_003E4__this;

		public float2 pos;
	}

	private sealed class _003C_003Ec__DisplayClass33_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnExplosionClustersAt_003Eb__0()
		{
			//IL_0131: Expected O, but got I4
			//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass33_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass33_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						float2 pos = default(float2);
						Projectile projectile = obj3._003C_003E4__this.SpawnExplosionAt(pos, localIndex, 1, 0f);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected int _samplesAmount;

	private ParticleSystem _pfxSnowEmitter;

	protected List<float2> screenGrid;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	protected uint[] tints;

	protected bool _triggerReactor;

	protected PhaserSprite _reactorSprite;

	protected PhaserSprite _reactorHideCrimesSprite;

	public float reactorSpriteOffsetY;

	protected BulletPool _reactorPool;

	public Projectile reactorPrefab;

	protected float2 centrePos;

	protected MultiTargetTween _moveReactorTween;

	protected Timer _completeTimer;

	private int lastIndex;

	private int sequenceCounter;

	private float[] _randomOffsets;

	private int _randomOffsetsIndex;

	public override float PPower()
	{
		float num = base.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num3 = default(float);
		float num2 = num3;
		if (!flag)
		{
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num2 = num3;
			if (!flag2)
			{
				num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = currentWeaponData._003Cpower_003Ek__BackingField * num3;
					float num5 = num4 * num2;
					return num2 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float SecondaryPPower()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num2 = currentWeaponData._003Cpower_003Ek__BackingField * num;
				return num + num2;
			}
		}
		throw new NullReferenceException();
	}

	protected override void MakeLevelOne()
	{
		//IL_005c: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		base.MakeLevelOne();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		Action onComplete = delegate
		{
			base.Fire();
		};
		bool flag = list._size == 0;
		object obj = 1000;
		if (!flag)
		{
			obj = 100;
		}
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override void OnStart()
	{
		//IL_0053: Expected I, but got O
		//IL_00b1: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		_explosionType = WeaponType.C1_SAMPLES2_EXPLOSION;
		base.ResetFiringTimer();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager gameMan = _gameMan;
		PhysicsManager physicsManager = gameMan._physicsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+360]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, physicsManager._playerGroup, collideCallback, processCallback, callbackContext);
		Collider collider2 = collider.setName("Projectiles>Player");
		object obj2;
		object obj3 = default(object);
		do
		{
			float[] randomOffsets = _randomOffsets;
			object obj = -64;
			obj2 = 0 + 1;
			float num2 = (float)obj * (1f / 128f);
			float num3 = num2 * 0.64f;
			randomOffsets[obj3] = num3;
		}
		while ((nint)obj2 < 128);
		Extensions.Shuffle(_randomOffsets);
	}

	public virtual void MakeReactor()
	{
		//IL_007d: Expected I, but got O
		//IL_0179: Expected I, but got O
		//IL_0335: Expected O, but got I4
		//IL_04aa: Expected O, but got I4
		//IL_05a7: Expected O, but got I4
		//IL_0668: Expected O, but got I4
		//IL_0877->IL071b: Incompatible stack heights: 1 vs 0
		//IL_05c4->IL071b: Incompatible stack heights: 1 vs 0
		//IL_089e->IL071b: Incompatible stack heights: 1 vs 0
		//IL_05eb->IL071b: Incompatible stack heights: 1 vs 0
		//IL_0609->IL071b: Incompatible stack heights: 1 vs 0
		//IL_08c5->IL071b: Incompatible stack heights: 1 vs 0
		//IL_0630->IL071b: Incompatible stack heights: 1 vs 0
		//IL_064f->IL071b: Incompatible stack heights: 1 vs 0
		//IL_0685->IL071b: Incompatible stack heights: 1 vs 0
		//IL_08ec->IL071b: Incompatible stack heights: 1 vs 0
		//IL_06b9->IL071b: Incompatible stack heights: 1 vs 0
		//IL_06d8->IL071b: Incompatible stack heights: 1 vs 0
		BulletPool reactorPool = new BulletPool(reactorPrefab, 1);
		_reactorPool = reactorPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			ArcadePhysics physics = s_scene.physics;
			if ((object)s_scene.physics != null)
			{
				GameManager gameMan = _gameMan;
				if ((object)_gameMan != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+350]");
					ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num = (nint)this;
					if (physics.add != null)
					{
						ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
						CallbackContext callbackContext = default(CallbackContext);
						Collider collider = physics.add.overlap(_reactorPool, gameMan.Enemies, collideCallback, processCallback, callbackContext);
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							ArcadePhysics physics2 = s_scene2.physics;
							if ((object)s_scene2.physics != null)
							{
								GameManager gameMan2 = _gameMan;
								if ((object)_gameMan != null)
								{
									PhysicsManager physicsManager = gameMan2._physicsManager;
									if (gameMan2._physicsManager != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v999 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+3A0]");
										ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
										nint num2 = (nint)this;
										if (physics2.add != null)
										{
											Collider collider2 = physics2.add.overlap(_reactorPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
											PhaserWorld instance = PhaserWorld.Instance;
											if ((object)instance != null)
											{
												Vector2 pos = default(Vector2);
												PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "LaunchThrusters");
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene3 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserScene.Renderer renderer = s_scene3._renderer;
														if (s_scene3._renderer != null && (object)phaserSprite != null)
														{
															int depth = renderer.pixelHeight - 2;
															PhaserSprite phaserSprite2 = phaserSprite.setDepth(depth);
															if ((object)phaserSprite2 != null)
															{
																PhaserSprite phaserSprite3 = phaserSprite2.setTint(10066329u);
																if ((object)phaserSprite3 != null)
																{
																	PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
																	if ((object)phaserSprite4 != null)
																	{
																		PhaserSprite reactorSprite = phaserSprite4.setOrigin(0.5f, (float?)(object)1);
																		_reactorSprite = reactorSprite;
																		PhaserWorld instance2 = PhaserWorld.Instance;
																		if ((object)instance2 != null)
																		{
																			PhaserSprite phaserSprite5 = instance2.AddPhaserSprite(pos, "vfx", "LaunchThrustersLine");
																			if ((object)GM.Core != null)
																			{
																				PhaserScene s_scene4 = ArcadePhysics.s_scene;
																				if (ArcadePhysics.s_scene != null)
																				{
																					PhaserScene.Renderer renderer2 = s_scene4._renderer;
																					if (s_scene4._renderer != null && (object)phaserSprite5 != null)
																					{
																						int depth2 = renderer2.pixelHeight - 2;
																						PhaserSprite phaserSprite6 = phaserSprite5.setDepth(depth2);
																						if ((object)phaserSprite6 != null)
																						{
																							PhaserSprite phaserSprite7 = phaserSprite6.setTint(10066329u);
																							if ((object)phaserSprite7 != null)
																							{
																								PhaserSprite phaserSprite8 = phaserSprite7.setVisible(visible: false);
																								if ((object)phaserSprite8 != null)
																								{
																									PhaserSprite reactorHideCrimesSprite = phaserSprite8.setOrigin(0.5f, (float?)(object)1);
																									_reactorHideCrimesSprite = reactorHideCrimesSprite;
																									if ((object)GM.Core != null)
																									{
																										PhaserScene s_scene5 = ArcadePhysics.s_scene;
																										if (ArcadePhysics.s_scene != null)
																										{
																											PhaserScene.Renderer renderer3 = s_scene5._renderer;
																											if (s_scene5._renderer != null)
																											{
																												PhaserSprite reactorSprite2 = _reactorSprite;
																												if ((object)_reactorSprite != null && (object)reactorSprite2._spriteRenderer != null)
																												{
																													Sprite sprite = reactorSprite2._spriteRenderer.sprite;
																													if ((object)sprite != null)
																													{
																														bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
																														Sprite.GetTextureRect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
																														float num3 = (float)renderer3.pixelWidth * 0.8f;
																														object obj = default(object);
																														float xScale = num3 / (float)obj;
																														if ((object)_reactorSprite != null)
																														{
																															PhaserSprite phaserSprite9 = _reactorSprite.setScale(xScale, (float?)(object)0);
																															if ((object)GM.Core != null)
																															{
																																PhaserScene s_scene6 = ArcadePhysics.s_scene;
																																if (ArcadePhysics.s_scene != null && s_scene6._renderer != null && (object)GM.Core != null)
																																{
																																	PhaserScene s_scene7 = ArcadePhysics.s_scene;
																																	if (ArcadePhysics.s_scene != null && s_scene7._renderer != null && (object)_reactorHideCrimesSprite != null)
																																	{
																																		PhaserSprite phaserSprite10 = _reactorHideCrimesSprite.setScale(xScale, (float?)(object)1);
																																		if ((object)GM.Core != null)
																																		{
																																			PhaserScene s_scene8 = ArcadePhysics.s_scene;
																																			if (ArcadePhysics.s_scene != null)
																																			{
																																				PhaserScene.Renderer renderer4 = s_scene8._renderer;
																																				if (s_scene8._renderer != null && (object)_reactorSprite != null)
																																				{
																																					float height = _reactorSprite.Height;
																																					float num4 = renderer4.height * 0.5f;
																																					float num5 = height + num4;
																																					reactorSpriteOffsetY = num5;
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

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00ca: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		ParticleEmitterManager particlesManager = _particlesManager;
		if ((object)_particlesManager == null || ((UnityEngine.Object)particlesManager).m_CachedPtr == (IntPtr)0)
		{
			GenerateParticleSystems();
		}
		PhaserSprite reactorSprite = _reactorSprite;
		if ((object)_reactorSprite == null || ((UnityEngine.Object)reactorSprite).m_CachedPtr == (IntPtr)0)
		{
			MakeReactor();
		}
		List<float2> list = screenGrid;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v13 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)0 > (nint)0)
		{
			return;
		}
		object obj = 1;
		float2 item = default(float2);
		do
		{
			object obj2 = 1;
			do
			{
				screenGrid.Add(item);
				obj2++;
			}
			while ((nint)obj2 < 10);
			obj++;
		}
		while ((nint)obj < 10);
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0167: Expected O, but got F4
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0118: Expected O, but got F4
		//IL_0126: Expected O, but got F4
		//IL_014e: Expected O, but got F4
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_03d6: Expected O, but got F4
		//IL_0261: Expected O, but got F4
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_04d3: Expected O, but got I4
		//IL_0538: Expected F4, but got O
		//IL_0538: Expected I4, but got O
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected O, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_048a->IL02f6: Incompatible stack heights: 1 vs 0
		//IL_02e0->IL02f6: Incompatible stack heights: 2 vs 0
		List<float2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		screenGrid = list;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							float num = renderer2.height * 0.3f;
							float num2 = renderer.width * 0.25f;
							if (!(num > num2))
							{
								num2 = num;
							}
							List<float2> list2 = null;
							float2 float5 = default(float2);
							List<float2> list8 = default(List<float2>);
							List<float2> list9 = default(List<float2>);
							while (true)
							{
								List<float2> list3 = null;
								object obj3;
								while (true)
								{
									bool flag = (nint)list2 != 1;
									List<float2> list4 = list3;
									if (!flag)
									{
										while (true)
										{
											bool flag2 = (nint)list4 != 1;
											list3 = list4;
											if (flag2)
											{
												break;
											}
											list4 = (List<float2>)(list4 + 1);
											object obj = num2 ^ -0f;
											object obj2 = num2 ^ -0f;
											float num3 = (float)obj + num2;
											float num4 = (float)obj2 + num2;
											centrePos = (float2)num3;
										}
									}
									obj3 = num2 ^ -0f;
									if (screenGrid == null)
									{
										break;
									}
									screenGrid.Add(float5);
									list3 = (List<float2>)(list3 + 1);
									if ((nint)list3 < 3)
									{
										continue;
									}
									goto IL_01c1;
								}
								break;
								IL_01c1:
								list2 = (List<float2>)(list2 + 1);
								if ((nint)list2 < 3)
								{
									continue;
								}
								Extensions.Shuffle(screenGrid);
								_samplesAmount = 3;
								sequenceCounter = 3;
								float2 float6 = float5;
								List<float2> list5 = null;
								while (true)
								{
									object obj4 = UnityEngine.Random.value;
									VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
									{
										break;
									}
									CharacterData currentCharacterData = characterController._currentCharacterData;
									if (characterController._currentCharacterData == null)
									{
										break;
									}
									float6 = (float2)(currentCharacterData._003Cluck_003Ek__BackingField * 0.5f);
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6))
									{
										int num5 = sequenceCounter + 1;
										sequenceCounter = num5;
									}
									list5 = (List<float2>)(list5 + 1);
									if ((nint)list5 < 2)
									{
										continue;
									}
									IntPtr main_Injected = Camera.get_main_Injected();
									Camera camera = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected);
									if ((object)camera == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v49 (UnityEngine.Camera)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v49 (UnityEngine.Camera)+10]");
									IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									if ((object)transform == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v54 (UnityEngine.Transform)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v54 (UnityEngine.Transform)+10]");
									float2 ret;
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
									List<float2> list6 = null;
									List<float2> list7 = (List<float2>)2400;
									list6 = list8;
									list7 = list9;
									do
									{
										fireSample((int)list6, ret, (float)list7, 0f);
										list6 = (List<float2>)(list6 + 1);
										list7 = (List<float2>)(list7 + 300);
									}
									while ((nint)list7 < 4800);
									if (!skipTriggers)
									{
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											break;
										}
										((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
									}
									return;
								}
								break;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void fireSample(int sampleInt, float2 position, float flashDelay, float activationDelay)
	{
		//IL_0060: Expected I, but got O
		//IL_006e: Expected I, but got O
		//IL_007e: Expected O, but got I
		//IL_00fe: Expected O, but got I4
		//IL_00ba: Expected O, but got I
		//IL_00f0: Expected O, but got I4
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 float5 = default(float2);
		Projectile projectile = base.FireOneProjectile(float5, sampleInt, _targetTransform);
		Sample2Projectile sample2Projectile;
		if ((object)projectile == null)
		{
			sample2Projectile = null;
			goto IL_01fa;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(Sample2Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v32+FFFFFFF8+v173 @ rax_v28*8]");
			if (0 == (nint)typeof(Sample2Projectile))
			{
				obj3 = 1;
				goto IL_01d2;
			}
		}
		obj3 = 0;
		goto IL_01d2;
		IL_01d2:
		bool flag = obj3 == null;
		sample2Projectile = null;
		if (!flag)
		{
			sample2Projectile = (Sample2Projectile)projectile;
		}
		goto IL_01fa;
		IL_01fa:
		if ((object)sample2Projectile == null || ((UnityEngine.Object)sample2Projectile).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		List<float2> list = screenGrid;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v20 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)sampleInt < (nint)0)
		{
			bool flag2 = sampleInt >= sequenceCounter;
			int showNumber = 10;
			if (!flag2)
			{
				showNumber = sampleInt;
			}
			if (_triggerReactor)
			{
				showNumber = 10;
			}
			float activationDelay2 = default(float);
			sample2Projectile.SetFloorTarget(showNumber, float5, flashDelay, activationDelay2);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void InputSequence(int index)
	{
		//IL_015c: Expected O, but got I4
		//IL_010c: Expected F4, but got I4
		//IL_012a: Expected I4, but got I8
		//IL_0053: Expected O, but got I4
		//IL_007e: Expected I4, but got I8
		//IL_00b1: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		if (index != 0)
		{
			if (index != lastIndex && index < 9)
			{
				object obj = lastIndex + 1;
				if (index != (nint)obj)
				{
					lastIndex = -1;
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_CardDeny, 1300f, 10, 0f, volume, rate, detune, loop, 1f);
				}
				else
				{
					lastIndex = index;
				}
			}
		}
		else
		{
			lastIndex = 0;
		}
		object obj2 = sequenceCounter - 1;
		if (lastIndex >= (nint)obj2)
		{
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_TaskComplete, 1300f, 10, 0f, volume, rate, detune, loop, 1f);
			startReactor();
			lastIndex = -1;
		}
	}

	protected void startReactor()
	{
		//IL_01e9: Expected O, but got F4
		//IL_01f2: Invalid comparison between O and F4
		//IL_0138: Expected I, but got O
		//IL_01d1->IL01d1: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		if (_triggerReactor)
		{
			return;
		}
		_triggerReactor = true;
		PhaserSprite phaserSprite = _reactorSprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _reactorHideCrimesSprite.setVisible(visible: true);
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float reactorDuration = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f)) ? 750f : 500f);
		CS_0024_003C_003E8__locals6.reactorDuration = reactorDuration;
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary._002Ector();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.height * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"reactorSpriteOffsetY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 500f;
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		bool flag2 = obj3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.ease = Ease.InOutSine;
		TweenCallback onComplete = delegate
		{
			//IL_0025: Expected O, but got I
			//IL_0046: Expected I, but got O
			//IL_004e: Expected I, but got O
			//IL_005e: Expected O, but got I
			//IL_009a: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_012f: Expected O, but got I4
			//IL_0121: Expected O, but got I4
			//IL_01e3: Invalid comparison between O and F4
			Weapon weapon = CS_0024_003C_003E8__locals6._003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (VampireSurvivors.Objects.Weapons.Weapon)+1B0]");
			float2 pos = default(float2);
			Projectile projectile = ((BulletPool)0).SpawnAt(pos, CS_0024_003C_003E8__locals6._003C_003E4__this);
			Sample2Weapon sample2Weapon = CS_0024_003C_003E8__locals6._003C_003E4__this;
			nint num3 = (nint)typeof(Sample2Reactor);
			nint num4 = (nint)projectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Reactor>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Reactor>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v8+FFFFFFF8+v91 @ rax_v7*8]");
				if (0 == (nint)typeof(Sample2Reactor))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Reactor>)+130]");
					object obj6 = 0;
					object obj7 = sample2Weapon._samplesAmount * CS_0024_003C_003E8__locals6.reactorDuration;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v8+FFFFFFF8+v96 @ rcx_v5*8]");
					object obj8 = ((0 != (nint)typeof(Sample2Reactor)) ? ((object)0) : ((object)1));
					bool flag3 = obj8 == null;
					Projectile projectile2 = null;
					if (!flag3)
					{
						projectile2 = projectile;
					}
					BaseBody body = projectile2.body;
					body._enable = true;
					float num6 = 100f;
					float num7 = 111.111115f;
					float num8 = default(float);
					num6 = num8;
					float num9 = default(float);
					num7 = num9;
					do
					{
						num6 += num7;
						num7 = num6 / 0.9f;
					}
					while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num7));
					((Sample2Reactor)projectile2).fireThruster(num7);
					return;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween moveReactorTween = Tweens.Add(tweenConfig);
		_moveReactorTween = moveReactorTween;
	}

	public void hideReactor()
	{
		//IL_00c7: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary._002Ector();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = _reactorSprite.Height;
		float num = renderer.height * 0.5f;
		float num2 = height + num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"reactorSpriteOffsetY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 500f;
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.ease = Ease.InOutSine;
			TweenCallback onComplete = delegate
			{
				_triggerReactor = false;
				PhaserSprite phaserSprite = _reactorSprite.setVisible(visible: false);
				PhaserSprite phaserSprite2 = _reactorHideCrimesSprite.setVisible(visible: false);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween moveReactorTween = Tweens.Add(tweenConfig);
			_moveReactorTween = moveReactorTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void completeReactor()
	{
		_reactorPool.Cleanup();
	}

	protected virtual void LateUpdate()
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00ee->IL008e: Incompatible stack heights: 1 vs 0
		//IL_007e->IL008e: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj2 = default(object);
				object obj = obj2 + reactorSpriteOffsetY;
				if ((object)_reactorSprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					if ((object)_reactorHideCrimesSprite != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SpawnExplosionClustersAt(float2 pos)
	{
		//IL_0056: Invalid comparison between O and F4
		//IL_00f7: Expected I, but got O
		//IL_010d: Expected O, but got I
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		//IL_01e2: Expected O, but got I4
		//IL_01f9: Expected I, but got I8
		//IL_01b6: Invalid comparison between F4 and I4
		//IL_016d: Expected I, but got I8
		_003C_003Ec__DisplayClass33_0 obj = new _003C_003Ec__DisplayClass33_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		float2 float5 = default(float2);
		Projectile projectile = SpawnExplosionAt(float5, 0, 1, 0f);
		float num = base.PAmount();
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			return;
		}
		int num2 = 1;
		float num6;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass33_1 obj2 = new _003C_003Ec__DisplayClass33_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = num2;
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass33_1._003CSpawnExplosionClustersAt_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num4;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_01d9;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num4 = ((Delegate)action).method_ptr;
			goto IL_01d9;
			IL_01d9:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num5 = (float)num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			num6 = num5 * 0.001f;
			Timer lastShotTimer = Timers.Register(num6, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			num2++;
			float num7 = base.PAmount();
		}
		while (num6 > (float)num2);
	}

	public override Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_027b: Expected I4, but got I8
		//IL_02ab: Expected O, but got I4
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected I4, but got Unknown
		//IL_02fb: Expected I4, but got I8
		//IL_032b: Expected O, but got I4
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected I4, but got Unknown
		//IL_0156: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_0206: Expected I, but got O
		if (_secondaryPool != null)
		{
			goto IL_023e;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(_explosionType);
		BulletPool secondaryPool = new BulletPool(projectilePrefab);
		_secondaryPool = secondaryPool;
		Factory add;
		ArcadeColliderType enemies;
		ArcadePhysicsCallback collideCallback;
		ArcadeColliderType secondaryPool2;
		if (_secondaryOvarlapDamageType != WeaponType.CURSE)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				add = physics.add;
				GameManager core = GM.Core;
				enemies = core.Enemies;
				nint method = default(nint);
				collideCallback = new ArcadePhysicsCallback(this, method);
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+370]");
				method = 0;
				secondaryPool2 = _secondaryPool;
				goto IL_0175;
			}
		}
		else if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			add = physics2.add;
			GameManager core2 = GM.Core;
			enemies = core2.Enemies;
			collideCallback = null;
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+380]");
			nint method = 0;
			secondaryPool2 = _secondaryPool;
			goto IL_0175;
		}
		goto IL_0369;
		IL_0369:
		throw new NullReferenceException();
		IL_0175:
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = add.overlap(secondaryPool2, enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			PhysicsManager physicsManager = core3._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider2 = physics3.add.overlap(_secondaryPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			goto IL_023e;
		}
		goto IL_0369;
		IL_023e:
		float[] randomOffsets = _randomOffsets;
		int num4 = ++_randomOffsetsIndex;
		int num5 = (int)(_randomOffsetsIndex & 0x8000007FL);
		if ((nint)_randomOffsets < 0)
		{
			object obj = num5 - 1;
			object obj2 = obj | -128;
			num5 = obj2 + 1;
		}
		if (num5 < randomOffsets.Length)
		{
			int randomOffsetsIndex = num4 + 1;
			_randomOffsetsIndex = randomOffsetsIndex;
			int num6 = (int)(num4 & 0x8000007FL);
			if ((nint)_randomOffsets < 0)
			{
				object obj3 = num6 - 1;
				object obj4 = obj3 | -128;
				num6 = obj4 + 1;
			}
			float2 pos2 = default(float2);
			if (num6 < randomOffsets.Length)
			{
				return _secondaryPool.SpawnAt(pos2, this, enemiesHit);
			}
		}
		return (Projectile)(object)new IndexOutOfRangeException();
	}

	protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_021d: Expected I4, but got O
		//IL_0119: Expected I, but got O
		//IL_0127: Expected I, but got O
		//IL_0137: Expected O, but got I
		//IL_01b7: Expected O, but got I4
		//IL_0173: Expected O, but got I
		//IL_01a9: Expected O, but got I4
		Projectile component2;
		Sample2Projectile sample2Projectile;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				if ((object)component != null)
				{
					if (component._isDead || component.IsDisconnectedFromOnlinePlay)
					{
						goto IL_0209;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 == null)
							{
								sample2Projectile = null;
								goto IL_0266;
							}
							nint num = (nint)component2;
							nint num2 = (nint)typeof(Sample2Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Projectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample2Projectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v28+FFFFFFF8+v240 @ rax_v24*8]");
								if (0 == (nint)typeof(Sample2Projectile))
								{
									obj3 = 1;
									goto IL_023f;
								}
							}
							obj3 = 0;
							goto IL_023f;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_023f:
		bool flag = obj3 == null;
		sample2Projectile = null;
		if (!flag)
		{
			sample2Projectile = (Sample2Projectile)component2;
		}
		goto IL_0266;
		IL_0266:
		if ((object)sample2Projectile != null && ((UnityEngine.Object)sample2Projectile).m_CachedPtr != (IntPtr)0)
		{
			sample2Projectile.Break();
			return true;
		}
		goto IL_0209;
		IL_0209:
		return false;
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01a8: Expected I4, but got O
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
						goto IL_01c5;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = SecondaryPPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									float num2 = default(float);
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
									float2 position = component.position;
									Vector2 pos = default(Vector2);
									RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, 10);
									float2 position2 = component.position;
									RenderingExtensions.EmitParticleAt(_pfxEmitter2, pos, 5);
								}
								goto IL_01c5;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01c5:
		return false;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		PhaserSprite reactorSprite = _reactorSprite;
		if ((object)_reactorSprite != null && ((UnityEngine.Object)reactorSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _reactorSprite.setVisible(visible: false);
		}
		if (_moveReactorTween != null)
		{
			_moveReactorTween.Kill();
		}
		if (_reactorPool != null)
		{
			_reactorPool.Cleanup();
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0205: Expected O, but got I4
		//IL_021e: Expected O, but got Ref
		//IL_0238: Expected native int or pointer, but got O
		//IL_0252: Expected O, but got I
		//IL_0272: Expected O, but got Ref
		//IL_028c: Expected native int or pointer, but got O
		//IL_02a6: Expected O, but got I
		//IL_02c6: Expected O, but got Ref
		//IL_02e0: Expected native int or pointer, but got O
		//IL_08ad: Expected O, but got I4
		//IL_0305: Expected O, but got Ref
		//IL_031f: Expected native int or pointer, but got O
		//IL_08e7: Expected O, but got I
		//IL_0357: Expected O, but got Ref
		//IL_037e: Expected O, but got I
		//IL_0398: Expected native int or pointer, but got O
		//IL_0921: Expected O, but got I
		//IL_03d0: Expected O, but got Ref
		//IL_03f7: Expected O, but got I
		//IL_041e: Expected O, but got I
		//IL_0438: Expected native int or pointer, but got O
		//IL_0460: Expected O, but got I
		//IL_095b: Expected O, but got I
		//IL_057e: Expected O, but got I4
		//IL_0597: Expected O, but got Ref
		//IL_05b1: Expected native int or pointer, but got O
		//IL_05cb: Expected O, but got I
		//IL_05eb: Expected O, but got Ref
		//IL_0605: Expected native int or pointer, but got O
		//IL_061f: Expected O, but got I
		//IL_063f: Expected O, but got Ref
		//IL_0659: Expected native int or pointer, but got O
		//IL_09e2: Expected O, but got I
		//IL_0691: Expected O, but got Ref
		//IL_06ab: Expected native int or pointer, but got O
		//IL_0a1c: Expected O, but got I
		//IL_06e3: Expected O, but got Ref
		//IL_070a: Expected O, but got I
		//IL_0724: Expected native int or pointer, but got O
		//IL_0a56: Expected O, but got I
		//IL_075c: Expected O, but got Ref
		//IL_0776: Expected native int or pointer, but got O
		//IL_0a90: Expected O, but got I
		//IL_07ae: Expected O, but got Ref
		//IL_07c8: Expected native int or pointer, but got O
		//IL_0aca: Expected O, but got I
		//IL_0b6f: Expected O, but got I
		//IL_0b90: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 704))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitCloud1");
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
			((List<object>)(object)list).AddWithResize((object)"HitCloud2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		_ = 0;
		particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(-80f, -100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 344));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+168]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+178]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+188]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		particleSystemConfig._on = false;
		particleSystemConfig._tintRandom = tints;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		Transform transform = _pfxEmitter2.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxLine2");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 408));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+198]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 440));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B8]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 472));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(20f, 30f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig2._speedX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 504));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(-80f, -100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+208]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 536));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+218]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+228]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 568));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0.05f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+238]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+248]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 600));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+258]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+268]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._tintRandom = tints;
		particleSystemConfig2._on = false;
		bool flag2 = (object)_particlesManager == null;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		bool flag3 = (object)_pfxEmitter == null;
		Transform transform2 = _pfxEmitter.transform;
		bool flag4 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v104 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v104 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
	}

	public Sample2Weapon()
	{
		//IL_0044: Expected I4, but got I8
		_samplesAmount = 8;
		List<float2> list = new List<float2>();
		screenGrid = list;
		tints = new uint[3] { 16777215u, 12303359u, 12632319u };
		lastIndex = -1;
		sequenceCounter = 3;
		_randomOffsets = new float[128];
		base._002Ector();
	}

	private void _003CMakeLevelOne_003Eb__22_0()
	{
		base.Fire();
	}

	private void _003ChideReactor_003Eb__30_0()
	{
		_triggerReactor = false;
		PhaserSprite phaserSprite = _reactorSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _reactorHideCrimesSprite.setVisible(visible: false);
	}
}
