using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodGarlicProjectile : Projectile
{
	private Timer _expireTimer;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _angleTween;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setAlpha(0.1f);
	}

	public void OverrideWeaponData(Weapon weapon)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_04f6: Expected O, but got I4
		//IL_023d: Expected I, but got O
		//IL_0297: Expected I4, but got I8
		//IL_02dd: Expected O, but got I4
		//IL_039e: Expected I, but got O
		//IL_0414: Expected I4, but got I8
		//IL_0422: Expected O, but got I4
		BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController._magnet;
		EggFloat eggFloat = magnet.Radius / 32f;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF1184h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_04af;
			}
		}
		num = 3.4028235E+38f;
		goto IL_04af;
		IL_04af:
		float num2 = weapon.PArea();
		float num3 = default(float);
		if (!(num > num3))
		{
			num = num3;
		}
		ArcadeSprite arcadeSprite2 = setScale(num, (float?)(object)0);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num4 = weapon.PDuration();
		Action onComplete = delegate
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			FadeOut();
		};
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.repeatDelay = 100f;
		tweenConfig.duration = 1000f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			ArcadeSprite arcadeSprite4 = setAlpha(0.1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num6 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 6000f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.repeat = -1;
		tweenConfig2.angle = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			base.angle = 0f;
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig2);
		_angleTween = angleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		ArcadeSprite arcadeSprite3 = setDepth(0);
	}

	private void FadeOut()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodGarlicProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void _003COverrideWeaponData_003Eb__4_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}

	private void _003COverrideWeaponData_003Eb__4_1()
	{
		ArcadeSprite arcadeSprite = setAlpha(0.1f);
	}

	private void _003COverrideWeaponData_003Eb__4_2()
	{
		base.angle = 0f;
	}
}
