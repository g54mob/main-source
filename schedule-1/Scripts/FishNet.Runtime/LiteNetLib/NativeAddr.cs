using System;

namespace LiteNetLib
{
	internal readonly struct NativeAddr : IEquatable<NativeAddr>
	{
		private readonly long _part1;

		private readonly long _part2;

		private readonly long _part3;

		private readonly int _part4;

		private readonly int _hash;

		public NativeAddr(byte[] address, int len)
		{
			_part1 = 0L;
			_part2 = 0L;
			_part3 = 0L;
			_part4 = 0;
			_hash = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(NativeAddr other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(NativeAddr left, NativeAddr right)
		{
			return false;
		}

		public static bool operator !=(NativeAddr left, NativeAddr right)
		{
			return false;
		}
	}
}
