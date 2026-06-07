using System.Collections.Generic;

public class MenuPanelEqualityComparer : IEqualityComparer<MenuPanelType>
{
	public bool Equals(MenuPanelType a, MenuPanelType b)
	{
		return a == b;
	}

	public int GetHashCode(MenuPanelType obj)
	{
		return (int)obj;
	}
}
