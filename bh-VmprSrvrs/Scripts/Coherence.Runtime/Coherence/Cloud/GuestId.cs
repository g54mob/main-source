using System;

namespace Coherence.Cloud
{
	public readonly struct GuestId : IEquatable<GuestId>
	{
		private const int MaxLength = 32;

		public static readonly GuestId None;

		private readonly string? id;

		private GuestId(string? id)
		{
			this.id = null;
		}

		public static string Serialize(GuestId guestId)
		{
			return null;
		}

		public static GuestId Deserialize(string serializedGuestId)
		{
			return default(GuestId);
		}

		internal static GuestId GetOrCreate(string projectId, CloudUniqueId uniqueId)
		{
			return default(GuestId);
		}

		internal static GuestId FromLegacyLoginData(string username, string password)
		{
			return default(GuestId);
		}

		internal static void Save(string projectId, CloudUniqueId uniqueId, GuestId id)
		{
		}

		internal static void Delete(string projectId, CloudUniqueId uniqueId)
		{
		}

		internal static string GetPrefsKey(string projectId, CloudUniqueId uniqueId)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator string(GuestId id)
		{
			return null;
		}

		public static implicit operator GuestId(string? id)
		{
			return default(GuestId);
		}

		public bool Equals(GuestId other)
		{
			return false;
		}

		public override bool Equals(object? obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
