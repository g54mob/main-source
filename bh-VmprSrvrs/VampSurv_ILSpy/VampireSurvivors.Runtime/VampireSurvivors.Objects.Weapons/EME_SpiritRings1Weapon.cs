using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_SpiritRings1Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public EME_SpiritRings1Weapon _003C_003E4__this;

		public BulletPool spellPool;
	}

	private sealed class _003C_003Ec__DisplayClass38_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireSpell_003Eb__0()
		{
			//IL_01bc: Expected O, but got I4
			//IL_0112: Expected O, but got I
			//IL_0176: Expected I, but got O
			//IL_00a8->IL0185: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0185: Incompatible stack heights: 1 vs 0
			//IL_00fc->IL0185: Incompatible stack heights: 1 vs 0
			//IL_013a->IL0185: Incompatible stack heights: 1 vs 0
			//IL_0169->IL0185: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass38_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass38_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						GameObject gameObject2 = (GameObject)(object)obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdi_v7 (UnityEngine.GameObject)+58]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdi_v7 (UnityEngine.GameObject)+58]");
								float2 position = ((ArcadeSprite)0).position;
								_003C_003Ec__DisplayClass38_0 obj4 = CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals1 != null)
								{
									EME_SpiritRings1Weapon eME_SpiritRings1Weapon = obj4._003C_003E4__this;
									if ((object)obj4._003C_003E4__this != null)
									{
										nint num = (nint)gameObject2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
										return;
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

	protected Projectile _SunlightPrefab;

	protected Projectile _AquaSpherePrefab;

	protected Projectile _HeavensThunderPrefab;

	protected Projectile _HyperGravityPrefab;

	protected Projectile _VermillionSandsPrefab;

	protected Projectile _ChaosDisasterPrefab;

	private int _sunlightPoolCount = 50;

	private int _aquaSpherePoolCount = 10;

	private int _heavensThunderPoolCount = 50;

	private int _hyperGravityPoolCount = 1;

	private int _vermillionSandsPoolCount = 1;

	private int _chaosDisasterPoolCount = 1;

	private BulletPool _sunlightPool;

	private BulletPool _aquaSpherePool;

	private BulletPool _heavensThunderPool;

	private BulletPool _hyperGravityPool;

	private BulletPool _vermillionSandsPool;

	private BulletPool _chaosDisasterPool;

	private BulletPool _fireExplosionPool;

	protected const float IntervalMul_Water = 3f;

	protected const float IntervalMul_WoodA = 5f;

	protected const float IntervalMul_Earth = 7f;

	protected const float IntervalMul_Metal = 11f;

	protected const float IntervalMul_Chaos = 13f;

	protected float _elapsed_Firee;

	protected float _elapsed_Water;

	protected float _elapsed_Earth;

	protected float _elapsed_WoodA;

	protected float _elapsed_Metal;

	protected float _elapsed_Chaos;

	private readonly Dictionary<WeaponType, string> _glimmerNames;

	protected virtual bool IsEvolved => false;

	protected override void OnStart()
	{
		//IL_0126: Expected I, but got O
		//IL_01c9: Expected I, but got O
		//IL_02f2: Expected I, but got O
		//IL_041b: Expected I, but got O
		//IL_04ac: Expected I, but got O
		//IL_054f: Expected I, but got O
		//IL_0678: Expected I, but got O
		//IL_0709: Expected I, but got O
		//IL_07ac: Expected I, but got O
		base.OnStart();
		BulletPool sunlightPool = new BulletPool(_SunlightPrefab, _sunlightPoolCount);
		_sunlightPool = sunlightPool;
		BulletPool aquaSpherePool = new BulletPool(_AquaSpherePrefab, _aquaSpherePoolCount);
		_aquaSpherePool = aquaSpherePool;
		BulletPool heavensThunderPool = new BulletPool(_HeavensThunderPrefab, _heavensThunderPoolCount);
		_heavensThunderPool = heavensThunderPool;
		BulletPool hyperGravityPool = new BulletPool(_HyperGravityPrefab, _hyperGravityPoolCount);
		_hyperGravityPool = hyperGravityPool;
		BulletPool vermillionSandsPool = new BulletPool(_VermillionSandsPrefab, _vermillionSandsPoolCount);
		_vermillionSandsPool = vermillionSandsPool;
		BulletPool chaosDisasterPool = new BulletPool(_ChaosDisasterPrefab, _chaosDisasterPoolCount);
		_chaosDisasterPool = chaosDisasterPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1538 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_sunlightPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1562 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_sunlightPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemyDamagex15;
				Collider collider3 = physics3.add.overlap(_aquaSpherePool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					PhysicsManager physicsManager2 = core4._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1605 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					Collider collider4 = physics4.add.overlap(_aquaSpherePool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene5 = ArcadePhysics.s_scene;
						ArcadePhysics physics5 = s_scene5.physics;
						GameManager core5 = GM.Core;
						ArcadePhysicsCallback collideCallback5 = OnBulletOverlapsEnemyDamagex3;
						Collider collider5 = physics5.add.overlap(_heavensThunderPool, core5.Enemies, collideCallback5, processCallback, callbackContext);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene6 = ArcadePhysics.s_scene;
							ArcadePhysics physics6 = s_scene6.physics;
							GameManager core6 = GM.Core;
							PhysicsManager physicsManager3 = core6._physicsManager;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1648 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
							ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num4 = (nint)this;
							Collider collider6 = physics6.add.overlap(_heavensThunderPool, physicsManager3._destructiblesGroup, collideCallback6, processCallback, callbackContext);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene7 = ArcadePhysics.s_scene;
								ArcadePhysics physics7 = s_scene7.physics;
								GameManager core7 = GM.Core;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1670 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+350]");
								ArcadePhysicsCallback collideCallback7 = new ArcadePhysicsCallback(this, (IntPtr)0);
								nint num5 = (nint)this;
								Collider collider7 = physics7.add.overlap(_hyperGravityPool, core7.Enemies, collideCallback7, processCallback, callbackContext);
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene8 = ArcadePhysics.s_scene;
									ArcadePhysics physics8 = s_scene8.physics;
									GameManager core8 = GM.Core;
									PhysicsManager physicsManager4 = core8._physicsManager;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1692 @ r8_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
									ArcadePhysicsCallback collideCallback8 = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num6 = (nint)this;
									Collider collider8 = physics8.add.overlap(_hyperGravityPool, physicsManager4._destructiblesGroup, collideCallback8, processCallback, callbackContext);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene9 = ArcadePhysics.s_scene;
										ArcadePhysics physics9 = s_scene9.physics;
										GameManager core9 = GM.Core;
										ArcadePhysicsCallback collideCallback9 = OnBulletOverlapsEnemyDamagex2;
										Collider collider9 = physics9.add.overlap(_vermillionSandsPool, core9.Enemies, collideCallback9, processCallback, callbackContext);
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene10 = ArcadePhysics.s_scene;
											ArcadePhysics physics10 = s_scene10.physics;
											GameManager core10 = GM.Core;
											PhysicsManager physicsManager5 = core10._physicsManager;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1735 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
											ArcadePhysicsCallback collideCallback10 = new ArcadePhysicsCallback(this, (IntPtr)0);
											nint num7 = (nint)this;
											Collider collider10 = physics10.add.overlap(_vermillionSandsPool, physicsManager5._destructiblesGroup, collideCallback10, processCallback, callbackContext);
											if ((object)GM.Core != null)
											{
												PhaserScene s_scene11 = ArcadePhysics.s_scene;
												ArcadePhysics physics11 = s_scene11.physics;
												GameManager core11 = GM.Core;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1757 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+350]");
												ArcadePhysicsCallback collideCallback11 = new ArcadePhysicsCallback(this, (IntPtr)0);
												nint num8 = (nint)this;
												Collider collider11 = physics11.add.overlap(_chaosDisasterPool, core11.Enemies, collideCallback11, processCallback, callbackContext);
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene12 = ArcadePhysics.s_scene;
													ArcadePhysics physics12 = s_scene12.physics;
													GameManager core12 = GM.Core;
													PhysicsManager physicsManager6 = core12._physicsManager;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1779 @ r8_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
													ArcadePhysicsCallback collideCallback12 = new ArcadePhysicsCallback(this, (IntPtr)0);
													nint num9 = (nint)this;
													Collider collider12 = physics12.add.overlap(_chaosDisasterPool, physicsManager6._destructiblesGroup, collideCallback12, processCallback, callbackContext);
													AddGlimmerName(WeaponType.EME_MAGIC_TECH_01);
													AddGlimmerName(WeaponType.EME_MAGIC_TECH_02);
													AddGlimmerName(WeaponType.EME_MAGIC_TECH_03);
													AddGlimmerName(WeaponType.EME_MAGIC_TECH_04);
													AddGlimmerName(WeaponType.EME_MAGIC_TECH_05);
													Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1685 Invalid \"Jump target not found in method: 0x1874D1240\"");
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

	private unsafe void AddGlimmerName(WeaponType glimmerWeaponType)
	{
		//IL_005c: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)glimmerWeaponType, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	private unsafe string GetGlimmerName(WeaponType weaponType)
	{
		//IL_0033: Expected I4, but got O
		//IL_0058: Expected O, but got Ref
		if (_glimmerNames != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)weaponType, out object value))
			{
				object obj = default(object);
				object arg = (WeaponType)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
				GameObject context = base.gameObject;
				Debug.LogWarning(message, context);
				return "Glimmer WeaponType not set";
			}
			return (string)value;
		}
		return (string)(object)new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0082: Invalid comparison between O and F4
		float num = base.PInterval();
		float num2 = default(float);
		_elapsed_Firee = num2;
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = num2;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void FireSpell(BulletPool spellPool, bool skipTriggers = false)
	{
		//IL_0050: Invalid comparison between O and F4
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01ee: Invalid comparison between O and F4
		//IL_0219: Expected F4, but got O
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_01a7: Expected O, but got I4
		_003C_003Ec__DisplayClass38_0 obj = new _003C_003Ec__DisplayClass38_0();
		obj._003C_003E4__this = this;
		BulletPool spellPool2 = default(BulletPool);
		obj.spellPool = spellPool2;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		Vector2 vector2 = vector;
		if (!flag)
		{
			bool flag2 = true;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag3;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj2 = flag2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj2 <= 0)
				{
					Vector2 playerPos = base.PlayerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass38_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass38_1();
					CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals8.localIndex = (flag2 ? 1 : 0);
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_01bc: Expected O, but got I4
						//IL_0112: Expected O, but got I
						//IL_0176: Expected I, but got O
						//IL_00a8->IL0185: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL0185: Incompatible stack heights: 1 vs 0
						//IL_00fc->IL0185: Incompatible stack heights: 1 vs 0
						//IL_013a->IL0185: Incompatible stack heights: 1 vs 0
						//IL_0169->IL0185: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass38_0 obj4 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
						{
							GameObject gameObject = obj4._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj5 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass38_0 obj6 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
								{
									GameObject gameObject2 = (GameObject)(object)obj6._003C_003E4__this;
									if ((object)obj6._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdi_v7 (UnityEngine.GameObject)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdi_v7 (UnityEngine.GameObject)+58]");
											float2 position2 = ((ArcadeSprite)0).position;
											_003C_003Ec__DisplayClass38_0 obj7 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
											{
												EME_SpiritRings1Weapon eME_SpiritRings1Weapon = obj7._003C_003E4__this;
												if ((object)obj7._003C_003E4__this != null)
												{
													nint num6 = (nint)gameObject2;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
													return;
												}
											}
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num2 = (float)(flag2 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag3 = (nint)vector > (flag2 ? 1 : 0);
				vector2 = (Vector2)flag2;
			}
			while (flag3);
		}
		float num3 = base.PInterval();
		float num4 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num5 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		Vector2 vector = default(Vector2);
		float num2 = (float)vector + _elapsed_Firee;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addps xmm1,xmm6\"");
		float elapsed_Chaos = (float)vector + _elapsed_Chaos;
		_elapsed_Chaos = elapsed_Chaos;
		_elapsed_Firee = num2;
		_elapsed_Water = _elapsed_Water;
		if (!(num2 < deltaTime))
		{
			_elapsed_Firee = 0f;
			FireSpell(_projectilePool);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_01);
			Tuple<string, WeaponType> glimmerNameAndType = null;
			_ = 2396;
			stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		}
		float num3 = deltaTime * 3f;
		if (!(_elapsed_Water < num3))
		{
			_elapsed_Water = 0f;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num4 = characterController.PDuration();
			if (!(1.55f > _elapsed_Water))
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				string glimmerName2 = GetGlimmerName(WeaponType.EME_MAGIC_TECH_02);
				Tuple<string, WeaponType> glimmerNameAndType2 = null;
				_ = 2397;
				stage2._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType2);
			}
		}
		float num5 = deltaTime * 5f;
		if (!(_elapsed_WoodA < num5))
		{
			_elapsed_WoodA = 0f;
			float num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
			if (!(1.55f > _elapsed_WoodA))
			{
				FireSpell(_heavensThunderPool);
				GameManager core3 = GM.Core;
				Stage stage3 = core3._stage;
				string glimmerName3 = GetGlimmerName(WeaponType.EME_MAGIC_TECH_03);
				Tuple<string, WeaponType> glimmerNameAndType3 = null;
				_ = 2398;
				stage3._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType3);
			}
		}
		float num7 = deltaTime * 7f;
		if (!(_elapsed_Earth < num7))
		{
			_elapsed_Earth = 0f;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num8 = characterController2.PGrowth();
			if (!(1.55f > _elapsed_Earth))
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Projectile projectile2 = base.FireOneProjectile(vector, 0, _targetTransform);
				GameManager core4 = GM.Core;
				Stage stage4 = core4._stage;
				string glimmerName4 = GetGlimmerName(WeaponType.EME_MAGIC_TECH_04);
				Tuple<string, WeaponType> glimmerNameAndType4 = null;
				_ = 2399;
				stage4._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType4);
			}
		}
		float num9 = deltaTime * 11f;
		if (!(_elapsed_Metal < num9))
		{
			_elapsed_Metal = 0f;
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num10 = characterController3.PArea();
			if (!(1.55f > _elapsed_Metal))
			{
				float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Projectile projectile3 = base.FireOneProjectile(vector, 0, _targetTransform);
				GameManager core5 = GM.Core;
				Stage stage5 = core5._stage;
				string glimmerName5 = GetGlimmerName(WeaponType.EME_MAGIC_TECH_05);
				Tuple<string, WeaponType> glimmerNameAndType5 = null;
				_ = 2400;
				stage5._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType5);
			}
		}
		float num11 = deltaTime * 13f;
		if (!(_elapsed_Chaos < num11))
		{
			_elapsed_Chaos = 0f;
			if (IsEvolved)
			{
				float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Projectile projectile4 = base.FireOneProjectile(vector, 0, _targetTransform);
				GameManager core6 = GM.Core;
				Stage stage6 = core6._stage;
				string glimmerName6 = GetGlimmerName(WeaponType.EME_MAGIC_TECH_06);
				Tuple<string, WeaponType> glimmerNameAndType6 = null;
				_ = 2401;
				stage6._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType6);
			}
		}
	}

	private void Fire_Fire()
	{
		FireSpell(_projectilePool);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_01);
		Tuple<string, WeaponType> glimmerNameAndType = null;
		_ = 2396;
		stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
	}

	private void Fire_Water()
	{
		//IL_001c: Invalid comparison between F4 and O
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = characterController.PDuration();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.55f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_02);
			Tuple<string, WeaponType> glimmerNameAndType = null;
			_ = 2397;
			stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		}
	}

	private void Fire_WoodA()
	{
		//IL_001d: Invalid comparison between F4 and O
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.55f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			FireSpell(_heavensThunderPool);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_03);
			Tuple<string, WeaponType> glimmerNameAndType = null;
			_ = 2398;
			stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		}
	}

	private void Fire_Earth()
	{
		//IL_001c: Invalid comparison between F4 and O
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = characterController.PGrowth();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.55f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_04);
			Tuple<string, WeaponType> glimmerNameAndType = null;
			_ = 2399;
			stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		}
	}

	private void Fire_Metal()
	{
		//IL_001c: Invalid comparison between F4 and O
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = characterController.PArea();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.55f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_05);
			Tuple<string, WeaponType> glimmerNameAndType = null;
			_ = 2400;
			stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		}
	}

	private void Fire_Chaos()
	{
		if (IsEvolved)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			string glimmerName = GetGlimmerName(WeaponType.EME_MAGIC_TECH_06);
			Tuple<string, WeaponType> glimmerNameAndType = null;
			_ = 2401;
			stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	private bool OnBulletOverlapsEnemyDamagex15(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 1.5f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	private bool OnBulletOverlapsEnemyDamagex2(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0159: Expected I4, but got O
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
						goto IL_0176;
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
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 + obj2;
									float damage = (float)obj2 * (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0176;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0176:
		return false;
	}

	private bool OnBulletOverlapsEnemyDamagex3(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 3f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_explodeOnExpire = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				GameManager gameMan4 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan4._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
	}

	public void SpawnFireExplosionAt(float2 pos)
	{
		//IL_009e: Expected I, but got O
		//IL_0141: Expected I, but got O
		if (_fireExplosionPool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FIREEXPLOSION);
			BulletPool fireExplosionPool = new BulletPool(projectilePrefab);
			_fireExplosionPool = fireExplosionPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				GameManager core = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+370]");
				ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
				CallbackContext callbackContext = default(CallbackContext);
				Collider collider = physics.add.overlap(_fireExplosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					ArcadePhysics physics2 = s_scene2.physics;
					GameManager core2 = GM.Core;
					PhysicsManager physicsManager = core2._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_SpiritRings1Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num2 = (nint)this;
					Collider collider2 = physics2.add.overlap(_fireExplosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
					goto IL_0179;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0179;
		IL_0179:
		Projectile projectile = _fireExplosionPool.SpawnAt(pos, this, 1);
	}

	public EME_SpiritRings1Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}
}
