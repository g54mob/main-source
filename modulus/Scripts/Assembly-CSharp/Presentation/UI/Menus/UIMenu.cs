using Data.Operator;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.Menus
{
	public abstract class UIMenu : MonoBehaviour
	{
		public bool UIMenuIsStacked { get; set; }

		public virtual void ShowMenu(FactoryObjectUIData factoryObjectUIData)
		{
		}

		public abstract void ShowMenu(AbstractUIMenuData menuData);

		public abstract void HideMenu();
	}
}
