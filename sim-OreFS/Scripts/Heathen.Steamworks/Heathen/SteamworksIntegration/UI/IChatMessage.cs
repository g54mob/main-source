using System;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.UI
{
	public interface IChatMessage
	{
		UserData User { get; }

		byte[] Data { get; }

		string Message { get; }

		DateTime ReceivedAt { get; }

		EChatEntryType Type { get; }

		bool IsExpanded { get; set; }

		GameObject GameObject { get; }

		void Initialize(ClanChatMsg message);

		void Initialize(LobbyChatMsg message);

		void Initialize(UserData sender, string message, EChatEntryType type);
	}
}
