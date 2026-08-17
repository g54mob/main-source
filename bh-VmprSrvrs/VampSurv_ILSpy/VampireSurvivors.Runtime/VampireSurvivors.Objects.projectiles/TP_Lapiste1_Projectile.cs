using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Lapiste1_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public float detune;

		internal void _003CPlaySfx_003Eb__0()
		{
			//IL_006a: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float num = detune + 500f;
			soundConfig.Detune = num;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig, 200f, 5, time);
		}
	}

	private const float Radius = 16f;

	private const float ScaleModifier = 1.5f;

	private readonly Vector2 BaseOffset;

	private TP_Lapiste1_Weapon _trueWeapon;

	private PhaserSprite _knuckleSprite;

	private int _cachedAmount;

	private float _cachedArea;

	private int _repeatCounter;

	private Timer _hitBoxTimer;

	private Tween _scaleTween;

	protected override void Awake()
	{
		//IL_0194: Expected O, but got I4
		//IL_0194: Expected I4, but got O
		//IL_01fc: Expected O, but got I4
		//IL_01fc: Expected I4, but got O
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
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1646]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Knuckle01");
			GameObject gameObject2 = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject2).SetName("KnuckleSprite");
			_knuckleSprite = phaserSprite;
			string text = default(string);
			int num = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Knuckle", 3, 4, vector, text, num, flag);
			PhaserSprite knuckleSprite = _knuckleSprite;
			bool autoSetAnimation = default(bool);
			knuckleSprite._spriteAnimation.AddAnimation("loop", animationFrames, 18, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_KnuckleDusters", 4, 14, vector, text, num, flag);
			PhaserSprite knuckleSprite2 = _knuckleSprite;
			knuckleSprite2._spriteAnimation.AddAnimation("loop_alt", animationFrames2, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0027: Expected I, but got O
		//IL_002f: Expected I, but got O
		//IL_003f: Expected O, but got I
		//IL_00bf: Expected O, but got I4
		//IL_007b: Expected O, but got I
		//IL_00b1: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_0140: Expected I4, but got F4
		//IL_03f3: Expected O, but got F4
		//IL_02d3: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_Lapiste1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_036c;
		}
		nint num = (nint)typeof(TP_Lapiste1_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Lapiste1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v65+FFFFFFF8+v71 @ rax_v60*8]");
			if (0 == (nint)typeof(TP_Lapiste1_Weapon))
			{
				obj3 = 1;
				goto IL_037b;
			}
		}
		obj3 = 0;
		goto IL_037b;
		IL_037b:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (TP_Lapiste1_Weapon)_weapon;
		}
		goto IL_036c;
		IL_036c:
		_trueWeapon = trueWeapon;
		Transform parent = _weapon.transform;
		Transform transform = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		int cachedAmount = (int)_weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		_cachedAmount = cachedAmount;
		float num4 = _weapon.PArea();
		float cachedArea = default(float);
		_cachedArea = cachedArea;
		_repeatCounter = 0;
		float num5 = UnityEngine.Random.Range(-0.025f, 0.025f);
		float num6 = UnityEngine.Random.Range(-0.025f, 0.025f);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite = _knuckleSprite.setLocalPosition(localPosition);
		TP_Lapiste1_Weapon trueWeapon2 = _trueWeapon;
		PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(scale: (!trueWeapon2._UseAltAnimation) ? 1f : 0.8f, component: _knuckleSprite);
		TP_Lapiste1_Weapon trueWeapon3 = _trueWeapon;
		bool flag2 = !trueWeapon3._UseAltAnimation;
		string animation = "loop";
		if (!flag2)
		{
			animation = "loop_alt";
		}
		PhaserSprite knuckleSprite = _knuckleSprite;
		knuckleSprite._spriteAnimation.SetAnimation(animation);
		ScaleIn();
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass14_0();
		object obj4 = UnityEngine.Random.value;
		float num7 = num6 - 0.5f;
		float num8 = num7 * 200f;
		float detune = num8 + 1000f;
		CS_0024_003C_003E8__locals3.detune = detune;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = CS_0024_003C_003E8__locals3.detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig, 200f, 5, time);
		TweenCallback callback = delegate
		{
			//IL_006a: Expected O, but got I4
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			float detune2 = CS_0024_003C_003E8__locals3.detune + 500f;
			soundConfig2.Detune = detune2;
			soundConfig2.Volume = (float?)(object)1;
			float time2 = default(float);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig2, 200f, 5, time2);
		};
		Tween tween = DOVirtual.DelayedCall(0.2f, callback);
	}

	private void InitSprite()
	{
		float num = UnityEngine.Random.Range(-0.025f, 0.025f);
		float num2 = UnityEngine.Random.Range(-0.025f, 0.025f);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite = _knuckleSprite.setLocalPosition(localPosition);
		TP_Lapiste1_Weapon trueWeapon = _trueWeapon;
		PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(scale: (!trueWeapon._UseAltAnimation) ? 1f : 0.8f, component: _knuckleSprite);
		TP_Lapiste1_Weapon trueWeapon2 = _trueWeapon;
		bool flag = !trueWeapon2._UseAltAnimation;
		string animation = "loop";
		if (!flag)
		{
			animation = "loop_alt";
		}
		PhaserSprite knuckleSprite = _knuckleSprite;
		knuckleSprite._spriteAnimation.SetAnimation(animation);
	}

	private void ScaleIn()
	{
		//IL_0160: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		float num = _weapon.PArea();
		object obj = default(object);
		float endValue = (float)obj * 1.5f;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.15f);
		TweenCallback tweenCallback = StartHitBoxTimer;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
	}

	private void PlaySfx()
	{
		//IL_00eb: Expected O, but got F4
		//IL_0079: Expected O, but got I4
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass14_0();
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float num2 = num * 200f;
		float detune = num2 + 1000f;
		CS_0024_003C_003E8__locals3.detune = detune;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = CS_0024_003C_003E8__locals3.detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig, 200f, 5, time);
		TweenCallback callback = delegate
		{
			//IL_006a: Expected O, but got I4
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			float detune2 = CS_0024_003C_003E8__locals3.detune + 500f;
			soundConfig2.Detune = detune2;
			soundConfig2.Volume = (float?)(object)1;
			float time2 = default(float);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Lapiste, soundConfig2, 200f, 5, time2);
		};
		Tween tween = DOVirtual.DelayedCall(0.2f, callback);
	}

	private void StartHitBoxTimer()
	{
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		if ((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField != null)
		{
			if (_hitBoxTimer != null)
			{
				_hitBoxTimer.Cancel();
			}
			Action onComplete = delegate
			{
				// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
				if (_repeatCounter >= _cachedAmount)
				{
					Despawn();
				}
				else
				{
					int repeatCounter = _repeatCounter + 1;
					_repeatCounter = repeatCounter;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					Weapon weapon2 = _weapon;
					WeaponData currentWeaponData2 = weapon2._currentWeaponData;
					if ((object)currentWeaponData2._003ChitBoxDelay_003Ek__BackingField != null)
					{
						if (_hitBoxTimer != null)
						{
							_hitBoxTimer.Cancel();
						}
						Action onComplete2 = _003CStartHitBoxTimer_003Eb__15_0;
						object obj2 = default(object);
						float duration2 = (float)obj2 * 0.001f;
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						Timer hitBoxTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
						_hitBoxTimer = hitBoxTimer2;
					}
					else
					{
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					}
				}
			};
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitBoxTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitBoxTimer = hitBoxTimer;
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	public override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		if (!characterController._isFlipped)
		{
		}
		if (_scaleTween != null)
		{
			float num = TweenExtensions.ElapsedPercentage(_scaleTween);
		}
		PhaserSprite phaserSprite = _knuckleSprite.setFlipX(characterController._isFlipped);
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void UpdatePosition()
	{
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		if (!characterController._isFlipped)
		{
		}
		if (_scaleTween != null)
		{
			float num = TweenExtensions.ElapsedPercentage(_scaleTween);
		}
		PhaserSprite phaserSprite = _knuckleSprite.setFlipX(characterController._isFlipped);
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	public override void Despawn()
	{
		PhaserSprite knuckleSprite = _knuckleSprite;
		SpriteAnimation spriteAnimation = knuckleSprite._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		base.Despawn();
	}

	public TP_Lapiste1_Projectile()
	{
		//IL_001f: Expected I, but got O
		//IL_0062: Expected O, but got F4
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		float num3 = (float)Vector2.oneVector * 0.16f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
		float num4 = 0f * 0.16f;
		BaseOffset = (Vector2)num3;
		base._002Ector();
	}

	private void _003CStartHitBoxTimer_003Eb__15_0()
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		if (_repeatCounter >= _cachedAmount)
		{
			Despawn();
			return;
		}
		int repeatCounter = _repeatCounter + 1;
		_repeatCounter = repeatCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		if ((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField != null)
		{
			if (_hitBoxTimer != null)
			{
				_hitBoxTimer.Cancel();
			}
			Action onComplete = _003CStartHitBoxTimer_003Eb__15_0;
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitBoxTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitBoxTimer = hitBoxTimer;
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}
}
