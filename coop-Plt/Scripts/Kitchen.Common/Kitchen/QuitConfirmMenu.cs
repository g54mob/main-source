using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class QuitConfirmMenu : Menu<MenuAction>
	{
		public QuitConfirmMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			AddButton(base.Localisation["MENU_QUIT"], delegate
			{
				RequestAction(PauseMenuAction.Quit);
			});
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestAction(PauseMenuAction.Back);
			});
		}
	}
}
