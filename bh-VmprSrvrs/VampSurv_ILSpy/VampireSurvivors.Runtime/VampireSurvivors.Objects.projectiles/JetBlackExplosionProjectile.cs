using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class JetBlackExplosionProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public JetBlackExplosionProjectile _003C_003E4__this;

		public float salvoDuration;

		public TweenCallback _003C_003E9__2;

		public TweenCallback _003C_003E9__3;

		internal void _003COnRecycle_003Eb__0()
		{
			//IL_0015: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(0f, (float?)(object)0);
		}

		internal void _003COnRecycle_003Eb__1()
		{
			//IL_009a: Expected I, but got O
			//IL_0104: Expected I, but got O
			//IL_016e: Expected I, but got O
			//IL_01d8: Expected I, but got O
			//IL_0242: Expected I, but got O
			//IL_0298: Expected O, but got I4
			JetBlackExplosionProjectile jetBlackExplosionProjectile = _003C_003E4__this;
			if (jetBlackExplosionProjectile._tween5 != null)
			{
				jetBlackExplosionProjectile._tween5.Kill();
			}
			JetBlackExplosionProjectile jetBlackExplosionProjectile2 = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[5];
			JetBlackExplosionProjectile jetBlackExplosionProjectile3 = _003C_003E4__this;
			if ((object)jetBlackExplosionProjectile3._starSprite != null)
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
			JetBlackExplosionProjectile jetBlackExplosionProjectile4 = _003C_003E4__this;
			if ((object)jetBlackExplosionProjectile4._starSprite2 != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile5 = _003C_003E4__this;
			if ((object)jetBlackExplosionProjectile5._bubbleSprite != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile6 = _003C_003E4__this;
			if ((object)jetBlackExplosionProjectile6._sprite != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile7 = _003C_003E4__this;
			if ((object)jetBlackExplosionProjectile7._rockSprite != null)
			{
				nint num5 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.delay = salvoDuration;
			tweenConfig.duration = 300f;
			tweenConfig.ease = Ease.Linear;
			TweenCallback onStart = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onStart = (_003C_003E9__2 = delegate
				{
					JetBlackExplosionProjectile jetBlackExplosionProjectile8 = _003C_003E4__this;
					if (jetBlackExplosionProjectile8._tween2 != null)
					{
						jetBlackExplosionProjectile8._tween2.Kill();
					}
					JetBlackExplosionProjectile jetBlackExplosionProjectile9 = _003C_003E4__this;
					if (jetBlackExplosionProjectile9._tween3 != null)
					{
						jetBlackExplosionProjectile9._tween3.Kill();
					}
					JetBlackExplosionProjectile jetBlackExplosionProjectile10 = _003C_003E4__this;
					if (jetBlackExplosionProjectile10._tween4 != null)
					{
						jetBlackExplosionProjectile10._tween4.Kill();
					}
				});
			}
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onComplete = (_003C_003E9__3 = delegate
				{
					JetBlackExplosionProjectile jetBlackExplosionProjectile8 = _003C_003E4__this;
					if (jetBlackExplosionProjectile8._tween6 != null)
					{
						jetBlackExplosionProjectile8._tween6.Kill();
					}
					_003C_003E4__this.Despawn();
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			jetBlackExplosionProjectile2._tween5 = tween;
		}

		internal void _003COnRecycle_003Eb__2()
		{
			JetBlackExplosionProjectile jetBlackExplosionProjectile = _003C_003E4__this;
			if (jetBlackExplosionProjectile._tween2 != null)
			{
				jetBlackExplosionProjectile._tween2.Kill();
			}
			JetBlackExplosionProjectile jetBlackExplosionProjectile2 = _003C_003E4__this;
			if (jetBlackExplosionProjectile2._tween3 != null)
			{
				jetBlackExplosionProjectile2._tween3.Kill();
			}
			JetBlackExplosionProjectile jetBlackExplosionProjectile3 = _003C_003E4__this;
			if (jetBlackExplosionProjectile3._tween4 != null)
			{
				jetBlackExplosionProjectile3._tween4.Kill();
			}
		}

		internal void _003COnRecycle_003Eb__3()
		{
			JetBlackExplosionProjectile jetBlackExplosionProjectile = _003C_003E4__this;
			if (jetBlackExplosionProjectile._tween6 != null)
			{
				jetBlackExplosionProjectile._tween6.Kill();
			}
			_003C_003E4__this.Despawn();
		}
	}

	private SpriteRenderer _rockSprite;

	private SpriteRenderer _starSprite;

	private SpriteRenderer _starSprite2;

	private SpriteRenderer _bubbleSprite;

	private SpriteAnimation _animation;

	private bool _initialisedParticles;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private MultiTargetTween _tween5;

	private MultiTargetTween _tween6;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_starSprite).SetMaterial(material);
		Weapon weapon2 = _weapon;
		_isCullable = false;
		float salvoDuration;
		if (_indexInWeapon == 0)
		{
			WeaponData currentWeaponData = weapon2._currentWeaponData;
			float num = weapon2.PAmount();
			object obj = default(object);
			salvoDuration = (float)obj * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		}
		else
		{
			WeaponData currentWeaponData2 = weapon2._currentWeaponData;
			salvoDuration = currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
		}
		OnRecycle(salvoDuration);
		if (_indexInWeapon == 0)
		{
			DisplayMe(salvoDuration);
		}
	}

	private void OnRecycle(float salvoDuration)
	{
		//IL_0160: Expected I, but got O
		//IL_01d2: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals22._003C_003E4__this = this;
		CS_0024_003C_003E8__locals22.salvoDuration = salvoDuration;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_starSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite2, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_bubbleSprite, 0f);
		ArcadeSprite sprite = _sprite;
		_sprite.CheckRenderer();
		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(sprite._spriteRenderer, 0f);
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		EggFloat eggFloat = playerStats._003CMagnet_003Ek__BackingField;
		if (eggFloat._val > 1f)
		{
			float num = _weapon.PArea();
			if (_tween == null)
			{
				goto IL_010f;
			}
		}
		_tween.Kill();
		goto IL_010f;
		IL_010f:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.duration = 150f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0015: Expected O, but got I4
			ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals22._003C_003E4__this.setScale(0f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_009a: Expected I, but got O
			//IL_0104: Expected I, but got O
			//IL_016e: Expected I, but got O
			//IL_01d8: Expected I, but got O
			//IL_0242: Expected I, but got O
			//IL_0298: Expected O, but got I4
			JetBlackExplosionProjectile jetBlackExplosionProjectile = CS_0024_003C_003E8__locals22._003C_003E4__this;
			if (jetBlackExplosionProjectile._tween5 != null)
			{
				jetBlackExplosionProjectile._tween5.Kill();
			}
			JetBlackExplosionProjectile jetBlackExplosionProjectile2 = CS_0024_003C_003E8__locals22._003C_003E4__this;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[5];
			JetBlackExplosionProjectile jetBlackExplosionProjectile3 = CS_0024_003C_003E8__locals22._003C_003E4__this;
			if ((object)jetBlackExplosionProjectile3._starSprite != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile4 = CS_0024_003C_003E8__locals22._003C_003E4__this;
			if ((object)jetBlackExplosionProjectile4._starSprite2 != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile5 = CS_0024_003C_003E8__locals22._003C_003E4__this;
			if ((object)jetBlackExplosionProjectile5._bubbleSprite != null)
			{
				nint num5 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile6 = CS_0024_003C_003E8__locals22._003C_003E4__this;
			if ((object)jetBlackExplosionProjectile6._sprite != null)
			{
				nint num6 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			JetBlackExplosionProjectile jetBlackExplosionProjectile7 = CS_0024_003C_003E8__locals22._003C_003E4__this;
			if ((object)jetBlackExplosionProjectile7._rockSprite != null)
			{
				nint num7 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
					throw ex6;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.delay = CS_0024_003C_003E8__locals22.salvoDuration;
			tweenConfig2.duration = 300f;
			tweenConfig2.ease = Ease.Linear;
			TweenCallback onStart2 = CS_0024_003C_003E8__locals22._003C_003E9__2;
			if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
			{
				onStart2 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
				{
					JetBlackExplosionProjectile jetBlackExplosionProjectile8 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					if (jetBlackExplosionProjectile8._tween2 != null)
					{
						jetBlackExplosionProjectile8._tween2.Kill();
					}
					JetBlackExplosionProjectile jetBlackExplosionProjectile9 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					if (jetBlackExplosionProjectile9._tween3 != null)
					{
						jetBlackExplosionProjectile9._tween3.Kill();
					}
					JetBlackExplosionProjectile jetBlackExplosionProjectile10 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					if (jetBlackExplosionProjectile10._tween4 != null)
					{
						jetBlackExplosionProjectile10._tween4.Kill();
					}
				});
			}
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete2 = CS_0024_003C_003E8__locals22._003C_003E9__3;
			if (CS_0024_003C_003E8__locals22._003C_003E9__3 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals22._003C_003E9__3 = delegate
				{
					JetBlackExplosionProjectile jetBlackExplosionProjectile8 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					if (jetBlackExplosionProjectile8._tween6 != null)
					{
						jetBlackExplosionProjectile8._tween6.Kill();
					}
					CS_0024_003C_003E8__locals22._003C_003E4__this.Despawn();
				});
			}
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
			jetBlackExplosionProjectile2._tween5 = tween2;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.5f;
		float detune = (float)_indexInWeapon * 4.294967E+09f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 300f, 7, time);
	}

	private void DisplayMe(float salvoDuration)
	{
		//IL_00b8: Expected I, but got O
		//IL_0122: Expected I, but got O
		//IL_018c: Expected I, but got O
		//IL_01f6: Expected I, but got O
		//IL_0268: Expected O, but got I4
		//IL_0351: Expected I, but got O
		//IL_03d5: Expected I4, but got I8
		//IL_03e3: Expected O, but got I4
		//IL_04a4: Expected I, but got O
		//IL_0523: Expected O, but got I4
		//IL_05e4: Expected I, but got O
		//IL_0656: Expected O, but got I4
		_animation.SetAnimation("break");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_rockSprite, 1f);
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		Transform transform = _starSprite.transform;
		if ((object)transform != null)
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
		Transform transform2 = _starSprite2.transform;
		if ((object)transform2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Transform transform3 = _bubbleSprite.transform;
		if ((object)transform3 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Transform transform4 = _rockSprite.transform;
		if ((object)transform4 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 150f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_starSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_bubbleSprite, 0f);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(_rockSprite, 0f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_0083: Expected I4, but got I8
			//IL_00a7->IL0038: Incompatible stack heights: 1 vs 0
			SpriteRenderer starSprite = _starSprite;
			if ((object)_starSprite != null)
			{
				bool flag = ((UnityEngine.Object)starSprite).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)starSprite).m_CachedPtr, -1999);
				SpriteRenderer bubbleSprite = _bubbleSprite;
				if ((object)_bubbleSprite != null)
				{
					bool flag2 = ((UnityEngine.Object)bubbleSprite).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 75 ConditionalJump @-1, v117 @ ZF_v10 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 145 ConditionalJump @-1, v274 @ ZF_v15 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_starSprite != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 120f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = -1;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite, 0.55f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween3 = tween2;
		if (_tween6 != null)
		{
			_tween6.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_starSprite2 != null)
		{
			nint num6 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.duration = salvoDuration;
		tweenConfig3.ease = Ease.Linear;
		tweenConfig3.yoyo = true;
		tweenConfig3.alpha = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite2, 0f);
		};
		tweenConfig3.onStart = onStart3;
		MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
		_tween6 = tween3;
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)_bubbleSprite != null)
		{
			nint num7 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.duration = 300f;
		tweenConfig4.ease = Ease.Linear;
		tweenConfig4.alpha = (float?)(object)1;
		TweenCallback onStart4 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_bubbleSprite, 1f);
		};
		tweenConfig4.onStart = onStart4;
		MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
		_tween4 = tween4;
	}

	private void _003CDisplayMe_003Eb__14_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_starSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_bubbleSprite, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_rockSprite, 0f);
	}

	private void _003CDisplayMe_003Eb__14_1()
	{
		//IL_0083: Expected I4, but got I8
		//IL_00a7->IL0038: Incompatible stack heights: 1 vs 0
		SpriteRenderer starSprite = _starSprite;
		if ((object)_starSprite != null)
		{
			bool flag = ((UnityEngine.Object)starSprite).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)starSprite).m_CachedPtr, -1999);
			SpriteRenderer bubbleSprite = _bubbleSprite;
			if ((object)_bubbleSprite != null)
			{
				bool flag2 = ((UnityEngine.Object)bubbleSprite).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 75 ConditionalJump @-1, v117 @ ZF_v10 (System.Boolean) --- -1 Nop");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 145 ConditionalJump @-1, v274 @ ZF_v15 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CDisplayMe_003Eb__14_2()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_starSprite, 0.55f);
	}

	private void _003CDisplayMe_003Eb__14_3()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_starSprite2, 0f);
	}

	private void _003CDisplayMe_003Eb__14_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_bubbleSprite, 1f);
	}
}
