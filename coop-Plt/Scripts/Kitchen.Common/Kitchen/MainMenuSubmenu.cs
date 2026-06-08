using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public abstract class MainMenuSubmenu : Menu<MenuAction>
	{
		protected MainMenuSubmenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}
	}
}
