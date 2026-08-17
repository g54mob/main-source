using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass59_0
	{
		public EME_Weapon _003C_003E4__this;

		public BulletPool glimmerPool;

		public bool skipTriggers;

		internal void _003CFire_003Eb__0()
		{
			//IL_00c7: Expected O, but got I4
			//IL_006f->IL0090: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.Fire_DoAttacks(glimmerPool, skipTriggers);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass61_0
	{
		public int localIndex;

		public EME_Weapon _003C_003E4__this;

		internal void _003CFire_DoAttacks_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							EME_Weapon eME_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+6A8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected Projectile _Glimmer1Prefab;

	protected Projectile _Glimmer2Prefab;

	protected Projectile _Glimmer3Prefab;

	private float timeBeforeGlimmer = 15000f;

	private const float FIVE_SECOND_TIMER = 5000f;

	private float finalGlimmerTimer;

	private Timer glimmerUnlockTimer;

	private bool glimmerUnlocked;

	protected BulletPool _glimmer1Pool;

	protected BulletPool _glimmer2Pool;

	protected BulletPool _glimmer3Pool;

	private static List<TechniqueUsage> s_techniqueUsages;

	private static float s_lastUpdateTime;

	protected bool _hasGlimmeredFirstTime;

	protected bool _hasProcessedFirstGlimmer;

	protected bool _hasSentFirstGlimmer;

	protected bool _hasAddedEvo;

	protected bool _hasEvolution;

	protected bool _ShouldGlimmerNextFire;

	protected float _glimmerChance;

	protected int _fireCounter;

	protected int _lastFiredGlimmerLevel;

	private readonly Dictionary<WeaponType, string> _glimmerNames;

	public int OwnerComboModifier;

	private bool _forceGlimmer;

	public const int DefaultPoolSize = 20;

	protected virtual int GlimmerTier => 1;

	protected virtual float GlimmerChanceBaseValue => 0.01f;

	protected virtual float GlimmerChanceEntropyValue => 0.0025f;

	protected virtual int EvolutionLevel => 6;

	protected virtual int _comboIndex1 => 1;

	protected virtual int _comboIndex2 => 2;

	protected virtual int _comboIndex3 => 3;

	protected int ComboIndex1
	{
		get
		{
			//IL_005f: Expected I4, but got O
			int comboIndex = _comboIndex1;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				int glimmerComboModifier = ((Equipment)this)._003COwner_003Ek__BackingField.GlimmerComboModifier;
				int num = glimmerComboModifier + comboIndex;
				if (num <= 1)
				{
					num = 1;
				}
				return num;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	protected int ComboIndex2
	{
		get
		{
			//IL_005f: Expected I4, but got O
			int comboIndex = _comboIndex2;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				int glimmerComboModifier = ((Equipment)this)._003COwner_003Ek__BackingField.GlimmerComboModifier;
				int num = glimmerComboModifier + comboIndex;
				if (num <= 2)
				{
					num = 2;
				}
				return num;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	protected int ComboIndex3
	{
		get
		{
			//IL_005f: Expected I4, but got O
			int comboIndex = _comboIndex3;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				int glimmerComboModifier = ((Equipment)this)._003COwner_003Ek__BackingField.GlimmerComboModifier;
				int num = glimmerComboModifier + comboIndex;
				if (num <= 3)
				{
					num = 3;
				}
				return num;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	protected virtual int ComboIndexFinal => ComboIndex3;

	protected override int ProjectilePoolSize => 20;

	protected virtual bool CanWeaponGlimmer => true;

	protected virtual WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		return WeaponType.VOID;
	}

	protected override void OnStart()
	{
		base.OnStart();
		InitGlimmer1BulletPool();
		InitGlimmer2BulletPool();
		InitGlimmer3BulletPool();
	}

	protected virtual void InitGlimmer1BulletPool()
	{
		//IL_009f: Expected I, but got O
		//IL_0142: Expected I, but got O
		Projectile glimmer1Prefab = _Glimmer1Prefab;
		if ((object)_Glimmer1Prefab != null && ((UnityEngine.Object)glimmer1Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
			_glimmer1Pool = glimmer1Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected virtual void InitGlimmer2BulletPool()
	{
		//IL_009f: Expected I, but got O
		//IL_0142: Expected I, but got O
		Projectile glimmer2Prefab = _Glimmer2Prefab;
		if ((object)_Glimmer2Prefab != null && ((UnityEngine.Object)glimmer2Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer2Pool = new BulletPool(_Glimmer2Prefab, 20);
			_glimmer2Pool = glimmer2Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer2Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer2Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected virtual void InitGlimmer3BulletPool()
	{
		//IL_009f: Expected I, but got O
		//IL_0142: Expected I, but got O
		Projectile glimmer3Prefab = _Glimmer3Prefab;
		if ((object)_Glimmer3Prefab != null && ((UnityEngine.Object)glimmer3Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer3Pool = new BulletPool(_Glimmer3Prefab, 20);
			_glimmer3Pool = glimmer3Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer3Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer3Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0017: Expected I, but got O
		//IL_0101: Expected O, but got I
		//IL_0167: Expected O, but got I8
		//IL_0201: Expected O, but got Ref
		//IL_024e: Expected O, but got I4
		//IL_0282: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		int glimmerComboModifier = characterController.GlimmerComboModifier;
		nint num = (nint)this;
		OwnerComboModifier = glimmerComboModifier;
		base._003CCanCrit_003Ek__BackingField = false;
		_hasGlimmeredFirstTime = false;
		float glimmerChanceBaseValue = GlimmerChanceBaseValue;
		WeaponData currentWeaponData = _currentWeaponData;
		float glimmerChance = default(float);
		_glimmerChance = glimmerChance;
		bool flag = (nint)currentWeaponData._003CevoInto_003Ek__BackingField < 0;
		bool flag2 = currentWeaponData._003CevoInto_003Ek__BackingField == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool hasEvolution = flag4 & flag3;
		_hasEvolution = hasEvolution;
		WeaponData currentWeaponData2 = _currentWeaponData;
		bool flag6 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		TimerType timerType = default(TimerType);
		if (currentWeaponData2._003CisUnlocked_003Ek__BackingField)
		{
			glimmerUnlocked = true;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag5 = (nint)0 != 0;
			EME_Weapon eME_Weapon = this;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				eME_Weapon = (EME_Weapon)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v335 @ rax_v28 (should have been resolved before IL gen)");
			finalGlimmerTimer = 5000f;
			if (glimmerUnlockTimer != null)
			{
				glimmerUnlockTimer.Cancel();
			}
			Action onComplete = delegate
			{
				glimmerUnlocked = true;
			};
			float duration = finalGlimmerTimer * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag6, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
			glimmerUnlockTimer = timer;
		}
		int num3 = 1;
		nint num4 = default(nint);
		do
		{
			WeaponType weaponTypeForGlimmerLevel = GetWeaponTypeForGlimmerLevel(num3);
			if (weaponTypeForGlimmerLevel != WeaponType.VOID)
			{
				string text = ((Enum)(&num4)).ToString();
				string term = "weaponLang/{" + text + "}name";
				string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, (GameObject)(object)monoBehaviour, (string)num2, (byte)timerType != 0);
				bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)weaponTypeForGlimmerLevel, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				num4 = (nint)typeof(WeaponType);
			}
			num3++;
		}
		while (num3 < 4);
	}

	public void SetGlimmerFirstTimeOnline()
	{
		_hasGlimmeredFirstTime = true;
	}

	public override void Fire(bool skipTriggers = false)
	{
		_003C_003Ec__DisplayClass59_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass59_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		CS_0024_003C_003E8__locals15.skipTriggers = skipTriggers;
		CS_0024_003C_003E8__locals15.glimmerPool = null;
		int comboIndexFinal = ComboIndexFinal;
		if (_fireCounter >= comboIndexFinal)
		{
			_fireCounter = 0;
		}
		int fireCounter = _fireCounter + 1;
		_fireCounter = fireCounter;
		Fire_DoTargeting();
		if (CanWeaponGlimmer)
		{
			bool flag = GlimmerChecks();
			bool flag2 = !_ShouldGlimmerNextFire;
			bool flag3 = flag;
			if (!flag2)
			{
				_ShouldGlimmerNextFire = false;
				flag3 = true;
			}
			BulletPool glimmerBulletPool = GetGlimmerBulletPool(_fireCounter, out var glimmerLevel, flag3);
			CS_0024_003C_003E8__locals15.glimmerPool = glimmerBulletPool;
			bool flag4 = !flag3;
			bool flag5 = flag3;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			if (!flag4)
			{
				bool flag6 = glimmerLevel == _lastFiredGlimmerLevel;
				flag5 = flag3;
				if (!flag6)
				{
					GameManager core = GM.Core;
					Stage stage = core._stage;
					object glimmerManager = stage._glimmerManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rbp_v10 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						string text = ToString();
						string message = "<color=cyan><GlimmerManager.SetFirstGlimmering> first glimmering set to true with weapon :" + text + "</color>";
						Debug.Log(message);
						_ = 1;
						Action onComplete = ((GlimmerManager)glimmerManager).ClearFirstGlimmering;
						Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						flag5 = false;
					}
					else
					{
						_ShouldGlimmerNextFire = true;
						CS_0024_003C_003E8__locals15.glimmerPool = null;
						Debug.Log("<EME_Weapon.Fire>Cannot do first glimmer so setting _ShouldGlimmerNextFire to true");
						flag5 = flag3;
						flag3 = false;
					}
				}
			}
			if (!_ShouldGlimmerNextFire && CS_0024_003C_003E8__locals15.glimmerPool != null && glimmerLevel >= 1)
			{
				if (flag3)
				{
					BulletPool topLevelTechnique = GetTopLevelTechnique();
					if (CS_0024_003C_003E8__locals15.glimmerPool == topLevelTechnique)
					{
						GameManager core2 = GM.Core;
						if (core2._003CCanInterrupt_003Ek__BackingField && !core2._isPaused && core2._003CCanPause_003Ek__BackingField && !core2._003CFreezingFrame_003Ek__BackingField && core2.IsNormalCameraTarget() && glimmerLevel != _lastFiredGlimmerLevel)
						{
							int topLevelTechniqueComboIndex = GetTopLevelTechniqueComboIndex();
							_fireCounter = topLevelTechniqueComboIndex;
							_lastFiredGlimmerLevel = glimmerLevel;
							int glimmerTier = GlimmerTier;
							WeaponType weaponTypeForGlimmerLevel = GetWeaponTypeForGlimmerLevel(glimmerTier);
							((Equipment)this)._003COwner_003Ek__BackingField.OnGlimmeredTechniqueLearned(weaponTypeForGlimmerLevel);
							GameManager core3 = GM.Core;
							if (!core3._multiplayer.IsOnlineMultiplayer)
							{
								RunGlimmerAnimation();
								Action onComplete2 = delegate
								{
									//IL_00c7: Expected O, but got I4
									//IL_006f->IL0090: Incompatible stack heights: 1 vs 0
									if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
									{
										GameObject gameObject = CS_0024_003C_003E8__locals15._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj == null)
											{
												return;
											}
											if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
											{
												CS_0024_003C_003E8__locals15._003C_003E4__this.Fire_DoAttacks(CS_0024_003C_003E8__locals15.glimmerPool, CS_0024_003C_003E8__locals15.skipTriggers);
												return;
											}
										}
									}
									throw new NullReferenceException();
								};
								Timer lastShotTimer = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_lastShotTimer = lastShotTimer;
								return;
							}
							goto IL_0498;
						}
					}
				}
				WeaponType weaponTypeForGlimmerLevel2 = GetWeaponTypeForGlimmerLevel(glimmerLevel);
				GameManager core4 = GM.Core;
				Stage stage2 = core4._stage;
				string glimmerName = GetGlimmerName(weaponTypeForGlimmerLevel2);
				Tuple<string, WeaponType> glimmerNameAndType = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807C5B30");
				stage2._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
			}
		}
		goto IL_0498;
		IL_0498:
		Fire_DoAttacks(CS_0024_003C_003E8__locals15.glimmerPool, CS_0024_003C_003E8__locals15.skipTriggers);
	}

	protected virtual void Fire_DoTargeting()
	{
		_targetTransform = null;
	}

	protected virtual void Fire_DoAttacks(BulletPool glimmerPool, bool skipTriggers = false)
	{
		//IL_02e5: Invalid comparison between O and F4
		//IL_02f6: Expected F4, but got O
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_028b: Invalid comparison between O and F4
		//IL_00e6: Invalid comparison between O and F4
		//IL_00f7: Expected F4, but got O
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0163: Expected F4, but got O
		//IL_023e: Invalid comparison between F4 and I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Fire_FireBasicProjectile(vector, 0, _targetTransform);
		bool flag = glimmerPool == null;
		Vector2 vector2 = vector;
		object obj2 = default(object);
		object obj = obj2;
		if (!flag)
		{
			bool flag2 = _ShouldGlimmerNextFire;
			vector2 = vector;
			obj = obj2;
			if (!flag2)
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Fire_FireGlimmerProjectile(vector, 0, _targetTransform);
				((Equipment)this)._003COwner_003Ek__BackingField.OnGlimmeredTechniqueFired();
				vector2 = vector;
				obj = obj2;
			}
		}
		float num = base.PAmount();
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num2 = (float)vector2;
		if (!flag3)
		{
			float num3 = base.PAmount();
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num2 = (float)vector2;
			if (!flag4)
			{
				bool flag5 = true;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj3 = flag5 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj3 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE890");
						num2 = (float)playerPos;
					}
					else
					{
						_003C_003Ec__DisplayClass61_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass61_0();
						CS_0024_003C_003E8__locals8._003C_003E4__this = this;
						CS_0024_003C_003E8__locals8.localIndex = (flag5 ? 1 : 0);
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_012f: Expected O, but got I4
							//IL_00b4: Expected O, but got I
							//IL_00e9: Expected I, but got O
							//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj5 == null)
									{
										return;
									}
									GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
											float2 position3 = ((ArcadeSprite)0).position;
											EME_Weapon eME_Weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
											{
												nint num9 = (nint)gameObject2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+6A8] (should have been resolved before IL gen)");
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num4 = (float)(flag5 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num2 = num4 * 0.001f;
						Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
					float num5 = base.PAmount();
				}
				while (num2 > (float)(flag5 ? 1 : 0));
			}
		}
		float num6 = base.PInterval();
		float num7 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num8 = base.PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected virtual void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		Projectile projectile = base.FireOneProjectile(pos, index, target);
	}

	protected virtual void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		Projectile projectile = base.FireOneProjectile(pos, index, target);
	}

	protected unsafe virtual BulletPool GetGlimmerBulletPool(int index, out int glimmerLevel, bool forcedGlimmer = false)
	{
		ref int reference = ref *(int*)null;
		int glimmerTier = GlimmerTier;
		bool flag = glimmerTier != 1;
		BulletPool result = null;
		if (!flag)
		{
			bool flag2 = !_hasGlimmeredFirstTime;
			result = null;
			if (!flag2)
			{
				int comboIndex = ComboIndex1;
				bool flag3 = index != comboIndex;
				result = null;
				if (!flag3)
				{
					bool flag4 = AddEvolutionChecks();
					result = _glimmer1Pool;
					reference = ref *(int*)1;
				}
			}
		}
		int glimmerTier2 = GlimmerTier;
		if (glimmerTier2 == 2)
		{
			int comboIndex2 = ComboIndex1;
			if (index == comboIndex2)
			{
				result = _glimmer1Pool;
				reference = ref *(int*)1;
			}
			if (_hasGlimmeredFirstTime)
			{
				int comboIndex3 = ComboIndex2;
				if (index == comboIndex3)
				{
					bool flag5 = AddEvolutionChecks();
					result = _glimmer2Pool;
					reference = ref *(int*)2;
				}
			}
		}
		int glimmerTier3 = GlimmerTier;
		if (glimmerTier3 == 3)
		{
			int comboIndex4 = ComboIndex1;
			if (index == comboIndex4)
			{
				result = _glimmer1Pool;
				reference = ref *(int*)1;
			}
			int comboIndex5 = ComboIndex2;
			if (index == comboIndex5)
			{
				result = _glimmer2Pool;
				reference = ref *(int*)2;
			}
			if (_hasGlimmeredFirstTime)
			{
				int comboIndex6 = ComboIndex3;
				if (index == comboIndex6)
				{
					bool flag6 = AddEvolutionChecks();
					result = _glimmer3Pool;
					reference = ref *(int*)3;
				}
			}
		}
		if (forcedGlimmer)
		{
			bool flag7 = AddEvolutionChecks();
			BulletPool topLevelTechnique = GetTopLevelTechnique();
			int glimmerTier4 = GlimmerTier;
			reference = ref *(int*)glimmerTier4;
			result = topLevelTechnique;
		}
		return result;
	}

	protected bool GlimmerChecks()
	{
		//IL_042f: Expected I4, but got O
		//IL_0117: Expected O, but got I
		//IL_021d: Invalid comparison between F4 and I4
		//IL_0246: Expected O, but got I4
		if (_hasGlimmeredFirstTime && !_hasProcessedFirstGlimmer)
		{
			_hasProcessedFirstGlimmer = true;
			return true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			CoherenceSync coherenceSync = characterController._coherenceSync;
			if ((object)characterController._coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField != null)
				{
					ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
					if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
					{
						goto IL_0421;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v25 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v25 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v25 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						bool flag2 = obj == null;
						flag = flag2;
					}
					if (!flag)
					{
						goto IL_0496;
					}
				}
				if (!_hasGlimmeredFirstTime && !_hasSentFirstGlimmer)
				{
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData == null)
					{
						goto IL_0421;
					}
					if (currentWeaponData._003CisUnlocked_003Ek__BackingField || glimmerUnlocked)
					{
						float value = UnityEngine.Random.value;
						float num = FinalGlimmerChance();
						bool flag3 = value < value;
						float num2 = value - value;
						bool flag4 = num2 == 0f;
						bool flag5 = !flag3;
						bool flag6 = !flag4;
						object obj2 = flag6 & flag5;
						if (obj2 != null)
						{
							GameManager core = GM.Core;
							if ((object)GM.Core != null && core._multiplayer != null)
							{
								if (!core._multiplayer.IsOnlineMultiplayer)
								{
									goto IL_03de;
								}
								VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController2._coherenceSync != null)
								{
									if (!characterController2._coherenceSync.HasStateAuthority)
									{
										goto IL_03de;
									}
									VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
									{
										Action<long, int> action = null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
										if ((object)OnlineStageManager._instance != null)
										{
											long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
											if ((object)characterController3._coherenceSync != null)
											{
												int param = default(int);
												bool flag7 = characterController3._coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
												_hasSentFirstGlimmer = true;
												goto IL_0496;
											}
										}
									}
								}
							}
							goto IL_0421;
						}
						float glimmerChanceEntropyValue = GlimmerChanceEntropyValue;
						float glimmerChance = value + _glimmerChance;
						_glimmerChance = glimmerChance;
					}
				}
				goto IL_0496;
			}
		}
		goto IL_0421;
		IL_0496:
		return false;
		IL_0421:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03de:
		_hasGlimmeredFirstTime = true;
		return true;
	}

	protected virtual float FinalGlimmerChance()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		object obj = default(object);
		return (float)obj * _glimmerChance;
	}

	public override bool LevelUp()
	{
		bool result = LevelUp(skipFire: false);
		bool flag = AddEvolutionChecks();
		return result;
	}

	protected virtual bool AddEvolutionChecks()
	{
		//IL_0100: Expected I4, but got O
		if (_hasEvolution)
		{
			int evolutionLevel = EvolutionLevel;
			if (((Equipment)this)._003CLevel_003Ek__BackingField >= evolutionLevel && _hasGlimmeredFirstTime && !_hasAddedEvo)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData != null)
				{
					WeaponType weapon = Enum.Parse<WeaponType>(currentWeaponData._003CevoInto_003Ek__BackingField);
					if (_levelUpFactory != null)
					{
						_levelUpFactory.AddLateWeapon(weapon, ((Equipment)this)._003COwner_003Ek__BackingField);
						_hasAddedEvo = true;
						goto IL_011f;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
		}
		goto IL_011f;
		IL_011f:
		return false;
	}

	protected virtual BulletPool GetTopLevelTechnique()
	{
		int glimmerTier = GlimmerTier;
		if (glimmerTier != 3)
		{
			int glimmerTier2 = GlimmerTier;
			if (glimmerTier2 != 2)
			{
				return _glimmer1Pool;
			}
			return _glimmer2Pool;
		}
		return _glimmer3Pool;
	}

	protected virtual int GetTopLevelTechniqueComboIndex()
	{
		int glimmerTier = GlimmerTier;
		if (glimmerTier != 3)
		{
			int glimmerTier2 = GlimmerTier;
			if (glimmerTier2 != 2)
			{
				return ComboIndex1;
			}
			return ComboIndex2;
		}
		return ComboIndex3;
	}

	public List<EnemyController> Closest(VampireSurvivors.Objects.Characters.CharacterController source, PhysicsGroup targets)
	{
		List<EnemyController> result = new List<EnemyController>();
		GameManager core = GM.Core;
		PhysicsGroup enemies = core.Enemies;
		float num = 3.4028235E+38f;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		return result;
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

	private unsafe void RunGlimmerAnimation()
	{
		//IL_007f: Expected O, but got Ref
		//IL_0187: Expected F4, but got I4
		//IL_01e0->IL018c: Incompatible stack heights: 1 vs 0
		//IL_00aa->IL018c: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.EME_Light);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)pool != null)
					{
						Vector3 value = default(Vector3);
						LightBulbVFX objectComponent = pool.GetObjectComponent<LightBulbVFX>((Vector3)(&value));
						Transform parent = base.transform;
						if ((object)objectComponent != null)
						{
							Transform transform2 = objectComponent.transform;
							bool flag2 = (object)transform2 == null;
							Transform parent2 = transform2.parent;
							Transform transform3 = objectComponent.transform;
							bool flag3 = (object)transform3 == null;
							transform3.SetParent(parent, worldPositionStays: true);
							Transform transform4 = objectComponent.transform;
							bool flag4 = (object)transform4 == null;
							bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
							int glimmerTier = GlimmerTier;
							WeaponType weaponTypeForGlimmerLevel = GetWeaponTypeForGlimmerLevel(glimmerTier);
							string glimmerName = GetGlimmerName(weaponTypeForGlimmerLevel);
							objectComponent.Play(glimmerName);
							int glimmerTier2 = GlimmerTier;
							float? volume = default(float?);
							float rate = default(float);
							float detune = default(float);
							bool loop = default(bool);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC6_Glimmer, 0f, 10, 0f, volume, rate, detune, loop, 1f);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool HandleAnyTechniqueTriggers(BulletPool glimmerPool, int glimmerLevel, bool isGlimmering)
	{
		//IL_031a: Expected I4, but got O
		if (glimmerPool != null && glimmerLevel >= 1)
		{
			if (isGlimmering)
			{
				BulletPool topLevelTechnique = GetTopLevelTechnique();
				if (glimmerPool == topLevelTechnique)
				{
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						if (!core._003CCanInterrupt_003Ek__BackingField || core._isPaused || !core._003CCanPause_003Ek__BackingField || core._003CFreezingFrame_003Ek__BackingField || !GM.Core.IsNormalCameraTarget() || glimmerLevel == _lastFiredGlimmerLevel)
						{
							goto IL_023f;
						}
						int topLevelTechniqueComboIndex = GetTopLevelTechniqueComboIndex();
						_fireCounter = topLevelTechniqueComboIndex;
						_lastFiredGlimmerLevel = glimmerLevel;
						int glimmerTier = GlimmerTier;
						WeaponType weaponTypeForGlimmerLevel = GetWeaponTypeForGlimmerLevel(glimmerTier);
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							((Equipment)this)._003COwner_003Ek__BackingField.OnGlimmeredTechniqueLearned(weaponTypeForGlimmerLevel);
							GameManager core2 = GM.Core;
							if ((object)GM.Core != null && core2._multiplayer != null)
							{
								if (!core2._multiplayer.IsOnlineMultiplayer)
								{
									RunGlimmerAnimation();
									return true;
								}
								goto IL_02fe;
							}
						}
					}
					goto IL_030c;
				}
			}
			goto IL_023f;
		}
		goto IL_02fe;
		IL_02fe:
		return false;
		IL_023f:
		WeaponType weaponTypeForGlimmerLevel2 = GetWeaponTypeForGlimmerLevel(glimmerLevel);
		GameManager core3 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core3._stage;
			if ((object)core3._stage != null)
			{
				string glimmerName = GetGlimmerName(weaponTypeForGlimmerLevel2);
				Tuple<string, WeaponType> glimmerNameAndType = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807C5B30");
				if (stage._glimmerManager != null)
				{
					stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
					goto IL_02fe;
				}
			}
		}
		goto IL_030c;
		IL_030c:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (glimmerUnlockTimer != null)
		{
			glimmerUnlockTimer.Cancel();
		}
	}

	public EME_Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}

	private void _003CInitWeapon_003Eb__57_0()
	{
		glimmerUnlocked = true;
	}
}
