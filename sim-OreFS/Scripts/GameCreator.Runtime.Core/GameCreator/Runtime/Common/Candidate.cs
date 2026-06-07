using System;

namespace GameCreator.Runtime.Common
{
	internal readonly struct Candidate : IComparable<Candidate>
	{
		[field: NonSerialized]
		public int UniqueCode { get; }

		[field: NonSerialized]
		private float Distance { get; }

		public Candidate(int uniqueCode, float distance)
		{
			UniqueCode = uniqueCode;
			Distance = distance;
		}

		public int CompareTo(Candidate other)
		{
			return Distance.CompareTo(other.Distance);
		}
	}
}
