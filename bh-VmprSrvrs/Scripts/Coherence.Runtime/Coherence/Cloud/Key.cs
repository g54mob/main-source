using System;
using System.Diagnostics.CodeAnalysis;

namespace Coherence.Cloud
{
	internal readonly struct Key : IEquatable<Key>
	{
		public const int MaxLength = 4096;

		public string Content { get; }

		public Key([DisallowNull] string content)
		{
			Content = null;
		}

		private static StorageException GetException(string message)
		{
			return null;
		}

		public bool Equals(Key other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(Key left, Key right)
		{
			return false;
		}

		public static bool operator !=(Key left, Key right)
		{
			return false;
		}

		public static bool operator ==(Key left, string right)
		{
			return false;
		}

		public static bool operator !=(Key left, string right)
		{
			return false;
		}

		public static implicit operator Key(string value)
		{
			return default(Key);
		}

		public static implicit operator string(Key value)
		{
			return null;
		}
	}
}
