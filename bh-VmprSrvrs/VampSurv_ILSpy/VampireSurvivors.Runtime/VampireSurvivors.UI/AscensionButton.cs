using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coffee.UIExtensions;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class AscensionButton : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public UISpriteAnimation anim;

		public GameObject g;

		public Image i;

		public AscensionButton _003C_003E4__this;

		public TweenCallback _003C_003E9__2;

		public TweenCallback _003C_003E9__3;

		internal unsafe void _003CCreateAngelVFX_003Eb__1()
		{
			//IL_0212: Expected O, but got Ref
			//IL_0142: Expected O, but got Ref
			UISpriteAnimation uISpriteAnimation = anim;
			uISpriteAnimation._003CIsPaused_003Ek__BackingField = true;
			Transform transform = g.transform;
			Vector3 value = default(Vector3);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&value), 0.2f);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					UnityEngine.Object.Destroy(g, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Transform transform2 = g.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveY(transform2, 600f, 0.2f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(i, 0f, 0.2f);
			AscensionButton ascensionButton = _003C_003E4__this;
			Transform transform3 = ascensionButton._VFXBeam.transform;
			bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			AscensionButton ascensionButton2 = _003C_003E4__this;
			Transform transform4 = ascensionButton2._VFXBeam.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(transform4, (Vector3)(&obj), 0.1f);
			TweenCallback tweenCallback2 = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				tweenCallback2 = (_003C_003E9__3 = delegate
				{
					//IL_0033: Expected O, but got Ref
					AscensionButton ascensionButton3 = _003C_003E4__this;
					Transform transform5 = ascensionButton3._VFXBeam.transform;
					object obj2 = default(object);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(transform5, (Vector3)(&obj2), 0.1f);
				});
			}
			if (tweenerCore4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CCreateAngelVFX_003Eb__2()
		{
			UnityEngine.Object.Destroy(g, 0f);
		}

		internal unsafe void _003CCreateAngelVFX_003Eb__3()
		{
			//IL_0033: Expected O, but got Ref
			AscensionButton ascensionButton = _003C_003E4__this;
			Transform transform = ascensionButton._VFXBeam.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.1f);
		}

		internal void _003CCreateAngelVFX_003Eb__0()
		{
			AscensionButton ascensionButton = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)ascensionButton._VFXsPFX_ring_64 != null)
			{
				Transform transform = ascensionButton._VFXsPFX_ring_64.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	private UIParticle _StarsBurstParticles;

	private Transform _VFXTransform;

	private Image _VFXBeam;

	private Image _VFXsPFX_ring_64;

	private bool _ForceShowAscensionConfirmation;

	private AdventureManager _adventureManager;

	private AdventureType _adventure;

	private void Construct(AdventureManager adventure)
	{
		_adventureManager = adventure;
	}

	private void Start()
	{
		Button component = GetComponent<Button>();
		UnityAction call = TryAscend;
		component.m_OnClick.AddListener(call);
	}

	public void SetAdventure(AdventureType t)
	{
		_adventure = t;
	}

	public void TryAscend()
	{
		//IL_005a: Expected I4, but got O
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			AdventureManager adventureManager = _adventureManager;
			_adventure = adventureManager.CurrentAdventure;
		}
		AdventureManager adventureManager2 = _adventureManager;
		Action<bool> action = null;
		((AscensionButton)(object)action).OnAscend((byte)(int)this != 0);
		Delegate obj = Delegate.Combine(adventureManager2._003COnAdventureAscended_003Ek__BackingField, action);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager2._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
		bool flag = _adventureManager.AscendAdventure(_adventure, _ForceShowAscensionConfirmation);
	}

	private void OnAscend(bool result)
	{
		AdventureManager adventureManager = _adventureManager;
		Action<bool> value = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002FD0");
		Delegate obj = Delegate.Remove(adventureManager._003COnAdventureAscended_003Ek__BackingField, value);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
		if (result)
		{
			Canvas canvas = UIHelper.Canvas;
			canvas.renderMode = RenderMode.WorldSpace;
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake(1);
			Transform transform = _StarsBurstParticles.transform;
			Transform transform2 = base.transform;
			Transform parent = transform2.parent;
			Transform parent2 = parent.parent;
			transform.parent = parent2;
			_StarsBurstParticles.Play();
			CreateAngelVFX();
		}
	}

	private unsafe void CreateAngelVFX()
	{
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_0808: Expected O, but got Unknown
		//IL_00c0: Expected I, but got O
		//IL_00d7: Expected I, but got O
		//IL_0151: Expected I, but got O
		//IL_054d: Expected O, but got I4
		//IL_057c: Expected F4, but got I4
		//IL_059c: Expected O, but got I4
		//IL_05e2: Expected F4, but got I4
		//IL_0602: Expected O, but got I4
		//IL_0648: Expected F4, but got I4
		//IL_0668: Expected O, but got I4
		//IL_06ae: Expected F4, but got I4
		//IL_06ce: Expected O, but got I4
		//IL_0706: Expected F4, but got I4
		//IL_074e: Expected O, but got Ref
		//IL_0890->IL03e5: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals50 = new _003C_003Ec__DisplayClass12_0();
		if (CS_0024_003C_003E8__locals50 != null)
		{
			CS_0024_003C_003E8__locals50._003C_003E4__this = this;
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			CS_0024_003C_003E8__locals50.g = gameObject;
			if ((object)CS_0024_003C_003E8__locals50.g != null)
			{
				Image i = CS_0024_003C_003E8__locals50.g.AddComponent<Image>();
				CS_0024_003C_003E8__locals50.i = i;
				GameObject i2 = (GameObject)(object)CS_0024_003C_003E8__locals50.i;
				if ((object)CS_0024_003C_003E8__locals50.i != null)
				{
					object obj = CS_0024_003C_003E8__locals50.i + 244;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77350");
					object obj2 = default(object);
					if (obj2 != null)
					{
						nint num = (nint)i2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v936 @ rax_v130 (Il2CppClass<UnityEngine.GameObject>)+2F8] (should have been resolved before IL gen)");
					}
					GameObject i3 = (GameObject)(object)CS_0024_003C_003E8__locals50.i;
					if ((object)CS_0024_003C_003E8__locals50.i != null)
					{
						nint num2 = (nint)i3;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1002 @ r8_v15 (Il2CppClass<UnityEngine.GameObject>)+298] (should have been resolved before IL gen)");
						if ((object)CS_0024_003C_003E8__locals50.i != null)
						{
							Color color = CS_0024_003C_003E8__locals50.i.color;
							if ((object)CS_0024_003C_003E8__locals50.i != null)
							{
								Color color2 = CS_0024_003C_003E8__locals50.i.color;
								nint num3 = (nint)i3;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1081 @ rax_v43 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
								if ((object)CS_0024_003C_003E8__locals50.g != null)
								{
									UISpriteAnimation anim = CS_0024_003C_003E8__locals50.g.AddComponent<UISpriteAnimation>();
									CS_0024_003C_003E8__locals50.anim = anim;
									bool flag = default(bool);
									List<Sprite> animation = SpriteManager.GetAnimation("angel_", 1, 8, "angel", flag);
									UISpriteAnimation anim2 = CS_0024_003C_003E8__locals50.anim;
									if ((object)CS_0024_003C_003E8__locals50.anim != null)
									{
										anim2.sprites = animation;
										UISpriteAnimation anim3 = CS_0024_003C_003E8__locals50.anim;
										if ((object)CS_0024_003C_003E8__locals50.anim != null)
										{
											anim3._ScaleBasedOnSpriteSize = true;
											UISpriteAnimation anim4 = CS_0024_003C_003E8__locals50.anim;
											if ((object)CS_0024_003C_003E8__locals50.anim != null)
											{
												anim4.FPS = 30;
												UISpriteAnimation anim5 = CS_0024_003C_003E8__locals50.anim;
												if ((object)CS_0024_003C_003E8__locals50.anim != null)
												{
													float triggerTimer = 1f / (float)anim5.FPS;
													anim5._triggerTimer = triggerTimer;
													UISpriteAnimation anim6 = CS_0024_003C_003E8__locals50.anim;
													if ((object)CS_0024_003C_003E8__locals50.anim != null)
													{
														Action b = delegate
														{
															//IL_0212: Expected O, but got Ref
															//IL_0142: Expected O, but got Ref
															UISpriteAnimation anim7 = CS_0024_003C_003E8__locals50.anim;
															anim7._003CIsPaused_003Ek__BackingField = true;
															Transform target2 = CS_0024_003C_003E8__locals50.g.transform;
															Vector3 value4 = default(Vector3);
															TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, (Vector3)(&value4), 0.2f);
															TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals50._003C_003E9__2;
															if (CS_0024_003C_003E8__locals50._003C_003E9__2 == null)
															{
																tweenCallback2 = (CS_0024_003C_003E8__locals50._003C_003E9__2 = delegate
																{
																	UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals50.g, 0f);
																});
															}
															if (tweenerCore2 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																if ((nint)0 == 0)
																{
																}
															}
															Transform target3 = CS_0024_003C_003E8__locals50.g.transform;
															TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMoveY(target3, 600f, 0.2f);
															TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(CS_0024_003C_003E8__locals50.i, 0f, 0.2f);
															AscensionButton ascensionButton = CS_0024_003C_003E8__locals50._003C_003E4__this;
															Transform transform5 = ascensionButton._VFXBeam.transform;
															bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
															Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value4);
															AscensionButton ascensionButton2 = CS_0024_003C_003E8__locals50._003C_003E4__this;
															Transform target4 = ascensionButton2._VFXBeam.transform;
															object obj6 = default(object);
															TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target4, (Vector3)(&obj6), 0.1f);
															TweenCallback tweenCallback3 = CS_0024_003C_003E8__locals50._003C_003E9__3;
															if (CS_0024_003C_003E8__locals50._003C_003E9__3 == null)
															{
																tweenCallback3 = (CS_0024_003C_003E8__locals50._003C_003E9__3 = delegate
																{
																	//IL_0033: Expected O, but got Ref
																	AscensionButton ascensionButton3 = CS_0024_003C_003E8__locals50._003C_003E4__this;
																	Transform target5 = ascensionButton3._VFXBeam.transform;
																	object obj7 = default(object);
																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOScale(target5, (Vector3)(&obj7), 0.1f);
																});
															}
															if (tweenerCore5 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																if ((nint)0 == 0)
																{
																}
															}
														};
														Delegate obj3 = Delegate.Combine(anim6.OnComplete, b);
														if ((object)obj3 == null)
														{
															anim6.OnComplete = null;
														}
														else
														{
															bool flag2 = (object)obj3.GetType() != typeof(Action);
															Delegate obj4 = null;
															if (!flag2)
															{
																obj4 = obj3;
															}
															bool flag3 = (object)obj4 == null;
															anim6.OnComplete = (Action)obj4;
															bool flag4 = (object)obj3.GetType() != typeof(Action);
															Delegate obj5 = null;
															if (!flag4)
															{
																obj5 = obj3;
															}
															bool flag5 = (object)obj5 == null;
														}
														Canvas canvas = UIHelper.Canvas;
														if ((object)canvas != null)
														{
															Transform parent = canvas.transform;
															if ((object)_VFXTransform != null)
															{
																_VFXTransform.SetParent(parent, worldPositionStays: true);
																if ((object)CS_0024_003C_003E8__locals50.g != null)
																{
																	Transform transform = CS_0024_003C_003E8__locals50.g.transform;
																	if ((object)transform != null)
																	{
																		transform.parent = _VFXTransform;
																		if ((object)CS_0024_003C_003E8__locals50.g != null)
																		{
																			Transform transform2 = CS_0024_003C_003E8__locals50.g.transform;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1724 @ rax_v64 (UnityEngine.Transform)+10]");
																			bool flag6 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1724 @ rax_v64 (UnityEngine.Transform)+10]");
																			Vector3 value = default(Vector3);
																			Transform.set_localScale_Injected((IntPtr)0, ref value);
																			Transform transform3 = CS_0024_003C_003E8__locals50.g.transform;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v70 (UnityEngine.Transform)+10]");
																			bool flag7 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v70 (UnityEngine.Transform)+10]");
																			Vector3 value2 = default(Vector3);
																			Transform.set_localPosition_Injected((IntPtr)0, ref value2);
																			CS_0024_003C_003E8__locals50.anim.Play();
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLV, new SoundManager.SoundConfig
																			{
																				Volume = (float?)(object)1,
																				Rate = 1f
																			}, 500f, 5, flag ? 1 : 0);
																			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.AutoLV, new SoundManager.SoundConfig
																			{
																				Volume = (float?)(object)1,
																				Rate = 1f,
																				Detune = 250f,
																				Delay = 0.16f
																			}, 500f, 5, flag ? 1 : 0);
																			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.AutoLV, new SoundManager.SoundConfig
																			{
																				Volume = (float?)(object)1,
																				Rate = 1f,
																				Detune = 500f,
																				Delay = 0.32f
																			}, 500f, 5, flag ? 1 : 0);
																			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.AutoLV, new SoundManager.SoundConfig
																			{
																				Volume = (float?)(object)1,
																				Rate = 1f,
																				Detune = 1000f,
																				Delay = 0.48f
																			}, 500f, 5, flag ? 1 : 0);
																			PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.AutoLV, new SoundManager.SoundConfig
																			{
																				Volume = (float?)(object)1,
																				Rate = 1f,
																				Detune = -1000f
																			}, 500f, 5, flag ? 1 : 0);
																			Transform transform4 = _VFXsPFX_ring_64.transform;
																			bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																			Vector3 value3 = default(Vector3);
																			Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value3);
																			Transform target = _VFXsPFX_ring_64.transform;
																			Vector3 vector = default(Vector3);
																			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector), 0.2f);
																			TweenCallback tweenCallback = delegate
																			{
																				AscensionButton ascensionButton = CS_0024_003C_003E8__locals50._003C_003E4__this;
																				if ((object)CS_0024_003C_003E8__locals50._003C_003E4__this != null && (object)ascensionButton._VFXsPFX_ring_64 != null)
																				{
																					Transform transform5 = ascensionButton._VFXsPFX_ring_64.transform;
																					if ((object)transform5 != null)
																					{
																						bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
																						Vector3 value4 = default(Vector3);
																						Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value4);
																						return;
																					}
																				}
																				throw new NullReferenceException();
																			};
																			if (tweenerCore != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1942 @ rax_v93 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																				if ((nint)0 == 0)
																				{
																				}
																			}
																			TestPFX();
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
		throw new NullReferenceException();
	}

	private void TestPFX()
	{
		//IL_0056->IL014f: Incompatible stack heights: 1 vs 0
		//IL_0083->IL014f: Incompatible stack heights: 1 vs 0
		//IL_00be->IL014f: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL014f: Incompatible stack heights: 1 vs 0
		//IL_0112->IL014f: Incompatible stack heights: 1 vs 0
		//IL_013e->IL014f: Incompatible stack heights: 1 vs 0
		Canvas canvas = UIHelper.Canvas;
		if ((object)canvas != null)
		{
			bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
			Canvas.set_renderMode_Injected(((UnityEngine.Object)canvas).m_CachedPtr, RenderMode.WorldSpace);
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			if ((object)instance != null)
			{
				instance.Shake(1);
				if ((object)_StarsBurstParticles != null)
				{
					Transform transform = _StarsBurstParticles.transform;
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						Transform parent = transform2.parent;
						if ((object)parent != null)
						{
							Transform parent2 = parent.parent;
							if ((object)transform != null)
							{
								transform.parent = parent2;
								if ((object)_StarsBurstParticles != null)
								{
									_StarsBurstParticles.Play();
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

	private unsafe void CreateParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f4: Expected O, but got Ref
		//IL_0409: Expected native int or pointer, but got O
		//IL_0423: Expected O, but got I
		//IL_047b: Expected O, but got Ref
		//IL_0494: Expected native int or pointer, but got O
		//IL_04b3: Expected O, but got I
		//IL_04e7: Expected O, but got I4
		//IL_0507: Expected O, but got Ref
		//IL_0521: Expected native int or pointer, but got O
		//IL_08dc: Expected O, but got I
		//IL_0559: Expected O, but got Ref
		//IL_0573: Expected native int or pointer, but got O
		//IL_0916: Expected O, but got I
		//IL_05ab: Expected O, but got Ref
		//IL_05d2: Expected O, but got I
		//IL_05f9: Expected O, but got I
		//IL_0613: Expected native int or pointer, but got O
		//IL_062d: Expected O, but got I
		//IL_0674: Expected O, but got I
		//IL_0970: Expected O, but got I4
		//IL_0ad8: Expected I, but got O
		//IL_0b50: Expected O, but got I
		//IL_0c3c: Expected O, but got Ref
		//IL_0b92: Expected O, but got I
		//IL_0c6c: Expected O, but got Ref
		//IL_0c84: Expected O, but got Ref
		//IL_0c9e: Expected native int or pointer, but got O
		//IL_0cb1: Expected O, but got Ref
		//IL_0ccb: Expected O, but got Ref
		//IL_0cdb: Expected O, but got I
		//IL_0bc8: Expected O, but got Ref
		//IL_0c2d: Expected I, but got O
		//IL_0988->IL089d: Incompatible stack heights: 1 vs 0
		//IL_0aa3->IL089d: Incompatible stack heights: 6 vs 0
		//IL_0839->IL0c2e: Incompatible stack heights: 12 vs 11
		//IL_0866->IL0c5e: Incompatible stack heights: 12 vs 11
		//IL_0893->IL0bba: Incompatible stack heights: 12 vs 11
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"PfxYellow.png");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxRed.png");
					}
					else
					{
						int size2 = list._size + 1;
						list._size = size2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
						}
						else
						{
							int size3 = list._size + 1;
							list._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxColor1.png");
							}
							else
							{
								int size4 = list._size + 1;
								list._size = size4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"PfxColor2.png");
								}
								else
								{
									int size5 = list._size + 1;
									list._size = size5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
									_ = 0;
									Camera main = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBounds(main);
									object obj3 = default(object);
									float max = (float)obj3 * 2f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1089 @ rax_v69 (UnityEngine.Bounds)+10]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
									_ = 0;
									_ = 0;
									ParticleSystem.MinMaxCurve value = new ParticleSystem.MinMaxCurve(1000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-195f, -390f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(2.6f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
									_ = 0;
									_ = 24;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 16777215;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
									particleSystemConfig._tint = (uint?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
									_ = 0;
									_ = 0;
									particleSystemConfig._on = true;
									_ = 1;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									GameObject gameObject = new GameObject();
									GameObject.Internal_CreateGameObject(gameObject, (string)null);
									if ((object)gameObject != null)
									{
										Transform transform = gameObject.transform;
										Canvas canvas = UIHelper.Canvas;
										if ((object)canvas != null)
										{
											Transform parent = canvas.transform;
											if ((object)transform != null)
											{
												transform.SetParent(parent, worldPositionStays: true);
												ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
												Transform transform2 = gameObject.transform;
												Camera main2 = Camera.main;
												Camera main3 = Camera.main;
												if ((object)main3 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v99 (UnityEngine.Camera)+10]");
													bool flag = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v99 (UnityEngine.Camera)+10]");
													object obj4 = Camera.get_pixelWidth_Injected((IntPtr)0);
													if ((object)main2 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2350 @ rax_v98 (UnityEngine.Camera)+10]");
														bool flag2 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2350 @ rax_v98 (UnityEngine.Camera)+10]");
														Vector3 position = default(Vector3);
														Camera.ScreenToWorldPoint_Injected((IntPtr)0, ref position, Camera.MonoOrStereoscopicEye.Mono, out Vector3 ret);
														bool flag3 = (object)transform2 == null;
														bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
														Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
														Transform transform3 = gameObject.transform;
														Transform transform4 = gameObject.transform;
														bool flag5 = (object)transform4 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2310 @ rax_v115 (UnityEngine.Transform)+10]");
														bool flag6 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2310 @ rax_v115 (UnityEngine.Transform)+10]");
														Transform.get_position_Injected((IntPtr)0, out position);
														Transform transform5 = gameObject.transform;
														if ((object)transform5 != null)
														{
															bool flag7 = ((List<string>)(object)transform5)._items == null;
															Transform.get_position_Injected((IntPtr)((List<string>)(object)transform5)._items, out ret);
															bool flag8 = (object)transform3 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2656 @ rax_v114 (UnityEngine.Transform)+10]");
															bool flag9 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2656 @ rax_v114 (UnityEngine.Transform)+10]");
															Transform.set_position_Injected((IntPtr)0, ref position);
															bool flag10 = (object)particleEmitterManager == null;
															Transform transform6 = particleEmitterManager.transform;
															Transform parent2 = default(Transform);
															string psName = default(string);
															bool isAdditive = default(bool);
															bool requiresMasking = default(bool);
															ParticleSystem particleSystem = particleEmitterManager.CreateUIEmitter(particleSystemConfig, "UI", 11001, parent2, psName, isAdditive, requiresMasking);
															bool flag11 = (object)particleSystem == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																bool flag12 = obj5 == null;
															}
															object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2855 @ rax_v135 (should have been resolved before IL gen)");
															particleSystem.Play(withChildren: true);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
															object obj7 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																bool flag13 = obj7 == null;
															}
															object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2948 @ rax_v141 (should have been resolved before IL gen)");
															ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
															ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
															_ = 0;
															((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&value);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
															object obj9 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																bool flag14 = obj9 == null;
															}
															object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2979 @ rax_v146 (should have been resolved before IL gen)");
															Transform transform7 = particleSystem.transform;
															bool flag15 = (object)transform7 == null;
															bool flag16 = ((List<string>)(object)transform7)._items == null;
															Vector3 value2 = default(Vector3);
															Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform7)._items, ref value2);
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

	public AscensionButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
