using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Sample2Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public bool alsoDespawn;

		public Sample2Projectile _003C_003E4__this;

		internal void _003CShrink_003Eb__0()
		{
			if (alsoDespawn)
			{
				_003C_003E4__this.Despawn();
			}
		}
	}

	private PhaserSprite sampleSprite;

	private PhaserSprite crystalSprite;

	private MultiTargetTween crystalTween;

	private Sample2Weapon trueWeapon;

	protected int[] tints = new int[3] { 16738030, 13378252, 16711935 };

	protected SfxType[] dropSounds = new SfxType[4]
	{
		SfxType.DLC3_SampleDrop1,
		SfxType.DLC3_SampleDrop2,
		SfxType.DLC3_SampleDrop3,
		SfxType.DLC3_SampleDrop4
	};

	protected SfxType[] stepSounds = new SfxType[4]
	{
		SfxType.DLC3_SamplePickup1,
		SfxType.DLC3_SamplePickup2,
		SfxType.DLC3_SamplePickup3,
		SfxType.DLC3_SamplePickup4
	};

	private bool isInitialised;

	private MultiTargetTween _moveXTween;

	private MultiTargetTween _moveYTween;

	private bool isBreaking;

	private Timer _expireTimer;

	private MultiTargetTween despawnTween;

	private PhaserSprite overlaySprite;

	private PhaserSprite numberSprite;

	private MultiTargetTween overlayAlphaTween;

	private MultiTargetTween numberSpriteTween;

	private Timer _activationTimer;

	private MultiTargetTween enterTween;

	private int assignedNumber;

	private float2 playerOffset;

	private bool followOwner;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("giantButtonBase_0", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public virtual void makeSprites()
	{
		//IL_008c: Expected I4, but got I8
		//IL_00c8: Expected O, but got I4
		//IL_00e4: Expected O, but got I4
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("giantButtonBase_", 0, 0, "vfx", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("giantButtonBase_", 0, 18, "vfx", num);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "CrystalBig");
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1995);
		GameObject gameObject = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject).SetName("_crystalSprite");
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
		crystalSprite = phaserSprite5;
		PhaserSprite phaserSprite6 = crystalSprite;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite6._spriteAnimation.AddAnimation("idle", animationFrames, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite7 = crystalSprite;
		phaserSprite7._spriteAnimation.AddAnimation("break", animationFrames2, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite8 = instance2.AddPhaserSprite(pos, "vfx", "giantButtonOverlay");
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float height = renderer.height;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = height ^ 0;
			float num2 = (float)obj - 2f;
			PhaserSprite phaserSprite9 = phaserSprite8.setDepth(num2);
			GameObject gameObject2 = phaserSprite9.gameObject;
			((UnityEngine.Object)gameObject2).SetName("overlaySprite");
			PhaserSprite phaserSprite10 = phaserSprite9.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite11 = phaserSprite10.setVisible(visible: false);
			overlaySprite = phaserSprite11;
			PhaserWorld instance3 = PhaserWorld.Instance;
			PhaserSprite phaserSprite12 = instance3.AddPhaserSprite(pos, "vfx", "giantButtonNumber_01");
			int height2 = Screen.height;
			PhaserSprite phaserSprite13 = phaserSprite12.setDepth(height2);
			GameObject gameObject3 = phaserSprite13.gameObject;
			((UnityEngine.Object)gameObject3).SetName("_numberSprite");
			PhaserSprite phaserSprite14 = phaserSprite13.setVisible(visible: false);
			numberSprite = phaserSprite14;
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0015: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_006e: Expected I, but got O
		//IL_0076: Expected I, but got O
		//IL_0086: Expected O, but got I
		//IL_0106: Expected O, but got I4
		//IL_00c2: Expected O, but got I
		//IL_00f8: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		if (isInitialised)
		{
			goto IL_011a;
		}
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		makeSprites();
		Weapon weapon2 = _weapon;
		isInitialised = true;
		Sample2Weapon sample2Weapon;
		if ((object)_weapon == null)
		{
			sample2Weapon = null;
			goto IL_0307;
		}
		nint num = (nint)typeof(Sample2Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v37+FFFFFFF8+v265 @ rax_v32*8]");
			if (0 == (nint)typeof(Sample2Weapon))
			{
				obj3 = 1;
				goto IL_0316;
			}
		}
		obj3 = 0;
		goto IL_0316;
		IL_011a:
		BaseBody baseBody = body;
		isBreaking = false;
		baseBody._enable = false;
		if (crystalTween != null)
		{
			crystalTween.Kill();
		}
		PhaserSprite phaserSprite = crystalSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite3 = crystalSprite;
		phaserSprite3._spriteAnimation.SetAnimation("idle");
		if (overlayAlphaTween != null)
		{
			overlayAlphaTween.Kill();
		}
		if (enterTween != null)
		{
			enterTween.Kill();
		}
		if (crystalTween != null)
		{
			crystalTween.Kill();
		}
		if (numberSpriteTween != null)
		{
			numberSpriteTween.Kill();
		}
		PhaserSprite phaserSprite4 = numberSprite.setVisible(visible: false);
		PhaserSprite phaserSprite5 = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite6 = overlaySprite.setVisible(visible: false);
		return;
		IL_0316:
		bool flag = obj3 == null;
		sample2Weapon = null;
		if (!flag)
		{
			sample2Weapon = (Sample2Weapon)_weapon;
		}
		goto IL_0307;
		IL_0307:
		trueWeapon = sample2Weapon;
		goto IL_011a;
	}

	public void SetFloorTarget(int showNumber, float2 targetPos, float delay, float activationDelay)
	{
		//IL_0235: Expected I, but got O
		//IL_02d0: Expected O, but got I4
		base.position = targetPos;
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = float5 - targetPos;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		playerOffset = float6;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		PhaserSprite phaserSprite = numberSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite3 = overlaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite4 = crystalSprite.setPosition(targetPos);
		PhaserSprite phaserSprite5 = overlaySprite.setPosition(targetPos);
		bool flag = (object)numberSprite == null;
		PhaserSprite phaserSprite6 = numberSprite.setPosition(targetPos);
		assignedNumber = showNumber;
		int num = showNumber + 1;
		if (!flag && num <= 9)
		{
			int num2 = default(int);
			string text = num2.ToString();
			string spriteName = "giantButtonNumber_0" + text;
			PhaserSprite phaserSprite7 = numberSprite.setFrame(spriteName, "vfx");
			PhaserSprite phaserSprite8 = numberSprite.setVisible(visible: true);
			PhaserSprite phaserSprite9 = numberSprite.setAlpha(0f);
		}
		PhaserSprite phaserSprite10 = overlaySprite.setAlpha(0f);
		if (overlayAlphaTween != null)
		{
			overlayAlphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)overlaySprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.repeatDelay = delay;
		tweenConfig.duration = 300f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite11 = overlaySprite.setVisible(visible: true);
			PhaserSprite phaserSprite12 = overlaySprite.setAlpha(0f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		overlayAlphaTween = multiTargetTween;
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		Action onComplete = Dropped;
		object obj5 = default(object);
		float duration = (float)obj5 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer activationTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_activationTimer = activationTimer;
		followOwner = true;
	}

	public unsafe void Dropped()
	{
		//IL_0543: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_00ec: Expected I, but got O
		//IL_015a: Expected O, but got I4
		//IL_022f: Expected I, but got O
		//IL_029d: Expected O, but got I4
		//IL_035e: Expected I, but got O
		//IL_03de: Expected I4, but got I8
		//IL_03ec: Expected O, but got I4
		//IL_050b: Expected I4, but got F4
		//IL_010f->IL010f: Incompatible stack heights: 1 vs 0
		//IL_0252->IL0252: Incompatible stack heights: 1 vs 0
		//IL_0381->IL0381: Incompatible stack heights: 1 vs 0
		followOwner = false;
		SfxType[] array = dropSounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		SfxType[] array2 = dropSounds;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 1, num);
		checkOverlap(0);
		if (enterTween != null)
		{
			enterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array3 = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num2 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			bool flag = obj2 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array3;
		tweenConfig.duration = 200f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		enterTween = multiTargetTween;
		PhaserSprite phaserSprite = numberSprite.setAlpha(0f);
		if (numberSpriteTween != null)
		{
			numberSpriteTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)numberSprite != null)
		{
			nint num3 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag2 = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array4;
		tweenConfig2.duration = 200f;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			PhaserSprite phaserSprite2 = numberSprite.setAlpha(0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		numberSpriteTween = multiTargetTween2;
		if (overlayAlphaTween != null)
		{
			overlayAlphaTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array5 = new object[1];
		if ((object)overlaySprite != null)
		{
			nint num4 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag3 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array5;
		tweenConfig3.duration = 500f;
		tweenConfig3.ease = Ease.InOutSine;
		tweenConfig3.yoyo = true;
		tweenConfig3.repeat = -1;
		tweenConfig3.alpha = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			PhaserSprite phaserSprite2 = overlaySprite.setVisible(visible: true);
			PhaserSprite phaserSprite3 = overlaySprite.setAlpha(0f);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onStop = delegate
		{
			PhaserSprite phaserSprite2 = overlaySprite.setVisible(visible: false);
			PhaserSprite phaserSprite3 = overlaySprite.setAlpha(0f);
		};
		tweenConfig3.onStop = onStop;
		MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
		overlayAlphaTween = multiTargetTween3;
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num5 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		object obj5 = default(object);
		float duration = (float)obj5 * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public unsafe void Break()
	{
		//IL_046e: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_04af: Expected O, but got I4
		//IL_01df: Expected F4, but got I4
		//IL_01df: Expected O, but got F4
		//IL_0203: Expected I4, but got I8
		//IL_0215: Expected F4, but got I4
		//IL_0107: Expected O, but got I4
		//IL_0137: Expected I4, but got I8
		//IL_016a: Expected F4, but got I4
		//IL_016a: Expected O, but got F4
		//IL_0180: Expected F4, but got I4
		//IL_0361: Expected I, but got O
		//IL_03d0: Expected O, but got I4
		//IL_0384->IL0384: Incompatible stack heights: 1 vs 0
		if (isBreaking)
		{
			return;
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		isBreaking = true;
		SfxType[] array = stepSounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		SfxType[] array2 = stepSounds;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 4, num);
		Sample2Weapon sample2Weapon = trueWeapon;
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		if (assignedNumber != 0)
		{
			if (assignedNumber != sample2Weapon.lastIndex && assignedNumber < 9)
			{
				object obj2 = sample2Weapon.lastIndex + 1;
				if (assignedNumber != (nint)obj2)
				{
					sample2Weapon.lastIndex = -1;
					PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_CardDeny, 1300f, 10, 0f, (float?)(object)num, rate, detune, loop, 1f);
					float num2 = 1300f;
					float num3 = 0f;
				}
				else
				{
					sample2Weapon.lastIndex = assignedNumber;
				}
			}
		}
		else
		{
			sample2Weapon.lastIndex = 0;
		}
		object obj3 = sample2Weapon.sequenceCounter - 1;
		if (sample2Weapon.lastIndex >= (nint)obj3)
		{
			PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_TaskComplete, 1300f, 10, 0f, (float?)(object)num, rate, detune, loop, 1f);
			sample2Weapon.startReactor();
			sample2Weapon.lastIndex = -1;
			float num2 = 1300f;
			float num3 = 0f;
		}
		float2 pos = crystalSprite.position;
		trueWeapon.SpawnExplosionClustersAt(pos);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (overlayAlphaTween != null)
		{
			overlayAlphaTween.Kill();
		}
		PhaserSprite phaserSprite = numberSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = overlaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite3 = crystalSprite.setVisible(visible: true);
		PhaserSprite phaserSprite4 = crystalSprite;
		phaserSprite4._spriteAnimation.SetAnimation("break");
		if (crystalTween != null)
		{
			crystalTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)crystalSprite != null)
		{
			nint num4 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array3;
		float num5 = _weapon.PArea();
		tweenConfig.duration = 600f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		crystalTween = multiTargetTween;
		Shrink();
	}

	protected unsafe void dropSound()
	{
		//IL_0080: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		SfxType[] array = dropSounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		SfxType[] array2 = dropSounds;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 1, time);
	}

	protected unsafe void breakSound()
	{
		//IL_0080: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		SfxType[] array = stepSounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		SfxType[] array2 = stepSounds;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 4, time);
	}

	public void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_0097: Expected I, but got O
		//IL_00fb: Expected O, but got I4
		if (despawnTween != null)
		{
			despawnTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)crystalSprite != null)
			{
				nint num2 = (nint)array;
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
			tweenConfig.duration = 120f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			despawnTween = multiTargetTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public void Shrink(bool alsoDespawn = false)
	{
		//IL_007a: Expected I, but got O
		//IL_00d2: Expected I, but got O
		//IL_0136: Expected O, but got I4
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals4.alsoDespawn = alsoDespawn;
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		if (despawnTween != null)
		{
			despawnTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)crystalSprite != null)
			{
				nint num2 = (nint)array;
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
			tweenConfig.duration = 120f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				if (CS_0024_003C_003E8__locals4.alsoDespawn)
				{
					CS_0024_003C_003E8__locals4._003C_003E4__this.Despawn();
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			despawnTween = multiTargetTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public override void Despawn()
	{
		if (overlayAlphaTween != null)
		{
			overlayAlphaTween.Kill();
		}
		PhaserSprite phaserSprite = numberSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite3 = overlaySprite.setVisible(visible: false);
		base.Despawn();
	}

	public override void InternalUpdate()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		if (followOwner)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Sample2Projectile)+170]");
			object obj2 = default(object);
			object obj = obj2 + 0;
			float2 float6 = default(float2);
			base.position = float6;
		}
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float8 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float9 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	private unsafe void checkOverlap(int tries)
	{
		//IL_0041: Expected O, but got I4
		//IL_0608: Expected O, but got I4
		//IL_0622: Expected O, but got I4
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_0114: Expected O, but got I
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Ref, but got Unknown
		//IL_0232: Expected I8, but got I4
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected Ref, but got Unknown
		//IL_0269: Expected O, but got I4
		//IL_0271: Expected I, but got I8
		//IL_027a: Expected O, but got I4
		//IL_0282: Expected I, but got I8
		//IL_04d6: Invalid comparison between O and F4
		//IL_067c: Expected F4, but got O
		//IL_06a5: Expected F4, but got O
		int num2 = default(int);
		int num = num2;
		object obj8 = default(object);
		nint num4 = default(nint);
		float num12 = default(float);
		object obj9 = default(object);
		float2 float9 = default(float2);
		while (true)
		{
			Weapon weapon = _weapon;
			List<Projectile> spawnedProjectiles = weapon._spawnedProjectiles;
			object obj = 0;
			object obj7;
			nint num3;
			float num9;
			float num11;
			float num7;
			float num10;
			float num8;
			while (true)
			{
				if ((nint)obj >= spawnedProjectiles._size)
				{
					return;
				}
				if ((nint)obj < spawnedProjectiles._size)
				{
					Projectile[] items = spawnedProjectiles._items;
					UnityEngine.Object obj2 = items[obj];
					bool flag = (object)items[obj] == null;
					bool flag2 = (object)this == null;
					object obj3 = flag2 & flag;
					bool flag3 = obj3 == null;
					object obj4 = !flag3;
					if (obj4 == null)
					{
						bool flag4;
						if ((object)items[obj] != null)
						{
							object obj5 = (object)items[obj] - (object)this;
							flag4 = obj5 == null;
						}
						else
						{
							flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
						}
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rbx_v8 (UnityEngine.Object)+28]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v20+40]");
							if ((nint)0 != 0)
							{
								string text = ((UnityEngine.Object)items[obj]).GetName();
								string text2 = GetName();
								bool flag5 = (object)text == text2;
								obj7 = obj8;
								num3 = num4;
								if (!flag5)
								{
									bool flag6 = text == null;
									num2 = 0;
									if (flag6)
									{
										goto IL_0446;
									}
									bool flag7 = text2 == null;
									num2 = 0;
									if (flag7)
									{
										goto IL_0446;
									}
									bool flag8 = text._stringLength != text2._stringLength;
									num2 = 0;
									if (flag8)
									{
										goto IL_0446;
									}
									ref byte second = ref *(byte*)(text2 + 20);
									ulong num5 = (ulong)(text._stringLength + text._stringLength);
									bool flag9 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text + 20), ref second, num5);
									bool flag10 = !flag9;
									obj7 = 0;
									num3 = (nint)num5;
									obj8 = 0;
									num4 = (nint)num5;
									if (flag10)
									{
										goto IL_0446;
									}
								}
								float2 float5 = base.displaySize;
								float num6 = (float)float5 * 0.5f;
								num7 = num6 - 0.01f;
								float2 float6 = base.position;
								float2 float7 = items[obj].position;
								num8 = (float)float6 - num7;
								num9 = (float)float6 + num7;
								num10 = (float)float7 + num7;
								num11 = num12 + num7;
								bool flag11 = num10 < num8;
								float num13 = num12;
								obj8 = obj7;
								num4 = num3;
								num2 = 0;
								if (!flag11)
								{
									num10 = (float)float7 - num7;
									bool flag12 = num9 < num10;
									num13 = num12;
									obj8 = obj7;
									num4 = num3;
									num2 = 0;
									if (!flag12)
									{
										num13 = num12 - num7;
										num10 = (float)obj9 + num7;
										bool flag13 = num10 < num13;
										obj8 = obj7;
										num4 = num3;
										num2 = 0;
										if (!flag13)
										{
											num10 = (float)obj9 - num7;
											bool flag14 = num11 < num10;
											bool flag15 = !flag14;
											obj8 = obj7;
											num4 = num3;
											num2 = 0;
											if (flag15)
											{
												break;
											}
										}
									}
								}
							}
						}
					}
					goto IL_0446;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
				IL_0446:
				obj++;
			}
			float2 float8 = base.displaySize;
			num7 = (float)float8 + 0.01f;
			Weapon weapon2;
			float2 float13;
			if (num == 0)
			{
				base.position = float9;
				weapon2 = _weapon;
			}
			else
			{
				weapon2 = _weapon;
				if ((num & 1) != 0)
				{
					float2 float10 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
					float2 float11 = base.position;
					float2 float12 = base.position;
					if (!(num12 < num11))
					{
						num7 ^= -0f;
					}
					num8 = (float)obj9 + num7;
					num10 = (float)float9;
					float13 = float9;
					goto IL_06b2;
				}
			}
			float2 float14 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			float2 float15 = base.position;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float14) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9))
			{
				num7 ^= -0f;
			}
			float2 float16 = base.position;
			num10 = num12;
			num8 = (float)float9;
			float13 = float9;
			goto IL_06b2;
			IL_06b2:
			base.position = float13;
			if (num < 4)
			{
				num++;
				obj8 = obj7;
				num4 = num3;
				continue;
			}
			break;
		}
	}

	private void _003CSetFloorTarget_003Eb__25_0()
	{
		PhaserSprite phaserSprite = overlaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = overlaySprite.setAlpha(0f);
	}

	private void _003CDropped_003Eb__26_0()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
	}

	private void _003CDropped_003Eb__26_1()
	{
		PhaserSprite phaserSprite = numberSprite.setAlpha(0f);
	}

	private void _003CDropped_003Eb__26_2()
	{
		PhaserSprite phaserSprite = overlaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = overlaySprite.setAlpha(0f);
	}

	private void _003CDropped_003Eb__26_3()
	{
		PhaserSprite phaserSprite = overlaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = overlaySprite.setAlpha(0f);
	}

	private void _003CBreak_003Eb__27_0()
	{
		Despawn();
	}

	private void _003CStartDespawn_003Eb__30_0()
	{
		Despawn();
	}
}
