using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Replaced by LobbyPlayer")]
	[Deprecated("04/2025", 1, 6, 0, Reason = "Replaced by LobbyPlayer to avoid confusion with PlayerAccount.")]
	public struct Player : IEquatable<Player>, IComparable<Player>
	{
		[JsonProperty("id")]
		public string UserId;

		[JsonProperty("username")]
		public string Username;

		[JsonProperty("attributes")]
		internal List<CloudAttribute> playerAttributes;

		public IReadOnlyList<CloudAttribute> Attributes => null;

		bool IEquatable<Player>.Equals(Player other)
		{
			return false;
		}

		public bool Equals(in Player other)
		{
			return false;
		}

		public bool Equals(in LobbyPlayer other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public int CompareTo(Player other)
		{
			return 0;
		}

		public int CompareTo(LobbyPlayer other)
		{
			return 0;
		}

		public static bool operator ==(in Player left, in Player right)
		{
			return false;
		}

		public static bool operator !=(in Player left, in Player right)
		{
			return false;
		}

		public static bool operator ==(in LobbyPlayer left, in Player right)
		{
			return false;
		}

		public static bool operator !=(in LobbyPlayer left, in Player right)
		{
			return false;
		}

		public static bool operator ==(in Player left, in LobbyPlayer right)
		{
			return false;
		}

		public static bool operator !=(in Player left, in LobbyPlayer right)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public CloudAttribute? GetAttribute(string key)
		{
			return null;
		}

		public static implicit operator LobbyPlayer(Player player)
		{
			return default(LobbyPlayer);
		}

		public static implicit operator Player(LobbyPlayer player)
		{
			return default(Player);
		}
	}
}
