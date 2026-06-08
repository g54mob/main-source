using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Manager
{
	internal class JoinedChannelManager
	{
		private readonly ConcurrentDictionary<string, JoinedChannel> _joinedChannels;

		public JoinedChannelManager()
		{
			_joinedChannels = new ConcurrentDictionary<string, JoinedChannel>(StringComparer.OrdinalIgnoreCase);
		}

		public void AddJoinedChannel(JoinedChannel joinedChannel)
		{
			_joinedChannels.TryAdd(joinedChannel.Channel, joinedChannel);
		}

		public JoinedChannel GetJoinedChannel(string channel)
		{
			_joinedChannels.TryGetValue(channel, out var value);
			return value;
		}

		public IReadOnlyList<JoinedChannel> GetJoinedChannels()
		{
			return _joinedChannels.Values.ToList().AsReadOnly();
		}

		public void RemoveJoinedChannel(string channel)
		{
			_joinedChannels.TryRemove(channel, out var _);
		}

		public void Clear()
		{
			_joinedChannels.Clear();
		}
	}
}
