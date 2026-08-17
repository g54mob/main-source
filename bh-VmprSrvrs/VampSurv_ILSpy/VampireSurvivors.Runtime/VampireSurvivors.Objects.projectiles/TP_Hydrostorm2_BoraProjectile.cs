using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Hydrostorm2_BoraProjectile : Projectile
{
	private const float BodyRadius = 16f;

	private const float GroundFxAlpha = 0.2f;

	private const float BaseGroundSpeed = 25f;

	private bool _isBroken;

	private Vector3 _targetPos;

	private Vector2 _currentDirection;

	private float _groundArea;

	private PhaserSprite _bottleSprite;

	private PhaserSprite _groundFx;

	private ParticleEmitterManager _pfxEmitterExplosionManager;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter1;

	private ParticleSystem _pfxEmitter2;

	private MultiTargetTween _angleTween;

	private Tween _bottlePositionTween;

	private Tween _groundScaleInTween;

	private Tween _groundGrowTween;

	private Tween _groundFadeOutTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Timer _despawnTimer;

	private Timer _groundHomingTimer;

	private float PfxRadius => 16f;

	private float BaseGroundArea
	{
		get
		{
			float num = _weapon.PArea();
			object obj = default(object);
			return (float)obj + (float)obj;
		}
	}

	private float GroundDuration
	{
		get
		{
			float num = _weapon.PDuration();
			object obj = default(object);
			return (float)obj * 1.5f;
		}
	}

	private float BonusGroundSpeed
	{
		get
		{
			Weapon weapon = _weapon;
			float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
			float num2 = default(float);
			bool flag = !(1f < num2);
			float result = 1f;
			if (!flag)
			{
				result = num2;
			}
			return result;
		}
	}

	private Vector2 GroundVelocity
	{
		get
		{
			//IL_0094: Invalid comparison between F4 and O
			if ((object)_weapon != null)
			{
				float num = _weapon.PSpeed();
				Weapon weapon = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					float num2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
					object obj = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						Vector2 result = default(Vector2);
						return result;
					}
				}
			}
			return (Vector2)new NullReferenceException();
		}
	}

	private TP_Hydrostorm2_Weapon TrueWeapon
	{
		get
		{
			//IL_0015: Expected I, but got O
			//IL_001d: Expected I, but got O
			//IL_002d: Expected O, but got I
			//IL_0069: Expected O, but got I
			Weapon weapon = _weapon;
			if ((object)_weapon == null)
			{
				return null;
			}
			nint num = (nint)typeof(TP_Hydrostorm2_Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Hydrostorm2_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Hydrostorm2_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v7+FFFFFFF8+v46 @ rax_v2*8]");
				if (0 == (nint)typeof(TP_Hydrostorm2_Weapon))
				{
					TP_Hydrostorm2_Weapon tP_Hydrostorm2_Weapon = null;
					return (TP_Hydrostorm2_Weapon)_weapon;
				}
			}
			return null;
		}
	}

	protected override void Awake()
	{
		//IL_01df: Expected O, but got I4
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.TP_Items != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A21D4]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "TP_items", "TP_HYDROSTORM2");
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(500);
			GameObject gameObject2 = phaserSprite2.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_bottleSprite");
			_bottleSprite = phaserSprite2;
			SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
			if (spriteTexturesBase.Unitycircle != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				GameObject gameObject3 = base.gameObject;
				PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "UnityCircle", "UnityCircle");
				PhaserSprite phaserSprite4 = phaserSprite3.setScale(32f, (float?)(object)0);
				PhaserSprite phaserSprite5 = phaserSprite4.setTint(35071u);
				PhaserSprite phaserSprite6 = phaserSprite5.setBlendMode(BlendMode.Add);
				GameObject gameObject4 = phaserSprite6.gameObject;
				((UnityEngine.Object)gameObject4).SetName("_groundFx");
				_groundFx = phaserSprite6;
				GenerateParticleSystems();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00c7: Expected O, but got I4
		//IL_00de: Expected I, but got O
		//IL_0040: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 2f;
		_isCullable = false;
		_isBroken = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		BaseBody baseBody = body;
		baseBody._velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = false;
		InitVfx();
		StartRotation();
		SetTargetPosition();
		MoveToTargetPosition();
	}

	private void InitVfx()
	{
		PhaserSprite phaserSprite = _bottleSprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _groundFx.setAlpha(0f);
		float num = _weapon.PArea();
		Circle circle = new Circle();
		object obj = default(object);
		float num2 = (float)obj * 16f;
		float radius = num2 * 3f;
		circle._x = 0f;
		circle._radius = radius;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = circle;
		RenderingExtensions.SetEmitZone(_pfxEmitter1, emitZone);
		RenderingExtensions.SetQuantity(_pfxEmitter1, 1);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._source = circle;
		emitZone2._type = EmitZoneType.Random;
		RenderingExtensions.SetEmitZone(_pfxEmitter2, emitZone2);
		RenderingExtensions.SetQuantity(_pfxEmitter2, 2);
	}

	private void StartRotation()
	{
		//IL_0152: Expected O, but got I
		//IL_003e: Expected O, but got I8
		//IL_009c: Expected I, but got O
		//IL_0112: Expected I4, but got I8
		//IL_0120: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TP_Hydrostorm2_BoraProjectile tP_Hydrostorm2_BoraProjectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_Hydrostorm2_BoraProjectile = (TP_Hydrostorm2_BoraProjectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49 @ rax_v3 (should have been resolved before IL gen)");
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 400f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.repeat = -1;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
	}

	private void SetTargetPosition()
	{
		//IL_01da->IL016e: Incompatible stack heights: 1 vs 0
		Vector2 randomPointOnScreen = GetRandomPointOnScreen();
		Weapon weapon = _weapon;
		float2 targetPos = default(float2);
		_targetPos = (Vector3)targetPos;
		_ = 0;
		if ((object)_weapon != null)
		{
			if (weapon.IsHoming)
			{
				Weapon weapon2 = _weapon;
				if ((object)GM.Core == null)
				{
					goto IL_0124;
				}
				Transform transform = GM.Core.FindClosestEnemyToPlayer(((Equipment)weapon2)._003COwner_003Ek__BackingField);
				if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
				{
					Transform transform2 = transform.transform;
					if ((object)transform2 == null)
					{
						goto IL_0124;
					}
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
					_targetPos = ret;
					_ = 0;
				}
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
				{
					base.position = targetPos;
					return;
				}
			}
		}
		goto IL_0124;
		IL_0124:
		throw new NullReferenceException();
	}

	private Vector2 GetRandomPointOnScreen()
	{
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v16 (UnityEngine.Bounds)+10]");
				float num = 0f * 2f;
				Vector2 vector = default(Vector2);
				float num2 = (float)vector * 2f;
				float num3 = num2 * 0.5f;
				float num4 = num2 * 0.5f;
				float maxInclusive = num3 + (float)ret;
				float minInclusive = (float)ret - num4;
				float num5 = UnityEngine.Random.Range(minInclusive, maxInclusive);
				float num6 = num * 0.5f;
				float num7 = num * 0.5f;
				object obj = default(object);
				float maxInclusive2 = num6 + (float)obj;
				float minInclusive2 = (float)obj - num7;
				float num8 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
				return vector;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void MoveToTargetPosition()
	{
		//IL_000d: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00e1: Expected O, but got Ref
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(TP_Hydrostorm2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Hydrostorm2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Hydrostorm2_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v7+FFFFFFF8+v70 @ rax_v6*8]");
			if (0 == (nint)typeof(TP_Hydrostorm2_Weapon))
			{
				if (_bottlePositionTween != null)
				{
					DG.Tweening.TweenExtensions.Kill(_bottlePositionTween);
				}
				object obj3 = default(object);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&obj3), 0.6f);
				TweenCallback tweenCallback = Break;
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_bottlePositionTween = tweenerCore;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void Break()
	{
		//IL_0092: Expected O, but got I4
		//IL_00b2: Expected I, but got O
		//IL_00cf: Expected O, but got I
		//IL_013d: Expected O, but got I8
		//IL_041b: Expected O, but got I4
		//IL_0447: Expected O, but got I4
		//IL_0340: Expected F4, but got I4
		if (_isBroken)
		{
			return;
		}
		BaseBody baseBody = body;
		_isBroken = true;
		baseBody._enable = true;
		PhaserSprite phaserSprite = _bottleSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _groundFx.setAlpha(0.2f);
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		_pfxEmitterExplosionManager.EmitParticleAt(vector);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		object obj2 = vector + vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			weapon = (Weapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v494 @ rax_v17 (should have been resolved before IL gen)");
		float groundArea = 0.5f * (float)obj2;
		_groundArea = groundArea;
		if (_groundScaleInTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundScaleInTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, _groundArea, 0.2f);
		TweenCallback tweenCallback = GrowGroundSize;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_groundScaleInTween = tweenerCore;
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num3 = hitBoxDelay * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num3, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num4 = _weapon.PDuration();
		float num5 = num3 * 1.5f;
		Action onComplete2 = StartDespawn;
		float duration = num5 * 0.001f;
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj3 = _indexInWeapon - 4;
		soundConfig.Rate = 2f;
		float detune = (float)obj3 * 50f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Holywater, soundConfig, 200f, 12, flag ? 1 : 0);
		Weapon weapon2 = _weapon;
		if (weapon2.IsHoming)
		{
			SeekNearestEnemyToOwner();
		}
	}

	private void GrowGroundSize()
	{
		float num = _weapon.PSpeed();
		Weapon weapon = _weapon;
		float num2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
		float num3 = default(float);
		bool flag = 1f > num3;
		float num4 = 1f;
		if (!flag)
		{
			num4 = num3;
		}
		float num5 = num3 * _groundArea;
		float num6 = num5 * num4;
		bool flag2 = num6 > 12f;
		float endValue = 12f;
		if (!flag2)
		{
			endValue = num6;
		}
		float num7 = _weapon.PDuration();
		float num8 = num3 * 1.5f;
		float num9 = num8 - 200f;
		float duration = num9 * 0.001f;
		if (_groundGrowTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundGrowTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> groundGrowTween = ShortcutExtensions.DOScale(_cachedTransform, endValue, duration);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_groundGrowTween = groundGrowTween;
	}

	public unsafe void SeekNearestEnemyToOwner()
	{
		//IL_01cd: Expected O, but got F4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_007a->IL0132: Incompatible stack heights: 1 vs 0
		if (!_isBroken)
		{
			return;
		}
		Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
		Vector2 groundVelocity = default(Vector2);
		if ((object)nearestEnemyTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v4 (UnityEngine.Transform)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v4 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v4 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				float2 float5 = base.position;
				Vector2 vector = (Vector2)(this + 224);
				Vector2 currentDirection = (Vector2)((object)ret - (object)float5);
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				groundVelocity = GroundVelocity;
				BaseBody baseBody = body;
				baseBody._velocity = groundVelocity;
			}
		}
		object obj4 = UnityEngine.Random.value;
		float num = (float)groundVelocity - 0.5f;
		float num2 = num * 250f;
		float num3 = num2 + 1000f;
		if (_groundHomingTimer != null)
		{
			_groundHomingTimer.Cancel();
		}
		Action onComplete = SeekNearestEnemyToOwner;
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer groundHomingTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_groundHomingTimer = groundHomingTimer;
	}

	private void PlaySfx()
	{
		//IL_004d: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = _indexInWeapon - 4;
		float detune = (float)obj * 50f;
		soundConfig.Rate = 2f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Holywater, soundConfig, 200f, 12, time);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00a2: Expected O, but got I4
		//IL_00b4: Unsupported input type for neg.
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		if (_isBroken)
		{
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			_pfxEmitterManager.EmitParticleAt(pos);
		}
		if (!_isBroken)
		{
			return;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		object obj3 = 0 - obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num2 = default(int);
		ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(num2);
		PhaserSprite phaserSprite = _groundFx.setDepth(num2);
		if (_isBroken)
		{
			Weapon weapon = _weapon;
			if (!weapon.IsHoming)
			{
				float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				float2 float7 = base.position;
				Vector2 vector = (Vector2)(this + 224);
				Vector2 currentDirection = float6 - float7;
				object obj5 = default(object);
				object obj6 = default(object);
				object obj4 = obj5 - obj6;
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				Vector2 groundVelocity = GroundVelocity;
				BaseBody baseBody = body;
				baseBody._velocity = groundVelocity;
			}
		}
	}

	private void UpdateGroundPfx()
	{
		if (_isBroken)
		{
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			_pfxEmitterManager.EmitParticleAt(pos);
		}
	}

	private void UpdateGroundDepth()
	{
		//IL_005b: Expected O, but got I4
		//IL_006d: Unsupported input type for neg.
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (_isBroken)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num = renderer.pixelHeight >> 31;
			object obj = renderer.pixelHeight - num;
			object obj2 = obj >> 1;
			object obj3 = 0 - obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num2 = default(int);
			ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(num2);
			PhaserSprite phaserSprite = _groundFx.setDepth(num2);
		}
	}

	private unsafe void UpdateGroundVelocity()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (_isBroken)
		{
			Weapon weapon = _weapon;
			if (!weapon.IsHoming)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				float2 float6 = base.position;
				Vector2 vector = (Vector2)(this + 224);
				Vector2 currentDirection = float5 - float6;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				Vector2 groundVelocity = GroundVelocity;
				BaseBody baseBody = body;
				baseBody._velocity = groundVelocity;
			}
		}
	}

	private void StartDespawn()
	{
		//IL_0042: Expected I, but got O
		//IL_0076: Expected I, but got O
		//IL_00aa: Expected I, but got O
		//IL_00de: Expected I, but got O
		//IL_0226: Expected O, but got I
		//IL_029e: Expected I, but got O
		BaseBody baseBody = body;
		_isBroken = false;
		baseBody._enable = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		if (_groundHomingTimer != null)
		{
			_groundHomingTimer.Cancel();
			nint num = unchecked((nint)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9E0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9E0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v429 @ rax_v15 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurveBlittable minMaxCurveBlittable = default(ParticleSystem.MinMaxCurveBlittable);
		ParticleSystem.MinMaxCurve minMaxCurve = ParticleSystem.MinMaxCurveBlittable.ToMinMaxCurve(ref minMaxCurveBlittable);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Hydrostorm2_BoraProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		float duration = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
		if (_groundFadeOutTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundFadeOutTween);
		}
		PhaserSprite groundFx = _groundFx;
		TweenerCore<Color, Color, ColorOptions> groundFadeOutTween = DOTweenModuleSprite.DOFade(groundFx._spriteRenderer, 0f, duration);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_groundFadeOutTween = groundFadeOutTween;
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_bottlePositionTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_bottlePositionTween);
		}
		if (_groundScaleInTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundScaleInTween);
		}
		if (_groundGrowTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundGrowTween);
		}
		if (_groundFadeOutTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundFadeOutTween);
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_groundHomingTimer != null)
		{
			_groundHomingTimer.Cancel();
		}
		base.Despawn();
	}

	private void KillTweens()
	{
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_bottlePositionTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_bottlePositionTween);
		}
		if (_groundScaleInTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundScaleInTween);
		}
		if (_groundGrowTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundGrowTween);
		}
		if (_groundFadeOutTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_groundFadeOutTween);
		}
	}

	private void KillTimers()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_groundHomingTimer != null)
		{
			_groundHomingTimer.Cancel();
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01c4: Expected O, but got Ref
		//IL_01de: Expected native int or pointer, but got O
		//IL_0b48: Expected O, but got I4
		//IL_01f6: Expected O, but got Ref
		//IL_021d: Expected O, but got I
		//IL_0237: Expected native int or pointer, but got O
		//IL_0251: Expected O, but got I
		//IL_027f: Expected O, but got I4
		//IL_0298: Expected O, but got Ref
		//IL_02b2: Expected native int or pointer, but got O
		//IL_0b65: Expected O, but got I4
		//IL_02e4: Expected O, but got Ref
		//IL_02fe: Expected native int or pointer, but got O
		//IL_0b9f: Expected O, but got I
		//IL_04f9: Expected O, but got Ref
		//IL_0513: Expected native int or pointer, but got O
		//IL_0beb: Expected O, but got I
		//IL_0551: Expected O, but got Ref
		//IL_0572: Expected O, but got I
		//IL_058c: Expected native int or pointer, but got O
		//IL_05a6: Expected O, but got I
		//IL_05d4: Expected O, but got I4
		//IL_05ed: Expected O, but got Ref
		//IL_0607: Expected native int or pointer, but got O
		//IL_0c25: Expected O, but got I
		//IL_063f: Expected O, but got Ref
		//IL_0659: Expected native int or pointer, but got O
		//IL_0c57: Expected O, but got I
		//IL_06aa: Expected O, but got I
		//IL_080f: Expected O, but got Ref
		//IL_0836: Expected O, but got I
		//IL_0850: Expected native int or pointer, but got O
		//IL_086a: Expected O, but got I
		//IL_0898: Expected O, but got I4
		//IL_08b1: Expected O, but got Ref
		//IL_08cb: Expected native int or pointer, but got O
		//IL_0ca3: Expected O, but got I
		//IL_0903: Expected O, but got Ref
		//IL_091d: Expected native int or pointer, but got O
		//IL_0cdd: Expected O, but got I
		//IL_09c5: Expected O, but got Ref
		//IL_09ec: Expected O, but got I
		//IL_0a06: Expected native int or pointer, but got O
		//IL_0a25: Expected O, but got I
		//IL_0a53: Expected O, but got I4
		//IL_0a6c: Expected O, but got Ref
		//IL_0a86: Expected native int or pointer, but got O
		//IL_0d17: Expected O, but got I
		//IL_0abe: Expected O, but got Ref
		//IL_0ad8: Expected native int or pointer, but got O
		//IL_0d51: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitterManager = pfxEmitterManager;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ProjectileFlameHoly2");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ProjectileFlameBlue2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+310]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = circle;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter1 = pfxEmitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameHoly2");
		}
		else
		{
			int num3 = list2._size + 1;
			list2._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameBlue2");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+310]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0.2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0.25f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+310]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = circle;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _pfxEmitterManager.CreateEmitter(particleSystemConfig2);
		_pfxEmitter2 = pfxEmitter2;
		GameObject gameObject2 = base.gameObject;
		ParticleEmitterManager pfxEmitterExplosionManager = gameObject2.AddComponent<ParticleEmitterManager>();
		_pfxEmitterExplosionManager = pfxEmitterExplosionManager;
		ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
		List<string> list3 = new List<string>();
		int version5 = list3._version + 1;
		list3._version = version5;
		string[] items5 = list3._items;
		if (list3._size >= items5.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"HitCloud2");
		}
		else
		{
			int num5 = list3._size + 1;
			list3._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig3._frame = list3;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+310]");
		particleSystemConfig3._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
		particleSystemConfig3._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(150f);
		particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
		particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.25f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+220]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+230]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+88]");
		_ = 0;
		particleSystemConfig3._on = false;
		ParticleSystem particleSystem = _pfxEmitterExplosionManager.CreateEmitter(particleSystemConfig3);
		ParticleSystemConfig particleSystemConfig4 = new ParticleSystemConfig("vfx");
		List<string> list4 = new List<string>();
		list4.Add("HitCloud1");
		particleSystemConfig4._frame = list4;
		ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
		_ = 0;
		_ = 3;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+310]");
		particleSystemConfig4._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+240]");
		particleSystemConfig4._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+250]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(150f);
		particleSystemConfig4._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 608));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(1f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+260]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+270]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
		particleSystemConfig4._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 640));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+290]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
		particleSystemConfig4._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D8]");
		_ = 0;
		particleSystemConfig4._on = false;
		ParticleSystem particleSystem2 = _pfxEmitterExplosionManager.CreateEmitter(particleSystemConfig4);
	}

	public TP_Hydrostorm2_BoraProjectile()
	{
		//IL_001f: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._002Ector();
	}

	private void _003CBreak_003Eb__41_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
