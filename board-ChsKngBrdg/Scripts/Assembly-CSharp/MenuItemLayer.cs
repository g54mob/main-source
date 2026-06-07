using System;
using System.Collections.Generic;

[Serializable]
public class MenuItemLayer
{
	public MenuItem parentMenuItem;

	public List<MenuItem> menuItems;

	public MenuItemLayer(MenuItem parentMenuItem, List<MenuItem> menuItems)
	{
		this.parentMenuItem = parentMenuItem;
		this.menuItems = menuItems;
	}
}
