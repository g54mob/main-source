using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api.Helix.Models.Users.GetUserFollows;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.Services.Core.FollowerService;
using TwitchLib.Api.Services.Events.FollowerService;

namespace TwitchLib.Api.Services
{
	public class FollowerService : ApiService
	{
		private readonly Dictionary<string, DateTime> _lastFollowerDates = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

		private CoreMonitor _monitor;

		private IdBasedMonitor _idBasedMonitor;

		private NameBasedMonitor _nameBasedMonitor;

		public Dictionary<string, List<Follow>> KnownFollowers { get; } = new Dictionary<string, List<Follow>>(StringComparer.OrdinalIgnoreCase);

		public int QueryCountPerRequest { get; }

		public int CacheSize { get; }

		private IdBasedMonitor IdBasedMonitor => _idBasedMonitor ?? (_idBasedMonitor = new IdBasedMonitor(_api));

		private NameBasedMonitor NameBasedMonitor => _nameBasedMonitor ?? (_nameBasedMonitor = new NameBasedMonitor(_api));

		public event EventHandler<OnNewFollowersDetectedArgs> OnNewFollowersDetected;

		public FollowerService(ITwitchAPI api, int checkIntervalInSeconds = 60, int queryCountPerRequest = 100, int cacheSize = 1000)
			: base(api, checkIntervalInSeconds)
		{
			if (queryCountPerRequest < 1 || queryCountPerRequest > 100)
			{
				throw new ArgumentException("Twitch doesn't support less than 1 or more than 100 followers per request.", "queryCountPerRequest");
			}
			if (cacheSize < queryCountPerRequest)
			{
				throw new ArgumentException("The cache size must be at least the size of the queryCountPerRequest parameter.", "cacheSize");
			}
			QueryCountPerRequest = queryCountPerRequest;
			CacheSize = cacheSize;
		}

		public void ClearCache()
		{
			KnownFollowers.Clear();
			_lastFollowerDates.Clear();
			_nameBasedMonitor?.ClearCache();
			_nameBasedMonitor = null;
			_idBasedMonitor = null;
		}

		public void SetChannelsById(List<string> channelsToMonitor)
		{
			SetChannels(channelsToMonitor);
			_monitor = IdBasedMonitor;
		}

		public void SetChannelsByName(List<string> channelsToMonitor)
		{
			SetChannels(channelsToMonitor);
			_monitor = NameBasedMonitor;
		}

		public async Task UpdateLatestFollowersAsync(bool callEvents = true)
		{
			if (base.ChannelsToMonitor == null)
			{
				return;
			}
			foreach (string channel in base.ChannelsToMonitor)
			{
				List<Follow> latestFollowers = await GetLatestFollowersAsync(channel);
				if (latestFollowers.Count == 0)
				{
					return;
				}
				List<Follow> newFollowers;
				if (!KnownFollowers.TryGetValue(channel, out var knownFollowers))
				{
					newFollowers = latestFollowers;
					KnownFollowers[channel] = latestFollowers.Take(CacheSize).ToList();
					_lastFollowerDates[channel] = latestFollowers.Last().FollowedAt;
				}
				else
				{
					HashSet<string> existingFollowerIds = new HashSet<string>(knownFollowers.Select((Follow f) => f.FromUserId));
					DateTime latestKnownFollowerDate = _lastFollowerDates[channel];
					newFollowers = new List<Follow>();
					foreach (Follow follower in latestFollowers)
					{
						if (existingFollowerIds.Add(follower.FromUserId) && !(follower.FollowedAt < latestKnownFollowerDate))
						{
							newFollowers.Add(follower);
							latestKnownFollowerDate = follower.FollowedAt;
							knownFollowers.Add(follower);
						}
					}
					existingFollowerIds.Clear();
					existingFollowerIds.TrimExcess();
					if (knownFollowers.Count > CacheSize)
					{
						knownFollowers.RemoveRange(0, knownFollowers.Count - CacheSize);
					}
					if (newFollowers.Count <= 0)
					{
						return;
					}
					_lastFollowerDates[channel] = latestKnownFollowerDate;
				}
				if (!callEvents)
				{
					return;
				}
				this.OnNewFollowersDetected?.Invoke(this, new OnNewFollowersDetectedArgs
				{
					Channel = channel,
					NewFollowers = newFollowers
				});
				knownFollowers = null;
			}
		}

		protected override async Task OnServiceTimerTick()
		{
			await base.OnServiceTimerTick();
			await UpdateLatestFollowersAsync();
		}

		private async Task<List<Follow>> GetLatestFollowersAsync(string channel)
		{
			return (await _monitor.GetUsersFollowsAsync(channel, QueryCountPerRequest)).Follows.Reverse().ToList();
		}
	}
}
