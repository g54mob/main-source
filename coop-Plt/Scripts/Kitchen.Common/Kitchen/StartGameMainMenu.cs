using System.Collections.Generic;
using System.Linq;
using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public abstract class StartGameMainMenu : MainMenuSubmenu
	{
		protected int PlayerID;

		protected Option<ProfileIdentifier> Profiles;

		protected int CreateNewProfileIndex;

		private ProfileIdentifier AddNewPlaceholder = (ProfileIdentifier)"ADD_NEW";

		protected StartGameMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			PlayerID = player_id;
			ProfileStore.Main.Load();
			List<ProfileIdentifier> list = ProfileStore.Main.AvailableProfiles();
			list.Add(AddNewPlaceholder);
			CreateNewProfileIndex = list.Count - 1;
			List<string> list2 = list.Select((ProfileIdentifier p) => p.ToString()).ToList();
			list2[CreateNewProfileIndex] = base.Localisation["NEW_PROFILE"];
			Profiles = new Option<ProfileIdentifier>(list, (Session.RetainedPlayers.Count > 0) ? Session.RetainedPlayers[0].PlayerProfile : list[0], list2, (ProfileIdentifier p1, ProfileIdentifier p2) => (!(p1 == p2)) ? 1 : 0);
		}

		protected void AddProfileSelector()
		{
			AddLabel(base.Localisation["MENU_LABEL_PROFILE_CHOICE"]);
			AddInfo(base.Localisation["MENU_PROFILE_DESCRIPTION"]);
			SelectElement selectElement = AddSelect(Profiles);
			selectElement.OnOptionHighlighted += SelectProfile;
			selectElement.OnOptionChosen += AttemptCreateProfile;
			SelectProfile(Profiles.Chosen);
		}

		private void AttemptCreateProfile(int i)
		{
			if (i == CreateNewProfileIndex)
			{
				RequestSubMenu(typeof(TextEntryMainMenu), skip_stack: true);
				TextInputView.RequestTextInput(base.Localisation["NEW_PROFILE_PROMPT"], "", 20, CreateProfile);
			}
		}

		private void SelectProfile(int i)
		{
			if (i != CreateNewProfileIndex)
			{
				SelectProfile(Profiles.GetOption(i));
			}
		}

		protected void SelectProfile(ProfileIdentifier profile_identifier)
		{
			Session.RetainedPlayers = new List<RetainedPlayer>
			{
				new RetainedPlayer
				{
					PlayerProfile = profile_identifier,
					InputPlayerID = PlayerID
				}
			};
		}

		private void CreateProfile(TextInputView.TextInputState result, string name)
		{
			ProfileIdentifier profileIdentifier = (ProfileIdentifier)name;
			bool flag = false;
			if (result == TextInputView.TextInputState.TextEntryComplete)
			{
				PlayerProfile base_profile = PlayerProfile.Default;
				base_profile.RequiresTutorial = true;
				if (ProfileAccessor.CreateProfile(profileIdentifier, base_profile))
				{
					Session.RetainedPlayers = new List<RetainedPlayer>
					{
						new RetainedPlayer
						{
							PlayerProfile = profileIdentifier,
							InputPlayerID = PlayerID
						}
					};
					flag = true;
				}
				else
				{
					Debug.LogWarning("Failed to create a profile");
				}
			}
			if (flag)
			{
				RequestSubMenu(GetType(), skip_stack: true);
			}
			else if (result != TextInputView.TextInputState.TextEntryCancelled)
			{
				TextInputView.RequestTextInput(base.Localisation["INPUT_TITLE_NEW_PROFILE"], profileIdentifier, 20, CreateProfile);
			}
			else
			{
				RequestSubMenu(GetType(), skip_stack: true);
			}
		}
	}
}
