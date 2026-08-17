using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class LevelUpItemUI : SelectableUI
{
	private Image _Background;

	private Localize _Name;

	private TextMeshProUGUI _Level;

	private TextMeshProUGUI _New;

	private TextMeshProUGUI _Description;

	private Image _Icon;

	private TextMeshProUGUI _EvoText;

	private Image[] _EvoIcons;

	private Image _EvoCharacterIcon;

	private GameObject _ItemCharacterIconGroup;

	private Image[] _ItemCharacterIcons;

	private Image[] _OnlineSuggestionsIcons;

	private WeaponData _data;

	private WeaponData _levelData;

	private WeaponType _type;

	private LevelUpPage _page;

	private List<WeaponData> _allData;

	private WeightedLimitBreak _wlBreak;

	private int _index;

	private ItemData _itemData;

	private ItemType _itemType;

	private int _currentLevel;

	private bool _isLimitBreak;

	private bool _isNew;

	public WeightedLimitBreak LimitBreakData => _wlBreak;

	public ItemType ItemType => _itemType;

	public int Index => _index;

	public void Select()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData = core2._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			bool flag = (object)activeCharacter._coherenceSync == null;
			bool hasStateAuthority = activeCharacter._coherenceSync.HasStateAuthority;
			if (!flag)
			{
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				myPlayerInfo._suggestedLevelUp = _index;
				myPlayerInfo.OnLevelUpSuggested(0, _index);
				return;
			}
		}
		if (_type == WeaponType.VOID && !_isLimitBreak)
		{
			_page.SelectItem(_itemData, _itemType);
		}
		else if (_isLimitBreak)
		{
			_page.SelectLimitBreak(_wlBreak, _index);
		}
		else
		{
			_page.SelectWeapon(_type, this);
		}
	}

	public void SelectWeapon()
	{
		if (_isLimitBreak)
		{
			_page.SelectLimitBreak(_wlBreak, _index);
		}
		else
		{
			_page.SelectWeapon(_type, this);
		}
	}

	public void SelectItem()
	{
		_page.SelectItem(_itemData, _itemType);
	}

	public unsafe void SetWeaponData(LevelUpPage page, WeaponType type, WeaponData baseData, WeaponData levelData, int index, int newLevel, bool isNew, bool showEvo = false, List<Sprite> evoIcons = null, Sprite characterOwner = null)
	{
		//IL_1566: Expected O, but got I
		//IL_1578: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_00aa: Expected O, but got I4
		//IL_0ca3: Expected I, but got I8
		//IL_0cc6: Expected O, but got I
		//IL_0cf6: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_0159: Expected O, but got I4
		//IL_046a: Expected O, but got I
		//IL_05ad: Expected I, but got O
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_019d: Expected O, but got I
		//IL_06d5: Expected O, but got I4
		//IL_0700: Expected I, but got O
		//IL_0208: Expected O, but got I4
		//IL_1098: Unknown result type (might be due to invalid IL or missing references)
		//IL_109d: Expected O, but got Unknown
		//IL_068d: Expected Ref, but got F4
		//IL_144b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1450: Expected O, but got Unknown
		//IL_12d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12db: Expected O, but got Unknown
		//IL_0371: Expected O, but got I
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c3: Expected O, but got Unknown
		//IL_1348: Unknown result type (might be due to invalid IL or missing references)
		//IL_134d: Expected O, but got Unknown
		//IL_03fd: Expected O, but got I
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_151d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1522: Expected O, but got Unknown
		//IL_0fcc: Expected I4, but got O
		//IL_0444: Expected O, but got I
		//IL_044d: Expected O, but got I4
		//IL_127e: Expected I, but got O
		//IL_128c: Expected O, but got I4
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected Ref, but got Unknown
		//IL_07af: Expected O, but got I
		//IL_0a94: Expected O, but got I4
		//IL_0abf: Expected I, but got O
		//IL_0acf: Expected O, but got I
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0823: Expected O, but got Unknown
		//IL_089d: Expected O, but got I
		//IL_0308->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_141f->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_0b67->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_10d3->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_0ba3->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_0b10->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_0d59->IL0c7e: Incompatible stack heights: 2 vs 0
		//IL_0ed8->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_1175->IL0c7e: Incompatible stack heights: 1 vs 0
		//IL_148c->IL0c7e: Incompatible stack heights: 2 vs 0
		//IL_131c->IL0c7e: Incompatible stack heights: 2 vs 0
		//IL_0dc0->IL0c7e: Incompatible stack heights: 3 vs 0
		//IL_0f32->IL0c7e: Incompatible stack heights: 2 vs 0
		//IL_11cf->IL0c7e: Incompatible stack heights: 2 vs 0
		//IL_0391->IL0c7e: Incompatible stack heights: 5 vs 0
		//IL_14ee->IL0c7e: Incompatible stack heights: 3 vs 0
		//IL_136c->IL1042: Incompatible stack heights: 3 vs 0
		//IL_0f8c->IL0c7e: Incompatible stack heights: 3 vs 0
		//IL_03da->IL0c7e: Incompatible stack heights: 6 vs 0
		//IL_1229->IL0c7e: Incompatible stack heights: 3 vs 0
		//IL_042f->IL0c7e: Incompatible stack heights: 6 vs 0
		//IL_1551->IL0c7e: Incompatible stack heights: 4 vs 0
		//IL_045a->IL0248: Incompatible stack heights: 6 vs 0
		//IL_1295->IL157d: Incompatible stack heights: 4 vs 0
		//IL_0c44->IL1587: Incompatible stack heights: 4 vs 0
		//IL_0ab2->IL0c7e: Incompatible stack heights: 4 vs 0
		//IL_12a9->IL157d: Incompatible stack heights: 4 vs 0
		//IL_087b->IL0c7e: Incompatible stack heights: 4 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+68]");
		_index = 0;
		_type = type;
		_data = baseData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+60]");
		WeaponData weaponData = (WeaponData)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+60]");
		_levelData = (WeaponData)0;
		_page = page;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+78]");
		_isNew = false;
		GameObject gameObject = base.gameObject;
		bool flag3;
		string text;
		if (baseData != null && (object)gameObject != null)
		{
			text = baseData._003Cname_003Ek__BackingField;
			((UnityEngine.Object)gameObject).SetName(baseData._003Cname_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+88]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+88]");
			bool flag = (nint)0 == 0;
			object obj2 = 0;
			if (flag)
			{
				goto IL_0c85;
			}
			if ((object)_EvoText != null)
			{
				GameObject gameObject2 = _EvoText.gameObject;
				if ((object)gameObject2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+80]");
					gameObject2.SetActive(value: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+90]");
					LevelUpPage levelUpPage = (LevelUpPage)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+90]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+80]");
					flag3 = false;
					obj2 = 0;
					if (!flag2)
					{
						bool flag4 = ((UnityEngine.Object)levelUpPage).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+80]");
						flag3 = false;
						obj2 = 0;
						if (!flag4)
						{
							if ((object)_EvoCharacterIcon != null)
							{
								Image evoCharacterIcon = _EvoCharacterIcon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+90]");
								evoCharacterIcon.sprite = (Sprite)0;
								if ((object)_EvoCharacterIcon != null)
								{
									GameObject gameObject3 = _EvoCharacterIcon.gameObject;
									if ((object)gameObject3 != null)
									{
										gameObject3.SetActive(value: true);
										flag3 = true;
										obj2 = 0;
										goto IL_020d;
									}
								}
							}
							goto IL_0c7e;
						}
					}
					goto IL_020d;
				}
			}
		}
		goto IL_0c7e;
		IL_0c85:
		bool flag5 = _type == WeaponType.VOID;
		nint num = unchecked((nint)6603577472L);
		object obj4 = default(object);
		if (!flag5)
		{
			if (_data != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				WeaponData data = _data;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+50]");
				string prefix = data.GetPrefix(WeaponType.VOID);
				string term = prefix + "name";
				if ((object)_Name != null)
				{
					_Name.Term = term;
					WeaponData data2 = _data;
					if (_data != null)
					{
						Sprite sprite = SpriteManager.GetSprite(data2._003CframeName_003Ek__BackingField, data2._003Ctexture_003Ek__BackingField);
						if ((object)_Icon != null)
						{
							_Icon.sprite = sprite;
							LevelUpPage background = (LevelUpPage)(object)_Background;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+58]");
							WeaponType weaponType = WeaponType.VOID;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ r14_v49 (VampireSurvivors.Data.WeaponType)+60]");
							bool flag6 = (nint)0 != 0;
							string hex = "0xffff00";
							if (!flag6)
							{
								hex = "0xffffff";
							}
							Color color = ColourHelper.HexToColor(hex);
							float r = color.r;
							if ((object)_Background != null)
							{
								nint num2 = (nint)background;
								object obj3 = obj4 - 32;
								_ = color.r;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2230 @ rax_v194 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+2A8] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+78]");
								bool num6;
								bool num7;
								bool num8;
								bool num9;
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+50]");
									if ((nint)0 == 24)
									{
										if (weaponData == null)
										{
											goto IL_0c7e;
										}
										_ = weaponData._003Cduration_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189984D76]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+78]");
										if (num3 == 0)
										{
											_ = 1;
										}
										string text2;
										if ((object)weaponData._003Cduration_003Ek__BackingField != null)
										{
											float num4 = (float)obj4 + 100f;
											text2 = ((float*)num4)->ToString();
										}
										else
										{
											text2 = "";
										}
										string message = "Duration : " + text2;
										Debug.Log(message);
									}
									LevelUpPage description = (LevelUpPage)(object)_Description;
									WeaponData levelData2 = weaponData;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+50]");
									string localizedDescriptionForLevel = ((WeaponData)weaponType).GetLocalizedDescriptionForLevel(levelData2, WeaponType.VOID);
									if ((object)_Description != null)
									{
										nint num5 = (nint)description;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v362 @ r9_v46 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+558] (should have been resolved before IL gen)");
										LevelUpPage levelUpPage2 = (LevelUpPage)(object)_New;
										if ((object)_New != null)
										{
											bool flag7 = ((UnityEngine.Object)levelUpPage2).m_CachedPtr == (IntPtr)0;
											num6 = flag7;
											IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)levelUpPage2).m_CachedPtr);
											GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
											if ((object)gameObject4 != null)
											{
												bool flag8 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
												num7 = flag8;
												GameObject.SetActive_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr, false);
												LevelUpPage level = (LevelUpPage)(object)_Level;
												if ((object)_Level != null)
												{
													bool flag9 = ((UnityEngine.Object)level).m_CachedPtr == (IntPtr)0;
													num8 = flag9;
													IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)level).m_CachedPtr);
													GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
													if ((object)gameObject5 != null)
													{
														bool flag10 = ((UnityEngine.Object)gameObject5).m_CachedPtr == (IntPtr)0;
														num9 = flag10;
														GameObject.SetActive_Injected(((UnityEngine.Object)gameObject5).m_CachedPtr, true);
														WeaponType weaponType2 = (WeaponType)_Level;
														_ = 0;
														bool ignoreRTLnumbers = default(bool);
														bool applyParameters = default(bool);
														GameObject localParametersRoot = default(GameObject);
														string overrideLanguage = default(string);
														bool flag11 = LocalizationManager.TryGetTranslation("lang/weapon_level_", out *(string*)(obj4 + 96), FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+60]");
														LevelUpPage levelUpPage3 = (LevelUpPage)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+60]");
														if ((nint)0 == 0 || (nint)((UnityEngine.Object)levelUpPage3).m_CachedPtr <= 0)
														{
															levelUpPage3 = (LevelUpPage)(object)"lang/weapon_level_";
														}
														_ = 0;
														ReadOnlySpan<char> format = (ReadOnlySpan<char>)(obj4 - 32);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+70]");
														int value = (int)((nint)0 + (nint)1);
														string text3 = System.Number.FormatInt32(value, format, null);
														string text4 = (string)(object)levelUpPage3 + text3;
														if ((object)_Level != null)
														{
															num = ((WeaponType*)(int)weaponType2)->value__;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ r9_v40 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+560]");
															object obj2 = 0;
															text = text4;
															LevelUpPage level2 = (LevelUpPage)(object)_Level;
															goto IL_129a;
														}
													}
												}
											}
										}
									}
								}
								else if ((object)_Description != null)
								{
									Localize component = _Description.GetComponent<Localize>();
									if (weaponData != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										WeaponData weaponData2 = weaponData;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+50]");
										string prefix2 = weaponData2.GetPrefix(WeaponType.VOID);
										string term2 = prefix2 + "description";
										if ((object)component != null)
										{
											component.Term = term2;
											LevelUpPage levelUpPage4 = (LevelUpPage)(object)_New;
											if ((object)_New != null)
											{
												bool flag12 = ((UnityEngine.Object)levelUpPage4).m_CachedPtr == (IntPtr)0;
												num6 = flag12;
												IntPtr gcHandlePtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)levelUpPage4).m_CachedPtr);
												GameObject gameObject6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
												if ((object)gameObject6 != null)
												{
													bool flag13 = ((UnityEngine.Object)gameObject6).m_CachedPtr == (IntPtr)0;
													num7 = flag13;
													GameObject.SetActive_Injected(((UnityEngine.Object)gameObject6).m_CachedPtr, true);
													LevelUpPage level3 = (LevelUpPage)(object)_Level;
													if ((object)_Level != null)
													{
														bool flag14 = ((UnityEngine.Object)level3).m_CachedPtr == (IntPtr)0;
														num8 = flag14;
														IntPtr gcHandlePtr4 = Component.get_gameObject_Injected(((UnityEngine.Object)level3).m_CachedPtr);
														GameObject gameObject7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
														if ((object)gameObject7 != null)
														{
															bool flag15 = ((UnityEngine.Object)gameObject7).m_CachedPtr == (IntPtr)0;
															num9 = flag15;
															GameObject.SetActive_Injected(((UnityEngine.Object)gameObject7).m_CachedPtr, false);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+50]");
															bool flag16 = (nint)0 != 77;
															num = unchecked((nint)null);
															text = null;
															object obj2 = 0;
															if (flag16)
															{
																goto IL_0fe1;
															}
															float value2 = weaponData._003Cpower_003Ek__BackingField * 100f;
															LevelUpPage description2 = (LevelUpPage)(object)_Description;
															string description3 = ((WeaponData)weaponType).GetDescription("weaponLevelUp_override_torronasbox1", value2);
															if ((object)_Description != null)
															{
																num = (nint)description2;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ r9_v40 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+560]");
																obj2 = 0;
																text = description3;
																LevelUpPage level2 = (LevelUpPage)(object)_Description;
																goto IL_129a;
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
			goto IL_0c7e;
		}
		goto IL_0fe1;
		IL_0fe1:
		Image icon = _Icon;
		float num10 = UIHelper.JS_MAGIC_SCALE_NUMBER + UIHelper.JS_MAGIC_SCALE_NUMBER;
		if ((object)_Icon != null)
		{
			LevelUpPage sprite2 = (LevelUpPage)(object)icon.m_Sprite;
			if ((object)icon.m_Sprite == null || ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0)
			{
				goto IL_1042;
			}
			if ((object)_Icon != null)
			{
				RectTransform rectTransform = _Icon.rectTransform;
				LevelUpPage icon2 = (LevelUpPage)(object)_Icon;
				if ((object)_Icon != null)
				{
					LevelUpPage luck = (LevelUpPage)(object)icon2._luck;
					if ((object)icon2._luck != null)
					{
						_ = 0;
						bool flag17 = ((UnityEngine.Object)luck).m_CachedPtr == (IntPtr)0;
						object obj5 = obj4 - 48;
						Sprite.get_rect_Injected(((UnityEngine.Object)luck).m_CachedPtr, out *(Rect*)obj5);
						LevelUpPage icon3 = (LevelUpPage)(object)_Icon;
						if ((object)_Icon != null)
						{
							LevelUpPage luck2 = (LevelUpPage)(object)icon3._luck;
							if ((object)icon3._luck != null)
							{
								_ = 0;
								bool flag18 = ((UnityEngine.Object)luck2).m_CachedPtr == (IntPtr)0;
								object obj6 = obj4 - 32;
								Sprite.get_rect_Injected(((UnityEngine.Object)luck2).m_CachedPtr, out *(Rect*)obj6);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp-14]");
								float num11 = 0f * num10;
								if ((object)rectTransform != null)
								{
									bool flag19 = !((WeaponData)(object)rectTransform)._003Chidden_003Ek__BackingField;
									text = (string)(obj4 + 96);
									RectTransform.set_sizeDelta_Injected((IntPtr)(((WeaponData)(object)rectTransform)._003Chidden_003Ek__BackingField ? 1 : 0), ref *(Vector2*)text);
									float num12 = default(float);
									float r = num12;
									goto IL_1042;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0c7e;
		IL_129a:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v359 @ r9_v40 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+558] (should have been resolved before IL gen)");
		goto IL_0fe1;
		IL_020d:
		Image[] evoIcons2 = _EvoIcons;
		bool flag20 = _EvoIcons == null;
		text = (string)flag3;
		LevelUpPage levelUpPage5 = null;
		LevelUpPage levelUpPage6 = null;
		if (flag20)
		{
			goto IL_0c7e;
		}
		while ((nint)levelUpPage5 < evoIcons2.Length)
		{
			LevelUpPage levelUpPage7 = levelUpPage6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r15_v39+18]");
			if ((nint)levelUpPage7 >= 0)
			{
				break;
			}
			Image[] evoIcons3 = _EvoIcons;
			if (_EvoIcons != null)
			{
				bool flag21 = (nint)levelUpPage6 >= evoIcons3.Length;
				WeaponData weaponData3 = (WeaponData)(object)evoIcons3[(object)levelUpPage6];
				if ((object)evoIcons3[(object)levelUpPage6] != null)
				{
					bool flag22 = !weaponData3._003Chidden_003Ek__BackingField;
					IntPtr gcHandlePtr5 = Component.get_gameObject_Injected((IntPtr)(weaponData3._003Chidden_003Ek__BackingField ? 1 : 0));
					GameObject gameObject8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr5);
					if ((object)gameObject8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v310 (UnityEngine.GameObject)+10]");
						bool flag23 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v310 (UnityEngine.GameObject)+10]");
						nint unity_self = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+80]");
						GameObject.SetActive_Injected((IntPtr)unity_self, false);
						Image[] evoIcons4 = _EvoIcons;
						if (_EvoIcons != null)
						{
							bool flag24 = (nint)levelUpPage6 >= evoIcons4.Length;
							LevelUpPage levelUpPage8 = levelUpPage6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r15_v39+18]");
							bool flag25 = (nint)levelUpPage8 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r15_v39+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r15_v39+10]");
							if ((nint)0 != 0)
							{
								LevelUpPage levelUpPage9 = levelUpPage6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rax_v316+18]");
								bool flag26 = (nint)levelUpPage9 >= 0;
								if ((object)evoIcons4[(object)levelUpPage6] != null)
								{
									Image image = evoIcons4[(object)levelUpPage6];
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rax_v316+20+v597 @ rbx_v80 (VampireSurvivors.UI.LevelUpPage)*8]");
									image.sprite = (Sprite)0;
									evoIcons2 = _EvoIcons;
									levelUpPage6 = (LevelUpPage)(levelUpPage6 + 1);
									if (_EvoIcons != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rax_v316+20+v597 @ rbx_v80 (VampireSurvivors.UI.LevelUpPage)*8]");
										text = (string)0;
										object obj2 = 0;
										levelUpPage5 = levelUpPage6;
										continue;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0c7e;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rsp+60]");
		weaponData = (WeaponData)0;
		goto IL_0c85;
		IL_1587:
		LevelUpPage levelUpPage10;
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(levelUpPage10);
		goto IL_0c7e;
		IL_0c7e:
		throw new NullReferenceException();
		IL_1042:
		levelUpPage10 = (LevelUpPage)(object)_Icon;
		if ((object)_Icon != null)
		{
			if (((UnityEngine.Object)levelUpPage10).m_CachedPtr == (IntPtr)0)
			{
				goto IL_1587;
			}
			IntPtr gcHandlePtr6 = Component.get_transform_Injected(((UnityEngine.Object)levelUpPage10).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
			if ((object)transform != null)
			{
				bool flag27 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
				if ((object)transform2 != null)
				{
					Image component2 = transform2.GetComponent<Image>();
					if ((object)component2 != null)
					{
						RectTransform rectTransform2 = component2.rectTransform;
						WeaponData luck3 = (WeaponData)(object)((LevelUpPage)(object)component2)._luck;
						if ((object)((LevelUpPage)(object)component2)._luck != null)
						{
							_ = 0;
							bool flag28 = (byte)(~(luck3._003Chidden_003Ek__BackingField ? 1u : 0u)) != 0;
							object obj8 = obj4 - 32;
							Sprite.get_rect_Injected((IntPtr)(luck3._003Chidden_003Ek__BackingField ? 1 : 0), out *(Rect*)obj8);
							LevelUpPage luck4 = (LevelUpPage)(object)((LevelUpPage)(object)component2)._luck;
							if ((object)((LevelUpPage)(object)component2)._luck != null)
							{
								_ = 0;
								bool flag29 = ((UnityEngine.Object)luck4).m_CachedPtr == (IntPtr)0;
								object obj9 = obj4 - 48;
								Sprite.get_rect_Injected(((UnityEngine.Object)luck4).m_CachedPtr, out *(Rect*)obj9);
								if ((object)rectTransform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v127 (UnityEngine.RectTransform)+10]");
									bool flag30 = (nint)0 == 0;
									object obj10 = obj4 + 96;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v127 (UnityEngine.RectTransform)+10]");
									RectTransform.set_sizeDelta_Injected((IntPtr)0, ref *(Vector2*)obj10);
									if ((object)_Description != null)
									{
										string text5 = _Description.text;
										if (text5 == null || text5._stringLength <= 0)
										{
											Debug.LogWarning("Description NULL... Uh oh");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2731 Invalid \"Jump target not found in method: 0x18720AA40\"");
										LevelUpPage levelUpPage11 = default(LevelUpPage);
										levelUpPage10 = levelUpPage11;
										goto IL_1587;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0c7e;
	}

	private unsafe void HookOnlineCallback()
	{
		//IL_005a: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_0140: Expected O, but got I4
		//IL_00ed: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_0226: Expected O, but got I
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0160: Expected I, but got O
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0375: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_019d: Expected I, but got O
		//IL_01d4: Expected O, but got I
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected I, but got Unknown
		//IL_03cb: Expected I, but got O
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj12;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				num = unchecked((nint)null);
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v6+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_012d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v6+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v10+v437 @ rax_v48*8]");
						if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v6+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_012d;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v10+8+v493 @ rcx_v39*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					goto IL_03a0;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_012d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_03a0;
			IL_03a0:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v498 @ rdx_v13] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = obj14 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v23+10]");
			bool flag3 = (nint)0 == 0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (flag3)
			{
				continue;
			}
			Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> b = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACB30");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v23+30]");
			Delegate obj15 = Delegate.Combine((Delegate)0, b);
			if ((object)obj15 == null)
			{
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj16 == null)
				{
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj17 == null)
				{
					throw new InvalidCastException();
				}
			}
			num = (nint)(obj14 + 48);
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
		}
		throw new NullReferenceException();
	}

	private void OnLevelUpSuggestedCallback(int newSuggestion, int seatNumber, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_002f: Expected O, but got I4
		Image[] onlineSuggestionsIcons = _OnlineSuggestionsIcons;
		GameObject gameObject = onlineSuggestionsIcons[seatNumber].gameObject;
		object obj = _index - newSuggestion;
		bool active = obj == null;
		gameObject.SetActive(active);
		Image[] onlineSuggestionsIcons2 = _OnlineSuggestionsIcons;
		CharacterData currentSkinData = character._currentSkinData;
		Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
		onlineSuggestionsIcons2[seatNumber].sprite = sprite;
	}

	protected unsafe override void OnDestroy()
	{
		//IL_005a: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_0140: Expected O, but got I4
		//IL_00ed: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_0226: Expected O, but got I
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0160: Expected I, but got O
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_037b: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_019d: Expected I, but got O
		//IL_01d4: Expected O, but got I
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected I, but got Unknown
		//IL_03d1: Expected I, but got O
		base.OnDestroy();
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj12;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				num = unchecked((nint)null);
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r10_v6+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_012d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r10_v6+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ r8_v10+v439 @ rax_v48*8]");
						if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r10_v6+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_012d;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ r8_v10+8+v495 @ rcx_v41*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					goto IL_03a6;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_012d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_03a6;
			IL_03a6:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v500 @ rdx_v14] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = obj14 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v23+10]");
			bool flag3 = (nint)0 == 0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (flag3)
			{
				continue;
			}
			Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> value = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACB30");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v23+30]");
			Delegate obj15 = Delegate.Remove((Delegate)0, value);
			if ((object)obj15 == null)
			{
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj16 == null)
				{
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj17 == null)
				{
					throw new InvalidCastException();
				}
			}
			num = (nint)(obj14 + 48);
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
		}
		throw new NullReferenceException();
	}

	public bool IsNew()
	{
		return _isNew;
	}

	public unsafe void DisableSelection()
	{
		//IL_002f: Expected O, but got Ref
		Button component = GetComponent<Button>();
		component.enabled = false;
		Image component2 = GetComponent<Image>();
		object obj = default(object);
		component2.color = (Color)(&obj);
		SelectableUI component3 = GetComponent<SelectableUI>();
		component3.enabled = false;
	}

	public unsafe void EnableSelection()
	{
		//IL_002f: Expected O, but got Ref
		Button component = GetComponent<Button>();
		component.enabled = true;
		Image component2 = GetComponent<Image>();
		object obj = default(object);
		component2.color = (Color)(&obj);
		SelectableUI component3 = GetComponent<SelectableUI>();
		component3.enabled = true;
	}

	public WeaponType GetWeaponType()
	{
		return _type;
	}

	public bool IsFriendshipAmulet()
	{
		//IL_0038: Expected O, but got I4
		if (_itemData == null)
		{
			return false;
		}
		object obj = _itemType - 65;
		return obj == null;
	}

	public unsafe void SetItemData(ItemType type, ItemData data, LevelUpPage page, int index, List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = null)
	{
		//IL_00b4: Expected I, but got O
		//IL_02e8: Expected I, but got O
		//IL_03e1: Expected O, but got Ref
		//IL_098c: Expected I, but got O
		//IL_05da: Expected O, but got I
		//IL_062e: Expected O, but got I
		//IL_065f: Expected O, but got I
		//IL_0690: Expected O, but got I
		//IL_06a0: Expected O, but got I
		//IL_06c7: Expected O, but got I
		//IL_06c7: Expected O, but got I
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Expected O, but got Unknown
		//IL_073b: Expected I, but got O
		//IL_0760->IL0760: Incompatible stack heights: 8 vs 0
		//IL_04d5->IL074a: Incompatible stack heights: 26 vs 24
		//IL_04fc->IL074a: Incompatible stack heights: 26 vs 24
		//IL_0440->IL0440: Incompatible stack heights: 29 vs 24
		//IL_074a->IL04b9: Incompatible stack heights: 41 vs 26
		int index2 = default(int);
		float num2;
		RectTransform rectTransform;
		LevelUpPage luck;
		while (true)
		{
			_index = index2;
			_itemType = type;
			_itemData = data;
			_page = page;
			GameObject gameObject = base.gameObject;
			bool flag = data == null;
			bool flag2 = (object)gameObject == null;
			((UnityEngine.Object)gameObject).SetName(data._003Cname_003Ek__BackingField);
			bool flag3 = (object)_Name == null;
			TextMeshProUGUI component = _Name.GetComponent<TextMeshProUGUI>();
			string localizedName = data.GetLocalizedName(type);
			bool flag4 = (object)component == null;
			nint num = (nint)component;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v928 @ r9_v12 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+558] (should have been resolved before IL gen)");
			Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
			bool flag5 = (object)_Icon == null;
			_Icon.sprite = sprite;
			num2 = UIHelper.JS_MAGIC_SCALE_NUMBER + UIHelper.JS_MAGIC_SCALE_NUMBER;
			bool flag6 = (object)_Icon == null;
			rectTransform = _Icon.rectTransform;
			LevelUpPage icon = (LevelUpPage)(object)_Icon;
			bool flag7 = (object)_Icon == null;
			luck = (LevelUpPage)(object)icon._luck;
			bool flag8 = (object)icon._luck == null;
			if (((UnityEngine.Object)luck).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(icon._luck);
		}
		Sprite.get_rect_Injected(((UnityEngine.Object)luck).m_CachedPtr, out Rect ret);
		LevelUpPage icon2 = (LevelUpPage)(object)_Icon;
		bool flag9 = (object)_Icon == null;
		LevelUpPage luck2 = (LevelUpPage)(object)icon2._luck;
		bool flag10 = (object)icon2._luck == null;
		bool flag11 = ((UnityEngine.Object)luck2).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)luck2).m_CachedPtr, out Rect ret2);
		bool flag12 = (object)rectTransform == null;
		Vector2 sizeDelta = default(Vector2);
		rectTransform.sizeDelta = sizeDelta;
		bool flag13 = (object)_Icon == null;
		Transform transform = _Icon.transform;
		bool flag14 = (object)transform == null;
		Transform parent = transform.parent;
		bool flag15 = (object)parent == null;
		Image component2 = parent.GetComponent<Image>();
		bool flag16 = (object)component2 == null;
		RectTransform rectTransform2 = component2.rectTransform;
		LevelUpPage sprite2 = (LevelUpPage)(object)component2.m_Sprite;
		bool flag17 = (object)component2.m_Sprite == null;
		bool flag18 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret2);
		LevelUpPage sprite3 = (LevelUpPage)(object)component2.m_Sprite;
		bool flag19 = (object)component2.m_Sprite == null;
		bool flag20 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite3).m_CachedPtr, out ret);
		object obj = default(object);
		float num3 = (float)obj * num2;
		bool flag21 = (object)rectTransform2 == null;
		rectTransform2.sizeDelta = sizeDelta;
		LevelUpPage description = (LevelUpPage)(object)_Description;
		string localizedDescription = data.GetLocalizedDescription(type);
		bool flag22 = (object)_Description == null;
		nint num4 = (nint)description;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v301 @ r9_v16 (Il2CppClass<VampireSurvivors.UI.LevelUpPage>)+558] (should have been resolved before IL gen)");
		bool flag23 = (object)_Level == null;
		GameObject gameObject2 = _Level.gameObject;
		bool flag24 = (object)gameObject2 == null;
		gameObject2.SetActive(value: false);
		if (data._003CisSpecialOption_003Ek__BackingField)
		{
			bool flag25 = (object)_Name == null;
			RectTransform component3 = _Name.GetComponent<RectTransform>();
			bool flag26 = (object)component3 == null;
			component3.sizeDelta = sizeDelta;
			bool flag27 = (object)_Background == null;
			_Background.color = (Color)(&ret2);
			bool flag28 = (object)_New == null;
			GameObject gameObject3 = _New.gameObject;
			bool flag29 = (object)gameObject3 == null;
			gameObject3.SetActive(value: false);
			num3 = 23.7f;
		}
		object obj2 = default(object);
		if (obj2 != null)
		{
			bool flag30 = (object)_ItemCharacterIconGroup == null;
			_ItemCharacterIconGroup.SetActive(value: true);
			Image[] itemCharacterIcons = _ItemCharacterIcons;
			bool flag31 = _ItemCharacterIcons == null;
			LevelUpPage levelUpPage = null;
			LevelUpPage levelUpPage2 = null;
			while ((nint)levelUpPage < itemCharacterIcons.Length)
			{
				LevelUpPage levelUpPage3 = levelUpPage2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ stack_30+18]");
				if ((nint)levelUpPage3 >= 0)
				{
					break;
				}
				Image[] itemCharacterIcons2 = _ItemCharacterIcons;
				bool flag32 = _ItemCharacterIcons == null;
				bool flag33 = (nint)levelUpPage2 >= itemCharacterIcons2.Length;
				string text = (string)(object)itemCharacterIcons2[(object)levelUpPage2];
				bool flag34 = (object)itemCharacterIcons2[(object)levelUpPage2] == null;
				bool flag35 = text._stringLength == 0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)text._stringLength);
				GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				bool flag36 = (object)gameObject4 == null;
				bool flag37 = ((ItemData)(object)gameObject4)._003Cname_003Ek__BackingField == null;
				GameObject.SetActive_Injected((IntPtr)((ItemData)(object)gameObject4)._003Cname_003Ek__BackingField, true);
				Image[] itemCharacterIcons3 = _ItemCharacterIcons;
				bool flag38 = _ItemCharacterIcons == null;
				bool flag39 = (nint)levelUpPage2 >= itemCharacterIcons3.Length;
				LevelUpPage levelUpPage4 = levelUpPage2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ stack_30+18]");
				bool flag40 = (nint)levelUpPage4 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ stack_30+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ stack_30+10]");
				bool flag41 = (nint)0 == 0;
				LevelUpPage levelUpPage5 = levelUpPage2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v84+18]");
				bool flag42 = (nint)levelUpPage5 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v84+20+v452 @ rbx_v27 (VampireSurvivors.UI.LevelUpPage)*8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v84+20+v452 @ rbx_v27 (VampireSurvivors.UI.LevelUpPage)*8]");
				bool flag43 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v58+118]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v58+118]");
				bool flag44 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v84+20+v452 @ rbx_v27 (VampireSurvivors.UI.LevelUpPage)*8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1832 @ rdx_v59+118]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v97+48]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1834 @ rax_v99+40]");
				Sprite sprite4 = SpriteManager.GetSprite((string)num5, (string)0);
				bool flag45 = (object)itemCharacterIcons3[(object)levelUpPage2] == null;
				itemCharacterIcons3[(object)levelUpPage2].sprite = sprite4;
				itemCharacterIcons = _ItemCharacterIcons;
				levelUpPage2 = (LevelUpPage)(levelUpPage2 + 1);
				bool flag46 = _ItemCharacterIcons == null;
				num4 = unchecked((nint)null);
				levelUpPage = levelUpPage2;
			}
		}
		HookOnlineCallback();
	}

	public bool IsWeapon()
	{
		//IL_0078: Expected I4, but got O
		if (_type == WeaponType.VOID)
		{
			return false;
		}
		WeaponData data = _data;
		if (_data != null)
		{
			return !data._003CisPowerUp_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsPowerUp()
	{
		//IL_0069: Expected I4, but got O
		if (_type == WeaponType.VOID)
		{
			return false;
		}
		WeaponData data = _data;
		if (_data != null)
		{
			return data._003CisPowerUp_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void SetLimitBreakData(LevelUpPage page, WeightedLimitBreak wlBreak, Equipment e, WeaponData baseWeaponData, WeaponType weaponType, int index)
	{
		//IL_0436: Expected I, but got O
		//IL_0017: Expected I, but got O
		//IL_0027: Expected O, but got I
		//IL_0063: Expected O, but got I
		//IL_014c: Expected O, but got I
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected I4, but got Unknown
		//IL_0172: Expected O, but got Ref
		//IL_01f8: Expected O, but got Ref
		//IL_024c: Expected O, but got Ref
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0622: Expected O, but got Unknown
		//IL_0630->IL067b: Incompatible stack heights: 7 vs 4
		nint num = (nint)typeof(Weapon);
		if ((object)e == null)
		{
			Equipment equipment = null;
			goto IL_0456;
		}
		nint num2 = (nint)e;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v48 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v48 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v155+FFFFFFF8+v63 @ rax_v152*8]");
			if (0 == (nint)typeof(Weapon))
			{
				Equipment equipment = e;
				goto IL_0456;
			}
		}
		throw new InvalidCastException();
		IL_0456:
		int index2 = default(int);
		_index = index2;
		_page = page;
		_wlBreak = wlBreak;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		WeaponData weaponData = default(WeaponData);
		WeaponType wType = default(WeaponType);
		string prefix = weaponData.GetPrefix(wType);
		string term = prefix + "name";
		_Name.Term = term;
		GameObject gameObject = _New.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _Level.gameObject;
		gameObject2.SetActive(value: true);
		int num4 = e._003CLevel_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbp_v17 (VampireSurvivors.Objects.Equipment)+14C]");
		object obj3 = (nint)num4 + (nint)0;
		int value = obj3 + 1;
		float ret = default(float);
		string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&ret), null);
		string text2 = "Level:" + text;
		_Level.text = text2;
		Sprite sprite = SpriteManager.GetSprite(weaponData._003CframeName_003Ek__BackingField, weaponData._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		Color color = ColourHelper.HexToColor("0xffff00");
		_Level.color = (Color)(&ret);
		Image background = _Background;
		bool flag = weaponData._003CisEvolution_003Ek__BackingField;
		string hex = "0xffff00";
		if (!flag)
		{
			hex = "0xffffff";
		}
		Color color2 = ColourHelper.HexToColor(hex);
		background.color = (Color)(&ret);
		RectTransform rectTransform = _Icon.rectTransform;
		Image icon = _Icon;
		Equipment sprite2 = (Equipment)(object)icon.m_Sprite;
		bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect ret2);
		Image icon2 = _Icon;
		Equipment sprite3 = (Equipment)(object)icon2.m_Sprite;
		bool flag3 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite3).m_CachedPtr, out *(Rect*)(&ret));
		Vector2 sizeDelta = default(Vector2);
		rectTransform.sizeDelta = sizeDelta;
		Transform transform = _Icon.transform;
		Transform parent = transform.parent;
		Image component = parent.GetComponent<Image>();
		RectTransform rectTransform2 = component.rectTransform;
		Equipment luck = (Equipment)(object)((LevelUpPage)(object)component)._luck;
		bool flag4 = ((UnityEngine.Object)luck).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)luck).m_CachedPtr, out *(Rect*)(&ret));
		Equipment luck2 = (Equipment)(object)((LevelUpPage)(object)component)._luck;
		bool flag5 = ((UnityEngine.Object)luck2).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)luck2).m_CachedPtr, out ret2);
		rectTransform2.sizeDelta = sizeDelta;
		GameObject gameObject3 = _EvoText.gameObject;
		gameObject3.SetActive(value: false);
		Image[] evoIcons = _EvoIcons;
		Equipment equipment2 = null;
		Equipment equipment3 = null;
		while ((nint)equipment3 < evoIcons.Length)
		{
			bool flag6 = (nint)equipment2 >= evoIcons.Length;
			Equipment equipment4 = (Equipment)(object)evoIcons[(object)equipment2];
			bool flag7 = ((UnityEngine.Object)equipment4).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)equipment4).m_CachedPtr);
			GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			bool flag8 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr, false);
			equipment2 = (Equipment)(equipment2 + 1);
			equipment3 = equipment2;
		}
		TextMeshProUGUI description = _Description;
		string text3 = ParseLimitBreakData(wlBreak.KeyValues);
		description.text = text3;
		_isLimitBreak = true;
		bool flag9 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
		GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
		((UnityEngine.Object)gameObject5).SetName(weaponData._003Cname_003Ek__BackingField);
		HookOnlineCallback();
	}

	public Image GetIcon()
	{
		return _Icon;
	}

	private unsafe string ParseLimitBreakData(LimitBreakData d)
	{
		//IL_04e5: Expected O, but got I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Ref, but got Unknown
		//IL_00cb: Expected F4, but got I
		//IL_05db: Expected O, but got I4
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba0: Expected O, but got Unknown
		//IL_0baa: Unsupported input type for neg.
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected Ref, but got Unknown
		//IL_022e: Expected F4, but got I
		//IL_06d1: Expected O, but got I4
		//IL_0be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bea: Expected O, but got Unknown
		//IL_0bf4: Unsupported input type for neg.
		//IL_0bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf9: Expected O, but got Unknown
		//IL_0500: Expected O, but got I8
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected Ref, but got Unknown
		//IL_0391: Expected F4, but got I
		//IL_0c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Expected O, but got Unknown
		//IL_0c3e: Unsupported input type for neg.
		//IL_0c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c43: Expected O, but got Unknown
		//IL_05f6: Expected O, but got I8
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Ref, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected Ref, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_06ec: Expected O, but got I8
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Ref, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected Ref, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected Ref, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected Ref, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected Ref, but got Unknown
		//IL_07d6: Expected F4, but got I
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Expected Ref, but got Unknown
		//IL_0943: Expected F4, but got I
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a91: Expected Ref, but got Unknown
		//IL_0aa6: Expected F4, but got I
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected Ref, but got Unknown
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Expected Ref, but got Unknown
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_0847: Expected O, but got Unknown
		//IL_097c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Expected Ref, but got Unknown
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Expected Ref, but got Unknown
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae4: Expected Ref, but got Unknown
		//IL_0aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af2: Expected Ref, but got Unknown
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0d: Expected O, but got Unknown
		bool flag = (object)d._003Cpower_003Ek__BackingField == null;
		string result = "";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		object obj = default(object);
		if (!flag)
		{
			string translation = LocalizationManager.GetTranslation("lang/limitBreak_might", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = d._003Cpower_003Ek__BackingField;
			if ((object)d._003Cpower_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			_ = 0;
			ref decimal.DecCalc result2 = ref *(decimal.DecCalc*)(obj - 24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result2);
			_ = 0;
			_ = 10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 24), ref *(decimal.DecCalc*)(obj - 40));
			decimal dec = obj - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			string newValue = UtilityExtensionMethods.DecimalToString(dec);
			result = translation.Replace("%0", newValue);
		}
		if ((object)d._003Carea_003Ek__BackingField != null)
		{
			string translation2 = LocalizationManager.GetTranslation("lang/limitBreak_area", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = d._003Carea_003Ek__BackingField;
			if ((object)d._003Carea_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			_ = 0;
			ref decimal.DecCalc result3 = ref *(decimal.DecCalc*)(obj - 24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result3);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 24), ref *(decimal.DecCalc*)(obj - 40));
			decimal dec2 = obj - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			string newValue2 = UtilityExtensionMethods.DecimalToString(dec2);
			result = translation2.Replace("%0", newValue2);
		}
		if ((object)d._003Cspeed_003Ek__BackingField != null)
		{
			string translation3 = LocalizationManager.GetTranslation("lang/limitBreak_speed", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = d._003Cspeed_003Ek__BackingField;
			if ((object)d._003Cspeed_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			_ = 0;
			ref decimal.DecCalc result4 = ref *(decimal.DecCalc*)(obj - 24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result4);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 24), ref *(decimal.DecCalc*)(obj - 40));
			decimal dec3 = obj - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			string newValue3 = UtilityExtensionMethods.DecimalToString(dec3);
			result = translation3.Replace("%0", newValue3);
		}
		if ((object)d._003Camount_003Ek__BackingField != null)
		{
			string translation4 = LocalizationManager.GetTranslation("lang/limitBreak_amount", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)d._003Camount_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			object obj2 = (object?)d._003Camount_003Ek__BackingField >> 32;
			bool flag2 = (nint)obj2 >= 0;
			object obj3 = 0;
			if (!flag2)
			{
				obj3 = 2147483648L;
			}
			decimal dec4 = obj - 24;
			_ = 0;
			object obj4 = 0 - obj2;
			_ = 0;
			if ((nint)obj2 >= 0)
			{
				obj4 = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			string newValue4 = UtilityExtensionMethods.DecimalToString(dec4);
			result = translation4.Replace("%0", newValue4);
		}
		if ((object)d._003Cpenetrating_003Ek__BackingField != null)
		{
			string translation5 = LocalizationManager.GetTranslation("lang/limitBreak_passes", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)d._003Cpenetrating_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			object obj5 = (object?)d._003Cpenetrating_003Ek__BackingField >> 32;
			bool flag3 = (nint)obj5 >= 0;
			object obj6 = 0;
			if (!flag3)
			{
				obj6 = 2147483648L;
			}
			decimal dec5 = obj - 24;
			_ = 0;
			object obj7 = 0 - obj5;
			_ = 0;
			if ((nint)obj5 >= 0)
			{
				obj7 = obj5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			string newValue5 = UtilityExtensionMethods.DecimalToString(dec5);
			result = translation5.Replace("%0", newValue5);
		}
		if ((object)d._003Cduration_003Ek__BackingField != null)
		{
			string translation6 = LocalizationManager.GetTranslation("lang/limitBreak_duration", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)d._003Cduration_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			object obj8 = (object?)d._003Cduration_003Ek__BackingField >> 32;
			bool flag4 = (nint)obj8 >= 0;
			object obj9 = 0;
			if (!flag4)
			{
				obj9 = 2147483648L;
			}
			decimal dec6 = obj - 24;
			_ = 0;
			object obj10 = 0 - obj8;
			_ = 0;
			if ((nint)obj8 >= 0)
			{
				obj10 = obj8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			string newValue6 = UtilityExtensionMethods.DecimalToString(dec6);
			result = translation6.Replace("%0", newValue6);
		}
		if ((object)d._003Ccooldown_003Ek__BackingField != null)
		{
			string translation7 = LocalizationManager.GetTranslation("lang/limitBreak_cooldown", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = d._003Ccooldown_003Ek__BackingField;
			if ((object)d._003Ccooldown_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			_ = 0;
			ref decimal.DecCalc result5 = ref *(decimal.DecCalc*)(obj - 24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result5);
			_ = 2147483648L;
			_ = 100;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 24), ref *(decimal.DecCalc*)(obj - 40));
			decimal dec7 = obj - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			string newValue7 = UtilityExtensionMethods.DecimalToString(dec7);
			result = translation7.Replace("%0", newValue7);
		}
		if ((object)d._003CcritChance_003Ek__BackingField != null)
		{
			string translation8 = LocalizationManager.GetTranslation("lang/limitBreak_critical", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = d._003CcritChance_003Ek__BackingField;
			if ((object)d._003CcritChance_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			_ = 0;
			ref decimal.DecCalc result6 = ref *(decimal.DecCalc*)(obj - 24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result6);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 24), ref *(decimal.DecCalc*)(obj - 40));
			decimal dec8 = obj - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			string newValue8 = UtilityExtensionMethods.DecimalToString(dec8);
			result = translation8.Replace("%0", newValue8);
		}
		if ((object)d._003Cchance_003Ek__BackingField != null)
		{
			string translation9 = LocalizationManager.GetTranslation("lang/limitBreak_chance", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = d._003Cchance_003Ek__BackingField;
			if ((object)d._003Cchance_003Ek__BackingField == null)
			{
				goto IL_0b56;
			}
			_ = 0;
			ref decimal.DecCalc result7 = ref *(decimal.DecCalc*)(obj - 24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+24]");
			decimal.DecCalc.VarDecFromR4(0f, out result7);
			_ = 0;
			_ = 100;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			decimal.DecCalc.VarDecMul(ref *(decimal.DecCalc*)(obj - 24), ref *(decimal.DecCalc*)(obj - 40));
			decimal dec9 = obj - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-18]");
			_ = 0;
			string newValue9 = UtilityExtensionMethods.DecimalToString(dec9);
			result = translation9.Replace("%0", newValue9);
		}
		return result;
		IL_0b56:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		string result8 = default(string);
		return result8;
	}

	public LevelUpItemUI()
	{
		List<WeaponData> allData = new List<WeaponData>();
		_allData = allData;
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
	}
}
