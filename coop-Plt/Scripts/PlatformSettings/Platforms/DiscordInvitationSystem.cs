using System;
using Discord;
using Kitchen.NetworkSupport;
using Sirenix.Utilities;
using UnityEngine;

namespace Platforms
{
	public static class DiscordInvitationSystem
	{
		public struct ActivityData
		{
			public string Name;

			public string Invite;

			public int CurrentPlayers;

			public long Timestamp;

			public int Day;

			public bool IsInGame;

			public string MainDishName;

			public string MainDishImageKey;

			public bool AllowInvites;

			public ActivityData(NetworkInviteData invite, RichPresenceData session, NetworkPermissions current_network_permissions)
			{
				Name = invite.Identifier;
				if (Name.IsNullOrWhitespace() || Name == "0")
				{
					Name = "local";
				}
				Invite = invite.InviteString;
				CurrentPlayers = 4 - invite.AvailableSlots;
				Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				Day = session.Day;
				IsInGame = session.IsInGame;
				MainDishName = session.MainDishName;
				MainDishImageKey = session.MainDishImageKey;
				AllowInvites = current_network_permissions != NetworkPermissions.Private;
			}

			public bool IsChangedFrom(ActivityData other)
			{
				if (!IsSameSession(other))
				{
					return true;
				}
				if (CurrentPlayers != other.CurrentPlayers)
				{
					return true;
				}
				if (Day != other.Day)
				{
					return true;
				}
				if (IsInGame != other.IsInGame)
				{
					return true;
				}
				if (MainDishName != other.MainDishName)
				{
					return true;
				}
				if (MainDishImageKey != other.MainDishImageKey)
				{
					return true;
				}
				if (AllowInvites != other.AllowInvites)
				{
					return true;
				}
				return false;
			}

			public bool IsSameSession(ActivityData other)
			{
				if (Name == other.Name)
				{
					return Invite == other.Invite;
				}
				return false;
			}
		}

		[Flags]
		private enum ActivityGamePlatforms
		{
			Null = 0,
			Desktop = 1,
			Xbox = 2,
			Samsung = 4,
			IOS = 8,
			Android = 0x10,
			Embedded = 0x20,
			PS4 = 0x40,
			PS5 = 0x80
		}

		public static long ApplicationID = 906914697817784352L;

		public static uint SteamID = 1599600u;

		public static string GameName = "PlateUp!";

		public static string ActivityLabel = "Running a restaurant";

		public static string PlateUpDiscord = "plateup";

		private static global::Discord.Discord Client;

		private static ActivityData CurrentData;

		public static bool Initialise()
		{
			try
			{
				Client?.Dispose();
				Client = new global::Discord.Discord(ApplicationID, 1uL);
				ActivityManager activityManager = Client.GetActivityManager();
				if (PlatformSettings.IsSteam)
				{
					activityManager.RegisterSteam(SteamID);
				}
				else
				{
					_ = PlatformSettings.IsPC;
				}
				activityManager.OnActivityJoin += delegate(string secret)
				{
					EventLog.Platform.Report(DiscordEvent.JoiningGame, secret);
					Platform.Current.QueuedJoinTarget = new NetworkInviteData
					{
						InviteString = secret
					};
				};
				activityManager.OnActivityJoinRequest += delegate(ref User user)
				{
					EventLog.Platform.Report(DiscordEvent.ActivityJoinRequest, user.Username);
				};
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				EventLog.Platform.Report(DiscordEvent.DiscordNotPresent);
				return false;
			}
		}

		public static void Update(RichPresenceData session_info, NetworkPermissions current_network_permissions)
		{
			if (Client == null)
			{
				return;
			}
			try
			{
				Client.RunCallbacks();
			}
			catch (ResultException)
			{
				return;
			}
			if (Platform.Current != null)
			{
				ActivityData activityData = new ActivityData(Platform.Current.CurrentInvitation, session_info, current_network_permissions);
				if (CurrentData.IsChangedFrom(activityData))
				{
					UpdateActivity(activityData);
				}
			}
		}

		public static void UpdateActivity(ActivityData data)
		{
			if (CurrentData.IsSameSession(data))
			{
				data.Timestamp = CurrentData.Timestamp;
			}
			Activity activity = CreateActivity(data);
			CurrentData = data;
			Client.GetActivityManager().UpdateActivity(activity, delegate(Result r)
			{
				if (r != Result.Ok)
				{
					EventLog.Platform.Report(DiscordEvent.ActivityFailedToUpdate, $"{data.Name} / {data.Invite} / {r}");
				}
			});
		}

		public static void OpenJoinServerUI()
		{
			Client.GetOverlayManager().OpenGuildInvite(PlateUpDiscord, delegate(Result r)
			{
				if (r != Result.Ok)
				{
					EventLog.Platform.Report(DiscordEvent.FailedToOpenGuildInvite, r.ToString());
				}
			});
		}

		public static void OpenInviteUI()
		{
			Client.GetOverlayManager().OpenActivityInvite(ActivityActionType.Join, delegate(Result r)
			{
				if (r != Result.Ok)
				{
					EventLog.Platform.Report(DiscordEvent.FailedToOpenInvite, r.ToString());
				}
			});
		}

		public static void ClearActivity()
		{
			Client.GetActivityManager().ClearActivity(delegate(Result r)
			{
				if (r == Result.Ok)
				{
					EventLog.Platform.Report(DiscordEvent.ActivityCleared);
				}
				else
				{
					EventLog.Platform.Report(DiscordEvent.ActivityFailedToClear, r.ToString());
				}
			});
		}

		private static string PlayerIcons(int players, bool allow_invites)
		{
			if (!allow_invites)
			{
				return "Solo \ud83d\udc68\u200d\ud83c\udf73";
			}
			return players switch
			{
				1 => "\ud83d\udc69\u200d\ud83c\udf73⚫⚫⚫", 
				2 => "\ud83d\udc69\u200d\ud83c\udf73\ud83d\udc68\u200d\ud83c\udf73⚫⚫", 
				3 => "\ud83d\udc69\u200d\ud83c\udf73\ud83d\udc68\u200d\ud83c\udf73\ud83d\udc69\u200d\ud83c\udf73⚫", 
				4 => "\ud83d\udc69\u200d\ud83c\udf73\ud83d\udc68\u200d\ud83c\udf73\ud83d\udc69\u200d\ud83c\udf73\ud83d\udc68\u200d\ud83c\udf73", 
				_ => "", 
			};
		}

		private static string Description(int day, bool in_game)
		{
			if (!in_game)
			{
				return "Planning a restaurant";
			}
			string arg = "Running a restaurant";
			if (day > 15)
			{
				return $"{arg} - Overtime {day - 15}";
			}
			if (day == 0)
			{
				return "Preparing a restaurant";
			}
			return $"{arg} - Day {day}";
		}

		private static Activity CreateActivity(ActivityData data)
		{
			return new Activity
			{
				Type = ActivityType.Playing,
				ApplicationId = ApplicationID,
				Name = GameName,
				State = PlayerIcons(data.CurrentPlayers, data.AllowInvites),
				Details = Description(data.Day, data.IsInGame),
				Timestamps = new ActivityTimestamps
				{
					Start = data.Timestamp
				},
				Assets = new ActivityAssets
				{
					LargeImage = (data.MainDishImageKey?.ToLower() ?? "logosquare"),
					LargeText = data.MainDishName,
					SmallImage = "logosquare",
					SmallText = "PlateUp!"
				},
				Party = (data.AllowInvites ? new ActivityParty
				{
					Id = data.Name,
					Size = new PartySize
					{
						CurrentSize = data.CurrentPlayers,
						MaxSize = 4
					}
				} : default(ActivityParty)),
				Secrets = new ActivitySecrets
				{
					Join = data.Invite
				},
				SupportedPlatforms = GetDiscordPlatform()
			};
		}

		private static uint GetDiscordPlatform()
		{
			return PlatformSettings.CurrentPlatformType switch
			{
				PlatformType.Steam => 1u, 
				PlatformType.WindowsStore => 3u, 
				PlatformType.Xbox => 2u, 
				PlatformType.PS4 => 192u, 
				PlatformType.PS5 => 192u, 
				PlatformType.Epic => 1u, 
				_ => 0u, 
			};
		}
	}
}
