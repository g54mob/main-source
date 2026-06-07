using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement
{
	public class DHStandardGroups
	{
		private static readonly string rfc2409_768_p;

		private static readonly string rfc2409_768_g;

		public static readonly DHParameters rfc2409_768;

		private static readonly string rfc2409_1024_p;

		private static readonly string rfc2409_1024_g;

		public static readonly DHParameters rfc2409_1024;

		private static readonly string rfc3526_1536_p;

		private static readonly string rfc3526_1536_g;

		public static readonly DHParameters rfc3526_1536;

		private static readonly string rfc3526_2048_p;

		private static readonly string rfc3526_2048_g;

		public static readonly DHParameters rfc3526_2048;

		private static readonly string rfc3526_3072_p;

		private static readonly string rfc3526_3072_g;

		public static readonly DHParameters rfc3526_3072;

		private static readonly string rfc3526_4096_p;

		private static readonly string rfc3526_4096_g;

		public static readonly DHParameters rfc3526_4096;

		private static readonly string rfc3526_6144_p;

		private static readonly string rfc3526_6144_g;

		public static readonly DHParameters rfc3526_6144;

		private static readonly string rfc3526_8192_p;

		private static readonly string rfc3526_8192_g;

		public static readonly DHParameters rfc3526_8192;

		public static readonly DHParameters rfc4306_768;

		public static readonly DHParameters rfc4306_1024;

		private static readonly string rfc5114_1024_160_p;

		private static readonly string rfc5114_1024_160_g;

		private static readonly string rfc5114_1024_160_q;

		public static readonly DHParameters rfc5114_1024_160;

		private static readonly string rfc5114_2048_224_p;

		private static readonly string rfc5114_2048_224_g;

		private static readonly string rfc5114_2048_224_q;

		public static readonly DHParameters rfc5114_2048_224;

		private static readonly string rfc5114_2048_256_p;

		private static readonly string rfc5114_2048_256_g;

		private static readonly string rfc5114_2048_256_q;

		public static readonly DHParameters rfc5114_2048_256;

		public static readonly DHParameters rfc5996_768;

		public static readonly DHParameters rfc5996_1024;

		private static readonly string rfc7919_ffdhe2048_p;

		public static readonly DHParameters rfc7919_ffdhe2048;

		private static readonly string rfc7919_ffdhe3072_p;

		public static readonly DHParameters rfc7919_ffdhe3072;

		private static readonly string rfc7919_ffdhe4096_p;

		public static readonly DHParameters rfc7919_ffdhe4096;

		private static readonly string rfc7919_ffdhe6144_p;

		public static readonly DHParameters rfc7919_ffdhe6144;

		private static readonly string rfc7919_ffdhe8192_p;

		public static readonly DHParameters rfc7919_ffdhe8192;

		private static BigInteger FromHex(string hex)
		{
			return null;
		}

		private static DHParameters FromPG(string hexP, string hexG)
		{
			return null;
		}

		private static DHParameters FromPGQ(string hexP, string hexG, string hexQ)
		{
			return null;
		}

		private static DHParameters Rfc7919Parameters(string hexP, int l)
		{
			return null;
		}
	}
}
