using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodPentagramProjectile : Projectile
{
	private Timer _expireTimer;

	private MultiTargetTween _alphaTween;

	private BloodAstronomiaWeapon _trueWeapon;

	private float _amount;

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
			goto IL_0101;
		}
		nint num = (nint)typeof(BloodAstronomiaWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v16+FFFFFFF8+v63 @ rax_v12*8]");
			if (0 == (nint)typeof(BloodAstronomiaWeapon))
			{
				obj3 = 1;
				goto IL_0110;
			}
		}
		obj3 = 0;
		goto IL_0110;
		IL_0101:
		_trueWeapon = (BloodAstronomiaWeapon)trueWeapon;
		return;
		IL_0110:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = weapon;
		}
		goto IL_0101;
	}

	public void OverrideWeaponData(Weapon weapon)
	{
		//IL_0042: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_01f5: Expected I4, but got O
		BaseBody baseBody = body;
		baseBody._enable = true;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
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
				goto IL_0210;
			}
		}
		num3 = 10f;
		goto IL_0210;
		IL_0210:
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num4 = (_amount = (float)currentWeaponData._003Camount_003Ek__BackingField + num3);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num5 = weapon.PInterval();
		float num6 = weapon.PDuration();
		Action action = delegate
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			FadeOut();
		};
		float num7 = num4 + num4;
		float duration = num7 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
			ArcadeSprite arcadeSprite3 = setDepth((int)action);
			return;
		}
		throw new NullReferenceException();
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
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 200f, 6, num);
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

	public override void Despawn()
	{
		base.Despawn();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
	}

	private void FadeOut()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 500f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void _003COverrideWeaponData_003Eb__5_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}
}
