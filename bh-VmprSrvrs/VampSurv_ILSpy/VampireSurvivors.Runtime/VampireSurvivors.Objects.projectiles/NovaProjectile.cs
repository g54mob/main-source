using System;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class NovaProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__8_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CInitProjectile_003Eb__8_3()
		{
		}
	}

	private SpriteRenderer _displaySprite;

	private float _displaySpritePxSize = 256f;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private float SelfRadius = 96f;

	private Transform _cachedSpriteTransform;

	protected override void Awake()
	{
		//IL_0106->IL00af: Incompatible stack heights: 1 vs 0
		//IL_009b->IL00af: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if ((object)_displaySprite != null)
		{
			Transform transform = _displaySprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)_displaySprite != null)
				{
					GameObject gameObject = _displaySprite.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_04ba: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_00ff: Expected I, but got O
		//IL_0163: Expected O, but got I4
		//IL_025e: Expected I, but got O
		//IL_02d3: Expected O, but got I4
		//IL_0394: Expected I, but got O
		//IL_0414: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		GameObject gameObject = _displaySprite.gameObject;
		gameObject.SetActive(value: true);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_displaySprite, 0f);
		float num = _weapon.PArea();
		object obj2 = default(object);
		object obj = obj2 * SelfRadius;
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.duration = 220f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			base.Despawn();
		};
		tweenConfig.onComplete = onComplete;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
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
		Transform transform = _displaySprite.transform;
		if ((object)transform != null)
		{
			nint num3 = (nint)array2;
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
		float num4 = _displaySpritePxSize / (float)obj;
		tweenConfig2.duration = 220f;
		tweenConfig2.scale = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_displaySprite, 0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween2 = tween2;
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num5 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.duration = 100f;
		tweenConfig3.yoyo = true;
		tweenConfig3.ease = Ease.InOutSine;
		tweenConfig3.alpha = (float?)(object)1;
		TweenCallback onComplete2 = _003C_003Ec._003C_003E9__8_3;
		if (_003C_003Ec._003C_003E9__8_3 == null)
		{
			onComplete2 = (_003C_003Ec._003C_003E9__8_3 = delegate
			{
			});
		}
		tweenConfig3.onComplete = onComplete2;
		TweenCallback onStart3 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_displaySprite, 0f);
		};
		tweenConfig3.onStart = onStart3;
		MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
		_tween3 = tween3;
		Transform cachedSpriteTransform = _displaySprite.transform;
		_cachedSpriteTransform = cachedSpriteTransform;
	}

	public override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Weapon weapon2 = _weapon;
		float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		base.position = float6;
		Transform cachedSpriteTransform = _cachedSpriteTransform;
		bool flag = ((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr, ref value);
	}

	public void SetNovaTint(uint tintValue)
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_displaySprite, tintValue);
	}

	public void SetBaseRadius(float value)
	{
		SelfRadius = value;
	}

	private void _003CInitProjectile_003Eb__8_0()
	{
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__8_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__8_2()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_displaySprite, 0f);
	}

	private void _003CInitProjectile_003Eb__8_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_displaySprite, 0f);
	}
}
