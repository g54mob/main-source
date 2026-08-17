using System;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MirageRobeProjectile : Projectile
{
	private Timer _expireTimer;

	private string _textureName;

	private string _frameName;

	private float _amount;

	private MultiTargetTween _fadeOutTween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0301: Expected O, but got I4
		//IL_003c: Expected F4, but got I
		//IL_005b: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		//IL_007f: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_032e: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		//IL_025b: Expected I4, but got O
		//IL_0299: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
		CheckRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		float num = 0f;
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		Color color = default(Color);
		BlendMode blendMode = default(BlendMode);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(((ArcadeSprite)this)._spriteRenderer, (Color)(&obj), (Color)(&obj2), (Color)(&obj3), color, blendMode);
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		float num2 = weapon.PArea();
		if (!(1f > num))
		{
			num = 1f;
		}
		ArcadeSprite arcadeSprite2 = setScale(num, (float?)(object)0);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		SpriteAnimation spriteAnimation = characterController._spriteAnimation;
		float? sprite2;
		if (((BaseSpriteAnimation)spriteAnimation)._currentAnimation != null)
		{
			Sprite sprite = ((BaseSpriteAnimation)spriteAnimation)._currentAnimation.GetFrame();
			sprite2 = (float?)sprite;
		}
		else
		{
			sprite2 = (float?)(object)0;
		}
		_renderer.sprite = (Sprite)sprite2;
		int num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
		int sortingOrder = num3 + 1;
		_renderer.sortingOrder = sortingOrder;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		ArcadeSprite arcadeSprite3 = setFlipX(characterController2._isFlipped);
		ArcadeSprite arcadeSprite4 = setAlpha(0.65f);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num4 = weapon.PDuration();
		Action onComplete = delegate
		{
			FadeOut();
		};
		float duration = num * 0.001f;
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)color != 0, (MonoBehaviour)blendMode, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		Weapon weapon2 = _weapon;
		_amount = currentWeaponData._003Camount_003Ek__BackingField;
		if (weapon2.IsHoming)
		{
			_speed = 0.2f;
			Transform transform = base.AimForNearestEnemy(rotate: false);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0054: Invalid comparison between I4 and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (!(0f < --_amount))
		{
			FadeOut();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			float num = _weapon.PDuration();
			bool flag = component.Freeze(0f);
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
			object obj2 = default(object);
			if (obj2 != null)
			{
				GameManager core2 = GM.Core;
				float2 float5 = component.position;
				Vector2 pos = default(Vector2);
				core2._arcanaManager.TriggerColdExplosion(pos);
			}
		}
	}

	public void FadeOut()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			base.Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
	}

	private void _003CInitProjectile_003Eb__5_0()
	{
		FadeOut();
	}

	private void _003CFadeOut_003Eb__7_0()
	{
		base.Despawn();
	}
}
