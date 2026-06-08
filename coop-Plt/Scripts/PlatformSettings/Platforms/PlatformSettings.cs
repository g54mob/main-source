using ExitGames.Client.Photon;

namespace Platforms
{
	public static class PlatformSettings
	{
		public static readonly bool IsWindowsStore = false;

		public static readonly bool IsXbox = false;

		public static readonly bool IsPS4 = false;

		public static readonly bool IsPS5 = false;

		public static readonly bool IsSwitch = false;

		public static readonly bool IsSteam = true;

		public static readonly bool IsEpic = false;

		public static readonly bool CompileSteamNetworking = IsSteam;

		public static readonly bool IsEditor = false;

		public static readonly bool IsDebugBuild = false;

		public static readonly bool IsHueyPlatform = false;

		public static readonly bool IsDemoMode = false;

		public static int SaveBackupDepth = (IsHueyPlatform ? 1 : 10);

		public static string MissingUserName = "Player";

		public static string PhotonURL = "https://ae-customauth.photonengine.com";

		public static string PhotonAppID = "b87230b0-ba8d-4285-bfe9-9c1405c6fdde";

		public static string PhotonAppVersion = "photon-networking-v1";

		public static ConnectionProtocol PhotonProtocol = ConnectionProtocol.Udp;

		public static PlatformType CurrentPlatformType
		{
			get
			{
				if (IsEditor)
				{
					if (IsCompilingPlatform(PlatformType.Steam))
					{
						return PlatformType.Steam;
					}
					if (IsCompilingPlatform(PlatformType.WindowsStore))
					{
						return PlatformType.WindowsStore;
					}
					if (IsCompilingPlatform(PlatformType.Epic))
					{
						return PlatformType.Epic;
					}
				}
				return BuildType;
			}
		}

		public static PlatformType BuildType
		{
			get
			{
				if (!IsWindowsStore)
				{
					if (!IsXbox)
					{
						if (!IsPS4)
						{
							if (!IsPS5)
							{
								if (!IsSwitch)
								{
									if (!IsSteam)
									{
										if (!IsEpic)
										{
											return PlatformType.Null;
										}
										return PlatformType.Epic;
									}
									return PlatformType.Steam;
								}
								return PlatformType.Switch;
							}
							return PlatformType.PS5;
						}
						return PlatformType.PS4;
					}
					return PlatformType.Xbox;
				}
				return PlatformType.WindowsStore;
			}
		}

		public static bool CompilePhoton
		{
			get
			{
				if (!IsXbox)
				{
					return IsPC;
				}
				return true;
			}
		}

		public static LargeMessageBehaviour LargeMessageBehaviour
		{
			get
			{
				if (!IsPC)
				{
					if (!IsPlayStation)
					{
						return LargeMessageBehaviour.SplitIntoManyPackets;
					}
					return LargeMessageBehaviour.SendAsOne;
				}
				return LargeMessageBehaviour.SendAsOne;
			}
		}

		public static bool DebugQuickLoadLobby => false;

		public static bool UseSteamNetworking => CurrentPlatformType == PlatformType.Steam;

		public static bool UsePhotonNetworking
		{
			get
			{
				if (!UseSignallingNetworking)
				{
					return !UseNPLNNetworking;
				}
				return false;
			}
		}

		public static bool IsPhotonCrossplayOnly
		{
			get
			{
				if (UsePhotonNetworking)
				{
					return IsSteam;
				}
				return false;
			}
		}

		public static bool UseSignallingNetworking
		{
			get
			{
				if (CurrentPlatformType != PlatformType.PS5)
				{
					return CurrentPlatformType == PlatformType.PS4;
				}
				return true;
			}
		}

		public static bool UseNPLNNetworking => CurrentPlatformType == PlatformType.Switch;

		public static int ActivePlatformCount => (IsWindowsStore ? 1 : 0) + (IsXbox ? 1 : 0) + (IsPS4 ? 1 : 0) + (IsPS5 ? 1 : 0) + (IsSwitch ? 1 : 0) + (IsEpic ? 1 : 0) + (IsSteam ? 1 : 0);

		public static bool OnlyUseSingleNames => !UseAdvancedProfilesMode;

		public static bool ShowSeeds => CurrentPlatformType == PlatformType.Steam;

		public static bool UseAdvancedProfilesMode => IsPC;

		public static bool RemoveOldInputsWhenFindingNewDevice => CurrentPlatformType == PlatformType.Xbox;

		public static bool AllowNonInviteOnlyGames => AllowJoinCodes;

		public static bool AllowQuit => IsPC;

		public static bool UsePressAnyButtonModeForJoinPrompts => CurrentPlatformType == PlatformType.Switch;

		public static bool IsPC
		{
			get
			{
				if (CurrentPlatformType != PlatformType.WindowsStore && CurrentPlatformType != PlatformType.Steam)
				{
					return CurrentPlatformType == PlatformType.Epic;
				}
				return true;
			}
		}

		public static bool IsPlayStation
		{
			get
			{
				if (CurrentPlatformType != PlatformType.PS4)
				{
					return CurrentPlatformType == PlatformType.PS5;
				}
				return true;
			}
		}

		public static bool AllowsAsyncKeyboard => true;

		public static bool UseSoftwareKeyboard
		{
			get
			{
				if (Platform.Current.RequiresSoftwareKeyboard())
				{
					return !IsEditor;
				}
				return false;
			}
		}

		public static bool IsConsole => !IsPC;

		public static bool SupportsUsernameLookup
		{
			get
			{
				if (CurrentPlatformType != PlatformType.WindowsStore)
				{
					return CurrentPlatformType == PlatformType.Xbox;
				}
				return true;
			}
		}

		public static bool SupportsExternalLinks => IsPC;

		public static bool SupportsGraphicsMenu => IsPC;

		public static bool SupportsLanguageSelection
		{
			get
			{
				if (!IsPC)
				{
					return CurrentPlatformType == PlatformType.Switch;
				}
				return true;
			}
		}

		public static bool AllowsDynamicVariables => CurrentPlatformType == PlatformType.Steam;

		public static bool SupportsExternalTools => IsPC;

		public static bool SupportsChef => CurrentPlatformType == PlatformType.Steam;

		public static string WikiLandingPage => "https://wiki.plateupgame.com/landing";

		public static string DiscordLandingPage => "https://discord.plateupgame.com";

		public static string DiscordDownloadPage => "https://discord.com/download";

		public static bool NeedsCrossplayOptIn => IsSteam;

		public static bool AllowJoinCodes => IsPC;

		public static bool AllowUGC => CurrentPlatformType == PlatformType.Steam;

		public static bool UseFileForPreferences => IsXbox;

		public static bool ShowLobbyMirrors => !IsSwitch;

		public static bool IsCompilingPlatform(PlatformType type)
		{
			return type switch
			{
				PlatformType.Null => false, 
				PlatformType.Steam => IsSteam, 
				PlatformType.WindowsStore => IsWindowsStore, 
				PlatformType.Xbox => IsXbox, 
				PlatformType.PS4 => IsPS4, 
				PlatformType.PS5 => IsPS5, 
				PlatformType.Switch => IsSwitch, 
				PlatformType.Epic => IsEpic, 
				_ => false, 
			};
		}

		public static bool RemotePlatformConnectionRequiresCrossplay(PlatformType remote)
		{
			if (CurrentPlatformType == remote)
			{
				return false;
			}
			if (IsPlayStation && (remote == PlatformType.PS5 || remote == PlatformType.PS4))
			{
				return false;
			}
			return true;
		}
	}
}
