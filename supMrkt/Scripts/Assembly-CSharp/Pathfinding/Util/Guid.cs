using System;
using System.Text;

namespace Pathfinding.Util
{
	public struct Guid
	{
		private const string hex = "0123456789ABCDEF";

		public static readonly Guid zero;

		public static readonly string zeroString;

		private readonly ulong _a;

		private readonly ulong _b;

		private static Random random;

		private static StringBuilder text;

		public Guid(byte[] bytes)
		{
			_a = 0uL;
			_b = 0uL;
		}

		public Guid(string str)
		{
			_a = 0uL;
			_b = 0uL;
		}

		public static Guid Parse(string input)
		{
			return default(Guid);
		}

		private static ulong SwapEndianness(ulong value)
		{
			return 0uL;
		}

		public byte[] ToByteArray()
		{
			return null;
		}

		public static Guid NewGuid()
		{
			return default(Guid);
		}

		public static bool operator ==(Guid lhs, Guid rhs)
		{
			return false;
		}

		public static bool operator !=(Guid lhs, Guid rhs)
		{
			return false;
		}

		public override bool Equals(object _rhs)
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
	}
}
