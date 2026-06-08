using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class SelectProfileMenu : ProfileEditorSubmenu
	{
		public SelectProfileMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			bool selectable = ProfileStore.Main.AvailableProfiles().Count > 0;
			AddButton(base.Localisation["NEW_PROFILE"], delegate
			{
				OpenNewProfile();
			});
			AddSubmenuButton(base.Localisation["LOAD_PROFILE"], typeof(LoadProfileMenu)).SetSelectable(selectable);
			New<SpacerElement>();
			AddButton(base.Localisation["CANCEL_PROFILE"], delegate
			{
				RequestAction(ProfileMenuAction.Back);
			}, 0, 0.75f);
		}

		private void OpenNewProfile()
		{
			TextInputView.RequestTextInput(base.Localisation["NEW_PROFILE_PROMPT"], "", 20, CreateProfile);
			RequestAction(ProfileMenuAction.Close);
		}

		private void CreateProfile(TextInputView.TextInputState result, string name)
		{
			if (PlayerID == 0)
			{
				return;
			}
			ProfileIdentifier profileIdentifier = ((name == "") ? ProfileIdentifier.Default : ((ProfileIdentifier)name));
			if (result == TextInputView.TextInputState.TextEntryComplete)
			{
				if (!ProfileAccessor.CreateAndActivateProfile(PlayerID, profileIdentifier))
				{
					Debug.LogWarning("Tried to create profile with duplicate name");
				}
				else
				{
					RequestAction(ProfileMenuAction.Close);
				}
			}
		}
	}
}
