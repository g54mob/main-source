using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class TextEntryMainMenu : Menu<MenuAction>
	{
		public TextEntryMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
		}
	}
}
