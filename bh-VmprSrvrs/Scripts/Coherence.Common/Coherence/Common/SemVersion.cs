using System;

namespace Coherence.Common
{
	public struct SemVersion : IEquatable<SemVersion>, IComparable<SemVersion>, IComparable
	{
		public bool IsInitialized { get; }

		public int Major { get; }

		public int Minor { get; }

		public int Patch { get; }

		public string Prerelease { get; }

		public string Build { get; }

		public SemVersion(int major, int minor = 0, int patch = 0, string prerelease = "", string build = "")
		{
			IsInitialized = false;
			Major = 0;
			Minor = 0;
			Patch = 0;
			Prerelease = null;
			Build = null;
		}

		public static int Compare(SemVersion versionA, SemVersion versionB)
		{
			return 0;
		}

		public static bool operator ==(SemVersion left, SemVersion right)
		{
			return false;
		}

		public static bool operator !=(SemVersion left, SemVersion right)
		{
			return false;
		}

		public static bool operator >(SemVersion left, SemVersion right)
		{
			return false;
		}

		public static bool operator >=(SemVersion left, SemVersion right)
		{
			return false;
		}

		public static bool operator <(SemVersion left, SemVersion right)
		{
			return false;
		}

		public static bool operator <=(SemVersion left, SemVersion right)
		{
			return false;
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public int CompareTo(SemVersion other)
		{
			return 0;
		}

		private static int CompareExtension(string current, string other, bool lower = false)
		{
			return 0;
		}

		public bool Equals(SemVersion other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static SemVersion Parse(string version)
		{
			return default(SemVersion);
		}
	}
}
