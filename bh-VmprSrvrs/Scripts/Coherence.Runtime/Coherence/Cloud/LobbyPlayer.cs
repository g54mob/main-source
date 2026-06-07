using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbyPlayer : IEquatable<LobbyPlayer>, IComparable<LobbyPlayer>
	{
		[JsonProperty("id")]
		private string id;

		[JsonProperty("username")]
		public string username;

		[JsonProperty("attributes")]
		internal List<CloudAttribute> attributes;

		public PlayerAccountId Id => default(PlayerAccountId);

		[JsonIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Id instead.")]
		[Deprecated("04/2025", 1, 6, 0, Reason = "Use Id instead.")]
		public string UserId => null;

		public string Username => null;

		public IReadOnlyList<CloudAttribute> Attributes => null;

		bool IEquatable<LobbyPlayer>.Equals(LobbyPlayer other)
		{
			return false;
		}

		internal LobbyPlayer(string id)
		{
			this.id = null;
			username = null;
			attributes = null;
		}

		internal LobbyPlayer(string id, string username, List<CloudAttribute> attributes)
		{
			this.id = null;
			this.username = null;
			this.attributes = null;
		}

		public bool Equals(in LobbyPlayer other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public int CompareTo(LobbyPlayer other)
		{
			return 0;
		}

		public static bool operator ==(in LobbyPlayer left, in LobbyPlayer right)
		{
			return false;
		}

		public static bool operator !=(in LobbyPlayer left, in LobbyPlayer right)
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
	}
}
