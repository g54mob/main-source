using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class FinalFireworksPage : BaseUIPage
{
	private ParticleEmitterManager _PfxEmitter;

	private ParticleEmitterManager _FireworksEmitter;

	private RectTransform _OkButton;

	private RectTransform _DoneButton;

	private Image _BGFader;

	private Image _FGFader;

	private TextMeshProUGUI _PanelText;

	private RectTransform _Panel;

	private GameObject _RayPrefab;

	private RectTransform _RayContainer;

	private Image _FakeFireworkPanel;

	private RectTransform _ScaleContainer;

	private TextMeshProUGUI _Name;

	private TextMeshProUGUI _Description;

	private TextMeshProUGUI _Tips;

	private Image _Icon;

	private RectTransform _WeaponPanel;

	private List<Image> _rays;

	private List<Tween> _rayTweens;

	private List<ParticleSystem> _fireworks;

	private ParticleSystem _blackParticles;

	private ParticleSystem _colorParticles;

	private PlayerOptions _playerOptions;

	private DataManager _data;

	private List<string> _frames;

	private void Construct(PlayerOptions player, DataManager data)
	{
		_playerOptions = player;
		_data = data;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_01a0: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_0394: Expected O, but got Ref
		//IL_01c0->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_020d->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_0284->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_02ba->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_02f6->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_0324->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_0352->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_0380->IL05c1: Incompatible stack heights: 1 vs 0
		//IL_03ae->IL05c1: Incompatible stack heights: 1 vs 0
		base.OnShowStart(g);
		if ((object)_DoneButton != null)
		{
			GameObject gameObject = _DoneButton.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: false);
				if ((object)_OkButton != null)
				{
					GameObject gameObject2 = _OkButton.gameObject;
					if ((object)gameObject2 != null)
					{
						gameObject2.SetActive(value: false);
						CreateBlackParticles();
						if (_playerOptions != null)
						{
							PlayerOptionsData config = _playerOptions.Config;
							if (config != null && _data != null)
							{
								Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
								if (convertedCharacterData != null)
								{
									object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)config._selectedChar);
									if (obj != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v23 (System.Object)+18]");
										bool flag = (nint)0 <= (nint)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v23 (System.Object)+10]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v23 (System.Object)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v24+18]");
											if ((nint)0 <= (nint)0)
											{
												throw new IndexOutOfRangeException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v24+20]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v24+20]");
												string fullName = ((CharacterData)0).GetFullName(config._selectedChar, ignoreSkinPrefixSuffix: true);
												bool applyParameters = default(bool);
												GameObject localParametersRoot = default(GameObject);
												string overrideLanguage = default(string);
												bool allowLocalizedParameters = default(bool);
												string translation = LocalizationManager.GetTranslation("lang/directer_5", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
												if (translation != null)
												{
													string text = translation.Replace("%0", fullName);
													if ((object)_PanelText != null)
													{
														_PanelText.text = text;
														float screenWidth = UIHelper.ScreenWidth;
														if ((object)_Panel != null)
														{
															Vector2 sizeDelta = _Panel.sizeDelta;
															if ((object)_Panel != null)
															{
																Vector2 anchoredPosition = _Panel.anchoredPosition;
																if ((object)_Panel != null)
																{
																	Vector2 anchoredPosition2 = default(Vector2);
																	_Panel.anchoredPosition = anchoredPosition2;
																	if ((object)_OkButton != null)
																	{
																		Vector3 value = default(Vector3);
																		_OkButton.localEulerAngles = (Vector3)(&value);
																		if ((object)_OkButton != null)
																		{
																			Transform transform = _OkButton.transform;
																			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
																			Sequence sequence = DOTween.Sequence();
																			Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 4f);
																			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPosX(_Panel, 0f, 0.15f);
																			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
																			{
																				Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
																			}
																			Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 3.5f);
																			TweenCallback tweenCallback = delegate
																			{
																				EnablePanelsInput();
																			};
																			Tween t2;
																			object message;
																			if (sequence != null)
																			{
																				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
																				{
																					if (!((Tween)sequence).creationLocked)
																					{
																						if (tweenCallback != null)
																						{
																							Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
																						}
																						return;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
																					if ((nint)0 == 0)
																					{
																						_ = 1;
																					}
																					t2 = null;
																					message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
																				}
																				else
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
																					if ((nint)0 == 0)
																					{
																						_ = 1;
																					}
																					t2 = null;
																					message = "You can't add elements to an inactive/killed Sequence";
																				}
																			}
																			else
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
																				if ((nint)0 == 0)
																				{
																					_ = 1;
																				}
																				t2 = null;
																				message = "You can't add elements to a NULL Sequence";
																			}
																			Debugger.LogWarning(message, t2);
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

	private unsafe void CreateBlackParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f4: Expected O, but got Ref
		//IL_0409: Expected native int or pointer, but got O
		//IL_0423: Expected O, but got I
		//IL_046e: Expected O, but got Ref
		//IL_0487: Expected native int or pointer, but got O
		//IL_04a6: Expected O, but got I
		//IL_04d4: Expected O, but got I4
		//IL_04ed: Expected O, but got Ref
		//IL_0507: Expected native int or pointer, but got O
		//IL_0ceb: Expected O, but got I4
		//IL_0539: Expected O, but got Ref
		//IL_0553: Expected native int or pointer, but got O
		//IL_0d25: Expected O, but got I
		//IL_058b: Expected O, but got Ref
		//IL_05b2: Expected O, but got I
		//IL_05d3: Expected O, but got I
		//IL_05ed: Expected native int or pointer, but got O
		//IL_0607: Expected O, but got I
		//IL_063a: Expected O, but got I
		//IL_0d54: Expected O, but got I
		//IL_0da7: Expected O, but got I
		//IL_0edd: Expected O, but got Ref
		//IL_0ef5: Expected O, but got Ref
		//IL_0f0f: Expected native int or pointer, but got O
		//IL_0f22: Expected O, but got Ref
		//IL_0f2f: Expected O, but got Ref
		//IL_0f3f: Expected O, but got I
		//IL_0df1: Expected O, but got Ref
		//IL_088e: Expected O, but got I
		//IL_0924: Expected O, but got I
		//IL_0956: Expected O, but got I4
		//IL_0956: Expected I4, but got O
		//IL_0a87: Expected O, but got Ref
		//IL_0e65: Expected I, but got O
		//IL_08ae->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_08fb->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_0972->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_09a8->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_09e4->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_0a17->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_0a45->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_0a73->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_0aa1->IL0cb4: Incompatible stack heights: 1 vs 0
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
					((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
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
						((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
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
							((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
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
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
									_ = 0;
									Camera main = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBounds(main);
									Vector2 vector = default(Vector2);
									float max = (float)vector * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(625f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-300f, -600f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
									_ = 0;
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(3f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
									_ = 0;
									_ = 8;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
									particleSystemConfig._tint = (uint?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									particleSystemConfig._on = true;
									if ((object)_PfxEmitter != null)
									{
										Transform transform = _PfxEmitter.transform;
										Transform transform2 = default(Transform);
										string text = default(string);
										bool flag = default(bool);
										bool flag2 = default(bool);
										ParticleSystem blackParticles = _PfxEmitter.CreateUIEmitter(particleSystemConfig, "UI", 4, transform2, text, flag, flag2);
										_blackParticles = blackParticles;
										if ((object)_blackParticles != null)
										{
											_blackParticles.Play(withChildren: true);
											if ((object)_blackParticles != null)
											{
												_ = _blackParticles;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													if (obj3 == null)
													{
														MissingMethodException ex = new MissingMethodException();
														throw ex;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2043 @ rax_v64 (should have been resolved before IL gen)");
												if ((object)_blackParticles != null)
												{
													_ = _blackParticles;
													_ = _blackParticles;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
													object obj4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														if (obj4 == null)
														{
															MissingMethodException ex2 = new MissingMethodException();
															throw ex2;
														}
													}
													object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2130 @ rax_v69 (should have been resolved before IL gen)");
													ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
													ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
													((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
													object obj6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														if (obj6 == null)
														{
															MissingMethodException ex3 = new MissingMethodException();
															throw ex3;
														}
													}
													object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2161 @ rax_v74 (should have been resolved before IL gen)");
													if (_playerOptions != null)
													{
														PlayerOptionsData config = _playerOptions.Config;
														if (config != null && _data != null)
														{
															Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
															if (convertedCharacterData != null)
															{
																object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)config._selectedChar);
																if (obj8 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v78 (System.Object)+18]");
																	bool flag3 = (nint)0 <= (nint)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v78 (System.Object)+10]");
																	object obj9 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v78 (System.Object)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v79+18]");
																		if ((nint)0 <= (nint)0)
																		{
																			throw new IndexOutOfRangeException();
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v79+20]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v79+20]");
																			string fullName = ((CharacterData)0).GetFullName(config._selectedChar, ignoreSkinPrefixSuffix: true);
																			string translation = LocalizationManager.GetTranslation("lang/directer_5", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)transform2 != 0, (GameObject)(object)text, (string)flag, flag2);
																			if (translation != null)
																			{
																				string text2 = translation.Replace("%0", fullName);
																				if ((object)_PanelText != null)
																				{
																					_PanelText.text = text2;
																					float screenWidth = UIHelper.ScreenWidth;
																					if ((object)_Panel != null)
																					{
																						Vector2 sizeDelta = _Panel.sizeDelta;
																						if ((object)_Panel != null)
																						{
																							Vector2 anchoredPosition = _Panel.anchoredPosition;
																							if ((object)_Panel != null)
																							{
																								_Panel.anchoredPosition = vector;
																								if ((object)_OkButton != null)
																								{
																									Vector2 vector2 = default(Vector2);
																									_OkButton.localEulerAngles = (Vector3)(&vector2);
																									if ((object)_OkButton != null)
																									{
																										Transform transform3 = _OkButton.transform;
																										bool flag4 = ((List<string>)(object)transform3)._items == null;
																										Vector3 value = default(Vector3);
																										Transform.set_localScale_Injected((IntPtr)((List<string>)(object)transform3)._items, ref value);
																										Sequence sequence = DOTween.Sequence();
																										Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 4f);
																										TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPosX(_Panel, 0f, 0.15f);
																										if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
																										{
																											Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
																										}
																										Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 3.5f);
																										TweenCallback tweenCallback = delegate
																										{
																											EnablePanelsInput();
																										};
																										Tween t2;
																										object message;
																										if (sequence != null)
																										{
																											if (((Tween)sequence)._003Cactive_003Ek__BackingField)
																											{
																												if (!((Tween)sequence).creationLocked)
																												{
																													if (tweenCallback != null)
																													{
																														Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
																													}
																													return;
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
																												if ((nint)0 == 0)
																												{
																													_ = 1;
																												}
																												t2 = null;
																												message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
																											}
																											else
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
																												if ((nint)0 == 0)
																												{
																													_ = 1;
																												}
																												t2 = null;
																												message = "You can't add elements to an inactive/killed Sequence";
																											}
																										}
																										else
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
																											if ((nint)0 == 0)
																											{
																												_ = 1;
																											}
																											t2 = null;
																											message = "You can't add elements to a NULL Sequence";
																										}
																										Debugger.LogWarning(message, t2);
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
		throw new NullReferenceException();
	}

	private unsafe void AddItemPanel()
	{
		//IL_0297: Expected O, but got I
		//IL_02f4: Expected O, but got I
		//IL_0693: Expected O, but got I
		//IL_06c4: Expected O, but got I
		//IL_0721: Expected O, but got I
		//IL_051f: Expected O, but got I4
		//IL_0558: Expected O, but got I4
		//IL_02b7->IL0643: Incompatible stack heights: 1 vs 0
		//IL_0314->IL0643: Incompatible stack heights: 1 vs 0
		//IL_0392->IL0643: Incompatible stack heights: 1 vs 0
		//IL_03f3->IL0643: Incompatible stack heights: 1 vs 0
		//IL_0454->IL0643: Incompatible stack heights: 1 vs 0
		//IL_04a7->IL0643: Incompatible stack heights: 1 vs 0
		//IL_04d5->IL0643: Incompatible stack heights: 1 vs 0
		//IL_050d->IL0643: Incompatible stack heights: 1 vs 0
		//IL_053c->IL0643: Incompatible stack heights: 1 vs 0
		//IL_08be->IL0643: Incompatible stack heights: 2 vs 0
		//IL_0575->IL0643: Incompatible stack heights: 2 vs 0
		//IL_07f3->IL0643: Incompatible stack heights: 3 vs 0
		//IL_05ab->IL0643: Incompatible stack heights: 3 vs 0
		//IL_05d7->IL0643: Incompatible stack heights: 3 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			AchievementManager achievementManager = core._achievementManager;
			if (core._achievementManager != null)
			{
				DataManager dataManager = achievementManager._dataManager;
				if (achievementManager._dataManager != null)
				{
					achievementManager._Achievements = dataManager._003CAllAchievements_003Ek__BackingField;
					bool flag = core._achievementManager.Unlock(AchievementType.GreatestJubilee);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						PlayerOptions playerOptions = core2._playerOptions;
						if (core2._playerOptions != null)
						{
							PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
							if (playerOptions._mainGameConfig != null)
							{
								mainGameConfig._003CHasSeenFinalFireworks_003Ek__BackingField = true;
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null && core3._playerOptions != null)
								{
									core3._playerOptions.Save();
									GameManager core4 = GM.Core;
									if ((object)GM.Core != null)
									{
										PlayerOptions playerOptions2 = core4._playerOptions;
										if (core4._playerOptions != null)
										{
											playerOptions2._003CJustGotJubilee_003Ek__BackingField = true;
											if (_data != null)
											{
												Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
												if (convertedWeapons != null)
												{
													object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)91);
													if (obj != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v45 (System.Object)+18]");
														bool flag2 = (nint)0 <= (nint)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v45 (System.Object)+10]");
														object obj2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v45 (System.Object)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v46+18]");
															if ((nint)0 <= (nint)0)
															{
																throw new IndexOutOfRangeException();
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v46+20]");
															WeaponData weaponData = (WeaponData)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v46+20]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v46+20]");
																string prefix = ((WeaponData)0).GetPrefix(WeaponType.JUBILEE);
																string term = prefix + "name";
																bool applyParameters = default(bool);
																GameObject localParametersRoot = default(GameObject);
																string overrideLanguage = default(string);
																bool allowLocalizedParameters = default(bool);
																string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
																if ((object)_Name != null)
																{
																	_Name.text = translation;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
																	if ((nint)0 == 0)
																	{
																		_ = 1;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v46+20]");
																	string prefix2 = ((WeaponData)0).GetPrefix(WeaponType.JUBILEE);
																	string term2 = prefix2 + "description";
																	string translation2 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
																	if ((object)_Description != null)
																	{
																		_Description.text = translation2;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C63]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v46+20]");
																		string prefix3 = ((WeaponData)0).GetPrefix(WeaponType.JUBILEE);
																		string term3 = prefix3 + "tips";
																		string translation3 = LocalizationManager.GetTranslation(term3, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
																		if ((object)_Tips != null)
																		{
																			_Tips.text = translation3;
																			Sprite sprite = SpriteManager.GetSprite(weaponData._003CframeName_003Ek__BackingField, weaponData._003Ctexture_003Ek__BackingField);
																			if ((object)_Icon != null)
																			{
																				_Icon.sprite = sprite;
																				if ((object)_Icon != null)
																				{
																					RectTransform rectTransform = _Icon.rectTransform;
																					WeaponData icon = (WeaponData)(object)_Icon;
																					if ((object)_Icon != null)
																					{
																						object obj3 = icon._003Cseen_003Ek__BackingField;
																						if (icon._003Cseen_003Ek__BackingField)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdi_v16 (System.Object)+10]");
																							bool flag3 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdi_v16 (System.Object)+10]");
																							Vector2 ret;
																							Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
																							WeaponData icon2 = (WeaponData)(object)_Icon;
																							if ((object)_Icon != null)
																							{
																								object obj4 = icon2._003Cseen_003Ek__BackingField;
																								if (icon2._003Cseen_003Ek__BackingField)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdi_v18 (System.Object)+10]");
																									bool flag4 = (nint)0 == 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdi_v18 (System.Object)+10]");
																									float ret2;
																									Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret2));
																									if ((object)rectTransform != null)
																									{
																										Vector2 sizeDelta = default(Vector2);
																										rectTransform.sizeDelta = sizeDelta;
																										if ((object)_WeaponPanel != null)
																										{
																											Transform transform = _WeaponPanel.transform;
																											if ((object)transform != null)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v80 (UnityEngine.Transform)+10]");
																												bool flag5 = (nint)0 == 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v80 (UnityEngine.Transform)+10]");
																												Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret2));
																												bool flag6 = (object)_WeaponPanel == null;
																												Transform transform2 = _WeaponPanel.transform;
																												bool flag7 = (object)transform2 == null;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v86 (UnityEngine.Transform)+10]");
																												bool flag8 = (nint)0 == 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v86 (UnityEngine.Transform)+10]");
																												Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&ret));
																												bool flag9 = (object)_WeaponPanel == null;
																												Transform target = _WeaponPanel.transform;
																												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleY(target, ret2, 0.3f);
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
		throw new NullReferenceException();
	}

	private unsafe void PlayReveal()
	{
		//IL_0196: Expected O, but got I4
		//IL_020e: Expected O, but got I8
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_03e4: Expected O, but got I4
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		StartFireworks();
		AddRays();
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			AddRays();
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_0171;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
		goto IL_0171;
		IL_0171:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Piano, soundConfig, 0f, 10, time);
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(_BGFader, 2f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 3f);
		TweenCallback tweenCallback2 = delegate
		{
			//IL_0008: Expected O, but got Ref
			//IL_0353: Expected O, but got Ref
			//IL_0368: Expected native int or pointer, but got O
			//IL_0382: Expected O, but got I
			//IL_03cd: Expected O, but got Ref
			//IL_03e6: Expected native int or pointer, but got O
			//IL_0405: Expected O, but got I
			//IL_0433: Expected O, but got I4
			//IL_044c: Expected O, but got Ref
			//IL_0466: Expected native int or pointer, but got O
			//IL_06a9: Expected O, but got I4
			//IL_0498: Expected O, but got Ref
			//IL_04b2: Expected native int or pointer, but got O
			//IL_06e3: Expected O, but got I
			//IL_04ea: Expected O, but got Ref
			//IL_0511: Expected O, but got I
			//IL_052b: Expected native int or pointer, but got O
			//IL_0545: Expected O, but got I
			//IL_0578: Expected O, but got I
			//IL_0719: Expected O, but got I
			//IL_07e4: Expected O, but got Ref
			//IL_076c: Expected O, but got I
			//IL_0801: Expected O, but got Ref
			//IL_0819: Expected O, but got Ref
			//IL_0833: Expected native int or pointer, but got O
			//IL_0846: Expected O, but got Ref
			//IL_0853: Expected O, but got Ref
			//IL_0863: Expected O, but got I
			//IL_07b6: Expected O, but got Ref
			object obj10 = default(object);
			object obj9 = (object)(&obj10);
			_blackParticles.Stop();
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
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
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
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
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
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
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj10, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			object obj11 = default(object);
			float max = (float)obj11 * 2f;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj10, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(625f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-300f, -600f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
			_ = 0;
			particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(3f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 72));
			_ = 0;
			_ = 8;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			particleSystemConfig._on = true;
			Transform transform = _PfxEmitter.transform;
			Transform parent = default(Transform);
			string psName = default(string);
			bool isAdditive = default(bool);
			bool requiresMasking = default(bool);
			ParticleSystem colorParticles = _PfxEmitter.CreateUIEmitter(particleSystemConfig, "UI", 4, parent, psName, isAdditive, requiresMasking);
			_colorParticles = colorParticles;
			_colorParticles.Play(withChildren: true);
			_ = _colorParticles;
			_ = _colorParticles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj12 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 216));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1477 @ rax_v53 (should have been resolved before IL gen)");
			_ = _colorParticles;
			_ = _colorParticles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj14 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 208));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1564 @ rax_v58 (should have been resolved before IL gen)");
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 104));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
			ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 208));
			((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj16 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
			}
			object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj10, 208));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1595 @ rax_v63 (should have been resolved before IL gen)");
			AddItemPanel();
		};
		object obj = 6603577472L;
		TweenCallback tweenCallback4;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				if ((nint)0 != 0)
				{
					object obj2 = tweenerCore + 32;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rbp_v1+462E0+v333 @ rdx_v14*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rbp_v1+462E0+v333 @ rdx_v14*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rbp_v1+462E0+v333 @ rdx_v14*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rbp_v1+462E0+v333 @ rdx_v14*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rbp_v1+462E0+v333 @ rdx_v14*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback3 = delegate
					{
						Sequence sequence4 = DOTween.Sequence();
						Sequence sequence5 = TweenSettingsExtensions.AppendInterval(sequence4, 4f);
						TweenCallback tweenCallback6 = delegate
						{
							//IL_0036: Expected O, but got Ref
							//IL_00a7: Expected O, but got Ref
							GameObject gameObject = _DoneButton.gameObject;
							gameObject.SetActive(value: true);
							Vector3 value = default(Vector3);
							_DoneButton.localEulerAngles = (Vector3)(&value);
							Transform transform = _DoneButton.transform;
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							object obj9 = default(object);
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_DoneButton, (Vector3)(&obj9), 0.15f);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_DoneButton, 1f, 0.15f);
						};
						object message2;
						if (sequence4 != null)
						{
							if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
							{
								if (!((Tween)sequence4).creationLocked)
								{
									if (tweenCallback6 != null)
									{
										Sequence sequence6 = Sequence.DoInsertCallback(sequence4, tweenCallback6, ((Tween)sequence4).duration);
									}
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								message2 = "You can't add elements to an inactive/killed Sequence";
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							message2 = "You can't add elements to a NULL Sequence";
						}
						Debugger.LogWarning(message2);
					};
					tweenCallback4 = tweenCallback3;
					goto IL_032d;
				}
			}
		}
		TweenCallback tweenCallback5 = delegate
		{
			Sequence sequence4 = DOTween.Sequence();
			Sequence sequence5 = TweenSettingsExtensions.AppendInterval(sequence4, 4f);
			TweenCallback tweenCallback6 = delegate
			{
				//IL_0036: Expected O, but got Ref
				//IL_00a7: Expected O, but got Ref
				GameObject gameObject = _DoneButton.gameObject;
				gameObject.SetActive(value: true);
				Vector3 value = default(Vector3);
				_DoneButton.localEulerAngles = (Vector3)(&value);
				Transform transform = _DoneButton.transform;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				object obj9 = default(object);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_DoneButton, (Vector3)(&obj9), 0.15f);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_DoneButton, 1f, 0.15f);
			};
			object message2;
			if (sequence4 != null)
			{
				if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence4).creationLocked)
					{
						if (tweenCallback6 != null)
						{
							Sequence sequence6 = Sequence.DoInsertCallback(sequence4, tweenCallback6, ((Tween)sequence4).duration);
						}
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message2 = "You can't add elements to an inactive/killed Sequence";
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message2);
		};
		bool flag = tweenerCore == null;
		tweenCallback4 = tweenCallback5;
		if (!flag)
		{
			goto IL_032d;
		}
		return;
		IL_032d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
	}

	private unsafe void EnableDoneButton()
	{
		//IL_0036: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		GameObject gameObject = _DoneButton.gameObject;
		gameObject.SetActive(value: true);
		Vector3 value = default(Vector3);
		_DoneButton.localEulerAngles = (Vector3)(&value);
		Transform transform = _DoneButton.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_DoneButton, (Vector3)(&obj), 0.15f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_DoneButton, 1f, 0.15f);
	}

	public unsafe void OnOKButtonClicked()
	{
		//IL_003b: Expected O, but got Ref
		PlayReveal();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_OkButton, (Vector3)(&obj), 0.15f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_OkButton, 0f, 0.15f);
		float screenWidth = UIHelper.ScreenWidth;
		Vector2 sizeDelta = _Panel.sizeDelta;
		float num = screenWidth * 0.5f;
		float endValue = num + (float)sizeDelta;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = DOTweenModuleUI.DOAnchorPosX(_Panel, endValue, 0.15f);
	}

	public unsafe void OnDoneClicked()
	{
		//IL_01be: Expected O, but got Ref
		//IL_027b: Expected O, but got Ref
		//IL_03ec: Expected I, but got O
		//IL_0402: Expected O, but got I
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		//IL_011e: Expected I, but got O
		//IL_0436: Expected O, but got I4
		//IL_044d: Expected I, but got I8
		//IL_00fa: Expected I, but got I8
		//IL_0232->IL0232: Incompatible stack heights: 1 vs 0
		//IL_030e->IL0153: Incompatible stack heights: 1 vs 0
		//IL_036e->IL0153: Incompatible stack heights: 2 vs 0
		TweenerCore<Color, Color, ColorOptions> tweenerCore3;
		TweenCallback tweenCallback;
		if ((object)_colorParticles != null)
		{
			_colorParticles.Stop();
			if (_rayTweens != null)
			{
				List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
				while (enumerator.MoveNext())
				{
				}
				bool flag = _rays == null;
				ParticleSystem particleSystem = (ParticleSystem)(&enumerator);
				if (!flag)
				{
					List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
					while (enumerator2.MoveNext())
					{
						object obj = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v18 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v18 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, 0f, 0.2f);
					}
					object scaleContainer = _ScaleContainer;
					bool flag3 = (object)_ScaleContainer == null;
					particleSystem = (ParticleSystem)(&enumerator2);
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v13 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v13 (System.Object)+10]");
						Vector2 value = default(Vector2);
						RectTransform.set_pivot_Injected((IntPtr)0, ref value);
						TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_ScaleContainer, 0.15f, 0.5f);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 0.3f);
						object panel = _Panel;
						if ((object)_Panel != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v14 (System.Object)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v14 (System.Object)+10]");
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							if ((object)gameObject != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v52 (UnityEngine.GameObject)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v52 (UnityEngine.GameObject)+10]");
								GameObject.SetActive_Injected((IntPtr)0, false);
								TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleUI.DOFade(_FGFader, 1f, 0.5f);
								tweenerCore3 = TweenSettingsExtensions.SetDelay(t2, 0.3f);
								tweenCallback = null;
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ r10_v1 (Il2CppMethodInfo)+8]");
								((Delegate)tweenCallback).method_ptr = (IntPtr)0;
								((Delegate)tweenCallback).method = (nint)__ldftn(FinalFireworksPage._003COnDoneClicked_003Eb__32_0);
								((Delegate)tweenCallback).m_target = this;
								((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ r10_v1 (Il2CppMethodInfo)+4C]");
								object obj2 = (nint)0 >> 4;
								object obj3 = obj2 & 1;
								nint num2;
								if (obj3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ r10_v1 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num2 = unchecked((nint)6447293664L);
										goto IL_042d;
									}
								}
								num2 = ((Delegate)tweenCallback).method_ptr;
								((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
								goto IL_042d;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_042d:
		object obj4 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1188 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void OnExitScene()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		FireworksManager.Clear();
	}

	private unsafe void EnablePanelsInput()
	{
		//IL_0036: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		GameObject gameObject = _OkButton.gameObject;
		gameObject.SetActive(value: true);
		Vector3 value = default(Vector3);
		_OkButton.localEulerAngles = (Vector3)(&value);
		Transform transform = _OkButton.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_OkButton, (Vector3)(&obj), 0.15f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_OkButton, 1f, 0.15f);
	}

	private unsafe void AddRays()
	{
		//IL_08b7: Expected O, but got I4
		//IL_009e: Expected O, but got Ref
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Expected O, but got Unknown
		//IL_09c7: Expected O, but got I4
		//IL_09e7: Expected O, but got Ref
		//IL_01f1: Expected O, but got Ref
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02e8: Expected F4, but got O
		//IL_03e4: Expected I, but got O
		//IL_04d4: Expected I, but got O
		//IL_05c4: Expected I, but got O
		//IL_06b4: Expected I, but got O
		//IL_07a4: Expected I, but got O
		//IL_0894: Expected I, but got O
		//IL_0a12->IL08bc: Incompatible stack heights: 3 vs 0
		//IL_0a3b->IL08bc: Incompatible stack heights: 3 vs 0
		//IL_0a5a->IL08bc: Incompatible stack heights: 3 vs 0
		//IL_02f9->IL0a5f: Incompatible stack heights: 3 vs 0
		//IL_0322->IL08bc: Incompatible stack heights: 3 vs 0
		//IL_0372->IL08bc: Incompatible stack heights: 4 vs 0
		//IL_03d7->IL08bc: Incompatible stack heights: 5 vs 0
		//IL_0412->IL08bc: Incompatible stack heights: 5 vs 0
		//IL_0462->IL08bc: Incompatible stack heights: 6 vs 0
		//IL_04c7->IL08bc: Incompatible stack heights: 7 vs 0
		//IL_0502->IL08bc: Incompatible stack heights: 7 vs 0
		//IL_0552->IL08bc: Incompatible stack heights: 8 vs 0
		//IL_05b7->IL08bc: Incompatible stack heights: 9 vs 0
		//IL_05f2->IL08bc: Incompatible stack heights: 9 vs 0
		//IL_0642->IL08bc: Incompatible stack heights: 10 vs 0
		//IL_06a7->IL08bc: Incompatible stack heights: 11 vs 0
		//IL_06e2->IL08bc: Incompatible stack heights: 11 vs 0
		//IL_0732->IL08bc: Incompatible stack heights: 12 vs 0
		//IL_0797->IL08bc: Incompatible stack heights: 13 vs 0
		//IL_07d2->IL08bc: Incompatible stack heights: 13 vs 0
		//IL_0822->IL08bc: Incompatible stack heights: 14 vs 0
		//IL_0887->IL08bc: Incompatible stack heights: 15 vs 0
		object obj = 0;
		Vector3 value = default(Vector3);
		object obj2 = default(object);
		object obj5 = default(object);
		float num3 = default(float);
		object obj6 = default(object);
		object obj7 = default(object);
		while (true)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_RayPrefab, _RayContainer);
			if ((object)gameObject == null)
			{
				break;
			}
			if (((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(gameObject);
				break;
			}
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			transform2.localEulerAngles = (Vector3)(&obj2);
			bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			object obj3 = obj & 1;
			bool flag4 = obj3 == null;
			object obj4 = !flag4;
			if (obj4 == null)
			{
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj5), 1f);
			Image component = gameObject.GetComponent<Image>();
			if (_rays == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77500");
			float num = (float)obj * 0.075f;
			float duration = num + 0.5f;
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(component, 0.25f, duration);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1495 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1495 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1495 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			if (_rayTweens == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
			Transform target2 = gameObject.transform;
			float num2 = (float)obj * 0.15f;
			float duration2 = num2 + 3f;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&num3), duration2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v62+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v62+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v62+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			if (_rayTweens == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
			obj++;
			bool flag5 = (nint)obj < 6;
			obj5 = obj7;
			num3 = (float)obj7;
			obj2 = obj7;
			if (!flag5)
			{
				List<Image> rays = _rays;
				if (_rays == null)
				{
					break;
				}
				bool flag6 = rays._size <= 0;
				Image[] items = rays._items;
				if (rays._items == null)
				{
					break;
				}
				bool flag7 = items.Length <= 0;
				GameObject gameObject2 = (GameObject)(object)items[0];
				Color color = ColourHelper.HexToColor("0xff0000");
				if ((object)items[0] == null)
				{
					break;
				}
				nint num4 = (nint)gameObject2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v223 @ r9_v15 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
				List<Image> rays2 = _rays;
				if (_rays == null)
				{
					break;
				}
				bool flag8 = rays2._size <= 1;
				Image[] items2 = rays2._items;
				if (rays2._items == null)
				{
					break;
				}
				bool flag9 = items2.Length <= 1;
				GameObject gameObject3 = (GameObject)(object)items2[1];
				Color color2 = ColourHelper.HexToColor("0x00ff00");
				if ((object)items2[1] == null)
				{
					break;
				}
				nint num5 = (nint)gameObject3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v224 @ r9_v16 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
				List<Image> rays3 = _rays;
				if (_rays == null)
				{
					break;
				}
				bool flag10 = rays3._size <= 2;
				Image[] items3 = rays3._items;
				if (rays3._items == null)
				{
					break;
				}
				bool flag11 = items3.Length <= 2;
				GameObject gameObject4 = (GameObject)(object)items3[2];
				Color color3 = ColourHelper.HexToColor("0x0000ff");
				if ((object)items3[2] == null)
				{
					break;
				}
				nint num6 = (nint)gameObject4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ r9_v17 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
				List<Image> rays4 = _rays;
				if (_rays == null)
				{
					break;
				}
				bool flag12 = rays4._size <= 3;
				Image[] items4 = rays4._items;
				if (rays4._items == null)
				{
					break;
				}
				bool flag13 = items4.Length <= 3;
				GameObject gameObject5 = (GameObject)(object)items4[3];
				Color color4 = ColourHelper.HexToColor("0xffff00");
				if ((object)items4[3] == null)
				{
					break;
				}
				nint num7 = (nint)gameObject5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v226 @ r9_v18 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
				List<Image> rays5 = _rays;
				if (_rays == null)
				{
					break;
				}
				bool flag14 = rays5._size <= 4;
				Image[] items5 = rays5._items;
				if (rays5._items == null)
				{
					break;
				}
				bool flag15 = items5.Length <= 4;
				GameObject gameObject6 = (GameObject)(object)items5[4];
				Color color5 = ColourHelper.HexToColor("0xff00ff");
				if ((object)items5[4] == null)
				{
					break;
				}
				nint num8 = (nint)gameObject6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v227 @ r9_v19 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
				List<Image> rays6 = _rays;
				if (_rays == null)
				{
					break;
				}
				bool flag16 = rays6._size <= 5;
				Image[] items6 = rays6._items;
				if (rays6._items == null)
				{
					break;
				}
				bool flag17 = items6.Length <= 5;
				GameObject gameObject7 = (GameObject)(object)items6[5];
				Color color6 = ColourHelper.HexToColor("0x00ffff");
				if ((object)items6[5] == null)
				{
					break;
				}
				nint num9 = (nint)gameObject7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v978 @ r9_v20 (Il2CppClass<UnityEngine.GameObject>)+2A8] (should have been resolved before IL gen)");
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void StartFireworks()
	{
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		gravityWellConfig._power = 0.6f;
		gravityWellConfig._epsilon = 15.000001f;
		gravityWellConfig._gravity = 90f;
		RectTransform component = GetComponent<RectTransform>();
		Vector2 viewportPosition = FireworksManager.GetViewportPosition(component);
		GravityWell gravityWell = FireworksManager.CreateGravityWell(viewportPosition, gravityWellConfig);
		float[] array = new float[7] { 0.1f, 0.3f, 0.5f, 0.7f, 0.9f, 1.2f, 1.4f };
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, array[0]);
		TweenCallback tweenCallback = delegate
		{
			PlayFirework(0);
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_01f7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
		goto IL_01f7;
		IL_0677:
		float interval = array[4] - array[3];
		Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, interval);
		TweenCallback tweenCallback2 = delegate
		{
			PlayFirework(4);
		};
		object message2;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback2 != null)
					{
						Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
					}
					goto IL_07f7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message2);
		goto IL_07f7;
		IL_0377:
		float interval2 = array[2] - array[1];
		Sequence sequence6 = TweenSettingsExtensions.AppendInterval(sequence, interval2);
		TweenCallback tweenCallback3 = delegate
		{
			PlayFirework(2);
		};
		object message3;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback3 != null)
					{
						Sequence sequence7 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
					}
					goto IL_04f7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message3);
		goto IL_04f7;
		IL_04f7:
		float interval3 = array[3] - array[2];
		Sequence sequence8 = TweenSettingsExtensions.AppendInterval(sequence, interval3);
		TweenCallback tweenCallback4 = delegate
		{
			PlayFirework(3);
		};
		object message4;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback4 != null)
					{
						Sequence sequence9 = Sequence.DoInsertCallback(sequence, tweenCallback4, ((Tween)sequence).duration);
					}
					goto IL_0677;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message4 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message4);
		goto IL_0677;
		IL_07f7:
		float interval4 = array[5] - array[4];
		Sequence sequence10 = TweenSettingsExtensions.AppendInterval(sequence, interval4);
		TweenCallback tweenCallback5 = delegate
		{
			PlayFirework(5);
		};
		object message5;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback5 != null)
					{
						Sequence sequence11 = Sequence.DoInsertCallback(sequence, tweenCallback5, ((Tween)sequence).duration);
					}
					goto IL_0977;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message5 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message5 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message5);
		goto IL_0977;
		IL_01f7:
		float interval5 = array[1] - array[0];
		Sequence sequence12 = TweenSettingsExtensions.AppendInterval(sequence, interval5);
		TweenCallback tweenCallback6 = delegate
		{
			PlayFirework(1);
		};
		object message6;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback6 != null)
					{
						Sequence sequence13 = Sequence.DoInsertCallback(sequence, tweenCallback6, ((Tween)sequence).duration);
					}
					goto IL_0377;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message6 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message6 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message6 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message6);
		goto IL_0377;
		IL_0977:
		float interval6 = array[6] - array[5];
		Sequence sequence14 = TweenSettingsExtensions.AppendInterval(sequence, interval6);
		TweenCallback tweenCallback7 = delegate
		{
			PlayFirework(6);
		};
		Tween t;
		object message7;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback7 != null)
					{
						Sequence sequence15 = Sequence.DoInsertCallback(sequence, tweenCallback7, ((Tween)sequence).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message7 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message7 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t = null;
			message7 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message7, t);
	}

	private void PlayFirework(int i)
	{
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_FakeFireworkPanel, 0.4f, 0.03f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						_ = 0;
					}
				}
			}
		}
		RectTransform component = GetComponent<RectTransform>();
		ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(i, _frames, component, 0.6f);
	}

	public FinalFireworksPage()
	{
		List<Image> rays = new List<Image>();
		_rays = rays;
		_rayTweens = new List<Tween>();
		_fireworks = new List<ParticleSystem>();
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxRed.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frames = list;
		base._002Ector();
	}

	private void _003COnShowStart_003Eb__26_0()
	{
		EnablePanelsInput();
	}

	private void _003CCreateBlackParticles_003Eb__27_0()
	{
		EnablePanelsInput();
	}

	private void _003CPlayReveal_003Eb__29_0()
	{
		AddRays();
	}

	private unsafe void _003CPlayReveal_003Eb__29_1()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0353: Expected O, but got Ref
		//IL_0368: Expected native int or pointer, but got O
		//IL_0382: Expected O, but got I
		//IL_03cd: Expected O, but got Ref
		//IL_03e6: Expected native int or pointer, but got O
		//IL_0405: Expected O, but got I
		//IL_0433: Expected O, but got I4
		//IL_044c: Expected O, but got Ref
		//IL_0466: Expected native int or pointer, but got O
		//IL_06a9: Expected O, but got I4
		//IL_0498: Expected O, but got Ref
		//IL_04b2: Expected native int or pointer, but got O
		//IL_06e3: Expected O, but got I
		//IL_04ea: Expected O, but got Ref
		//IL_0511: Expected O, but got I
		//IL_052b: Expected native int or pointer, but got O
		//IL_0545: Expected O, but got I
		//IL_0578: Expected O, but got I
		//IL_0719: Expected O, but got I
		//IL_07e4: Expected O, but got Ref
		//IL_076c: Expected O, but got I
		//IL_0801: Expected O, but got Ref
		//IL_0819: Expected O, but got Ref
		//IL_0833: Expected native int or pointer, but got O
		//IL_0846: Expected O, but got Ref
		//IL_0853: Expected O, but got Ref
		//IL_0863: Expected O, but got I
		//IL_07b6: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_blackParticles.Stop();
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxGreen.png");
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
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
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
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxBlue.png");
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
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		_ = 0;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj3 = default(object);
		float max = (float)obj3 * 2f;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(625f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-300f, -600f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(3f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 8;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._on = true;
		Transform transform = _PfxEmitter.transform;
		Transform parent = default(Transform);
		string psName = default(string);
		bool isAdditive = default(bool);
		bool requiresMasking = default(bool);
		ParticleSystem colorParticles = _PfxEmitter.CreateUIEmitter(particleSystemConfig, "UI", 4, parent, psName, isAdditive, requiresMasking);
		_colorParticles = colorParticles;
		_colorParticles.Play(withChildren: true);
		_ = _colorParticles;
		_ = _colorParticles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj4 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1477 @ rax_v53 (should have been resolved before IL gen)");
		_ = _colorParticles;
		_ = _colorParticles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj6 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1564 @ rax_v58 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
		((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj8 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1595 @ rax_v63 (should have been resolved before IL gen)");
		AddItemPanel();
	}

	private unsafe void _003CPlayReveal_003Eb__29_2()
	{
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 4f);
		TweenCallback tweenCallback = delegate
		{
			//IL_0036: Expected O, but got Ref
			//IL_00a7: Expected O, but got Ref
			GameObject gameObject = _DoneButton.gameObject;
			gameObject.SetActive(value: true);
			Vector3 value = default(Vector3);
			_DoneButton.localEulerAngles = (Vector3)(&value);
			Transform transform = _DoneButton.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			object obj = default(object);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_DoneButton, (Vector3)(&obj), 0.15f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_DoneButton, 1f, 0.15f);
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
	}

	private unsafe void _003CPlayReveal_003Eb__29_3()
	{
		//IL_0036: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		GameObject gameObject = _DoneButton.gameObject;
		gameObject.SetActive(value: true);
		Vector3 value = default(Vector3);
		_DoneButton.localEulerAngles = (Vector3)(&value);
		Transform transform = _DoneButton.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_DoneButton, (Vector3)(&obj), 0.15f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_DoneButton, 1f, 0.15f);
	}

	private void _003COnDoneClicked_003Eb__32_0()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		FireworksManager.Clear();
	}

	private void _003CStartFireworks_003Eb__36_0()
	{
		PlayFirework(0);
	}

	private void _003CStartFireworks_003Eb__36_1()
	{
		PlayFirework(1);
	}

	private void _003CStartFireworks_003Eb__36_2()
	{
		PlayFirework(2);
	}

	private void _003CStartFireworks_003Eb__36_3()
	{
		PlayFirework(3);
	}

	private void _003CStartFireworks_003Eb__36_4()
	{
		PlayFirework(4);
	}

	private void _003CStartFireworks_003Eb__36_5()
	{
		PlayFirework(5);
	}

	private void _003CStartFireworks_003Eb__36_6()
	{
		PlayFirework(6);
	}
}
