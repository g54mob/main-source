using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.JPake
{
	public abstract class JPakeUtilities
	{
		public static readonly BigInteger Zero;

		public static readonly BigInteger One;

		public static BigInteger GenerateX1(BigInteger q, SecureRandom random)
		{
			return null;
		}

		public static BigInteger GenerateX2(BigInteger q, SecureRandom random)
		{
			return null;
		}

		public static BigInteger CalculateS(char[] password)
		{
			return null;
		}

		public static BigInteger CalculateGx(BigInteger p, BigInteger g, BigInteger x)
		{
			return null;
		}

		public static BigInteger CalculateGA(BigInteger p, BigInteger gx1, BigInteger gx3, BigInteger gx4)
		{
			return null;
		}

		public static BigInteger CalculateX2s(BigInteger q, BigInteger x2, BigInteger s)
		{
			return null;
		}

		public static BigInteger CalculateA(BigInteger p, BigInteger q, BigInteger gA, BigInteger x2s)
		{
			return null;
		}

		public static BigInteger[] CalculateZeroKnowledgeProof(BigInteger p, BigInteger q, BigInteger g, BigInteger gx, BigInteger x, string participantId, IDigest digest, SecureRandom random)
		{
			return null;
		}

		private static BigInteger CalculateHashForZeroKnowledgeProof(BigInteger g, BigInteger gr, BigInteger gx, string participantId, IDigest digest)
		{
			return null;
		}

		public static void ValidateGx4(BigInteger gx4)
		{
		}

		public static void ValidateGa(BigInteger ga)
		{
		}

		public static void ValidateZeroKnowledgeProof(BigInteger p, BigInteger q, BigInteger g, BigInteger gx, BigInteger[] zeroKnowledgeProof, string participantId, IDigest digest)
		{
		}

		public static BigInteger CalculateKeyingMaterial(BigInteger p, BigInteger q, BigInteger gx4, BigInteger x2, BigInteger s, BigInteger B)
		{
			return null;
		}

		public static void ValidateParticipantIdsDiffer(string participantId1, string participantId2)
		{
		}

		public static void ValidateParticipantIdsEqual(string expectedParticipantId, string actualParticipantId)
		{
		}

		public static void ValidateNotNull(object obj, string description)
		{
		}

		public static BigInteger CalculateMacTag(string participantId, string partnerParticipantId, BigInteger gx1, BigInteger gx2, BigInteger gx3, BigInteger gx4, BigInteger keyingMaterial, IDigest digest)
		{
			return null;
		}

		private static byte[] CalculateMacKey(BigInteger keyingMaterial, IDigest digest)
		{
			return null;
		}

		public static void ValidateMacTag(string participantId, string partnerParticipantId, BigInteger gx1, BigInteger gx2, BigInteger gx3, BigInteger gx4, BigInteger keyingMaterial, IDigest digest, BigInteger partnerMacTag)
		{
		}

		private static void UpdateDigest(IDigest digest, BigInteger bigInteger)
		{
		}

		private static void UpdateDigest(IDigest digest, string str)
		{
		}

		private static void UpdateDigest(IDigest digest, byte[] bytes)
		{
		}

		private static void UpdateDigestIncludingSize(IDigest digest, BigInteger bigInteger)
		{
		}

		private static void UpdateDigestIncludingSize(IDigest digest, string str)
		{
		}

		private static void UpdateDigestIncludingSize(IDigest digest, byte[] bytes)
		{
		}

		private static void UpdateMac(IMac mac, BigInteger bigInteger)
		{
		}

		private static void UpdateMac(IMac mac, string str)
		{
		}

		private static void UpdateMac(IMac mac, byte[] bytes)
		{
		}

		private static byte[] IntToByteArray(int value)
		{
			return null;
		}
	}
}
