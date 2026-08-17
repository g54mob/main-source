using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodLaurelProjectile : Projectile
{
	private Timer _expireTimer;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _imageTween;

	private MultiTargetTween _scaleTween;

	private float _amount;

	private BloodAstronomiaWeapon _trueWeapon;

	private Timer _activationTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		bool flag = (object)weapon == null;
		Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_012d;
		}
		nint num = (nint)typeof(BloodAstronomiaWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v20+FFFFFFF8+v63 @ rax_v16*8]");
			if (0 == (nint)typeof(BloodAstronomiaWeapon))
			{
				obj3 = 1;
				goto IL_013c;
			}
		}
		obj3 = 0;
		goto IL_013c;
		IL_012d:
		_trueWeapon = (BloodAstronomiaWeapon)trueWeapon;
		ArcadeSprite arcadeSprite2 = setTint(16711680u);
		BaseBody baseBody = body;
		baseBody._enable = false;
		return;
		IL_013c:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = weapon;
		}
		goto IL_012d;
	}

	public void OverrideWeaponData(Weapon weapon)
	{
		//IL_0042: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_011f: Expected O, but got I4
		//IL_02f1: Expected I, but got O
		//IL_034b: Expected I4, but got I8
		//IL_0391: Expected O, but got I4
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0530: Expected I, but got O
		//IL_05a2: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		BaseBody baseBody2 = body.setCircle(64f, (float?)(object)0, (float?)(object)0);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setAlpha(0.2f);
		float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		float num3;
		if (!(num2 > 10f))
		{
			object obj = 10f & -2147483649L;
			bool flag = (nint)obj <= 2139095040;
			num3 = num2;
			if (flag)
			{
				goto IL_063e;
			}
		}
		num3 = 10f;
		goto IL_063e;
		IL_065f:
		float num4;
		if (!(1f > num4))
		{
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		ArcadeSprite arcadeSprite3 = setDepth(0);
		return;
		IL_063e:
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num6 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		float amount = num6 * num6;
		_amount = amount;
		ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		Action onComplete = delegate
		{
			if (_activationTimer != null)
			{
				_activationTimer.Cancel();
			}
			BaseBody baseBody3 = body;
			baseBody3._enable = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer activationTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_activationTimer = activationTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num7 = weapon.PInterval();
		float num8 = weapon.PDuration();
		Action onComplete2 = delegate
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			FadeOut();
		};
		float num9 = 1f + 1000f;
		float num10 = num9 + 1f;
		float duration = num10 * 0.001f;
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_renderer != null)
		{
			nint num11 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.repeat = -1;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeatDelay = 100f;
		tweenConfig2.duration = 1000f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			ArcadeSprite arcadeSprite5 = setAlpha(0.2f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween imageTween = Tweens.Add(tweenConfig2);
		_imageTween = imageTween;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController._magnet;
		EggFloat eggFloat = magnet.Radius / 64f;
		num4 = eggFloat._eggVal + eggFloat._val;
		object obj4 = num4 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num4 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF4B4Ah\"");
				if (num4 == -1f / 0f)
				{
					num4 = -3.4028235E+38f;
				}
				goto IL_065f;
			}
		}
		num4 = 3.4028235E+38f;
		goto IL_065f;
	}

	public override void Despawn()
	{
		base.Despawn();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
	}

	public override bool CanExplode()
	{
		return true;
	}

	public override void Explode(Vector2? position = null)
	{
		//IL_00cf: Expected O, but got I4
		//IL_0056: Expected F4, but got I
		//IL_0056: Expected F4, but got I
		//IL_007b: Invalid comparison between I4 and F4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 200f, 3, num);
		BloodAstronomiaWeapon trueWeapon = _trueWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [position @ rdx (System.Nullable`1<UnityEngine.Vector2>)+4]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [position @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
		trueWeapon.SpawnBloodExplosionVfxAt(num2, 0f, 10f, num);
		if (!(0f < --_amount))
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			FadeOut();
		}
	}

	private void FadeOut()
	{
		//IL_011a: Expected I, but got O
		//IL_017e: Expected O, but got I4
		//IL_0199: Expected I, but got O
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLaurelProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void _003COverrideWeaponData_003Eb__8_0()
	{
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003COverrideWeaponData_003Eb__8_1()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}

	private void _003COverrideWeaponData_003Eb__8_2()
	{
		ArcadeSprite arcadeSprite = setAlpha(0.2f);
	}

	private void _003COverrideWeaponData_003Eb__8_3()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}
}
