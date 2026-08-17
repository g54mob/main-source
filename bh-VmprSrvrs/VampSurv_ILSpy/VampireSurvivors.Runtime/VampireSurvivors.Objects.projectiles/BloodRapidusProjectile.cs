using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodRapidusProjectile : Projectile
{
	private float _amount;

	private BloodAstronomiaWeapon _trueWeapon;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Timer _expireTimer;

	private Timer _activationTimer;

	private List<string> _frameNames;

	private MultiTargetTween _localTween;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0181: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00c0: Expected O, but got I
		//IL_009d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		bool flag = (object)weapon == null;
		Weapon trueWeapon = null;
		Weapon weapon2 = weapon;
		if (flag)
		{
			goto IL_0156;
		}
		nint num = (nint)typeof(BloodAstronomiaWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v22+FFFFFFF8+v67 @ rax_v18*8]");
			if (0 == (nint)typeof(BloodAstronomiaWeapon))
			{
				obj3 = 1;
				goto IL_0165;
			}
		}
		obj3 = 0;
		goto IL_0165;
		IL_0156:
		_trueWeapon = (BloodAstronomiaWeapon)trueWeapon;
		string text = Extensions.PickRnd(_frameNames);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		ArcadeSprite arcadeSprite3 = setTint(16711680u);
		return;
		IL_0165:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		weapon2 = (Weapon)num2;
		if (!flag2)
		{
			trueWeapon = weapon;
			weapon2 = (Weapon)num2;
		}
		goto IL_0156;
	}

	public void OverrideWeaponData(Weapon weapon)
	{
		//IL_0023: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_00cc: Expected I, but got O
		//IL_0122: Expected O, but got I4
		//IL_0150: Expected I4, but got I8
		//IL_016c: Expected O, but got I4
		//IL_0373: Expected I, but got O
		//IL_03d7: Expected O, but got I4
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody2 = body.setCircle(36f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setVisible(visible: true);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		float num9;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.duration = 1000f;
			tweenConfig.yoyo = true;
			tweenConfig.repeat = -1;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0010: Expected O, but got I4
				ArcadeSprite arcadeSprite5 = setScale(1f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
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
			float num2 = weapon.PInterval();
			float num3 = weapon.PDuration();
			Action onComplete2 = delegate
			{
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				FadeOut();
			};
			float num4 = 1f + 1000f;
			float num5 = num4 + 1f;
			float num6 = num5 * 0.001f;
			Timer expireTimer = Timers.Register(num6, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			ArcadeSprite arcadeSprite4 = setAlpha(0.1f);
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 200f;
				tweenConfig2.alpha = (float?)(object)1;
				TweenCallback onStart2 = delegate
				{
					ArcadeSprite arcadeSprite5 = setAlpha(0.1f);
				};
				tweenConfig2.onStart = onStart2;
				MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
				_alphaTween = alphaTween;
				float num8 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PAmount();
				if (!(num6 > 10f))
				{
					object obj3 = 10f & -2147483649L;
					bool flag = (nint)obj3 <= 2139095040;
					num9 = num6;
					if (flag)
					{
						goto IL_04ee;
					}
				}
				num9 = 10f;
				goto IL_04ee;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
		IL_04ee:
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float amount = (float)currentWeaponData._003Camount_003Ek__BackingField + num9;
		_amount = amount;
	}

	public override void InternalUpdate()
	{
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		base.Despawn();
	}

	public override bool CanExplode()
	{
		return true;
	}

	public override void Explode(Vector2? pos = null)
	{
		//IL_00cb: Expected O, but got I4
		//IL_0052: Expected F4, but got O
		//IL_0077: Invalid comparison between I4 and F4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 200f, 3, num);
		float2 float5 = base.position;
		_trueWeapon.SpawnBloodExplosionVfxAt((float)float5, 0.4f, _amount, num);
		if (!(0f < --_amount))
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			FadeOut();
		}
	}

	private void FadeOut()
	{
		//IL_00cc: Expected I, but got O
		//IL_0130: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0167: Expected I, but got O
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
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
			tweenConfig.duration = 200f;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.scaleY = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodRapidusProjectile>)+370]");
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

	public BloodRapidusProjectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella01");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella02");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella05");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella06");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella07");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella08");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella09");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella10");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella11");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"vfx_constella12");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frameNames = list;
		base._002Ector();
	}

	private void _003COverrideWeaponData_003Eb__10_2()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	private void _003COverrideWeaponData_003Eb__10_0()
	{
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003COverrideWeaponData_003Eb__10_1()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}

	private void _003COverrideWeaponData_003Eb__10_3()
	{
		ArcadeSprite arcadeSprite = setAlpha(0.1f);
	}
}
