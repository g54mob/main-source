using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LegionnaireProjectile : Projectile
{
	private SpriteAnimation _spriteAnimation;

	private Color[][] _tints;

	private bool _hasAlreadyBeenRecycled;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private LegionnaireWeapon _trueWeapon;

	private bool _isMoving;

	public override float ProjectileSpeed
	{
		get
		{
			float num = _weapon.PSpeed();
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			CharacterData currentCharacterData = characterController._currentCharacterData;
			float num2 = GameManager.PlayerPxSpeed * currentCharacterData._003CmoveSpeed_003Ek__BackingField;
			object obj = default(object);
			float num3 = num2 * (float)obj;
			return num3 * _speed;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_07eb: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_01ee: Expected O, but got I
		//IL_0203: Expected O, but got I
		//IL_02ab: Expected I4, but got O
		//IL_0422: Expected O, but got I4
		//IL_0422: Expected O, but got Ref
		//IL_0422: Expected O, but got Ref
		//IL_0422: Expected O, but got Ref
		//IL_0476: Expected O, but got Ref
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected O, but got Unknown
		//IL_0858: Expected O, but got I4
		//IL_05a0: Expected I, but got O
		//IL_0604: Expected O, but got I4
		//IL_06a3: Expected I, but got O
		//IL_0707: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_07c4;
		}
		nint num = (nint)typeof(LegionnaireWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v86 (Il2CppClass<VampireSurvivors.Objects.Weapons.LegionnaireWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v63 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v86 (Il2CppClass<VampireSurvivors.Objects.Weapons.LegionnaireWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v63 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v149+FFFFFFF8+v71 @ rax_v144*8]");
			if (0 == (nint)typeof(LegionnaireWeapon))
			{
				obj3 = 1;
				goto IL_07d3;
			}
		}
		obj3 = 0;
		goto IL_07d3;
		IL_0895:
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
		IL_07c4:
		_trueWeapon = (LegionnaireWeapon)trueWeapon;
		if (_hasAlreadyBeenRecycled)
		{
			return;
		}
		_hasAlreadyBeenRecycled = true;
		_speed = 2f;
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
		if (obj4 == null)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
			obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)1);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v24 (System.Object)+18]");
		string textureName;
		string text;
		int end;
		int fps;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v24 (System.Object)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rcx_v21+20]");
			CharacterData characterData = (CharacterData)0;
			if (characterData._003Cskins_003Ek__BackingField == null)
			{
				textureName = characterData._003CtextureName_003Ek__BackingField;
				text = characterData._003CspriteName_003Ek__BackingField;
				end = characterData._003CwalkingFrames_003Ek__BackingField;
				if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
				{
					if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
					{
						fps = (object?)characterData._003CwalkFrameRate_003Ek__BackingField >> 32;
						goto IL_02ee;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					goto IL_0895;
				}
			}
			else
			{
				Skin currentSkinData = characterData.GetCurrentSkinData();
				textureName = currentSkinData._003CtextureName_003Ek__BackingField;
				text = currentSkinData._003CspriteName_003Ek__BackingField;
				end = currentSkinData._003CwalkingFrames_003Ek__BackingField;
			}
			fps = 8;
			goto IL_02ee;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_07d3:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_07c4;
		IL_02ee:
		string animName = text.Replace("01.png", "");
		int num4 = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, num4);
		SpriteAnimation spriteAnimation = _spriteAnimation;
		if ((object)_spriteAnimation == null || ((UnityEngine.Object)spriteAnimation).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = _renderer.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6590");
			SpriteAnimation spriteAnimation2 = default(SpriteAnimation);
			_spriteAnimation = spriteAnimation2;
		}
		_spriteAnimation.CleanAnimations();
		bool flag2 = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num4 != 0, flag2, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("walk");
		CheckRenderer();
		object obj6 = default(object);
		object obj7 = default(object);
		object obj8 = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(((ArcadeSprite)this)._spriteRenderer, (Color)(&obj6), (Color)(&obj7), (Color)(&obj8), (Color)num4, flag2 ? BlendMode.Add : BlendMode.Normal);
		Color[][] tints = _tints;
		int num5 = _indexInWeapon % tints.Length;
		int num6 = num5 + 4;
		ArcadeSprite arcadeSprite = setDepth(num6);
		Color color = default(Color);
		ApplyPlayerFacingVelocity((Vector3)(&color), rotate: false);
		BaseBody baseBody = body;
		bool flag3 = 0 < (nint)baseBody._velocity;
		object obj9 = 0 - baseBody._velocity;
		bool flag4 = obj9 == null;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		bool flag7 = flag6 & flag5;
		ArcadeSprite arcadeSprite2 = setFlipX(flag7);
		float num7 = weapon.PArea();
		object obj10 = default(object);
		float num8 = (float)obj10 - 0.4f;
		bool flag8 = 1f > num8;
		float xScale = 1f;
		if (!flag8)
		{
			xScale = num8;
		}
		ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
		_isMoving = true;
		ArcadeSprite arcadeSprite4 = setAlpha(0f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			nint num9 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 == null)
			{
				goto IL_0895;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			nint num10 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj12 = default(object);
			if (obj12 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 500f;
		tweenConfig2.alpha = (float?)(object)1;
		float num11 = weapon.PDuration();
		tweenConfig2.delay = num8;
		TweenCallback onStart = delegate
		{
			//IL_002d: Expected O, but got I4
			SpriteAnimation spriteAnimation3 = _spriteAnimation;
			_isMoving = false;
			((BaseSpriteAnimation)spriteAnimation3)._currentAnimation = null;
			BaseBody baseBody2 = body;
			_ = 0;
			baseBody2._velocity = (float2)0;
		};
		tweenConfig2.onStart = onStart;
		TweenCallback onComplete2 = delegate
		{
			Despawn();
		};
		tweenConfig2.onComplete = onComplete2;
		MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
		_despawnTween = despawnTween;
	}

	public override void Despawn()
	{
		base.Despawn();
		_hasAlreadyBeenRecycled = false;
	}

	protected override void OnUpdate()
	{
		//IL_009b: Invalid comparison between F4 and I4
		//IL_0085: Expected I4, but got I8
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		if (_isMoving)
		{
			float2 float5 = base.position;
			float2 float6 = _sprite.displaySize;
			LegionnaireWeapon trueWeapon = _trueWeapon;
			float2 float7 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(trueWeapon._smokeEmitter, pos, -1);
		}
	}

	public LegionnaireProjectile()
	{
		Color[][] tints = new Color[4][];
		Color[] array = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array2 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12390]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12390]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array3 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12390]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12390]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array4 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12390]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12390]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_tints = tints;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__10_0()
	{
		//IL_002d: Expected O, but got I4
		SpriteAnimation spriteAnimation = _spriteAnimation;
		_isMoving = false;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		BaseBody baseBody = body;
		_ = 0;
		baseBody._velocity = (float2)0;
	}

	private void _003CInitProjectile_003Eb__10_1()
	{
		Despawn();
	}
}
