using System;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class WeaponSelectionItemUI : SelectableUI
{
	private TextMeshProUGUI _Name;

	private Image _Icon;

	private Image _BanishedIcon;

	private Image _BackgroundImage;

	private WeaponType _type;

	private WeaponData _data;

	private BaseWeaponSelectionPage _page;

	private Button _button;

	public void SetData(BaseWeaponSelectionPage page, WeaponType t, WeaponData d)
	{
		_data = d;
		_type = t;
		_page = page;
		Button component = GetComponent<Button>();
		_button = component;
		Button button = _button;
		UnityAction call = SelectButton;
		button.m_OnClick.AddListener(call);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = _data.GetPrefix(_type);
		string term = prefix + "name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_Name.text = translation;
		WeaponData data = _data;
		Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		GameManager core = GM.Core;
		bool flag = core._levelUpFactory.IsBanished(t);
		_BanishedIcon.enabled = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		if (flag)
		{
			_BanishedIcon.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 505 Invalid \"Jump target not found in method: 0x186E01330\"");
		throw new NullReferenceException();
	}

	protected override void OnSelected()
	{
		_page.SetSelected(this);
	}

	public WeaponType GetWeaponType()
	{
		return _type;
	}

	public void DisableButton()
	{
		_button.interactable = false;
	}

	private void SelectButton()
	{
		_page.SelectWeapon(this);
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

	public WeaponSelectionItemUI()
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
