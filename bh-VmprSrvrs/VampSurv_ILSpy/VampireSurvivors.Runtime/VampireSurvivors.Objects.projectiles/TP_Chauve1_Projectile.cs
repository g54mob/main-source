using System;
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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Chauve1_Projectile : Projectile
{
	protected const float Radius = 16f;

	protected const float Angle = 15f;

	protected float _cachedAngle;

	protected float _bodyOffsetX;

	protected float _bodyOffsetY;

	protected bool _flipX;

	protected int _flipSign;

	protected bool _isCrit;

	protected float2 _spawnPos;

	protected float2 _tipTargetPos;

	protected PhaserSprite _displaySprite;

	protected MultiTargetTween _alphaTween;

	protected MultiTargetTween _posTween;

	private float _003CBodyOffsetY_003Ek__BackingField;

	protected virtual bool IsEvo => false;

	protected float BodyOffsetX
	{
		get
		{
			if (_flipX)
			{
				return -36f;
			}
			return 5f;
		}
	}

	protected float BodyOffsetY
	{
		get
		{
			return _003CBodyOffsetY_003Ek__BackingField;
		}
		set
		{
			_003CBodyOffsetY_003Ek__BackingField = value;
		}
	}

	protected virtual string SpriteName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A41EF]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_Trident_idle";
		}
	}

	protected virtual string SpriteObjectName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A41F0]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_Chauve1_Sprite";
		}
	}

	protected virtual uint Tint => 16711680u;

	public virtual bool IsCrit => _isCrit;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		string spriteName = SpriteName;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", spriteName);
		string spriteObjectName = SpriteObjectName;
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName(spriteObjectName);
		_displaySprite = phaserSprite;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0033: Expected I4, but got I8
		//IL_006b: Expected F4, but got I4
		//IL_064d: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_01e6: Expected F4, but got I4
		//IL_0172: Expected I4, but got I8
		//IL_01a0: Expected O, but got I4
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected I4, but got Unknown
		//IL_0222: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_0299: Expected O, but got Ref
		//IL_02b1: Expected O, but got I
		//IL_02be: Expected O, but got Ref
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_078d: Expected O, but got F4
		//IL_0371: Expected I, but got O
		//IL_03d1: Expected O, but got I4
		//IL_041b: Expected O, but got I4
		//IL_04dc: Expected I, but got O
		//IL_0540: Expected O, but got I4
		//IL_0586: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_isCrit = false;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		_flipX = characterController._isFlipped;
		Space flipSign = (Space)(-1);
		if (!characterController._isFlipped)
		{
			flipSign = Space.Self;
		}
		_flipSign = (int)flipSign;
		float num = weapon.PArea();
		SetScaleToArea();
		float oX = ((!_flipX) ? 0f : 1f);
		ArcadeSprite arcadeSprite = setOrigin(oX, (float?)(object)1);
		string spriteName = SpriteName;
		PhaserSprite phaserSprite = _displaySprite.setFrame(spriteName, "ThosePeople");
		PhaserSprite phaserSprite2 = _displaySprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = _displaySprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite4 = _displaySprite.setTint(16777215u);
		PhaserSprite phaserSprite5 = _displaySprite.setFlipX(_flipX);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
		object obj = (_flipX ? 1 : 0) >> 31;
		object obj2 = _flipX + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = index - obj4;
		float num3;
		if ((nint)obj5 != 2)
		{
			int num2 = (int)(index & 0x80000001L);
			if ((nint)obj5 < 2)
			{
				object obj6 = num2 - 1;
				object obj7 = obj6 | -2;
				num2 = obj7 + 1;
			}
			num3 = ((num2 == 1) ? (-15f) : 15f);
		}
		else
		{
			num3 = 0f;
		}
		_cachedAngle = num3;
		float bodyOffsetX = ((!_flipX) ? 5f : (-36f));
		_bodyOffsetX = bodyOffsetX;
		float num4 = num3 * 16f;
		float num5 = num4 * ((float)Math.PI / 180f);
		float bodyOffsetY = -16f - num5;
		_bodyOffsetY = bodyOffsetY;
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		float2 float5 = base.position;
		float2 float6 = base.position;
		float2 float7 = default(float2);
		base.position = float7;
		float2 spawnPos = base.position;
		_spawnPos = spawnPos;
		float num6 = num3 * (float)_flipSign;
		Transform transform = base.transform;
		object obj8 = default(object);
		transform.Rotate((Vector3)(&obj8), Space.Self);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
		object obj9 = (nint)(&obj8) >> 31;
		object obj10 = (ref *(_003F*)(&obj8)) + (ref *(_003F*)obj9);
		object obj11 = obj10 * 2;
		object obj12 = obj10 + obj11;
		object obj13 = index - obj12;
		float num7 = (((nint)obj13 != 2) ? 0.32f : 0.4f);
		object obj14 = default(object);
		float num8 = num7 * (float)obj14;
		if (_flipX)
		{
			num6 += 180f;
		}
		float num9 = num6 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num10 = num9 * num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num11 = num9 * num8;
		_tipTargetPos = (float2)num10;
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num12 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj15 = default(object);
		if (obj15 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float2 float8 = base.position;
			tweenConfig.x = (float?)(object)1;
			float2 float9 = base.position;
			float num13 = _bodyOffsetX + num11;
			tweenConfig.duration = 100f;
			tweenConfig.ease = Ease.OutSine;
			tweenConfig.y = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Action onComplete2 = StartDespawn;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				if (_isCrit)
				{
					MakeCritProjectile();
				}
				if (!IsEvo)
				{
					PhaserSprite phaserSprite6 = _displaySprite.setFrame("TP_VFX_Trident_idle", "ThosePeople");
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween posTween = Tweens.Add(tweenConfig);
			_posTween = posTween;
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_displaySprite != null)
			{
				nint num14 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj16 = default(object);
				if (obj16 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 100f;
			tweenConfig2.alpha = (float?)(object)1;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
			_alphaTween = alphaTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.7f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * -50f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Javelin, soundConfig, 200f, 10, time);
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public override void InternalUpdate()
	{
	}

	private void SetOrigin()
	{
		//IL_001c: Expected F4, but got I4
		//IL_004f: Expected O, but got I4
		float oX = ((!_flipX) ? 0f : 1f);
		ArcadeSprite arcadeSprite = setOrigin(oX, (float?)(object)1);
	}

	protected virtual void MakeCritProjectile()
	{
	}

	private void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00da: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
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
		uint tint = Tint;
		tweenConfig.delay = 50f;
		tweenConfig.duration = 50f;
		tweenConfig.tint = (uint?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00d0: Expected O, but got I4
			//IL_0172: Expected I, but got O
			//IL_01c8: Expected O, but got I4
			//IL_01f2: Expected O, but got I4
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_displaySprite != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 100f;
			tweenConfig2.ease = Ease.InSine;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				Despawn();
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig2);
			_alphaTween = alphaTween2;
			if (_posTween != null)
			{
				_posTween.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			nint num3 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				tweenConfig3.x = (float?)(object)1;
				tweenConfig3.duration = 100f;
				tweenConfig3.ease = Ease.InSine;
				tweenConfig3.y = (float?)(object)1;
				MultiTargetTween posTween = Tweens.Add(tweenConfig3);
				_posTween = posTween;
				return;
			}
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			throw ex3;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__30_0()
	{
		Action onComplete = StartDespawn;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		if (_isCrit)
		{
			MakeCritProjectile();
		}
		if (!IsEvo)
		{
			PhaserSprite phaserSprite = _displaySprite.setFrame("TP_VFX_Trident_idle", "ThosePeople");
		}
	}

	private void _003CStartDespawn_003Eb__34_0()
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		//IL_0172: Expected I, but got O
		//IL_01c8: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
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
		tweenConfig.ease = Ease.InSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num2 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.x = (float?)(object)1;
			tweenConfig2.duration = 100f;
			tweenConfig2.ease = Ease.InSine;
			tweenConfig2.y = (float?)(object)1;
			MultiTargetTween posTween = Tweens.Add(tweenConfig2);
			_posTween = posTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void _003CStartDespawn_003Eb__34_1()
	{
		Despawn();
	}
}
