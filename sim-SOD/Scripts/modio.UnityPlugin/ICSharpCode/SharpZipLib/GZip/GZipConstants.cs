using System.Text;

namespace ICSharpCode.SharpZipLib.GZip
{
	public sealed class GZipConstants
	{
		public const byte ID1 = 31;

		public const byte ID2 = 139;

		public const byte CompressionMethodDeflate = 8;

		public static Encoding Encoding => null;
	}
}
