using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WineGlass2_Shard_Projectile : Projectile
{
	private List<string> frameNames;

	private bool hasHit;

	private PhaserSprite _sunraySprite;

	private Timer cullableTimer;

	private MultiTargetTween sunTween;

	private MultiTargetTween _scaleTween;

	private bool isDespawning;

	protected override void Awake()
	{
		//IL_0104: Expected O, but got I4
		//IL_0104: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		GameObject gameObject = GM.Core.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite sunraySprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_TeleportRay01");
		_sunraySprite = sunraySprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_TeleportRay", 1, 10, vector, text, num, flag);
		PhaserSprite sunraySprite2 = _sunraySprite;
		bool autoSetAnimation = default(bool);
		sunraySprite2._spriteAnimation.AddAnimation("sunray", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite phaserSprite = _sunraySprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _sunraySprite.setLocalPosition(vector);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0288: Expected O, but got F4
		//IL_02ad: Expected O, but got F4
		//IL_02bb: Expected O, but got F4
		//IL_01dc: Expected I, but got O
		//IL_023c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(10f, (float?)(object)0, (float?)(object)0);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		_isCullable = false;
		isDespawning = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
		BaseBody baseBody2 = body;
		hasHit = false;
		baseBody2._enable = true;
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		string text = Extensions.PickRnd(frameNames);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite2 = default(Sprite);
		ArcadeSprite arcadeSprite3 = setFrame(sprite2);
		Weapon weapon2 = _weapon;
		float num = weapon2.PSpeed();
		object obj = UnityEngine.Random.value;
		object obj3 = default(object);
		object obj2 = obj3 + obj3;
		float2 float5 = base.position;
		object obj4 = UnityEngine.Random.value;
		object obj5 = UnityEngine.Random.value;
		float num2 = (float)obj3 - 0.5f;
		float num3 = num2 * (float)obj2;
		float num4 = 1.0653532E+09f + num3;
		float2 float6 = default(float2);
		base.position = float6;
		if (cullableTimer != null)
		{
			cullableTimer.Cancel();
		}
		float num5 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		cullableTimer = timer;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num6 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj6 = default(object);
		bool flag = obj6 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		if (!hasHit)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj == null)
			{
				BeamHere();
				BaseBody baseBody = body;
				hasHit = true;
				baseBody._enable = false;
			}
		}
	}

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00cd: Expected O, but got I4
		//IL_00e8: Expected I, but got O
		if (!isDespawning)
		{
			isDespawning = true;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.scaleX = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_WineGlass2_Shard_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			TweenCallback onStart = delegate
			{
				//IL_0010: Expected O, but got I4
				ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		PhaserSprite phaserSprite = _sunraySprite.setVisible(visible: false);
		if (sunTween != null)
		{
			sunTween.Kill();
		}
		if (cullableTimer != null)
		{
			cullableTimer.Cancel();
		}
		base.Despawn();
	}

	private void BeamHere()
	{
		//IL_0209: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_0128: Expected I, but got O
		//IL_019a: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -200f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Recovery, soundConfig, 200f, 3, time);
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = _sunraySprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _sunraySprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = _sunraySprite.setScale(0f, (float?)(object)1);
		PhaserSprite sunraySprite = _sunraySprite;
		sunraySprite._spriteAnimation.SetAnimation("sunray");
		if (sunTween != null)
		{
			sunTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sunraySprite != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.yoyo = true;
		tweenConfig.scaleX = (float?)(object)1;
		TweenCallback onComplete = StartDespawn;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		sunTween = multiTargetTween;
	}

	public TP_WineGlass2_Shard_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food01");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food02");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food03");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food04");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food05");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food06");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food07");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food08");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food09");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food10");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food11");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food12");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food13");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food14");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items15 = list._items;
		if (list._size >= items15.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food15");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items16 = list._items;
		if (list._size >= items16.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food16");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items17 = list._items;
		if (list._size >= items17.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food17");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items18 = list._items;
		if (list._size >= items18.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food18");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items19 = list._items;
		if (list._size >= items19.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food19");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items20 = list._items;
		if (list._size >= items20.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food20");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items21 = list._items;
		if (list._size >= items21.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food21");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items22 = list._items;
		if (list._size >= items22.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food22");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items23 = list._items;
		if (list._size >= items23.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food23");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items24 = list._items;
		if (list._size >= items24.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food24");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items25 = list._items;
		if (list._size >= items25.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food25");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items26 = list._items;
		if (list._size >= items26.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food26");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items27 = list._items;
		if (list._size >= items27.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food27");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items28 = list._items;
		if (list._size >= items28.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food28");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items29 = list._items;
		if (list._size >= items29.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food29");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items30 = list._items;
		if (list._size >= items30.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food30");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items31 = list._items;
		if (list._size >= items31.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food31");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items32 = list._items;
		if (list._size >= items32.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food32");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items33 = list._items;
		if (list._size >= items33.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food33");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items34 = list._items;
		if (list._size >= items34.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food34");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items35 = list._items;
		if (list._size >= items35.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food35");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items36 = list._items;
		if (list._size >= items36.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food36");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items37 = list._items;
		if (list._size >= items37.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food37");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items38 = list._items;
		if (list._size >= items38.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Food38");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		frameNames = list;
		base._002Ector();
	}

	private void _003CStartDespawn_003Eb__10_0()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}
}
