using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class AccountDetailUI : MonoBehaviour, IUIObject, ISelectableUI
{
	private Image _Icon;

	private TextMeshProUGUI _Account;

	private TextMeshProUGUI _Detail;

	private TextMeshProUGUI _ButtonLabel;

	private Button _Button;

	public void SetAccountText(string text)
	{
		_Account.text = text;
	}

	public void SetDetailText(string text)
	{
		_Detail.text = text;
	}

	public void SetButtonLabel(string text)
	{
		_ButtonLabel.text = text;
		((UnityEngine.Object)_Button).SetName(text);
	}

	public void SetButtonCallback(Action cb)
	{
		Button button = _Button;
		UnityAction call = cb.Invoke;
		button.m_OnClick.AddListener(call);
	}

	public unsafe void SetLinkedIcon(bool linked)
	{
		//IL_00a5: Expected O, but got Ref
		Image icon;
		if (!linked)
		{
			Sprite sprite = SpriteManager.GetSprite("no16", "UI.png");
			_Icon.sprite = sprite;
			icon = _Icon;
		}
		else
		{
			Sprite sprite2 = SpriteManager.GetSprite("menu_checkbox_24_checkmark", "UI.png");
			_Icon.sprite = sprite2;
			icon = _Icon;
		}
		object obj = default(object);
		icon.color = (Color)(&obj);
	}

	public void RemoveButton()
	{
		GameObject gameObject = _Button.gameObject;
		gameObject.SetActive(value: false);
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public Selectable GetSelectable()
	{
		return _Button;
	}

	public unsafe void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_Button.navigation = (Navigation)(&obj);
	}

	public AccountDetailUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
