using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_AxeProjectile_HellsFury : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__22_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CActivate_003Eb__22_1()
		{
		}
	}

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_RapierWeapon _trueWeapon;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem punchVFX;

	private MeshRenderer _Quad1;

	private MeshRenderer _Quad2;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private Timer _DespawnTimer;

	private PhaserSprite _displayImage;

	private float _offsetX;

	private MultiTargetTween slashTween;

	private MultiTargetTween modelTween1;

	private MultiTargetTween modelTween2;

	private Timer _hitboxTimer;

	private int _strikeTimes;

	private void LateUpdate()
	{
		float2 float5 = base.position;
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				float2 float6 = default(float2);
				base.position = float6;
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void Awake()
	{
		//IL_0080: Expected O, but got I4
		//IL_01a8->IL012e: Incompatible stack heights: 1 vs 0
		//IL_0114->IL012e: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite displayImage = instance.AddPhaserSprite(pos, "vfx", "add_pierceBack");
			_displayImage = displayImage;
			if ((object)_displayImage != null)
			{
				PhaserSprite phaserSprite = _displayImage.setOrigin(1f, (float?)(object)1);
				PhaserSprite displayImage2 = _displayImage;
				if ((object)_displayImage != null)
				{
					object spriteRenderer = displayImage2._spriteRenderer;
					if ((object)displayImage2._spriteRenderer != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdi_v6 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdi_v6 (System.Object)+10]");
						Color value = default(Color);
						SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
						if ((object)_displayImage != null)
						{
							PhaserSprite phaserSprite2 = _displayImage.setAlpha(0f);
							if ((object)_displayImage != null)
							{
								PhaserSprite phaserSprite3 = _displayImage.setDepth(2000);
								return;
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
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_01b8: Expected O, but got I8
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected F4, but got Unknown
		//IL_05be: Expected O, but got Ref
		//IL_0ac1: Expected O, but got I4
		//IL_07b6: Expected I, but got O
		//IL_0899: Expected O, but got I4
		//IL_08a7: Expected O, but got I4
		//IL_0a08->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0a25->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_039d->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_03c9->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_03fb->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0a42->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0488->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0a5f->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0515->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0548->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0580->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_05ac->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_05e6->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0a86->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_060d->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_062c->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_065e->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0691->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_06ce->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0aad->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0702->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_078a->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_07fb->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_07d9->IL07d9: Incompatible stack heights: 2 vs 1
		//IL_0835->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_0b06->IL08f1: Incompatible stack heights: 1 vs 0
		//IL_085c->IL08f1: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		EME_RapierWeapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0936;
		}
		nint num = (nint)typeof(EME_RapierWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v66 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v66 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v134+FFFFFFF8+v74 @ rax_v129*8]");
			if (0 == (nint)typeof(EME_RapierWeapon))
			{
				obj3 = 1;
				goto IL_0945;
			}
		}
		obj3 = 0;
		goto IL_0945;
		IL_0945:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (EME_RapierWeapon)_weapon;
		}
		goto IL_0936;
		IL_0936:
		_trueWeapon = trueWeapon;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_strikeTimes = 0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = 1f;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_hellstart, soundConfig, 100f, 2, time);
		if (body != null)
		{
			BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._offset = (float2)3212836864L;
				_ = 1082130432;
				BaseBody baseBody3 = body;
				if (body != null)
				{
					baseBody3._enable = false;
					_isCullable = false;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer = s_scene._renderer;
							if (s_scene._renderer != null)
							{
								float num4 = renderer.width * 0.25f;
								if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
								{
									if (((Equipment)weapon)._003COwner_003Ek__BackingField.flipX)
									{
										float num5 = num4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
										num4 = num5 ^ 0;
									}
									_offsetX = num4;
									if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
									{
										float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
										Camera main = Camera.main;
										if ((object)main != null)
										{
											Transform transform = main.transform;
											if ((object)transform != null)
											{
												bool flag2 = (byte)(~(((SoundManager.SoundConfig)(object)transform).Mute ? 1u : 0u)) != 0;
												Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform).Mute ? 1 : 0), out Vector3 ret);
												float2 float6 = default(float2);
												base.position = float6;
												if ((object)_Quad1 != null)
												{
													Material material = ((Renderer)_Quad1).GetMaterial();
													if ((object)material != null)
													{
														material.SetFloatImpl(_AlphaMul, 0f);
														if ((object)_Quad2 != null)
														{
															Material material2 = ((Renderer)_Quad2).GetMaterial();
															if ((object)material2 != null)
															{
																material2.SetFloatImpl(_AlphaMul, 0f);
																if ((object)_Quad1 != null)
																{
																	Material material3 = ((Renderer)_Quad1).GetMaterial();
																	TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material3, 1f, _AlphaMul, 0.5f);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																	if ((nint)0 == 0)
																	{
																		_ = 1;
																	}
																	if (tweenerCore != null && (object)_Quad2 != null)
																	{
																		Material material4 = ((Renderer)_Quad2).GetMaterial();
																		TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material4, 1f, _AlphaMul, 0.5f);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		if (tweenerCore2 != null && (object)_displayImage != null)
																		{
																			PhaserSprite phaserSprite = _displayImage.setVisible(visible: true);
																			if ((object)_displayImage != null)
																			{
																				PhaserSprite phaserSprite2 = _displayImage.setAlpha(0f);
																				if ((object)_displayImage != null)
																				{
																					Transform transform2 = _displayImage.transform;
																					if ((object)transform2 != null)
																					{
																						transform2.localEulerAngles = (Vector3)(&ret);
																						float2 float7 = base.position;
																						if ((object)GM.Core != null)
																						{
																							PhaserScene s_scene2 = ArcadePhysics.s_scene;
																							if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)_displayImage != null)
																							{
																								PhaserSprite phaserSprite3 = _displayImage.setPosition(float6);
																								if ((object)_displayImage != null)
																								{
																									PhaserSprite phaserSprite4 = _displayImage.setBlendMode(BlendMode.Add);
																									if ((object)_weapon != null)
																									{
																										float num6 = _weapon.PArea();
																										float num7 = (float)float6 * 0.5f;
																										if ((object)GM.Core != null)
																										{
																											PhaserScene s_scene3 = ArcadePhysics.s_scene;
																											if (ArcadePhysics.s_scene != null)
																											{
																												PhaserScene.Renderer renderer2 = s_scene3._renderer;
																												if (s_scene3._renderer != null)
																												{
																													float num8 = renderer2.width * 0.25f;
																													if (!(num8 > num7))
																													{
																														num7 = num8;
																													}
																													ArcadeSprite arcadeSprite2 = setScale(num7, (float?)(object)1);
																													if (slashTween != null)
																													{
																														slashTween.Kill();
																													}
																													TweenConfig tweenConfig = new TweenConfig();
																													object[] array = new object[1];
																													if (array != null)
																													{
																														if ((object)_displayImage != null)
																														{
																															nint num9 = (nint)array;
																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																															object obj4 = default(object);
																															bool flag3 = obj4 == null;
																														}
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																														if (tweenConfig != null)
																														{
																															tweenConfig.targets = array;
																															float2 float8 = base.position;
																															if ((object)GM.Core != null)
																															{
																																PhaserScene s_scene4 = ArcadePhysics.s_scene;
																																if (ArcadePhysics.s_scene != null && s_scene4._renderer != null)
																																{
																																	tweenConfig.duration = 100f;
																																	tweenConfig.ease = Ease.Linear;
																																	tweenConfig.delay = 500f;
																																	tweenConfig.y = (float?)(object)1;
																																	tweenConfig.scaleY = (float?)(object)1;
																																	TweenCallback onComplete = delegate
																																	{
																																		Activate();
																																	};
																																	tweenConfig.onComplete = onComplete;
																																	MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																																	slashTween = multiTargetTween;
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

	private void Activate()
	{
		//IL_004d: Expected O, but got I4
		//IL_0120: Expected I4, but got F4
		//IL_01d1: Expected I, but got O
		//IL_0242: Expected O, but got I4
		//IL_0405: Expected I, but got O
		//IL_0309: Expected I, but got O
		//IL_037a: Expected O, but got I4
		punchVFX.Play(withChildren: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Detune = 1f;
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_hellmid, soundConfig, 100f, 2, num);
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			//IL_0082: Expected O, but got I4
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			soundConfig2.Rate = 1.5f;
			soundConfig2.Volume = (float?)(object)1;
			float detune = (float)_strikeTimes * 100f;
			soundConfig2.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Sfx_eme_hellstart, soundConfig2, 100f, 10, time);
			int strikeTimes = _strikeTimes + 1;
			_strikeTimes = strikeTimes;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration = hitBoxDelay * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num2 = _weapon.PDuration();
		if (modelTween1 != null)
		{
			modelTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _Quad1.transform;
		if ((object)transform != null)
		{
			nint num3 = (nint)array;
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
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onComplete2 = _003C_003Ec._003C_003E9__22_1;
		bool flag = _003C_003Ec._003C_003E9__22_1 != null;
		bool flag2 = true;
		nint num4 = (nint)transform;
		if (!flag)
		{
			onComplete2 = (_003C_003Ec._003C_003E9__22_1 = delegate
			{
			});
			flag2 = false;
			num4 = 0;
		}
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		modelTween1 = multiTargetTween;
		if (modelTween2 != null)
		{
			modelTween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		Transform transform2 = _Quad2.transform;
		if ((object)transform2 != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = duration;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.scaleY = (float?)(object)1;
		TweenCallback onComplete3 = delegate
		{
			StartDespawn();
		};
		tweenConfig2.onComplete = onComplete3;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		modelTween2 = multiTargetTween2;
	}

	public void StartDespawn()
	{
		//IL_008a: Expected I, but got O
		punchVFX.Stop();
		Material material = ((Renderer)_Quad1).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 0f, _AlphaMul, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material2 = ((Renderer)_Quad2).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material2, 0f, _AlphaMul, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_AxeProjectile_HellsFury>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (modelTween1 != null)
		{
			modelTween1.Kill();
		}
		if (modelTween2 != null)
		{
			modelTween2.Kill();
		}
		base.Despawn();
	}

	static EME_AxeProjectile_HellsFury()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003CInitProjectile_003Eb__21_0()
	{
		Activate();
	}

	private void _003CActivate_003Eb__22_0()
	{
		//IL_0082: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Rate = 1.5f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_strikeTimes * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_hellstart, soundConfig, 100f, 10, time);
		int strikeTimes = _strikeTimes + 1;
		_strikeTimes = strikeTimes;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CActivate_003Eb__22_2()
	{
		StartDespawn();
	}
}
