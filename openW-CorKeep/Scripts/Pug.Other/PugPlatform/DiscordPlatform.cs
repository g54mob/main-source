using System;
using System.Threading;
using Discord;
using I2.Loc;
using Steamworks;
using UnityEngine;

namespace PugPlatform
{
	public class DiscordPlatform
	{
		private class DiscordRichPresence : IRichPresence
		{
			private const string DEFAULT_LARGE_IMAGE = "rich_presence_icon_upscaled";

			private readonly string[] _sessionStatusTerms = new string[3] { "", "RichPresence/InMainMenu", "RichPresence/InGame" };

			private global::Discord.Discord _discord;

			private ActivityManager _activityManager;

			private Activity _activity;

			private string _currentTask;

			private string _currentBiome;

			public Activity CurrentActivity => _activity;

			public DiscordRichPresence(global::Discord.Discord discord, ActivityManager activityManager)
			{
				_discord = discord;
				_activityManager = activityManager;
			}

			public void StartSession(RichPresenceSessionTypes type)
			{
				long start = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				switch (type)
				{
				case RichPresenceSessionTypes.Menu:
					_activity = new Activity
					{
						ApplicationId = 1184796349334552576L,
						Type = ActivityType.Playing,
						State = LocalizationManager.GetTranslation(_sessionStatusTerms[(int)type]),
						Assets = 
						{
							LargeImage = "rich_presence_icon_upscaled"
						}
					};
					break;
				case RichPresenceSessionTypes.InGame:
					_activity = new Activity
					{
						ApplicationId = 1184796349334552576L,
						Type = ActivityType.Playing,
						State = LocalizationManager.GetTranslation(_sessionStatusTerms[(int)type]),
						Timestamps = new ActivityTimestamps
						{
							Start = start
						},
						Party = new ActivityParty
						{
							Size = new PartySize
							{
								CurrentSize = 1,
								MaxSize = 8
							}
						},
						Assets = 
						{
							LargeImage = "rich_presence_icon_upscaled"
						}
					};
					break;
				default:
					Debug.LogWarning($"unsupported rich presence session type: {type}");
					break;
				}
				_activityManager.UpdateActivity(_activity, delegate(Discord.Result result)
				{
					if (result != Discord.Result.Ok)
					{
						Debug.LogError($"Failed to update activity: {result}");
					}
				});
			}

			public void EndSession()
			{
				EndSession(flush: false);
			}

			public void EndSession(bool flush)
			{
				if (_activity.ApplicationId == 0L)
				{
					return;
				}
				bool done = false;
				_activityManager.ClearActivity(delegate(Discord.Result result)
				{
					if (result != Discord.Result.InvalidPayload && result != Discord.Result.Ok)
					{
						Debug.LogError($"Failed to clear activity: {result}");
					}
					done = true;
				});
				while (flush && !done)
				{
					_discord.RunCallbacks();
					Thread.Sleep(10);
				}
				_activity = default(Activity);
			}

			public void SetPartySize(int size)
			{
				if (_activity.ApplicationId == 0L || _activity.Party.Size.CurrentSize == size)
				{
					return;
				}
				_activity.Party.Size.CurrentSize = size;
				_activityManager.UpdateActivity(_activity, delegate(Discord.Result result)
				{
					if (result != Discord.Result.Ok)
					{
						Debug.LogError($"Failed to update activity party size: {result}");
					}
				});
			}

			public void SetCurrentBiome(string biome)
			{
				if (_activity.ApplicationId == 0L || _currentBiome == biome)
				{
					return;
				}
				_currentBiome = biome;
				_activity.State = LocalizationManager.GetTranslation("BiomeNames/" + biome);
				Debug.Log("new state " + _activity.State + " for biome " + biome);
				_activityManager.UpdateActivity(_activity, delegate(Discord.Result result)
				{
					if (result != Discord.Result.Ok)
					{
						Debug.LogError($"Failed to update activity biome: {result}");
					}
				});
			}

			public void SetCurrentTask(string task)
			{
				if (_activity.ApplicationId == 0L || _currentTask == task)
				{
					return;
				}
				task = LocalizationManager.GetTranslation("RichPresence/Task" + task);
				_activity.Details = task;
				_activityManager.UpdateActivity(_activity, delegate(Discord.Result result)
				{
					if (result != Discord.Result.Ok)
					{
						Debug.LogError($"Failed to update activity task: {result}");
					}
				});
			}

			public void SetSessionKey(string sessionKey)
			{
				if (_activity.ApplicationId == 0L || _activity.Secrets.Join == sessionKey)
				{
					return;
				}
				_activity.Party.Id = Guid.NewGuid().ToString();
				_activity.Secrets.Join = sessionKey;
				_activityManager.UpdateActivity(_activity, delegate(Discord.Result result)
				{
					if (result != Discord.Result.Ok)
					{
						Debug.LogError($"Failed to update activity session: {result}");
					}
				});
			}
		}

		private const long CLIENT_ID = 1184796349334552576L;

		private global::Discord.Discord _discord;

		private DiscordRichPresence _richPresence;

		public event Action<string> JoinRequest;

		public void Init()
		{
			try
			{
				_discord = new global::Discord.Discord(1184796349334552576L, 1uL);
				ActivityManager activityManager = _discord.GetActivityManager();
				if (SteamClient.IsValid)
				{
					uint value = SteamClient.AppId.Value;
					Debug.Log($"Registering steam game {value} with discord");
					activityManager.RegisterSteam(value);
				}
				LogLevel minLevel = (CommandLineArgs.Has("-extralog") ? LogLevel.Debug : LogLevel.Warn);
				_discord.SetLogHook(minLevel, delegate(LogLevel level, string message)
				{
					switch (level)
					{
					case LogLevel.Error:
						Debug.LogError("Discord: " + message);
						break;
					case LogLevel.Warn:
						Debug.LogWarning("Discord: " + message);
						break;
					default:
						Debug.Log("Discord: " + message);
						break;
					}
				});
				_richPresence = new DiscordRichPresence(_discord, activityManager);
				RichPresence.AddBackend(_richPresence);
				activityManager.OnActivityJoin += OnActivityJoin;
			}
			catch (ResultException ex)
			{
				Debug.Log((ex.Result == Discord.Result.NotRunning) ? "discord not running" : $"couldn't initialize discord SDK: {ex.Result} {ex.Message}");
				if (ex.Result == Discord.Result.Ok)
				{
					Deinit();
				}
				_discord = null;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_discord = null;
			}
		}

		public void Deinit()
		{
			if (_discord == null)
			{
				return;
			}
			ActivityManager activityManager = _discord.GetActivityManager();
			if (activityManager != null)
			{
				activityManager.OnActivityJoin -= OnActivityJoin;
			}
			if (_richPresence != null)
			{
				try
				{
					RichPresence.RemoveBackend(_richPresence);
					_richPresence?.EndSession(flush: true);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				finally
				{
					_richPresence = null;
				}
			}
			this.JoinRequest = null;
			_discord?.Dispose();
			_discord = null;
		}

		public void Update()
		{
			if (_discord == null)
			{
				return;
			}
			try
			{
				_discord.RunCallbacks();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Deinit();
			}
		}

		public void StartFriendInvitationFlow()
		{
			if (_richPresence == null)
			{
				Debug.LogWarning("Trying to open invite dialog for Discord activity when rich presence is not active.");
				return;
			}
			if (string.IsNullOrEmpty(_richPresence.CurrentActivity.Secrets.Join))
			{
				Debug.LogWarning("Trying to open invite dialog for Discord activity with invalid configuration.");
				return;
			}
			_discord.GetOverlayManager().OpenActivityInvite(ActivityActionType.Join, delegate(Discord.Result result)
			{
				if (result != Discord.Result.Ok)
				{
					Debug.LogError($"Failed to open activity invite dialog: {result}");
				}
			});
		}

		private void OnActivityJoin(string joinSecret)
		{
			if (string.IsNullOrEmpty(joinSecret))
			{
				Debug.Log("DiscordPlatform.OnActivityJoin: got an activity join callback with an invalid join secret. Won't broadcast this as a join request.");
			}
			else
			{
				this.JoinRequest?.Invoke(joinSecret);
			}
		}
	}
}
