using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class IsoTrailers
	{
		public const int TRAILER_IMPLICIT = 188;

		public const int TRAILER_RIPEMD160 = 12748;

		public const int TRAILER_RIPEMD128 = 13004;

		public const int TRAILER_SHA1 = 13260;

		public const int TRAILER_SHA256 = 13516;

		public const int TRAILER_SHA512 = 13772;

		public const int TRAILER_SHA384 = 14028;

		public const int TRAILER_WHIRLPOOL = 14284;

		public const int TRAILER_SHA224 = 14540;

		public const int TRAILER_SHA512_224 = 14796;

		public const int TRAILER_SHA512_256 = 16588;

		private static readonly IDictionary trailerMap;

		private static IDictionary CreateTrailerMap()
		{
			return null;
		}

		public static int GetTrailer(IDigest digest)
		{
			return 0;
		}

		public static bool NoTrailerAvailable(IDigest digest)
		{
			return false;
		}
	}
}
