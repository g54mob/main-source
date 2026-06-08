using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class CreditsMainMenu : MainMenuSubmenu
	{
		public override bool RequiresBackingPanel => false;

		public CreditsMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			New<CreditsElement>();
			AddActionButton(base.Localisation["MAIN_MENU_BACK"], MainMenuAction.Back, ElementStyle.MainMenuBack);
		}
	}
}
