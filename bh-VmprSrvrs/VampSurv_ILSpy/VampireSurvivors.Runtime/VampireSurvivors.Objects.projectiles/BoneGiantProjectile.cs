using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BoneGiantProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__24_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CSpinnn_003Eb__24_0()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.2f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		}
	}

	private MultiTargetTween _angleTween;

	private MultiTargetTween _scaleTween;

	private float _saveVelX;

	private float _saveVelY;

	private Timer _bounceTimer;

	private bool _canBounce;

	private bool _isAttached;

	private bool _isSpinning;

	[NonSerialized]
	public PhaserSprite _displaySprite;

	[NonSerialized]
	public Vector2 _anchorPosition;

	private MultiTargetTween _attachTween;

	protected override void Awake()
	{
		//IL_0035: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_anchorPosition = (Vector2)0;
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	protected override void OnDestroy()
	{
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
	}

	private unsafe void CreateDisplaySprite()
	{
		//IL_0058: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		//IL_023b: Expected O, but got I4
		//IL_023b: Expected O, but got Ref
		//IL_023b: Expected O, but got Ref
		//IL_023b: Expected O, but got Ref
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		PhaserScene s_scene = ArcadePhysics.s_scene;
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		PhaserSprite displaySprite = RenderingExtensions.sprite(s_scene.add, pos, "anima", "Gash_arm_i01");
		_displaySprite = displaySprite;
		PhaserSprite phaserSprite = _displaySprite.setOrigin(11f / 60f, (float?)(object)1);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Gash_arm_i", 1, 5, "anima", num);
		PhaserSprite displaySprite2 = _displaySprite;
		bool flag = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		displaySprite2._spriteAnimation.AddAnimation("idle", animationFrames, 24, (byte)num != 0, flag, onComplete, autoSetAnimation);
		PhaserSprite displaySprite3 = _displaySprite;
		displaySprite3._spriteAnimation.SetAnimation("idle");
		PhaserSprite displaySprite4 = _displaySprite;
		GameObject gameObject = displaySprite4._spriteRenderer.gameObject;
		SpriteTrail spriteTrail = gameObject.AddComponent<SpriteTrail>();
		_spriteTrail = spriteTrail;
		PhaserSprite displaySprite5 = _displaySprite;
		SpriteTrail spriteTrail2 = _spriteTrail;
		spriteTrail2._MainSprite = displaySprite5._spriteRenderer;
		SpriteTrail spriteTrail3 = _spriteTrail;
		spriteTrail3._DefaultGhostAlpha = 0.65f;
		SpriteTrail spriteTrail4 = _spriteTrail;
		spriteTrail4._AlphaDecayPerGhost = 0.25f;
		SpriteTrail spriteTrail5 = _spriteTrail;
		spriteTrail5._MaxHistory = 2;
		spriteTrail5.InitialiseGhosts(expandExisting: true);
		SpriteTrail spriteTrail6 = _spriteTrail.setVisible(b: false);
		object obj = 0;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		while (true)
		{
			SpriteTrail spriteTrail7 = _spriteTrail;
			List<SpriteRenderer> ghosts = spriteTrail7._ghosts;
			if ((nint)obj >= ghosts._size)
			{
				break;
			}
			SpriteRenderer[] items = ghosts._items;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(items[obj], (Color)(&obj2), (Color)(&obj3), (Color)(&obj4), (Color)num, flag ? BlendMode.Add : BlendMode.Normal);
			obj++;
			if ((nint)obj >= 2)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Attach()
	{
		//IL_015f: Expected O, but got I4
		//IL_007e: Expected I, but got O
		//IL_00d4: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = (float)_indexInWeapon * 0.1f;
		float rate = num + 0.3f;
		soundConfig.Rate = rate;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		if (_attachTween != null)
		{
			_attachTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.x = (float?)(object)1;
			tweenConfig.duration = 200f;
			tweenConfig.y = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				OnAttached();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween attachTween = Tweens.Add(tweenConfig);
			_attachTween = attachTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public unsafe void OnAttached()
	{
		//IL_003b: Expected O, but got Ref
		//IL_0055: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_0156: Expected I, but got O
		//IL_010f: Expected O, but got Ref
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		Transform transform = _displaySprite.transform;
		float2 float5 = default(float2);
		transform.localEulerAngles = (Vector3)(&float5);
		PhaserSprite phaserSprite = _displaySprite.setOrigin(11f / 60f, (float?)(object)1);
		float2 float6 = default(float2);
		PhaserSprite phaserSprite2 = _displaySprite.setPosition(float6);
		base.position = float6;
		_isAttached = true;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v14 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		BaseBody baseBody = body;
		baseBody._velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		Transform transform2 = base.transform;
		transform2.localEulerAngles = (Vector3)(&float5);
		SpriteTrail spriteTrail = _spriteTrail.setVisible(b: false);
	}

	public void Detach(float angle)
	{
		//IL_01dc: Expected O, but got I8
		//IL_01fa: Expected O, but got I4
		//IL_009d: Expected I, but got O
		//IL_0121: Expected I4, but got I8
		//IL_012f: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = 4294967286L - _indexInWeapon;
		float detune = (float)obj * 100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		tweenConfig.duration = 1000f;
		tweenConfig.repeat = -1;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
		_isAttached = false;
		PhaserSprite phaserSprite = _displaySprite.setOrigin(0.5f, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Transform transform = base.AimForRandomEnemy();
		SpriteTrail spriteTrail = _spriteTrail.setVisible(b: true);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_005f: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00e4: Expected O, but got I4
		//IL_00e4: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_015d: Expected I, but got O
		//IL_01e4: Expected I, but got O
		//IL_023a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		PhaserSprite displaySprite = _displaySprite;
		if ((object)_displaySprite == null || ((UnityEngine.Object)displaySprite).m_CachedPtr == (IntPtr)0)
		{
			CreateDisplaySprite();
		}
		BaseBody baseBody = base.body.setCircle(14f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_canBounce = true;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody2 = base.body;
		baseBody2._bounce = (float2)1066192077;
		_ = 1066192077;
		_isCullable = false;
		_isAttached = false;
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody3 = base.body;
		baseBody3._onWorldBounds = true;
		PhaserSprite phaserSprite = _displaySprite.setScale(1f, (float?)(object)0);
		nint num = (nint)this;
		Transform transform = base.AimForRandomEnemy();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
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
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 100f;
		float num3 = _weapon.PDuration();
		float delay = default(float);
		tweenConfig.delay = delay;
		tweenConfig.ease = Ease.Linear;
		TweenCallback onStart = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite2 = _displaySprite.setScale(1f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		SpriteTrail spriteTrail = _spriteTrail.setVisible(b: false);
	}

	protected void Bounce(Body bdy, bool up, bool down, bool left, bool right)
	{
		if (bdy == body)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0135: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		bool flag = default(bool);
		if (!flag && _canBounce != flag)
		{
			_canBounce = flag;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canBounce = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.030000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
			BaseBody baseBody = body;
			ArcadeSprite sprite = _sprite;
			float num = (float)baseBody._velocity * -1.1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v12 (BaseBody)+74]");
			float num2 = 0f * -1.1f;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0230: Expected O, but got I4
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		if (_isAttached)
		{
			return;
		}
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01ca;
			}
		}
		obj5 = 4294967295L;
		goto IL_01ca;
		IL_01ca:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj6 = !flag7;
		object obj7 = flag9 & obj6;
		object obj10;
		if (obj7 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj8 = !flag12;
			object obj9 = obj8 | flag10;
			obj10 = 1;
			if (obj9 != null)
			{
				goto IL_024b;
			}
		}
		obj10 = 4294967295L;
		goto IL_024b;
		IL_024b:
		float saveVelY = (float)obj10 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	public override void InternalUpdate()
	{
		//IL_0060: Expected F4, but got O
		//IL_00ae: Expected F4, but got I
		if (!_isSpinning && !_isAttached)
		{
			BaseBody baseBody = body;
			float saveVelX = (float)baseBody._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FFD597h\"");
			if ((object)baseBody._velocity == null)
			{
				saveVelX = _saveVelX;
			}
			_saveVelX = saveVelX;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v6 (BaseBody)+74]");
			float saveVelY = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FFD5BCh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v6 (BaseBody)+74]");
			if ((nint)0 == 0)
			{
				saveVelY = _saveVelY;
			}
			_saveVelY = saveVelY;
			float2 float5 = base.position;
			PhaserSprite phaserSprite = _displaySprite.setPosition(float5);
		}
		else
		{
			float2 float6 = default(float2);
			PhaserSprite phaserSprite2 = _displaySprite.setPosition(float6);
			base.position = float6;
			AdjustBodyOffset();
		}
	}

	public override void Despawn()
	{
		_isCullable = true;
		SpriteTrail spriteTrail = _spriteTrail.setVisible(b: false);
		PhaserSprite displaySprite = _displaySprite;
		if ((object)_displaySprite != null && ((UnityEngine.Object)displaySprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		}
		base.Despawn();
	}

	public unsafe void AdjustBodyOffset()
	{
		//IL_0018: Invalid comparison between F4 and I4
		//IL_00ba: Expected O, but got I4
		//IL_00ca: Expected O, but got Ref
		//IL_0066: Expected O, but got I4
		//IL_0076: Expected O, but got Ref
		//IL_00e7: Invalid comparison between F4 and I4
		float num = _displaySprite.scale;
		float num2;
		object obj3 = default(object);
		if (num > 0f)
		{
			Transform transform = _displaySprite.transform;
			num2 = transform.localEulerAngles.z;
			object obj = 0;
			Transform transform2 = transform;
			object obj2 = (object)(&obj3);
		}
		else
		{
			Transform transform3 = _displaySprite.transform;
			num2 = transform3.localEulerAngles.z + 180f;
			object obj = 0;
			Transform transform2 = transform3;
			object obj2 = (object)(&obj3);
		}
		float num3 = num2 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num4 = _displaySprite.scale;
		if (!(num4 > 0f))
		{
			float2 float5 = _displaySprite.position;
		}
		else
		{
			float2 float6 = _displaySprite.position;
		}
		float2 float7 = default(float2);
		base.position = float7;
	}

	public void Spinnn(float angle, float duration, int times)
	{
		//IL_0189: Expected O, but got I4
		//IL_009d: Expected I, but got O
		//IL_0129: Expected O, but got I4
		_isAttached = false;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		if (_angleTween != null)
		{
			_angleTween.Kill();
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
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		tweenConfig.duration = duration;
		tweenConfig.repeat = times;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onRepeat = _003C_003Ec._003C_003E9__24_0;
		if (_003C_003Ec._003C_003E9__24_0 == null)
		{
			onRepeat = (_003C_003Ec._003C_003E9__24_0 = delegate
			{
				//IL_003d: Expected O, but got I4
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 0.2f;
				float time2 = default(float);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Shot, soundConfig2, 200f, 10, time2);
			});
		}
		tweenConfig.onRepeat = onRepeat;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
	}

	public void SetProjectileVisible(bool visible)
	{
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible);
		bool visible2;
		if (visible && !_isSpinning)
		{
			bool flag = !_isAttached;
			visible2 = flag;
		}
		else
		{
			visible2 = false;
		}
		SpriteTrail spriteTrail = _spriteTrail.setVisible(visible2);
	}

	private void _003CAttach_003Eb__14_0()
	{
		OnAttached();
	}

	private void _003CInitProjectile_003Eb__17_0()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _displaySprite.setScale(1f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__17_1()
	{
		Despawn();
	}

	private void _003COnHasHitAnObject_003Eb__19_0()
	{
		_canBounce = true;
	}
}
