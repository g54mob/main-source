using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SpellstreamProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public bool dieOnStop;

		public SpellstreamProjectile _003C_003E4__this;

		internal void _003CInitProjectile_003Eb__1()
		{
			if (dieOnStop)
			{
				_003C_003E4__this.Despawn();
			}
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			//IL_0015: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(1f, (float?)(object)0);
		}

		internal void _003CInitProjectile_003Eb__0()
		{
			_003C_003E4__this.Despawn();
		}

		internal void _003CInitProjectile_003Eb__3()
		{
			SpellstreamProjectile spellstreamProjectile = _003C_003E4__this;
			spellstreamProjectile.Deceleration = 2f;
		}
	}

	private ParticleEmitterManager _pfxEmitter;

	private Circle _emitZone;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _speedTween;

	private Vector2 _aimVec;

	private float _setDuration = 750f;

	private Timer _durationTween;

	[NonSerialized]
	public float Deceleration;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004e: Expected O, but got I4
		//IL_012a: Expected O, but got I
		//IL_0767: Expected O, but got I4
		//IL_02d4: Expected O, but got Ref
		//IL_02fb: Expected O, but got I
		//IL_0315: Expected native int or pointer, but got O
		//IL_032f: Expected O, but got I
		//IL_034f: Expected O, but got Ref
		//IL_0369: Expected native int or pointer, but got O
		//IL_0784: Expected O, but got I4
		//IL_039b: Expected O, but got Ref
		//IL_03b5: Expected native int or pointer, but got O
		//IL_07be: Expected O, but got I
		//IL_080a: Expected O, but got I
		//IL_05d6: Expected O, but got Ref
		//IL_05fd: Expected O, but got I
		//IL_0617: Expected native int or pointer, but got O
		//IL_0631: Expected O, but got I
		//IL_0651: Expected O, but got Ref
		//IL_066b: Expected native int or pointer, but got O
		//IL_0844: Expected O, but got I
		//IL_06a3: Expected O, but got Ref
		//IL_06bd: Expected native int or pointer, but got O
		//IL_0876: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_isCullable = false;
		_aimVec = (Vector2)0;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		_emitZone = circle;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rbx_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager pfxEmitter;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+140]");
			pfxEmitter = (ParticleEmitterManager)0;
		}
		else
		{
			pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell1");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell2");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+140]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f, 700f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _emitZone;
		particleSystemConfig._emitZone = emitZone;
		ParticleSystem emitter = _pfxEmitter.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
		_emitter1 = emitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"2Spell3");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"2Spell4");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+140]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(100f, 200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._on = false;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _emitZone;
		particleSystemConfig2._emitZone = emitZone2;
		ParticleSystem emitter2 = _pfxEmitter.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_emitter2 = emitter2;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0031: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Ref, but got Unknown
		//IL_0101: Expected O, but got I4
		//IL_0101: Expected F4, but got O
		//IL_0127: Invalid comparison between F4 and I
		//IL_014f: Invalid comparison between F4 and I4
		//IL_01fd: Expected I, but got O
		//IL_028a: Expected O, but got I4
		//IL_045a: Expected I, but got O
		//IL_03fc: Expected I, but got O
		//IL_058d: Expected O, but got I4
		//IL_05bb: Expected F4, but got I4
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		base.InitProjectile(pool, weapon, index);
		_aimVec = (Vector2)0;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		Deceleration = 2f;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		Transform transform = SetForNearestEnemy(ref *(Vector2*)(this + 256));
		setVelocity((float)_aimVec, (float?)(object)1);
		float num = _weapon.PDuration();
		float setDuration = _setDuration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstreamProjectile)+104]");
		bool flag = setDuration < 0f;
		float num2 = _setDuration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstreamProjectile)+104]");
		float num3 = num2 - 0f;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool dieOnStop = flag4 & flag3;
		CS_0024_003C_003E8__locals8.dieOnStop = dieOnStop;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num4 = (nint)array;
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
		float num5 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstreamProjectile)+104]");
		float num6 = 0f + 1f;
		float num7 = num6 * 16f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = _setDuration;
		TweenCallback onComplete = delegate
		{
			if (CS_0024_003C_003E8__locals8.dieOnStop)
			{
				CS_0024_003C_003E8__locals8._003C_003E4__this.Despawn();
			}
		};
		tweenConfig.onComplete = onComplete;
		TweenCallback onStart = delegate
		{
			//IL_0015: Expected O, but got I4
			ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals8._003C_003E4__this.setScale(1f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		nint num8 = 0;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		bool flag5 = CS_0024_003C_003E8__locals8.dieOnStop;
		bool flag6 = false;
		bool flag7 = default(bool);
		if (!flag5)
		{
			if (_durationTween != null)
			{
				_durationTween.Cancel();
			}
			float num9 = _weapon.PDuration();
			Action onComplete2 = delegate
			{
				CS_0024_003C_003E8__locals8._003C_003E4__this.Despawn();
			};
			float num10 = num7 * 0.001f;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer durationTween = Timers.Register(num10, onComplete2, null, isLooped: false, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_durationTween = durationTween;
			num7 = num10;
			flag6 = false;
			num8 = unchecked((nint)null);
		}
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num11 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag8 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Deceleration", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			tweenConfig2.duration = _setDuration;
			tweenConfig2.ease = Ease.InOutSine;
			TweenCallback onStart2 = delegate
			{
				SpellstreamProjectile spellstreamProjectile = CS_0024_003C_003E8__locals8._003C_003E4__this;
				spellstreamProjectile.Deceleration = 2f;
			};
			tweenConfig2.onStart = onStart2;
			MultiTargetTween speedTween = Tweens.Add(tweenConfig2);
			_speedTween = speedTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float detune = (float)_indexInWeapon * -100f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Song, soundConfig, 150f, 1, flag7 ? 1 : 0);
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_01ab: Expected O, but got F4
		//IL_025d->IL01b1: Incompatible stack heights: 1 vs 0
		//IL_016a->IL01b1: Incompatible stack heights: 1 vs 0
		//IL_0199->IL01b1: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			float num = ret * 0.25f;
			if (!(num > 300f))
			{
			}
			Circle emitZone = _emitZone;
			if (_emitZone != null)
			{
				emitZone._radius = ret;
				float diameter = ret + ret;
				emitZone._diameter = diameter;
				RenderingExtensions.SetEmitZone(emitZone: new EmitZone
				{
					_type = EmitZoneType.Random,
					_source = _emitZone
				}, pfx: _emitter1);
				RenderingExtensions.SetEmitZone(emitZone: new EmitZone
				{
					_type = EmitZoneType.Random,
					_source = _emitZone
				}, pfx: _emitter2);
				float2 float5 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm6\"");
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(_emitter1, pos, 0);
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A106E0h]\"");
				RenderingExtensions.EmitParticleAt(_emitter2, pos, 0);
				ArcadeSprite sprite = _sprite;
				float num2 = Deceleration * (float)_aimVec;
				float num3 = Deceleration;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstreamProjectile)+104]");
				float num4 = num3 * 0f;
				if ((object)_sprite != null)
				{
					BaseBody baseBody = sprite.body;
					if (sprite.body != null)
					{
						baseBody._velocity = (float2)num2;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_isCullable = true;
		if (_durationTween != null)
		{
			_durationTween.Cancel();
		}
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}
}
