using System;
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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Dominus0_Projectile : Projectile
{
	private PhaserSprite _displaySprite;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _scale2Tween;

	private MultiTargetTween _scale3Tween;

	private MultiTargetTween _scale4Tween;

	private Timer hitBoxTimer;

	private TP_Dominus2_Weapon _trueWeapon;

	private bool inverted;

	private string mainFrameName = "TP_VFX_Hatred12";

	private string topFrameName = "TP_VFX_Hatred13";

	protected override void Awake()
	{
		//IL_00fe: Expected O, but got I4
		//IL_01ff->IL01ff: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Hatred12", "ThosePeople");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				Vector2 pos = default(Vector2);
				while (true)
				{
					GameObject gameObject = base.gameObject;
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Hatred13");
					if ((object)phaserSprite == null)
					{
						break;
					}
					PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
					if ((object)phaserSprite2 == null)
					{
						break;
					}
					PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
					if ((object)phaserSprite3 == null)
					{
						break;
					}
					GameObject gameObject2 = phaserSprite3.gameObject;
					if ((object)gameObject2 == null)
					{
						break;
					}
					((UnityEngine.Object)gameObject2).SetName("TP_Dominus0_BeamTop");
					_displaySprite = phaserSprite3;
					if ((object)_displaySprite == null)
					{
						break;
					}
					Transform transform = _displaySprite.transform;
					if ((object)transform == null)
					{
						break;
					}
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0929: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_025d: Expected O, but got I4
		//IL_09a2: Expected O, but got I4
		//IL_07e2: Expected O, but got I4
		//IL_07fd: Expected I, but got O
		//IL_08a9: Expected I4, but got F4
		//IL_0388->IL08bd: Incompatible stack heights: 1 vs 0
		//IL_03da->IL08bd: Incompatible stack heights: 2 vs 0
		//IL_0487->IL08bd: Incompatible stack heights: 2 vs 0
		//IL_04f8->IL08bd: Incompatible stack heights: 2 vs 0
		//IL_04d6->IL04d6: Incompatible stack heights: 3 vs 2
		//IL_0598->IL08bd: Incompatible stack heights: 2 vs 0
		//IL_05ea->IL08bd: Incompatible stack heights: 3 vs 0
		//IL_0612->IL08bd: Incompatible stack heights: 3 vs 0
		//IL_09f6->IL08bd: Incompatible stack heights: 3 vs 0
		//IL_0646->IL08bd: Incompatible stack heights: 3 vs 0
		//IL_06f1->IL08bd: Incompatible stack heights: 3 vs 0
		//IL_07a1->IL08bd: Incompatible stack heights: 4 vs 0
		//IL_077f->IL077f: Incompatible stack heights: 5 vs 4
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0902;
		}
		nint num = (nint)typeof(TP_Dominus2_Weapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v110 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v2 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v110 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v2 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v197+FFFFFFF8+v72 @ rax_v192*8]");
			if (0 == (nint)typeof(TP_Dominus2_Weapon))
			{
				obj3 = 1;
				goto IL_0911;
			}
		}
		obj3 = 0;
		goto IL_0911;
		IL_0911:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0902;
		IL_0902:
		_trueWeapon = (TP_Dominus2_Weapon)trueWeapon;
		TP_Dominus2_Weapon trueWeapon2 = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			inverted = trueWeapon2._003CInverted_003Ek__BackingField;
			bool flag2 = (byte)(~(trueWeapon2._003CInverted_003Ek__BackingField ? 1u : 0u)) != 0;
			string text = "TP_VFX_Hatred12";
			if (!flag2)
			{
				text = "TP_VFX_HatredInv12";
			}
			mainFrameName = text;
			bool flag3 = !inverted;
			string text2 = "TP_VFX_Hatred13";
			if (!flag3)
			{
				text2 = "TP_VFX_HatredInv13";
			}
			topFrameName = text2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite sprite = default(Sprite);
			ArcadeSprite arcadeSprite = setFrame(sprite);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			if ((object)_displaySprite != null)
			{
				Sprite sprite2 = default(Sprite);
				PhaserSprite phaserSprite = _displaySprite.setFrame(sprite2);
				ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
				_isCullable = false;
				if ((object)_renderer != null)
				{
					_renderer.enabled = true;
					ArcadeSprite arcadeSprite3 = setScale(1f, (float?)(object)0);
					ArcadeSprite arcadeSprite4 = setAlpha(0.65f);
					if ((object)_weapon != null)
					{
						float num3 = _weapon.PArea();
						if ((object)_displaySprite != null)
						{
							PhaserSprite phaserSprite2 = _displaySprite.setScale(1f, (float?)(object)0);
							if ((object)_displaySprite != null)
							{
								PhaserSprite phaserSprite3 = _displaySprite.setAlpha(0.65f);
								if ((object)_displaySprite != null)
								{
									PhaserSprite phaserSprite4 = _displaySprite.setVisible(visible: true);
									if ((object)_displaySprite != null)
									{
										Transform transform = _displaySprite.transform;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1186 @ rax_v50 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1186 @ rax_v50 (UnityEngine.Transform)+10]");
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected((IntPtr)0, ref value);
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Volume = (float?)(object)1,
											Rate = 1f
										};
										float detune = (float)_indexInWeapon * 100f;
										soundConfig.Detune = detune;
										float num4 = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 150f, 3, num4);
										if (_scaleTween != null)
										{
											_scaleTween.Kill();
										}
										TweenConfig tweenConfig = new TweenConfig();
										object[] array = new object[1];
										if (array != null)
										{
											object obj4 = array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj5 = default(object);
											bool flag5 = obj5 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig != null)
											{
												_ = 1128792064;
												object obj7 = default(object);
												object obj6 = obj7 + obj7;
												_ = 1;
												MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
												_scaleTween = scaleTween;
												if (_scale2Tween != null)
												{
													_scale2Tween.Kill();
												}
												TweenConfig tweenConfig2 = new TweenConfig();
												object[] array2 = new object[1];
												if (array2 != null)
												{
													if ((object)_displaySprite != null)
													{
														object obj8 = array2;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj9 = default(object);
														bool flag6 = obj9 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig2 != null)
													{
														_ = 1128792064;
														_ = 1;
														MultiTargetTween scale2Tween = Tweens.Add(tweenConfig2);
														_scale2Tween = scale2Tween;
														if (_scale3Tween != null)
														{
															_scale3Tween.Kill();
														}
														TweenConfig tweenConfig3 = new TweenConfig();
														object[] array3 = new object[1];
														if (array3 != null)
														{
															object obj10 = array3;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj11 = default(object);
															bool flag7 = obj11 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig3 != null && (object)GM.Core != null)
															{
																PhaserScene s_scene = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null)
																{
																	PhaserScene.Renderer renderer = s_scene._renderer;
																	if (s_scene._renderer != null)
																	{
																		float num5 = renderer.height * 100f;
																		_ = 1133903872;
																		_ = 1;
																		MultiTargetTween scale3Tween = Tweens.Add(tweenConfig3);
																		_scale3Tween = scale3Tween;
																		if (_scale4Tween != null)
																		{
																			_scale4Tween.Kill();
																		}
																		TweenConfig tweenConfig4 = new TweenConfig();
																		object[] array4 = new object[2];
																		if (array4 != null)
																		{
																			int value2 = ((int*)(&array4))->m_value;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj12 = default(object);
																			bool flag8 = obj12 == null;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			if ((object)_displaySprite != null)
																			{
																				int value3 = ((int*)(&array4))->m_value;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj13 = default(object);
																				bool flag9 = obj13 == null;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			if (tweenConfig4 != null)
																			{
																				tweenConfig4.targets = array4;
																				tweenConfig4.duration = 100f;
																				tweenConfig4.delay = 500f;
																				tweenConfig4.scaleX = (float?)(object)1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1996 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus0_Projectile>)+370]");
																				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
																				nint num6 = (nint)this;
																				tweenConfig4.onComplete = onComplete;
																				MultiTargetTween scale4Tween = Tweens.Add(tweenConfig4);
																				_scale4Tween = scale4Tween;
																				if (hitBoxTimer != null)
																				{
																					hitBoxTimer.Cancel();
																				}
																				Action onComplete2 = delegate
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																				};
																				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																				int repeat = default(int);
																				TimerType type = default(TimerType);
																				Timer timer = Timers.Register(0.05f, onComplete2, null, isLooped: false, (byte)(int)num4 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																				hitBoxTimer = timer;
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

	private void LateUpdate()
	{
		//IL_006d->IL0087: Incompatible stack heights: 1 vs 0
		//IL_0169->IL0087: Incompatible stack heights: 2 vs 0
		if ((object)_displaySprite != null)
		{
			Transform transform = _displaySprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float2 float5 = base.position;
				float2 float6 = base.position;
				object obj = default(object);
				float num = (float)obj * 5f;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					float num2 = (float)obj + num;
					float num3 = num2 * 0.01f;
					object obj2 = default(object);
					float num4 = num3 + (float)obj2;
					if ((object)_displaySprite != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		if (hitBoxTimer != null)
		{
			hitBoxTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_scale2Tween != null)
		{
			_scale2Tween.Kill();
		}
		if (_scale3Tween != null)
		{
			_scale3Tween.Kill();
		}
		if (_scale4Tween != null)
		{
			_scale4Tween.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
