using Controllers;
using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class ManageProfileMenu : ProfileEditorSubmenu
	{
		public ManageProfileMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			ButtonElement buttonElement = AddSubmenuButton(base.Localisation["PROFILE_REBIND"], typeof(ControlsMenu));
			if (!InputSourceIdentifier.DefaultInputSource.CanPerformRebinding(player_id))
			{
				buttonElement.SetSelectable(selectable: false);
			}
			AddSubmenuButton(base.Localisation["PROFILE_CHANGE"], typeof(SelectProfileMenu));
			AddSubmenuButton(base.Localisation["PROFILE_DELETE"], typeof(DeleteProfileMenu));
			New<SpacerElement>();
			AddButton(base.Localisation["CANCEL_PROFILE"], delegate
			{
				RequestAction(ProfileMenuAction.Back);
			}, 0, 0.75f);
		}
	}
}
