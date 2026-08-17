using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Confodere1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public TP_Confodere1_Weapon _003C_003E4__this;

		public List<EnemyController> closest;

		public Transform source;

		public float x;

		public float y;

		internal void _003CFire_003Eb__0()
		{
			TP_Confodere1_Weapon tP_Confodere1_Weapon = _003C_003E4__this;
			RenderingExtensions.StopEmitting(tP_Confodere1_Weapon._emitter1);
			TP_Confodere1_Weapon tP_Confodere1_Weapon2 = _003C_003E4__this;
			RenderingExtensions.StopEmitting(tP_Confodere1_Weapon2._emitter2);
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_1
	{
		public int enemiesCount;

		public _003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals1;
	}

	private sealed class _003C_003Ec__DisplayClass41_2
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass41_1 CS_0024_003C_003E8__locals2;

		internal void _003CFire_003Eb__1()
		{
			//IL_0718: Expected I, but got O
			//IL_00c1->IL0680: Incompatible stack heights: 1 vs 0
			//IL_017a->IL0680: Incompatible stack heights: 1 vs 0
			//IL_01a9->IL0680: Incompatible stack heights: 1 vs 0
			//IL_01cb->IL0680: Incompatible stack heights: 1 vs 0
			//IL_0218->IL0680: Incompatible stack heights: 1 vs 0
			//IL_0247->IL0680: Incompatible stack heights: 1 vs 0
			//IL_0276->IL0680: Incompatible stack heights: 1 vs 0
			//IL_073c->IL0680: Incompatible stack heights: 2 vs 0
			//IL_02af->IL0680: Incompatible stack heights: 2 vs 0
			//IL_02d1->IL0680: Incompatible stack heights: 2 vs 0
			//IL_0348->IL0680: Incompatible stack heights: 2 vs 0
			//IL_0377->IL0680: Incompatible stack heights: 2 vs 0
			//IL_03bc->IL0680: Incompatible stack heights: 2 vs 0
			//IL_03ef->IL0680: Incompatible stack heights: 2 vs 0
			//IL_041e->IL0680: Incompatible stack heights: 2 vs 0
			//IL_044d->IL0680: Incompatible stack heights: 2 vs 0
			//IL_04a7->IL0680: Incompatible stack heights: 2 vs 0
			//IL_04d6->IL0680: Incompatible stack heights: 2 vs 0
			//IL_04f8->IL0680: Incompatible stack heights: 2 vs 0
			//IL_0546->IL0680: Incompatible stack heights: 2 vs 0
			//IL_0575->IL0680: Incompatible stack heights: 2 vs 0
			//IL_05bb->IL0680: Incompatible stack heights: 2 vs 0
			//IL_060a->IL0680: Incompatible stack heights: 2 vs 0
			//IL_0639->IL0680: Incompatible stack heights: 2 vs 0
			//IL_065b->IL0680: Incompatible stack heights: 2 vs 0
			//IL_0680->IL06e7: Incompatible stack heights: 2 vs 1
			_003C_003Ec__DisplayClass41_1 obj = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass41_0 obj2 = obj.CS_0024_003C_003E8__locals1;
				if (obj.CS_0024_003C_003E8__locals1 != null)
				{
					List<EnemyController> closest = obj2.closest;
					if (obj2.closest != null)
					{
						int num = localIndex % obj.enemiesCount;
						bool flag = num >= closest._size;
						EnemyController[] items = closest._items;
						if (closest._items != null)
						{
							if (num >= items.Length)
							{
								throw new IndexOutOfRangeException();
							}
							Component component = items[num];
							if ((object)items[num] == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v7 (UnityEngine.Component)+260]");
							if ((nint)0 != 0)
							{
								return;
							}
							_003C_003Ec__DisplayClass41_1 obj3 = CS_0024_003C_003E8__locals2;
							if (CS_0024_003C_003E8__locals2 != null)
							{
								BulletPool bulletPool = (BulletPool)(object)obj3.CS_0024_003C_003E8__locals1;
								if (obj3.CS_0024_003C_003E8__locals1 != null && ((EventEmitter)bulletPool).callbacks != null)
								{
									Transform source = ((TP_Confodere1_Weapon)(object)((EventEmitter)bulletPool).callbacks).GetSource();
									((Group)bulletPool).childrenToRemove = (HashSet<PhaserGameObject>)(object)source;
									_003C_003Ec__DisplayClass41_1 obj4 = CS_0024_003C_003E8__locals2;
									if (CS_0024_003C_003E8__locals2 != null)
									{
										_003C_003Ec__DisplayClass41_0 obj5 = obj4.CS_0024_003C_003E8__locals1;
										if (obj4.CS_0024_003C_003E8__locals1 != null)
										{
											BulletPool source2 = (BulletPool)(object)obj5.source;
											if ((object)obj5.source != null)
											{
												bool flag2 = ((EventEmitter)source2).callbacks == null;
												Transform.get_position_Injected((IntPtr)((EventEmitter)source2).callbacks, out Vector3 ret);
												_003C_003Ec__DisplayClass41_1 obj6 = CS_0024_003C_003E8__locals2;
												if (CS_0024_003C_003E8__locals2 != null)
												{
													_003C_003Ec__DisplayClass41_0 obj7 = obj6.CS_0024_003C_003E8__locals1;
													if (obj6.CS_0024_003C_003E8__locals1 != null && (object)obj7._003C_003E4__this != null)
													{
														float chanceFromArray = obj7._003C_003E4__this.GetChanceFromArray();
														object obj8 = default(object);
														float num2 = (float)obj8 * 8f;
														float num3 = num2 * 0.01f;
														float x = num3 + (float)ret;
														obj5.x = x;
														BulletPool bulletPool2 = (BulletPool)(object)CS_0024_003C_003E8__locals2;
														if (CS_0024_003C_003E8__locals2 != null)
														{
															BulletPool children = (BulletPool)(object)((Group)bulletPool2).children;
															if (((Group)bulletPool2).children != null)
															{
																BulletPool callbacks = (BulletPool)(object)((EventEmitter)children).callbacks;
																Transform transform = items[num].transform;
																if (((EventEmitter)children).callbacks != null)
																{
																	_003C_003Ec__DisplayClass41_1 obj9 = CS_0024_003C_003E8__locals2;
																	if (CS_0024_003C_003E8__locals2 != null)
																	{
																		_003C_003Ec__DisplayClass41_0 obj10 = obj9.CS_0024_003C_003E8__locals1;
																		if (obj9.CS_0024_003C_003E8__locals1 != null)
																		{
																			TP_Confodere1_Weapon tP_Confodere1_Weapon = obj10._003C_003E4__this;
																			if ((object)obj10._003C_003E4__this != null)
																			{
																				float2 position = items[num].position;
																				float2 position2 = items[num].position;
																				_003C_003Ec__DisplayClass41_1 obj11 = CS_0024_003C_003E8__locals2;
																				if (CS_0024_003C_003E8__locals2 != null)
																				{
																					_003C_003Ec__DisplayClass41_0 obj12 = obj11.CS_0024_003C_003E8__locals1;
																					if (obj11.CS_0024_003C_003E8__locals1 != null && tP_Confodere1_Weapon._destructibleProjectilePool != null)
																					{
																						float2 pos = default(float2);
																						Projectile projectile = tP_Confodere1_Weapon._destructibleProjectilePool.SpawnAt(pos, obj12._003C_003E4__this, localIndex);
																						_003C_003Ec__DisplayClass41_1 obj13 = CS_0024_003C_003E8__locals2;
																						if (CS_0024_003C_003E8__locals2 != null)
																						{
																							_003C_003Ec__DisplayClass41_0 obj14 = obj13.CS_0024_003C_003E8__locals1;
																							if (obj13.CS_0024_003C_003E8__locals1 != null)
																							{
																								_003C_003Ec__DisplayClass41_1 obj15 = CS_0024_003C_003E8__locals2;
																								_003C_003Ec__DisplayClass41_0 obj16 = obj15.CS_0024_003C_003E8__locals1;
																								TP_Confodere1_Weapon tP_Confodere1_Weapon2 = obj16._003C_003E4__this;
																								if ((object)obj16._003C_003E4__this != null)
																								{
																									Projectile projectile2 = obj14._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Confodere1_Weapon2._targetTransform);
																									_003C_003Ec__DisplayClass41_1 obj17 = CS_0024_003C_003E8__locals2;
																									if (CS_0024_003C_003E8__locals2 != null)
																									{
																										_003C_003Ec__DisplayClass41_0 obj18 = obj17.CS_0024_003C_003E8__locals1;
																										if (obj17.CS_0024_003C_003E8__locals1 != null && (object)obj18._003C_003E4__this != null)
																										{
																											obj18._003C_003E4__this.DealDamage(items[num]);
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
			throw new NullReferenceException();
		}
	}

	private float _range;

	private int _sourceIndex;

	private float _maxSources;

	private List<Transform> _sources;

	protected SpriteRenderer _TargetZone;

	protected Transform _cachedTargetTransform;

	protected Color _targetZoneCol;

	protected float _targetZoneStroke;

	private static readonly int AlphaId;

	private static readonly int ColorId;

	private static readonly int ThicknessId;

	[NonSerialized]
	public int _FireCounter;

	[NonSerialized]
	public int[] _FireAngles;

	private float _defaultRange;

	private BulletPool _destructibleProjectilePool;

	private Projectile _destructibleProjectilePrefab;

	private BulletPool _bigProjectilePool;

	private Projectile _bigProjectilePrefab;

	private BulletPool _specialProjectilePool;

	private Projectile _specialProjectilePrefab;

	protected int _activations;

	protected bool _hasLight;

	protected bool _hasDark;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	protected List<WeaponType> lightGlyphs;

	protected List<WeaponType> darkGlyphs;

	private Timer glyphCheckTimer;

	protected virtual bool bigProjectileEnabled => false;

	protected virtual bool specialProjectileEnabled => false;

	protected override void Awake()
	{
		MakeEmitters();
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_006e: Expected F4, but got I4
		//IL_0a33: Expected I, but got O
		//IL_02ab: Expected I, but got O
		//IL_03bd: Expected I, but got O
		//IL_04d5: Expected I, but got O
		//IL_05e7: Expected I, but got O
		//IL_06ff: Expected I, but got O
		//IL_086c: Expected I4, but got O
		//IL_0be3: Expected I, but got O
		//IL_0c77: Expected I, but got O
		//IL_0a4d->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_00d8->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_010a->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0a74->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_013e->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_015c->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0a9b->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0190->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0201->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0af0->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0235->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_025c->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_028b->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_02ce->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0342->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0b17->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0376->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_039d->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_03e0->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_042b->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0b3e->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_045f->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0486->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_04b5->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_04f8->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_056c->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0b65->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_05a0->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_05c7->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_060a->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0655->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0b8c->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0689->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_06b0->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_06df->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_0722->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_089c->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_08ca->IL09a3: Incompatible stack heights: 1 vs 0
		//IL_08f6->IL09a3: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		_activations = 0;
		List<Transform> list = new List<Transform>();
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
				_sources = list;
				_maxSources = list._size;
				if ((object)_TargetZone != null)
				{
					Material material = ((Renderer)_TargetZone).GetMaterial();
					if ((object)material != null)
					{
						bool flag = ((List<Transform>)(object)material)._items == null;
						float value = default(float);
						Material.SetColorImpl_Injected((IntPtr)((List<Transform>)(object)material)._items, ColorId, ref *(Color*)(&value));
						if ((object)_TargetZone != null)
						{
							Material material2 = ((Renderer)_TargetZone).GetMaterial();
							if ((object)material2 != null)
							{
								material2.SetFloatImpl(ThicknessId, _targetZoneStroke);
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
													float num = renderer2.height * 0.2f;
													float num2 = renderer.width * 0.2f;
													if (!(num > num2))
													{
														num2 = num;
													}
													_defaultRange = num2;
													BulletPool destructibleProjectilePool = new BulletPool(_destructibleProjectilePrefab);
													_destructibleProjectilePool = destructibleProjectilePool;
													if ((object)GM.Core != null)
													{
														PhaserScene s_scene3 = ArcadePhysics.s_scene;
														if (ArcadePhysics.s_scene != null)
														{
															ArcadePhysics physics = s_scene3.physics;
															if ((object)s_scene3.physics != null)
															{
																GameManager core = GM.Core;
																if ((object)GM.Core != null)
																{
																	PhysicsManager physicsManager = core._physicsManager;
																	if (core._physicsManager != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1831 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+3A0]");
																		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
																		nint num3 = (nint)this;
																		if (physics.add != null)
																		{
																			ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
																			CallbackContext callbackContext = default(CallbackContext);
																			Collider collider = physics.add.overlap(_destructibleProjectilePool, physicsManager._destructiblesGroup, collideCallback, arcadePhysicsCallback, callbackContext);
																			BulletPool bigProjectilePool = new BulletPool(_bigProjectilePrefab);
																			_bigProjectilePool = bigProjectilePool;
																			if ((object)GM.Core != null)
																			{
																				PhaserScene s_scene4 = ArcadePhysics.s_scene;
																				if (ArcadePhysics.s_scene != null)
																				{
																					ArcadePhysics physics2 = s_scene4.physics;
																					if ((object)s_scene4.physics != null)
																					{
																						GameManager core2 = GM.Core;
																						if ((object)GM.Core != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1925 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+5E0]");
																							ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
																							nint num4 = (nint)this;
																							if (physics2.add != null)
																							{
																								Collider collider2 = physics2.add.overlap(_bigProjectilePool, core2.Enemies, collideCallback2, arcadePhysicsCallback, callbackContext);
																								if ((object)GM.Core != null)
																								{
																									PhaserScene s_scene5 = ArcadePhysics.s_scene;
																									if (ArcadePhysics.s_scene != null)
																									{
																										ArcadePhysics physics3 = s_scene5.physics;
																										if ((object)s_scene5.physics != null)
																										{
																											GameManager core3 = GM.Core;
																											if ((object)GM.Core != null)
																											{
																												PhysicsManager physicsManager2 = core3._physicsManager;
																												if (core3._physicsManager != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1947 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+3A0]");
																													ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
																													nint num5 = (nint)this;
																													if (physics3.add != null)
																													{
																														Collider collider3 = physics3.add.overlap(_bigProjectilePool, physicsManager2._destructiblesGroup, collideCallback3, arcadePhysicsCallback, callbackContext);
																														BulletPool specialProjectilePool = new BulletPool(_specialProjectilePrefab);
																														_specialProjectilePool = specialProjectilePool;
																														if ((object)GM.Core != null)
																														{
																															PhaserScene s_scene6 = ArcadePhysics.s_scene;
																															if (ArcadePhysics.s_scene != null)
																															{
																																ArcadePhysics physics4 = s_scene6.physics;
																																if ((object)s_scene6.physics != null)
																																{
																																	GameManager core4 = GM.Core;
																																	if ((object)GM.Core != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2039 @ r8_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+5E0]");
																																		ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
																																		nint num6 = (nint)this;
																																		if (physics4.add != null)
																																		{
																																			Collider collider4 = physics4.add.overlap(_specialProjectilePool, core4.Enemies, collideCallback4, arcadePhysicsCallback, callbackContext);
																																			if ((object)GM.Core != null)
																																			{
																																				PhaserScene s_scene7 = ArcadePhysics.s_scene;
																																				if (ArcadePhysics.s_scene != null)
																																				{
																																					ArcadePhysics physics5 = s_scene7.physics;
																																					if ((object)s_scene7.physics != null)
																																					{
																																						GameManager core5 = GM.Core;
																																						if ((object)GM.Core != null)
																																						{
																																							PhysicsManager physicsManager3 = core5._physicsManager;
																																							if (core5._physicsManager != null)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2061 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+3A0]");
																																								ArcadePhysicsCallback collideCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
																																								nint num7 = (nint)this;
																																								if (physics5.add != null)
																																								{
																																									Collider collider5 = physics5.add.overlap(_specialProjectilePool, physicsManager3._destructiblesGroup, collideCallback5, arcadePhysicsCallback, callbackContext);
																																									if (specialProjectileEnabled)
																																									{
																																										if (!_hasLight)
																																										{
																																											CheckLightGlyphs();
																																										}
																																										if (!_hasDark)
																																										{
																																											CheckDarkGlyphs();
																																										}
																																										if (!_hasLight || !_hasDark)
																																										{
																																											if (glyphCheckTimer != null)
																																											{
																																												glyphCheckTimer.Cancel();
																																											}
																																											Action onComplete = CheckGlyphs;
																																											int repeat = default(int);
																																											TimerType type = default(TimerType);
																																											Timer timer = Timers.Register(10f, onComplete, null, isLooped: false, (byte)(int)arcadePhysicsCallback != 0, (MonoBehaviour)(object)callbackContext, repeat, type, isOnlineTimer: false, canPause: false);
																																											glyphCheckTimer = timer;
																																										}
																																									}
																																									if ((object)_emitter1 != null)
																																									{
																																										Transform transform2 = _emitter1.transform;
																																										if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
																																										{
																																											Transform transform3 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
																																											if ((object)transform3 != null)
																																											{
																																												bool flag2 = ((List<Transform>)(object)transform3)._items == null;
																																												Transform.get_position_Injected((IntPtr)((List<Transform>)(object)transform3)._items, out Vector3 ret);
																																												bool flag3 = (object)transform2 == null;
																																												bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																																												Vector3 value2 = default(Vector3);
																																												Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
																																												bool flag5 = (object)_emitter2 == null;
																																												Transform transform4 = _emitter2.transform;
																																												bool flag6 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
																																												Transform transform5 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
																																												bool flag7 = (object)transform5 == null;
																																												bool flag8 = ((List<Transform>)(object)transform5)._items == null;
																																												Transform.get_position_Injected((IntPtr)((List<Transform>)(object)transform5)._items, out ret);
																																												bool flag9 = (object)transform4 == null;
																																												bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																																												Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&value));
																																												ParticleSystem particleSystem = RenderingExtensions.SetScale(_emitter1, 1f);
																																												ParticleSystem particleSystem2 = RenderingExtensions.SetScale(_emitter2, 1f);
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected void CheckGlyphs()
	{
		if (!_hasLight)
		{
			CheckLightGlyphs();
		}
		if (!_hasDark)
		{
			CheckDarkGlyphs();
		}
		if (!_hasLight || !_hasDark)
		{
			if (glyphCheckTimer != null)
			{
				glyphCheckTimer.Cancel();
			}
			Action onComplete = CheckGlyphs;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(10f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			glyphCheckTimer = timer;
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
		Material material = ((Renderer)_TargetZone).GetMaterial();
		float num3 = base._003CTotalTime_003Ek__BackingField + 100f;
		float value = num3 / deltaTime;
		material.SetFloatImpl(AlphaId, value);
		float num4 = base.PArea();
		float num5 = _defaultRange + _defaultRange;
		float scale = num5 * deltaTime;
		Transform transform = RenderingExtensions.SetScale(_cachedTargetTransform, scale);
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public void SetSources(List<Transform> array)
	{
		//IL_0014: Expected F4, but got I4
		_sources = array;
		_maxSources = array._size;
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			float num = base.PSpeed();
			float num2 = default(float);
			bool flag = !(1f < num2);
			float num3 = 1f;
			if (!flag)
			{
				num3 = num2;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num3 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num2;
					return num2 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public float GetRange()
	{
		float num = base.PArea();
		object obj = default(object);
		return (float)obj * _defaultRange;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_00e0: Expected O, but got Ref
		//IL_0290: Expected I, but got O
		//IL_03b2: Expected O, but got I
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_0366: Expected O, but got F4
		//IL_0f2a: Expected O, but got F4
		//IL_06a5: Expected F4, but got I4
		//IL_06a5: Expected F4, but got I4
		//IL_06a5: Expected F4, but got O
		//IL_06a5: Expected O, but got I4
		//IL_06c9: Expected F4, but got I4
		//IL_07dd: Invalid comparison between F4 and I4
		//IL_0bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Expected O, but got Unknown
		//IL_0c08: Invalid comparison between O and F4
		//IL_0866: Invalid comparison between F4 and I4
		//IL_0fa3: Invalid comparison between F4 and I4
		//IL_090f: Expected O, but got I
		//IL_0b23: Expected O, but got F4
		//IL_0e20->IL0da6: Incompatible stack heights: 1 vs 0
		//IL_013c->IL0da6: Incompatible stack heights: 1 vs 0
		//IL_0d3e->IL0da6: Incompatible stack heights: 2 vs 0
		//IL_0d6a->IL0da6: Incompatible stack heights: 2 vs 0
		//IL_01c8->IL0da6: Incompatible stack heights: 3 vs 0
		//IL_021f->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0253->IL0d24: Incompatible stack heights: 4 vs 2
		//IL_0279->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0f13->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0ef4->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_02f0->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0536->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_048f->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_05ab->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_031e->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0562->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_04bd->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_034c->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_06f1->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_04eb->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_071d->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_075a->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0789->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_07ba->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0f7e->IL0fb7: Incompatible stack heights: 4 vs 2
		//IL_0fd9->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0c58->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0c6e->IL0fb7: Incompatible stack heights: 4 vs 2
		//IL_0844->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0c92->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_08a4->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_08d3->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_08f5->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0931->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0988->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_09c1->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_09fd->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0a2c->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0a4e->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0b05->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0b51->IL0da6: Incompatible stack heights: 4 vs 0
		//IL_0b73->IL0da6: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass41_0 obj = new _003C_003Ec__DisplayClass41_0();
		float num2;
		float num5;
		_003C_003Ec__DisplayClass41_1 obj5;
		int num7 = default(int);
		bool flag7;
		float num8 = default(float);
		float num10 = default(float);
		_003C_003Ec__DisplayClass41_0 obj11;
		float num9;
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			float num = base.PArea();
			object obj2 = default(object);
			num2 = (_range = (float)obj2 * _defaultRange) * 1.45f;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					if ((object)core._stage != null)
					{
						object obj3 = default(object);
						List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&obj3), excludeDead: true, num2);
						obj.closest = closestEnemiesSorted;
						Transform source = GetSource();
						obj.source = source;
						Transform source2 = obj.source;
						if ((object)obj.source != null)
						{
							bool flag2 = ((UnityEngine.Object)source2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)source2).m_CachedPtr, out *(Vector3*)(&ret));
							float chanceFromArray = base.GetChanceFromArray();
							bool flag3 = obj.closest == null;
							float num3 = (float)ret * 8f;
							float num4 = num3 * 0.01f;
							float x = num4 + (float)ret;
							obj.x = x;
							object obj4 = default(object);
							num5 = (obj.y = (float)obj4 + 0.24f);
							if (!flag3)
							{
								List<EnemyController> closest = obj.closest;
								if (closest._size > 0)
								{
									bool flag4 = closest._size <= 0;
									EnemyController[] items = closest._items;
									if (closest._items != null)
									{
										bool flag5 = items.Length <= 0;
										EnemyController enemyController = items[0];
										if ((object)items[0] != null)
										{
											num5 = _range * _range;
											if (num5 < enemyController.Distance)
											{
												goto IL_0d24;
											}
											obj5 = new _003C_003Ec__DisplayClass41_1();
											if (obj5 != null)
											{
												obj5.CS_0024_003C_003E8__locals1 = obj;
												nint num6 = (nint)this;
												bool flag6 = specialProjectileEnabled;
												if (flag6)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+5D0]");
													object obj6 = (nint)0 >> 31;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+5D0]");
													object obj7 = 0 + obj6;
													object obj8 = obj7 * 2;
													object obj9 = obj7 + obj8;
													object obj10 = _activations - obj9;
													if (!flag6)
													{
														if ((_hasLight ? 1 : 0) != (nint)obj10)
														{
															obj11 = (_003C_003Ec__DisplayClass41_0)(object)_specialProjectilePool;
															goto IL_0ef9;
														}
													}
													else if ((nint)obj10 == 1 && _hasDark)
													{
														obj11 = (_003C_003Ec__DisplayClass41_0)(object)_specialProjectilePool;
														if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
														{
															float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
															if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
															{
																float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
																if (_specialProjectilePool != null)
																{
																	num7 = 1;
																	goto IL_0f18;
																}
															}
														}
														goto IL_0da6;
													}
													obj11 = (_003C_003Ec__DisplayClass41_0)(object)_bigProjectilePool;
													goto IL_0ef9;
												}
												if (!bigProjectileEnabled)
												{
													flag7 = false;
													goto IL_0eda;
												}
												obj11 = (_003C_003Ec__DisplayClass41_0)(object)_bigProjectilePool;
												if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
												{
													float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
													if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
													{
														float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
														if (_bigProjectilePool != null)
														{
															Projectile projectile = _bigProjectilePool.SpawnAt((float2)num8, this);
															num9 = num10;
															num7 = 0;
															num5 = num8;
															flag7 = false;
															goto IL_0eda;
														}
													}
												}
											}
										}
									}
									goto IL_0da6;
								}
							}
							goto IL_0d24;
						}
					}
				}
			}
		}
		goto IL_0da6;
		IL_0bcf:
		float num11 = base.PInterval();
		float num12 = _lastFiringInterval - num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj12 = num12 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num13 = base.PInterval();
			_lastFiringInterval = num5;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
				return;
			}
			goto IL_0da6;
		}
		return;
		IL_0eda:
		if ((object)_TargetZone != null)
		{
			GameObject gameObject = _TargetZone.gameObject;
			if ((object)gameObject != null)
			{
				bool activeSelf = gameObject.activeSelf;
				bool flag8 = !activeSelf;
				bool flag9 = (byte)num7 != 0;
				float num14 = num2;
				bool flag10 = default(bool);
				MonoBehaviour monoBehaviour = default(MonoBehaviour);
				int num15 = default(int);
				TimerType timerType = default(TimerType);
				if (!flag8)
				{
					RenderingExtensions.Start(_emitter1);
					RenderingExtensions.Start(_emitter2);
					obj11 = obj5.CS_0024_003C_003E8__locals1;
					Action onComplete = delegate
					{
						TP_Confodere1_Weapon tP_Confodere1_Weapon = obj5.CS_0024_003C_003E8__locals1._003C_003E4__this;
						RenderingExtensions.StopEmitting(tP_Confodere1_Weapon._emitter1);
						TP_Confodere1_Weapon tP_Confodere1_Weapon2 = obj5.CS_0024_003C_003E8__locals1._003C_003E4__this;
						RenderingExtensions.StopEmitting(tP_Confodere1_Weapon2._emitter2);
					};
					Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, flag10, monoBehaviour, num15, timerType, isOnlineTimer: false, flag7);
					float value = UnityEngine.Random.value;
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Victory2, 200f, 10, 0f, (float?)(object)flag10, (float)monoBehaviour, num15, (byte)timerType != 0, 1f);
					num9 = 200f;
					flag9 = false;
					num14 = 0f;
					num5 = 1.2f;
				}
				if ((object)_TargetZone != null)
				{
					GameObject gameObject2 = _TargetZone.gameObject;
					if ((object)gameObject2 != null)
					{
						gameObject2.SetActive(value: false);
						_003C_003Ec__DisplayClass41_0 obj13 = obj5.CS_0024_003C_003E8__locals1;
						if (obj5.CS_0024_003C_003E8__locals1 != null)
						{
							List<EnemyController> closest2 = obj13.closest;
							if (obj13.closest != null)
							{
								obj5.enemiesCount = closest2._size;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									((Equipment)this)._003COwner_003Ek__BackingField.OnMeleeAttackAnim();
									float num16 = base.PAmount();
									if (!(num5 > 0f))
									{
										goto IL_0bcf;
									}
									bool flag11 = flag7;
									Component component = default(Component);
									while (true)
									{
										_003C_003Ec__DisplayClass41_2 CS_0024_003C_003E8__locals36 = new _003C_003Ec__DisplayClass41_2();
										if (CS_0024_003C_003E8__locals36 == null)
										{
											break;
										}
										CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 = obj5;
										CS_0024_003C_003E8__locals36.localIndex = (flag11 ? 1 : 0);
										WeaponData currentWeaponData = _currentWeaponData;
										if (_currentWeaponData == null)
										{
											break;
										}
										num5 = (float)(flag11 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
										if (!(num5 > 0f))
										{
											_003C_003Ec__DisplayClass41_1 obj14 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
											if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 == null)
											{
												break;
											}
											_003C_003Ec__DisplayClass41_0 obj15 = obj14.CS_0024_003C_003E8__locals1;
											if (obj14.CS_0024_003C_003E8__locals1 == null || obj15.closest == null)
											{
												break;
											}
											bool num17 = flag11;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v89 (VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon+<>c__DisplayClass41_1)+10]");
											object obj16 = (nint)(num17 ? 1 : 0) % (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											if ((object)component == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v92 (UnityEngine.Component)+260]");
											if ((nint)0 == 0)
											{
												_003C_003Ec__DisplayClass41_1 obj17 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
												if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 == null)
												{
													break;
												}
												_003C_003Ec__DisplayClass41_0 obj18 = obj17.CS_0024_003C_003E8__locals1;
												Transform source3 = GetSource();
												if (obj17.CS_0024_003C_003E8__locals1 == null)
												{
													break;
												}
												obj18.source = source3;
												_003C_003Ec__DisplayClass41_1 obj19 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
												if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 == null)
												{
													break;
												}
												_003C_003Ec__DisplayClass41_0 obj20 = obj19.CS_0024_003C_003E8__locals1;
												if (obj19.CS_0024_003C_003E8__locals1 == null || (object)obj20.source == null)
												{
													break;
												}
												Vector3 position5 = obj20.source.position;
												float chanceFromArray2 = base.GetChanceFromArray();
												float num18 = num5 * 8f;
												float num19 = num18 * 0.01f;
												float x2 = num19 + position5.x;
												obj20.x = x2;
												Transform targetTransform = component.transform;
												_targetTransform = targetTransform;
												float2 position6 = ((ArcadeSprite)component).position;
												float2 position7 = ((ArcadeSprite)component).position;
												if (_destructibleProjectilePool == null)
												{
													break;
												}
												Projectile projectile2 = _destructibleProjectilePool.SpawnAt((float2)num8, this, CS_0024_003C_003E8__locals36.localIndex);
												_003C_003Ec__DisplayClass41_1 obj21 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
												if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 == null || obj21.CS_0024_003C_003E8__locals1 == null)
												{
													break;
												}
												_003C_003Ec__DisplayClass41_1 obj22 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
												flag9 = (byte)CS_0024_003C_003E8__locals36.localIndex != 0;
												_003C_003Ec__DisplayClass41_0 obj23 = obj22.CS_0024_003C_003E8__locals1;
												num9 = obj23.y;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
												base.DealDamage((IDamageable)component);
												num5 = num8;
											}
											flag7 = false;
										}
										else
										{
											WeaponData currentWeaponData2 = _currentWeaponData;
											if (_currentWeaponData == null)
											{
												break;
											}
											Action onComplete2 = delegate
											{
												//IL_0718: Expected I, but got O
												//IL_00c1->IL0680: Incompatible stack heights: 1 vs 0
												//IL_017a->IL0680: Incompatible stack heights: 1 vs 0
												//IL_01a9->IL0680: Incompatible stack heights: 1 vs 0
												//IL_01cb->IL0680: Incompatible stack heights: 1 vs 0
												//IL_0218->IL0680: Incompatible stack heights: 1 vs 0
												//IL_0247->IL0680: Incompatible stack heights: 1 vs 0
												//IL_0276->IL0680: Incompatible stack heights: 1 vs 0
												//IL_073c->IL0680: Incompatible stack heights: 2 vs 0
												//IL_02af->IL0680: Incompatible stack heights: 2 vs 0
												//IL_02d1->IL0680: Incompatible stack heights: 2 vs 0
												//IL_0348->IL0680: Incompatible stack heights: 2 vs 0
												//IL_0377->IL0680: Incompatible stack heights: 2 vs 0
												//IL_03bc->IL0680: Incompatible stack heights: 2 vs 0
												//IL_03ef->IL0680: Incompatible stack heights: 2 vs 0
												//IL_041e->IL0680: Incompatible stack heights: 2 vs 0
												//IL_044d->IL0680: Incompatible stack heights: 2 vs 0
												//IL_04a7->IL0680: Incompatible stack heights: 2 vs 0
												//IL_04d6->IL0680: Incompatible stack heights: 2 vs 0
												//IL_04f8->IL0680: Incompatible stack heights: 2 vs 0
												//IL_0546->IL0680: Incompatible stack heights: 2 vs 0
												//IL_0575->IL0680: Incompatible stack heights: 2 vs 0
												//IL_05bb->IL0680: Incompatible stack heights: 2 vs 0
												//IL_060a->IL0680: Incompatible stack heights: 2 vs 0
												//IL_0639->IL0680: Incompatible stack heights: 2 vs 0
												//IL_065b->IL0680: Incompatible stack heights: 2 vs 0
												//IL_0680->IL06e7: Incompatible stack heights: 2 vs 1
												_003C_003Ec__DisplayClass41_1 obj24 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
												if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
												{
													_003C_003Ec__DisplayClass41_0 obj25 = obj24.CS_0024_003C_003E8__locals1;
													if (obj24.CS_0024_003C_003E8__locals1 != null)
													{
														List<EnemyController> closest3 = obj25.closest;
														if (obj25.closest != null)
														{
															int num24 = CS_0024_003C_003E8__locals36.localIndex % obj24.enemiesCount;
															bool flag12 = num24 >= closest3._size;
															EnemyController[] items2 = closest3._items;
															if (closest3._items != null)
															{
																if (num24 >= items2.Length)
																{
																	throw new IndexOutOfRangeException();
																}
																Component component2 = items2[num24];
																if ((object)items2[num24] == null || ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0)
																{
																	return;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v7 (UnityEngine.Component)+260]");
																if ((nint)0 != 0)
																{
																	return;
																}
																_003C_003Ec__DisplayClass41_1 obj26 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																{
																	BulletPool bulletPool = (BulletPool)(object)obj26.CS_0024_003C_003E8__locals1;
																	if (obj26.CS_0024_003C_003E8__locals1 != null && ((EventEmitter)bulletPool).callbacks != null)
																	{
																		Transform source4 = ((TP_Confodere1_Weapon)(object)((EventEmitter)bulletPool).callbacks).GetSource();
																		((Group)bulletPool).childrenToRemove = (HashSet<PhaserGameObject>)(object)source4;
																		_003C_003Ec__DisplayClass41_1 obj27 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																		if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																		{
																			_003C_003Ec__DisplayClass41_0 obj28 = obj27.CS_0024_003C_003E8__locals1;
																			if (obj27.CS_0024_003C_003E8__locals1 != null)
																			{
																				BulletPool source5 = (BulletPool)(object)obj28.source;
																				if ((object)obj28.source != null)
																				{
																					bool flag13 = ((EventEmitter)source5).callbacks == null;
																					Transform.get_position_Injected((IntPtr)((EventEmitter)source5).callbacks, out Vector3 ret2);
																					_003C_003Ec__DisplayClass41_1 obj29 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																					if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																					{
																						_003C_003Ec__DisplayClass41_0 obj30 = obj29.CS_0024_003C_003E8__locals1;
																						if (obj29.CS_0024_003C_003E8__locals1 != null && (object)obj30._003C_003E4__this != null)
																						{
																							float chanceFromArray3 = obj30._003C_003E4__this.GetChanceFromArray();
																							object obj31 = default(object);
																							float num25 = (float)obj31 * 8f;
																							float num26 = num25 * 0.01f;
																							float x3 = num26 + (float)ret2;
																							obj28.x = x3;
																							BulletPool bulletPool2 = (BulletPool)(object)CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																							if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																							{
																								BulletPool children = (BulletPool)(object)((Group)bulletPool2).children;
																								if (((Group)bulletPool2).children != null)
																								{
																									BulletPool callbacks = (BulletPool)(object)((EventEmitter)children).callbacks;
																									Transform transform2 = items2[num24].transform;
																									if (((EventEmitter)children).callbacks != null)
																									{
																										_003C_003Ec__DisplayClass41_1 obj32 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																										if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																										{
																											_003C_003Ec__DisplayClass41_0 obj33 = obj32.CS_0024_003C_003E8__locals1;
																											if (obj32.CS_0024_003C_003E8__locals1 != null)
																											{
																												TP_Confodere1_Weapon tP_Confodere1_Weapon = obj33._003C_003E4__this;
																												if ((object)obj33._003C_003E4__this != null)
																												{
																													float2 position10 = items2[num24].position;
																													float2 position11 = items2[num24].position;
																													_003C_003Ec__DisplayClass41_1 obj34 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																													if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																													{
																														_003C_003Ec__DisplayClass41_0 obj35 = obj34.CS_0024_003C_003E8__locals1;
																														if (obj34.CS_0024_003C_003E8__locals1 != null && tP_Confodere1_Weapon._destructibleProjectilePool != null)
																														{
																															float2 pos = default(float2);
																															Projectile projectile4 = tP_Confodere1_Weapon._destructibleProjectilePool.SpawnAt(pos, obj35._003C_003E4__this, CS_0024_003C_003E8__locals36.localIndex);
																															_003C_003Ec__DisplayClass41_1 obj36 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																															if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																															{
																																_003C_003Ec__DisplayClass41_0 obj37 = obj36.CS_0024_003C_003E8__locals1;
																																if (obj36.CS_0024_003C_003E8__locals1 != null)
																																{
																																	_003C_003Ec__DisplayClass41_1 obj38 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																																	_003C_003Ec__DisplayClass41_0 obj39 = obj38.CS_0024_003C_003E8__locals1;
																																	TP_Confodere1_Weapon tP_Confodere1_Weapon2 = obj39._003C_003E4__this;
																																	if ((object)obj39._003C_003E4__this != null)
																																	{
																																		Projectile projectile5 = obj37._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals36.localIndex, tP_Confodere1_Weapon2._targetTransform);
																																		_003C_003Ec__DisplayClass41_1 obj40 = CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2;
																																		if (CS_0024_003C_003E8__locals36.CS_0024_003C_003E8__locals2 != null)
																																		{
																																			_003C_003Ec__DisplayClass41_0 obj41 = obj40.CS_0024_003C_003E8__locals1;
																																			if (obj40.CS_0024_003C_003E8__locals1 != null && (object)obj41._003C_003E4__this != null)
																																			{
																																				obj41._003C_003E4__this.DealDamage(items2[num24]);
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
												throw new NullReferenceException();
											};
											float num20 = (float)(flag11 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
											num5 = num20 * 0.001f;
											Timer lastShotTimer = Timers.Register(num5, onComplete2, null, isLooped: false, flag10, monoBehaviour, num15, timerType, isOnlineTimer: false, flag7);
											_lastShotTimer = lastShotTimer;
											flag9 = false;
										}
										flag11 = (byte)((flag11 ? 1u : 0u) + 1u) != 0;
										float num21 = base.PAmount();
										if (num5 > (float)(flag11 ? 1 : 0))
										{
											continue;
										}
										goto IL_0bcf;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0da6;
		IL_0f18:
		Projectile projectile3 = ((BulletPool)(object)obj11).SpawnAt((float2)num8, (Weapon)this, num7);
		int activations = _activations + 1;
		_activations = activations;
		num9 = num10;
		num5 = num8;
		flag7 = false;
		goto IL_0eda;
		IL_0ef9:
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position8 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position9 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if (obj11 != null)
				{
					num7 = 0;
					goto IL_0f18;
				}
			}
		}
		goto IL_0da6;
		IL_0d24:
		if ((object)_TargetZone != null)
		{
			GameObject gameObject3 = _TargetZone.gameObject;
			if ((object)gameObject3 != null)
			{
				gameObject3.SetActive(value: true);
				float num22 = base.PInterval();
				float num23 = num5 - 100f;
				base._003CTotalTime_003Ek__BackingField = num23;
				return;
			}
		}
		goto IL_0da6;
		IL_0da6:
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0018: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		_isVisible = visible;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (!flag)
		{
			Projectile[] items;
			do
			{
				List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
				if ((nint)obj < spawnedProjectiles2._size)
				{
					items = spawnedProjectiles2._items;
					items[obj].Despawn();
					obj--;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)items[obj] >= 0);
		}
		_TargetZone.enabled = visible;
	}

	private Transform GetSource()
	{
		List<Transform> sources = _sources;
		if (++_sourceIndex >= sources._size)
		{
			_sourceIndex = 0;
		}
		int sourceIndex = _sourceIndex;
		if (_sourceIndex < sources._size)
		{
			Transform[] items = sources._items;
			return items[sourceIndex];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Transform result = default(Transform);
		return result;
	}

	public override void Cleanup()
	{
		RenderingExtensions.StopEmitting(_emitter1);
		RenderingExtensions.StopEmitting(_emitter2);
		_destructibleProjectilePool.Cleanup();
		_bigProjectilePool.Cleanup();
		_specialProjectilePool.Cleanup();
		if (glyphCheckTimer != null)
		{
			glyphCheckTimer.Cancel();
		}
		base.Cleanup();
	}

	protected virtual bool OnBigBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_00e8: Expected O, but got I
		//IL_0149: Invalid comparison between F4 and I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				List<float> critChancesArray = _critChancesArray;
				int critIndex = _critIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
				int num = (int)((nint)critIndex % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)num >= (nint)0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					bool result = default(bool);
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v12 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				int critIndex2 = _critIndex + 1;
				_critIndex = critIndex2;
				WeaponData currentWeaponData = _currentWeaponData;
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
				object obj2 = default(object);
				float num3 = (float)obj2 * currentWeaponData._003CcritChance_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v13+20+v79 @ rdx_v11 (System.Int32)*4]");
				float num5;
				if (num3 > 0f)
				{
					WeaponData currentWeaponData2 = _currentWeaponData;
					float num4 = currentWeaponData2._003CcritMul_003Ek__BackingField + currentWeaponData2._003CcritMul_003Ek__BackingField;
					num5 = num4 * ArcanaManager.CritMul;
				}
				else
				{
					num5 = 1f;
				}
				float num6 = PPower();
				float damage = num3 * num5;
				base.DealDamage(component, damage);
			}
		}
		return false;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	public void CheckLightGlyphs()
	{
		//IL_0025: Expected O, but got I4
		_hasLight = false;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public void CheckDarkGlyphs()
	{
		//IL_0025: Expected O, but got I4
		_hasDark = false;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0c89: Expected O, but got I4
		//IL_0cb0: Expected O, but got I4
		//IL_0cd7: Expected O, but got I4
		//IL_0cf0: Expected O, but got Ref
		//IL_0d0a: Expected native int or pointer, but got O
		//IL_0d24: Expected O, but got I
		//IL_0d44: Expected O, but got Ref
		//IL_0d6c: Expected native int or pointer, but got O
		//IL_0d86: Expected O, but got I
		//IL_0da6: Expected O, but got Ref
		//IL_0dc0: Expected native int or pointer, but got O
		//IL_12f5: Expected O, but got I4
		//IL_0dd8: Expected O, but got Ref
		//IL_0e00: Expected native int or pointer, but got O
		//IL_1312: Expected O, but got I4
		//IL_0e4b: Expected O, but got I
		//IL_135e: Expected O, but got I
		//IL_0f45: Expected O, but got I4
		//IL_0f6c: Expected O, but got I4
		//IL_0f93: Expected O, but got I4
		//IL_0fa7: Expected O, but got Ref
		//IL_0fc1: Expected native int or pointer, but got O
		//IL_0fe0: Expected O, but got I
		//IL_0ffb: Expected O, but got Ref
		//IL_1023: Expected native int or pointer, but got O
		//IL_1042: Expected O, but got I
		//IL_105d: Expected O, but got Ref
		//IL_1077: Expected native int or pointer, but got O
		//IL_10bc: Expected O, but got I
		//IL_10e9: Expected O, but got Ref
		//IL_1111: Expected native int or pointer, but got O
		//IL_1156: Expected O, but got I
		//IL_118f: Expected O, but got I
		//IL_1238: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 60f;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0000");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0001");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0002");
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
			((List<object>)(object)list).AddWithResize((object)"leaf0003");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0004");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0005");
		}
		else
		{
			int size6 = list._size + 1;
			list._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0006");
		}
		else
		{
			int size7 = list._size + 1;
			list._size = size7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0007");
		}
		else
		{
			int size8 = list._size + 1;
			list._size = size8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0008");
		}
		else
		{
			int size9 = list._size + 1;
			list._size = size9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0009");
		}
		else
		{
			int size10 = list._size + 1;
			list._size = size10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0010");
		}
		else
		{
			int size11 = list._size + 1;
			list._size = size11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list._version + 1;
		list._version = version12;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0011");
		}
		else
		{
			int size12 = list._size + 1;
			list._size = size12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version13 = list._version + 1;
		list._version = version13;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0012");
		}
		else
		{
			int size13 = list._size + 1;
			list._size = size13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version14 = list._version + 1;
		list._version = version14;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0013");
		}
		else
		{
			int size14 = list._size + 1;
			list._size = size14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version15 = list._version + 1;
		list._version = version15;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0014");
		}
		else
		{
			int size15 = list._size + 1;
			list._size = size15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version16 = list._version + 1;
		list._version = version16;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0015");
		}
		else
		{
			int size16 = list._size + 1;
			list._size = size16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version17 = list._version + 1;
		list._version = version17;
		string[] items17 = list._items;
		if (list._size >= items17.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0016");
		}
		else
		{
			int size17 = list._size + 1;
			list._size = size17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version18 = list._version + 1;
		list._version = version18;
		string[] items18 = list._items;
		if (list._size >= items18.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0017");
		}
		else
		{
			int size18 = list._size + 1;
			list._size = size18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version19 = list._version + 1;
		list._version = version19;
		string[] items19 = list._items;
		if (list._size >= items19.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0018");
		}
		else
		{
			int size19 = list._size + 1;
			list._size = size19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version20 = list._version + 1;
		list._version = version20;
		string[] items20 = list._items;
		if (list._size >= items20.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"leaf0019");
		}
		else
		{
			int size20 = list._size + 1;
			list._size = size20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		ParticleEmitterManager pfxManager = _pfxManager;
		if ((object)_pfxManager == null || ((UnityEngine.Object)pfxManager).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager2 = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager2;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			particleSystemConfig._angleSteps = 30;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			particleSystemConfig._alphaEase = Easing.OutExpo;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(350f, 450f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
			_ = 0;
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
			particleSystemConfig._quantity = (int?)(object)0;
			particleSystemConfig._tintRandom = new uint[3] { 16733268u, 16733316u, 15614787u };
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
			_ = 0;
			particleSystemConfig._on = true;
			ParticleSystem emitter = _pfxManager.CreateEmitter(particleSystemConfig);
			_emitter1 = emitter;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			particleSystemConfig2._frame = list;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(90f, 450f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			particleSystemConfig2._angleSteps = 30;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			particleSystemConfig2._alphaEase = Easing.OutExpo;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(150f, 250f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
			_ = 0;
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
			particleSystemConfig2._quantity = (int?)(object)0;
			particleSystemConfig2._tintRandom = new uint[3] { 16733268u, 16733316u, 15614787u };
			EmitZone emitZone2 = new EmitZone();
			emitZone2._type = EmitZoneType.Random;
			emitZone2._source = circle;
			particleSystemConfig2._emitZone = emitZone2;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig2._on = true;
			ParticleSystem emitter2 = _pfxManager.CreateEmitter(particleSystemConfig2);
			_emitter2 = emitter2;
		}
	}

	public TP_Confodere1_Weapon()
	{
		//IL_0a17: Expected O, but got I
		//IL_0037: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_0a7b: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0aa3: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_0acb: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_0af3: Expected O, but got I
		//IL_0239: Expected O, but got I
		//IL_0b1b: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_0b43: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_0b6b: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_0b93: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_0bbb: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_0be3: Expected O, but got I
		//IL_04b5: Expected O, but got I
		//IL_0c0b: Expected O, but got I
		//IL_051f: Expected O, but got I
		//IL_0566: Expected O, but got I
		//IL_05c0: Expected O, but got I
		//IL_0c42: Expected O, but got I
		//IL_062a: Expected O, but got I
		//IL_0c6a: Expected O, but got I
		//IL_0694: Expected O, but got I
		//IL_0c92: Expected O, but got I
		//IL_06fe: Expected O, but got I
		//IL_0cba: Expected O, but got I
		//IL_0768: Expected O, but got I
		//IL_0ce2: Expected O, but got I
		//IL_07d2: Expected O, but got I
		//IL_0d0a: Expected O, but got I
		//IL_083c: Expected O, but got I
		//IL_0d32: Expected O, but got I
		//IL_08a6: Expected O, but got I
		//IL_0d5a: Expected O, but got I
		//IL_0910: Expected O, but got I
		//IL_0d82: Expected O, but got I
		//IL_097a: Expected O, but got I
		//IL_0daa: Expected O, but got I
		//IL_09e4: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12200]");
		_targetZoneCol = (Color)0;
		_maxSources = 1f;
		_targetZoneStroke = 0.01f;
		_FireAngles = new int[6] { -60, 50, -40, 30, -20, 10 };
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v7+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1427);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1427;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v9+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1428);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1428;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v11+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1496);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1496;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v13+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1452);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1452;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v15+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1453);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1453;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v17+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1471);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1471;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v19+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1472);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1472;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v21+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1437);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1437;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdx_v23+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1438);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1438;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v25+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1439);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1439;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdx_v27+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1440);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1440;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v29+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1618);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1618;
		}
		lightGlyphs = list;
		List<WeaponType> list2 = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v33+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1429);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1429;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v35+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1430);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1430;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v32+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1496);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1496;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v38+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1473);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1473;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v40+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1474);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 1474;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v38+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1471);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 1471;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ r8_v40+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1472);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 1472;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v44+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1497);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 1497;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v46+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1498);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 1498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v48+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1499);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 1499;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v50+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 1500;
		}
		darkGlyphs = list2;
		base._002Ector();
	}

	static TP_Confodere1_Weapon()
	{
		int alphaId = Shader.PropertyToID("_Alpha");
		AlphaId = alphaId;
		int colorId = Shader.PropertyToID("_Color");
		ColorId = colorId;
		int thicknessId = Shader.PropertyToID("_Thickness");
		ThicknessId = thicknessId;
	}
}
