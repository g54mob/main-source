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
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AuraBlast2_Projectile : Projectile
{
	private const float BodySizeX = 32f;

	private const float BodySizeY = 80f;

	private const float ScaleX = 20f;

	private const float HellfireBaseIntervalMS = 1500f;

	private const float VolcanoScale = 2f;

	private const float VolcanoOffsetY = 0.6f;

	private TP_AuraBlast2_Weapon _trueWeapon;

	private int _hellfireIndex;

	private PhaserSprite _volcanoSprite;

	private bool _initPfx;

	private bool _emitPfx;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxEmitter;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _volcanoTween;

	private Timer _hitBoxTimer;

	private Timer _expireTimer;

	private Timer _hellfireTimer;

	protected override void Awake()
	{
		//IL_01f9: Expected O, but got I4
		//IL_022c: Expected I4, but got I8
		//IL_03e0->IL0300: Incompatible stack heights: 1 vs 0
		//IL_0215->IL0300: Incompatible stack heights: 1 vs 0
		//IL_0248->IL0300: Incompatible stack heights: 1 vs 0
		//IL_0272->IL0300: Incompatible stack heights: 1 vs 0
		//IL_02b8->IL0300: Incompatible stack heights: 1 vs 0
		//IL_02da->IL0300: Incompatible stack heights: 1 vs 0
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
					if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A180E]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Volcano");
						if ((object)phaserSprite != null)
						{
							Transform transform = phaserSprite.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rcx_v38 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
								if ((object)phaserSprite2 != null)
								{
									PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
									if ((object)phaserSprite3 != null)
									{
										PhaserSprite phaserSprite4 = phaserSprite3.setDepth(-2);
										if ((object)phaserSprite4 != null)
										{
											GameObject gameObject2 = phaserSprite4.gameObject;
											if ((object)gameObject2 != null)
											{
												((UnityEngine.Object)gameObject2).SetName("_volcanoSprite");
												_volcanoSprite = phaserSprite4;
												PhaserSprite volcanoSprite = _volcanoSprite;
												if ((object)_volcanoSprite != null && (object)volcanoSprite._spriteRenderer != null)
												{
													Transform transform2 = volcanoSprite._spriteRenderer.transform;
													bool flag2 = (object)transform2 == null;
													bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
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
		//IL_0257: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0230;
		}
		nint num = (nint)typeof(TP_AuraBlast2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AuraBlast2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AuraBlast2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v37+FFFFFFF8+v68 @ rax_v32*8]");
			if (0 == (nint)typeof(TP_AuraBlast2_Weapon))
			{
				obj3 = 1;
				goto IL_023f;
			}
		}
		obj3 = 0;
		goto IL_023f;
		IL_023f:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0230;
		IL_0230:
		_trueWeapon = (TP_AuraBlast2_Weapon)trueWeapon;
		_hellfireIndex = 0;
		InitVolcano();
		GenerateParticleSystems();
		_emitPfx = true;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body.setOffset(-15.5f, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		ScaleIn();
		StartTimers();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.3f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig, 200f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 0.2f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig2, 200f, 10, time);
	}

	private void ScaleIn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.scaleX = (float?)(object)1;
		TweenCallback onComplete = FireHellfireProjectile;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void StartTimers()
	{
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitBoxTimer = Timers.Register(num, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitBoxTimer = hitBoxTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num2 = _weapon.PDuration();
		Action onComplete2 = FadeOut;
		float duration = num * 0.001f;
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private void PlaySfx()
	{
		//IL_0095: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.3f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig, 200f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 0.2f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig2, 200f, 10, time);
	}

	private void InitVolcano()
	{
		//IL_0124: Expected I, but got O
		//IL_01aa: Expected O, but got I4
		//IL_026e->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_004e->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_007d->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_00f8->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_0169->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_0147->IL0147: Incompatible stack heights: 2 vs 1
		if ((object)_volcanoSprite != null)
		{
			Transform transform = _volcanoSprite.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			float2 float5 = base.position;
			if ((object)_volcanoSprite != null)
			{
				float2 float6 = default(float2);
				PhaserSprite phaserSprite = _volcanoSprite.setPosition(float6);
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: true);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
						if (_volcanoTween != null)
						{
							_volcanoTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							if ((object)_volcanoSprite != null)
							{
								nint num = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								bool flag2 = obj == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.delay = 250f;
								tweenConfig.duration = 250f;
								tweenConfig.alpha = (float?)(object)1;
								TweenCallback onComplete = DoVolcanoShake;
								tweenConfig.onComplete = onComplete;
								MultiTargetTween volcanoTween = Tweens.Add(tweenConfig);
								_volcanoTween = volcanoTween;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void DoVolcanoShake()
	{
		//IL_00d8: Expected I, but got O
		//IL_014c: Expected O, but got I
		//IL_032c: Expected O, but got F4
		//IL_0349: Expected O, but got I8
		//IL_02c9: Expected O, but got I4
		//IL_02d9: Expected O, but got I
		//IL_01a9: Expected O, but got I8
		//IL_01b7: Expected O, but got I4
		//IL_030a: Expected O, but got F4
		//IL_0374: Expected O, but got I4
		//IL_01f1: Expected O, but got I8
		//IL_0082->IL0218: Incompatible stack heights: 1 vs 0
		//IL_00ae->IL0218: Incompatible stack heights: 1 vs 0
		//IL_011d->IL0218: Incompatible stack heights: 1 vs 0
		//IL_00fb->IL00fb: Incompatible stack heights: 2 vs 1
		//IL_01ae->IL028d: Incompatible stack heights: 2 vs 1
		//IL_01f6->IL0357: Incompatible stack heights: 2 vs 1
		if ((object)_volcanoSprite != null)
		{
			Transform transform = _volcanoSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (_volcanoTween != null)
				{
					_volcanoTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if ((object)_volcanoSprite != null)
				{
					Transform transform2 = _volcanoSprite.transform;
					if (array != null)
					{
						if ((object)transform2 != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag2 = obj == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							Transform transform3 = (Transform)(object)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag3 = obj2 == null;
								transform3 = (Transform)6573110936L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v686 @ rax_v39 (should have been resolved before IL gen)");
							do
							{
								object obj3 = UnityEngine.Random.value;
								bool flag4 = 0.5f > 0.01f;
								Transform transform4 = (Transform)4294967295L;
								if (!flag4)
								{
									transform4 = (Transform)1;
								}
								float num2 = (float)transform4 * 0.01f;
								float num3 = num2 + (float)ret;
								tweenConfig.localX = (float?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									bool flag5 = obj4 == null;
									transform3 = (Transform)6573110936L;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v776 @ rax_v48 (should have been resolved before IL gen)");
								object obj5 = UnityEngine.Random.value;
							}
							while (!(0.5f > 0.01f));
							tweenConfig.localY = (float?)(object)1;
							tweenConfig.duration = 50f;
							tweenConfig.yoyo = true;
							TweenCallback onComplete = DoVolcanoShake;
							tweenConfig.onComplete = onComplete;
							MultiTargetTween volcanoTween = Tweens.Add(tweenConfig);
							_volcanoTween = volcanoTween;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FireHellfireProjectile()
	{
		//IL_0077: Invalid comparison between O and F4
		//IL_0085: Expected F4, but got O
		if (_emitPfx)
		{
			float2 float5 = base.position;
			TP_AuraBlast2_Weapon trueWeapon = _trueWeapon;
			float2 float6 = default(float2);
			Projectile projectile = trueWeapon._hellfireProjectilePool.SpawnAt(float6, _weapon, _hellfireIndex);
			int hellfireIndex = _hellfireIndex + 1;
			_hellfireIndex = hellfireIndex;
			float num = _weapon.PAmount();
			bool flag = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			float num2 = (float)float6;
			if (!flag)
			{
				num2 = 1f;
			}
			float num3 = 1500f / num2;
			if (_hellfireTimer != null)
			{
				_hellfireTimer.Cancel();
			}
			Action onComplete = FireHellfireProjectile;
			float duration = num3 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hellfireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hellfireTimer = hellfireTimer;
		}
	}

	public override void InternalUpdate()
	{
		UpdateParticles();
	}

	private void UpdateParticles()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0035: Expected O, but got I4
		//IL_0062: Expected I4, but got I8
		//IL_0089: Expected I4, but got I8
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_012e->IL014f: Incompatible stack heights: 1 vs 0
		//IL_014a->IL014f: Incompatible stack heights: 1 vs 0
		//IL_00b4->IL014f: Incompatible stack heights: 1 vs 0
		if (!_emitPfx)
		{
			return;
		}
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v2 (System.Object)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out Vector3 _);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,dword ptr [rsp+20h]\"");
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			return;
		}
		object obj2 = obj - 1;
		object obj3 = 0;
		Vector2 pos = default(Vector2);
		while (obj3 != obj2)
		{
			float2 float5 = base.position;
			RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, -1);
			float2 float6 = base.position;
			RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, -1);
			obj3++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				break;
			}
		}
	}

	private void FadeOut()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		//IL_015a: Expected I, but got O
		BaseBody baseBody = body;
		_emitPfx = false;
		baseBody._enable = false;
		if (_volcanoTween != null)
		{
			_volcanoTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_volcanoSprite != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween volcanoTween = Tweens.Add(tweenConfig);
		_volcanoTween = volcanoTween;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_AuraBlast2_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _volcanoSprite.setVisible(visible: false);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_volcanoTween != null)
		{
			_volcanoTween.Kill();
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hellfireTimer != null)
		{
			_hellfireTimer.Cancel();
		}
		base.Despawn();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007a: Expected O, but got I
		//IL_060a: Expected O, but got Ref
		//IL_0624: Expected native int or pointer, but got O
		//IL_063e: Expected O, but got I
		//IL_065e: Expected O, but got Ref
		//IL_0678: Expected native int or pointer, but got O
		//IL_0692: Expected O, but got I
		//IL_06b2: Expected O, but got Ref
		//IL_06cc: Expected native int or pointer, but got O
		//IL_06e6: Expected O, but got I
		//IL_0706: Expected O, but got Ref
		//IL_0720: Expected native int or pointer, but got O
		//IL_08c5: Expected O, but got I4
		//IL_0738: Expected O, but got Ref
		//IL_075f: Expected O, but got I
		//IL_0779: Expected native int or pointer, but got O
		//IL_08e2: Expected O, but got I4
		//IL_079e: Expected O, but got Ref
		//IL_07c5: Expected O, but got I
		//IL_07df: Expected native int or pointer, but got O
		//IL_0914: Expected O, but got I
		//IL_0872: Expected I4, but got I8
		//IL_0968->IL0968: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_initPfx)
		{
			_initPfx = true;
			GameObject gameObject = base.gameObject;
			_ = 0;
			ParticleEmitterManager pfxManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
				pfxManager = (ParticleEmitterManager)0;
			}
			else
			{
				pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_pfxManager = pfxManager;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 1f;
			emitZone._source = circle;
			emitZone._type = EmitZoneType.Random;
			emitZone._yoyo = false;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire21");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire22");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire23");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire24");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire25");
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
				((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire26");
			}
			else
			{
				int num8 = list._size + 1;
				list._size = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(250f, 1000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
			_ = 0;
			_ = 1065353216;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _pfxManager.CreateEmitter(particleSystemConfig, _cachedTransform, "PfxEmitter");
			_pfxEmitter = pfxEmitter;
			RenderingExtensions.SetMaxParticles(_pfxEmitter, 2000);
			RenderingExtensions.SetDepth(_pfxEmitter, -1);
			Transform transform = _pfxEmitter.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_01fb->IL0162: Incompatible stack heights: 1 vs 0
		//IL_0161->IL0161: Incompatible stack heights: 1 vs 0
		if (other != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Transform component = gameObject.GetComponent<Transform>();
				if ((object)component == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v12 (UnityEngine.Transform)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				if ((object)_weapon != null)
				{
					if (!_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
					{
						return;
					}
					Weapon weapon = _weapon;
					if ((object)_weapon != null)
					{
						GameManager gameMan = weapon._gameMan;
						if ((object)weapon._gameMan != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v12 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v12 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							if (gameMan._arcanaManager != null)
							{
								Vector2 pos = default(Vector2);
								gameMan._arcanaManager.TriggerFireExplosion(pos);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CStartTimers_003Eb__21_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
