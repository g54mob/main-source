using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public abstract class TspAlgorithms
	{
		public static readonly string MD5;

		public static readonly string Sha1;

		public static readonly string Sha224;

		public static readonly string Sha256;

		public static readonly string Sha384;

		public static readonly string Sha512;

		public static readonly string RipeMD128;

		public static readonly string RipeMD160;

		public static readonly string RipeMD256;

		public static readonly string Gost3411;

		public static readonly string Gost3411_2012_256;

		public static readonly string Gost3411_2012_512;

		public static readonly string SM3;

		public static readonly IList Allowed;

		static TspAlgorithms()
		{
		}
	}
}
