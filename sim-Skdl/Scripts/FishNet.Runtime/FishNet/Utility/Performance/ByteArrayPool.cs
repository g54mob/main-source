using System.Collections.Generic;

namespace FishNet.Utility.Performance
{
	public static class ByteArrayPool
	{
		private static Queue<byte[]> _byteArrays;

		public static byte[] Retrieve(int minimumLength)
		{
			return null;
		}

		public static void Store(byte[] buffer)
		{
		}
	}
}
