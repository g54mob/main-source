using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Icicle2_RuneProjectile : Projectile
{
	private const float BodyRadius = 14f;

	private const float Radius = 0.15f;

	private const float PfxFrequency = 100f;

	private readonly uint[] _pfxTints = new uint[4] { 16777215u, 8454143u, 65535u, 33023u };

	private TP_Icicle2_Weapon _trueWeapon;

	private PhaserSprite _runeSprite;

	private ParticleSystem _pfx;

	private Timer _hitboxTimer;

	private Timer _pfxTintTimer;

	private Tween _scaleTween;

	private Tween _posTween;

	private bool _updatePosition;

	protected override void Awake()
	{
		//IL_010b: Expected I, but got O
		base.Awake();
		GenerateParticleSystem();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F68D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "des_m");
			nint num = (nint)typeof(float2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v24 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
			nint num2 = 0;
			PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(vector);
			PhaserSprite phaserSprite3 = phaserSprite2.setTint(65535u);
			PhaserSprite phaserSprite4 = phaserSprite3.setDepth(1);
			GameObject gameObject2 = phaserSprite4.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_runeSprite");
			_runeSprite = phaserSprite4;
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_m");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_a");
			}
			else
			{
				int num4 = list._size + 1;
				list._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_s");
			}
			else
			{
				int num5 = list._size + 1;
				list._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_c");
			}
			else
			{
				int num6 = list._size + 1;
				list._size = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_a");
			}
			else
			{
				int num7 = list._size + 1;
				list._size = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list._version + 1;
			list._version = version6;
			string[] items6 = list._items;
			if (list._size >= items6.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_r");
			}
			else
			{
				int num8 = list._size + 1;
				list._size = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version7 = list._version + 1;
			list._version = version7;
			string[] items7 = list._items;
			if (list._size >= items7.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_p");
			}
			else
			{
				int num9 = list._size + 1;
				list._size = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version8 = list._version + 1;
			list._version = version8;
			string[] items8 = list._items;
			if (list._size >= items8.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_o");
			}
			else
			{
				int num10 = list._size + 1;
				list._size = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version9 = list._version + 1;
			list._version = version9;
			string[] items9 = list._items;
			if (list._size >= items9.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_n");
			}
			else
			{
				int num11 = list._size + 1;
				list._size = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version10 = list._version + 1;
			list._version = version10;
			string[] items10 = list._items;
			if (list._size >= items10.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"des_e");
			}
			else
			{
				int num12 = list._size + 1;
				list._size = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(list, "vfx");
			PhaserSprite runeSprite = _runeSprite;
			bool shouldLoop = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			runeSprite._spriteAnimation.AddAnimation("idle", animationFrames, 2, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite runeSprite2 = _runeSprite;
			runeSprite2._spriteAnimation.SetAnimation("idle");
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_01f5: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0103: Expected O, but got I4
		//IL_0103: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_022a: Expected O, but got I
		//IL_0252: Expected I, but got O
		//IL_0296: Expected O, but got I4
		//IL_016a: Expected I, but got I8
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_01ce;
		}
		nint num = (nint)typeof(TP_Icicle2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v37+FFFFFFF8+v68 @ rax_v32*8]");
			if (0 == (nint)typeof(TP_Icicle2_Weapon))
			{
				obj3 = 1;
				goto IL_01dd;
			}
		}
		obj3 = 0;
		goto IL_01dd;
		IL_01dd:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_01ce;
		IL_01ce:
		_trueWeapon = (TP_Icicle2_Weapon)trueWeapon;
		_isCullable = false;
		_updatePosition = true;
		BaseBody baseBody = body.setCircle(14f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ScaleIn();
		StartTimers();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag2 = (nint)0 != 0;
		nint num4 = (nint)typeof(SoundManager.SoundConfig);
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj4 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num4 = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v387 @ rax_v17 (should have been resolved before IL gen)");
		float detune = 3f * -100f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Globus, soundConfig, 200f, 10, time);
	}

	private void ScaleIn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 1f, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			_pfx.Play(withChildren: true);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
	}

	private void StartTimers()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			if (_objectsHit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			}
		};
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if (_pfxTintTimer != null)
		{
			_pfxTintTimer.Cancel();
		}
		Action onComplete2 = RandomisePfxTint;
		Timer pfxTintTimer = Timers.Register(0.1f, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_pfxTintTimer = pfxTintTimer;
	}

	private void PlaySfx()
	{
		//IL_009f: Expected O, but got I
		//IL_00c7: Expected I, but got O
		//IL_010b: Expected O, but got I4
		//IL_003e: Expected I, but got I8
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		nint num = (nint)typeof(SoundManager.SoundConfig);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v52 @ rax_v4 (should have been resolved before IL gen)");
		float detune = 3f * -100f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Globus, soundConfig, 200f, 10, time);
	}

	private unsafe void RandomisePfxTint()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0144: Expected O, but got I4
		//IL_00ad: Expected O, but got Ref
		//IL_00bb: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		uint[] pfxTints = _pfxTints;
		object obj3 = UnityEngine.Random.RandomRangeInt(0, pfxTints.Length);
		_ = 1065353216;
		int num = (int)pfxTints[obj3] >> 16;
		int num2 = (int)pfxTints[obj3] >> 8;
		float num3 = (float)num / 255f;
		float num4 = (float)(int)pfxTints[obj3] / 255f;
		float num5 = (float)num2 / 255f;
		_ = _pfx;
		_ = _pfx;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxGradient startColor = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startColor = startColor;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0062: Expected O, but got Ref
		//IL_00ee->IL00b8: Incompatible stack heights: 1 vs 0
		float num = base.scale;
		float num2 = _trueWeapon.PArea();
		float num3 = num * 0.3f;
		float num4 = num3 + 1f;
		float min = num4 * num;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
		object obj = default(object);
		sizeOverLifetimeModule.size = (ParticleSystem.MinMaxCurve)(&obj);
		if (_updatePosition)
		{
			Transform cachedTransform = _cachedTransform;
			Vector3 localPosition = GetLocalPosition();
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	private unsafe void LateUpdate()
	{
		//IL_003d: Expected O, but got Ref
		TP_Icicle2_Weapon trueWeapon = _trueWeapon;
		Vector3 localEulerAngles = trueWeapon._RuneContainer.localEulerAngles;
		Transform transform = base.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private unsafe void UpdatePfxScale()
	{
		//IL_0068: Expected O, but got Ref
		float num = base.scale;
		float num2 = _trueWeapon.PArea();
		float num3 = num * 0.3f;
		float num4 = num3 + 1f;
		float min = num4 * num;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
		object obj = default(object);
		sizeOverLifetimeModule.size = (ParticleSystem.MinMaxCurve)(&obj);
	}

	private unsafe void UpdateRotation()
	{
		//IL_003d: Expected O, but got Ref
		TP_Icicle2_Weapon trueWeapon = _trueWeapon;
		Vector3 localEulerAngles = trueWeapon._RuneContainer.localEulerAngles;
		Transform transform = base.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private unsafe void UpdatePosition()
	{
		//IL_0078->IL0042: Incompatible stack heights: 1 vs 0
		if (_updatePosition)
		{
			Transform cachedTransform = _cachedTransform;
			Vector3 localPosition = GetLocalPosition();
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	public unsafe void MoveToNewPosition()
	{
		//IL_003d: Expected O, but got Ref
		_updatePosition = false;
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		Vector3 localPosition = GetLocalPosition();
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMove(_cachedTransform, (Vector3)(&obj), 0.5f);
		TweenCallback tweenCallback = delegate
		{
			_updatePosition = true;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_posTween = tweenerCore;
	}

	private unsafe Vector3 GetLocalPosition()
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_008d: Expected I, but got O
		//IL_0185: Expected native int or pointer, but got O
		//IL_01ac: Expected native int or pointer, but got O
		//IL_01c9: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		TP_Icicle2_Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			bool flag = trueWeapon._003CNumRunes_003Ek__BackingField <= 1;
			int num = 1;
			if (!flag)
			{
				num = trueWeapon._003CNumRunes_003Ek__BackingField;
			}
			Weapon weapon = _weapon;
			float num2 = 360f / (float)num;
			float num3 = num2 * (float)_indexInWeapon;
			float num4 = num3 * ((float)Math.PI / 180f);
			if ((object)_weapon != null)
			{
				nint num5 = (nint)weapon;
				float num6 = _weapon.PArea();
				int num7;
				if (0 <= _indexInWeapon)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
					num7 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
					num7 = _indexInWeapon;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num8 = num4 * (float)num7;
				float x = num8 * 0.15f;
				((Vector3*)(nint)vector)->x = x;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num9 = num4 * (float)num7;
				((Vector3*)(nint)vector)->z = 0f;
				float y = num9 * 0.15f;
				((Vector3*)(nint)vector)->y = y;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_pfxTintTimer != null)
		{
			_pfxTintTimer.Cancel();
		}
		_pfx.Stop();
		base.Despawn();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00e7: Expected native int or pointer, but got O
		//IL_02b2: Expected O, but got I
		//IL_011f: Expected O, but got Ref
		//IL_0146: Expected O, but got I
		//IL_015b: Expected native int or pointer, but got O
		//IL_0175: Expected O, but got I
		//IL_02e5: Expected O, but got I4
		//IL_01c3: Expected O, but got Ref
		//IL_01d8: Expected O, but got I
		//IL_01f2: Expected native int or pointer, but got O
		//IL_0305: Expected O, but got I
		//IL_0251: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Page");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(50f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		uint[] pfxTints = _pfxTints;
		object obj3 = UnityEngine.Random.RandomRangeInt(0, pfxTints.Length);
		_ = 0;
		_ = 1;
		_ = pfxTints[obj3];
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._tint = (uint?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = true;
		_ = 1120403456;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._frequency = (float?)(object)0;
		ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfx = pfx;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			bool flag = TryFreeze(other);
		}
	}

	private void _003CScaleIn_003Eb__14_0()
	{
		_pfx.Play(withChildren: true);
	}

	private void _003CStartTimers_003Eb__15_0()
	{
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void _003CMoveToNewPosition_003Eb__23_0()
	{
		_updatePosition = true;
	}
}
