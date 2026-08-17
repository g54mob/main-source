using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_VampireKiller_Explosion_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public TP_VampireKiller_Explosion_Projectile _003C_003E4__this;

		public int i;
	}

	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public PhaserSprite explo;

		public float area;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		public TweenCallback _003C_003E9__1;

		internal void _003CExplode_003Eb__0()
		{
			//IL_0094: Expected O, but got I4
			//IL_033d: Expected O, but got F4
			//IL_00a6: Invalid comparison between O and F4
			//IL_00c5: Invalid comparison between F4 and I4
			//IL_0356: Expected O, but got I4
			//IL_0364: Expected O, but got F4
			//IL_01b1: Expected O, but got I4
			//IL_023f: Expected I, but got O
			//IL_037c: Expected O, but got F4
			//IL_038a: Expected O, but got I4
			//IL_03a2: Expected O, but got F4
			//IL_03f1: Expected O, but got I4
			//IL_0409: Expected O, but got F4
			//IL_0457: Expected O, but got I4
			//IL_04a8: Expected O, but got F4
			//IL_04d6: Expected O, but got I4
			//IL_0465: Expected O, but got F4
			//IL_0473: Expected O, but got I4
			//IL_0262->IL0262: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass21_0 obj = CS_0024_003C_003E8__locals1;
			float2 position = obj._003C_003E4__this.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite = explo.setVisible(visible: true);
			PhaserSprite phaserSprite2 = explo;
			phaserSprite2._spriteAnimation.SetAnimation("bang");
			PhaserSprite phaserSprite3 = explo.setAlpha(0.95f);
			PhaserSprite phaserSprite4 = explo.setScale(0.5f, (float?)(object)0);
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
			float num = (float)obj3 - 0.5f;
			bool flag2 = num == 0f;
			BlendMode blendMode = ((flag | flag2) ? BlendMode.Add : BlendMode.Normal);
			PhaserSprite phaserSprite5 = explo.setBlendMode(blendMode);
			_003C_003Ec__DisplayClass21_0 obj4 = CS_0024_003C_003E8__locals1;
			TP_VampireKiller_Explosion_Projectile tP_VampireKiller_Explosion_Projectile = obj4._003C_003E4__this;
			uint[] tints = tP_VampireKiller_Explosion_Projectile._tints;
			object obj5 = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			PhaserSprite phaserSprite6 = explo.setTint(tints[obj5]);
			_003C_003Ec__DisplayClass21_0 obj6 = CS_0024_003C_003E8__locals1;
			TP_VampireKiller_Explosion_Projectile tP_VampireKiller_Explosion_Projectile2 = obj6._003C_003E4__this;
			SfxType sfxType = Extensions.PickRnd(tP_VampireKiller_Explosion_Projectile2.sfxs);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj7 = UnityEngine.Random.value;
			_003C_003Ec__DisplayClass21_0 obj8 = CS_0024_003C_003E8__locals1;
			float num2 = (float)obj3 * -100f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)obj8.i * num2;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 10, time);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)explo != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				bool flag3 = obj9 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			object obj10 = UnityEngine.Random.value;
			tweenConfig.scale = (float?)(object)1;
			_003C_003Ec__DisplayClass21_0 obj11 = CS_0024_003C_003E8__locals1;
			float2 position2 = obj11._003C_003E4__this.position;
			object obj12 = UnityEngine.Random.value;
			float num4 = 1f - 0.5f;
			float num5 = num4 * 0.16f;
			float num6 = num5 * area;
			float num7 = num6 + (float)position2;
			tweenConfig.x = (float?)(object)1;
			_003C_003Ec__DisplayClass21_0 obj13 = CS_0024_003C_003E8__locals1;
			float2 position3 = obj13._003C_003E4__this.position;
			object obj14 = UnityEngine.Random.value;
			float num8 = num7 - 0.5f;
			float num9 = num8 * 0.16f;
			float num10 = num9 * area;
			object obj15 = default(object);
			float num11 = num10 + (float)obj15;
			tweenConfig.y = (float?)(object)1;
			object obj16 = UnityEngine.Random.value;
			float num12 = num11 * 100f;
			float duration = num12 + 275f;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = duration;
			object obj17 = UnityEngine.Random.value;
			tweenConfig.angle = (float?)(object)1;
			TweenCallback onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					PhaserSprite phaserSprite7 = explo.setAlpha(0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			_003C_003Ec__DisplayClass21_0 obj18 = CS_0024_003C_003E8__locals1;
			obj18._003C_003E4__this.DisplayRandomFlare();
		}

		internal void _003CExplode_003Eb__1()
		{
			PhaserSprite phaserSprite = explo.setAlpha(0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public PhaserSprite __sprite;

		public TP_VampireKiller_Explosion_Projectile _003C_003E4__this;

		internal void _003CDisplayRandomFlare_003Eb__0()
		{
			//IL_004c: Expected O, but got I4
			//IL_00a7: Expected O, but got I4
			PhaserSprite phaserSprite = __sprite.setVisible(visible: true);
			PhaserSprite phaserSprite2 = __sprite.setAlpha(1f);
			PhaserSprite phaserSprite3 = __sprite.setScale(0f, (float?)(object)0);
			TP_VampireKiller_Explosion_Projectile tP_VampireKiller_Explosion_Projectile = _003C_003E4__this;
			uint[] tints = tP_VampireKiller_Explosion_Projectile._tints;
			object obj = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			PhaserSprite phaserSprite4 = __sprite.setTint(tints[obj]);
		}

		internal void _003CDisplayRandomFlare_003Eb__1()
		{
			PhaserSprite phaserSprite = __sprite.setVisible(visible: false);
			PhaserSprite phaserSprite2 = __sprite.setAlpha(0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public PhaserSprite _beamSprite;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CDisplayRandomFlare_003Eb__2()
		{
			//IL_004c: Expected O, but got I4
			//IL_0076: Expected O, but got Ref
			//IL_0090: Expected O, but got I4
			//IL_00fd: Expected O, but got I4
			PhaserSprite phaserSprite = _beamSprite.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _beamSprite.setAlpha(1f);
			PhaserSprite phaserSprite3 = _beamSprite.setScale(0.25f, (float?)(object)0);
			Transform transform = _beamSprite.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			PhaserSprite phaserSprite4 = _beamSprite.setOrigin(0.5f, (float?)(object)0);
			_003C_003Ec__DisplayClass22_0 obj2 = CS_0024_003C_003E8__locals1;
			TP_VampireKiller_Explosion_Projectile tP_VampireKiller_Explosion_Projectile = obj2._003C_003E4__this;
			uint[] tints = tP_VampireKiller_Explosion_Projectile._tints;
			object obj3 = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			PhaserSprite phaserSprite5 = _beamSprite.setTint(tints[obj3]);
		}

		internal void _003CDisplayRandomFlare_003Eb__3()
		{
			PhaserSprite phaserSprite = _beamSprite.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_2
	{
		public uint beamTint;
	}

	private sealed class _003C_003Ec__DisplayClass22_3
	{
		public PhaserSprite _beamSprite;

		public int localIndex;

		public _003C_003Ec__DisplayClass22_2 CS_0024_003C_003E8__locals2;

		internal unsafe void _003CDisplayRandomFlare_003Eb__4()
		{
			//IL_004c: Expected O, but got I4
			//IL_0076: Expected O, but got Ref
			//IL_0090: Expected O, but got I4
			PhaserSprite phaserSprite = _beamSprite.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _beamSprite.setAlpha(1f);
			PhaserSprite phaserSprite3 = _beamSprite.setScale(0.25f, (float?)(object)0);
			Transform transform = _beamSprite.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			PhaserSprite phaserSprite4 = _beamSprite.setOrigin(0.85f, (float?)(object)1);
			_003C_003Ec__DisplayClass22_2 obj2 = CS_0024_003C_003E8__locals2;
			PhaserSprite phaserSprite5 = _beamSprite.setTint(obj2.beamTint);
		}

		internal void _003CDisplayRandomFlare_003Eb__5()
		{
			PhaserSprite phaserSprite = _beamSprite.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public PhaserSprite exp;

		internal void _003CGenerateAnimatedSprites_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private ParticleSystem _pfxEmitter;

	private Tween _scaleTween;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _sunraySprite;

	private uint[] _tints;

	private List<PhaserSprite> explosionSprites;

	private string[] _sideNames;

	private string[] _starNames;

	private string[] _flatNames;

	private List<PhaserSprite> BeamSprites;

	private List<PhaserSprite> SideSprites;

	private List<PhaserSprite> StarSprites;

	private List<PhaserSprite> FlatSprites;

	private List<List<PhaserSprite>> ListOfListsLol;

	private Timer attackTimer;

	private Timer expireTimer;

	private bool _isDespawning;

	private EnemyController _targetEnemy;

	private List<SfxType> sfxs;

	protected override void Awake()
	{
		//IL_0198: Expected O, but got I4
		//IL_0198: Expected I4, but got O
		//IL_0292: Expected O, but got I4
		//IL_0292: Expected I4, but got O
		//IL_02cd: Expected O, but got I4
		//IL_02cd: Expected I4, but got O
		base.Awake();
		List<PhaserSprite> sideSprites = new List<PhaserSprite>();
		SideSprites = sideSprites;
		List<PhaserSprite> starSprites = new List<PhaserSprite>();
		StarSprites = starSprites;
		List<PhaserSprite> flatSprites = new List<PhaserSprite>();
		FlatSprites = flatSprites;
		List<List<PhaserSprite>> listOfListsLol = new List<List<PhaserSprite>>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC000");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC000");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC000");
		ListOfListsLol = listOfListsLol;
		List<PhaserSprite> beamSprites = new List<PhaserSprite>();
		BeamSprites = beamSprites;
		GenerateAnimatedSprites();
		GenerateParticleSystem();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_FireValve02");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_FireValve", 2, 5, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
		PhaserSprite phaserSprite = _animatedSprite.setBlendMode(BlendMode.Add);
		GameObject gameObject2 = base.gameObject;
		PhaserSprite sunraySprite = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_TeleportRay01");
		_sunraySprite = sunraySprite;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_TeleportRay", 1, 5, vector, text, num, flag);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_TeleportRay", 6, 10, vector, text, num, flag);
		PhaserSprite sunraySprite2 = _sunraySprite;
		sunraySprite2._spriteAnimation.AddAnimation("sunray", animationFrames2, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite sunraySprite3 = _sunraySprite;
		sunraySprite3._spriteAnimation.AddAnimation("unsunray", animationFrames3, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0033: Expected O, but got I4
		//IL_00a2: Expected I, but got O
		//IL_0106: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_targetEnemy = null;
		PhaserSprite phaserSprite = _sunraySprite.setAlpha(0.65f);
		PhaserSprite phaserSprite2 = _sunraySprite.setScale(0f, (float?)(object)1);
		PhaserSprite sunraySprite = _sunraySprite;
		sunraySprite._spriteAnimation.SetAnimation("sunray");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sunraySprite != null)
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
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		Explode();
		if (attackTimer != null)
		{
			attackTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = Explode;
		float num2 = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(num2, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		attackTimer = timer;
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		float num3 = _weapon.PDuration();
		Action onComplete2 = StartDespawn;
		float duration = num2 * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		expireTimer = timer2;
	}

	public unsafe void Explode()
	{
		//IL_00b6: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_019b: Expected I, but got O
		//IL_01b1: Expected O, but got I
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_0228: Expected I, but got O
		//IL_0276: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_02a0: Expected I, but got I8
		//IL_0211: Expected I, but got I8
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		obj._003C_003E4__this = this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		BaseBody baseBody = body;
		baseBody._enable = true;
		obj.i = 1;
		float num2 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			List<PhaserSprite> list = explosionSprites;
			if (obj.i > list._size)
			{
				return;
			}
			_003C_003Ec__DisplayClass21_1 obj2 = new _003C_003Ec__DisplayClass21_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			_003C_003Ec__DisplayClass21_0 obj3 = obj2.CS_0024_003C_003E8__locals1;
			List<PhaserSprite> list2 = explosionSprites;
			object obj4 = obj3.i - 1;
			if ((nint)obj4 >= list2._size)
			{
				break;
			}
			PhaserSprite[] items = list2._items;
			object obj5 = obj3.i - 1;
			obj2.explo = items[obj5];
			float num = _weapon.PArea();
			_003C_003Ec__DisplayClass21_0 obj6 = obj2.CS_0024_003C_003E8__locals1;
			obj2.area = num2;
			Action action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_1._003CExplode_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj7 = (nint)0 >> 4;
			object obj8 = obj7 & 1;
			nint num4;
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_026d;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num4 = ((Delegate)action).method_ptr;
			goto IL_026d;
			IL_026d:
			object obj9 = 24;
			object obj10 = obj6.i * 100;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			num2 = (float)obj10 * 0.001f;
			Timer timer = Timers.Register(num2, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			int i = obj.i + 1;
			obj.i = i;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private unsafe void DisplayRandomFlare()
	{
		//IL_00a2: Expected I, but got O
		//IL_05ea: Expected O, but got F4
		//IL_0615: Expected O, but got I4
		//IL_062d: Expected O, but got F4
		//IL_0679: Expected O, but got I4
		//IL_0691: Expected O, but got F4
		//IL_06eb: Expected O, but got I4
		//IL_0942: Expected O, but got F4
		//IL_0970: Expected O, but got I4
		//IL_06f9: Expected O, but got F4
		//IL_072d: Expected O, but got I4
		//IL_073b: Expected O, but got F4
		//IL_0753: Expected O, but got F4
		//IL_076f: Expected O, but got I4
		//IL_0515: Expected I, but got O
		//IL_0567: Expected O, but got I4
		//IL_08d1: Expected O, but got F4
		//IL_08df: Expected O, but got I4
		//IL_08f7: Expected O, but got F4
		//IL_0913: Expected O, but got I4
		//IL_0243: Expected I, but got O
		//IL_02b0: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		//IL_02cc: Expected O, but got I4
		//IL_0799: Expected I, but got O
		//IL_07af: Expected O, but got I
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected O, but got Unknown
		//IL_0359: Expected I, but got O
		//IL_07e3: Expected O, but got I4
		//IL_07fa: Expected I, but got I8
		//IL_0386: Expected O, but got I
		//IL_0819: Expected I, but got O
		//IL_082f: Expected O, but got I
		//IL_0838: Unknown result type (might be due to invalid IL or missing references)
		//IL_083d: Expected O, but got Unknown
		//IL_0342: Expected I, but got I8
		//IL_0408: Expected I, but got O
		//IL_087a: Expected I, but got I8
		//IL_03f1: Expected I, but got I8
		//IL_0538->IL0538: Incompatible stack heights: 1 vs 0
		//IL_0266->IL0266: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		List<PhaserSprite> list = Extensions.PickRnd(ListOfListsLol);
		PhaserSprite phaserSprite = Extensions.PickRnd(list);
		CS_0024_003C_003E8__locals15.__sprite = phaserSprite;
		float num = _weapon.PArea();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals15.__sprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				goto IL_05d2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		object obj2 = UnityEngine.Random.value;
		object obj4 = default(object);
		object obj3 = obj4 + obj4;
		float num3 = (float)obj3 + 1f;
		tweenConfig.scale = (float?)(object)1;
		float2 float5 = base.position;
		object obj5 = UnityEngine.Random.value;
		float num4 = num3 - 0.5f;
		float num5 = num4 * 0.16f;
		float num6 = num5 * (float)obj4;
		float num7 = num6 + (float)float5;
		tweenConfig.x = (float?)(object)1;
		float2 float6 = base.position;
		object obj6 = UnityEngine.Random.value;
		float num8 = num7 - 0.5f;
		tweenConfig.duration = 100f;
		float num9 = num8 * 0.16f;
		float num10 = num9 * (float)obj4;
		object obj7 = default(object);
		float num11 = num10 + (float)obj7;
		tweenConfig.y = (float?)(object)1;
		object obj8 = UnityEngine.Random.value;
		float num12 = num11 * 90f;
		float num13 = num12 - 45f;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_004c: Expected O, but got I4
			//IL_00a7: Expected O, but got I4
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals15.__sprite.setVisible(visible: true);
			PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals15.__sprite.setAlpha(1f);
			PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals15.__sprite.setScale(0f, (float?)(object)0);
			TP_VampireKiller_Explosion_Projectile tP_VampireKiller_Explosion_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
			uint[] tints2 = tP_VampireKiller_Explosion_Projectile._tints;
			object obj25 = UnityEngine.Random.RandomRangeInt(0, tints2.Length);
			PhaserSprite phaserSprite5 = CS_0024_003C_003E8__locals15.__sprite.setTint(tints2[obj25]);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals15.__sprite.setVisible(visible: false);
			PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals15.__sprite.setAlpha(0f);
		};
		tweenConfig.onComplete = onComplete;
		nint num14 = 0;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		object obj9 = UnityEngine.Random.value;
		if (num13 > 0.85f)
		{
			_003C_003Ec__DisplayClass22_2 obj10 = new _003C_003Ec__DisplayClass22_2();
			uint[] tints = _tints;
			object obj11 = UnityEngine.Random.RandomRangeInt(0, tints.Length);
			obj10.beamTint = tints[obj11];
			float2 float7 = base.position;
			object obj12 = UnityEngine.Random.value;
			float2 float8 = base.position;
			object obj13 = UnityEngine.Random.value;
			List<PhaserSprite> beamSprites = BeamSprites;
			int num15 = 0;
			object obj14 = 0;
			int num16 = 0;
			object obj16 = default(object);
			while (true)
			{
				if (num16 >= beamSprites._size)
				{
					return;
				}
				_003C_003Ec__DisplayClass22_3 obj15 = new _003C_003Ec__DisplayClass22_3();
				obj15.CS_0024_003C_003E8__locals2 = obj10;
				List<PhaserSprite> beamSprites2 = BeamSprites;
				if (num15 >= beamSprites2._size)
				{
					break;
				}
				PhaserSprite[] items = beamSprites2._items;
				obj15._beamSprite = items[num15];
				obj15.localIndex = num15;
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)obj15._beamSprite != null)
				{
					nint num17 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj16 == null;
				}
				array2[0] = obj15._beamSprite;
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 60f;
				tweenConfig2.scaleX = (float?)(object)1;
				tweenConfig2.x = (float?)(object)1;
				tweenConfig2.y = (float?)(object)1;
				TweenCallback tweenCallback = null;
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2691 @ r10_v19 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_3._003CDisplayRandomFlare_003Eb__4);
				((Delegate)tweenCallback).m_target = obj15;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2691 @ r10_v19 (Il2CppMethodInfo)+4C]");
				object obj17 = (nint)0 >> 4;
				object obj18 = obj17 & 1;
				nint num19;
				if (obj18 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2691 @ r10_v19 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num19 = unchecked((nint)6447293664L);
						goto IL_07da;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num19 = ((Delegate)tweenCallback).method_ptr;
				goto IL_07da;
				IL_085a:
				nint num20 = 24;
				TweenCallback tweenCallback2;
				((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
				tweenConfig2.onComplete = tweenCallback2;
				num14 = 24;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				beamSprites = BeamSprites;
				num15++;
				num16 = num15;
				continue;
				IL_07da:
				object obj19 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				tweenConfig2.onStart = tweenCallback;
				tweenCallback2 = null;
				nint num21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r10_v20 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_3._003CDisplayRandomFlare_003Eb__5);
				((Delegate)tweenCallback2).m_target = obj15;
				((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r10_v20 (Il2CppMethodInfo)+4C]");
				object obj20 = (nint)0 >> 4;
				object obj21 = obj20 & 1;
				nint num22;
				if (obj21 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r10_v20 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num22 = unchecked((nint)6447293664L);
						goto IL_085a;
					}
				}
				((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
				num22 = ((Delegate)tweenCallback2).method_ptr;
				goto IL_085a;
			}
		}
		else
		{
			_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass22_1();
			CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals15;
			List<PhaserSprite> beamSprites3 = BeamSprites;
			if (beamSprites3._size > 0)
			{
				PhaserSprite[] items2 = beamSprites3._items;
				CS_0024_003C_003E8__locals23._beamSprite = items2[0];
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				if ((object)CS_0024_003C_003E8__locals23._beamSprite != null)
				{
					nint num23 = (nint)array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj22 = default(object);
					bool flag2 = obj22 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				tweenConfig3.scaleX = (float?)(object)1;
				float2 float9 = base.position;
				object obj23 = UnityEngine.Random.value;
				tweenConfig3.x = (float?)(object)1;
				float2 float10 = base.position;
				object obj24 = UnityEngine.Random.value;
				tweenConfig3.duration = 60f;
				tweenConfig3.y = (float?)(object)1;
				TweenCallback onStart2 = delegate
				{
					//IL_004c: Expected O, but got I4
					//IL_0076: Expected O, but got Ref
					//IL_0090: Expected O, but got I4
					//IL_00fd: Expected O, but got I4
					PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals23._beamSprite.setVisible(visible: true);
					PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals23._beamSprite.setAlpha(1f);
					PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals23._beamSprite.setScale(0.25f, (float?)(object)0);
					Transform transform = CS_0024_003C_003E8__locals23._beamSprite.transform;
					object obj25 = default(object);
					transform.localEulerAngles = (Vector3)(&obj25);
					PhaserSprite phaserSprite5 = CS_0024_003C_003E8__locals23._beamSprite.setOrigin(0.5f, (float?)(object)0);
					_003C_003Ec__DisplayClass22_0 obj26 = CS_0024_003C_003E8__locals23.CS_0024_003C_003E8__locals1;
					TP_VampireKiller_Explosion_Projectile tP_VampireKiller_Explosion_Projectile = obj26._003C_003E4__this;
					uint[] tints2 = tP_VampireKiller_Explosion_Projectile._tints;
					object obj27 = UnityEngine.Random.RandomRangeInt(0, tints2.Length);
					PhaserSprite phaserSprite6 = CS_0024_003C_003E8__locals23._beamSprite.setTint(tints2[obj27]);
				};
				tweenConfig3.onStart = onStart2;
				TweenCallback onComplete2 = delegate
				{
					PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals23._beamSprite.setVisible(visible: false);
				};
				tweenConfig3.onComplete = onComplete2;
				MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_05d2;
		IL_05d2:
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void SetTargetEnemy(EnemyController enemy)
	{
		_targetEnemy = enemy;
	}

	private void LateUpdate()
	{
		EnemyController targetEnemy = _targetEnemy;
		if ((object)_targetEnemy != null && ((UnityEngine.Object)targetEnemy).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite targetEnemy2 = _targetEnemy;
			if ((object)_targetEnemy != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v11 (ArcadeSprite)+260]");
				if ((nint)0 != 0)
				{
					goto IL_0247;
				}
				int num = _targetEnemy.depth;
				int num2 = num + 1;
				ArcadeSprite arcadeSprite = setDepth(num2);
				if ((object)_targetEnemy != null)
				{
					float2 float5 = _targetEnemy.position;
					if ((object)_targetEnemy != null)
					{
						float2 float6 = _targetEnemy.position;
						float2 float7 = default(float2);
						base.position = float7;
						int num3 = base.depth;
						if ((object)_sunraySprite != null)
						{
							int num4 = num3 - 2;
							PhaserSprite phaserSprite = _sunraySprite.setDepth(num4);
							int num5 = base.depth;
							if ((object)_animatedSprite != null)
							{
								int num6 = num5 + 1;
								PhaserSprite phaserSprite2 = _animatedSprite.setDepth(num6);
								if (explosionSprites != null)
								{
									List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
									if (enumerator.MoveNext())
									{
										int num7 = base.depth;
										throw new NullReferenceException();
									}
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0247;
		IL_0247:
		StartDespawn();
	}

	public void StartDespawn()
	{
		//IL_007b: Expected I, but got O
		//IL_00df: Expected O, but got I4
		//IL_01a0: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		PhaserSprite sunraySprite = _sunraySprite;
		_isDespawning = true;
		sunraySprite._spriteAnimation.SetAnimation("unsunray");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sunraySprite != null)
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
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		if (attackTimer != null)
		{
			attackTimer.Cancel();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		float hitBoxDelay = _weapon.HitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Explosion_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void GenerateAnimatedSprites()
	{
		//IL_0932: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0164: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		//IL_02bc: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_0452: Expected O, but got I4
		//IL_045b: Expected O, but got I4
		//IL_0622: Expected O, but got I4
		//IL_063f: Expected O, but got I4
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_06ba: Expected I, but got O
		//IL_06d0: Expected O, but got I
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06de: Expected O, but got Unknown
		//IL_0747: Expected I, but got O
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_09d3: Expected O, but got I4
		//IL_09ea: Expected I, but got I8
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		//IL_0730: Expected I, but got I8
		//IL_081b: Expected I4, but got I8
		//IL_08f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Expected O, but got Unknown
		object obj = 0;
		Vector2 vector = default(Vector2);
		do
		{
			GameObject gameObject = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "_phaser");
			PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
			PhaserSprite phaserSprite3 = phaserSprite.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite4 = phaserSprite.setOrigin(1f, (float?)(object)1);
			List<object> beamSprites = (List<object>)(object)BeamSprites;
			int version = beamSprites._version + 1;
			beamSprites._version = version;
			object[] items = beamSprites._items;
			if (beamSprites._size >= items.Length)
			{
				beamSprites.AddWithResize((object)phaserSprite);
			}
			else
			{
				int num = beamSprites._size + 1;
				beamSprites._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
		}
		while ((nint)obj < 5);
		string[] sideNames = _sideNames;
		Vector2 vector2 = vector;
		object obj2 = 0;
		object obj3 = 0;
		while ((nint)obj3 < sideNames.Length)
		{
			string[] sideNames2 = _sideNames;
			GameObject gameObject2 = base.gameObject;
			PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "vfx", sideNames2[obj2]);
			PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
			PhaserSprite phaserSprite7 = phaserSprite5.setBlendMode(BlendMode.Add);
			List<object> sideSprites = (List<object>)(object)SideSprites;
			int version2 = sideSprites._version + 1;
			sideSprites._version = version2;
			object[] items2 = sideSprites._items;
			if (sideSprites._size >= items2.Length)
			{
				sideSprites.AddWithResize((object)phaserSprite5);
			}
			else
			{
				int num2 = sideSprites._size + 1;
				sideSprites._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			sideNames = _sideNames;
			obj2++;
			vector2 = vector;
			obj3 = obj2;
		}
		string[] starNames = _starNames;
		object obj4 = 0;
		object obj5 = 0;
		int num3 = default(int);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		bool flag2;
		do
		{
			if ((nint)obj5 >= starNames.Length)
			{
				string[] flatNames = _flatNames;
				object obj6 = 0;
				object obj7 = 0;
				bool flag;
				do
				{
					if ((nint)obj7 >= flatNames.Length)
					{
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_FireDesat", 19, 29, "ThosePeople", num3);
						List<PhaserSprite> list = new List<PhaserSprite>();
						explosionSprites = list;
						object obj8 = 0;
						Transform transform;
						while (true)
						{
							_003C_003Ec__DisplayClass26_0 obj9 = new _003C_003Ec__DisplayClass26_0();
							PhaserWorld instance = PhaserWorld.Instance;
							PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "ThosePeople", "TP_VFX_FireDesat19");
							obj9.exp = exp;
							PhaserSprite exp2 = obj9.exp;
							Action action = null;
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r10_v5 (Il2CppMethodInfo)+8]");
							((Delegate)action).method_ptr = (IntPtr)0;
							((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass26_0._003CGenerateAnimatedSprites_003Eb__0);
							((Delegate)action).m_target = obj9;
							((Delegate)action).method_code = (IntPtr)action;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r10_v5 (Il2CppMethodInfo)+4C]");
							object obj10 = (nint)0 >> 4;
							object obj11 = obj10 & 1;
							nint num5;
							if (obj11 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r10_v5 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num5 = unchecked((nint)6447293664L);
									goto IL_09ca;
								}
							}
							((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
							num5 = ((Delegate)action).method_ptr;
							goto IL_09ca;
							IL_09ca:
							object obj12 = 24;
							((Delegate)action).extra_arg = unchecked((nint)6447293568L);
							exp2._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)num3 != 0, startRandomFrame, onComplete, autoSetAnimation);
							PhaserSprite phaserSprite8 = obj9.exp.setVisible(visible: false);
							transform = obj9.exp.transform;
							if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
							{
								break;
							}
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1770 @ rcx_v47 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							PhaserSprite phaserSprite9 = obj9.exp.setDepth(-1);
							PhaserSprite exp3 = obj9.exp;
							exp3._spriteAnimation.SetAnimation("bang");
							List<object> list2 = (List<object>)(object)explosionSprites;
							int version3 = list2._version + 1;
							list2._version = version3;
							object[] items3 = list2._items;
							if (list2._size >= items3.Length)
							{
								list2.AddWithResize((object)obj9.exp);
							}
							else
							{
								int num7 = list2._size + 1;
								list2._size = num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							obj8++;
							if ((nint)obj8 >= 6)
							{
								return;
							}
						}
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
						break;
					}
					string[] flatNames2 = _flatNames;
					GameObject gameObject3 = base.gameObject;
					PhaserSprite phaserSprite10 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "vfx", flatNames2[obj6]);
					PhaserSprite phaserSprite11 = phaserSprite10.setVisible(visible: false);
					PhaserSprite phaserSprite12 = phaserSprite10.setBlendMode(BlendMode.Add);
					List<object> flatSprites = (List<object>)(object)FlatSprites;
					int version4 = flatSprites._version + 1;
					flatSprites._version = version4;
					object[] items4 = flatSprites._items;
					if (flatSprites._size >= items4.Length)
					{
						flatSprites.AddWithResize((object)phaserSprite10);
					}
					else
					{
						int num8 = flatSprites._size + 1;
						flatSprites._size = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					flatNames = _flatNames;
					obj6++;
					flag = _flatNames != null;
					vector2 = vector;
					obj7 = obj6;
				}
				while (flag);
				break;
			}
			string[] starNames2 = _starNames;
			GameObject gameObject4 = base.gameObject;
			PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(gameObject4, vector, "vfx", starNames2[obj4]);
			PhaserSprite phaserSprite14 = phaserSprite13.setVisible(visible: false);
			PhaserSprite phaserSprite15 = phaserSprite13.setBlendMode(BlendMode.Add);
			List<object> starSprites = (List<object>)(object)StarSprites;
			int version5 = starSprites._version + 1;
			starSprites._version = version5;
			object[] items5 = starSprites._items;
			if (starSprites._size >= items5.Length)
			{
				starSprites.AddWithResize((object)phaserSprite13);
			}
			else
			{
				int num9 = starSprites._size + 1;
				starSprites._size = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			starNames = _starNames;
			obj4++;
			flag2 = _starNames != null;
			vector2 = vector;
			obj5 = obj4;
		}
		while (flag2);
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04f3: Expected O, but got Ref
		//IL_051a: Expected O, but got I
		//IL_052f: Expected native int or pointer, but got O
		//IL_0549: Expected O, but got I
		//IL_0569: Expected O, but got Ref
		//IL_0583: Expected native int or pointer, but got O
		//IL_0687: Expected O, but got I
		//IL_05bb: Expected O, but got Ref
		//IL_05d5: Expected native int or pointer, but got O
		//IL_06c1: Expected O, but got I
		//IL_0626: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball01");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball02");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball03");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball04");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball05");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball06");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball07");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball08");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.65f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-31]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
		_ = 0;
		particleSystemConfig._on = false;
		particleSystemConfig._tintRandom = _tints;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if (attackTimer != null)
		{
			attackTimer.Cancel();
		}
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		base.Despawn();
	}

	public TP_VampireKiller_Explosion_Projectile()
	{
		//IL_0160: Expected O, but got I
		//IL_01ba: Expected O, but got I
		//IL_02fd: Expected O, but got I
		//IL_0224: Expected O, but got I
		//IL_0325: Expected O, but got I
		//IL_028e: Expected O, but got I
		_tints = new uint[3] { 16725010u, 16776978u, 16725247u };
		string[] sideNames = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_sideNames = sideNames;
		string[] starNames = new string[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_starNames = starNames;
		string[] flatNames = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_flatNames = flatNames;
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v28+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)25);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 25;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v30+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)24);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v32+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)264);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 264;
		}
		sfxs = list;
		base._002Ector();
	}
}
