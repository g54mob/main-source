using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class AdventureInfoPanel : MonoBehaviour
{
	private GameObject SpritePrefab;

	private MultipleLineHorizontalList CharacterContainer;

	private MultipleLineHorizontalList WeaponContainer;

	private AdventureData _currentData;

	private AdventureType _currentType;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private bool _shouldUpdateFormatting;

	private void Construct(DataManager data, PlayerOptions player)
	{
		_data = data;
		_playerOptions = player;
	}

	public unsafe void SetData(AdventureType type)
	{
		//IL_01df: Expected O, but got Ref
		//IL_02ac: Expected F4, but got I4
		//IL_02b5: Expected I4, but got O
		//IL_0318: Expected O, but got I
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_039c: Expected O, but got I4
		//IL_064a: Expected F4, but got I4
		//IL_03ed: Expected O, but got I
		//IL_0446: Expected O, but got I
		//IL_06ae: Expected O, but got I
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_04d1: Expected O, but got I
		//IL_04d1: Expected O, but got I
		//IL_073b: Expected O, but got I
		//IL_0774: Expected O, but got I
		//IL_0540: Expected I4, but got O
		//IL_0ca5: Expected I4, but got O
		//IL_07cf: Expected O, but got I
		//IL_07cf: Expected O, but got I
		//IL_0a8b: Expected O, but got Ref
		//IL_05db: Expected I4, but got O
		//IL_08c6: Expected O, but got Ref
		//IL_0b09->IL0906: Incompatible stack heights: 3 vs 0
		//IL_0637->IL0906: Incompatible stack heights: 3 vs 0
		//IL_05e0->IL0ab3: Incompatible stack heights: 18 vs 0
		//IL_05c2->IL0a7e: Incompatible stack heights: 18 vs 17
		//IL_08d9->IL0c5a: Incompatible stack heights: 14 vs 3
		//IL_08b4->IL0c5a: Incompatible stack heights: 15 vs 3
		//IL_08b9->IL08b9: Incompatible stack heights: 15 vs 14
		_currentType = type;
		DataManager data = _data;
		if (_data != null && data._003CAllAdventures_003Ek__BackingField != null)
		{
			object currentData = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllAdventures_003Ek__BackingField).get_Item((System.Int32Enum)type);
			_currentData = (AdventureData)currentData;
			if ((object)CharacterContainer != null)
			{
				CharacterContainer.Clear();
				if ((object)WeaponContainer != null)
				{
					WeaponContainer.Clear();
					RectTransform component = GetComponent<RectTransform>();
					Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
					if ((object)WeaponContainer != null)
					{
						RectTransform component2 = WeaponContainer.GetComponent<RectTransform>();
						Extensions.RefreshLayoutGroupsImmediateAndRecursive(component2);
						Canvas.ForceUpdateCanvases();
						PlayerOptions playerOptions = _playerOptions;
						if (_playerOptions != null)
						{
							PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
							if (playerOptions._mainGameConfig != null && mainGameConfig._003CAdventuresSaveData_003Ek__BackingField != null)
							{
								System.ParamsArray ret;
								System.ParamsArray ret2 = default(System.ParamsArray);
								if (!((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).TryGetValue((System.Int32Enum)type, out object value))
								{
									AdventureType adventureType = default(AdventureType);
									object arg = adventureType;
									ret = new System.ParamsArray(arg);
									string message = string.FormatHelper((IFormatProvider)null, "Progress data for {0} could not be found in the main game config", (System.ParamsArray)(&ret2));
									Debug.LogWarning(message);
								}
								if (_data != null)
								{
									Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
									if (_data != null)
									{
										Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
										AdventureData currentData2 = _currentData;
										if (_currentData != null && currentData2._003CCharacterTypes_003Ek__BackingField != null)
										{
											float num = 0f;
											AdventureType adventureType2 = (AdventureType)convertedCharacterData;
											object obj = default(object);
											object obj2 = default(object);
											object obj4 = default(object);
											object obj10 = default(object);
											List<CharacterType> value2 = default(List<CharacterType>);
											object obj11 = default(object);
											RectTransform rectTransform2 = default(RectTransform);
											while (true)
											{
												bool flag = obj == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-D8_v57+1C]");
												if (obj2 != null)
												{
													break;
												}
												object obj3 = obj4;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-D8_v57+18]");
												if ((nint)obj3 >= 0)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-D8_v57+10]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-D8_v57+10]");
												bool flag2 = (nint)0 == 0;
												object obj6 = obj4;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rdx_v113+18]");
												if ((nint)obj6 < 0)
												{
													obj4++;
													bool flag3 = adventureType2 == AdventureType.ADV_LMS_001;
													AdventureType num2 = adventureType2;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rdx_v113+20+v2327 @ rcx_v151*4]");
													object obj7 = ((Dictionary<System.Int32Enum, object>)num2).get_Item((System.Int32Enum)0);
													bool flag4 = obj7 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2058 @ rax_v220 (System.Object)+18]");
													bool flag5 = (nint)0 <= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2058 @ rax_v220 (System.Object)+10]");
													object obj8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2058 @ rax_v220 (System.Object)+10]");
													bool flag6 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v221+18]");
													if ((nint)0 > (nint)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v221+20]");
														object obj9 = 0;
														bool flag7 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
														IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
														GameObject gameObject = UnityEngine.Object.Instantiate(parent: UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr), original: SpritePrefab);
														bool flag8 = (object)gameObject == null;
														Image component3 = gameObject.GetComponent<Image>();
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v221+20]");
														bool flag9 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r14_v61 (System.Object)+48]");
														nint num3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r14_v61 (System.Object)+40]");
														Sprite sprite = SpriteManager.GetSprite((string)num3, (string)0);
														bool flag10 = (object)component3 == null;
														component3.sprite = sprite;
														Image component4 = gameObject.GetComponent<Image>();
														bool flag11 = (object)component4 == null;
														RectTransform rectTransform = component4.rectTransform;
														AdventureType adventureType3 = (AdventureType)component4.m_Sprite;
														bool flag12 = (object)component4.m_Sprite == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rbx_v69 (VampireSurvivors.Data.AdventureType)+10]");
														bool flag13 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rbx_v69 (VampireSurvivors.Data.AdventureType)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
														AdventureType adventureType4 = (AdventureType)component4.m_Sprite;
														bool flag14 = (object)component4.m_Sprite == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rbx_v70 (VampireSurvivors.Data.AdventureType)+10]");
														bool flag15 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rbx_v70 (VampireSurvivors.Data.AdventureType)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret2));
														num = UIHelper.JS_MAGIC_SCALE_NUMBER * (float)obj10;
														bool flag16 = (object)rectTransform == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1518 @ rax_v234 (UnityEngine.RectTransform)+10]");
														bool flag17 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1518 @ rax_v234 (UnityEngine.RectTransform)+10]");
														RectTransform.set_sizeDelta_Injected((IntPtr)0, ref *(Vector2*)(&value2));
														bool num4;
														if (value != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ stack_20_v57 (System.Object)+170]");
															bool flag18 = (nint)0 == 0;
															num4 = flag18;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
															if (obj11 == null)
															{
																goto IL_05c2;
															}
														}
														component4.color = (Color)(&value2);
														rectTransform2 = component4.rectTransform;
														bool flag19 = (object)CharacterContainer == null;
														num4 = flag19;
														goto IL_05c2;
													}
													throw new IndexOutOfRangeException();
												}
												throw new IndexOutOfRangeException();
												IL_05c2:
												CharacterContainer.AddNewItem(rectTransform2);
												adventureType2 = (AdventureType)convertedCharacterData;
											}
											bool flag20 = obj == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-D8_v57+1C]");
											bool flag21 = obj2 != null;
											AdventureData currentData3 = _currentData;
											if (_currentData != null)
											{
												List<WeaponType> list = currentData3._003CWeaponTypes_003Ek__BackingField;
												if (currentData3._003CWeaponTypes_003Ek__BackingField != null)
												{
													float num5 = 0f;
													object obj12 = default(object);
													object obj13 = default(object);
													object obj15 = default(object);
													List<WeaponType> value3 = default(List<WeaponType>);
													object obj22 = default(object);
													object obj23 = default(object);
													while (true)
													{
														bool flag22 = obj12 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2470 @ stack_-110_v30+1C]");
														if (obj13 != null)
														{
															break;
														}
														object obj14 = obj15;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2470 @ stack_-110_v30+18]");
														if ((nint)obj14 >= 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2470 @ stack_-110_v30+10]");
														object obj16 = 0;
														object obj17 = obj15;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2526 @ rdx_v93+18]");
														bool flag23 = (nint)obj17 >= 0;
														object obj18 = obj15 + 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2526 @ rdx_v93+20+v2465 @ stack_-108_v28*4]");
														object obj19 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3866 @ rax_v163 (System.Object)+18]");
														bool flag24 = (nint)0 <= (nint)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3866 @ rax_v163 (System.Object)+10]");
														object obj20 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2696 @ rax_v164+18]");
														bool flag25 = (nint)0 <= (nint)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2696 @ rax_v164+20]");
														object obj21 = 0;
														bool flag26 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
														IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
														GameObject gameObject2 = UnityEngine.Object.Instantiate(parent: UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2), original: SpritePrefab);
														Image component5 = gameObject2.GetComponent<Image>();
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2715 @ rsi_v60+40]");
														nint num6 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2715 @ rsi_v60+38]");
														Sprite sprite2 = SpriteManager.GetSprite((string)num6, (string)0);
														component5.sprite = sprite2;
														Image component6 = gameObject2.GetComponent<Image>();
														RectTransform rectTransform3 = component6.rectTransform;
														object sprite3 = component6.m_Sprite;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2793 @ rdi_v63 (System.Object)+10]");
														bool flag27 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2793 @ rdi_v63 (System.Object)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret2));
														object sprite4 = component6.m_Sprite;
														bool flag28 = (object)component6.m_Sprite == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2934 @ rdi_v64 (System.Object)+10]");
														bool flag29 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2934 @ rdi_v64 (System.Object)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
														float num7 = UIHelper.JS_MAGIC_SCALE_NUMBER;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2522 @ r9_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
														float num8 = num7 * 0f;
														num5 = num8 * 1.5f;
														bool flag30 = (object)rectTransform3 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4480 @ rax_v177 (UnityEngine.RectTransform)+10]");
														bool flag31 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4480 @ rax_v177 (UnityEngine.RectTransform)+10]");
														RectTransform.set_sizeDelta_Injected((IntPtr)0, ref *(Vector2*)(&value3));
														RectTransform rectTransform4 = component6.rectTransform;
														bool flag32 = (object)WeaponContainer == null;
														WeaponContainer.AddNewItem(rectTransform4);
														if (value != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ stack_20_v57 (System.Object)+168]");
															bool flag33 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
															bool flag34 = obj22 != null;
															obj15 = obj18;
															list = null;
															if (flag34)
															{
																continue;
															}
														}
														component6.color = (Color)(&obj23);
														obj15 = obj18;
														list = null;
													}
													bool flag35 = obj12 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2470 @ stack_-110_v30+1C]");
													bool flag36 = obj13 != null;
													_shouldUpdateFormatting = true;
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

	public void Hide()
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		component.alpha = 0f;
		component.blocksRaycasts = false;
		component.interactable = false;
	}

	public void Show()
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		component.alpha = 1f;
		component.blocksRaycasts = true;
		component.interactable = true;
	}

	private void LateUpdate()
	{
		//IL_00bd: Expected I, but got O
		if (_shouldUpdateFormatting)
		{
			_shouldUpdateFormatting = false;
			RectTransform component = GetComponent<RectTransform>();
			Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
			Transform transform = WeaponContainer.transform;
			Transform parent = transform.parent;
			RectTransform component2 = parent.GetComponent<RectTransform>();
			Extensions.RefreshLayoutGroupsImmediateAndRecursive(component2);
			Transform transform2 = CharacterContainer.transform;
			Transform parent2 = transform2.parent;
			RectTransform component3 = parent2.GetComponent<RectTransform>();
			Extensions.RefreshLayoutGroupsImmediateAndRecursive(component3);
			Canvas.ForceUpdateCanvases();
			nint num = (nint)typeof(UIHelper);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v15 (Il2CppClass<VampireSurvivors.UI.UIHelper>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
	}

	public AdventureInfoPanel()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
