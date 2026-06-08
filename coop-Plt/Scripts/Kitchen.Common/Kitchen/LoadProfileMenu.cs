using System.Collections.Generic;
using System.Linq;
using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class LoadProfileMenu : ProfileEditorSubmenu
	{
		private Option<ProfileIdentifier> Profiles;

		public LoadProfileMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			List<ProfileIdentifier> list = ProfileStore.Main.AvailableProfiles();
			Profiles = new Option<ProfileIdentifier>(list, default(ProfileIdentifier), list.Select((ProfileIdentifier p) => p.ToString()).ToList());
			AddSelect(Profiles).OnOptionChosen += SelectProfile;
			New<SpacerElement>();
			AddButton(base.Localisation["CANCEL_PROFILE"], delegate
			{
				RequestAction(ProfileMenuAction.Back);
			}, 0, 0.75f);
		}

		private void SelectProfile(int i)
		{
			SelectProfile(Profiles.GetOption(i));
		}

		private void SelectProfile(ProfileIdentifier p)
		{
			if (PlayerID != 0 && ProfileStore.Main.AvailableProfiles().Contains(p))
			{
				Players.Main.SetActiveProfile(PlayerID, p);
				RequestAction(ProfileMenuAction.Back);
			}
			else
			{
				RequestAction(ProfileMenuAction.Back);
			}
		}
	}
}
