using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities
{
	[Il2CppEagerStaticClassConstruction]
	public abstract class Arrays
	{
		public static readonly byte[] EmptyBytes;

		public static readonly int[] EmptyInts;

		public static bool AreAllZeroes(byte[] buf, int off, int len)
		{
			return false;
		}

		public static bool AreEqual(bool[] a, bool[] b)
		{
			return false;
		}

		public static bool AreEqual(char[] a, char[] b)
		{
			return false;
		}

		public static bool AreEqual(byte[] a, byte[] b)
		{
			return false;
		}

		public static bool AreEqual(byte[] a, int aFromIndex, int aToIndex, byte[] b, int bFromIndex, int bToIndex)
		{
			return false;
		}

		public static bool AreSame(byte[] a, byte[] b)
		{
			return false;
		}

		public static bool ConstantTimeAreEqual(byte[] a, byte[] b)
		{
			return false;
		}

		public static bool ConstantTimeAreEqual(BufferSegment a, BufferSegment b)
		{
			return false;
		}

		public static bool ConstantTimeAreEqual(int len, byte[] a, int aOff, byte[] b, int bOff)
		{
			return false;
		}

		public static bool AreEqual(int[] a, int[] b)
		{
			return false;
		}

		public static bool AreEqual(uint[] a, uint[] b)
		{
			return false;
		}

		private static bool HaveSameContents(bool[] a, bool[] b)
		{
			return false;
		}

		private static bool HaveSameContents(char[] a, char[] b)
		{
			return false;
		}

		private static bool HaveSameContents(byte[] a, byte[] b)
		{
			return false;
		}

		private static bool HaveSameContents(int[] a, int[] b)
		{
			return false;
		}

		private static bool HaveSameContents(uint[] a, uint[] b)
		{
			return false;
		}

		public static string ToString(object[] a)
		{
			return null;
		}

		public static int GetHashCode(byte[] data)
		{
			return 0;
		}

		public static int GetHashCode(byte[] data, int off, int len)
		{
			return 0;
		}

		public static int GetHashCode(int[] data)
		{
			return 0;
		}

		public static int GetHashCode(int[] data, int off, int len)
		{
			return 0;
		}

		public static int GetHashCode(uint[] data)
		{
			return 0;
		}

		public static int GetHashCode(uint[] data, int off, int len)
		{
			return 0;
		}

		public static int GetHashCode(ulong[] data)
		{
			return 0;
		}

		public static int GetHashCode(ulong[] data, int off, int len)
		{
			return 0;
		}

		public static bool[] Clone(bool[] data)
		{
			return null;
		}

		public static byte[] Clone(byte[] data)
		{
			return null;
		}

		public static int[] Clone(int[] data)
		{
			return null;
		}

		public static uint[] Clone(uint[] data)
		{
			return null;
		}

		public static long[] Clone(long[] data)
		{
			return null;
		}

		public static ulong[] Clone(ulong[] data)
		{
			return null;
		}

		public static byte[] Clone(byte[] data, byte[] existing)
		{
			return null;
		}

		public static ulong[] Clone(ulong[] data, ulong[] existing)
		{
			return null;
		}

		public static bool Contains(byte[] a, byte n)
		{
			return false;
		}

		public static bool Contains(short[] a, short n)
		{
			return false;
		}

		public static bool Contains(int[] a, int n)
		{
			return false;
		}

		public static void Fill(byte[] buf, byte b)
		{
		}

		public static void Fill(byte[] buf, int from, int to, byte b)
		{
		}

		public static byte[] CopyOf(byte[] data, int newLength)
		{
			return null;
		}

		public static char[] CopyOf(char[] data, int newLength)
		{
			return null;
		}

		public static int[] CopyOf(int[] data, int newLength)
		{
			return null;
		}

		public static long[] CopyOf(long[] data, int newLength)
		{
			return null;
		}

		public static BigInteger[] CopyOf(BigInteger[] data, int newLength)
		{
			return null;
		}

		public static byte[] CopyOfRange(byte[] data, int from, int to)
		{
			return null;
		}

		public static int[] CopyOfRange(int[] data, int from, int to)
		{
			return null;
		}

		public static long[] CopyOfRange(long[] data, int from, int to)
		{
			return null;
		}

		public static BigInteger[] CopyOfRange(BigInteger[] data, int from, int to)
		{
			return null;
		}

		private static int GetLength(int from, int to)
		{
			return 0;
		}

		public static byte[] Append(byte[] a, byte b)
		{
			return null;
		}

		public static short[] Append(short[] a, short b)
		{
			return null;
		}

		public static int[] Append(int[] a, int b)
		{
			return null;
		}

		public static byte[] Concatenate(byte[] a, byte[] b)
		{
			return null;
		}

		public static byte[] ConcatenateAll(params byte[][] vs)
		{
			return null;
		}

		public static int[] Concatenate(int[] a, int[] b)
		{
			return null;
		}

		public static byte[] Prepend(byte[] a, byte b)
		{
			return null;
		}

		public static short[] Prepend(short[] a, short b)
		{
			return null;
		}

		public static int[] Prepend(int[] a, int b)
		{
			return null;
		}

		public static byte[] Reverse(byte[] a)
		{
			return null;
		}

		public static int[] Reverse(int[] a)
		{
			return null;
		}

		public static void Clear(byte[] data)
		{
		}

		public static void Clear(int[] data)
		{
		}

		public static bool IsNullOrContainsNull(object[] array)
		{
			return false;
		}
	}
}
