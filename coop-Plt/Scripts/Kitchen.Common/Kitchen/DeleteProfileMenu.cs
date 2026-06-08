using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class DeleteProfileMenu : ProfileEditorSubmenu
	{
		public DeleteProfileMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			AddButton(base.Localisation["PROFILE_CONFIRM_DELETE"], delegate
			{
				DeleteMyProfile();
			});
			New<SpacerElement>();
			AddButton(base.Localisation["CANCEL_PROFILE"], delegate
			{
				RequestAction(ProfileMenuAction.Back);
			}, 0, 0.75f);
		}

		private void DeleteMyProfile()
		{
			if (Players.Main.TryGetActiveProfile(PlayerID, out var identifier))
			{
				ProfileStore.Main.Delete(identifier);
				Players.Main.SetActiveProfile(PlayerID, ProfileIdentifier.Default);
				RequestAction(ProfileMenuAction.Back);
			}
		}
	}
}
