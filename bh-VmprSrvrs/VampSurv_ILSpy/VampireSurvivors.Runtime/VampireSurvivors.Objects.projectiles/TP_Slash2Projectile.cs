using System;
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
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Slash2Projectile : Projectile
{
	private TrailRenderer _verbotenTrail;

	protected SpriteTrail _Trail;

	private float startingAngle;

	private float saveAngle;

	private float radiusX;

	private float radiusY;

	private TweenerCore<float, float, FloatOptions> _radiusTween;

	private TweenerCore<float, float, FloatOptions> _radiusTween2;

	private TweenerCore<float, float, FloatOptions> _angleTween;

	private Timer _despawnTimer;

	private Vector2 direction;

	private Sprite _verbotenTrailSprite;

	private static readonly int _FlipX;

	private static readonly int _FlipY;

	private float2 _startingOffset;

	private float finalAngle;

	private float currentAngle;

	private float trailAlpha = 0.15f;

	private TweenerCore<float, float, FloatOptions> _trailAlphaTween;

	private bool _isDespawning;

	private MultiTargetTween _despawnTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Sword02", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite verbotenTrailSprite = default(Sprite);
		_verbotenTrailSprite = verbotenTrailSprite;
		SetupVerbotenTrail();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0a3f: Expected I, but got O
		//IL_0a6c: Expected O, but got I
		//IL_0b6d: Expected F4, but got I
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected F4, but got Unknown
		//IL_0517: Expected O, but got I8
		//IL_05d4: Expected O, but got I4
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_0bdf: Expected O, but got I4
		//IL_0bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected O, but got Unknown
		//IL_082e: Expected O, but got I4
		//IL_088b: Expected O, but got I4
		//IL_095f->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_01f6->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0225->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_025f->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0986->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0293->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_02be->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_09ad->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_03f9->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0349->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0a2c->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_09f9->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_043f->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_038f->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_046b->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_03bb->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0afe->IL08cb: Incompatible stack heights: 1 vs 0
		//IL_0b4c->IL08cb: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_isDespawning = false;
		float endValue;
		int num6;
		float value;
		Material material4;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float num2 = default(float);
				ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
				if ((object)_Trail != null)
				{
					SpriteTrail spriteTrail = _Trail.setVisible(b: false);
					if ((object)weapon != null)
					{
						float num3 = weapon.PArea();
						float num4 = num2 * 0.4f;
						if ((object)_verbotenTrail != null)
						{
							_verbotenTrail.endWidth = num4;
							_verbotenTrail.startWidth = num4;
							if ((object)_verbotenTrail != null)
							{
								Material material = ((Renderer)_verbotenTrail).GetMaterial();
								RenderingExtensions.SetAlpha(material, 0.15f);
								if ((object)_verbotenTrail != null)
								{
									_verbotenTrail.time = 0.85f;
									Weapon verbotenTrail = (Weapon)(object)_verbotenTrail;
									if ((object)_verbotenTrail != null)
									{
										bool flag = ((UnityEngine.Object)verbotenTrail).m_CachedPtr == (IntPtr)0;
										TrailRenderer.Clear_Injected(((UnityEngine.Object)verbotenTrail).m_CachedPtr);
										if ((object)_verbotenTrail != null)
										{
											_verbotenTrail.emitting = true;
											Weapon weapon2 = _weapon;
											trailAlpha = 0.15f;
											if ((object)_weapon != null)
											{
												VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
												{
													direction = characterController._lastMovementDirection;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v30 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
													_ = 0;
													if ((object)GM.Core != null)
													{
														PhaserScene s_scene = ArcadePhysics.s_scene;
														if (ArcadePhysics.s_scene != null)
														{
															PhaserScene.Renderer renderer = s_scene._renderer;
															if (s_scene._renderer != null)
															{
																float num5 = renderer.width;
																if ((object)GM.Core != null)
																{
																	PhaserScene s_scene2 = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null)
																	{
																		PhaserScene.Renderer renderer2 = s_scene2._renderer;
																		if (s_scene2._renderer != null)
																		{
																			if (!(renderer.width > renderer2.height))
																			{
																				num5 = renderer2.height;
																			}
																			endValue = num5 * 0.45f;
																			if (0 <= (nint)direction)
																			{
																				if ((object)_verbotenTrail != null)
																				{
																					Material material2 = ((Renderer)_verbotenTrail).GetMaterial();
																					if ((object)material2 != null)
																					{
																						material2.SetFloatImpl(_FlipX, 1f);
																						if ((object)_verbotenTrail != null)
																						{
																							Material material3 = ((Renderer)_verbotenTrail).GetMaterial();
																							if ((object)material3 != null)
																							{
																								num6 = _FlipY;
																								value = -1f;
																								material4 = material3;
																								goto IL_09fe;
																							}
																						}
																					}
																				}
																			}
																			else if ((object)_verbotenTrail != null)
																			{
																				Material material5 = ((Renderer)_verbotenTrail).GetMaterial();
																				if ((object)material5 != null)
																				{
																					material5.SetFloatImpl(_FlipX, -1f);
																					if ((object)_verbotenTrail != null)
																					{
																						Material material6 = ((Renderer)_verbotenTrail).GetMaterial();
																						if ((object)material6 != null)
																						{
																							num6 = _FlipY;
																							value = 1f;
																							material4 = material6;
																							goto IL_09fe;
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
		goto IL_08cb;
		IL_09fe:
		material4.SetFloatImpl(num6, value);
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v43 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rcx_v31 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Slash2Projectile)+114]");
		object obj = num9 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,dword ptr [rdi+70h]\"");
		float num10 = 0f * (float)Math.PI;
		object obj2 = Vector2.rightVector * direction;
		float num11 = num10 * 0.16f;
		object obj3 = obj2 + obj;
		float num12 = num11 + (float)Math.PI / 2f;
		if (0 > (nint)obj3)
		{
			float num13 = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			num12 = num13 ^ 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Slash2Projectile)+114]");
		finalAngle = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Slash2Projectile)+114]");
		float x = (base.angle = (currentAngle = (startingAngle = 0f + num12)) * 57.29578f);
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_Slash2Projectile)(object)dOSetter)._003CInitProjectile_003Eb__22_1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, finalAngle, 0.25f);
		object obj4 = 6603577472L;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				_ = 0;
			}
		}
		_angleTween = tweenerCore;
		Weapon angleTween = (Weapon)(object)_angleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore2;
		if (_angleTween != null)
		{
			((Equipment)angleTween)._signalBus = (SignalBus)(object)"DefaultGameTweenId";
			_startingOffset = (float2)0;
			_ = 1042536202;
			radiusX = 0f;
			if (_radiusTween != null)
			{
				TweenExtensions.Kill(_radiusTween);
			}
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((TP_Slash2Projectile)(object)dOSetter2)._003CInitProjectile_003Eb__22_3(x);
			tweenerCore2 = DOTween.To(getter2, dOSetter2, endValue, 0.25f);
			TweenCallback tweenCallback2;
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ rax_v64 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag2 = (nint)0 == 0;
					_ = 0;
					if (!flag2)
					{
						object obj5 = tweenerCore2 + 184;
						object obj6 = obj5 >> 12;
						object obj7 = obj6 & 0x1FFFFF;
						object obj8 = obj7 >> 6;
						object obj9 = obj7 & 0x3F;
						nint num16;
						do
						{
							object obj10 = 1 << (int)obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r14_v6+462E0+v1327 @ rdx_v44*8]");
							object obj11 = 0 | obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r14_v6+462E0+v1327 @ rdx_v44*8]");
							nint num15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r14_v6+462E0+v1327 @ rdx_v44*8]");
							if (num15 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r14_v6+462E0+v1327 @ rdx_v44*8]");
							num16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r14_v6+462E0+v1327 @ rdx_v44*8]");
						}
						while (num16 != 0);
						TweenCallback tweenCallback = GoBack;
						tweenCallback2 = tweenCallback;
						goto IL_0789;
					}
				}
			}
			TweenCallback tweenCallback3 = GoBack;
			bool flag3 = tweenerCore2 == null;
			tweenCallback2 = tweenCallback3;
			if (!flag3)
			{
				goto IL_0789;
			}
			goto IL_07b8;
		}
		goto IL_08cb;
		IL_0789:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ rax_v64 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_07b8;
		IL_07b8:
		_radiusTween = tweenerCore2;
		Weapon radiusTween = (Weapon)(object)_radiusTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_radiusTween != null)
		{
			((Equipment)radiusTween)._signalBus = (SignalBus)(object)"DefaultGameTweenId";
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordThrow, new SoundManager.SoundConfig
			{
				Volume = (float?)(object)1,
				Rate = 1f
			}, 200f, 10, time);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
			{
				Rate = 1f,
				Volume = (float?)(object)1
			};
			float detune = (float)_indexInWeapon * 50f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_SwordRune, soundConfig, 200f, 10, time);
			return;
		}
		goto IL_08cb;
		IL_08cb:
		throw new NullReferenceException();
	}

	public void GoBack()
	{
		//IL_00a5: Expected O, but got I8
		//IL_01c7: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_0645: Expected O, but got I4
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		//IL_018c: Expected O, but got I4
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_0697: Expected O, but got I4
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_06e9: Expected O, but got I4
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected O, but got Unknown
		SpriteTrail spriteTrail = _Trail.setVisible(b: true);
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((TP_Slash2Projectile)(object)dOSetter)._003CGoBack_003Eb__23_1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.32f, 0.25f);
		object obj = 6603577472L;
		object obj9;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v307 @ rdx_v45*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v307 @ rdx_v45*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v307 @ rdx_v45*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v307 @ rdx_v45*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v307 @ rdx_v45*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = StartDespawn;
					obj9 = 0;
					tweenCallback2 = tweenCallback;
					goto IL_01e6;
				}
			}
		}
		TweenCallback tweenCallback3 = StartDespawn;
		bool flag2 = tweenerCore == null;
		obj9 = 0;
		tweenCallback2 = tweenCallback3;
		object obj10 = 0;
		if (!flag2)
		{
			goto IL_01e6;
		}
		goto IL_0225;
		IL_0523:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0552;
		IL_0421:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		TweenerCore<float, float, FloatOptions> tweenerCore2;
		TweenCallback tweenCallback5;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj11 = tweenerCore2 + 112;
				object obj12 = obj11 >> 12;
				object obj13 = obj12 & 0x1FFFFF;
				object obj14 = obj13 >> 6;
				object obj15 = obj13 & 0x3F;
				nint num4;
				do
				{
					object obj16 = 1 << (int)obj15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v810 @ rdx_v29*8]");
					object obj17 = 0 | obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v810 @ rdx_v29*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v810 @ rdx_v29*8]");
					if (num3 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v810 @ rdx_v29*8]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v810 @ rdx_v29*8]");
				}
				while (num4 != 0);
				TweenCallback tweenCallback4 = delegate
				{
					_verbotenTrail.emitting = false;
				};
				tweenCallback5 = tweenCallback4;
				goto IL_0523;
			}
		}
		goto IL_04e8;
		IL_01e6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		bool flag3 = (nint)0 == 0;
		obj10 = obj9;
		if (!flag3)
		{
			obj10 = obj9;
		}
		goto IL_0225;
		IL_04e8:
		TweenCallback tweenCallback6 = delegate
		{
			_verbotenTrail.emitting = false;
		};
		bool flag4 = tweenerCore2 == null;
		tweenCallback5 = tweenCallback6;
		if (!flag4)
		{
			goto IL_0523;
		}
		goto IL_0552;
		IL_0552:
		_trailAlphaTween = tweenerCore2;
		TweenerCore<float, float, FloatOptions> trailAlphaTween = _trailAlphaTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return;
		IL_0225:
		_radiusTween = tweenerCore;
		TweenerCore<float, float, FloatOptions> radiusTween = _radiusTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_trailAlphaTween != null)
		{
			TweenExtensions.Kill(_trailAlphaTween);
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((TP_Slash2Projectile)(object)dOSetter2)._003CGoBack_003Eb__23_3(x);
		tweenerCore2 = DOTween.To(getter2, dOSetter2, 0f, 0.15f);
		TweenCallback tweenCallback8;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag5 = (nint)0 == 0;
				_ = 0;
				if (!flag5)
				{
					object obj18 = tweenerCore2 + 184;
					object obj19 = obj18 >> 12;
					object obj20 = obj19 & 0x1FFFFF;
					object obj21 = obj20 >> 6;
					object obj22 = obj20 & 0x3F;
					nint num6;
					do
					{
						object obj23 = 1 << (int)obj22;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v693 @ rdx_v33*8]");
						object obj24 = 0 | obj23;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v693 @ rdx_v33*8]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v693 @ rdx_v33*8]");
						if (num5 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v693 @ rdx_v33*8]");
						num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbp_v2+462E0+v693 @ rdx_v33*8]");
					}
					while (num6 != 0);
					TweenCallback tweenCallback7 = delegate
					{
						Material material = ((Renderer)_verbotenTrail).GetMaterial();
						RenderingExtensions.SetAlpha(material, trailAlpha);
					};
					tweenCallback8 = tweenCallback7;
					goto IL_0421;
				}
			}
		}
		TweenCallback tweenCallback9 = delegate
		{
			Material material = ((Renderer)_verbotenTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, trailAlpha);
		};
		bool flag6 = tweenerCore2 == null;
		tweenCallback8 = tweenCallback9;
		if (!flag6)
		{
			goto IL_0421;
		}
		goto IL_04e8;
	}

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00cd: Expected O, but got I4
		//IL_00e8: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_despawnTween != null)
			{
				_despawnTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Slash2Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
			_despawnTween = despawnTween;
		}
	}

	public override void Despawn()
	{
		TrailRenderer verbotenTrail = _verbotenTrail;
		if ((object)_verbotenTrail != null && ((UnityEngine.Object)verbotenTrail).m_CachedPtr != (IntPtr)0)
		{
			_verbotenTrail.Clear();
			_verbotenTrail.emitting = false;
		}
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_radiusTween2 != null)
		{
			TweenExtensions.Kill(_radiusTween2);
		}
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		base.Despawn();
	}

	public override void InternalUpdate()
	{
		float deltaTime = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num = currentAngle * 57.29578f;
		base.angle = num;
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	private void SetupVerbotenTrail()
	{
		//IL_0173->IL00f9: Incompatible stack heights: 1 vs 0
		//IL_0059->IL00f9: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL00f9: Incompatible stack heights: 1 vs 0
		//IL_01c3->IL00f9: Incompatible stack heights: 2 vs 0
		Sprite verbotenTrailSprite = _verbotenTrailSprite;
		if ((object)_verbotenTrailSprite != null)
		{
			bool flag = ((UnityEngine.Object)verbotenTrailSprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)verbotenTrailSprite).m_CachedPtr, out Rect _);
			if ((object)_verbotenTrail != null)
			{
				_verbotenTrail.time = 1f;
				object obj = default(object);
				float num = (float)obj * 0.01f;
				float num2 = num * 0.015f;
				if ((object)_verbotenTrail != null)
				{
					_verbotenTrail.endWidth = num2;
					_verbotenTrail.startWidth = num2;
					RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_verbotenTrail, _verbotenTrailSprite, true);
					TrailRenderer verbotenTrail = _verbotenTrail;
					if ((object)_verbotenTrail != null)
					{
						bool flag2 = ((UnityEngine.Object)verbotenTrail).m_CachedPtr == (IntPtr)0;
						TrailRenderer.Clear_Injected(((UnityEngine.Object)verbotenTrail).m_CachedPtr);
						if ((object)_verbotenTrail != null)
						{
							_verbotenTrail.emitting = false;
							TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_verbotenTrail);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	static TP_Slash2Projectile()
	{
		int num = Shader.PropertyToID("_FlipX");
		_FlipX = num;
		int num2 = Shader.PropertyToID("_FlipY");
		_FlipY = num2;
	}

	private float _003CInitProjectile_003Eb__22_0()
	{
		return currentAngle;
	}

	private void _003CInitProjectile_003Eb__22_1(float x)
	{
		currentAngle = x;
	}

	private float _003CInitProjectile_003Eb__22_2()
	{
		return radiusX;
	}

	private void _003CInitProjectile_003Eb__22_3(float x)
	{
		radiusX = x;
	}

	private float _003CGoBack_003Eb__23_0()
	{
		return radiusX;
	}

	private void _003CGoBack_003Eb__23_1(float x)
	{
		radiusX = x;
	}

	private float _003CGoBack_003Eb__23_2()
	{
		return trailAlpha;
	}

	private void _003CGoBack_003Eb__23_3(float x)
	{
		trailAlpha = x;
	}

	private void _003CGoBack_003Eb__23_4()
	{
		Material material = ((Renderer)_verbotenTrail).GetMaterial();
		RenderingExtensions.SetAlpha(material, trailAlpha);
	}

	private void _003CGoBack_003Eb__23_5()
	{
		_verbotenTrail.emitting = false;
	}
}
