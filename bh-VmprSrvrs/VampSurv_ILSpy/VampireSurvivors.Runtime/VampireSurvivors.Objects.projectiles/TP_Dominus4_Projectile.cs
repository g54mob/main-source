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

public class TP_Dominus4_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public PhaserSprite exp;

		internal void _003CAwake_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public float colorTime;

		public Color color1;

		public Color color2;

		public TP_Dominus4_Projectile _003C_003E4__this;

		internal float _003CDisplayExplosions_003Eb__0()
		{
			return colorTime;
		}

		internal void _003CDisplayExplosions_003Eb__1(float x)
		{
			colorTime = x;
		}

		internal unsafe void _003CDisplayExplosions_003Eb__2()
		{
			//IL_021e: Invalid comparison between I4 and F4
			//IL_0055: Expected F4, but got I4
			//IL_0259: Expected O, but got I4
			//IL_0262: Expected O, but got I4
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Expected O, but got Unknown
			//IL_0120->IL0202: Incompatible stack heights: 1 vs 0
			//IL_0157->IL0202: Incompatible stack heights: 1 vs 0
			//IL_0186->IL0202: Incompatible stack heights: 1 vs 0
			//IL_01e7->IL0202: Incompatible stack heights: 4 vs 0
			//IL_0201->IL030c: Incompatible stack heights: 4 vs 0
			float num = colorTime;
			if (!(0f > colorTime))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			TP_Dominus4_Projectile tP_Dominus4_Projectile = _003C_003E4__this;
			bool flag = (object)_003C_003E4__this == null;
			object obj = 0;
			object obj2 = 0;
			if (!flag)
			{
				float value = default(float);
				float num2 = default(float);
				while (true)
				{
					List<PhaserSprite> explosionSprites = tP_Dominus4_Projectile.explosionSprites;
					if (tP_Dominus4_Projectile.explosionSprites == null)
					{
						break;
					}
					if ((nint)obj2 < explosionSprites._size)
					{
						TP_Dominus4_Projectile tP_Dominus4_Projectile2 = _003C_003E4__this;
						if ((object)_003C_003E4__this == null)
						{
							break;
						}
						List<PhaserSprite> explosionSprites2 = tP_Dominus4_Projectile2.explosionSprites;
						if (tP_Dominus4_Projectile2.explosionSprites == null)
						{
							break;
						}
						bool flag2 = (nint)obj >= explosionSprites2._size;
						PhaserSprite[] items = explosionSprites2._items;
						if (explosionSprites2._items == null)
						{
							break;
						}
						PhaserSprite phaserSprite = items[obj];
						if ((object)items[obj] == null)
						{
							break;
						}
						object spriteRenderer = phaserSprite._spriteRenderer;
						if ((object)phaserSprite._spriteRenderer == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rsi_v6 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rsi_v6 (System.Object)+10]");
						SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
						object spriteRenderer2 = phaserSprite._spriteRenderer;
						bool flag4 = (object)phaserSprite._spriteRenderer == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rsi_v7 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rsi_v7 (System.Object)+10]");
						SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(phaserSprite._spriteRenderer, num2);
						tP_Dominus4_Projectile = _003C_003E4__this;
						obj++;
						if ((object)_003C_003E4__this == null)
						{
							break;
						}
						num = num2;
						obj2 = obj;
						continue;
					}
					return;
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CDisplayExplosions_003Eb__3()
		{
			_003C_003E4__this.HideBlackScreen();
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public PhaserSprite explo;

		internal void _003CDisplayExplosions_003Eb__4()
		{
			PhaserSprite phaserSprite = explo.setAlpha(0f);
		}
	}

	private float _displaySpritePxSize = 128f;

	private float _innerRadius = 0.32f;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private PhaserSprite _displaySprite;

	private int frameIndex;

	private float frameTime;

	private bool _isActivated;

	private bool _canUpdate;

	private PhaserSprite _draculaAnimSprite;

	private List<PhaserSprite> explosionSprites;

	private PhaserSprite _redCircleSprite;

	private MultiTargetTween _circleTween;

	private List<PhaserSprite> raySprites;

	private float _maxRadius;

	private MultiTargetTween _circleTween2;

	private MultiTargetTween _tween4;

	private TP_Dominus4_Weapon _trueWeapon;

	private bool _canFire;

	protected unsafe override void Awake()
	{
		//IL_003f: Expected O, but got F4
		//IL_010c: Expected O, but got F4
		//IL_01d9: Expected O, but got F4
		//IL_0215: Expected O, but got F4
		//IL_0290: Expected O, but got I4
		//IL_0290: Expected I4, but got O
		//IL_0318: Expected I4, but got O
		//IL_0361: Expected O, but got I4
		//IL_0411: Expected I, but got O
		//IL_0427: Expected O, but got I
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_049e: Expected I, but got O
		//IL_0b47: Expected O, but got I4
		//IL_0b5e: Expected I, but got I8
		//IL_04dc: Expected O, but got I4
		//IL_04dc: Expected I4, but got O
		//IL_0487: Expected I, but got I8
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Expected O, but got Unknown
		//IL_080a: Invalid comparison between I4 and F4
		//IL_0831: Expected F4, but got I4
		//IL_087e: Expected O, but got I4
		//IL_08a0: Expected O, but got I4
		//IL_08f9: Expected O, but got I4
		//IL_09b4: Expected I4, but got O
		//IL_09ba: Expected O, but got I
		//IL_0a67: Expected O, but got Ref
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a75: Expected O, but got Unknown
		//IL_023d->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_025f->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_02b4->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_02ec->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_0c08->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_037d->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_03be->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_0b7b->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_04f9->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_0532->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_0561->IL0a9b: Incompatible stack heights: 1 vs 0
		//IL_0bd9->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_05b6->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_05d8->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0614->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0663->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_071f->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0706->IL0bde: Incompatible stack heights: 2 vs 1
		//IL_0c2f->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0753->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0786->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0c56->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_07ba->IL0a9b: Incompatible stack heights: 2 vs 0
		//IL_0a95->IL0d1c: Incompatible stack heights: 9 vs 2
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setTintFill(isEnabled: true, 0u);
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			float num = default(float);
			PhaserSprite displaySprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)num, "ThosePeople", "TP_VFX_Neutron00");
			_displaySprite = displaySprite;
			if ((object)_displaySprite != null)
			{
				PhaserSprite phaserSprite = _displaySprite.setDepth(2000);
				if ((object)_displaySprite != null)
				{
					PhaserSprite phaserSprite2 = _displaySprite.setVisible(visible: false);
					if ((object)_displaySprite != null)
					{
						PhaserSprite phaserSprite3 = _displaySprite.setTintFill(isEnabled: true, 0u);
						GameObject gameObject2 = base.gameObject;
						PhaserSprite redCircleSprite = RenderingExtensions.AddPhaserSprite(gameObject2, (Vector2)num, "ThosePeople", "TP_VFX_Dominus41");
						_redCircleSprite = redCircleSprite;
						if ((object)_redCircleSprite != null)
						{
							PhaserSprite phaserSprite4 = _redCircleSprite.setDepth(2001);
							if ((object)_redCircleSprite != null)
							{
								PhaserSprite phaserSprite5 = _redCircleSprite.setVisible(visible: false);
								if ((object)_redCircleSprite != null)
								{
									Transform transform = _redCircleSprite.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1557 @ rax_v52 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1557 @ rax_v52 (UnityEngine.Transform)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									GameObject gameObject3 = base.gameObject;
									PhaserSprite draculaAnimSprite = RenderingExtensions.AddPhaserSprite(gameObject3, (Vector2)num, "ThosePeople", "TP_VFX_Dominus10");
									_draculaAnimSprite = draculaAnimSprite;
									string text = default(string);
									int num2 = default(int);
									bool flag2 = default(bool);
									List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Dominus", 10, 35, (Vector2)num, text, num2, flag2);
									PhaserSprite draculaAnimSprite2 = _draculaAnimSprite;
									if ((object)_draculaAnimSprite != null && (object)draculaAnimSprite2._spriteAnimation != null)
									{
										bool autoSetAnimation = default(bool);
										draculaAnimSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)(int)text != 0, (byte)num2 != 0, (Action)flag2, autoSetAnimation);
										PhaserSprite draculaAnimSprite3 = _draculaAnimSprite;
										if ((object)_draculaAnimSprite != null)
										{
											Action action = FadeOutDracula;
											if ((object)draculaAnimSprite3._spriteAnimation != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
												List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_FireDesat", 19, 29, "ThosePeople", (int)text);
												List<PhaserSprite> list = new List<PhaserSprite>();
												explosionSprites = list;
												GameObject gameObject4 = null;
												float value2 = default(float);
												float num15 = default(float);
												while (true)
												{
													_003C_003Ec__DisplayClass20_0 obj = new _003C_003Ec__DisplayClass20_0();
													PhaserWorld instance = PhaserWorld.Instance;
													if ((object)instance == null)
													{
														break;
													}
													PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "ThosePeople", "TP_VFX_FireDesat19");
													if (obj == null)
													{
														break;
													}
													obj.exp = exp;
													PhaserSprite exp2 = obj.exp;
													if ((object)obj.exp == null)
													{
														break;
													}
													Action action2 = null;
													nint num3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r10_v13 (Il2CppMethodInfo)+8]");
													((Delegate)action2).method_ptr = (IntPtr)0;
													((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CAwake_003Eb__0);
													((Delegate)action2).m_target = obj;
													((Delegate)action2).method_code = (IntPtr)action2;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r10_v13 (Il2CppMethodInfo)+4C]");
													object obj2 = (nint)0 >> 4;
													object obj3 = obj2 & 1;
													nint num4;
													if (obj3 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r10_v13 (Il2CppMethodInfo)+52]");
														if ((nint)0 == 0)
														{
															num4 = unchecked((nint)6447293664L);
															goto IL_0b3e;
														}
													}
													((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
													num4 = ((Delegate)action2).method_ptr;
													goto IL_0b3e;
													IL_0b3e:
													object obj4 = 24;
													((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
													if ((object)exp2._spriteAnimation == null)
													{
														break;
													}
													exp2._spriteAnimation.AddAnimation("bang", animationFrames2, 16, (byte)(int)text != 0, (byte)num2 != 0, (Action)flag2, autoSetAnimation);
													if ((object)obj.exp == null)
													{
														break;
													}
													PhaserSprite phaserSprite6 = obj.exp.setVisible(visible: false);
													if ((object)obj.exp == null)
													{
														break;
													}
													Transform transform2 = obj.exp.transform;
													if ((object)transform2 == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v92 (UnityEngine.Transform)+10]");
													bool flag3 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v92 (UnityEngine.Transform)+10]");
													Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
													if ((object)obj.exp == null)
													{
														break;
													}
													PhaserSprite phaserSprite7 = obj.exp.setDepth(3000);
													PhaserSprite exp3 = obj.exp;
													if ((object)obj.exp == null || (object)exp3._spriteAnimation == null)
													{
														break;
													}
													exp3._spriteAnimation.SetAnimation("bang");
													List<object> list2 = (List<object>)(object)explosionSprites;
													if (explosionSprites == null)
													{
														break;
													}
													int version = list2._version + 1;
													list2._version = version;
													object[] items = list2._items;
													if (list2._items == null)
													{
														break;
													}
													if (list2._size >= items.Length)
													{
														((List<object>)(object)explosionSprites).AddWithResize((object)obj.exp);
													}
													else
													{
														int num5 = list2._size + 1;
														list2._size = num5;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													gameObject4 = (GameObject)(gameObject4 + 1);
													if ((nint)gameObject4 < 64)
													{
														continue;
													}
													if ((object)GM.Core == null)
													{
														break;
													}
													PhaserScene s_scene = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene == null)
													{
														break;
													}
													PhaserScene.Renderer renderer = s_scene._renderer;
													if (s_scene._renderer == null)
													{
														break;
													}
													float num6 = renderer.width * 0.5f;
													if ((object)GM.Core == null)
													{
														break;
													}
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene == null)
													{
														break;
													}
													PhaserScene.Renderer renderer2 = s_scene2._renderer;
													if (s_scene2._renderer == null)
													{
														break;
													}
													float num7 = renderer2.height * 0.5f;
													float num8 = num6 * num6;
													float num9 = num7 * num7;
													float num10 = num9 + num8;
													float maxRadius;
													if (!(0f > num10))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
														maxRadius = 0f;
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
														maxRadius = num10;
													}
													_maxRadius = maxRadius;
													List<PhaserSprite> list3 = new List<PhaserSprite>();
													raySprites = list3;
													object obj5 = 0;
													bool flag11;
													do
													{
														GameObject gameObject5 = base.gameObject;
														PhaserSprite phaserSprite8 = RenderingExtensions.AddPhaserSprite(gameObject5, (Vector2)0, "ThosePeople", "TP_VFX_Dominus40");
														bool flag4 = (object)phaserSprite8 == null;
														PhaserSprite phaserSprite9 = phaserSprite8.setVisible(visible: false);
														PhaserSprite phaserSprite10 = phaserSprite8.setDepth(2003);
														PhaserSprite phaserSprite11 = phaserSprite8.setOrigin(0f, (float?)(object)1);
														List<object> list4 = (List<object>)(object)raySprites;
														bool flag5 = raySprites == null;
														int version2 = list4._version + 1;
														list4._version = version2;
														object[] items2 = list4._items;
														int num11 = list4._size;
														bool flag6 = list4._items == null;
														if (list4._size >= items2.Length)
														{
															((List<object>)(object)raySprites).AddWithResize((object)phaserSprite8);
															num11 = (int)phaserSprite8;
															object obj6 = 0;
															object[] array = (object[])(object)raySprites;
														}
														else
														{
															int num12 = list4._size + 1;
															list4._size = num12;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															object obj6 = phaserSprite8;
															object[] array = list4._items;
														}
														float num13 = (float)obj5 * ((float)Math.PI / 90f);
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
														float num14 = (float)obj5 * ((float)Math.PI / 90f);
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rax_v119 (VampireSurvivors.Framework.Phaser.PhaserSprite)+10]");
														bool flag7 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rax_v119 (VampireSurvivors.Framework.Phaser.PhaserSprite)+10]");
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
														Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														bool flag8 = (object)transform3 == null;
														bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
														Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value2));
														Transform transform4 = phaserSprite8.transform;
														bool flag10 = (object)transform4 == null;
														transform4.localEulerAngles = (Vector3)(&num15);
														obj5++;
														flag11 = (nint)obj5 < 180;
														maxRadius = num;
													}
													while (flag11);
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

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02b0: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_008a: Expected O, but got Ref
		//IL_0119: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_0196: Expected O, but got I
		//IL_0216: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_02e0: Expected O, but got I4
		//IL_01d2: Expected O, but got I
		//IL_0208: Expected O, but got I4
		//IL_024c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float radius = _displaySpritePxSize * 0.5f;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		frameIndex = 0;
		_isActivated = false;
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		Transform transform = _sprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		ArcadeSprite arcadeSprite3 = setDepth(2000);
		_isCullable = false;
		_canUpdate = false;
		_canFire = false;
		ArcadeSprite arcadeSprite4 = setVisible(visible: false);
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _displaySprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _displaySprite.setBlendMode(BlendMode.Normal);
		float? weapon2 = (float?)_weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_02b9;
		}
		nint num = (nint)typeof(TP_Dominus4_Weapon);
		object obj2 = weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus4_Weapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r9_v10+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus4_Weapon>)+130]");
		object obj5;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r9_v10+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v35+FFFFFFF8+v330 @ rax_v30*8]");
			if (0 == (nint)typeof(TP_Dominus4_Weapon))
			{
				obj5 = 1;
				goto IL_02c8;
			}
		}
		obj5 = 0;
		goto IL_02c8;
		IL_02c8:
		bool flag = obj5 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_02b9;
		IL_02b9:
		_trueWeapon = (TP_Dominus4_Weapon)trueWeapon;
		ShowDracula();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -1000f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Haha, soundConfig, 1000f, 1, time);
	}

	public override void InternalUpdate()
	{
		//IL_00c2: Expected O, but got I4
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		if (!_canUpdate)
		{
			return;
		}
		if (_canFire && (object)_trueWeapon != null)
		{
			_trueWeapon.FireInvisibleProjectiles();
		}
		bool flag = frameIndex == 0;
		if (!flag)
		{
			object obj = frameIndex - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
						Sprite sprite = default(Sprite);
						PhaserSprite phaserSprite = _displaySprite.setFrame(sprite);
						DisplayBlackScreen();
						goto IL_01a4;
					}
					object obj3 = "TP_VFX_Neutron04";
				}
				else
				{
					object obj3 = "TP_VFX_Neutron03";
				}
			}
			else
			{
				object obj3 = "TP_VFX_Neutron02";
			}
		}
		else
		{
			object obj3 = "TP_VFX_Neutron01";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite2 = default(Sprite);
		PhaserSprite phaserSprite2 = _displaySprite.setFrame(sprite2);
		goto IL_01a4;
		IL_01a4:
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (!((frameTime = num + frameTime) < 32f))
		{
			int num2 = frameIndex + 1;
			frameIndex = num2;
			frameTime = 0f;
		}
	}

	private void ShowDracula()
	{
		//IL_00f2: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_01e6: Expected O, but got I4
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			if ((object)_displaySprite != null)
			{
				object obj = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				tweenConfig.duration = 150f;
				tweenConfig.scale = (float?)(object)1;
				tweenConfig.delay = 1000f;
				tweenConfig.alpha = (float?)(object)1;
				TweenCallback onStart = delegate
				{
					//IL_0031: Expected O, but got I4
					//IL_0068: Expected O, but got I4
					PhaserSprite phaserSprite5 = _displaySprite.setVisible(visible: true);
					PhaserSprite phaserSprite6 = phaserSprite5.setScale(4f, (float?)(object)0);
					PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0.35f);
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 1f;
					soundConfig.Detune = 500f;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_DarkInferno, soundConfig, 1000f, 1, time);
				};
				tweenConfig.onStart = onStart;
				TweenCallback onComplete = delegate
				{
					_canUpdate = true;
				};
				tweenConfig.onComplete = onComplete;
				MultiTargetTween tween = Tweens.Add(tweenConfig);
				_tween2 = tween;
				if ((object)_draculaAnimSprite != null)
				{
					PhaserSprite phaserSprite = _draculaAnimSprite.setAlpha(1f);
					if ((object)_draculaAnimSprite != null)
					{
						PhaserSprite phaserSprite2 = _draculaAnimSprite.setScale(1f, (float?)(object)0);
						if ((object)_draculaAnimSprite != null)
						{
							PhaserSprite phaserSprite3 = _draculaAnimSprite.setVisible(visible: true);
							if ((object)_draculaAnimSprite != null)
							{
								Transform transform = _draculaAnimSprite.transform;
								Transform transform2 = base.transform;
								if ((object)transform2 != null)
								{
									bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
									bool flag2 = (object)transform == null;
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
									PhaserSprite draculaAnimSprite = _draculaAnimSprite;
									bool flag4 = (object)_draculaAnimSprite == null;
									bool flag5 = (object)draculaAnimSprite._spriteAnimation == null;
									draculaAnimSprite._spriteAnimation.SetAnimation("idle");
									bool flag6 = (object)_draculaAnimSprite == null;
									PhaserSprite phaserSprite4 = _draculaAnimSprite.setDepth(6000);
									Weapon weapon = _weapon;
									bool flag7 = (object)_weapon == null;
									VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
									bool flag8 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
									characterController._hasForcedSortingOrder = true;
									characterController._forcedSortingOrder = 10000;
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

	private void FadeOutDracula()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_draculaAnimSprite != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween3 = tween;
	}

	private void DisplayBlackScreen()
	{
		//IL_00e5: Expected I, but got O
		//IL_0149: Expected O, but got I4
		if (_isActivated)
		{
			return;
		}
		BaseBody baseBody = body;
		_isActivated = true;
		baseBody._enable = true;
		_canFire = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		if (!(renderer.width > renderer2.height) || _tween1 != null)
		{
			_tween1.Kill();
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
		tweenConfig.duration = 1650f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onUpdate = delegate
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			base.position = float5;
		};
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
		Action onComplete2 = delegate
		{
			//IL_0013: Expected O, but got I4
			DisplayRedCircle();
			DisplayRays();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.7f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_UnionDominus, soundConfig, 1000f, 1, time);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.82500005f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void DisplayRedCircle()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_00f1: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_01f8: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num = renderer2.height;
		if (!(renderer2.height > renderer.width))
		{
			object obj = renderer.width & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_0286;
			}
		}
		num = renderer.width;
		goto IL_0286;
		IL_0286:
		float num2 = num * 0.95f;
		float num3 = num2 / 2.56f;
		PhaserSprite phaserSprite = _redCircleSprite.setAlpha(1f);
		float xScale = num3 * 0.1f;
		PhaserSprite phaserSprite2 = _redCircleSprite.setScale(xScale, (float?)(object)0);
		PhaserSprite phaserSprite3 = _redCircleSprite.setVisible(visible: true);
		if (_circleTween != null)
		{
			_circleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_redCircleSprite != null)
		{
			nint num4 = (nint)array;
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
		tweenConfig.duration = 960f;
		tweenConfig.ease = Ease.OutQuint;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onUpdate = delegate
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			base.position = float5;
		};
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00c2: Expected O, but got I4
			if (_circleTween2 != null)
			{
				_circleTween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_redCircleSprite != null)
			{
				nint num5 = (nint)array2;
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
			tweenConfig2.duration = 200f;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				PhaserSprite phaserSprite4 = _redCircleSprite.setVisible(visible: false);
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween circleTween2 = Tweens.Add(tweenConfig2);
			_circleTween2 = circleTween2;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween circleTween = Tweens.Add(tweenConfig);
		_circleTween = circleTween;
	}

	private unsafe void DisplayRays()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_023f: Expected I, but got O
		//IL_0255: Expected O, but got I
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0093: Expected O, but got I4
		//IL_01e1: Expected I, but got O
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0289: Expected O, but got I4
		//IL_02a0: Expected I, but got I8
		//IL_01bd: Expected I, but got I8
		List<PhaserSprite> list = raySprites;
		object obj = 0;
		object obj2 = 0;
		List<PhaserSprite> list2 = raySprites;
		while (true)
		{
			if ((nint)obj2 < list._size)
			{
				if ((nint)obj >= list2._size)
				{
					break;
				}
				PhaserSprite[] items = list2._items;
				PhaserSprite phaserSprite = items[obj].setVisible(visible: true);
				PhaserSprite phaserSprite2 = items[obj].setScale(0.1f, (float?)(object)0);
				PhaserSprite phaserSprite3 = items[obj].setAlpha(1f);
				list2 = raySprites;
				obj++;
				obj2 = obj;
				list = raySprites;
				continue;
			}
			TweenConfig tweenConfig = new TweenConfig();
			PhaserSprite[] targets = raySprites.ToArray();
			tweenConfig.targets = targets;
			tweenConfig.ease = Ease.OutQuint;
			tweenConfig.duration = 1440f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback tweenCallback = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r10_v1 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(TP_Dominus4_Projectile._003CDisplayRays_003Eb__27_0);
			((Delegate)tweenCallback).m_target = this;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r10_v1 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r10_v1 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_0280;
				}
			}
			num2 = ((Delegate)tweenCallback).method_ptr;
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			goto IL_0280;
			IL_0280:
			object obj5 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			tweenConfig.onComplete = tweenCallback;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void DisplayExplosions()
	{
		//IL_00d1: Expected O, but got I4
		//IL_00da: Expected O, but got I4
		//IL_00e3: Expected O, but got I4
		//IL_0719: Expected O, but got I
		//IL_073c: Expected O, but got I
		//IL_076a: Expected F4, but got I
		//IL_0aed: Expected I, but got O
		//IL_0b03: Expected O, but got I
		//IL_0b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b11: Expected O, but got Unknown
		//IL_0821: Expected I, but got O
		//IL_0b37: Expected O, but got I4
		//IL_0b4e: Expected I, but got I8
		//IL_0b78: Expected I, but got O
		//IL_0b8e: Expected O, but got I
		//IL_0b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9c: Expected O, but got Unknown
		//IL_080a: Expected I, but got I8
		//IL_08f4: Expected I, but got O
		//IL_0bd0: Expected I, but got I8
		//IL_08c7: Expected I, but got I8
		//IL_01da: Expected O, but got I
		//IL_0210: Expected O, but got I
		//IL_03d6: Expected O, but got I4
		//IL_0a9a: Expected O, but got F4
		//IL_03e8: Invalid comparison between O and F4
		//IL_0407: Invalid comparison between F4 and I4
		//IL_0499: Expected I, but got O
		//IL_050c: Expected O, but got I4
		//IL_0585: Expected O, but got I4
		//IL_05fe: Expected O, but got I4
		//IL_0635: Expected O, but got I4
		//IL_064f: Expected F4, but got O
		//IL_066c: Expected O, but got I4
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Expected O, but got Unknown
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_0164->IL0929: Incompatible stack heights: 1 vs 0
		//IL_0181->IL0929: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL0929: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0929: Incompatible stack heights: 1 vs 0
		//IL_022c->IL0929: Incompatible stack heights: 1 vs 0
		//IL_0c0a->IL0929: Incompatible stack heights: 2 vs 0
		//IL_0272->IL0929: Incompatible stack heights: 2 vs 0
		//IL_02cf->IL0929: Incompatible stack heights: 2 vs 0
		//IL_0a8c->IL0929: Incompatible stack heights: 5 vs 0
		//IL_0329->IL0929: Incompatible stack heights: 5 vs 0
		//IL_034b->IL0929: Incompatible stack heights: 5 vs 0
		//IL_0380->IL0929: Incompatible stack heights: 5 vs 0
		//IL_03b9->IL0929: Incompatible stack heights: 5 vs 0
		//IL_0ab7->IL0929: Incompatible stack heights: 5 vs 0
		//IL_046a->IL0929: Incompatible stack heights: 5 vs 0
		//IL_04de->IL0929: Incompatible stack heights: 5 vs 0
		//IL_04bc->IL04bc: Incompatible stack heights: 6 vs 5
		//IL_0530->IL0929: Incompatible stack heights: 5 vs 0
		//IL_0552->IL0929: Incompatible stack heights: 5 vs 0
		//IL_05a9->IL0929: Incompatible stack heights: 5 vs 0
		//IL_05cb->IL0929: Incompatible stack heights: 5 vs 0
		//IL_06e4->IL0929: Incompatible stack heights: 5 vs 0
		//IL_0704->IL0abc: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass28_0 obj = new _003C_003Ec__DisplayClass28_0();
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
					{
						List<PhaserSprite> list = explosionSprites;
						if (explosionSprites != null)
						{
							float? num = (float?)(object)0;
							float? num2 = (float?)(object)0;
							float? num3 = (float?)(object)0;
							Vector3 value = default(Vector3);
							object obj3 = default(object);
							object obj4 = default(object);
							while (true)
							{
								if ((nint)num3 < list._size)
								{
									_003C_003Ec__DisplayClass28_1 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass28_1();
									List<PhaserSprite> list2 = explosionSprites;
									if (explosionSprites == null)
									{
										break;
									}
									bool flag = (nint)num2 >= list2._size;
									PhaserSprite[] items = list2._items;
									if (list2._items == null || CS_0024_003C_003E8__locals17 == null)
									{
										break;
									}
									CS_0024_003C_003E8__locals17.explo = items[(object)num2];
									ArcadeSprite weapon = (ArcadeSprite)(object)_weapon;
									if ((object)_weapon == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdi_v17 (ArcadeSprite)+58]");
									ArcadeSprite arcadeSprite = (ArcadeSprite)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdi_v17 (ArcadeSprite)+58]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdi_v17 (ArcadeSprite)+58]");
									Transform cachedTrans = ((ArcadeSprite)0).CachedTrans;
									if ((object)cachedTrans == null)
									{
										break;
									}
									bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
									float2 ret;
									Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
									if (arcadeSprite.body != null)
									{
										BaseBody baseBody = arcadeSprite.body;
										ArcadeTransform arcadeTransform = baseBody._transform;
										if (baseBody._transform == null)
										{
											break;
										}
										arcadeTransform.position = ret;
									}
									if ((object)CS_0024_003C_003E8__locals17.explo == null)
									{
										break;
									}
									Transform transform = CS_0024_003C_003E8__locals17.explo.transform;
									Transform transform2 = CS_0024_003C_003E8__locals17.explo.transform;
									if ((object)transform2 == null)
									{
										break;
									}
									bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
									bool flag4 = (object)transform == null;
									bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
									if ((object)CS_0024_003C_003E8__locals17.explo == null)
									{
										break;
									}
									PhaserSprite phaserSprite = CS_0024_003C_003E8__locals17.explo.setVisible(visible: true);
									PhaserSprite explo = CS_0024_003C_003E8__locals17.explo;
									if ((object)CS_0024_003C_003E8__locals17.explo == null || (object)explo._spriteAnimation == null)
									{
										break;
									}
									explo._spriteAnimation.SetAnimation("bang");
									if ((object)CS_0024_003C_003E8__locals17.explo == null)
									{
										break;
									}
									PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals17.explo.setAlpha(0.95f);
									if ((object)CS_0024_003C_003E8__locals17.explo == null)
									{
										break;
									}
									PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals17.explo.setScale(0.5f, (float?)(object)0);
									object obj2 = UnityEngine.Random.value;
									if ((object)CS_0024_003C_003E8__locals17.explo == null)
									{
										break;
									}
									bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
									float num4 = (float)obj3 - 0.5f;
									bool flag7 = num4 == 0f;
									BlendMode blendMode = ((flag6 | flag7) ? BlendMode.Add : BlendMode.Normal);
									PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals17.explo.setBlendMode(blendMode);
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array == null)
									{
										break;
									}
									if ((object)CS_0024_003C_003E8__locals17.explo != null)
									{
										nint num5 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										bool flag8 = obj4 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig == null)
									{
										break;
									}
									tweenConfig.targets = array;
									float value2 = UnityEngine.Random.value;
									tweenConfig.scale = (float?)(object)1;
									Weapon weapon2 = _weapon;
									if ((object)_weapon == null || (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
									{
										break;
									}
									float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
									float value3 = UnityEngine.Random.value;
									tweenConfig.x = (float?)(object)1;
									Weapon weapon3 = _weapon;
									if ((object)_weapon == null || (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null)
									{
										break;
									}
									float2 float6 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
									float value4 = UnityEngine.Random.value;
									tweenConfig.y = (float?)(object)1;
									float value5 = UnityEngine.Random.value;
									float num6 = value5 * 1000f;
									float duration = num6 + 650f;
									tweenConfig.alpha = (float?)(object)1;
									tweenConfig.duration = duration;
									tweenConfig.delay = (float)num;
									float value6 = UnityEngine.Random.value;
									tweenConfig.angle = (float?)(object)1;
									TweenCallback onComplete = delegate
									{
										PhaserSprite phaserSprite5 = CS_0024_003C_003E8__locals17.explo.setAlpha(0f);
									};
									tweenConfig.onComplete = onComplete;
									MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
									list = explosionSprites;
									num2 = (float?)(object)((_003F?)num2 + 1);
									Transform transform3 = (Transform)((_003F?)num + 10);
									if (explosionSprites == null)
									{
										break;
									}
									s_scene = null;
									num = (float?)transform3;
									num3 = num2;
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A122F0]");
								obj.color1 = (Color)0;
								obj.colorTime = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12040]");
								obj.color2 = (Color)0;
								DOGetter<float> getter = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
								DOSetter<float> dOSetter = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12040]");
								((_003C_003Ec__DisplayClass28_0)(object)dOSetter)._003CDisplayExplosions_003Eb__1(0f);
								TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 1.5f);
								TweenCallback tweenCallback = null;
								nint num7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1553 @ r10_v1 (Il2CppMethodInfo)+8]");
								((Delegate)tweenCallback).method_ptr = (IntPtr)0;
								((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass28_0._003CDisplayExplosions_003Eb__2);
								((Delegate)tweenCallback).m_target = obj;
								((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1553 @ r10_v1 (Il2CppMethodInfo)+4C]");
								object obj5 = (nint)0 >> 4;
								object obj6 = obj5 & 1;
								nint num8;
								if (obj6 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1553 @ r10_v1 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num8 = unchecked((nint)6447293664L);
										goto IL_0b2e;
									}
								}
								((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
								num8 = ((Delegate)tweenCallback).method_ptr;
								goto IL_0b2e;
								IL_0bb9:
								TweenCallback tweenCallback2;
								((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1441 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								return;
								IL_0b2e:
								object obj7 = 24;
								((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1441 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								tweenCallback2 = null;
								nint num9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1345 @ r10_v2 (Il2CppMethodInfo)+8]");
								((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
								((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass28_0._003CDisplayExplosions_003Eb__3);
								((Delegate)tweenCallback2).m_target = obj;
								((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1345 @ r10_v2 (Il2CppMethodInfo)+4C]");
								object obj8 = (nint)0 >> 4;
								object obj9 = obj8 & 1;
								nint num10;
								if (obj9 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1345 @ r10_v2 (Il2CppMethodInfo)+52]");
									bool flag9 = (nint)0 == 0;
									num10 = unchecked((nint)6447293664L);
									if (flag9)
									{
										goto IL_0bb9;
									}
								}
								num10 = ((Delegate)tweenCallback2).method_ptr;
								((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
								goto IL_0bb9;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void HideBlackScreen()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		_canFire = false;
		if (_tween4 != null)
		{
			_tween4.Kill();
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
		tweenConfig.duration = 1650f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onUpdate = delegate
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			base.position = float5;
		};
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			characterController._hasForcedSortingOrder = false;
			characterController._forcedSortingOrder = 0;
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween4 = tween;
	}

	public override void Despawn()
	{
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		if (_circleTween != null)
		{
			_circleTween.Kill();
		}
		if (_circleTween2 != null)
		{
			_circleTween2.Kill();
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		base.Despawn();
	}

	private void _003CShowDracula_003Eb__23_0()
	{
		//IL_0031: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = phaserSprite.setScale(4f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.35f);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = 500f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_DarkInferno, soundConfig, 1000f, 1, time);
	}

	private void _003CShowDracula_003Eb__23_1()
	{
		_canUpdate = true;
	}

	private void _003CDisplayBlackScreen_003Eb__25_1()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	private void _003CDisplayBlackScreen_003Eb__25_2()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CDisplayBlackScreen_003Eb__25_0()
	{
		//IL_0013: Expected O, but got I4
		DisplayRedCircle();
		DisplayRays();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.7f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_UnionDominus, soundConfig, 1000f, 1, time);
	}

	private void _003CDisplayRedCircle_003Eb__26_0()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	private void _003CDisplayRedCircle_003Eb__26_1()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_circleTween2 != null)
		{
			_circleTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_redCircleSprite != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _redCircleSprite.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween circleTween = Tweens.Add(tweenConfig);
		_circleTween2 = circleTween;
	}

	private void _003CDisplayRedCircle_003Eb__26_2()
	{
		PhaserSprite phaserSprite = _redCircleSprite.setVisible(visible: false);
	}

	private void _003CDisplayRays_003Eb__27_0()
	{
		//IL_0047: Expected O, but got I4
		DisplayExplosions();
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = raySprites.ToArray();
		tweenConfig.targets = targets;
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_000e: Expected O, but got I4
			//IL_0017: Expected O, but got I4
			//IL_0093: Expected O, but got I4
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			List<PhaserSprite> list = raySprites;
			object obj = 0;
			object obj2 = 0;
			List<PhaserSprite> list2 = raySprites;
			while (true)
			{
				if ((nint)obj2 >= list._size)
				{
					return;
				}
				if ((nint)obj >= list2._size)
				{
					break;
				}
				PhaserSprite[] items = list2._items;
				PhaserSprite phaserSprite = items[obj].setVisible(visible: false);
				PhaserSprite phaserSprite2 = items[obj].setScale(0f, (float?)(object)0);
				list2 = raySprites;
				obj++;
				obj2 = obj;
				list = raySprites;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void _003CDisplayRays_003Eb__27_1()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		List<PhaserSprite> list = raySprites;
		object obj = 0;
		object obj2 = 0;
		List<PhaserSprite> list2 = raySprites;
		while (true)
		{
			if ((nint)obj2 < list._size)
			{
				if ((nint)obj >= list2._size)
				{
					break;
				}
				PhaserSprite[] items = list2._items;
				PhaserSprite phaserSprite = items[obj].setVisible(visible: false);
				PhaserSprite phaserSprite2 = items[obj].setScale(0f, (float?)(object)0);
				list2 = raySprites;
				obj++;
				obj2 = obj;
				list = raySprites;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CHideBlackScreen_003Eb__29_0()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	private void _003CHideBlackScreen_003Eb__29_1()
	{
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		characterController._hasForcedSortingOrder = false;
		characterController._forcedSortingOrder = 0;
		Despawn();
	}
}
