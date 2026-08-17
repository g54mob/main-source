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
using VampireSurvivors.Data.Weapons;
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

public class EME_BloodProjectile_Special_ScarletHarbinger : Projectile
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

	private Tween _wellTween;

	private SpriteRenderer _rockSprite;

	private SpriteRenderer _starSprite;

	private SpriteRenderer _starSprite2;

	private SpriteRenderer _bubbleSprite;

	private SpriteAnimation _animation;

	private bool _initialisedParticles;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	private MultiTargetTween _tween5;

	private MultiTargetTween _tween6;

	protected string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A47E3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "eme_fx_sanguine3";
		}
	}

	protected float ExpireTime => 3000f;

	protected override void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A47E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Awake();
		PhaserWorld instance = PhaserWorld.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A47E3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite displaySprite = instance.AddPhaserSprite(pos, "Emeralds_VFX", "eme_fx_sanguine3");
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
		//IL_0086: Expected O, but got I
		//IL_0086: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_026c: Expected O, but got I
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F608]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-8]");
			Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
			_starSprite.sprite = sprite;
			SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
			if (spriteTexturesBase2.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F608]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-10]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-8]");
				Sprite sprite2 = SpriteManager.GetSprite((string)num2, (string)0);
				_starSprite2.sprite = sprite2;
				SpriteTextures.SpriteTexturesBase spriteTexturesBase3 = SpriteTextures.Base;
				if (spriteTexturesBase3.Vfx != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5D5]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-10]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-8]");
					Sprite sprite3 = SpriteManager.GetSprite((string)num3, (string)0);
					_bubbleSprite.sprite = sprite3;
					SpriteTextures.SpriteTexturesBase spriteTexturesBase4 = SpriteTextures.Base;
					if (spriteTexturesBase4.Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA8C]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-10]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-8]");
						Sprite sprite4 = SpriteManager.GetSprite((string)num4, (string)0);
						_rockSprite.sprite = sprite4;
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
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe void MakeEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00eb: Expected O, but got I
		//IL_0107: Expected O, but got I4
		//IL_0120: Expected O, but got Ref
		//IL_013a: Expected native int or pointer, but got O
		//IL_0593: Expected O, but got I4
		//IL_015f: Expected O, but got Ref
		//IL_0179: Expected native int or pointer, but got O
		//IL_0193: Expected O, but got I
		//IL_01b3: Expected O, but got Ref
		//IL_01cd: Expected native int or pointer, but got O
		//IL_05cd: Expected O, but got I
		//IL_0205: Expected O, but got Ref
		//IL_021f: Expected native int or pointer, but got O
		//IL_0607: Expected O, but got I
		//IL_0265: Expected O, but got I4
		//IL_0297: Expected O, but got I
		//IL_02ba: Expected O, but got I4
		//IL_0641: Expected O, but got I
		//IL_0367: Expected O, but got I
		//IL_06cf: Expected I, but got O
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(3000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(175f, 225f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(4f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+80]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 6684672;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
		particleSystemConfig._tint = (uint?)(object)0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.1f);
		_ = 0;
		_ = 0;
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		_ = 0;
		particleSystemConfig._on = false;
		GameObject gameObject = base.gameObject;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystem damageVfx = _particlesManager.CreateEmitter(particleSystemConfig, null, "EMEBloodEmitter3");
		_damageVfx = damageVfx;
		Transform transform = _damageVfx.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		GravityWellConfig config = new GravityWellConfig
		{
			_power = 1f,
			_epsilon = 50f,
			_gravity = 20f
		};
		GravityWell well = _particlesManager.CreateGravityWell(config);
		_well = well;
		Transform transform2 = _well.transform;
		bool flag2 = (object)((ParticleSystemConfig)(object)transform2)._x == null;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, ref value2);
		if (_wellTween != null)
		{
			TweenExtensions.Kill(_wellTween);
		}
		bool flag3 = (object)_well == null;
		Transform target = _well.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, 1f, 1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1933 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1933 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1933 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag4 = tweenerCore == null;
		_wellTween = tweenerCore;
	}

	private void LateUpdate()
	{
		if (isFirstUpdate)
		{
			isFirstUpdate = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x1871CE5B0\"");
		}
	}

	public void Activate()
	{
		//IL_0023: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00e8: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0276: Expected I, but got O
		//IL_02fc: Expected O, but got I4
		//IL_0566: Expected O, but got I4
		//IL_05b8: Expected F4, but got I4
		//IL_05d8: Expected O, but got I4
		//IL_0625: Expected F4, but got I4
		//IL_0269->IL062f: Incompatible stack heights: 1 vs 0
		//IL_02bb->IL062f: Incompatible stack heights: 2 vs 0
		//IL_0493->IL062f: Incompatible stack heights: 2 vs 0
		//IL_04d6->IL062f: Incompatible stack heights: 2 vs 0
		//IL_0505->IL062f: Incompatible stack heights: 2 vs 0
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
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v125 @ rdx_v9 (System.Collections.Generic.List`1<UnityEngine.Color>)+218] (should have been resolved before IL gen)");
					ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
					Renderer displaySprite = (Renderer)(object)_displaySprite;
					if ((object)_displaySprite != null)
					{
						List<Color> tints = _tints;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v6 (UnityEngine.Renderer)+28]");
						Renderer renderer = (Renderer)0;
						if (_tints != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
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
							bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
							Color value = default(Color);
							SpriteRenderer.set_color_Injected(((UnityEngine.Object)renderer).m_CachedPtr, ref value);
							PhaserSprite phaserSprite = _displaySprite.setAlpha(0.9f);
							BlendMode blendMode = VampireSurvivors.App.Tools.Extensions.PickRnd(_blendModes);
							PhaserSprite phaserSprite2 = _displaySprite.setBlendMode(blendMode);
							Weapon weapon = _weapon;
							float num = weapon.PArea();
							float2 float5 = base.position;
							float num2 = (float)obj * 0.16f;
							float num3 = 3.2631685E+09f + num2;
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
									Action onComplete3 = delegate
									{
										Despawn();
									};
									Timer timer2 = Timers.Register(3.0000002f, onComplete3, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									expireTimer = timer2;
									Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
									if ((object)_starSprite != null)
									{
										((Renderer)_starSprite).SetMaterial(material);
										Weapon weapon2 = _weapon;
										_isCullable = false;
										if ((object)_weapon != null)
										{
											WeaponData currentWeaponData = weapon2._currentWeaponData;
											if (weapon2._currentWeaponData != null)
											{
												OnRecycle(currentWeaponData._003CrepeatInterval_003Ek__BackingField);
												DisplayMe(currentWeaponData._003CrepeatInterval_003Ek__BackingField);
												if (_indexInWeapon < 10)
												{
													SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
													{
														Volume = (float?)(object)1,
														Rate = 2f
													};
													float detune = (float)_indexInWeapon * 4.294967E+09f;
													soundConfig.Detune = detune;
													PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 100f, 2, flag3 ? 1 : 0);
													SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
													{
														Volume = (float?)(object)1,
														Rate = 1f
													};
													float detune2 = (float)_indexInWeapon * 4.294967E+09f;
													soundConfig2.Detune = detune2;
													PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_death_4, soundConfig2, 100f, 2, flag3 ? 1 : 0);
												}
												return;
											}
										}
									}
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

	private void OnRecycle(float salvoDuration)
	{
		//IL_00fc: Expected I, but got O
		//IL_016e: Expected O, but got I4
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_starSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite2, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_bubbleSprite, 0f);
		ArcadeSprite sprite = _sprite;
		_sprite.CheckRenderer();
		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(sprite._spriteRenderer, 0f);
		if (_tween != null)
		{
			_tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 150f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00b6: Expected I, but got O
			//IL_010e: Expected I, but got O
			//IL_0166: Expected I, but got O
			//IL_01be: Expected I, but got O
			//IL_0230: Expected O, but got I4
			if (_tween5 != null)
			{
				_tween5.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[5];
			if ((object)_starSprite != null)
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
			if ((object)_starSprite2 != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_bubbleSprite != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_sprite != null)
			{
				nint num5 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_rockSprite != null)
			{
				nint num6 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
					throw ex6;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 300f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				if (_tween2 != null)
				{
					_tween2.Kill();
				}
				if (_tween3 != null)
				{
					_tween3.Kill();
				}
				if (_tween4 != null)
				{
					_tween4.Kill();
				}
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete2 = delegate
			{
				if (_tween6 != null)
				{
					_tween6.Kill();
				}
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
			_tween5 = tween2;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
	}

	private void DisplayMe(float salvoDuration)
	{
		//IL_00b8: Expected I, but got O
		//IL_0122: Expected I, but got O
		//IL_018c: Expected I, but got O
		//IL_01f6: Expected I, but got O
		//IL_0268: Expected O, but got I4
		//IL_0351: Expected I, but got O
		//IL_03d5: Expected I4, but got I8
		//IL_03e3: Expected O, but got I4
		//IL_04a4: Expected I, but got O
		//IL_0523: Expected O, but got I4
		//IL_05e4: Expected I, but got O
		//IL_0656: Expected O, but got I4
		_animation.SetAnimation("break");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_rockSprite, 1f);
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		Transform transform = _starSprite.transform;
		if ((object)transform != null)
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
		Transform transform2 = _starSprite2.transform;
		if ((object)transform2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Transform transform3 = _bubbleSprite.transform;
		if ((object)transform3 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Transform transform4 = _rockSprite.transform;
		if ((object)transform4 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 150f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_starSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_bubbleSprite, 0f);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(_rockSprite, 0f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_0083: Expected I4, but got I8
			//IL_00a7->IL0038: Incompatible stack heights: 1 vs 0
			SpriteRenderer starSprite = _starSprite;
			if ((object)_starSprite != null)
			{
				bool flag = ((UnityEngine.Object)starSprite).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)starSprite).m_CachedPtr, -1999);
				SpriteRenderer bubbleSprite = _bubbleSprite;
				if ((object)_bubbleSprite != null)
				{
					bool flag2 = ((UnityEngine.Object)bubbleSprite).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 75 ConditionalJump @-1, v117 @ ZF_v10 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 145 ConditionalJump @-1, v274 @ ZF_v15 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_starSprite != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 120f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = -1;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite, 0.55f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween3 = tween2;
		if (_tween6 != null)
		{
			_tween6.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_starSprite2 != null)
		{
			nint num6 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.duration = salvoDuration;
		tweenConfig3.ease = Ease.Linear;
		tweenConfig3.yoyo = true;
		tweenConfig3.alpha = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite2, 0f);
		};
		tweenConfig3.onStart = onStart3;
		MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
		_tween6 = tween3;
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)_bubbleSprite != null)
		{
			nint num7 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.duration = 300f;
		tweenConfig4.ease = Ease.Linear;
		tweenConfig4.alpha = (float?)(object)1;
		TweenCallback onStart4 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_bubbleSprite, 1f);
		};
		tweenConfig4.onStart = onStart4;
		MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
		_tween4 = tween4;
	}

	public EME_BloodProjectile_Special_ScarletHarbinger()
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

	private void _003CActivate_003Eb__22_0()
	{
		_damageVfx.Stop();
	}

	private void _003CActivate_003Eb__22_1()
	{
		Despawn();
	}

	private void _003CFadeOut_003Eb__24_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003COnRecycle_003Eb__37_0()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003COnRecycle_003Eb__37_1()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_01be: Expected I, but got O
		//IL_0230: Expected O, but got I4
		if (_tween5 != null)
		{
			_tween5.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[5];
		if ((object)_starSprite != null)
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
		if ((object)_starSprite2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_bubbleSprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sprite != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_rockSprite != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			if (_tween2 != null)
			{
				_tween2.Kill();
			}
			if (_tween3 != null)
			{
				_tween3.Kill();
			}
			if (_tween4 != null)
			{
				_tween4.Kill();
			}
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			if (_tween6 != null)
			{
				_tween6.Kill();
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween5 = tween;
	}

	private void _003COnRecycle_003Eb__37_2()
	{
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
	}

	private void _003COnRecycle_003Eb__37_3()
	{
		if (_tween6 != null)
		{
			_tween6.Kill();
		}
	}

	private void _003CDisplayMe_003Eb__38_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_starSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_bubbleSprite, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_rockSprite, 0f);
	}

	private void _003CDisplayMe_003Eb__38_1()
	{
		//IL_0083: Expected I4, but got I8
		//IL_00a7->IL0038: Incompatible stack heights: 1 vs 0
		SpriteRenderer starSprite = _starSprite;
		if ((object)_starSprite != null)
		{
			bool flag = ((UnityEngine.Object)starSprite).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)starSprite).m_CachedPtr, -1999);
			SpriteRenderer bubbleSprite = _bubbleSprite;
			if ((object)_bubbleSprite != null)
			{
				bool flag2 = ((UnityEngine.Object)bubbleSprite).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 75 ConditionalJump @-1, v117 @ ZF_v10 (System.Boolean) --- -1 Nop");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 145 ConditionalJump @-1, v274 @ ZF_v15 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CDisplayMe_003Eb__38_2()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_starSprite, 0.55f);
	}

	private void _003CDisplayMe_003Eb__38_3()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_starSprite2, 0f);
	}

	private void _003CDisplayMe_003Eb__38_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_bubbleSprite, 1f);
	}
}
