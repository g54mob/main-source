using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BubbleProjectile : Projectile
{
	private MultiTargetTween _speedTween;

	private MultiTargetTween _tween1;

	private float _saveVelX;

	private float _saveVelY;

	private bool _canBounce;

	private Vector2 _aimVec;

	public float _BombDeceleration = 1f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("circle8", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public void SetColor(uint color)
	{
		string[] array = new string[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		int num = random.Next(0, array.Length);
		Sprite sprite = SpriteManager.GetSprite(array[num], "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_04a3: Expected O, but got I4
		//IL_04cd: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Ref, but got Unknown
		//IL_0100: Expected O, but got I4
		//IL_013c: Expected O, but got I4
		//IL_01d2: Expected I, but got O
		//IL_0388: Expected I, but got O
		//IL_03eb: Expected O, but got I4
		//IL_0414: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_aimVec = (Vector2)0;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		BaseBody baseBody2 = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		ArcadeSprite arcadeSprite3 = setVisible(visible: true);
		ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
		ref Vector2 forNearestEnemy = ref *(Vector2*)(this + 236);
		_isCullable = true;
		_saveVelX = 1f;
		_saveVelY = 1f;
		Transform transform = SetForNearestEnemy(ref forNearestEnemy);
		float num = weapon.PSpeed();
		float num2 = weapon.PSpeed();
		object obj = default(object);
		float xVel = (float)obj * (float)_aimVec;
		setVelocity(xVel, (float?)(object)1);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float num3 = (float)_indexInWeapon * 50f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = num3;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bubbles, soundConfig, 100f, 12, time);
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		_BombDeceleration = 1f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_BombDeceleration", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			float num5 = weapon.PDuration();
			float num6 = (tweenConfig.delay = num3 * 0.25f);
			float num7 = weapon.PDuration();
			float duration = num6 * 0.75f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.duration = duration;
			TweenCallback onComplete = delegate
			{
				FadeOut();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween speedTween = Tweens.Add(tweenConfig);
			_speedTween = speedTween;
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_cachedTransform != null)
			{
				nint num8 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			float num9 = weapon.PArea();
			tweenConfig2.scaleX = (float?)(object)1;
			float num10 = weapon.PArea();
			tweenConfig2.duration = 250f;
			tweenConfig2.scaleY = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_003f: Expected O, but got I4
				ArcadeSprite arcadeSprite5 = setAlpha(0.65f);
				ArcadeSprite arcadeSprite6 = setVisible(visible: true);
				ArcadeSprite arcadeSprite7 = setScale(0f, (float?)(object)1);
				_canBounce = false;
			};
			tweenConfig2.onStart = onStart;
			TweenCallback onComplete2 = delegate
			{
				_canBounce = true;
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween tween = Tweens.Add(tweenConfig2);
			_tween1 = tween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public void FadeOut()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
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
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
	{
	}

	public void Decelerate()
	{
		_saveVelX = 0f;
	}

	private void JustBounce()
	{
		if (_canBounce)
		{
			float saveVelX = _saveVelX * -1f;
			_saveVelX = saveVelX;
			float saveVelY = _saveVelY * -1f;
			_saveVelY = saveVelY;
		}
	}

	public override void InternalUpdate()
	{
		//IL_0062: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected F4, but got Unknown
		float xVel = (float)_aimVec * _saveVelX;
		setVelocity(xVel, (float?)(object)1);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num = height ^ 0;
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	public override void Despawn()
	{
		//IL_006c: Expected O, but got I4
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		_speedTween = null;
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		_tween1 = null;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		_saveVelX = 0f;
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		FadeOut();
	}

	private void _003CInitProjectile_003Eb__9_1()
	{
		//IL_003f: Expected O, but got I4
		ArcadeSprite arcadeSprite = setAlpha(0.65f);
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)1);
		_canBounce = false;
	}

	private void _003CInitProjectile_003Eb__9_2()
	{
		_canBounce = true;
	}

	private void _003CFadeOut_003Eb__10_0()
	{
		Despawn();
	}
}
