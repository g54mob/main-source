using System;

namespace CLanguage.Syntax
{
	public struct Location : IEquatable<Location>
	{
		public readonly Document Document;

		public readonly int Index;

		public readonly int Line;

		public readonly int Column;

		public static readonly Location Null;

		public bool IsNull => false;

		public Location(Document document, int index, int line, int column)
		{
			Document = null;
			Index = 0;
			Line = 0;
			Column = 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static Location operator +(Location location, int columnOffset)
		{
			return default(Location);
		}

		public static bool operator ==(Location x, Location y)
		{
			return false;
		}

		public static bool operator !=(Location x, Location y)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Location y)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
