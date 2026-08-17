using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SpiritTornado2_Weapon : Weapon
{
	private SpriteRenderer _WhiteDot;

	private SpriteRenderer _GroundSeal;

	private GameObject _ExplosionVFXPrefab;

	private Projectile _spiritGemProjectilePrefab;

	private Projectile _gemExplosionProjectilePrefab;

	[NonSerialized]
	public float _R = 1f;

	[NonSerialized]
	public float _G = 1f;

	[NonSerialized]
	public float _B = 1f;

	[NonSerialized]
	public float _A;

	private BulletPool _spiritGemProjectilePool;

	private BulletPool _gemExplosionProjectilePool;

	private ObjectPool _explosionPool;

	private MultiTargetTween _rgbTween;

	private MultiTargetTween _alphaTween;

	private bool _canFlash;

	private Projectile _activeProjectile;

	private PhaserSprite _bigGemSprite1;

	private PhaserSprite _bigGemSprite2;

	private float _bigGemAngle;

	private float2 _bigGemOrbitModifier;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxEmitter;

	private float _cachedXPMultiplier;

	private float _003CStoredXP_003Ek__BackingField;

	public float StoredXP
	{
		get
		{
			return _003CStoredXP_003Ek__BackingField;
		}
		set
		{
			_003CStoredXP_003Ek__BackingField = value;
		}
	}

	public BulletPool SpiritGemProjectilePool => _spiritGemProjectilePool;

	public BulletPool GemExplosionProjectilePool => _gemExplosionProjectilePool;

	public ObjectPool ExplosionPool => _explosionPool;

	public SpriteRenderer WhiteDot => _WhiteDot;

	protected override bool UseOnlineTimer => false;

	public float TweenInDurationMillis => 3000f;

	protected override void OnStart()
	{
		//IL_00f5: Expected I, but got O
		//IL_01af: Expected I, but got O
		//IL_0252: Expected I, but got O
		base.OnStart();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F947]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("moon3", "vfx");
		_GroundSeal.sprite = sprite;
		BulletPool spiritGemProjectilePool = new BulletPool(_spiritGemProjectilePrefab, 200);
		_spiritGemProjectilePool = spiritGemProjectilePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_spiritGemProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			BulletPool gemExplosionProjectilePool = new BulletPool(_gemExplosionProjectilePrefab);
			_gemExplosionProjectilePool = gemExplosionProjectilePool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1080 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+370]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_gemExplosionProjectilePool, core2.Enemies, collideCallback2, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					ArcadePhysics physics3 = s_scene3.physics;
					GameManager core3 = GM.Core;
					PhysicsManager physicsManager = core3._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					Collider collider3 = physics3.add.overlap(_gemExplosionProjectilePool, physicsManager._destructiblesGroup, collideCallback3, processCallback, callbackContext);
					SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
					if (spriteTexturesBase.Items != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A928B]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "items", "Gem6");
						PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
						PhaserSprite phaserSprite3 = phaserSprite2.setDepth(9000);
						GameObject gameObject2 = phaserSprite3.gameObject;
						((UnityEngine.Object)gameObject2).SetName("BigGemSprite");
						_bigGemSprite1 = phaserSprite3;
						SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
						if (spriteTexturesBase2.Items != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A928F]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							GameObject gameObject3 = _bigGemSprite1.gameObject;
							PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "items", "Gem10");
							PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
							PhaserSprite phaserSprite6 = phaserSprite5.setDepth(9001);
							GameObject gameObject4 = phaserSprite6.gameObject;
							((UnityEngine.Object)gameObject4).SetName("BigGemSprite2");
							_bigGemSprite2 = phaserSprite6;
							GenerateParticleSystem();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0054: Expected I4, but got I8
		base.InitWeapon(characterController, weaponType);
		InitVariables();
		string text = ((UnityEngine.Object)_ExplosionVFXPrefab).GetName();
		ObjectPool explosionPool = ObjectPool.Create(_ExplosionVFXPrefab, text, 10, -1);
		_explosionPool = explosionPool;
		ObjectPool explosionPool2 = _explosionPool;
		explosionPool2._incrementalInstanceNames = true;
		ObjectPool explosionPool3 = _explosionPool;
		if (!explosionPool3._003CInitialized_003Ek__BackingField)
		{
			explosionPool3._003CInitialized_003Ek__BackingField = true;
			explosionPool3.AutoFillName();
			explosionPool3.Populate(explosionPool3._defaultSize);
		}
		ObjectPool explosionPool4 = _explosionPool;
		MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(explosionPool4._name, _explosionPool);
		MakeWhiteDot();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundSeal, 0f);
		Transform transform = _GroundSeal.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void InitVariables()
	{
		_canFlash = true;
		_003CStoredXP_003Ek__BackingField = 0f;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		_cachedXPMultiplier = arcanaManager._003CXpMultiplier_003Ek__BackingField;
	}

	public override float PInterval()
	{
		//IL_0069: Invalid comparison between F4 and I
		//IL_0090: Expected F4, but got I
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		float num2 = default(float);
		bool flag = !(0.1f < num2);
		float num3 = 0.1f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cinterval_003Ek__BackingField;
		float num5 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11158]");
		if (num5 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11158]");
			num4 = 0f;
		}
		return num4;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00a9->IL0038: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		SpriteRenderer whiteDot = _WhiteDot;
		if ((object)_WhiteDot != null)
		{
			bool flag = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, 29);
			SpriteRenderer whiteDot2 = _WhiteDot;
			if ((object)_WhiteDot != null)
			{
				bool flag2 = ((UnityEngine.Object)whiteDot2).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)whiteDot2).m_CachedPtr, ref *(Color*)(&value));
				UpdateBigGem();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00fe: Expected I4, but got O
		//IL_0081: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CoherenceSync coherenceSync = characterController._coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			FireVenusCrescent(skipTriggers);
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Action<bool> action = null;
		((VampireSurvivors.Objects.Characters.CharacterController)(object)action).FireVenusCrescentWeapon((byte)(int)((Equipment)this)._003COwner_003Ek__BackingField != 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F5C410");
	}

	public unsafe void FireVenusCrescent(bool skipTriggers)
	{
		//IL_01dc: Expected I, but got O
		//IL_01f5: Expected O, but got Ref
		//IL_009d: Expected I, but got O
		//IL_00f0: Invalid comparison between F4 and O
		//IL_0122: Expected F4, but got O
		//IL_015e: Expected I, but got O
		//IL_0151->IL016d: Incompatible stack heights: 1 vs 0
		bool flag = _spawnedProjectiles == null;
		TP_SpiritTornado2_Weapon tP_SpiritTornado2_Weapon = this;
		if (!flag)
		{
			List<Projectile> ret = _spawnedProjectiles;
			List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
			if (enumerator.MoveNext())
			{
				TP_SpiritTornado2_Weapon tP_SpiritTornado2_Weapon2 = null;
				tP_SpiritTornado2_Weapon = null;
				throw new NullReferenceException();
			}
			nint num = (nint)_cachedTransform;
			bool flag2 = (object)_cachedTransform == null;
			tP_SpiritTornado2_Weapon = (TP_SpiritTornado2_Weapon)(&enumerator);
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_Projectile>)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_Projectile>)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
				Vector2 vector = default(Vector2);
				Projectile activeProjectile = base.FireOneProjectile(vector, 0, _targetTransform);
				_activeProjectile = activeProjectile;
				nint num2 = (nint)_activeProjectile;
				if ((object)_activeProjectile == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_Projectile>)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				ShowSeal();
				float num3 = PInterval();
				bool flag4 = (object)_lastFiringInterval == (object)vector;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018746DE76h\"");
				if (!flag4)
				{
					float num4 = PInterval();
					_lastFiringInterval = (float)vector;
					base.ResetFiringTimer();
				}
				if (skipTriggers)
				{
					return;
				}
				tP_SpiritTornado2_Weapon = (TP_SpiritTornado2_Weapon)(object)((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					nint num5 = (nint)tP_SpiritTornado2_Weapon;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v830 @ rax_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+648] (should have been resolved before IL gen)");
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void FlashScreen(Projectile projectile)
	{
		//IL_06d1: Expected O, but got I4
		//IL_06eb: Expected O, but got I4
		//IL_028a: Expected I, but got O
		//IL_02f4: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_047d: Expected O, but got I4
		//IL_0543: Expected I, but got O
		//IL_0607: Expected O, but got I4
		//IL_008c->IL06f9: Incompatible stack heights: 0 vs 1
		//IL_006e->IL06f9: Incompatible stack heights: 0 vs 1
		//IL_0712->IL00c3: Incompatible stack heights: 1 vs 0
		//IL_068f->IL068f: Incompatible stack heights: 4 vs 1
		//IL_0637->IL0637: Incompatible stack heights: 16 vs 4
		Projectile activeProjectile = _activeProjectile;
		bool flag = (object)_activeProjectile == null;
		bool flag2 = (object)projectile == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		bool num;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)_activeProjectile != null)
			{
				if ((object)projectile != null)
				{
					object obj3 = (object)projectile - (object)_activeProjectile;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeProjectile).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				bool flag5 = (object)projectile == null;
				num = flag5;
				flag4 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		if (_rgbTween != null)
		{
			_rgbTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		Projectile whiteDot = (Projectile)(object)_WhiteDot;
		_B = 1f;
		_G = 1f;
		_R = 1f;
		_A = 0f;
		bool flag6 = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
		num = flag6;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, ref value);
		if (_canFlash)
		{
			GameManager core = GM.Core;
			bool flag7 = (object)GM.Core == null;
			bool flag8 = core._playerOptions == null;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag9 = config == null;
			if (config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				bool flag10 = array == null;
				void* value2 = ((IntPtr*)(&array))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				bool flag11 = obj4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag12 = tweenConfig == null;
				((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				bool flag13 = dictionary == null;
				object value3 = default(object);
				bool flag14 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_A", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1120403456;
				_ = 1;
				((GameMonoBehaviour)(object)tweenConfig)._onPauseSent = true;
				MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
				_alphaTween = alphaTween;
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				bool flag15 = array2 == null;
				void* value4 = ((IntPtr*)(&array2))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				bool flag16 = obj5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag17 = tweenConfig2 == null;
				((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				bool flag18 = dictionary2 == null;
				object value5 = default(object);
				bool flag19 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_R", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value6 = default(object);
				bool flag20 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_G", value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value7 = default(object);
				bool flag21 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_B", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1112014848;
				_ = 0;
				((GameMonoBehaviour)(object)tweenConfig2)._onPauseSent = true;
				MultiTargetTween rgbTween = Tweens.Add(tweenConfig2);
				_rgbTween = rgbTween;
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				bool flag22 = array3 == null;
				void* value8 = ((IntPtr*)(&array3))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				bool flag23 = obj6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag24 = tweenConfig3 == null;
				((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				bool flag25 = dictionary3 == null;
				object value9 = default(object);
				bool flag26 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_R", value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value10 = default(object);
				bool flag27 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_G", value10, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value11 = default(object);
				bool flag28 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_B", value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				_ = 1120403456;
				((MonoBehaviour)(object)tweenConfig3).m_CancellationTokenSource = (CancellationTokenSource)1103626240;
				_ = 0;
				((GameMonoBehaviour)(object)tweenConfig3)._onPauseSent = true;
				MultiTargetTween rgbTween2 = Tweens.Add(tweenConfig3);
				_rgbTween = rgbTween2;
			}
			_canFlash = false;
			Action onComplete = delegate
			{
				_canFlash = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public unsafe void SpinSeal(float durationMillis, float scale, float alpha, Projectile projectile)
	{
		//IL_0371: Expected O, but got I4
		//IL_038b: Expected O, but got I4
		//IL_0215: Expected O, but got Ref
		//IL_01c5: Expected O, but got I
		//IL_030f: Expected O, but got I
		Projectile activeProjectile = _activeProjectile;
		bool flag = (object)_activeProjectile == null;
		object obj = default(object);
		bool flag2 = obj == null;
		object obj2 = flag2 & flag;
		bool flag3 = obj2 == null;
		object obj3 = !flag3;
		if (obj3 == null)
		{
			bool flag4;
			if ((object)_activeProjectile != null)
			{
				if (obj != null)
				{
					object obj4 = obj - (object)_activeProjectile;
					flag4 = obj4 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeProjectile).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ stack_28+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		float duration = durationMillis * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundSeal, alpha, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						object obj5 = num + 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _GroundSeal.transform;
		float duration2 = durationMillis * 0.001f;
		object obj6 = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj6), duration2);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj7 = num2 + 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public unsafe void HideSeal(Projectile projectile)
	{
		//IL_0251: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_0175: Expected O, but got Ref
		Projectile activeProjectile = _activeProjectile;
		bool flag = (object)_activeProjectile == null;
		bool flag2 = (object)projectile == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)_activeProjectile != null)
			{
				if ((object)projectile != null)
				{
					object obj3 = (object)projectile - (object)_activeProjectile;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeProjectile).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundSeal, 0f, 0.3f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _GroundSeal.transform;
		object obj4 = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj4), 0.3f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		Action onComplete = delegate
		{
			base.Fire();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void InitGroundSeal()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundSeal, 0f);
		if ((object)_GroundSeal != null)
		{
			Transform transform = _GroundSeal.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ShowSeal()
	{
		//IL_0122: Expected O, but got Ref
		//IL_0247->IL01bd: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL01bd: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundSeal, 0f);
		if ((object)_GroundSeal != null)
		{
			Transform transform = _GroundSeal.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundSeal, 0.2f, 3.0000002f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore != null && (object)_GroundSeal != null)
				{
					Transform target = _GroundSeal.transform;
					object obj = default(object);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 3.0000002f);
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					bool flag2 = tweenerCore2 == null;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeWhiteDot()
	{
		Camera main = Camera.main;
		float num = (float)CameraExtensions.OrthographicBounds(main).m_Extents * 2f;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		if (num < num2 || (object)_WhiteDot != null)
		{
			Transform transform = _WhiteDot.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform whiteDot = (Transform)(object)_WhiteDot;
				bool flag2 = (object)_WhiteDot == null;
				bool flag3 = ((UnityEngine.Object)whiteDot).m_CachedPtr == (IntPtr)0;
				Color value2 = default(Color);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)whiteDot).m_CachedPtr, ref value2);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_WhiteDot, 0f);
				Transform whiteDot2 = (Transform)(object)_WhiteDot;
				bool flag4 = (object)_WhiteDot == null;
				bool flag5 = ((UnityEngine.Object)whiteDot2).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)whiteDot2).m_CachedPtr, 29);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void GeneratePool()
	{
		//IL_003b: Expected I4, but got I8
		string text = ((UnityEngine.Object)_ExplosionVFXPrefab).GetName();
		ObjectPool explosionPool = ObjectPool.Create(_ExplosionVFXPrefab, text, 10, -1);
		_explosionPool = explosionPool;
		ObjectPool explosionPool2 = _explosionPool;
		explosionPool2._incrementalInstanceNames = true;
		ObjectPool explosionPool3 = _explosionPool;
		if (!explosionPool3._003CInitialized_003Ek__BackingField)
		{
			explosionPool3._003CInitialized_003Ek__BackingField = true;
			explosionPool3.AutoFillName();
			explosionPool3.Populate(explosionPool3._defaultSize);
		}
		ObjectPool explosionPool4 = _explosionPool;
		MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(explosionPool4._name, _explosionPool);
	}

	public unsafe void MakeBigGem()
	{
		//IL_00a9: Expected O, but got I4
		//IL_00d1: Expected O, but got Ref
		//IL_013b: Expected O, but got Ref
		//IL_0151: Expected O, but got I4
		if (_isVisible)
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			_cachedXPMultiplier = arcanaManager._003CXpMultiplier_003Ek__BackingField;
			GameManager core2 = GM.Core;
			ArcanaManager arcanaManager2 = core2._arcanaManager;
			arcanaManager2._003CXpMultiplier_003Ek__BackingField = 0f;
			PhaserSprite phaserSprite = _bigGemSprite1.setVisible(visible: true);
			float2 localPosition = default(float2);
			PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(localPosition);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
			Transform transform = phaserSprite3.transform;
			float2 float5 = default(float2);
			transform.localEulerAngles = (Vector3)(&float5);
			PhaserSprite phaserSprite4 = _bigGemSprite2.setVisible(visible: true);
			PhaserSprite phaserSprite5 = phaserSprite4.setLocalPosition(localPosition);
			PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
			Transform transform2 = phaserSprite6.transform;
			transform2.localEulerAngles = (Vector3)(&float5);
			_bigGemAngle = -90f;
			_bigGemOrbitModifier = (float2)1065353216;
			_ = 1065353216;
			DoBigGemTween1();
		}
	}

	private unsafe void DoBigGemTween1()
	{
		//IL_001a: Expected O, but got I4
		//IL_0077: Expected O, but got I8
		//IL_0230: Expected O, but got Ref
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0450: Expected O, but got I4
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_03e9: Expected F4, but got I4
		PhaserSprite phaserSprite = _bigGemSprite1.setScale(8f, (float?)(object)0);
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_SpiritTornado2_Weapon)(object)dOSetter)._003CDoBigGemTween1_003Eb__55_1(8f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 3f, 0.5f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r14_v2+462E0+v401 @ rdx_v25*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r14_v2+462E0+v401 @ rdx_v25*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r14_v2+462E0+v401 @ rdx_v25*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r14_v2+462E0+v401 @ rdx_v25*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r14_v2+462E0+v401 @ rdx_v25*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = DoBigGemTween2;
					tweenCallback2 = tweenCallback;
					goto IL_019d;
				}
			}
		}
		TweenCallback tweenCallback3 = DoBigGemTween2;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_019d;
		}
		goto IL_01cc;
		IL_01cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _bigGemSprite1.transform;
		object obj9 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj9), 0.5f, RotateMode.FastBeyond360);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 2;
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite bigGemSprite = _bigGemSprite2;
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(bigGemSprite._spriteRenderer, 1f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_SoulAbsorb1, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		return;
		IL_019d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01cc;
	}

	private unsafe void DoBigGemTween2()
	{
		//IL_003f: Expected O, but got I8
		//IL_0161: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_05b8: Expected O, but got I4
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_0126: Expected O, but got I4
		//IL_03b6: Expected O, but got Ref
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float num = default(float);
		((TP_SpiritTornado2_Weapon)(object)dOSetter)._003CDoBigGemTween2_003Eb__56_1(num);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, 0.5f);
		object obj = 6603577472L;
		object obj9;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num3;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v1+462E0+v161 @ rdx_v42*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v1+462E0+v161 @ rdx_v42*8]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v1+462E0+v161 @ rdx_v42*8]");
						if (num2 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v1+462E0+v161 @ rdx_v42*8]");
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbp_v1+462E0+v161 @ rdx_v42*8]");
					}
					while (num3 != 0);
					TweenCallback tweenCallback = GrantStoredXP;
					obj9 = 0;
					tweenCallback2 = tweenCallback;
					goto IL_0180;
				}
			}
		}
		TweenCallback tweenCallback3 = GrantStoredXP;
		bool flag2 = tweenerCore == null;
		obj9 = 0;
		tweenCallback2 = tweenCallback3;
		object obj10 = 0;
		if (!flag2)
		{
			goto IL_0180;
		}
		goto IL_01bf;
		IL_01bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((TP_SpiritTornado2_Weapon)(object)dOSetter2)._003CDoBigGemTween2_003Eb__56_3(num);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 0f, 0.5f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _bigGemSprite1.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target, 1f, 0.5f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target2 = _bigGemSprite1.transform;
		object obj11 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj11), 0.5f, RotateMode.FastBeyond360);
		if (tweenerCore4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 2;
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite bigGemSprite = _bigGemSprite2;
		TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleSprite.DOFade(bigGemSprite._spriteRenderer, 0f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return;
		IL_0180:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		bool flag3 = (nint)0 == 0;
		obj10 = obj9;
		if (!flag3)
		{
			obj10 = obj9;
		}
		goto IL_01bf;
	}

	private unsafe void UpdateBigGem()
	{
		//IL_0151: Expected O, but got I4
		//IL_0255->IL00f1: Incompatible stack heights: 6 vs 0
		//IL_00f0->IL00f0: Incompatible stack heights: 6 vs 1
		PhaserSprite bigGemSprite = _bigGemSprite1;
		if ((object)_bigGemSprite1 != null)
		{
			PhaserSprite spriteRenderer = (PhaserSprite)(object)bigGemSprite._spriteRenderer;
			if ((object)bigGemSprite._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj = Renderer.get_enabled_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
				if (obj == null)
				{
					return;
				}
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime * 270f;
				float bigGemAngle = num + _bigGemAngle;
				_bigGemAngle = bigGemAngle;
				float num2 = _bigGemAngle * ((float)Math.PI / 180f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				ParticleEmitterManager cachedTransform = (ParticleEmitterManager)(object)_cachedTransform;
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector2 value = default(Vector2);
				Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
				bool flag4 = (object)_bigGemSprite1 == null;
				ParticleSystem particleSystem = RenderingExtensions.SetScale(scale: _bigGemSprite1.scale, component: _pfxEmitter);
				object cachedTransform2 = _cachedTransform;
				bool flag5 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rbx_v16 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rbx_v16 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				if ((object)_pfxManager != null)
				{
					Vector2 pos = default(Vector2);
					_pfxManager.EmitParticleAt(pos, 5);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void GrantStoredXP()
	{
		//IL_007e: Expected F4, but got I4
		//IL_024e: Expected O, but got I4
		//IL_01dd: Invalid comparison between F4 and O
		//IL_01c1: Expected F4, but got I4
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_021c: Expected O, but got I4
		PhaserSprite phaserSprite = _bigGemSprite1.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _bigGemSprite2.setVisible(visible: false);
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		if (arcanaManager._003CPewPew_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm6\"");
			float num = 0f;
			object obj = default(object);
			while (true)
			{
				bool flag = (nint)obj >= 50;
				object obj2 = 50;
				if (!flag)
				{
					obj2 = obj;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					break;
				}
				float damage = ((!(50f > _003CStoredXP_003Ek__BackingField)) ? (_003CStoredXP_003Ek__BackingField / 50f) : 1f);
				object obj3 = num & 1;
				bool flag2 = obj3 == null;
				object obj4 = !flag2;
				string frameName = "Gem10";
				if (obj4 == null)
				{
					frameName = "Gem6";
				}
				GameManager core = GM.Core;
				core._arcanaManager.TriggerGemCannon(damage, frameName, ((Equipment)this)._003COwner_003Ek__BackingField);
				num++;
			}
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		arcanaManager2._003CXpMultiplier_003Ek__BackingField = _cachedXPMultiplier;
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PGrowth();
		object obj5 = default(object);
		float xp = (float)obj5 * _003CStoredXP_003Ek__BackingField;
		_gameMan.AddPlayerXp(xp);
		_003CStoredXP_003Ek__BackingField = 0f;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_SoulAbsorb2, 0f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private void SpawnGameKillerGems(float amount)
	{
		//IL_004c: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0135: Expected O, but got I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		if (!arcanaManager._003CPewPew_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm6\"");
		object obj = 0;
		object obj2 = default(object);
		while (true)
		{
			bool flag = (nint)obj2 >= 50;
			object obj3 = 50;
			if (!flag)
			{
				obj3 = obj2;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				break;
			}
			float damage = ((!(50f > amount)) ? (amount / 50f) : 1f);
			object obj4 = obj & 1;
			bool flag2 = obj4 == null;
			object obj5 = !flag2;
			string frameName = "Gem10";
			if (obj5 == null)
			{
				frameName = "Gem6";
			}
			GameManager core = GM.Core;
			core._arcanaManager.TriggerGemCannon(damage, frameName, ((Equipment)this)._003COwner_003Ek__BackingField);
			obj++;
		}
	}

	public void SpawnGemExplosion()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		Projectile projectile = _gemExplosionProjectilePool.SpawnAt(pos, this);
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		//IL_01f7: Expected native int or pointer, but got O
		//IL_0378: Expected O, but got I4
		//IL_020f: Expected O, but got Ref
		//IL_0236: Expected O, but got I
		//IL_024b: Expected native int or pointer, but got O
		//IL_0265: Expected O, but got I
		//IL_0285: Expected O, but got Ref
		//IL_029f: Expected native int or pointer, but got O
		//IL_0395: Expected O, but got I4
		//IL_02b7: Expected O, but got Ref
		//IL_02d1: Expected native int or pointer, but got O
		//IL_03bf: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter == null || ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPink");
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
				((List<object>)(object)list).AddWithResize((object)"PfxYellow");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(2f, 2f));
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter2 = _pfxManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
			_pfxEmitter = pfxEmitter2;
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_003e: Expected O, but got I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		InitVariables();
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CFlashScreen_003Eb__46_0()
	{
		_canFlash = true;
	}

	private void _003CMakeLevelOne_003Eb__49_0()
	{
		base.Fire();
	}

	private float _003CDoBigGemTween1_003Eb__55_0()
	{
		//IL_0007: Expected F4, but got O
		return (float)_bigGemOrbitModifier;
	}

	private void _003CDoBigGemTween1_003Eb__55_1(float x)
	{
		//IL_000a: Expected O, but got F4
		_bigGemOrbitModifier = (float2)x;
	}

	private float _003CDoBigGemTween2_003Eb__56_0()
	{
		//IL_0007: Expected F4, but got O
		return (float)_bigGemOrbitModifier;
	}

	private void _003CDoBigGemTween2_003Eb__56_1(float x)
	{
		//IL_000a: Expected O, but got F4
		_bigGemOrbitModifier = (float2)x;
	}

	private float _003CDoBigGemTween2_003Eb__56_2()
	{
		//IL_000d: Expected F4, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon)+1E0]");
		return 0f;
	}

	private void _003CDoBigGemTween2_003Eb__56_3(float y)
	{
	}
}
