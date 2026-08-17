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

public class Sample1Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public bool alsoDespawn;

		public Sample1Projectile _003C_003E4__this;

		internal void _003CShrink_003Eb__0()
		{
			if (alsoDespawn)
			{
				_003C_003E4__this.Despawn();
			}
		}
	}

	private string[] frameNames;

	private PhaserSprite sampleSprite;

	private PhaserSprite crystalSprite;

	private MultiTargetTween crystalTween;

	private Sample1Weapon trueWeapon;

	protected int[] tints;

	protected SfxType[] dropSounds;

	protected SfxType[] stepSounds;

	private bool isInitialised;

	private MultiTargetTween _moveXTween;

	private MultiTargetTween _moveYTween;

	private bool isBreaking;

	private Timer _expireTimer;

	private MultiTargetTween despawnTween;

	public virtual void makeSprites()
	{
		//IL_008c: Expected I4, but got I8
		//IL_00c8: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_01fb: Expected I, but got O
		//IL_0271: Expected I4, but got I8
		//IL_027f: Expected O, but got I4
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("CrystalBig_", 0, 0, "vfx", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("CrystalBig_", 0, 12, "vfx", num);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "CrystalBig");
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1995);
		GameObject gameObject = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject).SetName("_crystalSprite");
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0.35f);
		PhaserSprite phaserSprite5 = phaserSprite4.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
		PhaserSprite phaserSprite7 = phaserSprite6.setBlendMode(BlendMode.Add);
		crystalSprite = phaserSprite7;
		PhaserSprite phaserSprite8 = crystalSprite;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite8._spriteAnimation.AddAnimation("idle", animationFrames, 22, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite9 = crystalSprite;
		phaserSprite9._spriteAnimation.AddAnimation("break", animationFrames2, 22, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)crystalSprite != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0015: Expected O, but got I4
		//IL_03cf: Expected O, but got I4
		//IL_0072: Expected I, but got O
		//IL_008a: Expected O, but got I
		//IL_010a: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_03ad: Expected O, but got I4
		//IL_00c6: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_03dd: Expected O, but got F4
		//IL_0257: Expected O, but got Ref
		Weapon weapon2 = default(Weapon);
		base.InitProjectile(pool, weapon2, index);
		_isCullable = false;
		if (isInitialised)
		{
			goto IL_0377;
		}
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		makeSprites();
		float? weapon3 = (float?)_weapon;
		isInitialised = true;
		float? num;
		if ((object)_weapon == null)
		{
			num = (float?)(object)0;
			goto IL_0386;
		}
		nint num2 = (nint)typeof(Sample1Weapon);
		object obj = weapon3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r9_v15+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r9_v15+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rax_v68+FFFFFFF8+v379 @ rax_v63*8]");
			if (0 == (nint)typeof(Sample1Weapon))
			{
				obj4 = 1;
				goto IL_0395;
			}
		}
		obj4 = 0;
		goto IL_0395;
		IL_0377:
		string[] array = frameNames;
		object obj5 = UnityEngine.Random.RandomRangeInt(0, array.Length);
		Sprite sprite = SpriteManager.GetSprite(array[obj5], "vfx");
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
		BaseBody baseBody = body;
		isBreaking = false;
		baseBody._enable = false;
		if (crystalTween != null)
		{
			crystalTween.Kill();
		}
		PhaserSprite phaserSprite = crystalSprite.setScale(1f, (float?)(object)0);
		int[] array2 = tints;
		int num4 = index % array2.Length;
		PhaserSprite phaserSprite2 = crystalSprite.setTint((uint)array2[num4]);
		object obj6 = UnityEngine.Random.value;
		Transform transform = crystalSprite.transform;
		object obj7 = default(object);
		transform.localEulerAngles = (Vector3)(&obj7);
		PhaserSprite phaserSprite3 = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite4 = crystalSprite;
		phaserSprite4._spriteAnimation.SetAnimation("idle");
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num5 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		object obj8 = default(object);
		float duration = (float)obj8 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		return;
		IL_0395:
		bool flag = obj4 == null;
		num = (float?)(object)0;
		if (!flag)
		{
			num = (float?)_weapon;
		}
		goto IL_0386;
		IL_0386:
		trueWeapon = (Sample1Weapon)num;
		BaseBody baseBody2 = body;
		BulletPool bulletPool = (BulletPool)(object)baseBody2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v96 @ rdx_v34 (VampireSurvivors.Objects.Pools.BulletPool)+218] (should have been resolved before IL gen)");
		goto IL_0377;
	}

	public unsafe void SetFloorTarget(float duration, float2 targetPos)
	{
		//IL_003f: Expected I, but got O
		//IL_00b0: Expected O, but got I4
		//IL_0152: Expected I, but got O
		//IL_01a8: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected I4, but got Unknown
		if (_moveXTween != null)
		{
			_moveXTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = duration;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.x = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				//IL_00b6: Expected O, but got I4
				//IL_0021: Expected O, but got I4
				SfxType[] array3 = dropSounds;
				object obj6 = UnityEngine.Random.RandomRangeInt(0, array3.Length);
				SfxType[] array4 = dropSounds;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[obj6]), soundConfig, 400f, 10, time);
				PhaserSprite phaserSprite2 = crystalSprite.setVisible(visible: true);
				BaseBody baseBody = body;
				baseBody._enable = true;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween moveXTween = Tweens.Add(tweenConfig);
			_moveXTween = moveXTween;
			if (_moveYTween != null)
			{
				_moveYTween.Kill();
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
				tweenConfig2.y = (float?)(object)1;
				tweenConfig2.duration = duration;
				Weapon weapon = _weapon;
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				object obj3 = default(object);
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
				object obj4 = obj3 - obj3;
				bool flag2 = obj4 == null;
				object obj5 = flag | flag2;
				Ease ease = (Ease)(obj5 + 26);
				tweenConfig2.ease = ease;
				MultiTargetTween moveYTween = Tweens.Add(tweenConfig2);
				_moveYTween = moveYTween;
				PhaserSprite phaserSprite = crystalSprite.setPosition(targetPos);
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public unsafe void Dropped()
	{
		//IL_00b6: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		SfxType[] array = dropSounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		SfxType[] array2 = dropSounds;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 10, time);
		PhaserSprite phaserSprite = crystalSprite.setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	public unsafe void Break()
	{
		//IL_0254: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0147: Expected I, but got O
		//IL_01b6: Expected O, but got I4
		//IL_016a->IL016a: Incompatible stack heights: 1 vs 0
		if (!isBreaking)
		{
			isBreaking = true;
			SfxType[] array = stepSounds;
			object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
			SfxType[] array2 = stepSounds;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 10, time);
			float2 pos = crystalSprite.position;
			trueWeapon.SpawnExplosionClustersAt(pos);
			PhaserSprite phaserSprite = crystalSprite.setVisible(visible: true);
			PhaserSprite phaserSprite2 = crystalSprite;
			phaserSprite2._spriteAnimation.SetAnimation("break");
			if (crystalTween != null)
			{
				crystalTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)crystalSprite != null)
			{
				nint num = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				bool flag = obj2 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array3;
			float num2 = _weapon.PArea();
			tweenConfig.duration = 500f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Despawn();
				PhaserSprite phaserSprite3 = crystalSprite.setVisible(visible: false);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			crystalTween = multiTargetTween;
			Shrink();
		}
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
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 10, time);
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
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 10, time);
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
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass22_0();
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
		PhaserSprite phaserSprite = crystalSprite.setVisible(visible: false);
		base.Despawn();
	}

	public Sample1Projectile()
	{
		string[] array = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		frameNames = array;
		tints = new int[3] { 16738030, 13378252, 16711935 };
		dropSounds = new SfxType[4]
		{
			SfxType.DLC3_SampleDrop1,
			SfxType.DLC3_SampleDrop2,
			SfxType.DLC3_SampleDrop3,
			SfxType.DLC3_SampleDrop4
		};
		stepSounds = new SfxType[4]
		{
			SfxType.DLC3_SamplePickup1,
			SfxType.DLC3_SamplePickup2,
			SfxType.DLC3_SamplePickup3,
			SfxType.DLC3_SamplePickup4
		};
		base._002Ector();
	}

	private unsafe void _003CSetFloorTarget_003Eb__16_0()
	{
		//IL_00b6: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		SfxType[] array = dropSounds;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		SfxType[] array2 = dropSounds;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[obj]), soundConfig, 400f, 10, time);
		PhaserSprite phaserSprite = crystalSprite.setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003CBreak_003Eb__18_0()
	{
		Despawn();
		PhaserSprite phaserSprite = crystalSprite.setVisible(visible: false);
	}

	private void _003CStartDespawn_003Eb__21_0()
	{
		Despawn();
	}
}
