using System;
using TMPro;
using TS.ColorPicker;
using UnityEngine;

public class CharacterCustomizationMenu : Menu
{
	public static CharacterCustomizationMenu Instance;

	[SerializeField]
	private TextMeshProUGUI p1Text;

	[SerializeField]
	private TextMeshProUGUI p2Text;

	private Color p1Color;

	private Color p2Color;

	private bool isInitialized;

	private ColorPickerPredefined colorPicker;

	private bool IsP1Selected;

	private void Start()
	{
		MenuManager.Instance.MenuOpened += HandleMenuOpened;
		MenuManager.Instance.MenuClosed += HandleMenuClosed;
	}

	private void OnDestroy()
	{
		MenuManager.Instance.MenuOpened -= HandleMenuOpened;
		MenuManager.Instance.MenuClosed -= HandleMenuClosed;
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		if (!isInitialized)
		{
			isInitialized = true;
			p1Color = SaveManager.Instance.GetP1Color();
			p2Color = SaveManager.Instance.GetP2Color();
			UpdateColors();
		}
	}

	protected override void OnClose()
	{
		base.OnClose();
		isInitialized = false;
	}

	public void UpdateColors()
	{
		p1Text.color = p1Color;
		p2Text.color = p2Color;
	}

	public void OnP1ColorClicked()
	{
		IsP1Selected = true;
		MenuManager.Instance.OpenMenu(MenuType.ColorPicker, p1Color);
	}

	public void OnP2ColorClicked()
	{
		IsP1Selected = false;
		MenuManager.Instance.OpenMenu(MenuType.ColorPicker, p2Color);
	}

	private void HandleMenuOpened(Menu menu)
	{
		if (menu.MenuType == MenuType.ColorPicker && menu is ColorPickerPredefined colorPickerPredefined)
		{
			colorPicker = colorPickerPredefined;
			ColorPickerPredefined colorPickerPredefined2 = colorPicker;
			colorPickerPredefined2.OnSubmit = (Action<Color>)Delegate.Combine(colorPickerPredefined2.OnSubmit, new Action<Color>(SetColor));
		}
	}

	private void SetColor(Color color)
	{
		if (IsP1Selected)
		{
			p1Color = color;
		}
		else
		{
			p2Color = color;
		}
		UpdateColors();
	}

	private void HandleMenuClosed(Menu menu)
	{
		if (menu.MenuType == MenuType.ColorPicker && menu is ColorPickerPredefined)
		{
			ColorPickerPredefined colorPickerPredefined = colorPicker;
			colorPickerPredefined.OnSubmit = (Action<Color>)Delegate.Remove(colorPickerPredefined.OnSubmit, new Action<Color>(SetColor));
			colorPicker = null;
		}
	}

	private void SaveColors()
	{
		SaveManager.Instance.SetP1Color(p1Color);
		SaveManager.Instance.SetP2Color(p2Color);
	}

	public void OnConfirmClicked()
	{
		SaveColors();
		PlayerManager.Instance.SetPlayerColors(p1Color, p2Color);
		MenuManager.Instance.CloseCurrentMenu();
	}

	public void OnCancelClicked()
	{
		MenuManager.Instance.CloseCurrentMenu();
	}
}
