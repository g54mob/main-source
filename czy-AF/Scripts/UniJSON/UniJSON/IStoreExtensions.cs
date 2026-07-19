using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class IStoreExtensions
	{
		public static void WriteValues(this IStore s, params byte[] bytes)
		{
			s.Write(new ArraySegment<byte>(bytes));
		}

		public static void Write(this IStore s, byte[] bytes)
		{
			s.Write(new ArraySegment<byte>(bytes));
		}

		public static void Write(this IStore s, IEnumerable<byte> bytes)
		{
			s.Write(new ArraySegment<byte>(bytes.ToArray()));
		}

		public static Utf8String ToUtf8String(this IStore s)
		{
			return new Utf8String(s.Bytes);
		}
	}
}
