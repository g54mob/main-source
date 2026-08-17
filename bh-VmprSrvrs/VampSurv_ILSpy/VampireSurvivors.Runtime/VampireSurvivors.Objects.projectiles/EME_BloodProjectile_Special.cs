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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_BloodProjectile_Special : Projectile
{
	private List<Color> _tints;

	protected List<BlendMode> _blendModes;

	protected MultiTargetTween _alphaTween;

	protected MultiTargetTween _scaleTween;

	protected ParticleSystem _damageVfx;

	protected ParticleEmitterManager _particlesManager;

	protected GravityWell _well;

	protected Timer bloodTimer;

	protected Timer expireTimer;

	protected PhaserSprite _displaySprite;

	protected EnemyController _myTarget;

	protected bool _targetFound;

	protected bool isFirstUpdate;

	protected virtual string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A47D7]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "eme_fx_sanguine";
		}
	}

	protected virtual float ExpireTime => 1000f;

	protected override void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A47D8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Awake();
		PhaserWorld instance = PhaserWorld.Instance;
		string frameName = FrameName;
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite displaySprite = instance.AddPhaserSprite(pos, "Emeralds_VFX", frameName);
			_displaySprite = displaySprite;
			if ((object)_displaySprite != null)
			{
				PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
				Transform parent = base.transform;
				if ((object)_displaySprite != null)
				{
					Transform transform = _displaySprite.transform;
					if ((object)transform != null)
					{
						transform.SetParent(parent, worldPositionStays: true);
						if ((object)_displaySprite != null)
						{
							Transform transform2 = _displaySprite.transform;
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
							ArcadeSprite arcadeSprite = setVisible(visible: false);
							MakeEmitter();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		_damageVfx.Clear(withChildren: true);
		if (bloodTimer != null)
		{
			bloodTimer.Cancel();
		}
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		isFirstUpdate = true;
		_isCullable = false;
	}

	protected unsafe virtual void MakeEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00eb: Expected O, but got I
		//IL_0107: Expected O, but got I4
		//IL_0120: Expected O, but got Ref
		//IL_013a: Expected native int or pointer, but got O
		//IL_0447: Expected O, but got I4
		//IL_015f: Expected O, but got Ref
		//IL_0179: Expected native int or pointer, but got O
		//IL_0193: Expected O, but got I
		//IL_01b3: Expected O, but got Ref
		//IL_01cd: Expected native int or pointer, but got O
		//IL_0481: Expected O, but got I
		//IL_0205: Expected O, but got Ref
		//IL_021f: Expected native int or pointer, but got O
		//IL_04bb: Expected O, but got I
		//IL_0265: Expected O, but got I4
		//IL_0297: Expected O, but got I
		//IL_033f: Expected O, but got I
		//IL_0549: Expected I, but got O
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
			((List<object>)(object)list).AddWithResize((object)"WhiteDot");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		_ = 0;
		_ = 10;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(300f, 350f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(200f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 16711680;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = false;
		GameObject gameObject = base.gameObject;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystem damageVfx = _particlesManager.CreateEmitter(particleSystemConfig, null, "EMEBloodEmitter");
		_damageVfx = damageVfx;
		Transform transform = _damageVfx.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		GravityWellConfig config = new GravityWellConfig
		{
			_power = 1f,
			_epsilon = 60f,
			_gravity = 20f
		};
		GravityWell well = _particlesManager.CreateGravityWell(config);
		_well = well;
		Transform transform2 = _well.transform;
		bool flag2 = (object)((ParticleSystemConfig)(object)transform2)._x == null;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, ref value2);
	}

	private void LateUpdate()
	{
		if (isFirstUpdate)
		{
			isFirstUpdate = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x1871CA410\"");
		}
	}

	public void Activate()
	{
		//IL_0023: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_0153: Expected O, but got I
		//IL_0273: Expected I, but got O
		//IL_02f9: Expected O, but got I4
		//IL_04b1: Expected O, but got I4
		//IL_0503: Expected F4, but got I4
		//IL_0266->IL050d: Incompatible stack heights: 1 vs 0
		//IL_02b8->IL050d: Incompatible stack heights: 2 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = true;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			ArcadeSprite sprite = _sprite;
			if ((object)_sprite != null)
			{
				BaseBody baseBody2 = sprite.body;
				if (sprite.body != null)
				{
					List<Color> list = (List<Color>)(object)baseBody2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v100 @ rdx_v9 (System.Collections.Generic.List`1<UnityEngine.Color>)+218] (should have been resolved before IL gen)");
					ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
					PhaserSprite displaySprite = _displaySprite;
					if ((object)_displaySprite != null)
					{
						List<Color> tints = _tints;
						object spriteRenderer = displaySprite._spriteRenderer;
						if (_tints != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
							object obj;
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BD30");
								object obj2 = default(object);
								obj = obj2;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
								obj = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v7 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v7 (System.Object)+10]");
							Color value = default(Color);
							SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
							PhaserSprite phaserSprite = _displaySprite.setAlpha(0.9f);
							BlendMode blendMode = Extensions.PickRnd(_blendModes);
							PhaserSprite phaserSprite2 = _displaySprite.setBlendMode(blendMode);
							Weapon weapon = _weapon;
							float num = weapon.PArea();
							float2 float5 = base.position;
							float num2 = (float)obj * 0.16f;
							float num3 = 3.2463913E+09f + num2;
							float2 float6 = default(float2);
							base.position = float6;
							_isCullable = false;
							if (_scaleTween != null)
							{
								_scaleTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if (array != null)
							{
								nint num4 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj3 = default(object);
								bool flag2 = obj3 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									tweenConfig.duration = 100f;
									tweenConfig.ease = Ease.InOutSine;
									tweenConfig.scale = (float?)(object)1;
									TweenCallback onComplete = FadeOut;
									tweenConfig.onComplete = onComplete;
									MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
									_scaleTween = scaleTween;
									RenderingExtensions.Start(_damageVfx);
									if (bloodTimer != null)
									{
										bloodTimer.Cancel();
									}
									Action onComplete2 = delegate
									{
										_damageVfx.Stop();
									};
									bool flag3 = default(bool);
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer timer = Timers.Register(0.25f, onComplete2, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									bloodTimer = timer;
									if (expireTimer != null)
									{
										expireTimer.Cancel();
									}
									float expireTime = ExpireTime;
									Action onComplete3 = delegate
									{
										Despawn();
									};
									float duration = 0.25f * 0.001f;
									Timer timer2 = Timers.Register(duration, onComplete3, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									expireTimer = timer2;
									if (_indexInWeapon < 10)
									{
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Volume = (float?)(object)1,
											Rate = 2f
										};
										float detune = (float)_indexInWeapon * 4.294967E+09f;
										soundConfig.Detune = detune;
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Banish, soundConfig, 100f, 2, flag3 ? 1 : 0);
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_damageVfx.Clear(withChildren: true);
		if (bloodTimer != null)
		{
			bloodTimer.Cancel();
		}
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	private void FadeOut()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
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
		tweenConfig.duration = 50f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public EME_BloodProjectile_Special()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0213: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_023b: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_01c0: Expected O, but got I
		List<BlendMode> list = new List<BlendMode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 0;
		}
		_blendModes = list;
		base._002Ector();
	}

	private void _003CActivate_003Eb__21_0()
	{
		_damageVfx.Stop();
	}

	private void _003CActivate_003Eb__21_1()
	{
		Despawn();
	}

	private void _003CFadeOut_003Eb__23_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
