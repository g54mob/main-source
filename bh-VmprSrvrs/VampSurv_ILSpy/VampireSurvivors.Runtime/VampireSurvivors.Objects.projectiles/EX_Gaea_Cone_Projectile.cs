using System;
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
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Gaea_Cone_Projectile : Projectile
{
	private Vector2 _collisionPos;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private uint[] _colors = new uint[5] { 8978431u, 65535u, 52428u, 11202286u, 34952u };

	private readonly BlendMode[] _blendModes = new BlendMode[4]
	{
		BlendMode.Normal,
		BlendMode.Screen,
		BlendMode.Screen,
		BlendMode.Screen
	};

	private SoundManager.SoundConfig _soundConfig;

	private float _life;

	private Transform _cachedSpriteTransform;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private PhaserSprite _lanceSprite;

	private Tween lifeTween;

	private Timer _hitboxTimer;

	protected virtual bool IsEvolved => false;

	public override float ProjectileSpeed
	{
		get
		{
			float num = _weapon.PSpeed();
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			CharacterData currentCharacterData = characterController._currentCharacterData;
			float num2 = GameManager.PlayerPxSpeed * currentCharacterData._003CmoveSpeed_003Ek__BackingField;
			object obj = default(object);
			float num3 = num2 * (float)obj;
			return num3 * _speed;
		}
	}

	protected override void Awake()
	{
		//IL_01a5: Expected O, but got I4
		//IL_0220->IL01aa: Incompatible stack heights: 1 vs 0
		//IL_018b->IL01aa: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "ex_cone2");
				if ((object)phaserSprite != null)
				{
					GameObject gameObject2 = phaserSprite.gameObject;
					if ((object)gameObject2 != null)
					{
						((UnityEngine.Object)gameObject2).SetName("GaeaCone");
						_lanceSprite = phaserSprite;
						if ((object)_lanceSprite != null)
						{
							Transform transform = _lanceSprite.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								if ((object)_lanceSprite != null)
								{
									PhaserSprite phaserSprite2 = _lanceSprite.setVisible(visible: false);
									if ((object)_lanceSprite != null)
									{
										PhaserSprite phaserSprite3 = _lanceSprite.setOrigin(0f, (float?)(object)1);
										return;
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

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0195: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00c2: Expected I4, but got I8
		//IL_00f4: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_01ae: Expected O, but got F4
		//IL_01ea: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		_isCullable = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		PhaserSprite phaserSprite = _lanceSprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _lanceSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _lanceSprite.setAlpha(1f);
		PhaserSprite phaserSprite4 = _lanceSprite.setDepth(-1993);
		Transform cachedSpriteTransform = _lanceSprite.transform;
		_cachedSpriteTransform = cachedSpriteTransform;
		_collisionPos = (Vector2)0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		_soundConfig = soundConfig;
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig2.Rate = 1f;
		float detune = num * 400f;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig2, 200f, 1, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 338 Invalid \"Jump target not found in method: 0x18726B2C0\"");
		throw new NullReferenceException();
	}

	private unsafe void OnRecycle()
	{
		//IL_0136: Expected O, but got I4
		//IL_0255: Expected I, but got O
		//IL_02b9: Expected O, but got I4
		//IL_03b4: Expected I, but got O
		//IL_0426: Expected O, but got I4
		//IL_0536: Expected F4, but got I
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected O, but got Unknown
		//IL_05d7: Expected O, but got Ref
		//IL_061f: Expected O, but got F4
		float num = (float)_indexInWeapon * 0.1f;
		bool flag = num > 0.1f;
		float num2 = 0.1f;
		if (!flag)
		{
			num2 = num;
		}
		float alpha = 0.5f - num2;
		PhaserSprite phaserSprite = _lanceSprite.setAlpha(alpha);
		VampireSurvivors.App.Tools.Extensions.Shuffle(_colors);
		uint[] colors = _colors;
		int num3 = _indexInWeapon % colors.Length;
		PhaserSprite phaserSprite2 = _lanceSprite.setTint(colors[num3]);
		BlendMode[] blendModes = _blendModes;
		int num4 = _indexInWeapon % blendModes.Length;
		PhaserSprite phaserSprite3 = _lanceSprite.setBlendMode((BlendMode)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref blendModes[num4]));
		float num5 = _weapon.PArea();
		float num6 = num - 1f;
		_life = 0f;
		float num7 = num6 * 0.5f;
		float num8 = num7 + 1f;
		float num9 = num8 * 60f;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite4 = RenderingExtensions.SetScale(_lanceSprite, 0f);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num10 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete2 = FadeOut;
			tweenConfig.onComplete = onComplete2;
			TweenCallback onStart = delegate
			{
				//IL_0010: Expected O, but got I4
				ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
			if (_tween2 != null)
			{
				_tween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Transform transform = _lanceSprite.transform;
			if ((object)transform != null)
			{
				nint num11 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 100f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.scale = (float?)(object)1;
			MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
			_tween2 = tween2;
			if (lifeTween != null)
			{
				TweenExtensions.Kill(lifeTween);
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EX_Gaea_Cone_Projectile)(object)dOSetter)._003COnRecycle_003Eb__20_2(0f);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			lifeTween = tweenerCore;
			Weapon weapon = _weapon;
			EX_Gaea_Cone_Projectile eX_Gaea_Cone_Projectile = (EX_Gaea_Cone_Projectile)(object)((Equipment)weapon)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v60 (VampireSurvivors.Objects.Projectiles.EX_Gaea_Cone_Projectile)+180]");
			float x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v60 (VampireSurvivors.Objects.Projectiles.EX_Gaea_Cone_Projectile)+184]");
			object obj3 = 0 ^ -0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018726BC3Fh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v60 (VampireSurvivors.Objects.Projectiles.EX_Gaea_Cone_Projectile)+180]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018726BC3Fh\"");
				if (obj3 == null)
				{
					x = 1f;
				}
			}
			eX_Gaea_Cone_Projectile._003COnRecycle_003Eb__20_2(x);
			Transform transform2 = _lanceSprite.transform;
			object obj4 = default(object);
			transform2.localEulerAngles = (Vector3)(&obj4);
			float num12 = num9 * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num13 = num12 * 2.5f;
			float num14 = (float)obj3 * num13;
			_collisionPos = (Vector2)num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num15 = num12 * -2.5f;
			float num16 = (float)obj3 * num15;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void FadeOut()
	{
		//IL_005e: Expected I, but got O
		//IL_00b4: Expected O, but got I4
		//IL_00fe: Expected I, but got O
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_lanceSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.alpha = (float?)(object)1;
		float num2 = _weapon.PDuration();
		float duration = default(float);
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.Linear;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Gaea_Cone_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween3 = tween;
	}

	public unsafe override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		Transform cachedSpriteTransform = _cachedSpriteTransform;
		bool flag = ((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr, ref *(Vector3*)(&value));
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _lanceSprite.setVisible(visible: false);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (lifeTween != null)
		{
			TweenExtensions.Kill(lifeTween);
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00ef: Invalid comparison between O and F4
		//IL_0131: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v6+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			object obj3 = default(object);
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && ((object)component._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && ((object)component._003CResDefang_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)))
			{
				bool flag = TryDefang(component);
			}
		}
	}

	private void _003COnRecycle_003Eb__20_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003COnRecycle_003Eb__20_3()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private float _003COnRecycle_003Eb__20_1()
	{
		return _life;
	}

	private void _003COnRecycle_003Eb__20_2(float x)
	{
		_life = x;
	}
}
