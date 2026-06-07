using System.Collections;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class MacUtilities
	{
		private static readonly IDictionary algorithms;

		private MacUtilities()
		{
		}

		static MacUtilities()
		{
		}

		public static IMac GetMac(DerObjectIdentifier id)
		{
			return null;
		}

		public static IMac GetMac(string algorithm)
		{
			return null;
		}

		public static string GetAlgorithmName(DerObjectIdentifier oid)
		{
			return null;
		}

		public static byte[] DoFinal(IMac mac)
		{
			return null;
		}

		public static BufferSegment DoFinalOptimized(IMac mac)
		{
			return default(BufferSegment);
		}

		public static byte[] DoFinal(IMac mac, byte[] input)
		{
			return null;
		}
	}
}
