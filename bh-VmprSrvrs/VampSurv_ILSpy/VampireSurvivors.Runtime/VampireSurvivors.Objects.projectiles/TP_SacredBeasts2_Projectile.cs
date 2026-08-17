using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SacredBeasts2_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private float _bodyRadius = 24f;

	private Timer _hitBoxTimer;

	private Timer _durationTimer;

	private PhaserSprite _displaySprite1;

	private PhaserSprite _displaySprite2;

	private PhaserSprite _displaySprite3;

	private PhaserSprite _displaySprite4;

	private PhaserSprite _displaySprite5;

	private MultiTargetTween _alphaTween1;

	private MultiTargetTween _alphaTween2;

	private MultiTargetTween _alphaTween3;

	private MultiTargetTween _alphaTween4;

	private MultiTargetTween _alphaTween5;

	private TP_SacredBeasts1_Weapon _trueWeapon;

	private Timer _selfDelayTimer;

	private bool _canShoot = true;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_ShieldSB2");
		PhaserSprite displaySprite = phaserSprite.setAlpha(0f);
		_displaySprite1 = displaySprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_ShieldSB3");
		PhaserSprite displaySprite2 = phaserSprite2.setAlpha(0f);
		_displaySprite2 = displaySprite2;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_ShieldSB4");
		PhaserSprite displaySprite3 = phaserSprite3.setAlpha(0f);
		_displaySprite3 = displaySprite3;
		GameObject gameObject4 = base.gameObject;
		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "ThosePeople", "TP_VFX_ShieldSB5");
		PhaserSprite displaySprite4 = phaserSprite4.setAlpha(0f);
		_displaySprite4 = displaySprite4;
		GameObject gameObject5 = base.gameObject;
		PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "ThosePeople", "TP_VFX_ShieldSB1");
		PhaserSprite displaySprite5 = phaserSprite5.setAlpha(0f);
		_displaySprite5 = displaySprite5;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_048b: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_0213: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_038f: Expected I4, but got F4
		//IL_04b1: Expected O, but got F4
		//IL_04cf: Expected O, but got I4
		//IL_0407: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		_isCullable = false;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0464;
		}
		nint num = (nint)typeof(TP_SacredBeasts1_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v59 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SacredBeasts1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v15 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v59 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SacredBeasts1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v15 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v103+FFFFFFF8+v70 @ rax_v98*8]");
			if (0 == (nint)typeof(TP_SacredBeasts1_Weapon))
			{
				obj3 = 1;
				goto IL_0473;
			}
		}
		obj3 = 0;
		goto IL_0473;
		IL_0473:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0464;
		IL_0464:
		_trueWeapon = (TP_SacredBeasts1_Weapon)trueWeapon;
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite = _displaySprite1.setLocalPosition(localPosition);
		PhaserSprite phaserSprite2 = _displaySprite2.setLocalPosition(localPosition);
		PhaserSprite phaserSprite3 = _displaySprite3.setLocalPosition(localPosition);
		PhaserSprite phaserSprite4 = _displaySprite4.setLocalPosition(localPosition);
		PhaserSprite phaserSprite5 = _displaySprite5.setLocalPosition(localPosition);
		_canShoot = true;
		StartAlphaTweens();
		float num4 = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			UpdatePosition();
			float num6 = _weapon.PInterval();
			Weapon weapon3 = _weapon;
			float num7 = weapon3.PDuration();
			float num9 = default(float);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				object obj6 = UnityEngine.Random.value;
				float num8 = (float)obj4 - 0.5f;
				soundConfig.Volume = (float?)(object)1;
				float detune = num8 * 200f;
				soundConfig.Detune = detune;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_HolyRod, soundConfig, 200f, 10, num9);
			}
			float hitBoxDelay = weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float num10 = hitBoxDelay * 0.001f;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitBoxTimer = Timers.Register(num10, onComplete, null, isLooped: true, (byte)(int)num9 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitBoxTimer = hitBoxTimer;
			float num11 = weapon.PDuration();
			Action onComplete2 = StartDespawn;
			float duration = num10 * 0.001f;
			Timer durationTimer = Timers.Register(duration, onComplete2, null, isLooped: false, (byte)(int)num9 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_durationTimer = durationTimer;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void StartAlphaTweens()
	{
		//IL_001d: Invalid comparison between F4 and O
		//IL_003d: Invalid comparison between O and F4
		//IL_0130: Expected I, but got O
		//IL_0198: Expected I4, but got I8
		//IL_01b4: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_02b5: Expected I4, but got I8
		//IL_02df: Expected O, but got I4
		//IL_0378: Expected I, but got O
		//IL_03e0: Expected I4, but got I8
		//IL_040a: Expected O, but got I4
		//IL_04a3: Expected I, but got O
		//IL_050b: Expected I4, but got I8
		//IL_0535: Expected O, but got I4
		float num = _weapon.PArea();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
		{
		}
		PhaserSprite phaserSprite = _displaySprite1.setAlpha(0f);
		PhaserSprite phaserSprite2 = _displaySprite2.setAlpha(0f);
		PhaserSprite phaserSprite3 = _displaySprite3.setAlpha(0f);
		PhaserSprite phaserSprite4 = _displaySprite4.setAlpha(0f);
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite1 != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween1 = alphaTween;
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_displaySprite2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 500f;
		tweenConfig2.repeat = -1;
		tweenConfig2.yoyo = true;
		tweenConfig2.delay = 250f;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig2);
		_alphaTween2 = alphaTween2;
		if (_alphaTween3 != null)
		{
			_alphaTween3.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_displaySprite3 != null)
		{
			nint num4 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.duration = 500f;
		tweenConfig3.repeat = -1;
		tweenConfig3.yoyo = true;
		tweenConfig3.delay = 500f;
		tweenConfig3.alpha = (float?)(object)1;
		MultiTargetTween alphaTween3 = Tweens.Add(tweenConfig3);
		_alphaTween3 = alphaTween3;
		if (_alphaTween4 != null)
		{
			_alphaTween4.Kill();
		}
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[1];
		if ((object)_displaySprite4 != null)
		{
			nint num5 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.duration = 500f;
		tweenConfig4.repeat = -1;
		tweenConfig4.yoyo = true;
		tweenConfig4.delay = 750f;
		tweenConfig4.alpha = (float?)(object)1;
		MultiTargetTween alphaTween4 = Tweens.Add(tweenConfig4);
		_alphaTween4 = alphaTween4;
	}

	public void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
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
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SacredBeasts2_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		//IL_03f9: Expected O, but got I4
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_04fc->IL03e5: Incompatible stack heights: 1 vs 0
		//IL_0174->IL03e5: Incompatible stack heights: 1 vs 0
		//IL_01a3->IL03e5: Incompatible stack heights: 1 vs 0
		//IL_0582->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_01df->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_0211->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_0243->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_0275->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_02be->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_02fe->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_033e->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_037e->IL03e5: Incompatible stack heights: 2 vs 0
		//IL_03be->IL03e5: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			TP_SacredBeasts1_Weapon trueWeapon = _trueWeapon;
			ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)_trueWeapon != null)
			{
				float num = (float)trueWeapon.SlotNumber / 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
					bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
					if ((trueWeapon.SlotNumber & 1) != 0)
					{
						flag2 = flag;
					}
					object obj = (flag2 ? 1 : 0) + (flag2 ? 1 : 0);
					object obj2 = obj - 1;
					object obj3 = obj ^ 1;
					object obj4 = obj ^ obj2;
					object obj5 = obj3 & obj4;
					bool flag3 = (nint)obj5 < 0;
					bool flag4 = (nint)obj2 < 0;
					bool flag5 = obj2 == null;
					bool flag6 = flag4 == flag3;
					bool flag7 = !flag5;
					bool flag8 = flag7 & flag6;
					((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag9 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							if (body != null)
							{
								float num2 = base.scale;
								((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag10 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if ((nint)obj > 1)
										{
										}
										float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
										float2 float6 = default(float2);
										base.position = float6;
										if ((object)_displaySprite1 != null)
										{
											PhaserSprite phaserSprite = _displaySprite1.setFlipX(flag8);
											if ((object)_displaySprite2 != null)
											{
												PhaserSprite phaserSprite2 = _displaySprite2.setFlipX(flag8);
												if ((object)_displaySprite3 != null)
												{
													PhaserSprite phaserSprite3 = _displaySprite3.setFlipX(flag8);
													if ((object)_displaySprite4 != null)
													{
														PhaserSprite phaserSprite4 = _displaySprite4.setFlipX(flag8);
														if ((object)_displaySprite5 != null)
														{
															PhaserSprite phaserSprite5 = _displaySprite5.setFlipX(flag8);
															int num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
															if ((object)_displaySprite1 != null)
															{
																int num4 = num3 + 1;
																PhaserSprite phaserSprite6 = _displaySprite1.setDepth(num4);
																if ((object)_displaySprite2 != null)
																{
																	int num5 = num3 + 2;
																	PhaserSprite phaserSprite7 = _displaySprite2.setDepth(num5);
																	if ((object)_displaySprite3 != null)
																	{
																		int num6 = num3 + 3;
																		PhaserSprite phaserSprite8 = _displaySprite3.setDepth(num6);
																		if ((object)_displaySprite4 != null)
																		{
																			int num7 = num3 + 4;
																			PhaserSprite phaserSprite9 = _displaySprite4.setDepth(num7);
																			if ((object)_displaySprite5 != null)
																			{
																				int num8 = num3 + 5;
																				PhaserSprite phaserSprite10 = _displaySprite5.setDepth(num8);
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		if (_alphaTween3 != null)
		{
			_alphaTween3.Kill();
		}
		if (_alphaTween4 != null)
		{
			_alphaTween4.Kill();
		}
		if (_alphaTween5 != null)
		{
			_alphaTween5.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0154: Expected I, but got O
		//IL_01c6: Expected O, but got I4
		if (!_canShoot)
		{
			return;
		}
		_canShoot = false;
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			_canShoot = true;
		};
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer selfDelayTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_selfDelayTimer = selfDelayTimer;
		TP_SacredBeasts1_Weapon trueWeapon = _trueWeapon;
		_trueWeapon.FireProjectiles(trueWeapon._standardPool);
		if (_alphaTween5 != null)
		{
			_alphaTween5.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite5 != null)
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
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite = _displaySprite5.setAlpha(0f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween5 = alphaTween;
	}

	private void _003CInitProjectile_003Eb__18_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003COnHasHitAnObject_003Eb__24_0()
	{
		_canShoot = true;
	}

	private void _003COnHasHitAnObject_003Eb__24_1()
	{
		PhaserSprite phaserSprite = _displaySprite5.setAlpha(0f);
	}
}
