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
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI;

public class AdventureItemUI : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	private Image _Icon;

	private Image _Selection;

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _CoinCount;

	private TextMeshProUGUI _ProgressCount;

	private Image _ProgressFill;

	private GameObject _AvailableGroup;

	private GameObject _RequiresDlcPurchaseGroup;

	private GameObject _CompletedGroup;

	private GameObject _LockedGroup;

	private Button _AscendAdventureButton;

	private Image _Flash;

	private RectTransform _BackgroundContainer;

	private Image _CompletionStar;

	private AdventureType _type;

	private AdventureData _data;

	private SelectAdventuresPage _page;

	private GameObject _background;

	private bool _isUnlockedViaAtlas;

	private bool _ownsRequiredDlc;

	private void Awake()
	{
		Button ascendAdventureButton = _AscendAdventureButton;
		UnityAction call = SetAscendingItem;
		ascendAdventureButton.m_OnClick.AddListener(call);
	}

	private void Start()
	{
	}

	public Button GetAscendButton()
	{
		return _AscendAdventureButton;
	}

	public unsafe void SetData(SelectAdventuresPage page, AdventureType type, AdventureData adventureData)
	{
		//IL_0008: Expected O, but got Ref
		//IL_1058: Expected O, but got I
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_10b2: Expected O, but got Ref
		//IL_0271: Expected I, but got O
		//IL_01e2: Expected I4, but got O
		//IL_09cc: Expected O, but got I
		//IL_0a1c: Invalid comparison between I and F4
		//IL_0adf: Expected O, but got I4
		//IL_0a44: Invalid comparison between F4 and I
		//IL_0843: Expected O, but got I4
		//IL_0b52: Expected O, but got I4
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_0835: Expected O, but got I
		//IL_0b17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1c: Expected O, but got Unknown
		//IL_0b44: Expected O, but got I
		//IL_085b: Expected O, but got Ref
		//IL_0871: Expected O, but got I4
		//IL_088f: Expected O, but got I
		//IL_0b6a: Expected O, but got Ref
		//IL_0b7b: Expected O, but got I4
		//IL_0b7b: Expected I4, but got O
		//IL_0ba3: Expected O, but got I
		//IL_0bd3: Expected I, but got O
		//IL_093e: Expected O, but got I
		//IL_0c31: Expected O, but got I
		//IL_096e: Expected I, but got O
		//IL_0c66: Expected O, but got I
		//IL_0d7a: Expected O, but got I
		//IL_0e32: Expected F4, but got I4
		//IL_0db4: Expected O, but got I
		//IL_0e56: Expected O, but got I
		//IL_01ca->IL1022: Incompatible stack heights: 1 vs 0
		//IL_021e->IL10a4: Incompatible stack heights: 1 vs 0
		//IL_0382->IL1022: Incompatible stack heights: 1 vs 0
		//IL_03b1->IL1022: Incompatible stack heights: 1 vs 0
		//IL_03e0->IL1022: Incompatible stack heights: 1 vs 0
		//IL_040f->IL1022: Incompatible stack heights: 1 vs 0
		//IL_044e->IL1022: Incompatible stack heights: 1 vs 0
		//IL_056c->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0495->IL1022: Incompatible stack heights: 1 vs 0
		//IL_05b5->IL1022: Incompatible stack heights: 1 vs 0
		//IL_04ca->IL1022: Incompatible stack heights: 1 vs 0
		//IL_116c->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0505->IL1022: Incompatible stack heights: 1 vs 0
		//IL_05e6->IL1022: Incompatible stack heights: 1 vs 0
		//IL_053a->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0691->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0fe1->IL1022: Incompatible stack heights: 1 vs 0
		//IL_06e9->IL1022: Incompatible stack heights: 1 vs 0
		//IL_100d->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0718->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0747->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0769->IL1022: Incompatible stack heights: 1 vs 0
		//IL_09ec->IL1022: Incompatible stack heights: 1 vs 0
		//IL_07ce->IL1022: Incompatible stack heights: 1 vs 0
		//IL_08b2->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0bc6->IL1022: Incompatible stack heights: 1 vs 0
		//IL_08fa->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0c03->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0961->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0c51->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0992->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0c86->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0cf6->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0f4f->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0d56->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0f7e->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0fad->IL1022: Incompatible stack heights: 1 vs 0
		//IL_11aa->IL1022: Incompatible stack heights: 1 vs 0
		//IL_11c9->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0e76->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0e03->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0e95->IL1022: Incompatible stack heights: 1 vs 0
		//IL_0ec1->IL1022: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_type = type;
		_ = 0;
		_data = adventureData;
		_page = page;
		SelectAdventuresPage page2 = _page;
		if ((object)_page != null)
		{
			PlayerOptions playerOptions = page2._playerOptions;
			if (page2._playerOptions != null)
			{
				GameObject mainGameConfig = (GameObject)(object)playerOptions._mainGameConfig;
				if (playerOptions._mainGameConfig != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdi_v5 (UnityEngine.GameObject)+188]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdi_v5 (UnityEngine.GameObject)+188]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v14+18]");
						bool isUnlockedViaAtlas;
						if ((nint)0 == 0)
						{
							isUnlockedViaAtlas = false;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj5 = default(object);
							object obj4 = obj5 - -1;
							bool flag = obj4 == null;
							isUnlockedViaAtlas = !flag;
						}
						_isUnlockedViaAtlas = isUnlockedViaAtlas;
						if (adventureData != null)
						{
							CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
							if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
							{
								if ((object)coreAdventureData._003CRequiresDLC_003Ek__BackingField == null)
								{
									goto IL_10a4;
								}
								Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
								CoreAdventureData coreAdventureData2 = adventureData._003CCoreAdventureData_003Ek__BackingField;
								if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
								{
									bool flag2 = (object)coreAdventureData2._003CRequiresDLC_003Ek__BackingField == null;
									if (loadedDlc != null)
									{
										System.Int32Enum key = (System.Int32Enum)((object?)coreAdventureData2._003CRequiresDLC_003Ek__BackingField >> 32);
										int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry(key);
										int num2 = num >> 31;
										int ownsRequiredDlc = num2 ^ 1;
										_ownsRequiredDlc = (byte)ownsRequiredDlc != 0;
										goto IL_10a4;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1022;
		IL_0f1c:
		bool flag3;
		if (!flag3)
		{
			goto IL_0fc7;
		}
		if ((object)_RequiresDlcPurchaseGroup != null)
		{
			_RequiresDlcPurchaseGroup.SetActive(value: false);
			if ((object)_AvailableGroup != null)
			{
				_AvailableGroup.SetActive(value: false);
				if ((object)_CompletedGroup != null)
				{
					_CompletedGroup.SetActive(value: true);
					goto IL_0fc7;
				}
			}
		}
		goto IL_1022;
		IL_1022:
		throw new NullReferenceException();
		IL_113b:
		GameObject gameObject;
		bool active;
		gameObject.SetActive(active);
		SelectAdventuresPage page3 = _page;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		ref object value;
		GameObject gameObject3;
		GameObject gameObject4;
		if ((object)_page != null && page3._adventureManager != null)
		{
			bool flag4 = page3._adventureManager.CanAscend(type);
			string translation = LocalizationManager.GetTranslation("adventureLang/adv_adventure_coins", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string translation2 = LocalizationManager.GetTranslation("adventureLang/adv_adventureSelect_progress", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if (page._adventureManager != null)
			{
				if (!page._adventureManager.IsOwned(type))
				{
					goto IL_0fc7;
				}
				SelectAdventuresPage page4 = _page;
				if ((object)_page != null)
				{
					PlayerOptions playerOptions2 = page4._playerOptions;
					if (page4._playerOptions != null)
					{
						PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
						if (playerOptions2._mainGameConfig != null && mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField != null)
						{
							value = ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103);
							if (!((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField).TryGetValue((System.Int32Enum)type, out value))
							{
								CoreAdventureData coreAdventureData3 = adventureData._003CCoreAdventureData_003Ek__BackingField;
								if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
								{
									bool flag5 = ((Dictionary<AdventureType, PlayerOptionsData>)(object)typeof(LocalizationManager)).TryGetValue(type, out System.Runtime.CompilerServices.Unsafe.As<object, PlayerOptionsData>(ref value));
									GameObject gameObject2 = (GameObject)(object)"N0";
									if ("N0" != null)
									{
										object obj6 = "N0" + 20;
										_ = 0;
										_ = ((UnityEngine.Object)gameObject2).m_CachedPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
										object obj7 = 0;
									}
									else
									{
										object obj7 = 0;
									}
									ReadOnlySpan<char> format = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
									string text = System.Number.FormatInt32(coreAdventureData3._003CStartingCoins_003Ek__BackingField, format, (IFormatProvider)flag5);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
									string text2 = (string)0 + ": " + text;
									if ((object)_CoinCount != null)
									{
										_CoinCount.text = text2;
										List<AchievementData> list = adventureData._003CProgressData_003Ek__BackingField;
										GameObject progressCount = (GameObject)(object)_ProgressCount;
										if (adventureData._003CProgressData_003Ek__BackingField != null)
										{
											int num3 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
											_ = list._size;
											string text3 = ((int*)num3)->ToString();
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+77]");
											string text4 = (string)0 + ": 0/" + text3;
											if ((object)_ProgressCount != null)
											{
												nint num4 = (nint)progressCount;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ r9_v24 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
												if ((object)_ProgressFill != null)
												{
													_ProgressFill.fillAmount = 0f;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
													flag3 = false;
													goto IL_0f1c;
												}
											}
										}
									}
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
								if ((nint)0 != 0)
								{
									bool flag6 = mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField.TryGetValue(type, out System.Runtime.CompilerServices.Unsafe.As<object, PlayerOptionsData>(ref value));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v55+84]");
									float num5 = default(float);
									float num6;
									if (0f < 2.1474836E+09f)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v55+84]");
										bool flag7 = !(-2.1474836E+09f < 0f);
										num5 = -2.1474836E+09f;
										if (!flag7)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
											bool flag8 = (nint)gameObject3 > 9999999;
											num5 = -2.1474836E+09f;
											if (!flag8)
											{
												bool flag9 = (nint)gameObject3 >= 0;
												num5 = -2.1474836E+09f;
												num6 = -2.1474836E+09f;
												gameObject4 = gameObject3;
												if (flag9)
												{
													goto IL_0ae4;
												}
											}
										}
									}
									num6 = num5;
									gameObject4 = (GameObject)9999999;
									goto IL_0ae4;
								}
							}
						}
					}
				}
			}
		}
		goto IL_1022;
		IL_0fc7:
		if ((object)_AscendAdventureButton != null)
		{
			AscensionButton component = _AscendAdventureButton.GetComponent<AscensionButton>();
			if ((object)component != null)
			{
				component._adventure = _type;
				return;
			}
		}
		goto IL_1022;
		IL_0ae4:
		bool flag10 = ((Dictionary<AdventureType, PlayerOptionsData>)(object)typeof(LocalizationManager)).TryGetValue(type, out System.Runtime.CompilerServices.Unsafe.As<object, PlayerOptionsData>(ref value));
		object obj9 = "N0";
		if ("N0" != null)
		{
			object obj10 = "N0" + 20;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rdi_v14+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
			object obj11 = 0;
		}
		else
		{
			object obj11 = 0;
		}
		ReadOnlySpan<char> format2 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		string text5 = System.Number.FormatInt32((int)gameObject4, format2, (IFormatProvider)flag10);
		GameObject coinCount = (GameObject)(object)_CoinCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
		string text6 = (string)0 + ": " + text5;
		float fillAmount;
		if ((object)_CoinCount != null)
		{
			nint num7 = (nint)coinCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v279 @ r9_v18 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
			string[] array = new string[5];
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v69+2D8]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v69+2D8]");
					if ((nint)0 != 0)
					{
						int num8 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v70+18]");
						_ = 0;
						string text7 = ((int*)num8)->ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						List<AchievementData> list2 = adventureData._003CProgressData_003Ek__BackingField;
						if (adventureData._003CProgressData_003Ek__BackingField != null)
						{
							int num9 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
							_ = list2._size;
							string text8 = ((int*)num9)->ToString();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							string text9 = string.Concat(array);
							if ((object)_ProgressCount != null)
							{
								_ProgressCount.text = text9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
								GameObject gameObject5 = (GameObject)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v17 (UnityEngine.GameObject)+2D8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v17 (UnityEngine.GameObject)+2D8]");
										object obj14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v88+18]");
										if ((nint)0 != 0)
										{
											List<AchievementData> list3 = adventureData._003CProgressData_003Ek__BackingField;
											if (adventureData._003CProgressData_003Ek__BackingField == null)
											{
												goto IL_1022;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v88+18]");
											fillAmount = 0f / (float)list3._size;
											goto IL_11af;
										}
									}
									fillAmount = 0f;
									goto IL_11af;
								}
							}
						}
					}
				}
			}
		}
		goto IL_1022;
		IL_10a4:
		Enum obj15 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		GameObject title = (GameObject)(object)_Title;
		_ = typeof(AdventureType);
		_ = -1;
		string text10 = obj15.ToString();
		string term = "adventureLang/{" + text10 + "}header";
		string translation3 = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if ((object)_Title != null)
		{
			nint num10 = (nint)title;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ r9_v9 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
			if ((object)_Icon != null)
			{
				_Icon.enabled = false;
				if ((object)page != null && (object)page._backgroundFactory != null)
				{
					GameObject backgroundForAdventureType = page._backgroundFactory.GetBackgroundForAdventureType(type);
					gameObject3 = UnityEngine.Object.Instantiate(backgroundForAdventureType, _BackgroundContainer);
					if ((object)gameObject3 != null)
					{
						Transform transform = gameObject3.transform;
						if ((object)transform != null)
						{
							bool flag11 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.SetSiblingIndex_Injected(((UnityEngine.Object)transform).m_CachedPtr, 0);
							_background = gameObject3;
							if ((object)_AvailableGroup != null)
							{
								_AvailableGroup.SetActive(value: false);
								if ((object)_RequiresDlcPurchaseGroup != null)
								{
									_RequiresDlcPurchaseGroup.SetActive(value: false);
									if ((object)_LockedGroup != null)
									{
										_LockedGroup.SetActive(value: false);
										if ((object)_CompletedGroup != null)
										{
											_CompletedGroup.SetActive(value: false);
											CoreAdventureData coreAdventureData4 = adventureData._003CCoreAdventureData_003Ek__BackingField;
											if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
											{
												if ((object)coreAdventureData4._003CRequiresDLC_003Ek__BackingField == null)
												{
													if (page._adventureManager != null)
													{
														bool active2 = page._adventureManager.IsOwned(type);
														if ((object)_AvailableGroup != null)
														{
															_AvailableGroup.SetActive(active2);
															gameObject = _LockedGroup;
															if (page._adventureManager != null)
															{
																bool flag12 = page._adventureManager.IsOwned(type);
																if ((object)_LockedGroup != null)
																{
																	active = (byte)((flag12 ? 1u : 0u) ^ 1u) != 0;
																	goto IL_113b;
																}
															}
														}
													}
												}
												else if ((object)_RequiresDlcPurchaseGroup != null)
												{
													bool active3 = !_ownsRequiredDlc;
													_RequiresDlcPurchaseGroup.SetActive(active3);
													gameObject = _AvailableGroup;
													if ((object)_AvailableGroup != null)
													{
														active = _ownsRequiredDlc;
														goto IL_113b;
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
		goto IL_1022;
		IL_11af:
		if ((object)_ProgressFill != null)
		{
			_ProgressFill.fillAmount = fillAmount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			if ((nint)0 != 0 && (object)_CompletionStar != null)
			{
				GameObject gameObject6 = _CompletionStar.gameObject;
				if ((object)gameObject6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
					flag3 = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v84+2D4]");
					bool flag13 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
					bool active4 = false;
					if (!flag13)
					{
						active4 = true;
					}
					gameObject6.SetActive(active4);
					goto IL_0f1c;
				}
			}
		}
		goto IL_1022;
	}

	public void OpenDLC()
	{
		_page.HandleDLCPerPlatform();
	}

	public void OnClick()
	{
	}

	public GameObject GetBackground()
	{
		return _background;
	}

	public AdventureType GetAdventureType()
	{
		return _type;
	}

	public AdventureData GetAdventureData()
	{
		return _data;
	}

	public void SetAscendingItem()
	{
		SelectAdventuresPage page = _page;
		page._ascending = this;
	}

	public void OnSelect(BaseEventData eventData)
	{
		GameObject gameObject = _Selection.gameObject;
		gameObject.SetActive(value: true);
		_page.SelectAdventure(this);
	}

	public void Deselect()
	{
		GameObject gameObject = _Selection.gameObject;
		gameObject.SetActive(value: false);
	}

	private float CurrentAdventureCompletionProgress(PlayerOptionsData pod, AdventureData adventureData, AdventureType adventureType)
	{
		//IL_0092: Expected F4, but got I4
		if (pod._003CAdventureProgress_003Ek__BackingField != null)
		{
			List<AdventureAchievementType> list = pod._003CAdventureProgress_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.AdventureAchievementType>)+18]");
			if ((nint)0 != 0)
			{
				List<AchievementData> list2 = adventureData._003CProgressData_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.AdventureAchievementType>)+18]");
				return 0f / (float)list2._size;
			}
		}
		return 0f;
	}

	public void DoAscenscionFeedback()
	{
		//IL_01cb: Expected O, but got I8
		//IL_0162: Expected O, but got I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_0225: Expected O, but got I4
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Flash, 0.15f, 0.15f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 20;
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rbp_v1+462E0+v111 @ rdx_v9*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rbp_v1+462E0+v111 @ rdx_v9*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rbp_v1+462E0+v111 @ rdx_v9*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rbp_v1+462E0+v111 @ rdx_v9*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rbp_v1+462E0+v111 @ rdx_v9*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Flash, 0f, 0.075f);
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 18;
								_ = 0;
							}
						}
					};
					tweenCallback2 = tweenCallback;
					goto IL_010e;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Flash, 0f, 0.075f);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 18;
					_ = 0;
				}
			}
		};
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_010e;
		}
		goto IL_013d;
		IL_013d:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rosary, soundConfig, 500f, 4, time);
		SetData(_page, _type, _data);
		return;
		IL_010e:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_013d;
	}

	public AdventureItemUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CDoAscenscionFeedback_003Eb__33_0()
	{
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Flash, 0f, 0.075f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 18;
				_ = 0;
			}
		}
	}
}
