using System;
using System.Collections.Generic;
using System.Linq;
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
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Fibonacci1_Projectile : Projectile
{
	private const float Radius = 16f;

	private const float FibOffsetModifier = 0.01f;

	private const float SeltzerSpriteScale = 0.4f;

	private LEM_Fibonacci1_Weapon _trueWeapon;

	private PhaserSprite _seltzerSprite;

	private Transform _seltzerNozzle;

	private int _fibIndex;

	private List<int> _fibSequence;

	private List<float2> _fibOffsets;

	private float2 _landedPos;

	private float2 _offset;

	private float _angle;

	private float _angleForNextOffset;

	private bool _isSpiralling;

	private bool _isDespawning;

	private float _cachedArea;

	private Tween _moveTween;

	private Tween _rotateTween;

	private Tween _scaleTween;

	private Timer _hitBoxTimer;

	private Timer _despawnTimer;

	private Timer _sfxTimer;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private float SpeedModifier
	{
		get
		{
			float num = _weapon.PSpeed();
			object obj = default(object);
			return (float)obj * 250f;
		}
	}

	protected unsafe override void Awake()
	{
		//IL_0086: Expected O, but got I
		//IL_0086: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_01a4: Expected O, but got I4
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0499: Expected I, but got O
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Expected O, but got Unknown
		base.Awake();
		GenerateParticleSystem();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
			Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
					if (SpriteTextures.Lemon != null && lemon.LEM_Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E74]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						_ = 0;
						GameObject gameObject = base.gameObject;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, (string)num2, (string)0);
						if ((object)phaserSprite != null)
						{
							PhaserSprite phaserSprite2 = phaserSprite.setScale(0.4f, (float?)(object)0);
							if ((object)phaserSprite2 != null)
							{
								Transform transform = phaserSprite2.transform;
								if ((object)transform != null)
								{
									_ = -90f;
									object obj = default(object);
									Vector3 localEulerAngles = (Vector3)(obj - 64);
									transform.localEulerAngles = localEulerAngles;
									GameObject gameObject2 = phaserSprite2.gameObject;
									if ((object)gameObject2 != null)
									{
										((UnityEngine.Object)gameObject2).SetName("SeltzerSprite");
										_seltzerSprite = phaserSprite2;
										GameObject gameObject3 = new GameObject();
										GameObject.Internal_CreateGameObject(gameObject3, (string)null);
										if ((object)gameObject3 != null)
										{
											Transform seltzerNozzle = gameObject3.transform;
											_seltzerNozzle = seltzerNozzle;
											if ((object)_seltzerNozzle != null)
											{
												((UnityEngine.Object)_seltzerNozzle).SetName("Nozzle");
												PhaserSprite seltzerSprite = _seltzerSprite;
												if ((object)_seltzerSprite != null && (object)seltzerSprite._spriteRenderer != null)
												{
													Transform parent = seltzerSprite._spriteRenderer.transform;
													if ((object)_seltzerNozzle != null)
													{
														_seltzerNozzle.SetParent(parent, worldPositionStays: true);
														if ((object)_seltzerNozzle != null)
														{
															Transform transform2 = _seltzerNozzle.transform;
															nint num3 = (nint)typeof(Vector3);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ rcx_v55 (Il2CppClass<UnityEngine.Vector3>)+B8]");
															nint num4 = 0;
															_ = Vector3.oneVector;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rax_v63 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v61 (UnityEngine.Transform)+10]");
															bool flag = (nint)0 == 0;
															object obj2 = obj - 64;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v61 (UnityEngine.Transform)+10]");
															Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj2);
															Transform transform3 = _seltzerNozzle.transform;
															_ = 0;
															bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
															object obj3 = obj - 48;
															Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj3);
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
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I4, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_01c9: Expected O, but got I
		//IL_026e: Expected O, but got I
		//IL_0285: Expected O, but got I
		//IL_02b8: Expected F4, but got I
		//IL_0323: Expected O, but got I4
		//IL_0323: Expected O, but got I4
		//IL_041b: Expected O, but got Ref
		//IL_0530: Expected O, but got I4
		int index2 = default(int);
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index2);
		Weapon weapon2 = _weapon;
		LEM_Fibonacci1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0491;
		}
		nint num = (nint)typeof(LEM_Fibonacci1_Weapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Fibonacci1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v2 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Fibonacci1_Weapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v2 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v80+FFFFFFF8+v72 @ rax_v75*8]");
			if (0 == (nint)typeof(LEM_Fibonacci1_Weapon))
			{
				obj3 = 1;
				goto IL_04a0;
			}
		}
		obj3 = 0;
		goto IL_04a0;
		IL_04a0:
		bool flag = obj3 == null;
		pool2 = (BulletPool)(object)typeof(LEM_Fibonacci1_Weapon);
		trueWeapon = null;
		if (!flag)
		{
			pool2 = (BulletPool)(object)typeof(LEM_Fibonacci1_Weapon);
			trueWeapon = (LEM_Fibonacci1_Weapon)_weapon;
		}
		goto IL_0491;
		IL_0491:
		_trueWeapon = trueWeapon;
		LEM_Fibonacci1_Weapon trueWeapon2 = _trueWeapon;
		_isCullable = false;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rsi_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (trueWeapon2._003CFibonacciSequence_003Ek__BackingField != null)
		{
			List<int> fibSequence = new List<int>(trueWeapon2._003CFibonacciSequence_003Ek__BackingField);
			_fibSequence = fibSequence;
			LEM_Fibonacci1_Weapon trueWeapon3 = _trueWeapon;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rsi_v8 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				((List<int>)0)._002Ector((IEnumerable<int>)trueWeapon2._003CFibonacciSequence_003Ek__BackingField);
			}
			if (trueWeapon3._003CFibonacciOffsets_003Ek__BackingField != null)
			{
				List<float2> fibOffsets = new List<float2>(trueWeapon3._003CFibonacciOffsets_003Ek__BackingField);
				_fibOffsets = fibOffsets;
				List<float2> fibOffsets2 = _fibOffsets;
				_fibIndex = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v35 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v35 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v36+20]");
					_offset = (float2)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v36+24]");
					_ = 0;
					float startingAngle = _trueWeapon.StartingAngle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v36+20]");
					_angle = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v36+20]");
					float num5 = (_angleForNextOffset = 0f + 90f);
					float num6 = _weapon.PArea();
					_cachedArea = num5;
					_isSpiralling = false;
					BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
					BaseBody baseBody2 = body;
					baseBody2._enable = true;
					float num7 = _weapon.PArea();
					bool flag2 = !(1f < num5);
					float alpha = 1f;
					if (!flag2)
					{
						if (num5 < 3f)
						{
							float num8 = num5 - 1f;
							float num9 = num8 * 0.3f;
							float num10 = num9 * 0.5f;
							alpha = 1f - num10;
						}
						else
						{
							alpha = 0.7f;
						}
					}
					PhaserSprite phaserSprite = _seltzerSprite.setAlpha(alpha);
					object obj5 = default(object);
					ApplyPlayerFacingVelocity((Vector3)(&obj5), rotate: false);
					TweenIn();
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					float detune = (float)_indexInWeapon * 100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_throw, soundConfig, 200f, 10, time);
					return;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private unsafe void TweenIn()
	{
		//IL_04b6: Expected I, but got O
		//IL_04f6: Expected O, but got I
		//IL_0526: Invalid comparison between F4 and O
		//IL_0072: Expected I, but got O
		//IL_0608: Expected O, but got I
		//IL_00f4: Expected I, but got O
		//IL_056f: Invalid comparison between I4 and F4
		//IL_0136: Expected I, but got I8
		//IL_0203: Expected O, but got Ref
		//IL_0313: Expected O, but got Ref
		//IL_0360: Expected O, but got Ref
		//IL_03b2: Expected O, but got I4
		//IL_004d->IL0443: Incompatible stack heights: 1 vs 0
		//IL_009b->IL0443: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL0443: Incompatible stack heights: 1 vs 0
		//IL_017d->IL0443: Incompatible stack heights: 1 vs 0
		//IL_013b->IL055a: Incompatible stack heights: 2 vs 1
		//IL_019f->IL0443: Incompatible stack heights: 1 vs 0
		//IL_059b->IL0443: Incompatible stack heights: 1 vs 0
		//IL_02d5->IL0443: Incompatible stack heights: 1 vs 0
		//IL_0301->IL0443: Incompatible stack heights: 1 vs 0
		//IL_05b8->IL0443: Incompatible stack heights: 1 vs 0
		//IL_05e4->IL0443: Incompatible stack heights: 1 vs 0
		Vector3 value = default(Vector3);
		if ((object)_seltzerSprite != null)
		{
			Transform transform = _seltzerSprite.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				nint cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
				nint num = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v11 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num2 = 0;
				object obj = characterController._lastMovementDirection - Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v23 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v664 @ rax_v25 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				object obj2 = num3 - 0;
				object obj3 = obj2 * obj2;
				object obj4 = obj * obj;
				object obj5 = obj3 + obj4;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
				{
					nint num4 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v12 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num5 = 0;
					Vector2 vector2 = default(Vector2);
					Vector2 vector = vector2;
					goto IL_05f8;
				}
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						Vector2 vector = characterController2._lastMovementDirection;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
						nint num4 = (nint)typeof(Vector2);
						object obj6 = default(object);
						cachedPtr = (nint)(&obj6);
						goto IL_05f8;
					}
				}
			}
		}
		goto IL_0443;
		IL_0443:
		throw new NullReferenceException();
		IL_05f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag2 = obj7 == null;
			nint cachedPtr = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v742 @ rax_v28 (should have been resolved before IL gen)");
		if (!(0f > _cachedArea))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm2\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		Weapon weapon3 = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
			if (_moveTween != null)
			{
				TweenExtensions.Kill(_moveTween);
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&value), 0.3f);
			TweenCallback tweenCallback = StartSpinning;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (tweenerCore != null)
			{
				_moveTween = tweenerCore;
				if ((object)_cachedTransform != null)
				{
					Transform transform2 = _cachedTransform.transform;
					if ((object)transform2 != null)
					{
						Vector2 vector3 = default(Vector2);
						transform2.localEulerAngles = (Vector3)(&vector3);
						if (_rotateTween != null)
						{
							TweenExtensions.Kill(_rotateTween);
						}
						Vector2 vector4 = default(Vector2);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(_cachedTransform, (Vector3)(&vector4), 0.3f, RotateMode.FastBeyond360);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore2 != null)
						{
							_rotateTween = tweenerCore2;
							ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
							if (_scaleTween != null)
							{
								TweenExtensions.Kill(_scaleTween);
							}
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_cachedTransform, _cachedArea, 0.3f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore3 != null)
							{
								_scaleTween = tweenerCore3;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0443;
	}

	private void StartSpinning()
	{
		_isSpiralling = true;
		float2 landedPos = base.position;
		_landedPos = landedPos;
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
		float num2 = _weapon.PSpeed();
		if (!(num > 1f))
		{
			num = 1f;
		}
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
		Action onComplete2 = PlaySpinningSfx;
		float num3 = 1000f / num;
		float duration = num3 * 0.001f;
		Timer sfxTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_sfxTimer = sfxTimer;
	}

	private void PlayThrowSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_throw, soundConfig, 200f, 10, time);
	}

	private void PlaySpinningSfx()
	{
		//IL_002d: Invalid comparison between F4 and I4
		//IL_00e6: Expected O, but got I4
		//IL_004d: Expected F4, but got I4
		float num = _weapon.PSpeed();
		object obj = default(object);
		float num2 = (float)obj - 1f;
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		float num3 = num2 * 600f;
		soundConfig.Rate = 1f;
		float num4 = (float)_indexInWeapon * 100f;
		float num5 = num4 + num3;
		float detune = num5 - 300f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_stream, soundConfig, 200f, 10, time);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00a3: Expected O, but got I
		//IL_00f6: Expected O, but got Ref
		if (_isSpiralling && !_isDespawning)
		{
			UpdateAngleAndOffset();
			List<int> fibSequence = _fibSequence;
			float num = _angle * ((float)Math.PI / 180f);
			int fibIndex = _fibIndex;
			int fibIndex2 = _fibIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)fibIndex2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float2 float5 = default(float2);
				base.position = float5;
				Transform transform = _cachedTransform.transform;
				object obj2 = default(object);
				transform.localEulerAngles = (Vector3)(&obj2);
				UpdateVfx();
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private void UpdateAngleAndOffset()
	{
		//IL_0031: Invalid comparison between I4 and F4
		//IL_0170: Expected O, but got I4
		//IL_01be: Expected I, but got O
		//IL_00a8: Expected O, but got I
		//IL_00bd: Expected O, but got I4
		//IL_00d2: Expected F4, but got I
		//IL_00e4: Expected O, but got I
		float num = _angle;
		if (!(_angle < _angleForNextOffset))
		{
			float angleForNextOffset = _angleForNextOffset + 90f;
			_angleForNextOffset = angleForNextOffset;
			if (!((float)_fibIndex < 14f))
			{
				BaseBody baseBody = body;
				_isDespawning = true;
				baseBody._enable = false;
				ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
				if (_despawnTimer != null)
				{
					_despawnTimer.Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Fibonacci1_Projectile>)+370]");
				Action onComplete = new Action(this, (IntPtr)0);
				nint num2 = (nint)this;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer despawnTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_despawnTimer = despawnTimer;
				return;
			}
			List<float2> fibOffsets = _fibOffsets;
			int num3 = ++_fibIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj = 0;
			object obj2 = _fibIndex + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v20+20+v64 @ rax_v26*8]");
			num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v20+20+v64 @ rax_v26*8]");
			_offset = (float2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v20+24+v64 @ rax_v26*8]");
			_ = 0;
		}
		float num4 = _weapon.PSpeed();
		float num5 = num * 250f;
		float deltaTime = PauseSystem.DeltaTime;
		float num6 = deltaTime * num5;
		float num7 = num6 + _angle;
		_angle = num7;
	}

	private void UpdatePosition()
	{
		//IL_003e: Expected O, but got I
		List<int> fibSequence = _fibSequence;
		float num = _angle * ((float)Math.PI / 180f);
		int fibIndex = _fibIndex;
		int fibIndex2 = _fibIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)fibIndex2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float2 float5 = default(float2);
			base.position = float5;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe void UpdateRotation()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _cachedTransform.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private unsafe void UpdateVfx()
	{
		//IL_0103: Expected O, but got I4
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_0038: Expected O, but got I4
		//IL_0096: Expected O, but got Ref
		//IL_00a5: Expected O, but got Ref
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_021d->IL0222: Incompatible stack heights: 1 vs 0
		//IL_0222->IL01a2: Incompatible stack heights: 1 vs 0
		int num = _fibIndex >> 31;
		object obj = _fibIndex - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		object obj4 = default(object);
		object obj3 = obj4 + 1;
		float maxInclusive = (float)obj3 + _angle;
		float minInclusive = _angle - (float)obj3;
		float num2 = UnityEngine.Random.Range(minInclusive, maxInclusive);
		object obj5 = obj3 + 1;
		float num3 = _cachedArea * 0.05f;
		float min = num3 * (float)obj5;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
		if ((nint)obj3 <= 0)
		{
			return;
		}
		object obj6 = 0;
		Vector2 vector = default(Vector2);
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		Vector2 vector2 = default(Vector2);
		while (true)
		{
			if ((object)_pfx != null)
			{
				Transform transform = _pfx.transform;
				if ((object)transform != null)
				{
					transform.localEulerAngles = (Vector3)(&vector);
					RenderingExtensions.SetScale(_pfx, (ParticleSystem.MinMaxCurve)(&minMaxCurve2));
					Transform seltzerNozzle = _seltzerNozzle;
					if ((object)_seltzerNozzle != null)
					{
						bool flag = ((UnityEngine.Object)seltzerNozzle).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)seltzerNozzle).m_CachedPtr, out Vector3 _);
						RenderingExtensions.EmitParticleAt(_pfx, vector2, 1);
						obj6++;
						bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
						minMaxCurve2 = minMaxCurve;
						vector = vector2;
						if (!flag2)
						{
							break;
						}
						continue;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_01cd: Expected O, but got Ref
		//IL_01e7: Expected native int or pointer, but got O
		//IL_03e0: Expected O, but got I4
		//IL_01ff: Expected O, but got Ref
		//IL_0226: Expected O, but got I
		//IL_0240: Expected native int or pointer, but got O
		//IL_025a: Expected O, but got I
		//IL_027a: Expected O, but got Ref
		//IL_0294: Expected native int or pointer, but got O
		//IL_03fd: Expected O, but got I4
		//IL_02b9: Expected O, but got Ref
		//IL_02c8: Expected O, but got I4
		//IL_02d1: Expected native int or pointer, but got O
		//IL_02eb: Expected O, but got I
		//IL_037b: Expected I4, but got I8
		//IL_045b->IL03d1: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager pfxManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
			pfxManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxManager = pfxManager;
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 1f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"BulletBlue");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(50f, 100f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(500f, 1000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.5f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
			_ = 0;
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			particleSystemConfig._on = false;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
			RenderingExtensions.SetDepth(_pfx, -1993);
			Transform transform = _pfx.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	private void StartDespawn()
	{
		//IL_0023: Expected O, but got I4
		//IL_0071: Expected I, but got O
		BaseBody baseBody = body;
		_isDespawning = true;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Fibonacci1_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		if (_moveTween != null)
		{
			TweenExtensions.Kill(_moveTween);
		}
		if (_rotateTween != null)
		{
			TweenExtensions.Kill(_rotateTween);
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CStartSpinning_003Eb__29_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
