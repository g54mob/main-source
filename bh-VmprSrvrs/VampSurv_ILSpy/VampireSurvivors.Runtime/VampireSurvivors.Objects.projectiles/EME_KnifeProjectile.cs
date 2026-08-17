using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
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

public class EME_KnifeProjectile : Projectile
{
	private SpriteTrail _Trail;

	private SpriteAnimation _spriteAnimation;

	protected Color[][] _tints;

	protected Color[][] _tints2;

	protected Color[][] _tints3;

	private bool _hasAlreadyBeenRecycled;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	protected EME_Knife1Weapon _trueWeapon;

	public virtual bool DoExplosions => false;

	public virtual float DurationMultiplier => 1f;

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
		_speed = 2f;
	}

	public virtual Color[][] GetTints()
	{
		return _tints;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_08df: Expected O, but got I4
		//IL_00c6: Expected I4, but got O
		//IL_00ab: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_030f: Expected O, but got I
		//IL_0324: Expected O, but got I
		//IL_03cc: Expected I4, but got O
		//IL_04f1: Expected O, but got I4
		//IL_04f1: Expected I4, but got O
		//IL_0544: Expected I4, but got O
		//IL_0544: Expected O, but got I4
		//IL_0544: Expected O, but got Ref
		//IL_0544: Expected O, but got Ref
		//IL_0544: Expected O, but got Ref
		//IL_05ca: Invalid comparison between F4 and I4
		//IL_0693: Expected I, but got O
		//IL_06f7: Expected O, but got I4
		//IL_0796: Expected I, but got O
		//IL_07ec: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		bool flag;
		if ((object)weapon == null)
		{
			flag = false;
			goto IL_08d5;
		}
		nint num = (nint)typeof(EME_Knife1Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v99 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Knife1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v72 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v99 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Knife1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v72 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v172+FFFFFFF8+v71 @ rax_v167*8]");
			if (0 == (nint)typeof(EME_Knife1Weapon))
			{
				obj3 = 1;
				goto IL_08e4;
			}
		}
		obj3 = 0;
		goto IL_08e4;
		IL_040f:
		string text;
		string animName = text.Replace("01.png", "");
		int end;
		string textureName;
		bool flag2 = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, flag2 ? 1 : 0);
		SpriteAnimation spriteAnimation = _spriteAnimation;
		if ((object)_spriteAnimation == null || ((UnityEngine.Object)spriteAnimation).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = _renderer.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6590");
			SpriteAnimation spriteAnimation2 = default(SpriteAnimation);
			_spriteAnimation = spriteAnimation2;
		}
		_spriteAnimation.CleanAnimations();
		int fps;
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num4 = default(int);
		TimerType timerType = default(TimerType);
		_spriteAnimation.AddAnimation("walk", animationFrames, fps, flag2, (byte)(int)monoBehaviour != 0, (Action)num4, (byte)timerType != 0);
		_spriteAnimation.SetAnimation("walk");
		Color[][] tints = GetTints();
		CheckRenderer();
		object obj4 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(((ArcadeSprite)this)._spriteRenderer, (Color)(&obj4), (Color)(&obj5), (Color)(&obj6), (Color)flag2, (BlendMode)monoBehaviour);
		int num5 = _indexInWeapon % tints.Length;
		int num6 = num5 + 4;
		ArcadeSprite arcadeSprite = setDepth(num6);
		Transform transform = base.AimForNearestEnemy(rotate: false);
		BaseBody baseBody = body;
		bool flag3 = 0 < (nint)baseBody._velocity;
		float num7 = 0f - (float)baseBody._velocity;
		bool flag4 = num7 == 0f;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		bool flag7 = flag6 & flag5;
		ArcadeSprite arcadeSprite2 = setFlipX(flag7);
		ArcadeSprite arcadeSprite3 = setAlpha(0f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			nint num8 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				goto IL_097e;
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
			nint num9 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 300f;
		float num10 = weapon.PDuration();
		float durationMultiplier = DurationMultiplier;
		float num11;
		float delay = num11 * num11;
		tweenConfig2.delay = delay;
		TweenCallback onStart = delegate
		{
			StopMoving();
		};
		tweenConfig2.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
		_despawnTween = despawnTween;
		return;
		IL_08d5:
		_trueWeapon = (EME_Knife1Weapon)flag;
		_isCullable = false;
		if (_hasAlreadyBeenRecycled)
		{
			return;
		}
		SpriteTrail trail = _Trail;
		_hasAlreadyBeenRecycled = true;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			SpriteTrail spriteTrail = _Trail.setVisible(b: true);
		}
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete2 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		num11 = hitBoxDelay * 0.001f;
		Timer hitboxTimer = Timers.Register(num11, onComplete2, null, isLooped: true, flag2, monoBehaviour, num4, timerType, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		object obj9 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
		if (obj9 == null)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
			obj9 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)1);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v36 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v36 (System.Object)+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ rcx_v32+20]");
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
						goto IL_040f;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					goto IL_097e;
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
			goto IL_040f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_08e4:
		bool flag8 = obj3 == null;
		flag = false;
		if (!flag8)
		{
			flag = (byte)(int)weapon != 0;
		}
		goto IL_08d5;
		IL_097e:
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public virtual void FireSpecialBullets()
	{
	}

	private void StopMoving()
	{
		//IL_002d: Expected O, but got I4
		SpriteAnimation spriteAnimation = _spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		BaseBody baseBody = body;
		_ = 0;
		baseBody._velocity = (float2)0;
		FireSpecialBullets();
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		SpriteTrail trail = _Trail;
		_hasAlreadyBeenRecycled = false;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_008c: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if (!DoExplosions)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				float detune = (float)_indexInWeapon * -100f;
				soundConfig.Rate = 1.5f;
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_backstab, soundConfig, 100f, 2, time);
				StopMoving();
			}
			else
			{
				FireSpecialBullets();
				Transform transform = base.AimForNearestEnemyToPlayer(rotate: false);
			}
		}
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
	}

	public EME_KnifeProjectile()
	{
		Color[][] tints = new Color[4][];
		Color[] array = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12180]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12180]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array2 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array3 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12180]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12180]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array4 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_tints = tints;
		Color[][] tints2 = new Color[4][];
		Color[] array5 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12290]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12290]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array6 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12290]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12290]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array7 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12190]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12330]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12190]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12330]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array8 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12330]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12330]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_tints2 = tints2;
		Color[][] tints3 = new Color[4][];
		Color[] array9 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FD0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FD0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array10 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FD0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FD0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array11 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120F0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FB0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120F0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FB0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array12 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12060]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FB0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12060]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FB0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_tints3 = tints3;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__18_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__18_1()
	{
		StopMoving();
	}

	private void _003CInitProjectile_003Eb__18_2()
	{
		Despawn();
	}
}
