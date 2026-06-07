using System;
using System.Text;

namespace Gh
{
	public static class ShortHash
	{
		private static readonly XXHash _xxHash;

		[ThreadStatic]
		private static StringBuilder _sb;

		public static string ComputeHash(string input)
		{
			return null;
		}

		public static string ComputeHash(byte[] data)
		{
			return null;
		}
	}
}
