using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api.Helix.Models.Streams.GetStreams;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.Services.Core.LiveStreamMonitor;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace TwitchLib.Api.Services
{
	public class LiveStreamMonitorService : ApiService
	{
		private CoreMonitor _monitor;

		private IdBasedMonitor _idBasedMonitor;

		private NameBasedMonitor _nameBasedMonitor;

		public Dictionary<string, Stream> LiveStreams { get; } = new Dictionary<string, Stream>(StringComparer.OrdinalIgnoreCase);

		public int MaxStreamRequestCountPerRequest { get; }

		private IdBasedMonitor IdBasedMonitor => _idBasedMonitor ?? (_idBasedMonitor = new IdBasedMonitor(_api));

		private NameBasedMonitor NameBasedMonitor => _nameBasedMonitor ?? (_nameBasedMonitor = new NameBasedMonitor(_api));

		public event EventHandler<OnStreamOnlineArgs> OnStreamOnline;

		public event EventHandler<OnStreamOfflineArgs> OnStreamOffline;

		public event EventHandler<OnStreamUpdateArgs> OnStreamUpdate;

		public LiveStreamMonitorService(ITwitchAPI api, int checkIntervalInSeconds = 60, int maxStreamRequestCountPerRequest = 100)
			: base(api, checkIntervalInSeconds)
		{
			if (maxStreamRequestCountPerRequest < 1 || maxStreamRequestCountPerRequest > 100)
			{
				throw new ArgumentException("Twitch doesn't support less than 1 or more than 100 streams per request.", "maxStreamRequestCountPerRequest");
			}
			MaxStreamRequestCountPerRequest = maxStreamRequestCountPerRequest;
		}

		public void ClearCache()
		{
			LiveStreams.Clear();
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

		public async Task UpdateLiveStreamersAsync(bool callEvents = true)
		{
			List<Stream> result = await GetLiveStreamersAsync();
			foreach (string channel in base.ChannelsToMonitor)
			{
				IEnumerable<Stream> source = result;
				Stream liveStream = source.FirstOrDefault(await _monitor.CompareStream(channel));
				if (liveStream != null)
				{
					HandleLiveStreamUpdate(channel, liveStream, callEvents);
				}
				else
				{
					HandleOfflineStreamUpdate(channel, callEvents);
				}
			}
		}

		protected override async Task OnServiceTimerTick()
		{
			try
			{
				await base.OnServiceTimerTick();
				await UpdateLiveStreamersAsync();
			}
			catch
			{
			}
		}

		private void HandleLiveStreamUpdate(string channel, Stream liveStream, bool callEvents)
		{
			bool flag = LiveStreams.ContainsKey(channel);
			LiveStreams[channel] = liveStream;
			if (callEvents)
			{
				if (!flag)
				{
					this.OnStreamOnline?.Invoke(this, new OnStreamOnlineArgs
					{
						Channel = channel,
						Stream = liveStream
					});
				}
				else
				{
					this.OnStreamUpdate?.Invoke(this, new OnStreamUpdateArgs
					{
						Channel = channel,
						Stream = liveStream
					});
				}
			}
		}

		private void HandleOfflineStreamUpdate(string channel, bool callEvents)
		{
			if (LiveStreams.TryGetValue(channel, out var value))
			{
				LiveStreams.Remove(channel);
				if (callEvents)
				{
					this.OnStreamOffline?.Invoke(this, new OnStreamOfflineArgs
					{
						Channel = channel,
						Stream = value
					});
				}
			}
		}

		private async Task<List<Stream>> GetLiveStreamersAsync()
		{
			List<Stream> livestreamers = new List<Stream>();
			double pages = Math.Ceiling((double)base.ChannelsToMonitor.Count / (double)MaxStreamRequestCountPerRequest);
			for (int i = 0; (double)i < pages; i++)
			{
				List<string> selectedSet = base.ChannelsToMonitor.Skip(i * MaxStreamRequestCountPerRequest).Take(MaxStreamRequestCountPerRequest).ToList();
				GetStreamsResponse resultset = await _monitor.GetStreamsAsync(selectedSet);
				if (resultset.Streams != null)
				{
					livestreamers.AddRange(resultset.Streams);
				}
			}
			return livestreamers;
		}
	}
}
