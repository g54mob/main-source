using System;

namespace Sentry.PlatformAbstractions
{
	public class SentryRuntime : IEquatable<SentryRuntime>
	{
		private static Lazy<SentryRuntime> _currentRuntime = new Lazy<SentryRuntime>(RuntimeInfo.GetRuntime);

		public static SentryRuntime Current => _currentRuntime.Value;

		public string? Name { get; }

		public string? Version { get; }

		public string? Raw { get; }

		public string? Identifier { get; }

		public SentryRuntime(string? name = null, string? version = null, string? raw = null, string? identifier = null)
		{
			Name = name;
			Version = version;
			Raw = raw;
			Identifier = identifier;
		}

		public override string? ToString()
		{
			if (Name == null && Version == null)
			{
				return Raw;
			}
			if (Name != null && Version == null)
			{
				string? raw = Raw;
				if (raw == null || !raw.Contains(Name))
				{
					return Name + " " + Raw;
				}
				return Raw;
			}
			return Name + " " + Version;
		}

		public bool Equals(SentryRuntime? other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (string.Equals(Name, other.Name) && string.Equals(Version, other.Version) && string.Equals(Raw, other.Raw))
			{
				return object.Equals(Identifier, other.Identifier);
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((SentryRuntime)obj);
		}

		public override int GetHashCode()
		{
			return ((((((Name?.GetHashCode() ?? 0) * 397) ^ (Version?.GetHashCode() ?? 0)) * 397) ^ (Raw?.GetHashCode() ?? 0)) * 397) ^ (Identifier?.GetHashCode() ?? 0);
		}
	}
}
