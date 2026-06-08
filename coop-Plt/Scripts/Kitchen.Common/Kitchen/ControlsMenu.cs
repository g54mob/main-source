using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class ControlsMenu : ProfileEditorSubmenu
	{
		private ControlRebindElement RebindElement;

		public ControlsMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			RebindElement = ModuleDirectory.Add<ControlRebindElement>(Container);
			RebindElement.Setup(player_id, display_only: false, show_panel: false, ModuleList);
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestAction(ProfileMenuAction.Back);
			}, 0, 0.75f);
		}
	}
}
