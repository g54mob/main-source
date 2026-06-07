using System;

namespace FluffyUnderware.Curvy.Generator
{
	public readonly struct DuplicateSamplePoint : IEquatable<DuplicateSamplePoint>
	{
		public int StartIndex { get; }

		public int EndIndex { get; }

		public bool IsHardEdge { get; }

		public DuplicateSamplePoint(int startIndex, int endIndex, bool isHardEdge)
		{
			StartIndex = 0;
			EndIndex = 0;
			IsHardEdge = false;
		}

		public bool Equals(DuplicateSamplePoint other)
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

		public static bool operator ==(DuplicateSamplePoint left, DuplicateSamplePoint right)
		{
			return false;
		}

		public static bool operator !=(DuplicateSamplePoint left, DuplicateSamplePoint right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
