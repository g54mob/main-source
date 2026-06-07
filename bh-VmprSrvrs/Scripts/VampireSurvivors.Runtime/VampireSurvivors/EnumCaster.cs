using System;

namespace VampireSurvivors
{
	public class EnumCaster<T>
	{
		public static readonly Func<byte, T> FromByte;

		public static readonly Func<short, T> FromShort;

		public static readonly Func<int, T> FromInt;

		public static readonly Func<long, T> FromLong;

		static EnumCaster()
		{
		}
	}
}
