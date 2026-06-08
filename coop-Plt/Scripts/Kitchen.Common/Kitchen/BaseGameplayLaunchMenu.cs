using System.Collections.Generic;
using System.Linq;
using Controllers;
using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Platforms;
using Platforms.PlatformDebugConfigurations;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen
{
	public abstract class BaseGameplayLaunchMenu : Menu<MenuAction>
	{
		protected int PlayerID;

		protected Option<ProfileIdentifier> Profiles;

		protected int CreateNewProfileIndex;

		protected ProfileIdentifier AddNewPlaceholder = (ProfileIdentifier)"ADD_NEW";

		protected ButtonElement StartGame;

		protected ButtonElement JoinViaCodeButton;

		protected ButtonElement CopyJoinCodeButton;

		protected bool ShowJoinViaCode
		{
			get
			{
				if (PlatformSettings.AllowJoinCodes || DebugConfig.Generic.ForceAllowJoinCodes)
				{
					return NetworkServices.HasAvailableJoinCodePlatform();
				}
				return false;
			}
		}

		protected virtual bool ShowCopyJoinCode
		{
			get
			{
				if (ShowJoinViaCode)
				{
					return !Session.GetInvite().AsJoinCode().IsNullOrWhitespace();
				}
				return false;
			}
		}

		protected bool CanStartHasProfileSelected
		{
			get
			{
				if (PlatformSettings.UseAdvancedProfilesMode && Profiles != null)
				{
					if (Profiles.TryGetChosen(out var value) && value != default(ProfileIdentifier))
					{
						return value != AddNewPlaceholder;
					}
					return false;
				}
				return true;
			}
		}

		protected BaseGameplayLaunchMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			PlayerID = player_id;
			ProfileStore.Main.Load();
		}

		public override void Update()
		{
			base.Update();
			if (StartGame != null)
			{
				StartGame.SetSelectable(CanStartHasProfileSelected);
			}
			if (JoinViaCodeButton != null)
			{
				JoinViaCodeButton.SetSelectable(ShowJoinViaCode);
			}
			if (CopyJoinCodeButton != null)
			{
				CopyJoinCodeButton.SetSelectable(ShowCopyJoinCode);
			}
		}

		protected void AutoStart(int player_id, bool use_networking)
		{
			PlayerProfile playerProfile = ProfileAccessor.EnsureProfile(InputSourceIdentifier.Default.GetPlatformUser(player_id));
			Session.RetainedPlayers.Clear();
			Session.RetainedPlayers.Add(new RetainedPlayer
			{
				PlayerProfile = playerProfile.Identifier,
				InputPlayerID = player_id
			});
			RequestAction(new MenuAction((!use_networking) ? MainMenuAction.StartSingleplayer : MainMenuAction.StartMultiplayer, skip_animation: true));
		}

		protected virtual void Redraw(bool jump_to_joincode = false, bool jump_to_invite = false)
		{
			Redraw();
		}

		protected void SetupProfileOption()
		{
			List<ProfileIdentifier> list = ProfileStore.Main.AvailableProfiles();
			list.Add(AddNewPlaceholder);
			CreateNewProfileIndex = list.Count - 1;
			List<string> list2 = list.Select((ProfileIdentifier p) => p.ToString()).ToList();
			list2[CreateNewProfileIndex] = base.Localisation["NEW_PROFILE"];
			Profiles = new Option<ProfileIdentifier>(list, (Session.RetainedPlayers.Count > 0) ? Session.RetainedPlayers[0].PlayerProfile : list[0], list2, (ProfileIdentifier p1, ProfileIdentifier p2) => (!(p1 == p2)) ? 1 : 0);
		}

		protected void DrawNetworkPermissions(int hide_player_id = -1)
		{
			if (PlatformSettings.AllowNonInviteOnlyGames)
			{
				Option<NetworkPermissions> option = new Option<NetworkPermissions>(new List<NetworkPermissions>
				{
					NetworkPermissions.Private,
					NetworkPermissions.InviteOnly,
					NetworkPermissions.Open
				}, NetworkHelpers.CurrentNetworkPermissions, new List<string>
				{
					base.Localisation.Name(NetworkPermissions.Private),
					base.Localisation.Name(NetworkPermissions.InviteOnly),
					base.Localisation.Name(NetworkPermissions.Open)
				});
				option.OnChanged += delegate(object _, NetworkPermissions f)
				{
					NetworkHelpers.CurrentNetworkPermissions = f;
				};
				AddLabel(base.Localisation["MENU_LABEL_NETWORK_CHOICE"]);
				AddSelect(option);
			}
		}

		protected void DrawInviteUI(bool select)
		{
			List<string> opts = new List<string>();
			if (PlatformSettings.IsWindowsStore)
			{
				opts.Add("Xbox");
			}
			if (PlatformSettings.IsSteam)
			{
				opts.Add("Steam");
			}
			if (PlatformSettings.IsEpic)
			{
				opts.Add("Epic");
			}
			bool isPC = PlatformSettings.IsPC;
			if (Platform.Current.DiscordEnabled || isPC)
			{
				opts.Add("Discord");
			}
			if (opts.Count > 1)
			{
				AddLabel(base.Localisation["MENU_OPEN_INVITE_OVERLAY"]);
				SelectElement module = AddSelectChooseable(opts.Select((string o) => get_label(o)).ToList(), delegate(int i)
				{
					if (i < 0 || i > opts.Count)
					{
						RequestAction(PauseMenuAction.OpenInvitePanel);
					}
					else if (opts[i] == "Discord")
					{
						RequestAction(PauseMenuAction.OpenInvitePanelDiscord);
					}
					else
					{
						RequestAction(PauseMenuAction.OpenInvitePanel);
					}
					Redraw(jump_to_joincode: false, jump_to_invite: true);
				});
				if (select)
				{
					ModuleList.Select(module);
				}
			}
			else
			{
				ButtonElement module2 = AddActionButton(base.Localisation["MENU_OPEN_INVITE_OVERLAY"], PauseMenuAction.OpenInvitePanel);
				if (select)
				{
					ModuleList.Select(module2);
				}
				if (Platform.Current.DiscordEnabled)
				{
					AddActionButton(base.Localisation["MENU_OPEN_INVITE_OVERLAY_DISCORD"], PauseMenuAction.OpenInvitePanelDiscord);
				}
			}
			string get_label(string name)
			{
				return "<color=#333333>" + string.Join("  ", opts.Select(delegate(string o)
				{
					string text = ((o != name) ? "1" : "0");
					return "<sprite=\"ManualSprites\" name=\"" + o + "\" tint=" + text + ">";
				}));
			}
		}

		protected void DrawJoinCodeUI()
		{
			string text = (DebugConfig.Generic.ForceAllowJoinCodes ? "DBG " : "");
			JoinViaCodeButton = AddButton(text + base.Localisation["PROMPT_JOIN_WITH_LOBBY_CODE"], delegate
			{
				TextInputView.RequestTextInput(base.Localisation["PROMPT_JOIN_WITH_LOBBY_CODE"], "", NetworkServices.GetMaxJoinCodeLength(), JoinFromTextInput);
			});
			JoinViaCodeButton.SetSelectable(selectable: false);
		}

		protected void AddCopyJoinCodeButton(bool select)
		{
			CopyJoinCodeButton = AddButton(base.Localisation["MENU_COPY_LOBBY_CODE"], delegate
			{
				NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.Open;
				GUIUtility.systemCopyBuffer = Session.GetInvite().AsJoinCode();
				Redraw(jump_to_joincode: true);
			});
			if (select)
			{
				CopyJoinCodeButton.SetSelectable(selectable: true);
				ModuleList.Select(CopyJoinCodeButton);
			}
			else
			{
				CopyJoinCodeButton.SetSelectable(selectable: false);
			}
		}

		private void JoinFromTextInput(TextInputView.TextInputState result, string text)
		{
			if (result != TextInputView.TextInputState.TextEntryCancelled && !string.IsNullOrEmpty(text))
			{
				JoinTarget(text);
			}
		}

		private async void JoinTarget(string text)
		{
			text = text.ToUpper();
			INetworkTarget networkTarget = await NetworkServices.CreateTargetFromJoinCode(JoinCode.CreateFromRemote(text));
			if (networkTarget != null)
			{
				Session.JoinGame(networkTarget);
			}
			else
			{
				Debug.LogWarning("Attempted to join unknown join code " + text);
			}
		}

		protected void DrawStartButton(MenuAction start_action)
		{
			StartGame = AddActionButton(base.Localisation["MAIN_MENU_START"], start_action);
			Profiles.OnChanged += delegate(object _, ProfileIdentifier p)
			{
				if (!PlatformSettings.UseAdvancedProfilesMode && !(StartGame == null))
				{
					StartGame.SetSelectable(p != default(ProfileIdentifier) && p != AddNewPlaceholder);
				}
			};
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
