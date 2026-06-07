using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;

public class ManualUI : UIMenu
{
	public override void ShowMenu(AbstractUIMenuData menuData)
	{
		base.gameObject.SetActive(value: true);
	}

	public override void HideMenu()
	{
		base.gameObject.SetActive(value: false);
	}
}
