public class AkUtilities
{
	public class ShortIDGenerator
	{
		private const uint s_prime32 = 16777619u;

		private const uint s_offsetBasis32 = 2166136261u;

		private static byte s_hashSize;

		private static uint s_mask;

		public static byte HashSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		static ShortIDGenerator()
		{
		}

		public static uint Compute(string in_name)
		{
			return 0u;
		}
	}

	public static void FixSlashes(ref string path, char separatorChar, char badChar, bool addTrailingSlash)
	{
	}

	public static void FixSlashes(ref string path)
	{
	}

	public static string GetPathInPackage(string relativePath)
	{
		return null;
	}
}
