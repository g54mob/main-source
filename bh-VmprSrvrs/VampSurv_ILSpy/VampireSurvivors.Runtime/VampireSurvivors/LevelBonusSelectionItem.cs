using System;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Graphics;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class LevelBonusSelectionItem : SelectableUI
{
	private TextMeshProUGUI _Name;

	private Image _Icon;

	private PowerUpType _type;

	private PowerUpData _data;

	private LevelBonusSelectionPage _page;

	private Button _button;

	public unsafe void SetData(LevelBonusSelectionPage page, PowerUpType t, PowerUpData d)
	{
		//IL_01a6: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_01d7: Expected O, but got Ref
		_type = t;
		_page = page;
		_data = d;
		Button component = GetComponent<Button>();
		_button = component;
		Button button = _button;
		UnityAction call = ClickButton;
		button.m_OnClick.AddListener(call);
		string term = "powerUpLang/{" + d._003CbulletType_003Ek__BackingField + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string newValue;
		if (translation != null && translation._stringLength > 0)
		{
			if (translation._stringLength <= 0)
			{
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				return;
			}
			char firstChar = char.ToUpper(translation._firstChar);
			string text = string.FastAllocateString(1);
			text._firstChar = firstChar;
			int length = translation._stringLength - 1;
			string text2 = translation.Substring(1, length);
			string text3 = text + text2;
			newValue = text3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rax_v36+B8]");
			object obj2 = 0;
			newValue = (string)obj2;
		}
		string translation2 = LocalizationManager.GetTranslation("lang/bonusSelection_BonusExplanation", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		object obj3 = default(object);
		string newValue2 = System.Number.FormatInt32(1, (ReadOnlySpan<char>)(&obj3), null);
		string text4 = translation2.Replace("%0", newValue2);
		string text5 = text4.Replace("%1", newValue);
		_Name.text = text5;
		PowerUpData data = _data;
		Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 545 Invalid \"Jump target not found in method: 0x187208E20\"");
		throw new NullReferenceException();
	}

	private string UppercaseFirst(string s)
	{
		//IL_00f7: Expected O, but got I
		//IL_0107: Expected O, but got I
		if (s != null && s._stringLength > 0)
		{
			if (s._stringLength > 0)
			{
				char firstChar = char.ToUpper(s._firstChar);
				string text = string.FastAllocateString(1);
				text._firstChar = firstChar;
				int length = s._stringLength - 1;
				string text2 = s.Substring(1, length);
				return text + text2;
			}
			System.ThrowHelper.ThrowIndexOutOfRangeException();
			string result = default(string);
			return result;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v1+B8]");
		return (string)0;
	}

	public void DisableButton()
	{
		_button.interactable = false;
	}

	protected override void OnSelected()
	{
		LevelBonusSelectionPage page = _page;
		page._currentSelected = this;
		LevelBonusSelectionItem currentSelected = page._currentSelected;
		page._currentType = currentSelected._type;
	}

	public PowerUpType GetPowerUpType()
	{
		return _type;
	}

	private void ClickButton()
	{
		_page.ConfirmBonus(this);
	}

	private void SetIconSize()
	{
		//IL_0219->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_026d->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0102->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_012c->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0156->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0192->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_02d2->IL01b9: Incompatible stack heights: 3 vs 0
		//IL_031f->IL01b9: Incompatible stack heights: 4 vs 0
		if ((object)_Icon != null)
		{
			RectTransform rectTransform = _Icon.rectTransform;
			Image icon = _Icon;
			if ((object)_Icon != null)
			{
				Image sprite = (Image)(object)icon.m_Sprite;
				if ((object)icon.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image icon2 = _Icon;
					if ((object)_Icon != null)
					{
						object sprite2 = icon2.m_Sprite;
						if ((object)icon2.m_Sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v13 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v13 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								if ((object)_Icon != null)
								{
									Transform transform = _Icon.transform;
									if ((object)transform != null)
									{
										Transform parent = transform.parent;
										if ((object)parent != null)
										{
											Image component = parent.GetComponent<Image>();
											if ((object)component != null)
											{
												RectTransform rectTransform2 = component.rectTransform;
												object sprite3 = component.m_Sprite;
												if ((object)component.m_Sprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v14 (System.Object)+10]");
													bool flag3 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v14 (System.Object)+10]");
													Sprite.get_rect_Injected((IntPtr)0, out ret2);
													Image sprite4 = (Image)(object)component.m_Sprite;
													if ((object)component.m_Sprite != null)
													{
														bool flag4 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
														Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out ret);
														if ((object)rectTransform2 != null)
														{
															rectTransform2.sizeDelta = sizeDelta;
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

	public LevelBonusSelectionItem()
	{
		//IL_0036: Expected I, but got O
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
