using System.Text;

namespace ICSharpCode.SharpZipLib.Zip
{
	public static class ZipStrings
	{
		private static int codePage;

		private const int AutomaticCodePage = -1;

		private const int FallbackCodePage = 437;

		public static int CodePage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int SystemDefaultCodePage { get; }

		public static bool UseUnicode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		static ZipStrings()
		{
		}

		public static string ConvertToString(byte[] data, int count)
		{
			return null;
		}

		public static string ConvertToString(byte[] data)
		{
			return null;
		}

		private static Encoding EncodingFromFlag(int flags)
		{
			return null;
		}

		public static string ConvertToStringExt(int flags, byte[] data, int count)
		{
			return null;
		}

		public static string ConvertToStringExt(int flags, byte[] data)
		{
			return null;
		}

		public static byte[] ConvertToArray(string str)
		{
			return null;
		}

		public static byte[] ConvertToArray(int flags, string str)
		{
			return null;
		}
	}
}
