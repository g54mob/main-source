using System;
using Unity.Netcode;

namespace Brewery.Face
{
	public struct FaceMoodSet : IEquatable<FaceMoodSet>, INetworkSerializable
	{
		private ulong _bits;

		public static FaceMoodSet Empty => default(FaceMoodSet);

		public ulong RawBits => 0uL;

		public bool IsEmpty => false;

		private FaceMoodSet(ulong bits)
		{
			_bits = 0uL;
		}

		public bool Contains(FaceMood mood)
		{
			return false;
		}

		public FaceMoodSet With(FaceMood mood)
		{
			return default(FaceMoodSet);
		}

		public FaceMoodSet Without(FaceMood mood)
		{
			return default(FaceMoodSet);
		}

		public FaceMoodSet Union(FaceMoodSet other)
		{
			return default(FaceMoodSet);
		}

		public FaceMoodSet Intersect(FaceMoodSet other)
		{
			return default(FaceMoodSet);
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(FaceMoodSet other)
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

		public static bool operator ==(FaceMoodSet a, FaceMoodSet b)
		{
			return false;
		}

		public static bool operator !=(FaceMoodSet a, FaceMoodSet b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
